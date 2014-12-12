using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataEntity.SysConfig;
using DataAccess.SysConfig;

namespace BusinessLogic.SysConfig {

    /// <summary>
    /// 业务逻辑类:HospitalBusiness
    /// 文  件  名:HospitalBusiness.cs
    /// 说      明:医院信息业务逻辑对象
    /// </summary>
    public class HospitalBusiness : BaseBusinessLogic<HospitalDataAccess> {

        #region 构造器

        public HospitalBusiness() {

        }

        #endregion

        #region 公共方法      

        public HospitalEntity GetHospital(int HospitalID) {
            return DataAccess.GetHospital(HospitalID);
        }

        public void SaveHospital(HospitalEntity Hospital) {
            DataAccess.SaveHospital(Hospital);
        }       

        #endregion
    }
}
