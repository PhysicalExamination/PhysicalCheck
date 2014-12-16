using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {

    /// <summary>
    /// 数据访问类:ItemGroupDataAccess
    /// 文  件  名:ItemGroupDataAccess.cs
    /// 说      明:组合项目数据访问对象
    /// </summary>
    public class ItemGroupDataAccess : BaseDataAccess<ItemGroupEntity> {

        #region 构造器

        public ItemGroupDataAccess() {

        }

        #endregion

        #region 公共方法

        public IList<ItemGroupViewEntity> GetItemGroups(int DeptID) {
            String hql = @" from ItemGroupViewEntity where Enabled=1 and DeptID=? order by DisplayOrder";
            IList<ItemGroupViewEntity> Result = Session.CreateQuery(hql)
                                               .SetInt32(0,DeptID)
                                                .List<ItemGroupViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        ///获取科室组合项目所有数据
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="DeptID">科室编号</param>
        /// <param name="RecordCount">总记录数据</param>
        ///<returns>组合项目列表</returns>
        public List<ItemGroupViewEntity> GetItemGroups(int pageIndex, int pageSize, out int RecordCount) {
            String hql = @"select count(DeptID) from ItemGroupViewEntity where Enabled=1 ";
            IQuery query = Session.CreateQuery(hql);
            object obj = query.UniqueResult();
            int.TryParse(obj.ToString(), out RecordCount);
            hql = @" from ItemGroupViewEntity where Enabled=1 order by DisplayOrder";
            List<ItemGroupViewEntity> Result = Session.CreateQuery(hql)                                                
                                                .SetFirstResult((pageIndex - 1) * pageSize)
                                                .SetMaxResults(pageSize)
                                                .List<ItemGroupViewEntity>().ToList<ItemGroupViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取组合项目数据
        /// </summary>
        /// <param name="GroupID">组合项目编号</param> 
        /// <returns>组合项目实体</returns>
        public ItemGroupViewEntity GetItemGroup(int GroupID) {
            ItemGroupViewEntity Result = Session.Get<ItemGroupViewEntity>(GroupID);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存组合项目数据
        /// </summary>
        /// <param name="ItemGroup">组合项目实体</param>
        public void SaveItemGroup(ItemGroupEntity ItemGroup) {
            if (ItemGroup.GroupID == int.MinValue) ItemGroup.GroupID = GetLineID("itemgroup");
            Session.SaveOrUpdate(ItemGroup);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除组合项目数据
        /// </summary>
        /// <param name="ItemGroup">组合项目实体</param>
        public void DeleteItemGroup(ItemGroupEntity ItemGroup) {
            Session.Delete(ItemGroup);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
