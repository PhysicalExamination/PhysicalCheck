/**  版本信息模板在安装目录下，可自行修改。
* messages.cs
*
* 功 能： N/A
* 类 名： messages
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
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model.messages;
namespace Maticsoft.BLL.messages
{
	/// <summary>
	/// messages
	/// </summary>
	public partial class messagesSend
	{
		private readonly Maticsoft.DAL.messages.messagesSend dal=new Maticsoft.DAL.messages.messagesSend();
        public messagesSend()
		{}
        #region  "单位"
        /// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList_PhysicalDepartment(string strWhere)
		{
			return dal.GetList_PhysicalDepartment(strWhere);
		}		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public int GetRecordCount_PhysicalDepartment(string strWhere)
		{
			return dal.GetRecordCount_PhysicalDepartment(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        public DataSet GetListByPage_PhysicalDepartment(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage_PhysicalDepartment( strWhere,  orderby,  startIndex,  endIndex);
		}
		
		#endregion  BasicMethod

        #region  "体检登记"
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_Registration(string strWhere)
        {
            return dal.GetList_Registration(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount_Registration(string strWhere)
        {
            return dal.GetRecordCount_Registration(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage_Registration(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage_Registration(strWhere, orderby, startIndex, endIndex);
        }

        #endregion  BasicMethod


		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

