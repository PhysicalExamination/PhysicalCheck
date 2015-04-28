using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.Examination {

    /// <summary>
    /// 数据分组
    /// </summary>
    public class DataGroupEntity {

        public DataGroupEntity() {
        }

        /// <summary>
        /// 年月
        /// </summary>
        public virtual String YearMonth {
            get;
            set;
        }

        public virtual int GroupID {
            get;
            set;
        }

        /// <summary>
        /// 分组名称
        /// </summary>
        public virtual String GroupName {
            get;
            set;
        }

        /// <summary>
        /// 体检合格人数
        /// </summary>
        public virtual int? PassedCount {
            get;
            set;
        }

        /// <summary>
        /// 体检不合格人数
        /// </summary>
        public virtual int? UnpassedCount {
            get;
            set;
        }
    }
}
