using System;
using System.ComponentModel;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:DepartmentGroupEntity
    /// 文件名:DepartmentGroupEntity.cs
    /// 说  明:
    /// </summary>
    public class DepartmentGroupEntity {

        #region 构造方法

        public DepartmentGroupEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 主键 
        /// </summary>
        public virtual DepartmentGroupPK ID { get; set; }

        /// <summary>
        /// 分组名称
        /// </summary>		
        public virtual string GroupName {
            get;
            set;
        }

        /// <summary>
        /// 体检套餐
        /// </summary>	
        public virtual int? PackageID {
            set;
            get;
        }

        /// <summary>
        /// 性别
        /// </summary>		
        public virtual string Sex {
            get;
            set;
        }

        /// <summary>
        /// 是否儿童体检
        /// </summary>		
        public virtual bool? IsChildren {
            get;
            set;
        }

        /// <summary>
        /// 职称
        /// </summary>		
        public virtual string Duty {
            get;
            set;
        }

        /// <summary>
        /// 职务
        /// </summary>		
        public virtual string Position {
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

    public class DepartmentGroupPK {      

        /// <summary>
        /// 分组编号
        /// </summary>		
        public virtual int? GroupID {
            get;
            set;
        }

        /// <summary>
        /// 单位编号
        /// </summary>		
        public virtual int? DeptID {
            get;
            set;
        }

        public override bool Equals(object obj) {
            if (obj is DepartmentGroupPK) {
                DepartmentGroupPK pk = obj as DepartmentGroupPK;
                if (this.DeptID == pk.DeptID && this.GroupID == pk.GroupID) {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}