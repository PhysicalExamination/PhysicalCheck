using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.SysConfig;
using DataEntity.SysConfig;

namespace BusinessLogic.SysConfig {

    public class LISMapBusiness:BaseBusinessLogic<LISMapDataAccess> {

        #region 构造器

        public LISMapBusiness() {
        }

        #endregion

        #region 构造器

        public List<LisMapEntity> GetLISMaps() {
            return DataAccess.GetLISMaps();
        }

        public LisMapEntity GetLISMap(int ItemID) {
            return DataAccess.GetLISMap(ItemID);
        }

        public void SaveLISMap(LisMapEntity LISMap) {
            DataAccess.SaveLISMap(LISMap);
        }

        #endregion
    }
}
