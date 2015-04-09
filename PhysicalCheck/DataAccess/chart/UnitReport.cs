using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.UintReport
{
    //综合查询类
    public partial class UintReport
    {


        #region 体检疾病统计汇总
        /// <summary>
        /// 获得体检组合项目结论列表
        /// </summary>
        public DataSet GetUnitDiseasesumMain(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select DeptName, SUM(CASE when Sex='男'then 1 else 0 end )as 'nan' ,sum( CASE when Sex='女' then 1 else 0 end) as 'nv'  ");
            strSql.Append(" from registrationview  ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" GROUP BY DeptName;  ");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得体检组合项目结论列表
        /// </summary>
        public DataSet GetUnitDiseasesumSub(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select F.`Name`,SUM(1) from  groupsummary AS E   ");
            strSql.Append(" INNER JOIN suggestion AS F ON E.SummaryID=F.SNo ");
            strSql.Append(" INNER JOIN registrationview as G ON E.RegisterNo=G.RegisterNo  ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" GROUP BY F.`Name`;  ");

            return DbHelperMySQL.Query(strSql.ToString());
        }


        #endregion
    }
}
