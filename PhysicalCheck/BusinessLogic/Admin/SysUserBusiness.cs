using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Admin;
using DataEntity.Admin;

namespace BusinessLogic.Admin {

	/// <summary>
	/// 业务逻辑类:SysUserBusiness
	/// 文  件  名:SysUserBusiness.cs
	/// 说      明:系统用户业务逻辑对象
	/// </summary>
	public class SysUserBusiness : BaseBusinessLogic<SysUserDataAccess> {

		#region 构造器

		public SysUserBusiness() {

		}

		#endregion

		#region 公共方法

        public List<SysUserViewEntity> GetSysUsers() {
			return DataAccess.GetSysUsers();
		}

		/// <summary>
		/// 分页查询系统用户所有数据
		/// </summary>
		/// <param name="pageIndex">当前第几页</param>
		/// <param name="pageSize">每页显示几条</param>        
		/// <param name="RecordCount">总记录数</param>
		/// <returns></returns>
		public List<SysUserViewEntity> GetSysUsers(int pageIndex, int pageSize, out int RecordCount) {
			return DataAccess.GetSysUsers(pageIndex, pageSize, out RecordCount);
		}

		public SysUserEntity GetSysUser(string UserNo) {
			return DataAccess.GetSysUser(UserNo);
		}

		public int SaveSysUser(SysUserEntity SysUser) {
			return DataAccess.SaveSysUser(SysUser);
		}

		public int DeleteSysUser(SysUserEntity SysUser) {
			return DataAccess.DeleteSysUser(SysUser);
		}

		/// <summary>
		/// 根据提供的用户账号返回用户信息
		/// </summary>
		/// <param name="UserAccount">用户账号</param>
		/// <returns></returns>
		public SysUserEntity GetUserByAccount(String UserAccount) {
			return DataAccess.GetUserByAccount(UserAccount);
		}

		/// <summary>
		/// 检查用户是否存在不存在返回false否则返回true
		/// </summary>
		/// <param name="UserAccount"></param>
		/// <returns></returns>
		public bool CheckUserExists(string UserAccount) {
			return DataAccess.CheckUserExists(UserAccount);
		}

		/// <summary>
		/// 根据用户登录账号和密码验证用户合法性，验证通过返回true否则返回false
		/// </summary>
		/// <param name="UserAccount">用户登录账号</param>
		/// <param name="Password">密码</param>
		/// <returns></returns>
		public bool Authentication(string UserAccount, string Password) {
			return DataAccess.Authentication(UserAccount, Password);
		}

		/// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="UserAccount">用户账号</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
		public bool ChangedPassword(string UserAccount, string Password) {
			return DataAccess.ChangedPassword(UserAccount, Password);
		}

		/// <summary>
		/// 返回授权用户访问的模块
		/// </summary>
		/// <param name="UserNo"></param>
		/// <param name="ParentModuleNo"></param>
		/// <returns></returns>
		public List<ModuleEntity> GetUserModules(String UserAccount, String ParentModuleNo) {
			return DataAccess.GetUserModules(UserAccount, ParentModuleNo);
		}

		#endregion
	}
}
