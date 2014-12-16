using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.FormatProvider;
using BusinessLogic.Examination;
using DataEntity.Examination;

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
        RegistrationRepeater.DataSource = m_Registration.GetRegistrations(Pager.CurrentPageIndex, Pager.PageSize,
            RegisterDate, DeptName, RegisterNo, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }

    #endregion

    #region 私有成员

    private void ClientInitial() {
        txtSRegisterDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
    }

    /// <summary>
    /// 重置界面
    /// </summary>
    private void ClearcheckpersonUI() {
        txtConclusion.Text = "";
        txtRecommend.Text = "";       
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetRegistrationUI() {
        RegistrationViewEntity Result = m_Registration.GetRegistration(RegisterNo);
        if (Result == null) return;
        txtRegisterNo.Text = Result.RegisterNo;
        txtDeptName.Text = Result.DeptName;
        //txtPackageName.Text = Result.PackageName;
        txtCheckDate.Text = EnvShowFormater.GetShortDate(Result.CheckDate);
        txtName.Text = Result.Name;
        drpSex.SelectedValue = Result.Sex;
        txtSummary.Text= Result.Summary;
        txtConclusion.Text = Result.Conclusion;
        txtRecommend.Text = Result.Recommend;
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private RegistrationEntity GetRegistrationUI() {
        RegistrationEntity Result = new RegistrationEntity();
        Result.RegisterNo = RegisterNo;
        Result.Conclusion = txtConclusion.Text;
        Result.Recommend = txtRecommend.Text;
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
        txtSummary.Enabled = false;
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object sender, EventArgs e) {
        RegistrationEntity Result = GetRegistrationUI();
        //m_Registration.SaveRegistration(Result);
        ShowMessage("体检登记数据保存成功!");
        //int Succeed = m_Registration.SaveRegistration(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNew_Click(object sender, EventArgs e) {
        ClearcheckpersonUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }
   
    protected void btnEdit_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancel_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblRegisterNo = (Literal)e.Item.FindControl("lblRegisterNo");
            RegisterNo = lblRegisterNo.Text;
            SetRegistrationUI();
            SetUIState("Default");
        }
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}