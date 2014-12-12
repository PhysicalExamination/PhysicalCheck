using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:CommonCodeEntity
    /// 文件名:CommonCodeEntity.cs
    /// 说  明:公共代码
    /// </summary>
    public class CommonCodeEntity:BaseEntity<CommonCodeEntity> {

        #region 构造方法

        public CommonCodeEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 代码
        /// </summary>		
        public virtual string Code {
            get;
            set;
        }

        /// <summary>
        /// 名称
        /// </summary>		
        public virtual string Name {
            get;
            set;
        }

        /// <summary>
        /// 类别
        /// </summary>		
        public virtual string Category {
            get;
            set;
        }

        #endregion
    }
}