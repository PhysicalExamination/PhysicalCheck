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
        private GroupResultBusiness m_GroupResult;
        private ItemResultBusiness m_ItemResult;     

        public GetCheckedResultJob() {
            m_GroupResult = new GroupResultBusiness();
            m_ItemResult = new ItemResultBusiness();
        }

        public void Execute(IJobExecutionContext context) {
            List<GroupResultViewEntity> Groups = m_GroupResult.GetGroupInfo4LIS();
            List<LisEntity> LISResults;
            using (LISBusiness LISBusiness = new LISBusiness()) {
                foreach (GroupResultViewEntity Group in Groups) {
                    m_Logger.InfoFormat("从LIS中读取档案号{0}检验代码{1}体检结果数据.", Group.ID.RegisterNo, Group.LISCode);
                    try {
                        LISResults = LISBusiness.GetLisDatas(Group.ID.RegisterNo, Group.LISCode);//从LIS中读取结果数据                        
                        SaveItemResult(LISResults, Group.ID.GroupID,Group.DeptID);                      
                    }
                    catch (Exception ex) {
                        m_Logger.InfoFormat("档案号{0}" + ex.Message, Group.ID.RegisterNo);
                        m_Logger.Error(ex.Message, ex);
                    }
                    m_Logger.InfoFormat("档案号{0}检验代码{1}的体检结果数据保存成功.", Group.ID.RegisterNo, Group.LISCode);
                }
            }
        }
        
        /// <summary>
        /// 保存体检结果明细数据
        /// </summary>
        /// <param name="CheckResults"></param>
        private void SaveItemResult(List<LisEntity> CheckResults,int GroupID,int DeptID) {
            if (CheckResults.Count <= 0) return;
            ItemResultEntity ItemResult;
            String Summary = "";
            foreach (LisEntity Result in CheckResults) {
                ItemResult = new ItemResultEntity {
                    ID = new ItemResultPK {
                        RegisterNo = Result.RegisterNo,
                        GroupID = GroupID,
                        ItemID = Convert.ToInt32(Result.ItemID)
                    },
                    DeptID = DeptID,
                    ItemName = Result.ItemName,
                    CheckedResult = Result.QuantitativeResult,
                    QualitativeResult = GetQualitativeResult(Result.QualitativeResult),
                    MeasureUnit = Result.MeasureUnit,
                    CheckDoctor = Result.CheckPerson
                };
                String[] References = Result.Reference.Split('-');//参考范围
                if (References.Length == 2) {
                    ItemResult.LowerLimit = References[0];
                    ItemResult.UpperLimit = References[1];
                }
                Summary += GetSummary(Result.ItemName, Result.QualitativeResult);
                m_ItemResult.SaveItemResult(ItemResult);
                m_Logger.InfoFormat("档案号{0}检验项目{1}定性结论是{2}", Result.RegisterNo, Result.ItemID, Result.QualitativeResult);
            }
            if (!String.IsNullOrWhiteSpace(Summary)) {
                m_GroupResult.UpdateSummary(CheckResults[0].RegisterNo,GroupID, Summary);
            }
        }

        /// <summary>
        /// 返回检验项目偏高或偏低小结项
        /// </summary>
        /// <param name="CheckedResult"></param>
        /// <returns></returns>
        private String GetSummary(String ItemName,String QualitativeResult) {
            String Summary = "";
            if (String.IsNullOrEmpty(QualitativeResult)) return Summary;
            if (QualitativeResult.ToUpper() == "H") Summary = "【" + ItemName + "】偏高  "; 
            if (QualitativeResult.ToUpper() == "L") Summary = "【" + ItemName + "】偏低  ";
            return Summary;
        }

       /// <summary>
       /// 返回偏高或偏低上下箭头
       /// </summary>
       /// <param name="CheckedResult"></param>
       /// <returns></returns>
        private String GetQualitativeResult(String CheckedResult) {
            if (String.IsNullOrEmpty(CheckedResult)) return "";
            if (CheckedResult.ToUpper() == "H") return "↑";
            if (CheckedResult.ToUpper() == "L") return "↓";
            return "";
        }
        
    }
}
