using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Admin;


namespace DataAccess.Admin {

	public class RoleDataAccess : BaseDataAccess<RoleEntity> {

		#region 构造器

		public RoleDataAccess() {

		}

		#endregion 

		#region 公共方法

		/// <summary>
		///获取系统角色所有数据
		/// </summary>
		public List<RoleEntity> GetRoles() {
			List<RoleEntity> result = (from c in Session.Query<RoleEntity>() select c).ToList();
			CloseSession();
			return result;
		}

		/// <summary>
		/// 获取系统角色数据
		/// </summary>
		/// <param name="RoleNo">角色编号</param> 
		/// <returns>系统角色实体</returns>
		public RoleEntity GetRole(string RoleNo) {
			RoleEntity result = Session.Get<RoleEntity>(RoleNo);
			CloseSession();
			return result;
		}

		/// <summary>
		/// 保存系统角色数据
		/// </summary>
		/// <param name="Role">系统角色实体</param>        
		/// <returns>成功保存的行数</returns>
		public int SaveRole(RoleEntity Role) {
			if (String.IsNullOrEmpty(Role.RoleNo)) Role.RoleNo =  GetLineID("Role")+"";
			Session.SaveOrUpdate(Role);
			Session.Flush();
			CloseSession();
			return 1;
		}

		/// <summary>
		/// 删除系统角色数据
		/// </summary>
		/// <param name="Role">系统角色实体</param>        
		/// <returns>删除的数据行数</returns>
		public int DeleteRole(RoleEntity Role) {
			Session.Delete(Role);
			Session.Flush();
			CloseSession();
			return 1;
		}

		#endregion
	}
}
