using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Examination {
   
    public class GroupSummaryEntity {

        #region 构造方法

        public GroupSummaryEntity() {
        }

        #endregion

        #region 属性

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
        public virtual int GroupID {
            get;
            set;
        }

        public virtual int SummaryID {
            get;
            set;
        }
        #endregion
    }
}
