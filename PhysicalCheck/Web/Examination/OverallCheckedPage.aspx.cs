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
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "setCheckedStatus", "setCheckedStatus();", true);
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
        txtSummary.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetRegistrationUI() {
        RegistrationViewEntity Result = m_Registration.GetOverall(RegisterNo);
        if (Result == null) return;
        drpHealthCondition.SelectedValue = Result.HealthCondition;
        drpEvaluateResult.SelectedValue = drpEvaluateResult.SelectedValue;
        txtRegisterNo.Text = Result.RegisterNo;
        txtDeptName.Text = Result.DeptName;
        txtPackageName.Text = Result.PackageName;
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
        bool IsCheckOver = true;
        if (drpHealthCondition.SelectedValue == "04") IsCheckOver = false;
        RegistrationViewEntity RegInfo = m_Registration.GetRegistration(RegisterNo);
        RegistrationEntity Result = new RegistrationEntity {
            ChargeNo = RegInfo.ChargeNo,
            RegisterNo = RegInfo.RegisterNo,
            RegisterDate = RegInfo.RegisterDate,
            CheckDate = RegInfo.CheckDate,
            PersonID = RegInfo.PersonID,
            PackageID=  RegInfo.PackageID,
            IsCheckOver = IsCheckOver,
            Conclusion = txtConclusion.Text,
            Recommend = txtRecommend.Text,
            OverallDate = DateTime.Now.Date,
            OverallDoctor = UserName,
            ReviewDate = EnvConverter.ToDateTime(txtReviewDate.Text),
            ReviewSummary = txtReviewSummary.Text,
            EvaluateResult = drpEvaluateResult.SelectedValue,
            HealthCondition = drpHealthCondition.SelectedValue,
            Enabled = RegInfo.Enabled
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

    #endregion

    #region 事件

    protected void btnSave_Click(object sender, EventArgs e) {
        RegistrationEntity Result = GetRegistrationUI();
        m_Registration.SaveOverallChecked(Result);
        ShowMessage("总检数据保存成功!");
        ClearUI();
        //int Succeed = m_Registration.SaveRegistration(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();       
    }

    protected void btnNew_Click(object sender, EventArgs e) {
        ClearUI();
        btnSave.Enabled = CanEditData;       
    }
   
    protected void btnEdit_Click(object sender, EventArgs e) {
     
    }

    protected void btnCancel_Click(object sender, EventArgs e) {
        ClearUI();       
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblRegisterNo = (Literal)e.Item.FindControl("lblRegisterNo");
            RegisterNo = lblRegisterNo.Text;
            SetRegistrationUI();
            //SetUIState("Default");
        }
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    protected void btnBatch_Click(object source, EventArgs e) {
    }

    #endregion
}