using System;
using System.ComponentModel;

namespace DataEntity.Examination {
    /// <summary>
    /// 实体类:RegistrationEntity
    /// 文件名:RegistrationEntity.cs
    /// 说  明:体检登记
    /// </summary>
    public class RegistrationEntity:BaseEntity<RegistrationEntity> {

        #region 构造方法

        public RegistrationEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 体检人
        /// </summary>		
        public virtual int? PersonID {
            get;
            set;
        }

        /// <summary>
        /// 登记号
        /// </summary>		
        public virtual string RegisterNo {
            get;
            set;
        }

        /// <summary>
        /// 登记日期
        /// </summary>		
        public virtual DateTime? RegisterDate {
            get;
            set;
        }

        /// <summary>
        /// 套餐
        /// </summary>		
        public virtual int? PackageID {
            get;
            set;
        }

        /// <summary>
        /// 体检日期
        /// </summary>		
        public virtual DateTime? CheckDate {
            get;
            set;
        }

        /// <summary>
        /// 体检综述
        /// </summary>		
        public virtual string Summary {
            get;
            set;
        }

        /// <summary>
        /// 医生建议
        /// </summary>		
        public virtual string Recommend {
            get;
            set;
        }

        /// <summary>
        /// 总检医生
        /// </summary>		
        public virtual string OverallDoctor {
            get;
            set;
        }

        /// <summary>
        /// 总检日期
        /// </summary>		
        public virtual DateTime? OverallDate {
            get;
            set;
        }

        /// <summary>
        /// 总检结论
        /// </summary>		
        public virtual string Conclusion {
            get;
            set;
        }

        /// <summary>
        /// 办理健康证条件
        /// </summary>		
        public virtual string HealthCondition {
            get;
            set;
        }

        /// <summary>
        /// 职业能力评定
        /// </summary>		
        public virtual string EvaluateResult {
            get;
            set;
        }

        /// <summary>
        /// 体检是否结束
        /// </summary>		
        public virtual bool IsCheckOver {
            get;
            set;
        }

        /// <summary>
        /// 体检报告打印日期
        /// </summary>		
        public virtual DateTime? PrintDate {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>		
        public virtual bool? Enabled {
            get;
            set;
        }

        #endregion
    }
   
}