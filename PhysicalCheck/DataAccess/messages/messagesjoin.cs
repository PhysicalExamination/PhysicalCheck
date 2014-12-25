/**  版本信息模板在安装目录下，可自行修改。
* messagesjoin.cs
*
* 功 能： N/A
* 类 名： messagesjoin
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-12-24 18:25:29   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.messages
{
	/// <summary>
	/// 数据访问类:messagesjoin
	/// </summary>
	public partial class messagesjoin
	{
		public messagesjoin()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "messagesjoin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from messagesjoin");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.messages.messagesjoin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into messagesjoin(");
			strSql.Append("messagesid,jointable,tableCode)");
			strSql.Append(" values (");
			strSql.Append("@messagesid,@jointable,@tableCode)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@messagesid", MySqlDbType.Int32,11),
					new MySqlParameter("@jointable", MySqlDbType.VarChar,100),
					new MySqlParameter("@tableCode", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.messagesid;
			parameters[1].Value = model.jointable;
			parameters[2].Value = model.tableCode;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.messages.messagesjoin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update messagesjoin set ");
			strSql.Append("messagesid=@messagesid,");
			strSql.Append("jointable=@jointable,");
			strSql.Append("tableCode=@tableCode");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@messagesid", MySqlDbType.Int32,11),
					new MySqlParameter("@jointable", MySqlDbType.VarChar,100),
					new MySqlParameter("@tableCode", MySqlDbType.VarChar,100),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.messagesid;
			parameters[1].Value = model.jointable;
			parameters[2].Value = model.tableCode;
			parameters[3].Value = model.id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from messagesjoin ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from messagesjoin ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.messages.messagesjoin GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,messagesid,jointable,tableCode from messagesjoin ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.messages.messagesjoin model=new Maticsoft.Model.messages.messagesjoin();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.messages.messagesjoin DataRowToModel(DataRow row)
		{
			Maticsoft.Model.messages.messagesjoin model=new Maticsoft.Model.messages.messagesjoin();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["messagesid"]!=null && row["messagesid"].ToString()!="")
				{
					model.messagesid=int.Parse(row["messagesid"].ToString());
				}
				if(row["jointable"]!=null)
				{
					model.jointable=row["jointable"].ToString();
				}
				if(row["tableCode"]!=null)
				{
					model.tableCode=row["tableCode"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,messagesid,jointable,tableCode ");
			strSql.Append(" FROM messagesjoin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM messagesjoin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from messagesjoin T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "messagesjoin";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string tablename, string Code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from messagesjoin");
            strSql.Append(" where jointable=@tablename  And  tableCode=@tableCode");
            MySqlParameter[] parameters = {
					new MySqlParameter("@tablename", MySqlDbType.String),
                    new MySqlParameter("@tableCode", MySqlDbType.String)
			};
            parameters[0].Value = tablename;
            parameters[1].Value = Code;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

		#endregion  ExtensionMethod
	}
}

