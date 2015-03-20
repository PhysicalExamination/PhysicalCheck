using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.Survey;
using DataAccess.Survey;

namespace BusinessLogic.Survey {

    /// <summary>
    /// 业务逻辑类:EvaluateModelBusiness
    /// 文  件  名:EvaluateModelBusiness.cs
    /// 说      明:评估模型业务逻辑对象
    /// </summary>
    public class EvaluateModelBusiness : BaseBusinessLogic<EvaluateModelDataAccess> {

        #region 构造器

        public EvaluateModelBusiness() {

        }

        #endregion

        #region 公共方法

        public List<EvaluateModelEntity> GetEvaluateModels() {
            return DataAccess.GetEvaluateModels();
        }

        ///<summary>
        ///分页获取所有评估模型数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数</param>
        /// </summary>
        public List<EvaluateModelEntity> GetEvaluateModels(int pageIndex, int pageSize,
            out int RecordCount) {
                return DataAccess.GetEvaluateModels(pageIndex, pageSize, out RecordCount);
        }

        public EvaluateModelEntity GetEvaluateModel(int ModelID) {
            return DataAccess.GetEvaluateModel(ModelID);
        }

        public void Saveevaluatemodel(EvaluateModelEntity evaluatemodel) {
            DataAccess.SaveEvaluateModel(evaluatemodel);
        }

        public void DeleteEvaluateModel(EvaluateModelEntity evaluatemodel) {
            DataAccess.DeleteEvaluateModel(evaluatemodel);
        }

        #endregion
    }
}
