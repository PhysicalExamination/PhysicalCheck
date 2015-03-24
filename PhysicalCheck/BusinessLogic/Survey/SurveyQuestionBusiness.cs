using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.Survey;
using DataAccess.Survey;

namespace BusinessLogic.Survey {

    /// <summary>
    /// 业务逻辑类:SurveyQuestionBusiness
    /// 文  件  名:SurveyQuestionBusiness.cs
    /// 说      明:调查问卷业务逻辑对象
    /// </summary>
    public class SurveyQuestionBusiness : BaseBusinessLogic<SurveyQuestionDataAccess> {

        #region 构造器

        public SurveyQuestionBusiness() {

        }

        #endregion

        #region 公共方法

        public List<SurveyQuestionEntity> GetSurveyQuestions() {
            return DataAccess.GetSurveyQuestions();
        }

        ///<summary>
        ///分页获取所有调查问卷数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数</param>
        /// </summary>
        public List<SurveyQuestionEntity> GetSurveyQuestions(int pageIndex, int pageSize,
            out int RecordCount) {
                return DataAccess.GetSurveyQuestions(pageIndex, pageSize, out RecordCount);
        }

        public SurveyQuestionEntity GetSurveyQuestion(int QID) {
            return DataAccess.GetSurveyQuestion(QID);
        }

        public void SaveSurveyQuestion(SurveyQuestionEntity surveyquestion) {
            DataAccess.SaveSurveyQuestion(surveyquestion);
        }

        public void DeleteSurveyQuestion(SurveyQuestionEntity surveyquestion) {
            DataAccess.DeleteSurveyQuestion(surveyquestion);
        }

        #endregion
    }
}
