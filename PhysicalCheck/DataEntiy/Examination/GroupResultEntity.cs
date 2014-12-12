using System;
using System.ComponentModel;

namespace DataEntity.Examination {
   
    /// <summary>
    /// 实体类:GrouprResultEntity
    /// 文件名:GrouprResultEntity.cs
    /// 说  明:体检组合项目结论
    /// </summary>
    public class GroupResultEntity :BaseEntity<GroupResultEntity>{

        #region 构造方法

        public GroupResultEntity() {
        }

        #endregion

        #region 属性


        public virtual GroupResultPK ID { get; set; }
        

        /// <summary>
        /// 体检套餐
        /// </summary>		
        public virtual int? PackageID {
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

        #endregion
    }

    public class GroupResultPK {

        /// <summary>
        /// 登记号
        /// </summary>		
        public virtual string RegisterNo {
            get;
            set;
        }

        /// <summary>
        /// 组合项目
        /// </summary>		
        public virtual int? GroupID {
            get;
            set;
        }
        public override bool Equals(object obj) {
            if (obj is GroupResultPK) {
                GroupResultPK pk = obj as GroupResultPK;
                if (this.RegisterNo == pk.RegisterNo && this.GroupID == pk.GroupID) {
                    return true;
                }
            }
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}