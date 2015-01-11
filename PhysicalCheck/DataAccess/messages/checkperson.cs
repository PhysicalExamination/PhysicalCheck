/**  版本信息模板在安装目录下，可自行修改。
* checkperson.cs
*
* 功 能： N/A
* 类 名： checkperson
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-12-24 16:46:52   N/A    初版
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
	/// 数据访问类:checkperson
	/// </summary>
	public partial class checkperson
	{
		public checkperson()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("PersonID", "checkperson"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PersonID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from checkperson");
			strSql.Append(" where PersonID=@PersonID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PersonID", MySqlDbType.Int32,11)			};
			parameters[0].Value = PersonID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.messages.checkperson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into checkperson(");
			strSql.Append("PersonID,Name,Sex,IDNumber,Birthday,Age,DeptID,Marriage,Job,Education,Nation,LinkTel,Address,Mobile,EMail,Enabled)");
			strSql.Append(" values (");
			strSql.Append("@PersonID,@Name,@Sex,@IDNumber,@Birthday,@Age,@DeptID,@Marriage,@Job,@Education,@Nation,@LinkTel,@Address,@Mobile,@EMail,@Enabled)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PersonID", MySqlDbType.Int32,11),
					new MySqlParameter("@Name", MySqlDbType.VarChar,40),
					new MySqlParameter("@Sex", MySqlDbType.VarChar,6),
					new MySqlParameter("@IDNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@Birthday", MySqlDbType.DateTime),
					new MySqlParameter("@Age", MySqlDbType.Int32,4),
					new MySqlParameter("@DeptID", MySqlDbType.Int32,11),
					new MySqlParameter("@Marriage", MySqlDbType.VarChar,10),
					new MySqlParameter("@Job", MySqlDbType.VarChar,30),
					new MySqlParameter("@Education", MySqlDbType.VarChar,10),
					new MySqlParameter("@Nation", MySqlDbType.VarChar,30),
					new MySqlParameter("@LinkTel", MySqlDbType.VarChar,20),
					new MySqlParameter("@Address", MySqlDbType.VarChar,300),
					new MySqlParameter("@Mobile", MySqlDbType.VarChar,20),
					new MySqlParameter("@EMail", MySqlDbType.VarChar,100),
					new MySqlParameter("@Enabled", MySqlDbType.Int16,1)};
			parameters[0].Value = model.PersonID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.IDNumber;
			parameters[4].Value = model.Birthday;
			parameters[5].Value = model.Age;
			parameters[6].Value = model.DeptID;
			parameters[7].Value = model.Marriage;
			parameters[8].Value = model.Job;
			parameters[9].Value = model.Education;
			parameters[10].Value = model.Nation;
			parameters[11].Value = model.LinkTel;
			parameters[12].Value = model.Address;
			parameters[13].Value = model.Mobile;
			parameters[14].Value = model.EMail;
			parameters[15].Value = model.Enabled;

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
		public bool Update(Maticsoft.Model.messages.checkperson model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update checkperson set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("IDNumber=@IDNumber,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("Age=@Age,");
			strSql.Append("DeptID=@DeptID,");
			strSql.Append("Marriage=@Marriage,");
			strSql.Append("Job=@Job,");
			strSql.Append("Education=@Education,");
			strSql.Append("Nation=@Nation,");
			strSql.Append("LinkTel=@LinkTel,");
			strSql.Append("Address=@Address,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("EMail=@EMail,");
			strSql.Append("Enabled=@Enabled");
			strSql.Append(" where PersonID=@PersonID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Name", MySqlDbType.VarChar,40),
					new MySqlParameter("@Sex", MySqlDbType.VarChar,6),
					new MySqlParameter("@IDNumber", MySqlDbType.VarChar,20),
					new MySqlParameter("@Birthday", MySqlDbType.Date),
					new MySqlParameter("@Age", MySqlDbType.Int32,4),
					new MySqlParameter("@DeptID", MySqlDbType.Int32,11),
					new MySqlParameter("@Marriage", MySqlDbType.VarChar,10),
					new MySqlParameter("@Job", MySqlDbType.VarChar,30),
					new MySqlParameter("@Education", MySqlDbType.VarChar,10),
					new MySqlParameter("@Nation", MySqlDbType.VarChar,30),
					new MySqlParameter("@LinkTel", MySqlDbType.VarChar,20),
					new MySqlParameter("@Address", MySqlDbType.VarChar,300),
					new MySqlParameter("@Mobile", MySqlDbType.VarChar,20),
					new MySqlParameter("@EMail", MySqlDbType.VarChar,100),
					new MySqlParameter("@Enabled", MySqlDbType.Int16,1),
					new MySqlParameter("@PersonID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Sex;
			parameters[2].Value = model.IDNumber;
			parameters[3].Value = model.Birthday;
			parameters[4].Value = model.Age;
			parameters[5].Value = model.DeptID;
			parameters[6].Value = model.Marriage;
			parameters[7].Value = model.Job;
			parameters[8].Value = model.Education;
			parameters[9].Value = model.Nation;
			parameters[10].Value = model.LinkTel;
			parameters[11].Value = model.Address;
			parameters[12].Value = model.Mobile;
			parameters[13].Value = model.EMail;
			parameters[14].Value = model.Enabled;
			parameters[15].Value = model.PersonID;

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
		public bool Delete(int PersonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from checkperson ");
			strSql.Append(" where PersonID=@PersonID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PersonID", MySqlDbType.Int32,11)			};
			parameters[0].Value = PersonID;

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
		public bool DeleteList(string PersonIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from checkperson ");
			strSql.Append(" where PersonID in ("+PersonIDlist + ")  ");
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
		public Maticsoft.Model.messages.checkperson GetModel(int PersonID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PersonID,Name,Sex,IDNumber,Birthday,Age,DeptID,Marriage,Job,Education,Nation,LinkTel,Address,Mobile,EMail,Enabled from checkperson ");
			strSql.Append(" where PersonID=@PersonID ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@PersonID", MySqlDbType.Int32,11)			};
			parameters[0].Value = PersonID;

			Maticsoft.Model.messages.checkperson model=new Maticsoft.Model.messages.checkperson();
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
		public Maticsoft.Model.messages.checkperson DataRowToModel(DataRow row)
		{
			Maticsoft.Model.messages.checkperson model=new Maticsoft.Model.messages.checkperson();
			if (row != null)
			{
				if(row["PersonID"]!=null && row["PersonID"].ToString()!="")
				{
					model.PersonID=int.Parse(row["PersonID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["IDNumber"]!=null)
				{
					model.IDNumber=row["IDNumber"].ToString();
				}
				if(row["Birthday"]!=null && row["Birthday"].ToString()!="")
				{
					model.Birthday=DateTime.Parse(row["Birthday"].ToString());
				}
				if(row["Age"]!=null && row["Age"].ToString()!="")
				{
					model.Age=int.Parse(row["Age"].ToString());
				}
				if(row["DeptID"]!=null && row["DeptID"].ToString()!="")
				{
					model.DeptID=int.Parse(row["DeptID"].ToString());
				}
				if(row["Marriage"]!=null)
				{
					model.Marriage=row["Marriage"].ToString();
				}
				if(row["Job"]!=null)
				{
					model.Job=row["Job"].ToString();
				}
				if(row["Education"]!=null)
				{
					model.Education=row["Education"].ToString();
				}
				if(row["Nation"]!=null)
				{
					model.Nation=row["Nation"].ToString();
				}
				if(row["LinkTel"]!=null)
				{
					model.LinkTel=row["LinkTel"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["EMail"]!=null)
				{
					model.EMail=row["EMail"].ToString();
				}
				if(row["Enabled"]!=null && row["Enabled"].ToString()!="")
				{
					//model.Enabled=int.Parse(row["Enabled"].ToString());

                    model.Enabled = row["Enabled"].ToString() == "true" ? 1 : 0; 
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
			strSql.Append("select PersonID,Name,Sex,IDNumber,Birthday,Age,DeptID,Marriage,Job,Education,Nation,LinkTel,Address,Mobile,EMail,Enabled ");
			strSql.Append(" FROM checkperson ");
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
			strSql.Append("select count(1) FROM checkperson ");
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
            strSql.Append("SELECT * FROM checkperson ");

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
	
		
		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

