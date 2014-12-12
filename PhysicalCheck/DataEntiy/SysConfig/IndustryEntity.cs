using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:IndustryEntity
    /// 文件名:IndustryEntity.cs
    /// 说  明:健康行业
    /// </summary>
    public class IndustryEntity:BaseEntity<IndustryEntity> {

        #region 构造方法

        public IndustryEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 行业编号
        /// </summary>		
        public virtual int? IndustryID {
            get;
            set;
        }

        /// <summary>
        /// 行业名称
        /// </summary>		
        public virtual string IndustryName {
            get;
            set;
        }

        /// <summary>
        /// 有效期
        /// </summary>		
        public virtual int? Validity {
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