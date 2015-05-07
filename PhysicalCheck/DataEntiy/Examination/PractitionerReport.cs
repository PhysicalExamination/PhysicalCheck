using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Examination {

    public class PractitionerReport {

        #region 构造器

        public PractitionerReport() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 档案号
        /// </summary>
        public virtual String RegisterNo {
            get;
            set;
        }

        /// <summary>
        /// 体检日期
        /// </summary>
        public virtual DateTime CheckDate {
            get;
            set;
        }

        /// <summary>
        /// 工作单位
        /// </summary>
        public virtual String WorkDept {
            get;
            set;
        }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual String Sex {
            get;
            set;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual String Name {
            get;
            set;
        }

        /// <summary>
        /// 照片
        /// </summary>
        public virtual String Photo {
            get;
            set;
        }

        /// <summary>
        /// 工种
        /// </summary>
        public virtual String TradeName {
            get;
            set;
        }

        /// <summary>
        /// 民族
        /// </summary>
        public virtual String Nation {
            get;
            set;
        }

        /// <summary>
        /// 年龄
        /// </summary>
        public virtual int? Age {
            get;
            set;
        }

        /// <summary>
        /// 既往病史肝炎
        /// </summary>
        public virtual String Hepatitis {
            get;
            set;
        }

        /// <summary>
        /// 既往病史痢疾
        /// </summary>
        public virtual String Dysentery {
            get;
            set;
        }

        /// <summary>
        /// 既往病史伤寒
        /// </summary>
        public virtual String TyphoidFever {
            get;
            set;
        }

        /// <summary>
        /// 既往病史肺结核
        /// </summary>
        public virtual String Pulmonary {
            get;
            set;
        }

        /// <summary>
        /// 既往病史皮肤
        /// </summary>
        public virtual String Skin {
            get;
            set;
        }

        /// <summary>
        /// 既往病史其他
        /// </summary>
        public virtual String Other {
            get;
            set;
        }

        /// <summary>
        /// 体征心
        /// </summary>
        public virtual String Heart {
            get;
            set;
        }

        /// <summary>
        /// 体征肝
        /// </summary>
        public virtual String Liver {
            get;
            set;
        }

        /// <summary>
        /// 体征脾
        /// </summary>
        public virtual String Spleen {
            get;
            set;
        }

        /// <summary>
        /// 体征肺
        /// </summary>
        public virtual String Lung {
            get;
            set;
        }

        /// <summary>
        /// 体征皮肤
        /// </summary>
        public virtual String SignSkin {
            get;
            set;
        }

        /// <summary>
        /// 体征其他
        /// </summary>
        public virtual String SignOther {
            get;
            set;
        }

        /// <summary>
        /// X线胸透或胸部拍片
        /// </summary>
        public virtual String XLine {
            get;
            set;
        }

        /// <summary>
        /// 痢疾杆菌
        /// </summary>
        public virtual String DysenteryBacillus {
            get;
            set;
        }

        /// <summary>
        /// 伤寒或副伤寒
        /// </summary>
        public virtual String LibTyphoidFever {
            get;
            set;
        }

        /// <summary>
        /// HAVIgm
        /// </summary>
        public virtual String HAV {
            get;
            set;
        }

        /// <summary>
        /// HEVIgm
        /// </summary>
        public virtual String HEV {
            get;
            set;
        }

        /// <summary>
        /// 其他
        /// </summary>
        public virtual String LibOther {
            get;
            set;
        }

        /// <summary>
        /// 结论
        /// </summary>
        public virtual String Conclusion {
            get;
            set;
        }

        /// <summary>
        /// 经办人
        /// </summary>
        public virtual String CheckDoctor {
            get;
            set;
        }

        /// <summary>
        /// 经办日期
        /// </summary>
        public virtual DateTime? OverCheckedDate {
            get;
            set;
        }
     
        #endregion
    }
}
