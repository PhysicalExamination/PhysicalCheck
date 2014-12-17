using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity {

    public class Norecordor {

        public Norecordor() {
        }

        public virtual string TableNam {
            get;
            set;
        }

        public virtual DateTime LastBillDate {
            get;
            set;
        }

        public virtual String BillNo {
            get;
            set;
        }

        public virtual DateTime LastIdDate {
            get;
            set;
        }
        public virtual int LineId {
            get;
            set;
        }

    }
}
