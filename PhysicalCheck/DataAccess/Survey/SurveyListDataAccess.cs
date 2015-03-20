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
    /// 数据访问类:SurveyListDataAccess
    /// 文  件  名:SurveyListDataAccess.cs
    /// 说      明:调查问卷模板数据访问对象
    /// </summary>
    public class SurveyListDataAccess : BaseDataAccess<SurveyListEntity> {

        #region 构造器

        public SurveyListDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有调查问卷模板数据
        /// </summary>
        public List<SurveyListEntity> Getsurveylists() {
            var q = from p in Session.Query<SurveyListEntity>()
                    where p.Enabled == true
                    select p;
            List<SurveyListEntity> Result = q.ToList<SurveyListEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        ///分页获取所有调查问卷模板数据
        /// </summary>
        public List<SurveyListEntity> Getsurveylists(int pageIndex, int pageSize,out int RecordCount) {
            var q = from p in Session.Query<SurveyListEntity>()
                    where p.Enabled == true
                    select p;
            List<SurveyListEntity> Result = q.ToPagedList<SurveyListEntity>(pageIndex,pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取调查问卷模板数据
        /// </summary>
        /// <param name="SID"></param> 
        /// <returns>调查问卷模板实体</returns>
        public SurveyListEntity Getsurveylist(int SID) {
            SurveyListEntity Result = Session.Get<SurveyListEntity>(SID);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存调查问卷模板数据
        /// </summary>
        /// <param name="surveylist">调查问卷模板实体</param>
        public void Savesurveylist(SurveyListEntity surveylist) {
            if (surveylist.SID == int.MinValue) surveylist.SID = GetLineID("surveylist");
            Session.SaveOrUpdate(surveylist);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除调查问卷模板数据
        /// </summary>
        /// <param name="surveylist">调查问卷模板实体</param>
        public void Deletesurveylist(SurveyListEntity surveylist) {
            Session.Delete(surveylist);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
