using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:ItemResultViewEntity
    /// 文件名:ItemResultViewEntity.cs
    /// 说  明:体检项目结论
    /// </summary>
    public class ItemResultViewEntity : BaseEntity<ItemResultViewEntity> {

        #region 构造方法

        public ItemResultViewEntity() {
        }

        #endregion

        #region 属性

        public virtual ItemResultPK ID { get; set; }

        /// <summary>
        /// 检查项目名称
        /// </summary>		
        public virtual string ItemName {
            get;
            set;
        }

        /// <summary>
        /// 组合项目名称
        /// </summary>		
        public virtual string GroupName {
            get;
            set;
        }


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
        /// 检查科室名称
        /// </summary>		
        public virtual string DeptName {
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

        #endregion
    }
}
