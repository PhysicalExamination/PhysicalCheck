using System;
using System.ComponentModel;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:ChargeViewEntity
    /// 文件名:ChargeViewEntity.cs
    /// 说  明:
    /// </summary>
    public class ChargeViewEntity {

        #region 构造方法

        public ChargeViewEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 缴费单号
        /// </summary>
        [Description("BillNo")]
        public virtual string BillNo {
            get;
            set;
        }

        /// <summary>
        /// 缴费单位编号
        /// </summary>
        [Description("ChargeDeptID")]
        public virtual int? ChargeDeptID {
            get;
            set;
        }

        /// <summary>
        /// 缴费单位或个人
        /// </summary>
        [Description("Payer")]
        public virtual string Payer {
            get;
            set;
        }

        /// <summary>
        /// 体检套餐
        /// </summary>
        [Description("PackageID")]
        public virtual int? PackageID {
            get;
            set;
        }

        /// <summary>
        /// 体检套餐
        /// </summary>
        [Description("PackageName")]
        public virtual String PackageName {
            get;
            set;
        }

        /// <summary>
        /// 体检人数
        /// </summary>
        [Description("CheckNum")]
        public virtual int? CheckNum {
            get;
            set;
        }

        /// <summary>
        /// 已体检人数
        /// </summary>
        [Description("CheckedCount")]
        public virtual int CheckedCount {
            get;
            set;
        }

        /// <summary>
        /// 应收费用
        /// </summary>
        [Description("Charge")]
        public virtual decimal? Charge {
            get;
            set;
        }

        /// <summary>
        /// 实收费用
        /// </summary>
        [Description("ActualCharge")]
        public virtual decimal? ActualCharge {
            get;
            set;
        }

        /// <summary>
        /// 缴费方式
        /// </summary>
        [Description("PaymentMethod")]
        public virtual string PaymentMethod {
            get;
            set;
        }

        /// <summary>
        /// 缴费时间
        /// </summary>
        [Description("PaymentDate")]
        public virtual DateTime? PaymentDate {
            get;
            set;
        }

        /// <summary>
        /// 收费人
        /// </summary>
        [Description("ChargePerson")]
        public virtual string ChargePerson {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("Enabled")]
        public virtual bool? Enabled {
            get;
            set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual String Address {
            get;
            set;
        }

        /// <summary>
        /// 所在地区
        /// </summary>
        public virtual String RegionCode {
            get;
            set;
        }

        /// <summary>
        /// 所在地区
        /// </summary>
        public virtual String RegionName {
            get;
            set;
        }
        #endregion
    }
}