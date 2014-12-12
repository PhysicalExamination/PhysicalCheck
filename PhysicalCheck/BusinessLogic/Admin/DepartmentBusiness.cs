using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Admin;
using DataEntity.Admin;

namespace BusinessLogic.Admin {

	/// <summary>
	/// 部门信息业务逻辑
	/// </summary>
	public class DepartmentBusiness:BaseBusinessLogic<DepartmentDataAccess> {

		#region 构造器

		public DepartmentBusiness() {
		}

		#endregion

		#region 公共方法
		/// <summary>
		/// 返回部门信息
		/// </summary>
		/// <param name="DeptNo">部门编号</param>
		/// <returns></returns>
		public DepartmentEntity GetDepartment(Int32 DeptNo) {
			return DataAccess.GetDepartment(DeptNo);
		}

		/// <summary>
		/// 返回所有部门信息
		/// </summary>
		/// <returns></returns>
        public List<DepartmentEntity> GetDepartments(int pageIndex, int pageSize, out int RecordCount) {
            return DataAccess.GetDepartments(pageIndex, pageSize, out RecordCount);
		}

		/// <summary>
		/// 保存部门信息
		/// </summary>
		/// <param name="Department">部门信息实体</param>
		/// <returns></returns>
		public int SaveDepartment(DepartmentEntity Department) {
			return DataAccess.SaveDepartment(Department);
		}

		/// <summary>
		/// 删除部门信息
		/// </summary>
		/// <param name="Department">部门信息实体</param>
		/// <returns></returns>
		public int DeleteDepartment(DepartmentEntity Department) {
			return DataAccess.DeleteDepartment(Department);
		}


		#endregion
	}
}
