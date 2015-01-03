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


        #endregion


    }
}
