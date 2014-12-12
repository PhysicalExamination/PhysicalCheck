using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.SysConfig;
using DataAccess.SysConfig;

namespace BusinessLogic.SysConfig {

    /// <summary>
    /// 业务逻辑类:IndustryBusiness
    /// 文  件  名:IndustryBusiness.cs
    /// 说      明:健康行业业务逻辑对象
    /// </summary>
    public class IndustryBusiness : BaseBusinessLogic<IndustryDataAccess> {

        #region 构造器

        public IndustryBusiness() {

        }

        #endregion

        #region 公共方法

        public List<IndustryEntity> GetIndustrys() {
            return DataAccess.GetIndustrys();
        }

        public IndustryEntity GetIndustry(int IndustryID) {
            return DataAccess.GetIndustry(IndustryID);
        }

        public void SaveIndustry(IndustryEntity Industry) {
            DataAccess.SaveIndustry(Industry);
        }

        public void DeleteIndustry(IndustryEntity Industry) {
            DataAccess.DeleteIndustry(Industry);
        }

        #endregion
    }
}
