using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Examination;
using NHibernate.Criterion;

namespace DataAccess.Examination {

    /// <summary>
    /// 数据访问类:PhysicalDepartmentDataAccess
    /// 文  件  名:PhysicalDepartmentDataAccess.cs
    /// 说      明:体检单位数据访问对象
    /// </summary>
    public class PhysicalDepartmentDataAccess : BaseDataAccess<PhysicalDepartmentEntity> {

        #region 构造器

        public PhysicalDepartmentDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有体检单位数据
        /// </summary>
        public IList<PhysicalDepartmentEntity> GetPhysicalDepartments(int pageIndex, int pageSize,
            String DeptName, out int RecordCount) {
            ICriteria Criteria = Session.CreateCriteria<PhysicalDepartmentEntity>();
            Criteria.SetProjection(Projections.RowCount());
            Criteria.Add(Restrictions.Eq("Enabled",true));
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            RecordCount = Convert.ToInt32(Criteria.UniqueResult());

            Criteria = Session.CreateCriteria<PhysicalDepartmentEntity>();
            Criteria.Add(Restrictions.Eq("Enabled", true));
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                Criteria.Add(Restrictions.Like("DeptName", DeptName, MatchMode.Anywhere));
            }
            Criteria.SetFirstResult((pageIndex - 1) * pageSize)
                    .SetMaxResults(pageSize);
            Criteria.AddOrder(new Order("DeptID", true));
            IList<PhysicalDepartmentEntity> Result = Criteria.List<PhysicalDepartmentEntity>();
            /*String RecordCounthql = @"select count(DeptID) from PhysicalDepartmentEntity";
            String hql = @" from PhysicalDepartmentEntity";
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                DeptName = "'%" + DeptName + "%'";
                RecordCounthql = @"select count(DeptID) from PhysicalDepartmentEntity where DeptName like ?";
                hql = @" from PhysicalDepartmentEntity where DeptName like ?";
            }
            IQuery query;
            if (!String.IsNullOrWhiteSpace(DeptName)) {
                query = Session.CreateQuery(RecordCounthql).SetString(0, DeptName);
                object obj = query.UniqueResult();
                int.TryParse(obj.ToString(), out RecordCount);

                query = Session.CreateQuery(hql)
                  .SetString(0, DeptName)
                  .SetFirstResult((pageIndex - 1) * pageSize)
                  .SetMaxResults(pageSize);
            }
            else {
                query = Session.CreateQuery(RecordCounthql);
                object obj = query.UniqueResult();
                int.TryParse(obj.ToString(), out RecordCount);

                query = Session.CreateQuery(hql)
                  .SetFirstResult((pageIndex - 1) * pageSize)
                  .SetMaxResults(pageSize);
            }
            List<PhysicalDepartmentEntity> Result =
                query.List<PhysicalDepartmentEntity>().ToList<PhysicalDepartmentEntity>();*/
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检单位数据
        /// </summary>
        /// <param name="DeptID"></param> 
        /// <returns>体检单位实体</returns>
        public PhysicalDepartmentEntity GetPhysicalDepartment(int DeptID) {
            PhysicalDepartmentEntity Result = Session.Get<PhysicalDepartmentEntity>(DeptID);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 通过体检单位名称返回体检单位编码
        /// </summary>
        /// <param name="DeptName"></param>
        /// <returns></returns>
        public int GetPhysicalDepartmentID(String DeptName) {
            var q = Session.Query<PhysicalDepartmentEntity>();
            q = q.Where(p => p.Enabled == true && p.DeptName.Contains(DeptName));
           List<PhysicalDepartmentEntity> Depts = q.ToList();
           if (Depts.Count > 0) return Depts.First().DeptID.Value;
           return int.MinValue;
        }

        /// <summary>
        /// 保存体检单位数据
        /// </summary>
        /// <param name="PhysicalDepartment">体检单位实体</param>
        public void SavePhysicalDepartment(PhysicalDepartmentEntity PhysicalDepartment) {
            if (PhysicalDepartment.DeptID == int.MinValue) PhysicalDepartment.DeptID = GetLineID("PhysicalDepartment");
            PhysicalDepartment.Enabled = true;
            Session.SaveOrUpdate(PhysicalDepartment);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检单位数据
        /// </summary>
        /// <param name="PhysicalDepartment">体检单位实体</param>
        public void DeletePhysicalDepartment(PhysicalDepartmentEntity PhysicalDepartment) {
            PhysicalDepartment.Enabled = false;
            Session.SaveOrUpdate(PhysicalDepartment);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
