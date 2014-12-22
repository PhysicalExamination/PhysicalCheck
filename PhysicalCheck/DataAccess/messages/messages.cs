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
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL.messages
{
	/// <summary>
	/// 数据访问类:messages
	/// </summary>
	public partial class messages
	{
		public messages()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "messages"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from messages");
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
		public bool Add(Maticsoft.Model.messages.messages model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into messages(");
			strSql.Append("type,rcvMan,unit,rcvTel,content,sendTime,status)");
			strSql.Append(" values (");
			strSql.Append("@type,@rcvMan,@unit,@rcvTel,@content,@sendTime,@status)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@type", MySqlDbType.VarChar,20),
					new MySqlParameter("@rcvMan", MySqlDbType.VarChar,50),
					new MySqlParameter("@unit", MySqlDbType.VarChar,100),
					new MySqlParameter("@rcvTel", MySqlDbType.VarChar,20),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@sendTime", MySqlDbType.DateTime),
					new MySqlParameter("@status", MySqlDbType.VarChar,101)};
			parameters[0].Value = model.type;
			parameters[1].Value = model.rcvMan;
			parameters[2].Value = model.unit;
			parameters[3].Value = model.rcvTel;
			parameters[4].Value = model.content;
			parameters[5].Value = model.sendTime;
			parameters[6].Value = model.status;

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
		public bool Update(Maticsoft.Model.messages.messages model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update messages set ");
			strSql.Append("type=@type,");
			strSql.Append("rcvMan=@rcvMan,");
			strSql.Append("unit=@unit,");
			strSql.Append("rcvTel=@rcvTel,");
			strSql.Append("content=@content,");
			strSql.Append("sendTime=@sendTime,");
			strSql.Append("status=@status");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@type", MySqlDbType.VarChar,20),
					new MySqlParameter("@rcvMan", MySqlDbType.VarChar,50),
					new MySqlParameter("@unit", MySqlDbType.VarChar,100),
					new MySqlParameter("@rcvTel", MySqlDbType.VarChar,20),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@sendTime", MySqlDbType.DateTime),
					new MySqlParameter("@status", MySqlDbType.VarChar,101),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.type;
			parameters[1].Value = model.rcvMan;
			parameters[2].Value = model.unit;
			parameters[3].Value = model.rcvTel;
			parameters[4].Value = model.content;
			parameters[5].Value = model.sendTime;
			parameters[6].Value = model.status;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from messages ");
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
			strSql.Append("delete from messages ");
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
		public Maticsoft.Model.messages.messages GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,type,rcvMan,unit,rcvTel,content,sendTime,status from messages ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.messages.messages model=new Maticsoft.Model.messages.messages();
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
		public Maticsoft.Model.messages.messages DataRowToModel(DataRow row)
		{
			Maticsoft.Model.messages.messages model=new Maticsoft.Model.messages.messages();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["rcvMan"]!=null)
				{
					model.rcvMan=row["rcvMan"].ToString();
				}
				if(row["unit"]!=null)
				{
					model.unit=row["unit"].ToString();
				}
				if(row["rcvTel"]!=null)
				{
					model.rcvTel=row["rcvTel"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["sendTime"]!=null && row["sendTime"].ToString()!="")
				{
					model.sendTime=DateTime.Parse(row["sendTime"].ToString());
				}
				if(row["status"]!=null)
				{
					model.status=row["status"].ToString();
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
			strSql.Append("select id,type,rcvMan,unit,rcvTel,content,sendTime,status ");
			strSql.Append(" FROM messages ");
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
			strSql.Append("select count(1) FROM messages ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("SELECT * FROM messages ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by " + orderby );
			}
			
            strSql.AppendFormat(" limit {0} , {1}", startIndex, endIndex);

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
			parameters[0].Value = "messages";
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

		#endregion  ExtensionMethod
	}
}

