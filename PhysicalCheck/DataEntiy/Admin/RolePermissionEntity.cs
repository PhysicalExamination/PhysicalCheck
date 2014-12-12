using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataEntity.Admin {


	/// <summary>
	/// 实体类:RolePermissionEntity
	/// 文件名:RolePermissionEntity.cs
	/// 说  明:角色权限
	/// </summary>
	public class RolePermissionEntity {

		#region 构造方法

		public RolePermissionEntity() {
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
		/// 模块编号
		/// </summary>
		[Description("ModuleNo")]
		public virtual string ModuleNo {
			get;
			set;
		}

		/// <summary>
		/// 模块名称
		/// </summary>
		[Description("ModuleName")]
		public virtual string ModuleName {
			get;
			set;
		}

		#endregion

		#region 重写方法

		public override bool Equals(object obj) {
			bool Result = false;
			if (obj is RolePermissionEntity) {
				RolePermissionEntity RolePermission = obj as RolePermissionEntity;
				if (RoleNo == RolePermission.RoleNo
					 && ModuleNo == RolePermission.ModuleNo) {
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
