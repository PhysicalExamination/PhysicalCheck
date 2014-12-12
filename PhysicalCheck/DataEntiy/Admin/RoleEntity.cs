using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataEntity.Admin {

	/// <summary>
	/// 实体类:RoleEntity
	/// 文件名:RoleEntity.cs
	/// 说  明:系统角色
	/// </summary>
	public class RoleEntity {

		#region 构造方法

		public RoleEntity() {
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
		/// 描述
		/// </summary>
		[Description("Description")]
		public virtual string Description {
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

		#endregion
	}
}
