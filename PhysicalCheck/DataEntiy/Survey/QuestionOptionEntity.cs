using System;
using System.ComponentModel;

namespace DataEntity.Survey {
    /// <summary>
    /// 实体类:QuestionOptionEntity
    /// 文件名:QuestionOptionEntity.cs
    /// 说  明:问题选项
    /// </summary>
    public class QuestionOptionEntity {

        #region 构造方法

        public QuestionOptionEntity() {
        }

        #endregion

        #region 属性
        
        [Description("QID")]
        public virtual QuestionOptionPK ID {
            get;
            set;
        }        

        /// <summary>
        /// 选项标题
        /// </summary>
        [Description("OptionTitle")]
        public virtual string OptionTitle {
            get;
            set;
        }

        /// <summary>
        /// 选项值
        /// </summary>
        [Description("OptionValue")]
        public virtual int OptionValue {
            get;
            set;
        }

        #endregion
    }

    public class QuestionOptionPK {

        /// <summary>
        /// 问题编码
        /// </summary>
        [Description("QID")]
        public int QID {
            get;
            set;
        }

        /// <summary>
        /// 序号
        /// </summary>
        [Description("SN")]
        public int SN {
            get;
            set;
        }

        public override bool Equals(object obj) {
            if (obj is QuestionOptionPK) {
                QuestionOptionPK pk = obj as QuestionOptionPK;
                if (this.QID == pk.QID && this.SN == pk.SN) {
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