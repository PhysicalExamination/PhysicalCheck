using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:PackageGroupEntity
    /// 文件名:PackageGroupEntity.cs
    /// 说  明:套餐组合项目
    /// </summary>
    public class PackageGroupEntity:BaseEntity<PackageGroupEntity> {

        #region 构造方法

        public PackageGroupEntity() {
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

        #endregion
    }

    public class PackageGroupPK {

        /// <summary>
        /// 套餐编码
        /// </summary>		
        public virtual int? PackageID {
            get;
            set;
        }

        /// <summary>
        /// 组合编码
        /// </summary>		
        public virtual int? GroupID {
            get;
            set;
        }

        public override bool Equals(object obj) {
            if (obj is PackageGroupPK) {
                PackageGroupPK pk = obj as PackageGroupPK;
                if (this.PackageID == pk.PackageID && this.GroupID == pk.GroupID) {
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