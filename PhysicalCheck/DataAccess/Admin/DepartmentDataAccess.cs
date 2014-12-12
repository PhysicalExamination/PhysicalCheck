using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.Admin;
using NHibernate;
using NHibernate.Linq;

namespace DataAccess.Admin {
	
	public class DepartmentDataAccess:BaseDataAccess<DepartmentEntity> {

		#region 构造器

		public DepartmentDataAccess() {
		}

		#endregion

		#region 公共方法

		/// <summary>
		/// 返回部门信息
		/// </summary>
		/// <param name="DeptNo">部门编号</param>
		/// <returns></returns>
		public DepartmentEntity GetDepartment(int DeptID) {
            DepartmentEntity Result = Session.Get<DepartmentEntity>(DeptID);
			CloseSession();
			return Result;
		}

		/// <summary>
		/// 返回所有部门信息
		/// </summary>
		/// <returns></returns>
        public List<DepartmentEntity> GetDepartments(int pageIndex, int pageSize, out int RecordCount) {
            String hql = @"select count(DeptID) from DepartmentEntity  where Enabled=true order by DisplayOrder";
            IQuery query = Session.CreateQuery(hql);               
            object obj = query.UniqueResult();
            int.TryParse(obj.ToString(), out RecordCount);
            hql = @" from DepartmentEntity where Enabled=true order by DisplayOrder";
            List<DepartmentEntity> Result = Session.CreateQuery(hql)                                               
                                                .SetFirstResult((pageIndex - 1) * pageSize)
                                                .SetMaxResults(pageSize)
                                                .List<DepartmentEntity>().ToList<DepartmentEntity>();
            CloseSession();
            return Result;
		}

		/// <summary>
		/// 保存部门信息
		/// </summary>
		/// <param name="Department">部门信息实体</param>
		/// <returns></returns>
		public int SaveDepartment(DepartmentEntity Department) {
            if (Department.DeptID == null) Department.DeptID = GetLineID("Department");
			Session.SaveOrUpdate(Department);
			Session.Flush();
			CloseSession();
			return 1;
		}

		/// <summary>
		/// 删除部门信息
		/// </summary>
		/// <param name="Department">部门信息实体</param>
		/// <returns></returns>
		public int DeleteDepartment(DepartmentEntity Department) {
			Session.Delete(Department);
			Session.Flush();
			CloseSession();
			return 1;
		}

		#endregion
	}
}
