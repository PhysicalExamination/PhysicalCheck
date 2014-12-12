using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.Examination;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace DataAccess.Examination {

    /// <summary>
    /// 数据访问类:RegistrationDataAccess
    /// 文  件  名:RegistrationDataAccess.cs
    /// 说      明:体检登记数据访问对象
    /// </summary>
    public class RegistrationDataAccess : BaseDataAccess<RegistrationEntity> {

        #region 构造器

        public RegistrationDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有体检登记数据
        /// </summary>
        public IList<RegistrationViewEntity> GetRegistrations(int pageIndex, int pageSize,
            DateTime? CheckDate, String DeptName, String RegisterNo, out int RecordCount) {
            ICriteria Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.SetProjection(Projections.RowCount());
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Or(Restrictions.Eq("RegisterNo", RegisterNo),
                    Restrictions.Eq("IDNumber", RegisterNo)));
            }
            if (CheckDate != null) {
                Criteria.Add(Restrictions.Eq("RegisterDate", CheckDate));
            }
            RecordCount = Convert.ToInt32(Criteria.UniqueResult());

            Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.SetFirstResult((pageIndex - 1) * pageSize)
                    .SetMaxResults(pageSize);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Or(Restrictions.Eq("RegisterNo", RegisterNo),
                    Restrictions.Eq("IDNumber", RegisterNo)));
            }
            if (CheckDate != null) {
                Criteria.Add(Restrictions.Eq("RegisterDate", CheckDate));
            }
            IList<RegistrationViewEntity> Result = Criteria.List<RegistrationViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检登记数据
        /// </summary>
        /// <param name="PersonID"></param> 
        /// <param name="RegisterNo"></param> 
        /// <returns>体检登记实体</returns>
        public RegistrationViewEntity GetRegistration(string RegisterNo) {            
            RegistrationViewEntity Result = Session.Get<RegistrationViewEntity>(RegisterNo);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存体检登记数据
        /// </summary>
        /// <param name="Registration">体检登记实体</param>
        public void SaveRegistration(RegistrationEntity Registration) {
            if (String.IsNullOrWhiteSpace(Registration.RegisterNo)) Registration.RegisterNo = GetBillNo("Registration");
            Session.SaveOrUpdate(Registration);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检登记数据
        /// </summary>
        /// <param name="Registration">体检登记实体</param>
        public void DeleteRegistration(RegistrationEntity Registration) {
            Session.Delete(Registration);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
