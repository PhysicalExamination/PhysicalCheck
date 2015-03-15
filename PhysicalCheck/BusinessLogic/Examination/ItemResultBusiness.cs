using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DataEntity.Examination;
using DataAccess.Examination;

namespace BusinessLogic.Examination {

    /// <summary>
    /// 业务逻辑类:ItemResultBusiness
    /// 文  件  名:ItemResultBusiness.cs
    /// 说      明:体检项目结论业务逻辑对象
    /// </summary>
    public class ItemResultBusiness : BaseBusinessLogic<ItemResultDataAccess> {

        #region 构造器

        public ItemResultBusiness() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 获取所有一体检未从LIS返回结果信息
        /// </summary>
        /// <returns></returns>
        public List<String> GetRegisterDataForLIS() {
            return DataAccess.GetRegisterDataForLIS();
        }

        public List<ItemResultViewEntity> GetItemResults(string RegisterNo, int GroupID) {
            return DataAccess.GetItemResults(RegisterNo, GroupID);
        }

        ///// <summary>
        /////获取体检科室所有体检项目结论数据
        ///// </summary>
        //public IList<ItemResultViewEntity> GetDeptItemResults(int pageIndex, int pageSize,
        //    string RegisterNo, int DeptID, out int RecordCount) {
        //    IList<ItemResultViewEntity> List = DataAccess.GetDeptItemResults(pageIndex, pageSize,
        //        RegisterNo, DeptID, out RecordCount);
        //    var q = List.Select(p => new ItemResultViewEntity {
        //        ID = p.ID,
        //        ItemName = p.ItemName,
        //        CheckedResult = String.IsNullOrEmpty(p.CheckedResult) ? p.NormalTips : p.CheckedResult,
        //        UpperLimit = p.UpperLimit,
        //        LowerLimit = p.LowerLimit,
        //        MeasureUnit = p.MeasureUnit
        //    });
        //    return q.ToList<ItemResultViewEntity>();
        //    //return DataAccess.GetDeptItemResults(pageIndex, pageSize, RegisterNo, DeptID, out RecordCount);
        //}

        /// <summary>
        ///获取体检科室组合所有体检项目结论数据
        /// </summary>
        public List<ItemResultViewEntity> GetDeptItemResults(
            string RegisterNo, int GroupId) {
            return DataAccess.GetDeptItemResults(RegisterNo, GroupId);
            /*var q = List.Select(p => new ItemResultViewEntity
            {
                ID = p.ID,
                ItemName = p.ItemName,
                CheckedResult = String.IsNullOrEmpty(p.CheckedResult) ? p.NormalTips : p.CheckedResult,
                UpperLimit = p.UpperLimit,
                LowerLimit = p.LowerLimit,
                MeasureUnit = p.MeasureUnit               
            });          
            return q.ToList<ItemResultViewEntity>();  */
        }



        public ItemResultViewEntity GetItemResult(string RegisterNo, int GroupID, int ItemID) {
            return DataAccess.GetItemResult(RegisterNo, GroupID, ItemID);
        }

        public void SaveItemResult(String RegisterNo, int ItemID, String CheckResult,
            String QualitativeResult, String CheckDoctor) {
                DataAccess.SaveItemResult(RegisterNo, ItemID, CheckResult, 
                    GetQualitativeResult(QualitativeResult), CheckDoctor);
        }

        public void SaveItemResult(ItemResultEntity ItemResult) {
            DataAccess.SaveItemResult(ItemResult);
        }

        public void DeleteItemResult(ItemResultEntity ItemResult) {
            DataAccess.DeleteItemResult(ItemResult);
        }


        private String GetQualitativeResult(String CheckedResult) {
            if (String.IsNullOrEmpty(CheckedResult)) return "";
            if (CheckedResult == "h") return "↑";
            if (CheckedResult == "l") return "↓";
            return "";
        }
        #endregion
    }
}
