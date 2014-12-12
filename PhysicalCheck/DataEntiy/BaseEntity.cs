using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataEntity {

    [Serializable]
    public class BaseEntity<T> : System.IComparable<T> {

        #region IComparable<T> 成员

        public virtual int CompareTo(T other) {
            return -1;
        }

        #endregion
    }
}
