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
    /// 体检项目数据访问对象
    /// </summary>
    public class CheckedItemDataAccess:BaseDataAccess<CheckedItemEntity> {

        #region 构造器

        public CheckedItemDataAccess() {
        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取体检项目所有数据
        /// </summary>
        ///<returns>体检项目列表</returns>
        public List<CheckedItemViewEntity> GetCheckedItems() {
            var q = from p in Session.Query<CheckedItemViewEntity>()
                    where p.Enabled == true
                    select p;
            List<CheckedItemViewEntity> Result = q.ToList<CheckedItemViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        ///获取科室体检项目所有数据
        /// </summary>
        /// <param name="pageIndex">页数</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="DeptID">科室编号</param>
        /// <param name="RecordCount">总记录数据</param>
        ///<returns>体检项目列表</returns>
        public List<CheckedItemViewEntity> GetCheckedItems(int pageIndex, int pageSize, int DeptID, out int RecordCount) {
            //String hql = @"select count(ItemID) from CheckedItemEntity where Enabled=true and DeptID=? ";
            //IQuery query = Session.CreateQuery(hql)
            //    .SetInt32(0,DeptID);
            //object obj = query.UniqueResult();
            //int.TryParse(obj.ToString(), out RecordCount);
            //hql = @" from CheckedItemEntity where Enabled=true and DeptID=? ";
            //List<CheckedItemEntity> Result = Session.CreateQuery(hql)
            //                                    .SetInt32(0,DeptID)
            //                                    .SetFirstResult((pageIndex - 1) * pageSize)
            //                                    .SetMaxResults(pageSize)
            //                                    .List<CheckedItemEntity>().ToList<CheckedItemEntity>();
            var q = Session.Query<CheckedItemViewEntity>();
            q = q.Where(p => p.Enabled == true && p.DeptID==DeptID);
            List<CheckedItemViewEntity> Result = q.ToPagedList<CheckedItemViewEntity>(pageIndex, pageSize).ToList();
            RecordCount = q.Count();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取体检项目数据
        /// </summary>
        /// <param name="ItemID">体检项目编号</param> 
        /// <returns>体检项目实体</returns>
        public CheckedItemViewEntity GetCheckedItem(int ItemID) {
            CheckedItemViewEntity Result = Session.Get<CheckedItemViewEntity>(ItemID);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存体检项目数据
        /// </summary>
        /// <param name="CheckedItem">体检项目实体</param>   
        public void SaveCheckedItem(CheckedItemEntity CheckedItem) {
            if (CheckedItem.ItemID == int.MinValue) CheckedItem.ItemID = GetLineID("CheckedItem");
            CheckedItem.DisplayOrder = CheckedItem.ItemID;
            CheckedItem.Enabled = true;
            Session.SaveOrUpdate(CheckedItem);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除体检项目数据
        /// </summary>
        /// <param name="CheckedItem">体检项目实体</param>   
        public void DeleteCheckedItem(CheckedItemEntity CheckedItem) {
            CheckedItem.Enabled = false;
            Session.SaveOrUpdate(CheckedItem);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
