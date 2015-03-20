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
    /// 数据访问类:SurveyQuestionDataAccess
    /// 文  件  名:SurveyQuestionDataAccess.cs
    /// 说      明:调查问卷数据访问对象
    /// </summary>
    public class SurveyQuestionDataAccess : BaseDataAccess<SurveyQuestionEntity> {

        #region 构造器

        public SurveyQuestionDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有调查问卷数据
        /// </summary>
        public List<SurveyQuestionEntity> GetSurveyQuestions() {
            var q = from p in Session.Query<SurveyQuestionEntity>()
                    where p.Enabled == true
                    select p;
            List<SurveyQuestionEntity> Result = q.ToList<SurveyQuestionEntity>();
            CloseSession();
            return Result;
        }

        ///<summary>
        ///分页获取所有调查问卷数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数</param>
        /// </summary>
        public List<SurveyQuestionEntity> GetSurveyQuestions(int pageIndex, int pageSize, 
            out int RecordCount) {
            var q = from p in Session.Query<SurveyQuestionEntity>()
                    where p.Enabled == true
                    select p;
            List<SurveyQuestionEntity> Result = q.ToPagedList<SurveyQuestionEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取调查问卷数据
        /// </summary>
        /// <param name="QID">问题编码</param> 
        /// <returns>调查问卷实体</returns>
        public SurveyQuestionEntity GetSurveyQuestion(int QID) {
            SurveyQuestionEntity Result = Session.Get<SurveyQuestionEntity>(QID);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存调查问卷数据
        /// </summary>
        /// <param name="surveyquestion">调查问卷实体</param>
        public void SaveSurveyQuestion(SurveyQuestionEntity surveyquestion) {
            if (surveyquestion.QID == int.MinValue) surveyquestion.QID = GetLineID("surveyquestion");
            Session.SaveOrUpdate(surveyquestion);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="surveyquestion">调查问卷实体</param>
        public void DeleteSurveyQuestion(SurveyQuestionEntity surveyquestion) {
            Session.Delete(surveyquestion);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
