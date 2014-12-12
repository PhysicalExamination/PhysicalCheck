using System;
using System.Resources;

namespace Common.Web.UI
{
    internal sealed class SR
    {
        private static Common.Web.UI.SR _loader = null;
        private static object _lock = new object();
        private ResourceManager _rm;

        private SR()
        {
            this._rm = new ResourceManager("Common.Web.UI.AspNetPager", GetType().Assembly);
            //this._rm = new ResourceManager("Common.Web.UI.AspNetPager", System.Reflection.Assembly.GetExecutingAssembly());
        }

        private static Common.Web.UI.SR GetLoader()
        {
            if (_loader == null)
            {
                lock (_lock)
                {
                    if (_loader == null)
                    {
                        _loader = new Common.Web.UI.SR();
                    }
                }
            }
            return _loader;
        }

        public static string GetString(string name)
        {
            Common.Web.UI.SR loader = GetLoader();
            string str = null;
            if (loader != null)
            {
                str =  loader.Resources.GetString(name, null);
            }
            return str;
        }

        private ResourceManager Resources
        {
            get
            {
                return this._rm;
            }
        }
    }
}

