using System;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using NHibernate;


namespace DataAccess {

	public abstract class BaseDataAccess<T> : System.IDisposable where T : new() {

		#region 私有成员

		//private Database m_DataBase;

		#endregion

		#region 属性

		//protected Database DataBase {
		//    get {
		//        if (m_DataBase == null) {
		//            m_DataBase = DatabaseFactory.CreateDatabase();
		//        }
		//        return m_DataBase;
		//    }
		//}

		protected ISession Session {
			get {
				return NHibernateHelper.GetCurrentSession();
			}
		}

		#endregion

		#region 受保护方法


		protected void CloseSession() {
			NHibernateHelper.CloseSession();
		}		

		protected Int32 GetLineID(string tableName) {
			string Result = String.Empty;
			using (IDbCommand Command = Session.Connection.CreateCommand()) {
				Command.CommandText = "call ProcGetLineID(?)";
				//Command.CommandType = CommandType.StoredProcedure;
				IDbDataParameter parameter = Command.CreateParameter();
				parameter.ParameterName = "aTable_nam";
				parameter.DbType = DbType.String;
				parameter.Value = tableName;
                parameter.Direction = ParameterDirection.Input;
				Command.Parameters.Add(parameter);
				IDataReader Reader = Command.ExecuteReader();				
				try {
					if (Reader.Read()) {
						Result = Reader.GetString(0);
					}
				}
				finally {
					Reader.Dispose();
				}
			}			
			return Convert.ToInt32(Result);			
		}

		protected string GetBillNo(string tableName) {
			string Result = String.Empty;
			using (IDbCommand Command = Session.Connection.CreateCommand()) {
				Command.CommandText = "Proc_GetBillNo";
				Command.CommandType = CommandType.StoredProcedure;
				IDbDataParameter parameter = Command.CreateParameter();
				parameter.ParameterName = "aTable_nam";
				parameter.DbType = DbType.String;
				parameter.Value = tableName;
				Command.Parameters.Add(parameter);
				IDataReader Reader = Command.ExecuteReader();
				try {
					if (Reader.Read()) {
						Result = Reader.GetString(0);
					}
				}
				finally {
					Reader.Dispose();
				}
			}
			return Result;			
		}

		#endregion

		#region 私有方法

		private object ChangeType(object value, Type type) {
			if (value.ToString() == "" || value.ToString() == string.Empty || value == null) {
				if (type == typeof(decimal) || type == typeof(double) || type == typeof(int)) {
					return Convert.ChangeType(0, type);
				}
				else {
					return Convert.ChangeType(value, type);
				}
			}
			else
				return Convert.ChangeType(value, type);
		}


		private DbType GetParameterType(Type type) {
			if (type == typeof(Int16)) return DbType.Int16;
			if (type == typeof(Int32)) return DbType.Int32;
			if (type == typeof(int)) return DbType.Int32;
			if (type == typeof(string)) return DbType.String;
			if (type == typeof(Guid)) return DbType.Guid;
			if (type == typeof(bool)) return DbType.Boolean;
			if (type == typeof(bool)) return DbType.Boolean;
			if (type == typeof(Double)) return DbType.Double;
			if (type == typeof(double)) return DbType.Double;
			if (type == typeof(float)) return DbType.Double;
			if (type == typeof(decimal)) return DbType.Decimal;
			if (type == typeof(Decimal)) return DbType.Decimal;
			if (type == typeof(short)) return DbType.UInt16;
			if (type == typeof(UInt16)) return DbType.UInt16;
			if (type == typeof(DateTime)) return DbType.DateTime;
			if (type == typeof(byte)) return DbType.Byte;
			if (type == typeof(Byte)) return DbType.Byte;
			if (type == typeof(byte[])) return DbType.Binary;
			if (type == typeof(Byte[])) return DbType.Binary;
			if (type == typeof(long)) return DbType.Int64;
			return DbType.String;
		}

		#endregion

		#region IDisposable 成员

		public virtual void Dispose() {
			
		}


		#endregion
	}
}
