using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataEntity.Examination;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;
using System.Configuration;

namespace LISDataService {

    public class LISDataAccess : IDisposable {

        private OracleConnection m_Connection;

        #region 构造器

        public LISDataAccess() {
            String ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"] + "";
            m_Connection = new OracleConnection(ConnectionString);
            m_Connection.Open();
        }

        #endregion

        #region 公共方法

        public List<LisEntity> GetLisDatas() {
            List<LisEntity> Result = new List<LisEntity>();
            String SqlText = @"SELECT OUTPATIENT_ID,TEST_ORDER,TEST_ORDER_NAME, INSPECTION_PERSON,  
                                      CHECK_PERSON, TEST_ITEM_ID, CHINESE_NAME, QUANTITATIVE_RESULT,
                                      QUALITATIVE_RESULT,   TEST_ITEM_REFERENCE,TEST_ITEM_UNIT    
                               FROM v_lis_tijian";
            using (OracleCommand Command = new OracleCommand(SqlText, m_Connection)) {
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
            String SqlText = @"SELECT OUTPATIENT_ID,TEST_ORDER,TEST_ORDER_NAME, INSPECTION_PERSON,  
                                      CHECK_PERSON, TEST_ITEM_ID, CHINESE_NAME, QUANTITATIVE_RESULT,
                                      QUALITATIVE_RESULT,   TEST_ITEM_REFERENCE,TEST_ITEM_UNIT    
                               FROM v_lis_tijian WHERE outpatient_id='{0}'";
            SqlText = String.Format(SqlText, RegisterNo);
            using (OracleCommand Command = new OracleCommand(SqlText, m_Connection)) {
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

        public List<LisEntity> GetLisDatas(String RegisterNo, String GroupID) {
            List<LisEntity> Result = new List<LisEntity>();
            String SqlText = @"SELECT OUTPATIENT_ID,TEST_ORDER,TEST_ORDER_NAME, INSPECTION_PERSON,  
                                      CHECK_PERSON, TEST_ITEM_ID, CHINESE_NAME, QUANTITATIVE_RESULT,
                                      QUALITATIVE_RESULT,   TEST_ITEM_REFERENCE,TEST_ITEM_UNIT                                 
                               FROM V_LIS_TIJIAN WHERE outpatient_id='{0}' AND test_order='{1}'";
            SqlText = String.Format(SqlText, RegisterNo, GroupID);
            using (OracleCommand Command = new OracleCommand(SqlText, m_Connection)) {
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
                GroupID = DataReader.GetString(1),
                GroupName = DataReader.GetString(2),
                InspectionPerson = DataReader.GetString(3),
                CheckPerson = DataReader.GetString(4),
                ItemID = DataReader.GetString(5),
                ItemName = DataReader.GetString(6),
                QuantitativeResult = DataReader.GetString(7),
                QualitativeResult = DataReader.GetString(8),
                Reference = DataReader.GetString(9),
                MeasureUnit = DataReader.GetString(10)
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
