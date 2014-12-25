/**  版本信息模板在安装目录下，可自行修改。
* messagesjoin.cs
*
* 功 能： N/A
* 类 名： messagesjoin
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-12-24 18:25:29   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model.messages
{
	/// <summary>
	/// messagesjoin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class messagesjoin
	{
		public messagesjoin()
		{}
		#region Model
		private int _id;
		private int? _messagesid;
		private string _jointable;
		private string _tablecode;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? messagesid
		{
			set{ _messagesid=value;}
			get{return _messagesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string jointable
		{
			set{ _jointable=value;}
			get{return _jointable;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tableCode
		{
			set{ _tablecode=value;}
			get{return _tablecode;}
		}
		#endregion Model

	}
}

