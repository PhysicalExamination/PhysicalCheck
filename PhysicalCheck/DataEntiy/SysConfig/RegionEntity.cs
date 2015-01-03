using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    public class RegionEntity : BaseEntity<RegionEntity> {

        #region 构造方法

        public RegionEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 
        /// </summary>
        [Description("RegionCode")]
        public virtual string RegionCode {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("RegionName")]
        public virtual string RegionName {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("ParentNode")]
        public virtual string ParentNode {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("Comment")]
        public virtual string Comment {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("Spell")]
        public virtual string Spell {
            get;
            set;
        }

        #endregion
    }
}
