/**  版本信息模板在安装目录下，可自行修改。
* advise.cs
*
* 功 能： N/A
* 类 名： advise
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015-1-24 16:33:36   N/A    初版
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
namespace Maticsoft.DAL.Examination
{
	/// <summary>
	/// 数据访问类:advise
	/// </summary>
	public partial class advise
	{
		public advise()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "advise"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from advise");
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
		public bool Add(Maticsoft.Model.Examination.advise model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into advise(");
			strSql.Append("RegisterNo,investigation,content,content2,content3,Doctor,add_time)");
			strSql.Append(" values (");
			strSql.Append("@RegisterNo,@investigation,@content,@content2,@content3,@Doctor,@add_time)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@RegisterNo", MySqlDbType.VarChar,20),
					new MySqlParameter("@investigation", MySqlDbType.Text),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@content2", MySqlDbType.Text),
					new MySqlParameter("@content3", MySqlDbType.Text),
					new MySqlParameter("@Doctor", MySqlDbType.VarChar,50),
					new MySqlParameter("@add_time", MySqlDbType.DateTime)};
			parameters[0].Value = model.RegisterNo;
			parameters[1].Value = model.investigation;
			parameters[2].Value = model.content;
			parameters[3].Value = model.content2;
			parameters[4].Value = model.content3;
			parameters[5].Value = model.Doctor;
			parameters[6].Value = model.add_time;

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
		public bool Update(Maticsoft.Model.Examination.advise model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update advise set ");
			strSql.Append("RegisterNo=@RegisterNo,");
			strSql.Append("investigation=@investigation,");
			strSql.Append("content=@content,");
			strSql.Append("content2=@content2,");
			strSql.Append("content3=@content3,");
			strSql.Append("Doctor=@Doctor,");
			strSql.Append("add_time=@add_time");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@RegisterNo", MySqlDbType.VarChar,20),
					new MySqlParameter("@investigation", MySqlDbType.Text),
					new MySqlParameter("@content", MySqlDbType.Text),
					new MySqlParameter("@content2", MySqlDbType.Text),
					new MySqlParameter("@content3", MySqlDbType.Text),
					new MySqlParameter("@Doctor", MySqlDbType.VarChar,50),
					new MySqlParameter("@add_time", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.RegisterNo;
			parameters[1].Value = model.investigation;
			parameters[2].Value = model.content;
			parameters[3].Value = model.content2;
			parameters[4].Value = model.content3;
			parameters[5].Value = model.Doctor;
			parameters[6].Value = model.add_time;
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
			strSql.Append("delete from advise ");
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
			strSql.Append("delete from advise ");
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
		public Maticsoft.Model.Examination.advise GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,RegisterNo,investigation,content,content2,content3,Doctor,add_time from advise ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Maticsoft.Model.Examination.advise model=new Maticsoft.Model.Examination.advise();
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
		public Maticsoft.Model.Examination.advise DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Examination.advise model=new Maticsoft.Model.Examination.advise();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["RegisterNo"]!=null)
				{
					model.RegisterNo=row["RegisterNo"].ToString();
				}
				if(row["investigation"]!=null)
				{
					model.investigation=row["investigation"].ToString();
				}
				if(row["content"]!=null)
				{
					model.content=row["content"].ToString();
				}
				if(row["content2"]!=null)
				{
					model.content2=row["content2"].ToString();
				}
				if(row["content3"]!=null)
				{
					model.content3=row["content3"].ToString();
				}
				if(row["Doctor"]!=null)
				{
					model.Doctor=row["Doctor"].ToString();
				}
				if(row["add_time"]!=null && row["add_time"].ToString()!="")
				{
					model.add_time=DateTime.Parse(row["add_time"].ToString());
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
			strSql.Append("select id,RegisterNo,investigation,content,content2,content3,Doctor,add_time ");
			strSql.Append(" FROM advise ");
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
            strSql.Append("select count(1) FROM v_advise ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM v_advise ");

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
			parameters[0].Value = "advise";
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

