using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.Survey;
using DataAccess.Survey;

namespace BusinessLogic.Survey {

    /// <summary>
    /// 业务逻辑类:EvaluateFactorBusiness
    /// 文  件  名:EvaluateFactorBusiness.cs
    /// 说      明:评估因素业务逻辑对象
    /// </summary>
    public class EvaluateFactorBusiness : BaseBusinessLogic<EvaluateFactorDataAccess> {

        #region 构造器

        public EvaluateFactorBusiness() {

        }

        #endregion

        #region 公共方法

        public List<EvaluateFactorEntity> GetEvaluateFactors() {
            return DataAccess.GetEvaluateFactors();
        }

        ///<summary>
        ///分页获取所有评估因素数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数</param>
        /// </summary>
        public List<EvaluateFactorEntity> GetEvaluateFactors(int pageIndex, int pageSize,
            out int RecordCount) {
            return DataAccess.GetEvaluateFactors(pageIndex, pageSize, out RecordCount);
        }

        public EvaluateFactorEntity GetEvaluateFactor(int EID) {
            return DataAccess.GetEvaluateFactor(EID);
        }

        public void SaveEvaluateFactor(EvaluateFactorEntity evaluatefactor) {
            DataAccess.SaveEvaluateFactor(evaluatefactor);
        }

        public void DeleteEvaluateFactor(EvaluateFactorEntity evaluatefactor) {
            DataAccess.DeleteEvaluateFactor(evaluatefactor);
        }

        #endregion
    }
}
