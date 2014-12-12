using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace DataEntity.Admin {

	/// <summary>
	/// 实体类:ModuleEntity
	/// 文件名:ModuleEntity.cs
	/// 说  明:系统模块
	/// </summary>
	[DataContract]
	public class ModuleEntity {

		#region 构造方法

		public ModuleEntity() {
		}

		#endregion

		#region 属性

		/// <summary>
		/// 模块编号
		/// </summary>
		[Description("ModuleNo")]
		[DataMember(Name = "id")]
		public virtual string ModuleNo {
			get;
			set;
		}


		/// <summary>
		/// 模块名称
		/// </summary>
		[Description("ModuleName")]
		[DataMember(Name = "text")]
		public virtual string ModuleName {
			get;
			set;
		}

		/// <summary>
		/// 父模块编号
		/// </summary>
		[Description("ParentModuleNo")]
		public virtual string ParentModuleNo {
			get;
			set;
		}

		/// <summary>
		/// 模块图标
		/// </summary>
		[Description("ModuleIcon")]
		public virtual string ModuleIcon {
			get;
			set;
		}

		/// <summary>
		/// 模块对应的URL地址
		/// </summary>
		[Description("URL")]
		public virtual string URL {
			get;
			set;
		}

		/// <summary>
		/// 模块功能描述
		/// </summary>
		[Description("ModuleDescription")]
		public virtual string Description {
			get;
			set;
		}

		/// <summary>
		/// 显示排序
		/// </summary>
		[Description("OrderNo")]
		public virtual int OrderNo {
			get;
			set;
		}

		[DataMember(Name = "children")]
		public virtual List<ModuleEntity> SubModules {
			get;
			set;
		}

		[DataMember(Name="attributes")]
		public virtual ModuleAttribute Attributes {
			get;
			set;
		}

		[DataMember(Name="checked")]
		public virtual bool Checked {
			get;
			set;
		}

		#endregion
	}

	public class ModuleAttribute {

		public String ModuleIcon {
			get;
			set;
		}

		public String URL {
			get;
			set;
		}

		public String ParentModuleNo {
			get;
			set;
		}

		public String Description {
			get;
			set;
		}

		public int OrderNo {
			get;
			set;
		}
	}
}
