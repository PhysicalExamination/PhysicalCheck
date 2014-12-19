using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.FormatProvider;
using BusinessLogic.Examination;

/// <summary>
/// 复检通知
/// </summary>
public partial class Examination_ReviewPage : BasePage {

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            ClientInitial();
            DataBind();            
        }
    }   

    /// <summary>
    /// 数据绑定体检登记
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        DateTime StartDate = Convert.ToDateTime(txtStartDate.Text);
        DateTime EndDate = Convert.ToDateTime(txtEndDate.Text);
        using (RegistrationBusiness Registration = new RegistrationBusiness()) {
            ReviewRepeater.DataSource = Registration.GetReviews(Pager.CurrentPageIndex, Pager.PageSize,
                StartDate, EndDate, out RecordCount);
            Pager.RecordCount = RecordCount;           
        }
        base.DataBind();
    }

    #endregion

    #region 私有方法

    private void ClientInitial() {
        DateTime CurrentDate = DateTime.Now.Date;
        txtStartDate.Text = CurrentDate.AddDays(-10).ToString("yyyy年MM月dd日");
        txtEndDate.Text = CurrentDate.ToString("yyyy年MM月dd日");
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object sender, EventArgs e) {
        RegistrationBusiness Registration = new RegistrationBusiness();
        RepeaterItemCollection Items = ReviewRepeater.Items;
        Literal lblRegisterNo;
        DropDownList drpInformResult;
        foreach (RepeaterItem Item in Items) {
            lblRegisterNo = (Literal)Item.FindControl("lblRegisterNo");
            drpInformResult = (DropDownList)Item.FindControl("drpInformResult");
            Registration.SaveReview(lblRegisterNo.Text, drpInformResult.SelectedValue,UserName);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}