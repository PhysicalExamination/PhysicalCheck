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
    /// 数据访问类:QuestionOptionDataAccess
    /// 文  件  名:QuestionOptionDataAccess.cs
    /// 说      明:问题选项数据访问对象
    /// </summary>
    public class QuestionOptionDataAccess : BaseDataAccess<QuestionOptionEntity> {

        #region 构造器

        public QuestionOptionDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有问题选项数据
        /// </summary>
        public List<QuestionOptionEntity> GetQuestionOptions() {
            var q = Session.Query<QuestionOptionEntity>();                  
            List<QuestionOptionEntity> Result = q.ToList<QuestionOptionEntity>();
            CloseSession();
            return Result;
        }

        ///<summary>
        ///分页获取所有问题选项数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数</param>
        /// </summary>
        public List<QuestionOptionEntity> GetQuestionOptions(int pageIndex, int pageSize, 
            out int RecordCount) {
            var q = Session.Query<QuestionOptionEntity>();                   
            List<QuestionOptionEntity> Result = q.ToPagedList<QuestionOptionEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="QID">问题编码</param> 
        /// <param name="SN">序号</param> 
        /// <returns>问题选项实体</returns>
        public QuestionOptionEntity GetQuestionOption(int QID, int SN) {
            QuestionOptionPK ID = new QuestionOptionPK {
                QID = QID,
                SN = SN
            };
            QuestionOptionEntity Result = Session.Get<QuestionOptionEntity>(ID);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存问题选项数据
        /// </summary>
        /// <param name="questionoption">问题选项实体</param>
        public void SaveQuestionOption(QuestionOptionEntity questionoption) {
            if (questionoption.ID.SN == int.MinValue) questionoption.ID.SN = GetLineID("questionoption");
            Session.SaveOrUpdate(questionoption);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除问题选项数据
        /// </summary>
        /// <param name="questionoption">问题选项实体</param>
        public void DeleteQuestionOption(QuestionOptionEntity questionoption) {
            Session.Delete(questionoption);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
