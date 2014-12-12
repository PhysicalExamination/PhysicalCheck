using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {

    /// <summary>
    /// 数据访问类:ItemGroupDetailDataAccess
    /// 文  件  名:ItemGroupDetailDataAccess.cs
    /// 说      明:组合项目明细数据访问对象
    /// </summary>
    public class ItemGroupDetailDataAccess : BaseDataAccess<ItemGroupDetailEntity> {

        #region 构造器

        public ItemGroupDetailDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取组合的明细数据
        ///<param name="GroupID">组合编号</param>
        /// </summary>
        public List<ItemGroupDetailViewEntity> GetItemGroupDetails(int GroupID) {
            var q = from p in Session.Query<ItemGroupDetailViewEntity>()
                    where p.ID.GroupID == GroupID
                    select p;
            List<ItemGroupDetailViewEntity> Result = q.ToList<ItemGroupDetailViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 按分页的方式返回组合检查项目明细信息
        /// </summary>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="GroupID">组合编号</param>
        /// <param name="RecordCount">总记录数</param>
        /// <returns></returns>
        public List<ItemGroupDetailViewEntity> GetItemGroupDetails(int pageIndex, int pageSize,
            int GroupID, out int RecordCount) {
            String hql = @"select count(GroupID) from ItemGroupDetailViewEntity where GroupID=? ";
            IQuery query = Session.CreateQuery(hql)
                .SetInt32(0, GroupID);
            object obj = query.UniqueResult();
            int.TryParse(obj.ToString(), out RecordCount);
            hql = @" from ItemGroupDetailViewEntity where GroupID=? ";
            List<ItemGroupDetailViewEntity> Result = Session.CreateQuery(hql)
                                                .SetInt32(0, GroupID)
                                                .SetFirstResult((pageIndex - 1) * pageSize)
                                                .SetMaxResults(pageSize)
                                                .List<ItemGroupDetailViewEntity>().ToList<ItemGroupDetailViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取组合项目明细数据
        /// </summary>
        /// <param name="GroupID">组合编号</param> 
        /// <param name="ItemID">项目编号</param> 
        /// <returns>组合项目明细实体</returns>
        public ItemGroupDetailViewEntity GetItemGroupDetail(int GroupID, int ItemID) {
            ItemGroupDetailPK ID = new ItemGroupDetailPK { GroupID = GroupID, ItemID = ItemID };
            ItemGroupDetailViewEntity Result = Session.Get<ItemGroupDetailViewEntity>(ID);
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 保存组合项目明细数据
        /// </summary>
        /// <param name="ItemGroupDetail">组合项目明细实体</param>
        public void SaveItemGroupDetail(ItemGroupDetailEntity ItemGroupDetail) {
            Session.SaveOrUpdate(ItemGroupDetail);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除组合项目明细数据
        /// </summary>
        /// <param name="ItemGroupDetail">组合项目明细实体</param>
        public void DeleteItemGroupDetail(ItemGroupDetailEntity ItemGroupDetail) {
            Session.Delete(ItemGroupDetail);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
