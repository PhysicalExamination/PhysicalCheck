using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.Admin;
using NHibernate;
using NHibernate.Linq;

namespace DataAccess.Admin {

	/// <summary>
	/// 数据访问类:SysUserDataAccess
	/// 文  件  名:SysUserDataAccess.cs
	/// 说      明:系统用户数据访问对象
	/// </summary>
	public class SysUserDataAccess : BaseDataAccess<SysUserEntity> {

		#region 构造器

		public SysUserDataAccess() {

		}

		#endregion

		#region 公共方法

		/// <summary>
		///获取系统用户所有数据
		/// </summary>
		public List<SysUserEntity> GetSysUsers() {
			List<SysUserEntity> Result = (from c in Session.Query<SysUserEntity>() select c).ToList();
			CloseSession();
			return Result;
		}

		/// <summary>
		/// 分页查询系统用户所有数据
		/// </summary>
		/// <param name="pageIndex">当前第几页</param>
		/// <param name="pageSize">每页显示几条</param>        
		/// <param name="RecordCount">总记录数</param>
		/// <returns></returns>
		public List<SysUserViewEntity> GetSysUsers(int pageIndex, int pageSize, out int RecordCount) {
			String hql = "select count(*) from SysUserViewEntity";
			IQuery query = Session.CreateQuery(hql);
			object obj = query.UniqueResult();
			int.TryParse(obj.ToString(), out RecordCount);

			List<SysUserViewEntity> Result = Session.CreateQuery(" from SysUserViewEntity")
												.SetFirstResult((pageIndex - 1) * pageSize)
												.SetMaxResults(pageSize)
												.List<SysUserViewEntity>().ToList<SysUserViewEntity>();
			CloseSession();
			return Result;

		}

		/// <summary>
		/// 获取系统用户数据
		/// </summary>
		/// <param name="UserNo">用户编号</param> 
		/// <returns>系统用户实体</returns>
		public SysUserEntity GetSysUser(string UserNo) {
			SysUserEntity Result = Session.Get<SysUserEntity>(UserNo);
			CloseSession();
			return Result;
		}

		/// <summary>
		/// 根据提供的用户账号返回用户信息
		/// </summary>
		/// <param name="UserAccount">用户账号</param>
		/// <returns></returns>
		public SysUserEntity GetUserByAccount(String UserAccount) {
			List<SysUserEntity> Result = (from c in Session.Query<SysUserEntity>()
										  where c.UserAccount == UserAccount
										  select c).ToList();
			CloseSession();
			if (Result.Count > 0) return Result.First();
			return null;
		}

		/// <summary>
		/// 返回授权用户访问的模块
		/// </summary>
		/// <param name="UserNo"></param>
		/// <param name="ParentModuleNo"></param>
		/// <returns></returns>
		public List<ModuleEntity> GetUserModules(String UserAccount, String ParentModuleNo) {
			List<ModuleEntity> Result = (from a in Session.Query<RoleMemberEntity>()
										 join b in Session.Query<SysUserEntity>() on a.UserNo equals b.UserNo
										 join c in Session.Query<RolePermissionEntity>() on a.RoleNo equals c.RoleNo
										 join d in Session.Query<ModuleEntity>() on c.ModuleNo equals d.ModuleNo
										 where b.UserAccount == UserAccount && d.ParentModuleNo == ParentModuleNo
										 orderby d.OrderNo
										 select d).ToList<ModuleEntity>();
			CloseSession();
			return Result;
		}

		/// <summary>
		/// 检查用户是否存在不存在返回false否则返回true
		/// </summary>
		/// <param name="UserAccount"></param>
		/// <returns></returns>
		public bool CheckUserExists(string UserAccount) {
			List<SysUserEntity> Result = (from p in Session.Query<SysUserEntity>()
										  where p.UserAccount == UserAccount
										  select p).ToList<SysUserEntity>();
			CloseSession();
			return Result.Count > 0;
		}

		/// <summary>
		/// 根据用户登录账号和密码验证用户合法性，验证通过返回true否则返回false
		/// </summary>
		/// <param name="UserAccount">用户登录账号</param>
		/// <param name="Password">密码</param>
		/// <returns></returns>
		public bool Authentication(string UserAccount, string Password) {
			List<SysUserEntity> Result = (from p in Session.Query<SysUserEntity>()
										  where p.UserAccount == UserAccount && p.PassWord == Password
										  select p).ToList<SysUserEntity>();
			CloseSession();
			return Result.Count > 0;
		}

		/// <summary>
		/// 修改用户密码
		/// </summary>
		/// <param name="UserAccount">用户账号</param>
		/// <param name="Password">密码</param>
		/// <returns></returns>
		public bool ChangedPassword(string UserAccount, string Password) {
			List<SysUserEntity> UserList = (from p in Session.Query<SysUserEntity>()
											where p.UserAccount == UserAccount
											select p).ToList<SysUserEntity>();
			if (UserList.Count < 0) return false;
			SysUserEntity User = UserList.First();
			User.UserAccount = UserAccount;
			User.PassWord = Password;
			Session.SaveOrUpdate(User);
			Session.Flush();
			CloseSession();
			return true;
		}

		/// <summary>
		/// 保存系统用户数据
		/// </summary>
		/// <param name="SysUser">系统用户实体</param>        
		/// <returns>成功保存的行数</returns>
		public int SaveSysUser(SysUserEntity SysUser) {
			int Result = 0;
			if (String.IsNullOrEmpty(SysUser.UserNo)) SysUser.UserNo = GetLineID("SysUser")+"";
			Session.SaveOrUpdate(SysUser);
			Session.Flush();
			return Result;
		}

		/// <summary>
		/// 删除系统用户数据
		/// </summary>
		/// <param name="SysUser">系统用户实体</param>        
		/// <returns>删除的数据行数</returns>
		public int DeleteSysUser(SysUserEntity SysUser) {
			int Result = 0;
			Session.Delete(SysUser);
			Session.Flush();
			return Result;
		}



		#endregion

		#region IDisposable 成员

		public override void Dispose() {

		}

		#endregion
	}
}
