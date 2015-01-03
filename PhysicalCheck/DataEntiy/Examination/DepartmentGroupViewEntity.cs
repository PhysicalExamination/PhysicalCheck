using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Examination {

    public class DepartmentGroupViewEntity {

        #region 构造方法

        public DepartmentGroupViewEntity() {
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

        /// <summary>
        /// 体检单位名称
        /// </summary>		
        public virtual string DeptName {
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
        /// 体检套餐名称
        /// </summary>		
        public virtual string PackageName {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual decimal? Price {
            get;
            set;
        }

        #endregion
    }
}
