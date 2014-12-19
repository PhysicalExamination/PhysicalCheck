using System;
using System.Data;
using System.Collections.Generic;
using DataEntity.Examination;
using DataAccess.Examination;

namespace BusinessLogic.Examination {

    /// <summary>
    /// 业务逻辑类:ChargeBusiness
    /// 文  件  名:ChargeBusiness.cs
    /// 说      明:业务逻辑对象
    /// </summary>
    public class ChargeBusiness : BaseBusinessLogic<ChargeDataAccess> {

        #region 构造器

        public ChargeBusiness() {

        }

        #endregion

        #region 公共方法

        public List<ChargeViewEntity> GetCharges() {
            return DataAccess.GetCharges();
        }

        public ChargeViewEntity GetCharge(string BillNo) {
            return DataAccess.GetCharge(BillNo);
        }

        public void SaveCharge(ChargeEntity Charge) {
            DataAccess.SaveCharge(Charge);
        }

        public void DeleteCharge(ChargeEntity Charge) {
            DataAccess.DeleteCharge(Charge);
        }

        #endregion
    }
}
