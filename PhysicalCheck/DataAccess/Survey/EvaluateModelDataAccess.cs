using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagedList;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Survey;

namespace DataAccess.Survey {
    /// <summary>
    /// 数据访问类:EvaluateModelDataAccess
    /// 文  件  名:EvaluateModelDataAccess.cs
    /// 说      明:评估模型数据访问对象
    /// </summary>
    public class EvaluateModelDataAccess : BaseDataAccess<EvaluateModelEntity> {

        #region 构造器

        public EvaluateModelDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有评估模型数据
        /// </summary>
        public List<EvaluateModelEntity> GetEvaluateModels() {
            var q = Session.Query<EvaluateModelEntity>();
            List<EvaluateModelEntity> Result = q.ToList<EvaluateModelEntity>();
            CloseSession();
            return Result;
        }

        ///<summary>
        ///分页获取所有评估模型数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数</param>
        /// </summary>
        public List<EvaluateModelEntity> GetEvaluateModels(int pageIndex, int pageSize, 
            out int RecordCount) {
            var q = Session.Query<EvaluateModelEntity>();
            List<EvaluateModelEntity> Result = q.ToPagedList<EvaluateModelEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取评估模型数据
        /// </summary>
        /// <param name="ModelID"></param> 
        /// <returns>评估模型实体</returns>
        public EvaluateModelEntity GetEvaluateModel(int ModelID) {
            EvaluateModelEntity Result = Session.Get<EvaluateModelEntity>(ModelID);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存评估模型数据
        /// </summary>
        /// <param name="evaluatemodel">评估模型实体</param>
        public void SaveEvaluateModel(EvaluateModelEntity evaluatemodel) {
            if (evaluatemodel.ModelID == int.MinValue) evaluatemodel.ModelID = GetLineID("evaluatemodel");
            Session.SaveOrUpdate(evaluatemodel);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除评估模型数据
        /// </summary>
        /// <param name="evaluatemodel">评估模型实体</param>
        public void DeleteEvaluateModel(EvaluateModelEntity evaluatemodel) {
            Session.Delete(evaluatemodel);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
