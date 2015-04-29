using BusinessLogic.Examination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search_IntegrateSearchPage : BasePage {


    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            ClientInitial();
            DataBind();
        }
    }

    public override void DataBind() {
        using (RegistrationBusiness Business = new RegistrationBusiness()) {
            Repeater.DataSource = Business.GetDataByGroup(txtYearMonth.Text, drpCategory.SelectedValue);
        }
        base.DataBind();
    }

    private void ClientInitial() {
        txtYearMonth.Text = DateTime.Now.ToString("yyyy-MM");
    }
    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }
}