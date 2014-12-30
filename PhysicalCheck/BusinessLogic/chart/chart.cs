﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Maticsoft.Common;
namespace Maticsoft.BLL.chart
{
    public partial class chart
   {
       private readonly Maticsoft.DAL.chart.chart dal = new Maticsoft.DAL.chart.chart();
       #region " 体检单位费用统计"

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList_DepartmentCharge(string strWhere)
       {
           return dal.GetList_DepartmentCharge(strWhere);
       }

       /// <summary>
        /// 分页获取数据列表
        /// </summary>
       public int GetRecordCount_DepartmentCharge(string strWhere)
        {
            return dal.GetRecordCount_DepartmentCharge(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
       public DataSet GetListByPage_DepartmentCharge(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage_DepartmentCharge(strWhere, orderby, startIndex, endIndex);
        }

       public DataSet GetSum_DepartmentCharge(string strWhere)
       {
           return dal.GetSum_DepartmentCharge(strWhere);
       }
    #endregion

        
        #region " 体检人数同比分析"


       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList_PersonNumber(string strWhere)
       {

           return dal.GetList_PersonNumber(strWhere);
       }
        #endregion
   }
}
