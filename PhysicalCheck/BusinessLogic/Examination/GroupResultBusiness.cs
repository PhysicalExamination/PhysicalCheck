using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.Examination;
using DataAccess.Examination;

namespace BusinessLogic.Examination {

    /// <summary>
    /// 业务逻辑类:GroupResultBusiness
    /// 文  件  名:GroupResultBusiness.cs
    /// 说      明:体检组合项目结论业务逻辑对象
    /// </summary>
    public class GroupResultBusiness : BaseBusinessLogic<GroupResultDataAccess> {

        #region 构造器

        public GroupResultBusiness() {

        }

        #endregion

        #region 公共方法

        public List<GroupResultViewEntity> GetGroupResults(string RegisterNo) {
            return DataAccess.GetGroupResults(RegisterNo);
        }

        public GroupResultViewEntity GetGroupResult(string RegisterNo, int GroupID) {
            return DataAccess.GetGroupResult(RegisterNo, GroupID);
        }

        public void SaveGroupResult(GroupResultEntity GroupResult) {
            DataAccess.SaveGroupResult(GroupResult);
        }

        public void DeleteGroupResult(GroupResultEntity GroupResult) {
            DataAccess.DeleteGroupResult(GroupResult);
        }

        #endregion
    }
}
