using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {
    /// <summary>
    /// 数据访问类:CommonResultDataAccess
    /// 文  件  名:CommonResultDataAccess.cs
    /// 说      明:常见体检结果数据访问对象
    /// </summary>
    public class CommonResultDataAccess : BaseDataAccess<CommonResultEntity> {

        #region 构造器

        public CommonResultDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///分页获取常见体检结果数据
        ///<param name="pageIndex">页号</param>
        ///<param name="pageSize">页面大小</param>
        ///<param name="RecordCount">总记录数据</param>
        /// </summary>
        public List<CommonResultEntity> GetCommonResults(int pageIndex, int pageSize, int DeptID, out int RecordCount) {
            String hql = "select count(ItemID) from CommonResultEntity";
            IQuery query = Session.CreateQuery(hql);
            object obj = query.UniqueResult();
            int.TryParse(obj.ToString(), out RecordCount);
            hql = @" from CommonResultEntity where DeptID=?";
            List<CommonResultEntity> Result = Session.CreateQuery(hql)
                                              .SetInt32(0, DeptID)
                                              .SetFirstResult((pageIndex - 1) * pageSize)
                                              .SetMaxResults(pageSize)
                                              .List<CommonResultEntity>().ToList<CommonResultEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取常见体检结果数据
        /// </summary>
        /// <param name="ItemID"></param> 
        /// <param name="ResultID"></param> 
        /// <returns>常见体检结果实体</returns>
        public CommonResultEntity GetCommonResult(int ItemID, int ResultID) {
            var q = from p in Session.Query<CommonResultEntity>()
                    where p.ID.ItemID == ItemID && p.ID.ResultID == ResultID
                    select p;
            List<CommonResultEntity> Result = q.ToList<CommonResultEntity>();
            CloseSession();
            if (Result.Count > 0) return Result[0];
            return null;

        }

        /// <summary>
        /// 保存常见体检结果数据
        /// </summary>
        /// <param name="CommonResult">常见体检结果实体</param>
        public void SaveCommonResult(CommonResultEntity CommonResult) {
            if (CommonResult.ID.ResultID == int.MinValue) CommonResult.ID.ResultID = GetLineID("CommonResult");
            Session.SaveOrUpdate(CommonResult);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除常见体检结果数据
        /// </summary>
        /// <param name="CommonResult">常见体检结果实体</param>
        public void DeleteCommonResult(CommonResultEntity CommonResult) {
            Session.Delete(CommonResult);
            Session.Flush();
            CloseSession();
        }

        #endregion


    }
}
