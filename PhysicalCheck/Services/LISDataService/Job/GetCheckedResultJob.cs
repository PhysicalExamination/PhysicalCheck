using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using BusinessLogic.Examination;
using DataEntity.Examination;

namespace LISDataService.Job {

    public class GetCheckedResultJob:IJob{
        private ItemResultBusiness m_ItemResult = new ItemResultBusiness();
        private GroupResultBusiness m_GroupResult = new GroupResultBusiness();

        public void Execute(IJobExecutionContext context) {
            List<GroupResultViewEntity> List = m_GroupResult.GetGroupForLis();
            List<LisEntity> CheckResults;
            using (LISBusiness LISBusiness = new LISBusiness()) {
                foreach (GroupResultViewEntity Group in List) {
                    CheckResults = LISBusiness.GetLisDatas(Group.ID.RegisterNo, Group.ID.GroupID + "");//从LIS中读取结果数据
                    SaveGroupResult(CheckResults);
                    SaveItemResult(CheckResults);
                }
            }           
        }

        private void SaveGroupResult(List<LisEntity> CheckResults) {

        }

        private void SaveItemResult(List<LisEntity> CheckResults) {
            foreach (LisEntity Result in CheckResults) {
                m_ItemResult.SaveItemResult(Result.RegisterNo,Convert.ToInt32(Result.ItemID), Result.ItemResult);
            }
            //
        }
    }
}
