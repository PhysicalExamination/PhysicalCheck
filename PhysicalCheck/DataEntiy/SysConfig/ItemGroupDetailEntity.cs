using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:ItemGroupDetailEntity
    /// 文件名:ItemGroupDetailEntity.cs
    /// 说  明:组合项目明细
    /// </summary>
    public class ItemGroupDetailEntity:BaseEntity<ItemGroupDetailEntity> {

        #region 构造方法

        public ItemGroupDetailEntity() {

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

        #endregion
    }

    public class ItemGroupDetailPK {

        /// <summary>
        /// 组合编码
        /// </summary>		
        public virtual int? GroupID {
            get;
            set;
        }

        /// <summary>
        /// 项目编码
        /// </summary>		
        public virtual int? ItemID {
            get;
            set;
        }

        public override bool Equals(object obj) {
            if (obj is ItemGroupDetailPK) {
                ItemGroupDetailPK pk = obj as ItemGroupDetailPK;
                if (this.ItemID == pk.ItemID && this.GroupID == pk.GroupID) {
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