﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using DataEntity.Examination;

namespace DataAccess.Examination {

    /// <summary>
    /// 数据访问类:ChargeDataAccess
    /// 文  件  名:ChargeDataAccess.cs
    /// 说      明:数据访问对象
    /// </summary>
    public class ChargeDataAccess : BaseDataAccess<ChargeEntity> {

        #region 构造器

        public ChargeDataAccess() {

        }

        #endregion

        #region 公共方法

        /// <summary>
        ///获取所有数据
        /// </summary>
        public List<ChargeViewEntity> GetCharges() {
            var q = from p in Session.Query<ChargeViewEntity>()
                    where p.Enabled == true
                    select p;
            List<ChargeViewEntity> Result = q.ToList<ChargeViewEntity>();
            CloseSession();
            return Result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="BillNo"></param> 
        /// <returns>实体</returns>
        public ChargeViewEntity GetCharge(string BillNo) {
            ChargeViewEntity Result = Session.Get<ChargeViewEntity>(BillNo);
            CloseSession();
            return Result;

        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="Charge">实体</param>
        public void SaveCharge(ChargeEntity Charge) {
            if (String.IsNullOrEmpty(Charge.BillNo)) Charge.BillNo = GetBillNo("Charge");
            Charge.Enabled = true;
            Session.SaveOrUpdate(Charge);
            Session.Flush();
            CloseSession();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="Charge">实体</param>
        public void DeleteCharge(ChargeEntity Charge) {
            Charge.Enabled = false;
            Session.SaveOrUpdate(Charge);
            Session.Flush();
            CloseSession();
        }

        #endregion
    }
}