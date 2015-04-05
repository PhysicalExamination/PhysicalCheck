using DataAccess.Examination;
using DataEntity.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Examination {

    public class GroupSummaryBusiness :BaseBusinessLogic<GroupSummaryDataAccess>{

        #region 构造器

        public GroupSummaryBusiness() {
        }

        #endregion

        #region 公共方法

        public void SaveGroupSummary(GroupSummaryEntity groupSummary) {
            DataAccess.SaveGroupSummary(groupSummary);
        }

        public void DeleteGroupSummary(String RegisterNo, int GroupID) {
            DataAccess.DeleteGroupSummary(RegisterNo, GroupID);
        }

        #endregion

    }
}
