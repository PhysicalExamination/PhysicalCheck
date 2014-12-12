using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {

    /// <summary>
    /// 数据访问类:SuggestionDataAccess
    /// 文  件  名:SuggestionDataAccess.cs
    /// 说      明:体检建议数据访问对象
    /// </summary>
    public class SuggestionDataAccess : BaseDataAccess<SuggestionEntity> {

        #region 构造器

        public SuggestionDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///分页获取所有数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数据</param>
        /// </summary>
        public List<SuggestionViewEntity> GetSuggestions(int pageIndex, int pageSize, out int RecordCount) {
            String hql = @"select count(SNO) from SuggestionViewEntity order by DisplayOrder";
            IQuery query = Session.CreateQuery(hql);
            object obj = query.UniqueResult();
            int.TryParse(obj.ToString(), out RecordCount);
            hql = @" from SuggestionViewEntity order by DisplayOrder";
            List<SuggestionViewEntity> Result = Session.CreateQuery(hql)
                                                .SetFirstResult((pageIndex - 1) * pageSize)
                                                .SetMaxResults(pageSize)
                                                .List<SuggestionViewEntity>().ToList<SuggestionViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检建议数据
        /// </summary>
        /// <param name="SNo">流水号</param> 
        /// <returns>体检建议实体</returns>
        public SuggestionViewEntity GetSuggestion(int SNo) {
            SuggestionViewEntity Result = Session.Get<SuggestionViewEntity>(SNo);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存体检建议数据
        /// </summary>
        /// <param name="Suggestion">体检建议实体</param>
        public void SaveSuggestion(SuggestionEntity Suggestion) {
            if (Suggestion.SNo == int.MinValue) Suggestion.SNo = GetLineID("Suggestion");
            Session.SaveOrUpdate(Suggestion);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检建议数据
        /// </summary>
        /// <param name="Suggestion">体检建议实体</param>
        public void DeleteSuggestion(SuggestionEntity Suggestion) {
            Session.Delete(Suggestion);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
