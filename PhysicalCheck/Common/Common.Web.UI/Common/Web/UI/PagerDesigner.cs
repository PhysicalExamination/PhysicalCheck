﻿using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.Design;


namespace Common.Web.UI
{   

    public class PagerDesigner : ControlDesigner
    {
        private AspNetPager wb;

        public override string GetDesignTimeHtml()
        {
            this.wb = (AspNetPager) base.Component;
            this.wb.RecordCount = 0xe1;
            StringWriter writer = new StringWriter();
            HtmlTextWriter writer2 = new HtmlTextWriter(writer);
            this.wb.RenderControl(writer2);
            return writer.ToString();
        }

        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            region.Selectable = false;
            return null;
        }

        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            string instruction = "Error creating control：" + e.Message;
            return base.CreatePlaceHolderDesignTimeHtml(instruction);
        }
    }
}

