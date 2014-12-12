using System;
using System.ComponentModel;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:DepartmentPackageEntity
    /// 文件名:DepartmentPackageEntity.cs
    /// 说  明:单位分组套餐明细
    /// </summary>
    public class DepartmentPackageEntity:BaseEntity<DepartmentPackageEntity> {

        #region 构造方法

        public DepartmentPackageEntity() {
        }

        #endregion

        #region 属性

        public virtual DepartmentPackagePK ID { get; set; }

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

    public class DepartmentPackagePK {

        /// <summary>
        /// 单位编号
        /// </summary>		
        public virtual int? DeptID {
            get;
            set;
        }

        /// <summary>
        /// 分组编号
        /// </summary>		
        public virtual int? DeptGorupID {
            get;
            set;
        }

        /// <summary>
        /// 体检项目
        /// </summary>		
        public virtual int? ItemID {
            get;
            set;
        }

        public override bool Equals(object obj) {
            if (obj is DepartmentPackagePK) {
                DepartmentPackagePK PK = obj as DepartmentPackagePK;
                if (this.DeptGorupID == PK.DeptGorupID && this.DeptID == PK.DeptID && this.ItemID == PK.ItemID)
                    return true;
            }
            return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}