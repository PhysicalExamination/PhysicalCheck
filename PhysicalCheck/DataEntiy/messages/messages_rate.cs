/**  版本信息模板在安装目录下，可自行修改。
* messages_rate.cs
*
* 功 能： N/A
* 类 名： messages_rate
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-12-20 21:48:37   N/A    初版
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
	/// messages_rate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class messages_rate
	{
		public messages_rate()
		{}
		#region Model
		private int _id;
		private int? _rate;
		private DateTime? _upd_time;
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
		public int? rate
		{
			set{ _rate=value;}
			get{return _rate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? upd_time
		{
			set{ _upd_time=value;}
			get{return _upd_time;}
		}
		#endregion Model

	}
}

