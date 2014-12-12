using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.SysConfig {

    public class ItemGroupDetailViewEntity : BaseEntity<ItemGroupDetailViewEntity> {

        #region 构造方法

        public ItemGroupDetailViewEntity() {

        }

        #endregion

        #region 属性

        public virtual ItemGroupDetailPK ID { get; set; }

        /// <summary>
        /// 组合名称
        /// </summary>		
        public virtual string GroupName {
            get;
            set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>		
        public virtual string ItemName {
            get;
            set;
        }

        /// <summary>
        /// 计量单位
        /// </summary>		
        public virtual string MeasureUnit {
            get;
            set;
        }

        /// <summary>
        /// 参考下限
        /// </summary>		
        public virtual string LowerLimit {
            get;
            set;
        }

        /// <summary>
        /// 参考上限
        /// </summary>		
        public virtual string UpperLimit {
            get;
            set;
        }

        /// <summary>
        /// 正常提示
        /// </summary>		
        public virtual string NormalTips {
            get;
            set;
        }

        #endregion
    }
}
