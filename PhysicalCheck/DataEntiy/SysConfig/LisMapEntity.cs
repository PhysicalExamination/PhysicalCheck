using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity.SysConfig {
    
    public class LisMapEntity {

        #region 构造器

        public LisMapEntity() {
        }

        #endregion

        #region 属性

        public virtual int Itemid {
            get;
            set;
        }

        public virtual String LisItemId1 {
            get;
            set;
        }

        public virtual String LisItemId2 {
            get;
            set;
        }

        public virtual String ItemName {
            get;
            set;
        }
        #endregion
    }
}
