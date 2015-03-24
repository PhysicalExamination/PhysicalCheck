using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.Survey;
using DataAccess.Survey;

namespace BusinessLogic.Survey {

    /// <summary>
    /// 业务逻辑类:SurveyListBusiness
    /// 文  件  名:SurveyListBusiness.cs
    /// 说      明:调查问卷模板业务逻辑对象
    /// </summary>
    public class SurveyListBusiness : BaseBusinessLogic<SurveyListDataAccess> {

        #region 构造器

        public SurveyListBusiness() {

        }

        #endregion

        #region 公共方法

        public List<SurveyListEntity> GetSurveyLists() {
            return DataAccess.GetSurveyLists();
        }

        /// <summary>
        ///分页获取所有调查问卷模板数据
        /// </summary>
        public List<SurveyListEntity> GetSurveyLists(int pageIndex, int pageSize, out int RecordCount) {
            return DataAccess.GetSurveyLists(pageIndex, pageSize,out RecordCount);
        }

        public SurveyListEntity GetSurveyList(int SID) {
            return DataAccess.GetSurveyList(SID);
        }

        public void SaveSurveyList(SurveyListEntity SurveyList) {
            DataAccess.SaveSurveyList(SurveyList);
        }

        public void DeleteSurveyList(SurveyListEntity SurveyList) {
            DataAccess.DeleteSurveyList(SurveyList);
        }

        #endregion
    }
}
