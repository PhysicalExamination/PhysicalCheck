using System;
using System.ComponentModel;

namespace Common.Web.UI
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class ANPDescriptionAttribute : DescriptionAttribute
    {
        private bool replaced;

        public ANPDescriptionAttribute(string text) : base(text)
        {
            this.replaced = false;
        }

        public override string Description
        {
            get
            {
                if (!this.replaced)
                {
                    this.replaced = true;
                    base.DescriptionValue = Common.Web.UI.SR.GetString(base.DescriptionValue);
                }
                return base.Description;
            }
        }
    }
}

