using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.Search
{
    //综合查询类
    public partial class Search
    {


        #region 组合查询
        /// <summary>
        /// 获得体检组合项目结论列表
        /// </summary>
        public DataSet GetList_GroupResult(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.*,B.DeptName,C.PackageName,D.GroupName from groupresult  as A  ");
            strSql.Append(" INNER JOIN department as B on A.DeptID=B.DeptID  ");
            strSql.Append(" INNER JOIN package as C on C.PackageID=A.PackageID  ");
            strSql.Append(" INNER JOIN itemgroup as D on D.GroupID=A.GroupID   ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得体检项目结论列表
        /// </summary>
        public DataSet GetList_itemresult(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  *  from itemresultview   ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得组合查询列表
        /// </summary>
        public DataSet GetList_Composed(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM View_Search_Composed ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取组合查询记录总数
        /// </summary>
        public int GetRecordCount_Composed(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM View_Search_Composed ");
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
        /// 分页获取组合查询数据列表
        /// </summary>
        public DataSet GetListByPage_Composed(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM View_Search_Composed ");

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

        #region 工作量
        /// <summary>
        /// 获得体检项目合计工作量
        /// </summary>
        public DataSet GetList_workload_checkItem(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT D.DeptName ,  ItemName, SUM(1) as sumNum from groupresult as A  ");
            strSql.Append(" INNER JOIN itemresult as B on A.RegisterNo=B.RegisterNo AND A.GroupID=B.GroupID  ");
            strSql.Append(" INNER JOIN checkeditem as C on  C.ItemID=B.ItemID  ");
            strSql.Append(" INNER JOIN department as D on  D.DeptID=A.DeptID	  ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" GROUP BY D.DeptName, C.ItemName	  ");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得体检组合项目合计工作量
        /// </summary>
        public DataSet GetList_workload_itemgroup(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT D.DeptName ,B.GroupName,B.price,  SUM(1) as sumNum, sum( B.Price )as sumPrice  from groupresult as A  ");
            strSql.Append(" INNER JOIN itemgroup as B on B.GroupID=A.GroupID ");
            strSql.Append(" INNER JOIN department as D on  D.DeptID=A.DeptID  ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" GROUP BY D.DeptName, B.GroupName,B.price  ");
            return DbHelperMySQL.Query(strSql.ToString());
        }



        /// <summary>
        /// 获得体检项目合计工作量
        /// </summary>
        public DataSet GetList_workload_package(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select B.PackageName,SUM(1) as sumNum, SUM(B.Price) as sumPrice  from groupresult as A ");
            strSql.Append(" INNER JOIN package as B ON A.PackageID=B.PackageID  ");
            
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            strSql.Append(" GROUP BY B.PackageName  ");

            return DbHelperMySQL.Query(strSql.ToString());
        }

        #endregion

    }
}
