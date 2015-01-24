using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:ItemGroupEntity
    /// 文件名:ItemGroupEntity.cs
    /// 说  明:组合项目
    /// </summary>
    public class ItemGroupEntity :BaseEntity<ItemGroupEntity>{

        #region 构造方法

        public ItemGroupEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 组合编号
        /// </summary>		
        public virtual int? GroupID {
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

        /// <summary>
        /// 检查科室
        /// </summary>		
        public virtual int? DeptID {
            get;
            set;
        }

        /// <summary>
        /// 检查类别
        /// </summary>		
        public virtual string CheckCategory {
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
        /// 单价
        /// </summary>		
        public virtual decimal? Price {
            get;
            set;
        }

        /// <summary>
        /// 提示信息
        /// </summary>		
        public virtual string Notice {
            get;
            set;
        }

        /// <summary>
        /// 临床意义
        /// </summary>		
        public virtual string Clinical {
            get;
            set;
        }

        /// <summary>
        /// 正常描述
        /// </summary>		
        public virtual string NormalDesc {
            get;
            set;
        }

        /// <summary>
        /// 是否需要标本
        /// </summary>		
        public virtual bool? HasSpecimen {
            get;
            set;
        }

        /// <summary>
        /// 标本类型
        /// </summary>		
        public virtual string Specimen {
            get;
            set;
        }

        /// <summary>
        /// 结果获取方式
        /// </summary>		
        public virtual string ResultMode {
            get;
            set;
        }

        /// <summary>
        /// 显示顺序
        /// </summary>		
        public virtual int? DisplayOrder {
            get;
            set;
        }

        /// <summary>
        /// 是否需要条码
        /// </summary>
        public virtual bool? HasBarCode {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>		
        public virtual bool Enabled {
            get;
            set;
        }

        #endregion
    }
}