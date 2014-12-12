using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.SysConfig;

namespace DataAccess.SysConfig {

    /// <summary>
    /// 医院信息数据访问对象
    /// </summary>
    public class HospitalDataAccess:BaseDataAccess<HospitalEntity> {

        #region 构造器

        public HospitalDataAccess() {
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 返回医院信息
        /// </summary>
        /// <param name="HospitalID">医院编号</param>
        /// <returns></returns>
        public HospitalEntity GetHospital(int HospitalID) {
            HospitalEntity Result = Session.Get<HospitalEntity>(HospitalID);
            CloseSession();
            return Result;
        }

        public void SaveHospital(HospitalEntity Hospital) {
            if (Hospital.HospitalID == int.MinValue) Hospital.HospitalID = GetLineID("Hospital");
            Session.SaveOrUpdate(Hospital);
            Session.Flush();
            CloseSession();
        }

        #endregion

    }
}
