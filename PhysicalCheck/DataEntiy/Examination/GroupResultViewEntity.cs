using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Examination {

    /// <summary>
    /// 实体类:GroupResultViewEntity
    /// 文件名:GroupResultViewEntity.cs
    /// 说  明:体检组合项目结论视图
    /// </summary>
    public class GroupResultViewEntity : BaseEntity<GroupResultViewEntity> {

        #region 构造方法

        public GroupResultViewEntity() {
        }

        #endregion

        #region 属性


        public virtual GroupResultPK ID { get; set; }

        /// <summary>
        /// 组合项目名称
        /// </summary>		
        public virtual string GroupName {
            get;
            set;
        }

        /// <summary>
        /// 体检套餐
        /// </summary>		
        public virtual int? PackageID {
            get;
            set;
        }

        /// <summary>
        /// 体检套餐
        /// </summary>		
        public virtual string PackageName {
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

        /// <summary>
        /// 小结
        /// </summary>		
        public virtual string Summary {
            get;
            set;
        }

        /// <summary>
        /// 是否检查结束
        /// </summary>		
        public virtual bool IsOver {
            get;
            set;
        }

        /// <summary>
        ///是否合格
        /// </summary>
        public virtual bool IsPassed {
            get;
            set;
        }

        #endregion
    }
}
