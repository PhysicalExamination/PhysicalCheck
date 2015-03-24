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
        /// 返回团体体检未预约数据
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="RegisterDate">登记日期</param>
        /// <param name="DeptName">体检单位</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public List<RegistrationViewEntity> GetAppointments(int pageIndex, int pageSize,
            DateTime? RegisterDate, String DeptName, out int RecordCount) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true && p.DeptID > 1 && p.CheckDate == null);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }
            if (String.IsNullOrWhiteSpace(DeptName) && (RegisterDate != null)) {
                q = q.Where(p => p.RegisterDate >= RegisterDate);
            }
            q = q.OrderByDescending(p => p.RegisterNo);
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 返回团体正式体检数据
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="CheckDate">体检日期</param>
        /// <param name="DeptName">体检单位</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public List<RegistrationViewEntity> GetFormalRegistrations(int pageIndex, int pageSize,
            DateTime? CheckDate, String DeptName, out int RecordCount) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true && p.DeptID > 1);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }
            if (String.IsNullOrWhiteSpace(DeptName) && (CheckDate != null)) {
                q = q.Where(p => p.CheckDate >= CheckDate);
            }
            q = q.OrderByDescending(p => p.RegisterNo);
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }


        /// <summary>
        /// 返回团体登记数据
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="RegisterDate">登记日期</param>
        /// <param name="DeptName">体检单位</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public List<RegistrationViewEntity> GetGroupRegistrations(int pageIndex, int pageSize,
            DateTime? RegisterDate, String DeptName, out int RecordCount) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true && p.DeptID > 1);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }
            if (String.IsNullOrWhiteSpace(DeptName) && (RegisterDate != null)) {
                q = q.Where(p => p.RegisterDate >= RegisterDate);
            }
            q = q.OrderByDescending(p => p.RegisterNo);
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 返回个体登记数据
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="RegisterDate">登记日期</param>
        /// <param name="RegisterNo">身份证号/档案号</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public List<RegistrationViewEntity> GetIndividualRegistrations(int pageIndex, int pageSize,
            DateTime? RegisterDate, String RegisterNo, out int RecordCount) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true && p.DeptID == 1);

            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                q = q.Where(p => p.RegisterNo == RegisterNo || p.IDNumber == RegisterNo);
            }
            if (String.IsNullOrWhiteSpace(RegisterNo) && (RegisterDate != null)) {
                q = q.Where(p => p.RegisterDate >= RegisterDate);
            }
            q = q.OrderByDescending(p => p.RegisterNo);
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }


        /// <summary>
        ///获取所有体检登记数据
        /// </summary>
        public List<RegistrationViewEntity> GetRegistrations(int pageIndex, int pageSize,
            DateTime? RegisterDate, String DeptName, String RegisterNo, out int RecordCount) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                q = q.Where(p => p.RegisterNo == RegisterNo || p.IDNumber == RegisterNo);
            }
            if (String.IsNullOrWhiteSpace(RegisterNo) && String.IsNullOrWhiteSpace(DeptName) && (RegisterDate != null)) {
                q = q.Where(p => p.RegisterDate == RegisterDate);
            }
            q = q.OrderByDescending(p => p.RegisterNo);
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取某天或体检单位的所有体检登记数据
        /// </summary>
        /// <param name="RegisterDate"></param>
        /// <param name="DeptName"></param>
        /// <returns></returns>
        public List<RegistrationViewEntity> GetRegistrationForReport(DateTime? RegisterDate, String DeptName) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }

            if (String.IsNullOrWhiteSpace(DeptName) && (RegisterDate != null)) {
                q = q.Where(p => p.RegisterDate == RegisterDate);
            }
            List<RegistrationViewEntity> Result = q.ToList();
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
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true && p.IsCheckOver == false);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                q = q.Where(p => p.RegisterNo == RegisterNo || p.IDNumber == RegisterNo);
            }
            if (String.IsNullOrWhiteSpace(RegisterNo) && String.IsNullOrWhiteSpace(DeptName) && (CheckDate != null)) {
                q = q.Where(p => p.CheckDate == CheckDate);
            }
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
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
            DateTime? OverallDate, String DeptName, String RegisterNo, out int RecordCount) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true && p.IsCheckOver == true);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                q = q.Where(p => p.RegisterNo == RegisterNo || p.IDNumber == RegisterNo);
            }
            if (String.IsNullOrWhiteSpace(RegisterNo) && String.IsNullOrWhiteSpace(DeptName) && (OverallDate != null)) {
                q = q.Where(p => p.OverallDate == OverallDate);
            }
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
            /*ICriteria Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.SetProjection(Projections.RowCount());
            Criteria.Add(Restrictions.Eq("Enabled", true));
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Or(Restrictions.Eq("RegisterNo", RegisterNo),
                    Restrictions.Eq("IDNumber", RegisterNo)));
            }
            if (OverallDate != null) {
                Criteria.Add(Restrictions.Eq("OverallDate", OverallDate));
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
            if (CheckDate != null) {
                Criteria.Add(Restrictions.Eq("OverallDate", CheckDate));
            }
            if (String.IsNullOrWhiteSpace(RegisterNo)) {
                Criteria.Add(Restrictions.Eq("IsCheckOver", true));
            }
            IList<RegistrationViewEntity> Result = Criteria.List<RegistrationViewEntity>();
            CloseSession();
            return Result;*/
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
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true && p.ReviewDate >= StartDate && p.ReviewDate <= EndDate);
            List<RegistrationViewEntity> Result = q.ToPagedList<RegistrationViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
            /*ICriteria Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.SetProjection(Projections.RowCount());
            Criteria.Add(Restrictions.Eq("Enabled", true));
            Criteria.Add(Restrictions.Between("ReviewDate", StartDate, EndDate));
            RecordCount = Convert.ToInt32(Criteria.UniqueResult());

            Criteria = Session.CreateCriteria<RegistrationViewEntity>();
            Criteria.Add(Restrictions.Eq("Enabled", true));
            Criteria.SetFirstResult((pageIndex - 1) * pageSize)
                    .SetMaxResults(pageSize);
            Criteria.Add(Restrictions.Between("ReviewDate", StartDate, EndDate));
            IList<RegistrationViewEntity> Result = Criteria.List<RegistrationViewEntity>();
            CloseSession();
            return Result;*/
        }

        /// <summary>
        /// 返回体检结果录入时的树形数据
        /// </summary>
        /// <param name="CheckedDate">体检日期</param>
        /// <param name="DeptName">体检单位</param>
        /// <param name="RegisterNo">登记号或身份证号</param>
        /// <returns></returns>
        public List<RegisterTreeData> GetRegistrationTree(DateTime? CheckedDate,
            String DeptName, String RegisterNo) {
            var q = Session.Query<RegistrationViewEntity>();
            q = q.Where(p => p.Enabled == true);
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                q = q.Where(p => p.DeptName.Contains(DeptName));
            }
            if (!String.IsNullOrWhiteSpace(RegisterNo)) {
                q = q.Where(p => p.RegisterNo == RegisterNo || p.IDNumber == RegisterNo);
            }
            if (String.IsNullOrWhiteSpace(RegisterNo) && String.IsNullOrWhiteSpace(DeptName) && (CheckedDate != null)) {
                q = q.Where(p => p.CheckDate == CheckedDate);
            }
            q = q.OrderByDescending(p => p.RegisterNo);
            var m = q.Select(p => new RegisterTreeData {
                GroupID = p.RegisterNo,
                GroupName = p.Name
            });
            List<RegisterTreeData> Nodes = m.ToList<RegisterTreeData>();
            IQueryable<GroupResultViewEntity> g;
            foreach (RegisterTreeData Node in Nodes) {
                g = Session.Query<GroupResultViewEntity>();
                g = g.Where(p => p.ID.RegisterNo == Node.GroupID);
                Node.CheckedGroups = g.Select(p => new RegisterTreeData {
                    GroupID = p.ID.RegisterNo + "," + p.ID.GroupID,
                    GroupName = p.GroupName
                }).ToList<RegisterTreeData>();
            }
            CloseSession();
            return Nodes;
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

        /// <summary>
        /// 保存批量体检结果
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <param name="OverallDate">总检日期</param>
        /// <param name="OverallDoctor">总检医生</param>
        /// <param name="Summary">综述</param>
        /// <param name="Recommend">体检建议</param>
        /// <param name="Conclusion">体检结论</param>
        public void SaveOverall(String RegisterNo, DateTime OverallDate, String OverallDoctor, String Summary,
                                String Recommend, String Conclusion) {
            String HQL = @"Update RegistrationEntity set OverallDate =?,OverallDoctor=?,IsCheckOver=?,
                           Summary=?,Recommend=?,Conclusion=? WHERE RegisterNo=?";
            ITransaction tx = Session.BeginTransaction();
            try {
                Session.CreateQuery(HQL)
                    .SetDateTime(0, OverallDate)
                    .SetString(1, OverallDoctor)
                    .SetBoolean(2, true)
                    .SetString(3, Summary)
                    .SetString(4, Recommend)
                    .SetString(5, Conclusion)
                    .SetString(6, RegisterNo)
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

        /// <summary>
        /// 保存体检预约
        /// </summary>
        /// <param name="RegisterNo">档案号</param>
        /// <param name="CheckDate">预约体检日期</param>
        public void SaveCheckAppointment(String RegisterNo, DateTime CheckDate) {
            String HQL = @"Update RegistrationEntity set CheckDate =? WHERE RegisterNo=?";
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

        /// <summary>
        /// 撤销总检
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <param name="Doctor">总检医生</param>
        /// <returns></returns>
        public int CancelOverallCheck(String RegisterNo, String Doctor) {
            int Result = 0;
            String HQL = @"Update RegistrationEntity set OverallDate =null,OverallDoctor='',IsCheckOver=0
                           WHERE RegisterNo=? AND OverallDoctor=?";
            ITransaction tx = Session.BeginTransaction();
            try {
                Result = Session.CreateQuery(HQL)
                         .SetString(0, RegisterNo)
                         .SetString(1, Doctor)
                         .ExecuteUpdate();
                tx.Commit();
            }
            catch {
                tx.Rollback();
            }
            finally {
                CloseSession();
            }
            return Result;
        }

        #endregion
    }
}
