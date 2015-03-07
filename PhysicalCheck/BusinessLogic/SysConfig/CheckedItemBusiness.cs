using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.SysConfig;
using DataAccess.SysConfig;

namespace BusinessLogic.SysConfig {


    /// <summary>
    /// 业务逻辑类:CheckedItemBusiness
    /// 文  件  名:CheckedItemBusiness.cs
    /// 说      明:体检项目业务逻辑对象
    /// </summary>
    public class CheckedItemBusiness : BaseBusinessLogic<CheckedItemDataAccess> {

        #region 构造器

        public CheckedItemBusiness() {

        }

        #endregion

        #region 公共方法

        public List<CheckedItemEntity> GetCheckedItems() {
            return DataAccess.GetCheckedItems();
        }

        public List<CheckedItemEntity> GetCheckedItems(int pageIndex, int pageSize,
            int DeptID, out int RecordCount) {
            return DataAccess.GetCheckedItems(pageIndex, pageSize, DeptID, out RecordCount);
        }

        public CheckedItemEntity GetCheckedItem(int ItemID) {
            return DataAccess.GetCheckedItem(ItemID);
        }

        public void SaveCheckedItem(CheckedItemEntity CheckedItem) {
            DataAccess.SaveCheckedItem(CheckedItem);
            if (!String.IsNullOrWhiteSpace(CheckedItem.LISCode)) {
                String[] LisCodes = CheckedItem.LISCode.Split(',');
                using (LISMapDataAccess LISMapDataAccess = new LISMapDataAccess()) {
                    LisMapEntity LisMap = new LisMapEntity {
                        Itemid = CheckedItem.ItemID.Value,
                        ItemName = CheckedItem.ItemName
                    };
                    if (LisCodes.Length == 1) LisMap.LisItemId1 = LisCodes[0];
                    if (LisCodes.Length == 2) {
                        LisMap.LisItemId1 = LisCodes[0];
                        LisMap.LisItemId2 = LisCodes[1];
                    }
                    LISMapDataAccess.SaveLISMap(LisMap);
                }
            }
        }

        public void DeleteCheckedItem(CheckedItemEntity CheckedItem) {
            DataAccess.DeleteCheckedItem(CheckedItem);
        }

        #endregion
    }
}
