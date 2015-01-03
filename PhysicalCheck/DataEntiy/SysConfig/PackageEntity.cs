using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:PackageEntity
    /// 文件名:PackageEntity.cs
    /// 说  明:体检套餐
    /// </summary>
    public class PackageEntity:BaseEntity<PackageEntity> {

        #region 构造方法

        public PackageEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 套餐编号
        /// </summary>		
        public virtual int? PackageID {
            get;
            set;
        }

        /// <summary>
        /// 套餐名称
        /// </summary>		
        public virtual string PackageName {
            get;
            set;
        }

        /// <summary>
        /// 套餐单价
        /// </summary>		
        public virtual decimal? Price {
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

        /// <summary>
        /// 显示顺序
        /// </summary>		
        public virtual int? DisplayOrder {
            get;
            set;
        }

        public virtual bool Enabled {
            get;
            set;
        }

        #endregion
    }
}