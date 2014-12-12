using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Admin;

namespace DataAccess.Admin {

	/// <summary>
	/// 数据访问类:RoleMemberDataAccess
	/// 文  件  名:RoleMemberDataAccess.cs
	/// 说      明:角色成员数据访问对象
	/// </summary>
	public class RoleMemberDataAccess : BaseDataAccess<RoleMemberEntity> {

		#region 构造器

		public RoleMemberDataAccess() {

		}

		#endregion

		#region 公共方法

		/// <summary>
		///获取属于角色的所有用户数据
		///<param name="RoleNo">角色编号</param>
		/// </summary>
		public List<RoleMemberEntity> GetRoleMembers(string RoleNo) {
			List<RoleMemberEntity> Result = (from a in Session.Query<RoleMemberEntity>()
											 join b in Session.Query<RoleEntity>() on a.RoleNo equals b.RoleNo
											 join c in Session.Query<SysUserEntity>() on a.UserNo equals c.UserNo
											 where a.RoleNo == RoleNo
											 select new RoleMemberEntity {
												 UserNo = a.UserNo,
												 RoleNo = a.RoleNo,
												 RoleName = b.RoleName,
												 UserName = c.UserName
											 }).ToList<RoleMemberEntity>();
			CloseSession();
			return Result;
		}

		/// <summary>
		/// 获取角色成员数据
		/// </summary>
		/// <param name="RoleNo">角色编号</param> 
		/// <param name="UserNo">用户编号</param> 
		/// <returns>角色成员实体</returns>
		public RoleMemberEntity GetRoleMember(string RoleNo, string UserNo) {
			List<RoleMemberEntity> RoleMembers = (from p in Session.Query<RoleMemberEntity>()
												 where p.RoleNo == RoleNo && p.UserNo == UserNo
												 select p).ToList<RoleMemberEntity>();
			CloseSession();
			if (RoleMembers.Count > 0) return RoleMembers.First();
			return null;
		}

		/// <summary>
		/// 保存角色成员数据
		/// </summary>
		/// <param name="RoleMember">角色成员实体</param>        
		/// <returns>成功保存的行数</returns>
		public int SaveRoleMember(RoleMemberEntity RoleMember) {
			Session.SaveOrUpdate(RoleMember);
			Session.Flush();
			CloseSession();
			return 0;
		}

		/// <summary>
		/// 删除角色成员数据
		/// </summary>
		/// <param name="RoleMember">角色成员实体</param>        
		/// <returns>删除的数据行数</returns>
		public int DeleteRoleMember(RoleMemberEntity RoleMember) {
			Session.Delete(RoleMember);
			Session.Flush();
			CloseSession();
			return 0;
		}

		#endregion
	}
}
