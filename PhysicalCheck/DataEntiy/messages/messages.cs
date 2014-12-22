/**  版本信息模板在安装目录下，可自行修改。
* messages.cs
*
* 功 能： N/A
* 类 名： messages
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-12-20 21:48:36   N/A    初版
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
	/// messages:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class messages
	{
		public messages()
		{}
		#region Model
		private int _id;
		private string _type;
		private string _rcvman;
		private string _unit;
		private string _rcvtel;
		private string _content;
		private DateTime? _sendtime;
		private string _status;
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
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rcvMan
		{
			set{ _rcvman=value;}
			get{return _rcvman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string rcvTel
		{
			set{ _rcvtel=value;}
			get{return _rcvtel;}
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
		public DateTime? sendTime
		{
			set{ _sendtime=value;}
			get{return _sendtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

