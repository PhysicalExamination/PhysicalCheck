﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.Examination;
using NHibernate;
using NHibernate.Transaction;
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
            DateTime? RegisterDate, String DeptName, String RegisterNo, out int RecordCount) {
            ICriteria Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.SetProjection(Projections.RowCount());
            Criteria.Add(Restrictions.Eq("Enabled", true));
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Or(Restrictions.Eq("RegisterNo", RegisterNo),
                    Restrictions.Eq("IDNumber", RegisterNo)));
            }
            if (RegisterDate != null) {
                Criteria.Add(Restrictions.Eq("RegisterDate", RegisterDate));
            }            
            RecordCount = Convert.ToInt32(Criteria.UniqueResult());

            Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.Add(Restrictions.Eq("Enabled", true));
            Criteria.SetFirstResult((pageIndex - 1) * pageSize)
                    .SetMaxResults(pageSize);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Or(Restrictions.Eq("RegisterNo", RegisterNo),
                    Restrictions.Eq("IDNumber", RegisterNo)));
            }
            if (RegisterDate != null) {
                Criteria.Add(Restrictions.Eq("RegisterDate", RegisterDate));
            }
            
            IList<RegistrationViewEntity> Result = Criteria.List<RegistrationViewEntity>();    
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 返回所有通过体检但未总检的登记信息
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="CheckDate">体检日期</param>
        /// <param name="DeptName">单位名称</param>
        /// <param name="RegisterNo">登记号或身份证号</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public IList<RegistrationViewEntity> GetOveralls(int pageIndex, int pageSize,
            DateTime? CheckDate, String DeptName, String RegisterNo, out int RecordCount) {
            ICriteria Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.SetProjection(Projections.RowCount());
            Criteria.Add(Restrictions.Eq("Enabled",true));
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Or(Restrictions.Eq("RegisterNo", RegisterNo),
                    Restrictions.Eq("IDNumber", RegisterNo)));
            }
            if (CheckDate != null) {
                Criteria.Add(Restrictions.Eq("CheckDate", CheckDate));
            }
            if (String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Eq("IsCheckOver", false));
            }
            RecordCount = Convert.ToInt32(Criteria.UniqueResult());

            Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.Add(Restrictions.Eq("Enabled", true));
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
                Criteria.Add(Restrictions.Eq("CheckDate", CheckDate));
            }
            if (String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Eq("IsCheckOver", false));
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
            Registration.Enabled = false;
            Registration.PackageID = 1;
            Session.SaveOrUpdate(Registration);
            Session.Flush();
            CloseSession();
        }

        public void UpdateCheckDate(String RegisterNo ,DateTime CheckDate) {
            String HQL = @"Update RegistrationEntity set CheckDate =? AND RegisterNo=?";
            ITransaction tx = Session.BeginTransaction();
            try {
                Session.CreateQuery(HQL)
                    .SetDateTime(0, CheckDate)
                    .SetString(1, RegisterNo)
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
