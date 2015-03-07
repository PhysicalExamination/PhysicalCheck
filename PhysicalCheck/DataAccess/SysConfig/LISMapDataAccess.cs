using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {

    /// <summary>
    /// 体检项与LIS对照数据访问对象
    /// </summary>
    public class LISMapDataAccess : BaseDataAccess<LisMapEntity> {

        #region 构造器

        public LISMapDataAccess() {
        }

        #endregion

        #region 公共方法

        public List<LisMapEntity> GetLISMaps() {
            var q = Session.Query<LisMapEntity>();
            List<LisMapEntity> Result = q.ToList();
            CloseSession();
            return Result;
        }

        public LisMapEntity GetLISMap(int ItemID) {
            LisMapEntity Result = Session.Get<LisMapEntity>(ItemID);
            CloseSession();
            return Result;
        }

        public void SaveLISMap(LisMapEntity LISMap) {
            Session.SaveOrUpdate(LISMap);
            Session.Flush();
            CloseSession();
        }
        #endregion
    }
}
