using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:DepartmentPackageViewEntity
    /// 文件名:DepartmentPackageViewEntity.cs
    /// 说  明:体检单位分组套餐明细
    /// </summary>
    public class DepartmentPackageViewEntity:BaseEntity<DepartmentPackageEntity> {

        #region 构造方法

        public DepartmentPackageViewEntity() {
        }

        #endregion

        #region 属性

        public virtual DepartmentPackagePK ID { get; set; }

        /// <summary>
        /// 工作单位名称
        /// </summary>		
        public virtual string DeptName {
            get;
            set;
        }

        /// <summary>
        /// 组合项目名称
        /// </summary>		
        public virtual string GroupName {
            get;
            set;
        }

        /// <summary>
        /// 检查项目名称
        /// </summary>		
        public virtual string ItemName {
            get;
            set;
        }

        /// <summary>
        /// 项目类别
        /// </summary>		
        public virtual string Category {
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
