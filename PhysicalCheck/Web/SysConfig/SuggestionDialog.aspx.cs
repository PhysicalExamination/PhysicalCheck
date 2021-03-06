﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;

public partial class SysConfig_SuggestionDialog : BasePage {

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();           
        }
    }

    public override void DataBind() {
        using (SuggestionBusiness Suggestion = new SuggestionBusiness()) {
            int RecordCount = 0;
            String SearchKey = txtSearchKey.Text;
            int GroupID = 1;
            if (!String.IsNullOrWhiteSpace(Request.Params["GroupID"])) GroupID = Convert.ToInt32(Request.Params["GroupID"]);
            SuggestionRepeater.DataSource = Suggestion.GetSuggestions(Pager.CurrentPageIndex,
                Pager.PageSize, GroupID,SearchKey, out RecordCount);
            Pager.RecordCount = RecordCount;
        }
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    #endregion

   
}