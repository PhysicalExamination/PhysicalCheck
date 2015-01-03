using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.SysConfig;
using NHibernate;
using NHibernate.Linq;

namespace DataAccess.SysConfig {
    /// <summary>
    /// 数据访问类:RegionDataAccess
    /// 文  件  名:RegionDataAccess.cs
    /// 说      明:地区代码数据访问对象
    /// </summary>
    public class RegionDataAccess : BaseDataAccess<RegionEntity> {

        #region 构造器

        public RegionDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取指定地区所有数据
        /// </summary>
        public List<RegionEntity> GetRegions(String ParentCode) {
            var q = from p in Session.Query<RegionEntity>()
                    where p.ParentNode == ParentCode
                    select p;
            List<RegionEntity> Result = q.ToList<RegionEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取地区代码数据
        /// </summary>
        /// <param name="RegionCode"></param> 
        /// <returns>地区代码实体</returns>
        public RegionEntity GetRegion(string RegionCode) {
            RegionEntity Result = Session.Get<RegionEntity>(RegionCode);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存地区代码数据
        /// </summary>
        /// <param name="region">地区代码实体</param>
        public void SaveRegion(RegionEntity region) {
            //if (region.RegionCode == null) region.RegionCode = GetLineID("region");
            Session.SaveOrUpdate(region);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除地区代码数据
        /// </summary>
        /// <param name="region">地区代码实体</param>
        public void DeleteRegion(RegionEntity region) {
            Session.Delete(region);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}
