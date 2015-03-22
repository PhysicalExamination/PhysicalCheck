using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.Examination;

using System.Data.OracleClient;
using System.Data.OleDb;
using System.Configuration;

namespace LISDataService {

    public class LISDataAccess : IDisposable {

        private OleDbConnection m_Connection;

        #region 构造器
        //
        public LISDataAccess() {
            String ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"] + "";
            m_Connection = new OleDbConnection(ConnectionString);
            m_Connection.Open();
        }

        #endregion

        #region 公共方法

        public List<LisEntity> GetLisDatas() {
            List<LisEntity> Result = new List<LisEntity>();
            String SqlText = @"SELECT INPATIENT_ID,TEST_ORDER,TEST_ORDER_NAME, INSPECTION_PERSON,  
                                      CHECK_PERSON, TEST_ITEM_ID, CHINESE_NAME, QUANTITATIVE_RESULT,
                                      QUALITATIVE_RESULT,   TEST_ITEM_REFERENCE,TEST_ITEM_UNIT    
                               FROM dbo.v_lis_tijian";
            using (OleDbCommand Command = new OleDbCommand(SqlText, m_Connection)) {
                Command.CommandType = CommandType.Text;
                using (IDataReader DataReader = Command.ExecuteReader()) {
                    while (DataReader.Read()) {
                        Result.Add(GetEntity(DataReader));
                    }
                    DataReader.Close();
                }
            }
            //Oracle.DataAccess.Client.piv
            return Result;
        }

        public List<LisEntity> GetLisDatas(String RegisterNo) {
            List<LisEntity> Result = new List<LisEntity>();
            String SqlText = @"SELECT INPATIENT_ID,TEST_ORDER,TEST_ORDER_NAME, INSPECTION_PERSON,  
                                      CHECK_PERSON, TEST_ITEM_ID, CHINESE_NAME, QUANTITATIVE_RESULT,
                                      QUALITATIVE_RESULT, TEST_ITEM_REFERENCE,TEST_ITEM_UNIT    
                                FROM dbo.v_lis_tijian WHERE INPATIENT_ID='{0}'";

            SqlText = String.Format(SqlText, RegisterNo);
            using (OleDbCommand Command = new OleDbCommand(SqlText, m_Connection)) {
                Command.CommandType = CommandType.Text;
                using (OleDbDataReader DataReader = Command.ExecuteReader()) {
                    while (DataReader.Read()) {
                        Result.Add(GetEntity(DataReader));
                    }
                    DataReader.Close();
                }
            }
            return Result;
        }

        public List<LisEntity> GetLisDatas(String RegisterNo, String GroupID) {
            List<LisEntity> Result = new List<LisEntity>();
            String SqlText = @"SELECT INPATIENT_ID,TEST_ORDER,TEST_ORDER_NAME, INSPECTION_PERSON,  
                                      CHECK_PERSON, TEST_ITEM_ID, CHINESE_NAME, QUANTITATIVE_RESULT,
                                      QUALITATIVE_RESULT,   TEST_ITEM_REFERENCE,TEST_ITEM_UNIT                                 
                               FROM dbo.V_LIS_TIJIAN WHERE INPATIENT_ID='{0}' AND test_order='{1}'";
            SqlText = String.Format(SqlText, RegisterNo, GroupID);
            using (OleDbCommand Command = new OleDbCommand(SqlText, m_Connection)) {
                Command.CommandType = CommandType.Text;
                using (IDataReader DataReader = Command.ExecuteReader()) {
                    while (DataReader.Read()) {
                        Result.Add(GetEntity(DataReader));
                    }
                    DataReader.Close();
                }
            }
            return Result;
        }

        #endregion

        #region 私有方法

        private LisEntity GetEntity(IDataReader DataReader) {
            LisEntity Result = new LisEntity {
                RegisterNo = DataReader.GetString(0),
                GroupID = DataReader[1].ToString(),
                GroupName = DataReader[2].ToString(),
                InspectionPerson = DataReader[3].ToString(),
                CheckPerson = DataReader[4].ToString(),
                ItemID = DataReader[5].ToString(),
                ItemName = DataReader[6].ToString(),
                QuantitativeResult = DataReader[7].ToString(),
                QualitativeResult = DataReader[8].ToString(),
                Reference = DataReader[9].ToString(),
                MeasureUnit = DataReader[10].ToString()
            };
            return Result;
        }

        #endregion

        #region Dispose

        public void Dispose() {
            if (m_Connection != null) {
                m_Connection.Close();
                m_Connection.Dispose();
                m_Connection = null;
            }

        }

        #endregion
    }
}
