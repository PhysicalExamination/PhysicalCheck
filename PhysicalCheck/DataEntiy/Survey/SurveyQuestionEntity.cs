using System;
using System.ComponentModel;

namespace DataEntity.Survey {
    /// <summary>
    /// 实体类:SurveyQuestionEntity
    /// 文件名:SurveyQuestionEntity.cs
    /// 说  明:调查问卷
    /// </summary>
    public class SurveyQuestionEntity {

        #region 构造方法

        public SurveyQuestionEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 问题编码
        /// </summary>
        [Description("QID")]
        public virtual int QID {
            get;
            set;
        }

        /// <summary>
        /// 标题
        /// </summary>
        [Description("Title")]
        public virtual string Title {
            get;
            set;
        }

        /// <summary>
        /// 描述
        /// </summary>
        [Description("Description")]
        public virtual string Description {
            get;
            set;
        }

        /// <summary>
        /// 是否必填
        /// </summary>
        [Description("Required")]
        public virtual bool Required {
            get;
            set;
        }

        /// <summary>
        /// 题型
        /// </summary>
        [Description("QType")]
        public virtual string QType {
            get;
            set;
        }

        /// <summary>
        /// 是否多选
        /// </summary>
        [Description("Multipe")]
        public virtual bool Multipe {
            get;
            set;
        }

        /// <summary>
        /// 正常下限
        /// </summary>
        [Description("NormalLower")]
        public virtual string NormalLower {
            get;
            set;
        }

        /// <summary>
        /// 正常上限
        /// </summary>
        [Description("NormalUpper")]
        public virtual string NormalUpper {
            get;
            set;
        }

        /// <summary>
        /// 有效下限
        /// </summary>
        [Description("ValidLower")]
        public virtual string ValidLower {
            get;
            set;
        }

        /// <summary>
        /// 有效上限
        /// </summary>
        [Description("ValidUpper")]
        public virtual string ValidUpper {
            get;
            set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        [Description("Unit")]
        public virtual string Unit {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("Enabled")]
        public virtual bool Enabled {
            get;
            set;
        }      

        #endregion

    }

 
}