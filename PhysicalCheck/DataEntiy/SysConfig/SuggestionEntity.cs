using System;
using System.ComponentModel;

namespace DataEntity.SysConfig {

    /// <summary>
    /// 实体类:SuggestionEntity
    /// 文件名:SuggestionEntity.cs
    /// 说  明:
    /// </summary>
    public class SuggestionEntity: BaseEntity<SuggestionEntity>{

        #region 构造方法

        public SuggestionEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 流水号
        /// </summary>		
        public virtual int? SNo {
            get;
            set;
        }

        /// <summary>
        /// 名称
        /// </summary>		
        public virtual string Name {
            get;
            set;
        }

        /// <summary>
        /// 关键字
        /// </summary>		
        public virtual string KeyWord {
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
        /// 建议
        /// </summary>		
        public virtual string Suggestion {
            get;
            set;
        }

        /// <summary>
        /// 说明
        /// </summary>		
        public virtual string Explain {
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
        /// 是否启用
        /// </summary>		
        public virtual bool? Enabled {
            get;
            set;
        }

        #endregion
    }
}