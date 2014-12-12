using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Admin;
using DataEntity.Admin;

namespace BusinessLogic.Admin {

	/// <summary>
	/// 业务逻辑类:RoleBusiness
	/// 文  件  名:RoleBusiness.cs
	/// 说      明:系统角色业务逻辑对象
	/// </summary>
	public class RoleBusiness : BaseBusinessLogic<RoleDataAccess> {

		#region 构造器

		public RoleBusiness() {

		}

		#endregion

		#region 公共方法

		/// <summary>
		///获取属于角色的所有用户数据
		///<param name="RoleNo">角色编号</param>
		/// </summary>
		public List<RoleMemberEntity> GetRoleMembers(string RoleNo) {
			List<RoleMemberEntity> Result;
			using (RoleMemberDataAccess RoleMember = new RoleMemberDataAccess()) {
				Result = RoleMember.GetRoleMembers(RoleNo);
			}
			return Result;
		}

		public List<RoleEntity> GetRoles() {
			return DataAccess.GetRoles();
		}

		public RoleEntity GetRole(string RoleNo) {
			return DataAccess.GetRole(RoleNo);
		}

		/// <summary>
		///获取角色可操作的模块
		/// </summary>
		public List<RolePermissionEntity> GetRolePermissions(string RoleNo) {
			List<RolePermissionEntity> Result;
			using (RolePermissionDataAccess RolePermission = new RolePermissionDataAccess()) {
				Result = RolePermission.GetRolePermissions(RoleNo);
			}
			return Result;
		}

		public int SaveRole(RoleEntity Role) {
			return DataAccess.SaveRole(Role);
		}

		public int DeleteRole(RoleEntity Role) {
			return DataAccess.DeleteRole(Role);
		}

		/// <summary>
		/// 保存系统角色成员数据
		/// </summary>
		/// <param name="RoleMember">系统角色成员实体</param>        
		/// <returns>成功保存的行数</returns>
		public int SaveRoleMember(RoleMemberEntity roleMember) {
			int Result = 0;
			using (RoleMemberDataAccess RoleMember = new RoleMemberDataAccess()) {
				Result = RoleMember.SaveRoleMember(roleMember);
			}
			return Result;
		}

		public void SaveRolePermission(RolePermissionEntity Permission) {
			using (RolePermissionDataAccess RolePermission = new RolePermissionDataAccess()) {
				RolePermission.SaveRolePermission(Permission);
			}
		}

		public int DeleteRolePermissions(String RoleNo) {
			using (RolePermissionDataAccess RolePermission = new RolePermissionDataAccess()) {
				return RolePermission.DeleteRolePermissions(RoleNo);
			}
		}

		/// <summary>
		/// 删除系统角色成员数据
		/// </summary>
		/// <param name="RoleMember">系统角色成员实体</param>
		/// <param name="UserNo">执行删除操作的用户编号</param>  
		/// <returns>删除的数据行数</returns>
		public int DeleteRoleMember(RoleMemberEntity roleMember) {
			int Result = 0;
			using (RoleMemberDataAccess RoleMember = new RoleMemberDataAccess()) {
				Result = RoleMember.DeleteRoleMember(roleMember);
			}
			return Result;
		}

		#endregion
	}
}
