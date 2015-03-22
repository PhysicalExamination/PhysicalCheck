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

        public List<GroupResultViewEntity> GetGroupResults(string RegisterNo, int DeptID) {
            return DataAccess.GetGroupResults(RegisterNo, DeptID);
        }

        public GroupResultViewEntity GetGroupResult(string RegisterNo, int GroupID) {
            return DataAccess.GetGroupResult(RegisterNo, GroupID);
        }    


        /// <summary>
        /// 返回需要从LIS中返回结果的体检信息
        /// </summary>
        /// <returns></returns>
        public List<GroupResultViewEntity> GetGroupInfo4LIS() {
            return DataAccess.GetGroupInfo4LIS();
        }
        public void SaveGroupResult(GroupResultEntity GroupResult) {
            DataAccess.SaveGroupResult(GroupResult);
        }

        public void DeleteGroupResult(GroupResultEntity GroupResult) {
            DataAccess.DeleteGroupResult(GroupResult);
        }

        /// <summary>
        /// 返回体检人各检查项小结
        /// </summary>
        /// <param name="RegisterNo">登记号</param>
        /// <returns></returns>
        public List<String> GetGroupSummary(String RegisterNo) {
            return DataAccess.GetGroupSummary(RegisterNo);
        }

        /// <summary>
        /// 更新组合项小结
        /// </summary>
        /// <param name="RegisterNo"></param>
        /// <param name="GroupID"></param>
        /// <param name="Summary"></param>
        public void UpdateSummary(String RegisterNo, int GroupID, String Summary) {
            DataAccess.UpdateSummary(RegisterNo, GroupID, Summary);
        }

        #endregion
    }
}
