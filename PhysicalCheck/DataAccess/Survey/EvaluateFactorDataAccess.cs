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
    /// 数据访问类:EvaluateFactorDataAccess
    /// 文  件  名:EvaluateFactorDataAccess.cs
    /// 说      明:评估因素数据访问对象
    /// </summary>
    public class EvaluateFactorDataAccess : BaseDataAccess<EvaluateFactorEntity> {

        #region 构造器

        public EvaluateFactorDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有评估因素数据
        /// </summary>
        public List<EvaluateFactorEntity> GetEvaluateFactors() {
            var q = from p in Session.Query<EvaluateFactorEntity>()
                    where p.Enabled == true
                    select p;
            List<EvaluateFactorEntity> Result = q.ToList<EvaluateFactorEntity>();
            CloseSession();
            return Result;
        }

        ///<summary>
        ///分页获取所有评估因素数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数</param>
        /// </summary>
        public List<EvaluateFactorEntity> GetEvaluateFactors(int pageIndex, int pageSize, 
            out int RecordCount) {
            var q = from p in Session.Query<EvaluateFactorEntity>()
                    where p.Enabled == true
                    select p;
            List<EvaluateFactorEntity> Result = q.ToPagedList<EvaluateFactorEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取评估因素数据
        /// </summary>
        /// <param name="EID">因素编码</param> 
        /// <returns>评估因素实体</returns>
        public EvaluateFactorEntity GetEvaluateFactor(int EID) {
            EvaluateFactorEntity Result = Session.Get<EvaluateFactorEntity>(EID);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存评估因素数据
        /// </summary>
        /// <param name="evaluatefactor">评估因素实体</param>
        public void SaveEvaluateFactor(EvaluateFactorEntity evaluatefactor) {
            if (evaluatefactor.EID == int.MinValue) evaluatefactor.EID = GetLineID("evaluatefactor");
            Session.SaveOrUpdate(evaluatefactor);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除评估因素数据
        /// </summary>
        /// <param name="evaluatefactor">评估因素实体</param>
        public void DeleteEvaluateFactor(EvaluateFactorEntity evaluatefactor) {
            Session.Delete(evaluatefactor);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
