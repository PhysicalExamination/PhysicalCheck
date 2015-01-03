using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SysConfig;
using DataEntity.SysConfig;

namespace BusinessLogic.SysConfig {

    public class RegionBusiness:BaseBusinessLogic<RegionDataAccess> {

        #region 构造器

        public RegionBusiness() {
        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取指定地区所有数据
        /// </summary>
        public List<RegionEntity> GetRegions(String ParentCode) {
            return DataAccess.GetRegions(ParentCode);
        }

        /// <summary>
        /// 获取地区代码数据
        /// </summary>
        /// <param name="RegionCode"></param> 
        /// <returns>地区代码实体</returns>
        public RegionEntity GetRegion(string RegionCode) {
            return DataAccess.GetRegion(RegionCode);
        }

        /// <summary>
        /// 保存地区代码数据
        /// </summary>
        /// <param name="region">地区代码实体</param>
        public void SaveRegion(RegionEntity region) {
            DataAccess.SaveRegion(region);
        }

         /// <summary>
        /// 删除地区代码数据
        /// </summary>
        /// <param name="region">地区代码实体</param>
        public void DeleteRegion(RegionEntity region) {
            DataAccess.DeleteRegion(region);
        }
        #endregion
    }
}
