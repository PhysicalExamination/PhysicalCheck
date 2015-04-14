using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PagedList;
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
            var q = Session.Query<SuggestionViewEntity>();
            q = q.Where(p => p.Enabled == true);
            q = q.OrderBy(p => p.DisplayOrder);
            List<SuggestionViewEntity> Result = q.ToPagedList<SuggestionViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        public List<SuggestionViewEntity> GetSuggestions(int pageIndex, int pageSize, int DeptID,
            out int RecordCount) {
            var q = Session.Query<SuggestionViewEntity>();
            q = q.Where(p => p.Enabled == true && p.DeptID == DeptID);
            q = q.OrderBy(p => p.DisplayOrder);
            List<SuggestionViewEntity> Result = q.ToPagedList<SuggestionViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        public List<SuggestionViewEntity> GetSuggestions(int pageIndex, int pageSize,int GroupID,
            String searchKey,out int RecordCount) {
            var q = Session.Query<SuggestionViewEntity>();
            q = q.Where(p => p.Enabled == true && p.DeptID == GroupID);
            if (!String.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p=>p.KeyWord.Contains(searchKey) ||(p.Name.Contains(searchKey)));
            }
            q = q.OrderBy(p => p.DisplayOrder);
            List<SuggestionViewEntity> Result = q.ToPagedList<SuggestionViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
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
            Suggestion.DisplayOrder = Suggestion.SNo;
            Suggestion.Enabled = true;
            Session.SaveOrUpdate(Suggestion);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检建议数据
        /// </summary>
        /// <param name="Suggestion">体检建议实体</param>
        public void DeleteSuggestion(SuggestionEntity Suggestion) {
            Suggestion.Enabled = false;
            Session.SaveOrUpdate(Suggestion);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
