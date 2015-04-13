using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.Examination;
using PagedList;
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
            Criteria.AddOrder(new Order("RegisterNo", true));
            IList<RegistrationViewEntity> Result = Criteria.List<RegistrationViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 返回体检人员信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="CheckDate"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public List<RegistrationViewEntity> GetCheckedList(int pageIndex, int pageSize,
            DateTime CheckDate, out int RecordCount) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true && p.CheckDate == CheckDate && p.IsCheckOver == false);
            q = q.OrderBy(p => p.RegisterNo);
            RecordCount = q.Count();
            return q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
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
        public List<RegistrationViewEntity> GetOveralls(int pageIndex, int pageSize,
            DateTime? CheckDate, String DeptName, String RegisterNo, out int RecordCount) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                q = q.Where(p => p.RegisterNo == RegisterNo || p.IDNumber == RegisterNo);
            }
            if (CheckDate != null) {
                q = q.Where(p => p.CheckDate == CheckDate);
            }
            if (String.IsNullOrWhiteSpace(RegisterNo)) {
                q = q.Where(p => p.IsCheckOver == false);
            }
            q = q.OrderBy(p => p.RegisterNo);          
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
            foreach (var Registration in Result) {
                Registration.Status = GetCheckedStatus(Registration.RegisterNo);
            }
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        ///返回所有通过体检的登记信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="CheckDate"></param>
        /// <param name="DeptName"></param>
        /// <param name="RegisterNo"></param>
        /// <param name="RecordCount"></param>
        /// <returns></returns>
        public IList<RegistrationViewEntity> GetCheckReports(int pageIndex, int pageSize,
            DateTime? CheckDate, String DeptName, String RegisterNo, out int RecordCount) {
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
            if (String.IsNullOrWhiteSpace(RegisterNo)&&(CheckDate != null)) {
                Criteria.Add(Restrictions.Eq("CheckDate", CheckDate));
            }
            if (String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Eq("IsCheckOver", true));
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
            if (String.IsNullOrWhiteSpace(RegisterNo) && (CheckDate != null)) {
                Criteria.Add(Restrictions.Eq("CheckDate", CheckDate));
            }
            if (String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Eq("IsCheckOver", true));
            }
            Criteria.AddOrder(new Order("RegisterNo", true));
            IList<RegistrationViewEntity> Result = Criteria.List<RegistrationViewEntity>();
            CloseSession();
            return Result;
        }


        /// <summary>
        /// 返回复检人员信息
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="StartDate">开始日期</param>
        /// <param name="EndDate">截止日期</param>       
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public IList<RegistrationViewEntity> GetReviews(int pageIndex, int pageSize,
            DateTime StartDate, DateTime EndDate, out int RecordCount) {
            ICriteria Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.SetProjection(Projections.RowCount());
            Criteria.Add(Restrictions.Eq("Enabled", true));
            Criteria.Add(Restrictions.Between("ReviewDate", StartDate, EndDate));
            RecordCount = Convert.ToInt32(Criteria.UniqueResult());

            Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.Add(Restrictions.Eq("Enabled", true));
            Criteria.SetFirstResult((pageIndex - 1) * pageSize)
                    .SetMaxResults(pageSize);
            Criteria.Add(Restrictions.Between("ReviewDate", StartDate, EndDate));
            Criteria.AddOrder(new Order("RegisterNo", true));
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
            Registration.Enabled = true;
            Session.SaveOrUpdate(Registration);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检登记数据
        /// </summary>
        /// <param name="Registration">体检登记实体</param>
        public void DeleteRegistration(String RegisterNo) {
            RegistrationEntity Registration = Session.Get<RegistrationEntity>(RegisterNo);
            Registration.Enabled = false;
            Session.SaveOrUpdate(Registration);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 保存复查通知数据
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <param name="InformResult">通知情况0-未留联系方式、1-未联系到、2-已通知</param>
        /// <param name="InformPerson">通知人</param>
        public void SaveReview(String RegisterNo, String InformResult, String InformPerson) {
            String HQL = @"Update RegistrationEntity set InformResult =?,InformPerson=? WHERE RegisterNo=?";
            ITransaction tx = Session.BeginTransaction();
            try {
                Session.CreateQuery(HQL)
                    .SetString(0, InformResult)
                    .SetString(1, InformPerson)
                    .SetString(2, RegisterNo)
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

        #region 私有成员

        /// <summary>
        /// 返回体检状态 0待检、1合格 、2不合格
        /// </summary>
        private String GetCheckedStatus(String RegisterNo) {
            var q = Session.Query<GroupResultEntity>();
            q = q.Where(p => p.ID.RegisterNo == RegisterNo);
            if (q.Count(p => p.IsOver == false) > 0) return "0";//待检
            if (q.Count(p => p.IsOver == true && p.IsPassed == false) > 0) return "2";//不合格
            return "1";//合格
        }

        #endregion
    }
}
