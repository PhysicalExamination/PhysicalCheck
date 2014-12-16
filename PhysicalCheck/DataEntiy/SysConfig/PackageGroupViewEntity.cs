using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.SysConfig {
    public class PackageGroupViewEntity:BaseEntity<PackageGroupViewEntity> {

        #region 构造方法

        public PackageGroupViewEntity() {
        }

        #endregion

        #region 属性

        public virtual PackageGroupPK ID {
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
        /// 组合名称
        /// </summary>		
        public virtual string GroupName {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual String Sex {
            get;
            set;
        }

        public virtual decimal? Price {
            get;
            set;
        }

        public virtual String Clinical {
            get;
            set;
        }

        /// <summary>
        /// 检查科室
        /// </summary>
        public virtual int? DeptID {
            get;
            set;
        }

        #endregion
    }
}
