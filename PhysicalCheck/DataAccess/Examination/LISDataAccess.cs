using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using DataEntity.Examination;

namespace DataAccess.Examination {

    public class LISDataAccess:IDisposable {

        private OracleConnection m_Connection;

        #region 构造器

        public LISDataAccess() {
        }

        #endregion

        #region 公共方法

        public List<LisEntity> GetLisDatas() {
            List<LisEntity> Result = new List<LisEntity>();
            String SqlText = @"SELECT outpatient_id,test_order,test_item_id,
                                chinese_name,quantitative_result,test_item_reference,
                                test_item_unit   FROM v_lis_tijian";
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

        public List<LisEntity> GetLisDatas(String RegisterNo) {
            List<LisEntity> Result = new List<LisEntity>();
            String SqlText = @"SELECT outpatient_id,test_order,test_item_id,
                                chinese_name,quantitative_result,test_item_reference,
                                test_item_unit   FROM v_lis_tijian WHERE outpatient_id='{0}'";
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

        public List<LisEntity> GetLisDatas(String RegisterNo,String GroupID) {
            List<LisEntity> Result = new List<LisEntity>();
            String SqlText = @"SELECT outpatient_id,test_order,test_item_id,
                                chinese_name,quantitative_result,test_item_reference,
                                test_item_unit   FROM v_lis_tijian WHERE outpatient_id='{0}' AND test_order='{1}'";
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
                ItemID = DataReader.GetString(2),
                ItemName = DataReader.GetString(3),
                ItemResult = DataReader.GetString(4),
                Reference = DataReader.GetString(5),
                MeasureUnit = DataReader.GetString(6)
            };
            return Result;
        }

        #endregion

        #region Dispose

        public void Dispose() {
          
        }

        #endregion
    }
}
