using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.SysConfig;
using DataAccess.SysConfig;

namespace BusinessLogic.SysConfig {

    /// <summary>
    /// 业务逻辑类:ItemGroupBusiness
    /// 文  件  名:ItemGroupBusiness.cs
    /// 说      明:组合项目业务逻辑对象
    /// </summary>
    public class ItemGroupBusiness : BaseBusinessLogic<ItemGroupDataAccess> {

        #region 私有成员

        private ItemGroupDetailDataAccess m_ItemGroupDetail;

        #endregion

        #region 构造器

        public ItemGroupBusiness() {
            m_ItemGroupDetail = new ItemGroupDetailDataAccess();
        }

        #endregion

        #region 公共方法

        public IList<ItemGroupViewEntity> GetItemGroups(int DeptID) {
            return DataAccess.GetItemGroups(DeptID);
        }

        public List<ItemGroupViewEntity> GetItemGroups(int pageIndex, int pageSize, out int RecordCount) {
            return DataAccess.GetItemGroups(pageIndex, pageSize, out RecordCount);
        }

        public List<ItemGroupViewEntity> GetItemGroups(int pageIndex, int pageSize, String GroupName,
            out int RecordCount) {
            return DataAccess.GetItemGroups(pageIndex, pageSize, GroupName, out RecordCount);
        }

        public ItemGroupViewEntity GetItemGroup(int GroupID) {
            return DataAccess.GetItemGroup(GroupID);
        }

        public void SaveItemGroup(ItemGroupEntity ItemGroup) {
            DataAccess.SaveItemGroup(ItemGroup);
        }

        public void DeleteItemGroup(ItemGroupEntity ItemGroup) {
            DataAccess.DeleteItemGroup(ItemGroup);
            //GetItemGroupDetails(ItemGroup.GroupID.Value);
        }

        #endregion

        #region 组合项目明细

        public List<ItemGroupDetailViewEntity> GetItemGroupDetails(int GroupID) {
            return m_ItemGroupDetail.GetItemGroupDetails(GroupID);
        }

        public List<ItemGroupDetailViewEntity> GetItemGroupDetails(int pageIndex, int pageSize,
            int GroupID, out int RecordCount) {
            return m_ItemGroupDetail.GetItemGroupDetails(pageIndex, pageSize, GroupID, out RecordCount);
        }

        public ItemGroupDetailViewEntity GetItemGroupDetail(int GroupID, int ItemID) {
            return m_ItemGroupDetail.GetItemGroupDetail(GroupID, ItemID);
        }

        public void SaveItemGroupDetail(ItemGroupDetailEntity ItemGroupDetail) {
            m_ItemGroupDetail.SaveItemGroupDetail(ItemGroupDetail);
        }

        public void DeleteItemGroupDetail(ItemGroupDetailEntity ItemGroupDetail) {
            m_ItemGroupDetail.DeleteItemGroupDetail(ItemGroupDetail);
        }
        #endregion
    }
}
