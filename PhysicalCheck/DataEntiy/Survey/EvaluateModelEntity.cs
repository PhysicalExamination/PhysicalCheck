using System;
using System.ComponentModel;

namespace DataEntity.Survey {

    /// <summary>
    /// 实体类:EvaluateModelEntity
    /// 文件名:EvaluateModelEntity.cs
    /// 说  明:评估模型
    /// </summary>
    public class EvaluateModelEntity {

        #region 构造方法

        public EvaluateModelEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 模型编码
        /// </summary>
        [Description("ModelID")]
        public virtual int ModelID {
            get;
            set;
        }

        /// <summary>
        /// 模型名称
        /// </summary>
        [Description("ModelName")]
        public virtual string ModelName {
            get;
            set;
        }

        /// <summary>
        /// 病种
        /// </summary>
        [Description("Disease")]
        public virtual string Disease {
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

        #endregion
    }
}