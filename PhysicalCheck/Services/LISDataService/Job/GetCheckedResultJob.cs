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

    public class GetCheckedResultJob:IJob{

        private ILog m_Logger = LogHelper.Logger;
        private ItemResultBusiness m_ItemResult = new ItemResultBusiness();
        private CheckedItemBusiness m_CheckItem = new CheckedItemBusiness();
        private GroupResultBusiness m_GroupResult = new GroupResultBusiness();

        public void Execute(IJobExecutionContext context) {
            List<String> List = m_ItemResult.GetRegisterDataForLIS();
            List<LisEntity> CheckResults;
            using (LISBusiness LISBusiness = new LISBusiness()) {
                foreach (String RegisterNo in List) {
                    m_Logger.InfoFormat("从LIS中读取档案号{0}的体检结果数据", RegisterNo);
                    try
                    {
                        CheckResults = LISBusiness.GetLisDatas(RegisterNo);//从LIS中读取结果数据
                        UpdateCheckItem(CheckResults);
                        SaveItemResult(CheckResults);
                    }
                    catch (Exception ex)
                    {
                        m_Logger.InfoFormat("档案号{0}"+ex.Message , RegisterNo);
                    }
                    //SaveGroupResult(RegisterNo);
                   // m_Logger.InfoFormat("档案号{0}的体检结果数据保存成功", RegisterNo);
                }
            }           
        }

        public void run()
        {
            List<String> List = m_ItemResult.GetRegisterDataForLIS();
            List<LisEntity> CheckResults;
            using (LISBusiness LISBusiness = new LISBusiness())
            {
                foreach (String RegisterNo in List)
                {
                    m_Logger.InfoFormat("从LIS中读取档案号{0}的体检结果数据", RegisterNo);
                    CheckResults = LISBusiness.GetLisDatas(RegisterNo);//从LIS中读取结果数据
                    UpdateCheckItem(CheckResults);
                    SaveItemResult(CheckResults);
                    //SaveGroupResult(RegisterNo);
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
                ItemID = Convert.ToInt32(Item.ItemID);
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
                m_ItemResult.SaveItemResult(Result.RegisterNo,Convert.ToInt32(Result.ItemID),
                    Result.QuantitativeResult, Result.QualitativeResult, Result.CheckPerson);
            }          
        }

        private void SaveGroupResult(String RegisterNo) {
          
        }    
        /// <summary>
        /// 判断一个字符串是否为字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsNumeric(string str) {
            Regex reg = new  Regex(@"^[-]?\d+[.]?\d*$");
            return reg.IsMatch(str);
        }
    }
}
