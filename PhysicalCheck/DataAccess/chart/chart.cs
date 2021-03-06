﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.chart
{
    public partial class chart
    {
      
        #region " 体检单位费用统计"

        /// <summary>
        /// 获得数据列表
        /// </summary>
       public DataSet GetList_DepartmentCharge(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BillNo,ChargeDeptID,Payer,PackageID,CheckNum,Charge,ActualCharge,PaymentMethod,PaymentDate,ChargePerson,Enabled ");
            strSql.Append(" FROM charge ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

       /// <summary>
       /// 获取记录总数
       /// </summary>
       public DataSet GetSum_DepartmentCharge(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select sum(checknum) as checknum_sum,sum(ActualCharge) as ActualCharge_sum FROM view_chart_DepartmentCharge ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           
           return DbHelperMySQL.Query(strSql.ToString());

       }


        /// <summary>
        /// 获取记录总数
        /// </summary>
       public int GetRecordCount_DepartmentCharge(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM view_chart_DepartmentCharge ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
       public DataSet GetListByPage_DepartmentCharge(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM view_chart_DepartmentCharge ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by " + orderby);
            }

            strSql.AppendFormat(" limit {0} , {1}", startIndex, endIndex);

            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion

        #region " 体检人数同比分析"


       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList_PersonNumber(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("SELECT LEFT(RegisterNo,6) as dateM, SUM(1) as pointValue  from registration  ");
          
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append("  GROUP BY LEFT(RegisterNo,6) ");

           return DbHelperMySQL.Query(strSql.ToString());
       }

        #endregion

       #region "检查项目人数分布"



       /// <summary>
       /// 获得体检组合项目人数分布列表
       /// </summary>
       public DataSet GetList_itemgroupNumber(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append(" SELECT LEFT(RegisterNo,4) as nian,groupid,SUM(1) as pointValue from groupresult ");

           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append("  GROUP BY  LEFT(RegisterNo,4),groupid ");
           strSql.Append("  ORDER BY LEFT(RegisterNo,4) ");
           return DbHelperMySQL.Query(strSql.ToString());
       }




       #endregion

       #region "检查可是按年人数分布"


       

       /// <summary>
       /// 获得体检组合项目人数分布列表
       /// </summary>
       public DataSet GetList_itemDepartmentNumberPercent(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append(" SELECT LEFT(RegisterNo,4) as nian,DeptID,SUM(1) as pointValue from groupresult ");

           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append("  GROUP BY  LEFT(RegisterNo,4),DeptID ")          ;
           return DbHelperMySQL.Query(strSql.ToString());
       }

       #endregion

       #region " 工种按年体检人数同比分析-chart2"


       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList_TradeYear(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("Select  left (RegisterNo,4)as nian ,COUNT(1) as pointValue  from  registration AS A ");

           strSql.Append(" INNER JOIN checkperson as B on A.PersonID=B.PersonID ");

           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append("  GROUP BY LEFT(RegisterNo,4) ");

           return DbHelperMySQL.Query(strSql.ToString());
       }

       #endregion

       #region " 工种按年体检人数同比分析-chart3"

       /// <summary>
       /// 获得体检组合项目人数分布列表
       /// </summary>
       public DataSet GetList_TradePercent(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append(" Select  left (RegisterNo,4)as nian ,sum(1) as pointValue,B.tradecode from  registration AS A   ");

           strSql.Append(" INNER JOIN checkperson as B on A.PersonID=B.PersonID  ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           strSql.Append("   GROUP BY LEFT(RegisterNo,4),B.tradecode");
           return DbHelperMySQL.Query(strSql.ToString());
       }
        #endregion

    }
}
