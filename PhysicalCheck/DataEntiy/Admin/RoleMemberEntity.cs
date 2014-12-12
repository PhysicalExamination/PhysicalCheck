using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataEntity.Admin {

	/// 实体类:RoleMemberEntity
	/// 文件名:RoleMemberEntity.cs
	/// 说  明:角色成员
	/// </summary>
	public class RoleMemberEntity {
		#region 构造方法

		public RoleMemberEntity() {
		}

		#endregion

		#region 属性

		/// <summary>
		/// 角色编号
		/// </summary>
		[Description("RoleNo")]
		public virtual string RoleNo {
			get;
			set;
		}

		/// <summary>
		/// 角色名称
		/// </summary>
		[Description("RoleName")]
		public virtual string RoleName {
			get;
			set;
		}

		/// <summary>
		/// 用户编号
		/// </summary>
		[Description("UserNo")]
		public virtual string UserNo {
			get;
			set;
		}

		/// <summary>
		/// 系统用户名
		/// </summary>
		[Description("UserName")]
		public virtual string UserName {
			get;
			set;
		}

		#endregion

		#region 重写方法

		public override bool Equals(object obj) {
			bool Result = false;
			if (obj is RoleMemberEntity) {
				RoleMemberEntity RoleMember = obj as RoleMemberEntity;
				if (RoleNo == RoleMember.RoleNo
					 && UserNo == RoleMember.UserNo) {
					Result = true;
				}				
			}
			return Result;   
		}

		public override int GetHashCode() {
			return base.GetHashCode();			
		}

		#endregion
	}
}
