using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.Survey;
using DataAccess.Survey;

namespace BusinessLogic.Survey {

    /// <summary>
    /// 业务逻辑类:QuestionOptionBusiness
    /// 文  件  名:QuestionOptionBusiness.cs
    /// 说      明:问题选项业务逻辑对象
    /// </summary>
    public class QuestionOptionBusiness : BaseBusinessLogic<QuestionOptionDataAccess> {

        #region 构造器

        public QuestionOptionBusiness() {

        }

        #endregion

        #region 公共方法

        public List<QuestionOptionEntity> GetQuestionOptions(int QuestionID) {
            return DataAccess.GetQuestionOptions(QuestionID);
        }

        ///<summary>
        ///分页获取所有问题选项数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数</param>
        /// </summary>
        public List<QuestionOptionEntity> GetQuestionOptions(int pageIndex, int pageSize,
            out int RecordCount) {
                return DataAccess.GetQuestionOptions(pageIndex, pageSize, out RecordCount);
        }

        public QuestionOptionEntity GetQuestionOption(int QID, int SN) {
            return DataAccess.GetQuestionOption(QID, SN);
        }

        public void SaveQuestionOption(QuestionOptionEntity questionoption) {
            DataAccess.SaveQuestionOption(questionoption);
        }

        public void DeleteQuestionOption(QuestionOptionEntity questionoption) {
            DataAccess.DeleteQuestionOption(questionoption);
        }

        #endregion
    }
}
