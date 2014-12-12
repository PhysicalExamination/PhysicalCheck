using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Admin;

namespace DataAccess.Admin {

	/// <summary>
	/// 数据访问类:RolePermissionDataAccess
	/// 文  件  名:RolePermissionDataAccess.cs
	/// 说      明:角色权限数据访问对象
	/// </summary>
	public class RolePermissionDataAccess : BaseDataAccess<RolePermissionEntity> {

		#region 构造器

		public RolePermissionDataAccess() {

		}

		#endregion

		#region 公共方法

		/// <summary>
		///获取角色可操作的模块
		/// </summary>
		public List<RolePermissionEntity> GetRolePermissions(string RoleNo) {
			var q = from a in Session.Query<RolePermissionEntity>()
					join b in Session.Query<ModuleEntity>() on a.ModuleNo equals b.ModuleNo
					join c in Session.Query<RoleEntity>() on a.RoleNo equals c.RoleNo
					where a.RoleNo == RoleNo
					select new RolePermissionEntity {
						RoleNo = a.RoleNo,
						RoleName = c.RoleName,
						ModuleNo = a.ModuleNo,
						ModuleName = b.ModuleName
					};
			List<RolePermissionEntity> Result = q.ToList<RolePermissionEntity>();
			CloseSession();
			return Result;			
		}

		/// <summary>
        /// 获取角色权限数据
        /// </summary>
        /// <param name="RoleNo">角色编号</param> 
        /// <param name="ModuleNo">模块编号</param> 
        /// <returns>角色权限实体</returns>
		public RolePermissionEntity GetRolePermission(string RoleNo, string ModuleNo) {
			var q = from p in Session.Query<RolePermissionEntity>()
					where p.RoleNo == RoleNo && p.ModuleNo == ModuleNo
					select p;
			List<RolePermissionEntity> Result = q.ToList<RolePermissionEntity>();
			CloseSession();
			return Result.First();

		}

		/// <summary>
		/// 保存角色权限数据
		/// </summary>
		/// <param name="RolePermission">角色权限实体</param>        
		/// <returns>成功保存的行数</returns>
		public int SaveRolePermission(RolePermissionEntity RolePermission) {
			Session.SaveOrUpdate(RolePermission);
			Session.Flush();
			CloseSession();
			return 1;
		}

		/// <summary>
		/// 删除角色权限数据
		/// </summary>
		/// <param name="RolePermission">角色权限实体</param>        
		/// <returns>删除的数据行数</returns>
		public int DeleteRolePermission(RolePermissionEntity RolePermission) {
			Session.Delete(RolePermission);
			Session.Flush();
			CloseSession();
			return 1;
		}

		public int DeleteRolePermissions(String RoleNo) {
			int Result = 0;
			String hql = String.Format("from RolePermissionEntity Where RoleNo ='{0}'",RoleNo);
			Result= Session.Delete(hql);
			Session.Flush();
			CloseSession();
			return Result;
		}
		#endregion
	}
}
