using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataEntity.Survey {

    /// <summary>
    /// 实体类:SurveyListEntity
    /// 文件名:SurveyListEntity.cs
    /// 说  明:调查问卷模板
    /// </summary>
    public class SurveyListEntity {

        #region 构造方法

        public SurveyListEntity() {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 模板编号
        /// </summary>
        [Description("SID")]
        public virtual int SID {
            get;
            set;
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        [Description("SurveyName")]
        public virtual string SurveyName {
            get;
            set;
        }

        /// <summary>
        /// 适用性别
        /// </summary>
        [Description("Sex")]
        public virtual string Sex {
            get;
            set;
        }

        /// <summary>
        /// 病种
        /// </summary>
        [Description("Disease")]
        public virtual string Disease {
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

        /// <summary>
        /// 描述
        /// </summary>
        [Description("Description")]
        public virtual string Description {
            get;
            set;
        }

        #endregion
    }
}
