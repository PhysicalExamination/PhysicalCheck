using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SysConfig;
using DataEntity.SysConfig;

namespace BusinessLogic.SysConfig {

    public class SuggestionBusiness : BaseBusinessLogic<SuggestionDataAccess> {

        /// <summary>
        ///分页获取所有数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数据</param>
        /// </summary>
        public List<SuggestionViewEntity> GetSuggestions(int pageIndex, int pageSize, out int RecordCount) {
            return DataAccess.GetSuggestions(pageIndex, pageSize, out RecordCount);
        }

        public List<SuggestionViewEntity> GetSuggestions(int pageIndex, int pageSize, int DeptID,
            out int RecordCount) {
            return DataAccess.GetSuggestions(pageIndex, pageSize, DeptID, out RecordCount);
        }

        public List<SuggestionViewEntity> GetSuggestions(int pageIndex, int pageSize, int GroupID, 
            String searchKey,out int RecordCount) {
                return DataAccess.GetSuggestions(pageIndex, pageSize,GroupID, searchKey, out RecordCount);
        }

        /// <summary>
        /// 获取体检建议数据
        /// </summary>
        /// <param name="SNo">流水号</param> 
        /// <returns>体检建议实体</returns>
        public SuggestionViewEntity GetSuggestion(int SNo) {
            return DataAccess.GetSuggestion(SNo);
        }

        /// <summary>
        /// 保存体检建议数据
        /// </summary>
        /// <param name="Suggestion">体检建议实体</param>
        public void SaveSuggestion(SuggestionEntity Suggestion) {
            DataAccess.SaveSuggestion(Suggestion);
        }

        /// <summary>
        /// 删除体检建议数据
        /// </summary>
        /// <param name="Suggestion">体检建议实体</param>
        public void DeleteSuggestion(SuggestionEntity Suggestion) {
            DataAccess.DeleteSuggestion(Suggestion);
        }
    }
}
