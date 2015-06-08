﻿using BusinessLogic.Examination;
using BusinessLogic.SysConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search_GetDataByTradesPage : BasePage {
    protected override void OnLoad(EventArgs e) {
        if (!IsPostBack) {
            ClientInitial();
            DataBind();
        }
        base.OnLoad(e);
    }

    public override void DataBind() {
        using (RegistrationBusiness Business = new RegistrationBusiness()) {
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text);
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text);           
            int RecordCount = 0;
            Repeater.DataSource = Business.GetDataByTrades(Pager.CurrentPageIndex, Pager.PageSize,
                StartDate, EndDate, drpTrades.SelectedValue, out RecordCount);
            Pager.RecordCount = RecordCount;
        }
        base.DataBind();
    }

    protected void btnSearch_Click(Object Sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(Object Sender, EventArgs e) {
        DataBind();
    }

    protected String GetHealthCondition(object HealthCondition) {
        String Result = (String)HealthCondition;
        if (String.IsNullOrWhiteSpace(Result)) return "待检";
        if (Result == "01") return "合格";
        if (Result == "02") return "不合格";
        if (Result == "03") return "缺项";
        if (Result == "04") return "复查";
        return "待检";
    }

    private void ClientInitial() {
        DateTime CurrentDate = DateTime.Now.Date;
        txtStartDate.Text = CurrentDate.AddDays(-7).ToString("yyyy-MM-dd");
        txtEndDate.Text = CurrentDate.ToString("yyyy-MM-dd");
        using (CommonCodeBusiness CommonCode = new CommonCodeBusiness()) {
            drpTrades.DataSource = CommonCode.GetCommonCodes("003");
            drpTrades.DataValueField = "Code";
            drpTrades.DataTextField = "Name";
            drpTrades.DataBind();
        }
    }
}