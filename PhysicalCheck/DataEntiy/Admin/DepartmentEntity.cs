using System;
using System.ComponentModel;

namespace DataEntity.Admin {
    /// <summary>
    /// 实体类:DepartmentEntity
    /// 文件名:DepartmentEntity.cs
    /// 说  明:检查科室
    /// </summary>
    public class DepartmentEntity:BaseEntity<DepartmentEntity> {

        #region 构造方法

        public DepartmentEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 科室编号
        /// </summary>		
        public virtual int? DeptID {
            get;
            set;
        }

        /// <summary>
        /// 科室名称
        /// </summary>		
        public virtual string DeptName {
            get;
            set;
        }

        /// <summary>
        /// 科室类别
        /// </summary>		
        public virtual string DeptKind {
            get;
            set;
        }

        /// <summary>
        /// 科室位置
        /// </summary>		
        public virtual string DepLlocation {
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