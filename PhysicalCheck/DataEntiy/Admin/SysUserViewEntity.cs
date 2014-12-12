using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataEntity.Admin {

	/// <summary>
	/// 实体类:SysUserEntity
	/// 文件名:SysUserEntity.cs
	/// 说  明:系统用户
	/// </summary>
	public class SysUserViewEntity {

		#region 构造方法

		public SysUserViewEntity() {
		}

		#endregion

		#region 属性

		/// <summary>
		/// 用户编号
		/// </summary>
		[Description("UserNo")]
		public virtual string UserNo {
			get;
			set;
		}

		/// <summary>
		/// 所在部门
		/// </summary>
		[Description("DeptNo")]
		public virtual string DeptNo {
			get;
			set;
		}

		/// <summary>
		/// 所在部门
		/// </summary>
		[Description("DeptName")]
		public virtual string DeptName {
			get;
			set;
		}

		/// <summary>
		/// 用户名
		/// </summary>
		[Description("UserName")]
		public virtual string UserName {
			get;
			set;
		}

		/// <summary>
		/// 职务
		/// </summary>
		[Description("Position")]
		public virtual string Position {
			get;
			set;
		}

		/// <summary>
		/// 联系电话
		/// </summary>
		[Description("LinkTel")]
		public virtual string LinkTel {
			get;
			set;
		}

		/// <summary>
		/// 手机
		/// </summary>
		[Description("Mobile")]
		public virtual string Mobile {
			get;
			set;
		}

		/// <summary>
		/// 用户类别 0.管理员1.普通用户
		/// </summary>
		[Description("UserCategory")]
		public virtual string UserCategory {
			get;
			set;
		}

		/// <summary>
		/// 登陆IP
		/// </summary>
		[Description("LoginIP")]
		public virtual string LoginIP {
			get;
			set;
		}

		/// <summary>
		/// 是否绑定IP
		/// </summary>
		[Description("IsBindLogin")]
		public virtual bool IsBindLogin {
			get;
			set;
		}

		/// <summary>
		/// 密码
		/// </summary>
		[Description("PassWord")]
		public virtual string PassWord {
			get;
			set;
		}

		/// <summary>
		/// 序号
		/// </summary>
		[Description("OrderNo")]
		public virtual int OrderNo {
			get;
			set;
		}

		/// <summary>
		/// 
		/// </summary>
		[Description("UserAccount")]
		public virtual string UserAccount {
			get;
			set;
		}


		#endregion
	}
}
