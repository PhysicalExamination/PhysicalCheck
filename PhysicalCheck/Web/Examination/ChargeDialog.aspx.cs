using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;

public partial class Examination_ChargeDialog : BasePage {

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();           
        }
    }     

    /// <summary>
    /// 缴费信息数据绑定
    /// </summary>
    public override void DataBind() {
        String PaymentMan = txtSearchKey.Text.Trim();
        int RecordCount = 0;
        using (ChargeBusiness Business = new ChargeBusiness()) {
            ChargeRepeater.DataSource = Business.GetChargesForRegister(Pager.CurrentPageIndex,
                Pager.PageSize, PaymentMan, out RecordCount);
            Pager.RecordCount = RecordCount;
        }
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    #endregion
}