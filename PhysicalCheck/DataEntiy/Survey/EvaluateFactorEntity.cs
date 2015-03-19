using System;
using System.ComponentModel;

namespace DataEntity.Survey {
    /// <summary>
    /// 实体类:EvaluateFactorEntity
    /// 文件名:EvaluateFactorEntity.cs
    /// 说  明:
    /// </summary>
    public class EvaluateFactorEntity {

        #region 构造方法

        public EvaluateFactorEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 因素编码
        /// </summary>
        [Description("EID")]
        public virtual int EID {
            get;
            set;
        }

        /// <summary>
        /// 因素名称
        /// </summary>
        [Description("FactorName")]
        public virtual string FactorName {
            get;
            set;
        }

        /// <summary>
        /// 系数
        /// </summary>
        [Description("FactorRate")]
        public virtual double FactorRate {
            get;
            set;
        }

        /// <summary>
        /// 临界值
        /// </summary>
        [Description("CriticalValue")]
        public virtual int CriticalValue {
            get;
            set;
        }

        /// <summary>
        /// 临床意义
        /// </summary>
        [Description("Medicine")]
        public virtual string Medicine {
            get;
            set;
        }

        /// <summary>
        /// 建议
        /// </summary>
        [Description("Suggestion")]
        public virtual string Suggestion {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("Enabled")]
        public virtual bool Enabled {
            get;
            set;
        }

        #endregion
    }
}