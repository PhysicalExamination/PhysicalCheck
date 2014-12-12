using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:CommonResultEntity
    /// 文件名:CommonResultEntity.cs
    /// 说  明:常见体检结果
    /// </summary>
    public class CommonResultEntity:BaseEntity<CommonResultEntity> {

        #region 构造方法

        public CommonResultEntity() {
        }

        #endregion

        #region 属性

        public virtual CommonResultPK ID { get; set; }

        /// <summary>
        /// 结果名称
        /// </summary>		
        public virtual string ResultName {
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
        /// 是否阳性
        /// </summary>		
        public virtual bool? IsPositive {
            get;
            set;
        }

        /// <summary>
        /// 是否统计
        /// </summary>		
        public virtual bool? IsStatistic {
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

        #endregion
    }

    public class CommonResultPK {

        /// <summary>
        /// 体检项目
        /// </summary>		
        public virtual int? ItemID {
            get;
            set;
        }

        /// <summary>
        /// 结果编号
        /// </summary>		
        public virtual int? ResultID {
            get;
            set;
        }

        public override bool Equals(object obj) {
            if (obj is CommonResultPK) {
                CommonResultPK pk = obj as CommonResultPK;
                if (this.ItemID == pk.ItemID && this.ResultID == pk.ResultID) {
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