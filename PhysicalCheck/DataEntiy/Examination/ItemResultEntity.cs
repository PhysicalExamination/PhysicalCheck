using System;
using System.ComponentModel;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:ItemResultEntity
    /// 文件名:ItemResultEntity.cs
    /// 说  明:体检项目结论
    /// </summary>
    public class ItemResultEntity :BaseEntity<ItemResultEntity>{

        #region 构造方法

        public ItemResultEntity() {
        }

        #endregion

        #region 属性

        public virtual ItemResultPK ID { get; set; }

        /// <summary>
        /// 检查结果
        /// </summary>		
        public virtual string CheckedResult {
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

        /// <summary>
        /// 检查医生
        /// </summary>		
        public virtual string CheckDoctor {
            get;
            set;
        }

        /// <summary>
        /// 检查日期
        /// </summary>		
        public virtual DateTime? CheckDate {
            get;
            set;
        }

        /// <summary>
        /// 定性结论
        /// </summary>
        public virtual String QualitativeResult {
            get;
            set;
        }

        #endregion
    }

    public class ItemResultPK {

        /// <summary>
        /// 登记号
        /// </summary>		
        public virtual string RegisterNo {
            get;
            set;
        }

        /// <summary>
        /// 组合项目编号
        /// </summary>		
        public virtual int? GroupID {
            get;
            set;
        }

        /// <summary>
        /// 项目编号
        /// </summary>		
        public virtual int? ItemID {
            get;
            set;
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}