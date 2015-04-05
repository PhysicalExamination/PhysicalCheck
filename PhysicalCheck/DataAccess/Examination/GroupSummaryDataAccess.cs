using DataEntity.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace DataAccess.Examination {

    public class GroupSummaryDataAccess:BaseDataAccess<GroupSummaryEntity> {

        #region 构造器

        public GroupSummaryDataAccess() {
        }
        #endregion

        #region 公共方法

        public void SaveGroupSummary(GroupSummaryEntity groupSummary) {
            Session.SaveOrUpdate(groupSummary);
            Session.Flush();
            CloseSession();
        }

        public void DeleteGroupSummary(String RegisterNo, int GroupID) {
            String HQL = @"DELETE GroupSummaryEntity  WHERE RegisterNo=? AND GroupID";
            ITransaction tx = Session.BeginTransaction();
            try {
                Session.CreateQuery(HQL)
                    .SetString(0, RegisterNo)
                    .SetInt32(1, GroupID)                   
                    .ExecuteUpdate();
                tx.Commit();
            }
            catch {
                tx.Rollback();
            }
            finally {
                CloseSession();
            }
        }

        #endregion
    }
}
