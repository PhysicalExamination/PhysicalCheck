/**  版本信息模板在安装目录下，可自行修改。
* advise.cs
*
* 功 能： N/A
* 类 名： advise
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015-1-24 16:33:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model.Examination
{
	/// <summary>
	/// advise:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class advise
	{
		public advise()
		{}
		#region Model
		private int _id;
		private string _registerno;
		private string _investigation;
		private string _content;
		private string _content2;
		private string _content3;
		private string _doctor;
		private DateTime? _add_time;
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
		public string RegisterNo
		{
			set{ _registerno=value;}
			get{return _registerno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string investigation
		{
			set{ _investigation=value;}
			get{return _investigation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content2
		{
			set{ _content2=value;}
			get{return _content2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content3
		{
			set{ _content3=value;}
			get{return _content3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Doctor
		{
			set{ _doctor=value;}
			get{return _doctor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? add_time
		{
			set{ _add_time=value;}
			get{return _add_time;}
		}
		#endregion Model

	}
}

