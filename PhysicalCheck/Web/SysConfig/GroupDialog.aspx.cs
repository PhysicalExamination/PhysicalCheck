using BusinessLogic.SysConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysConfig_GroupDialog : BasePage {

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {           
            DataBind();
        }
    }

    public override void DataBind() {
        using (ItemGroupBusiness ItemGroup = new ItemGroupBusiness()) {
            int RecordCount = 0;
            String GroupName = txtGroupName.Text;
            ItemGroupRepeater.DataSource = ItemGroup.GetItemGroups(Pager.CurrentPageIndex,
                Pager.PageSize,GroupName,"", out RecordCount);
            Pager.RecordCount = RecordCount;
            base.DataBind();            
        }
    }

    #endregion



    #region 受保护方法

    protected String GetSex(Object obj) {
        String val = (String)obj;
        if (val == "%") return "不限";
        if (val == "0") return "女";
        if (val == "1") return "男";
        return "";
    }

    #endregion

    #region 事件

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnSearch_Click(object source, EventArgs e) {
        DataBind();
    }

    #endregion
}