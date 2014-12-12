using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic {

    public abstract class BaseBusinessLogic<T> : System.IDisposable where T : new() {
        protected T DataAccess;

        public BaseBusinessLogic() {
            DataAccess = new T();
        }


        #region IDisposable 成员

        public virtual void Dispose() {
        }

        #endregion
    }
}
