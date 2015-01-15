using System;
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
        Int32 DeptID = Convert.ToInt32(Request.Params["DeptID"]);
        using (SuggestionBusiness Suggestion = new SuggestionBusiness()) {
            int RecordCount = 0;
            SuggestionRepeater.DataSource = Suggestion.GetSuggestions(Pager.CurrentPageIndex,
                Pager.PageSize, DeptID, out RecordCount);
            Pager.RecordCount = RecordCount;
        }
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    #endregion

}