using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.BaseInfo
{
    //综合查询类
    public partial class BaseInfo
    {


        /// <summary>
        /// 获得科室列表
        /// </summary>
        public DataSet GetList_department(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from department  ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得体检组合项目列表
        /// </summary>
        public DataSet GetList_itemgroup(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from itemgroup  ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return DbHelperMySQL.Query(strSql.ToString());
        }

    }
}
