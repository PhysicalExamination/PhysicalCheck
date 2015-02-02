using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using BusinessLogic.Examination;
using DataEntity.Examination;

namespace LISDataService.Job {

    public class GetCheckedResultJob:IJob{             

        public void Execute(IJobExecutionContext context) {
            GroupResultBusiness GroupResult = new GroupResultBusiness();
            List<GroupResultViewEntity> List = GroupResult.GetGroupForLis();
            List<LisEntity> CheckResult;
            using (LISBusiness LISBusiness = new LISBusiness()) {
                foreach (GroupResultViewEntity Group in List) {
                    CheckResult = LISBusiness.GetLisDatas(Group.ID.RegisterNo, Group.ID.GroupID + "");
                    SaveGroupResult(CheckResult);
                    SaveItemResult(CheckResult);
                }
            }           
        }

        private void SaveGroupResult(List<LisEntity> CheckResult) {
        }

        private void SaveItemResult(List<LisEntity> CheckResult) {
        }
    }
}
