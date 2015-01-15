using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 体检项目
    /// </summary>
    public class CheckedItemEntity : BaseEntity<CheckedItemEntity> {

        #region 构造方法

        public CheckedItemEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 项目编号
        /// </summary>		
        public virtual int? ItemID {
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
        /// 体检科室
        /// </summary>		
        public virtual int? DeptID {
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

        /// <summary>
        /// 偏低提示
        /// </summary>		
        public virtual string LowerTips {
            get;
            set;
        }

        /// <summary>
        /// 偏高提示
        /// </summary>		
        public virtual string UpperTips {
            get;
            set;
        }

        /// <summary>
        /// 适用性别
        /// </summary>		
        public virtual string Sex {
            get;
            set;
        }

        /// <summary>
        /// 最大值
        /// </summary>		
        public virtual decimal? MaxValue {
            get;
            set;
        }

        /// <summary>
        /// 最小值
        /// </summary>		
        public virtual decimal? MinValue {
            get;
            set;
        }

        /// <summary>
        /// 是否入小结
        /// </summary>		
        public virtual bool? IsSummary {
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
        /// 显示序号
        /// </summary>
        public virtual int? DisplayOrder {
            get;
            set;
        }

        #endregion
    }
}
