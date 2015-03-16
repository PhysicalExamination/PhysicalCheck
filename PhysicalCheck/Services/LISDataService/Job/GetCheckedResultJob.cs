using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using BusinessLogic.Examination;
using BusinessLogic.SysConfig;
using DataEntity.Examination;
using log4net;
using DataEntity.SysConfig;
using System.Text.RegularExpressions;


namespace LISDataService.Job {

    public class GetCheckedResultJob : IJob {

        private ILog m_Logger = LogHelper.Logger;
        private GroupResultBusiness m_GroupResultBusiness = new GroupResultBusiness();
        private ItemResultBusiness m_ItemResult = new ItemResultBusiness();
        private CheckedItemBusiness m_CheckItem = new CheckedItemBusiness();
        private GroupResultBusiness m_GroupResult = new GroupResultBusiness();
        private List<LisMapEntity> m_LISMaps;

        public GetCheckedResultJob() {
            using (LISMapBusiness m_LISMap = new LISMapBusiness()) {
                m_LISMaps = m_LISMap.GetLISMaps();
            }
        }

        public void Execute(IJobExecutionContext context) {
            List<String> List = m_ItemResult.GetRegisterDataForLIS();

            List<LisEntity> CheckResults;
            using (LISBusiness LISBusiness = new LISBusiness()) {
                foreach (String RegisterNo in List) {
                    m_Logger.InfoFormat("从LIS中读取档案号{0}的体检结果数据", RegisterNo);
                    try {
                        CheckResults = LISBusiness.GetLisDatas(RegisterNo);//从LIS中读取结果数据
                        UpdateCheckItem(CheckResults);
                        SaveItemResult(CheckResults);
                        UpdateGroupSummary(RegisterNo);
                    }
                    catch (Exception ex) {
                        m_Logger.InfoFormat("档案号{0}" + ex.Message, RegisterNo);
                    }
                    //SaveGroupResult(RegisterNo);
                    // m_Logger.InfoFormat("档案号{0}的体检结果数据保存成功", RegisterNo);
                }
            }
        }

        public void RunJob() {
            List<String> List = m_ItemResult.GetRegisterDataForLIS();
            List<LisEntity> CheckResults;
            using (LISBusiness LISBusiness = new LISBusiness()) {
                foreach (String RegisterNo in List) {
                    m_Logger.InfoFormat("从LIS中读取档案号{0}的体检结果数据", RegisterNo);
                    CheckResults = LISBusiness.GetLisDatas(RegisterNo);//从LIS中读取结果数据
                    UpdateCheckItem(CheckResults);
                    SaveItemResult(CheckResults);
                    UpdateGroupSummary(RegisterNo);
                    m_Logger.InfoFormat("档案号{0}的体检结果数据保存成功", RegisterNo);
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 保存体检明细项参考上下限及单位
        /// </summary>
        /// <param name="CheckResults"></param>
        private void UpdateCheckItem(List<LisEntity> CheckResults) {
            int ItemID;
            CheckedItemEntity CheckedItem;
            String[] References;//参考范围
            foreach (LisEntity Item in CheckResults) {
                ItemID = GetCheckedItemID(Item.ItemID);
                CheckedItem = m_CheckItem.GetCheckedItem(ItemID);
                CheckedItem.MeasureUnit = Item.MeasureUnit;
                References = Item.Reference.Split('-');
                if (References.Length == 2) {
                    CheckedItem.MinValue = Convert.ToDecimal(References[0]);
                    CheckedItem.MaxValue = Convert.ToDecimal(References[1]);
                    CheckedItem.LowerLimit = References[0];
                    CheckedItem.UpperLimit = References[1];
                }
                if (References.Length == 1) {
                    CheckedItem.NormalTips = References[0];
                }
                m_CheckItem.SaveCheckedItem(CheckedItem);
            }
        }

        /// <summary>
        /// 保存体检结果明细数据
        /// </summary>
        /// <param name="CheckResults"></param>
        private void SaveItemResult(List<LisEntity> CheckResults) {
            foreach (LisEntity Result in CheckResults) {
                m_ItemResult.SaveItemResult(Result.RegisterNo, GetCheckedItemID(Result.ItemID),
                    Result.QuantitativeResult, Result.QualitativeResult, Result.CheckPerson);
                m_Logger.InfoFormat("档案号{0}检验项目{1}定性结论是{2}", Result.RegisterNo, Result.ItemID, Result.QualitativeResult);
            }
        }

        private void UpdateGroupSummary(String RegisterNo) {
            try {
                List<GroupResultViewEntity> Groups = m_GroupResultBusiness.GetGroupResults(RegisterNo);
                List<ItemResultViewEntity> ItemResults;
                String Summary = "";
                List<string> Items;
                foreach (GroupResultViewEntity Group in Groups) {
                    ItemResults = m_ItemResult.GetItemResults(RegisterNo, Group.ID.GroupID);
                    Items = ItemResults.Where(p => p.QualitativeResult == "↑").Select(p => p.ItemName).ToList();
                    foreach (String Item in Items) {
                        Summary += "【" + Item + "】偏高  ";
                    }
                    Items = ItemResults.Where(p => p.QualitativeResult == "↓").Select(p => p.ItemName).ToList();
                    foreach (String Item in Items) {
                        Summary += "【" + Item + "】偏低  ";
                    }
                    if (!String.IsNullOrWhiteSpace(Summary)) {
                        m_GroupResultBusiness.UpdateSummary(RegisterNo, Group.ID.GroupID, Summary);
                    }
                }
            }
            catch (Exception ex) {
                m_Logger.InfoFormat("保存小结时发生了错误。" + ex.Message, RegisterNo);
            }

        }


        /// <summary>
        /// 根据LIS代码返回检验项代码
        /// </summary>
        /// <param name="LIS_Checked_ItemID"></param>
        /// <returns></returns>
        private int GetCheckedItemID(string LIS_Checked_ItemID) {
            var q = m_LISMaps.Where(p => p.LisItemId1 == LIS_Checked_ItemID ||
                                         p.LisItemId2 == LIS_Checked_ItemID);
            List<LisMapEntity> Result = q.ToList();
            if (Result.Count > 0) return Result.First().Itemid;
            return 0;
        }
    }
}
