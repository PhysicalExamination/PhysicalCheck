using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:SysParameterEntity
    /// 文件名:SysParameterEntity.cs
    /// 说  明:系统参数
    /// </summary>
    public class SysParameterEntity {

        #region 构造方法

        public SysParameterEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 参数名称
        /// </summary>		
        public virtual string ParameterName {
            get;
            set;
        }

        /// <summary>
        /// 参数值
        /// </summary>		
        public virtual string ParameterValue {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>		
        public virtual bool Enabled {
            get;
            set;
        }

        #endregion
    }
}