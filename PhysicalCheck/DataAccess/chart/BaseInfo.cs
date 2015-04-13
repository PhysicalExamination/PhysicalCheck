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
        /// 获得字典表列表
        /// </summary>
        /// select * from  commoncode where Category=3 
        public DataSet GetList_CommonCode(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  commoncode  ");

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

        /// <summary>
        /// 获得体检单位列表
        /// </summary>
        public DataSet GetList_physicaldepartment(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from physicaldepartment   ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            //WHERE DeptID<>1

            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得表信息列表
        /// </summary>
        public DataSet GetList_Table(string tableName, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from "+tableName  );

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }         
            return DbHelperMySQL.Query(strSql.ToString());
        }



    }
}
