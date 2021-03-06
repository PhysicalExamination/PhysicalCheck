﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.FormatProvider;
using BusinessLogic.Examination;
using DataEntity.Examination;
using System.Data;

public partial class Examination_OverallCheckedPage : BasePage {

    #region 私有成员

    private RegistrationBusiness m_Registration;

    #endregion

    #region 属性

    private string RegisterNo {
        get {
            if (ViewState["RegisterNo"] == null) return string.Empty;
            return (string)ViewState["RegisterNo"];
        }
        set {
            ViewState["RegisterNo"] = value;
        }
    }

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            ClientInitial();
            DataBind();
            SetUIState("Default");
        }
    }

    protected override void OnInit(EventArgs e) {
        m_Registration = new RegistrationBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Registration.Dispose();
        m_Registration = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定体检登记
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        DateTime? RegisterDate = EnvConverter.ToDateTime(txtSRegisterDate.Text);
        String DeptName = txtsDeptName.Text.Trim();
        String RegisterNo = txtsRegisterNo.Text.Trim();
        RegistrationRepeater.DataSource = m_Registration.GetOveralls(Pager.CurrentPageIndex, Pager.PageSize,
            RegisterDate, DeptName, RegisterNo, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
        RepeaterItemCollection Items = RegistrationRepeater.Items;
        Button btnDetail;
        foreach (RepeaterItem Item in Items) {
            btnDetail = (Button)Item.FindControl("btnDetail");
            btnDetail.OnClientClick = "onSelected(1, \"" + btnDetail.CommandArgument + "\")";
        }
    }

    #endregion

    #region 私有成员

    private void ClientInitial() {
        txtSRegisterDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
    }

    /// <summary>
    /// 重置界面
    /// </summary>
    private void ClearUI() {
        drpEvaluateResult.SelectedIndex = -1;
        drpHealthCondition.SelectedIndex = -1;
        txtConclusion.Text = "";
        txtRecommend.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetRegistrationUI() {
        RegistrationViewEntity Result = m_Registration.GetOverall(RegisterNo);
        if (Result == null) return;
        txtRegisterNo.Text = Result.RegisterNo;
        txtDeptName.Text = Result.DeptName;
        txtPackageName.Text = Result.PackageName;
        txtCheckDate.Text = EnvShowFormater.GetShortDate(Result.CheckDate);
        txtName.Text = Result.Name;
        drpSex.SelectedValue = Result.Sex;
        txtSummary.Text = Result.Summary;
        txtConclusion.Text = Result.Conclusion;
        txtRecommend.Text = Result.Recommend;
        //BindCheckedGroups(RegisterNo);
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private RegistrationEntity GetRegistrationUI() {
        RegistrationViewEntity RegInfo = m_Registration.GetOverall(RegisterNo);
        bool IsCheckOver = true;
        if (!String.IsNullOrWhiteSpace(txtReviewDate.Text)) IsCheckOver = false;
        RegistrationEntity Result = new RegistrationEntity {
            RegisterNo = RegInfo.RegisterNo,
            RegisterDate = RegInfo.RegisterDate,
            PersonID = RegInfo.PersonID,
            PackageID = RegInfo.PackageID,
            IsCheckOver = IsCheckOver,
            Conclusion = txtConclusion.Text,
            Recommend = txtRecommend.Text,
            OverallDate = DateTime.Now.Date,
            OverallDoctor = UserName,
            ReviewDate = EnvConverter.ToDateTime(txtReviewDate.Text),
            ReviewSummary = txtReviewSummary.Text,
            EvaluateResult = drpEvaluateResult.SelectedValue,
            HealthCondition = drpHealthCondition.SelectedValue,
        };
        return Result;
    }

    /// <summary>
    /// 设置界面控件显示状态
    /// </summary>
    /// <param name="Enabled"></param>
    private void SetUIStatus(bool Enabled) {
        ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
        foreach (Control ctrl in Controls) {
            if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
        }
    }
    /// <summary>
    /// 设置界面按钮显示状态
    /// </summary>
    /// <param name="State"></param>
    private void SetUIState(string State) {
        if (State == "Default") {
            SetUIStatus(false);
            btnEdit.Enabled = CanEditData;
            btnSave.Enabled = false;
        }
        if (State == "New") {
            SetUIStatus(true);
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }

        if (State == "Edit") {
            SetUIStatus(true);
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        txtRegisterNo.Enabled = false;
        txtDeptName.Enabled = false;
        txtPackageName.Enabled = false;
        txtCheckDate.Enabled = false;
        txtName.Enabled = false;
        drpSex.Enabled = false;
        //txtSummary.Enabled = false;
    }

    private void BindCheckedGroups(String RegisterNo) {
        //GroupsRepeater.DataSource = m_Registration.GetCheckedGroups(RegisterNo);
        //GroupsRepeater.DataBind();
        //rptMain.DataSource = m_Registration.GetGroupResults(RegisterNo);// bll.GetList_GroupResult(sql);
        //rptMain.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object sender, EventArgs e) {
        RegistrationEntity Result = GetRegistrationUI();
        m_Registration.SaveOverallChecked(Result);
        ShowMessage("总检数据保存成功!");
        //int Succeed = m_Registration.SaveRegistration(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNew_Click(object sender, EventArgs e) {
        ClearUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnEdit_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancel_Click(object sender, EventArgs e) {
        ClearUI();
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {           
            RegisterNo = (String)e.CommandArgument;
            SetRegistrationUI();
            SetUIState("Default");
        }
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnBatch_Click(object source, EventArgs e) {
        RepeaterItemCollection Items = RegistrationRepeater.Items;
        GroupResultBusiness GroupResult = new GroupResultBusiness();
        Button btnDetail;
        String RegisterNo = "";
        foreach (RepeaterItem Item in Items) {
            btnDetail = (Button)Item.FindControl("btnDetail");
            RegisterNo = btnDetail.CommandArgument + "";
            String Summary = String.Join(Environment.NewLine, GroupResult.GetGroupSummary(RegisterNo).ToArray());
            m_Registration.SaveOverall(RegisterNo, DateTime.Now.Date, UserName, Summary, "", "");
        }
        ShowMessage("操作成功！");
    }


    protected void rptMain_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            Repeater rep = e.Item.FindControl("rptSub") as Repeater;//找到里层的repeater对象
            Literal lblGroupID = (Literal)e.Item.FindControl("lblGroupID");
            rep.DataSource = m_Registration.GetItemResults(RegisterNo, Convert.ToInt32(lblGroupID.Text));
            rep.DataBind();           
        }
    }

    #endregion
}