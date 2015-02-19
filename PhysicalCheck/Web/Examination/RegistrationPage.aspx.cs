using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using DataEntity.Examination;
using Common.FormatProvider;

public partial class Examination_RegistrationPage : BasePage {

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

    private int PersonID {
        get {
            if (ViewState["PersonID"] == null) return int.MinValue;
            return (int)ViewState["PersonID"];
        }
        set {
            ViewState["PersonID"] = value;
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
        txtDeptName.Text = "个人体检";
        txtPackageName.Text = "";
        txtRegisterNo.Text = "";
        txtName.Text = "";
        drpSex.SelectedIndex = -1;
        txtIDNumber.Text = "";
        txtBirthday.Text = "";
        txtAge.Text = "";
        drpMarriage.SelectedIndex = -1;//.Text = "";
        txtJob.Text = "";
        drpEducation.SelectedIndex = -1;
        txtNation.Text = "汉族";
        txtLinkTel.Text = "";
        txtAddress.Text = "";
        txtMobile.Text = "";
        txtEMail.Text = "";
        txtRegisterDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        txtCheckDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        hDeptID.Value = "1";
        hPackageID.Value = "-1";
        hGroups.Value = "";
        hPhoto.Value = "";
        PersonID = int.MinValue;
        RegisterNo = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetRegistrationUI() {
        RegistrationViewEntity Result = m_Registration.GetRegistration(RegisterNo);
        if (Result == null) return;
        PersonID = Result.PersonID.Value;
        hDeptID.Value = Result.DeptID.Value+"";
        hPackageID.Value = Result.PackageID + "";
        txtRegisterNo.Text = Result.RegisterNo;
        txtPackageName.Text = Result.PackageName;
        txtRegisterDate.Text = EnvShowFormater.GetShortDate(Result.RegisterDate);
        txtCheckDate.Text = EnvShowFormater.GetShortDate(Result.CheckDate);
        txtDeptName.Text = Result.DeptName;
        txtName.Text = Result.Name;
        drpSex.SelectedValue = Result.Sex;
        txtIDNumber.Text = Result.IDNumber;
        txtBirthday.Text = EnvShowFormater.GetShortDate(Result.Birthday);
        txtAge.Text = EnvShowFormater.GetNumberString(Result.Age);
        drpMarriage.SelectedValue = Result.Marriage;
        txtJob.Text = Result.Job;
        drpEducation.SelectedValue = Result.Education;
        txtNation.Text = Result.Nation;
        txtLinkTel.Text = Result.LinkTel;
        txtAddress.Text = Result.Address;
        txtMobile.Text = Result.Mobile;
        txtEMail.Text = Result.EMail;
        hPhoto.Value = Result.Photo;
        BindCheckedGroups(RegisterNo);
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private RegistrationViewEntity GetRegistrationUI() {
        RegistrationViewEntity Result = new RegistrationViewEntity();
        Result.PersonID = PersonID;
        Result.RegisterNo = RegisterNo;
        Result.Name = txtName.Text;
        Result.Sex = drpSex.SelectedValue;
        Result.IDNumber = txtIDNumber.Text;
        Result.Age = EnvConverter.ToInt32(txtAge.Text);
        Result.DeptID = EnvConverter.ToInt32(hDeptID.Value);
        Result.PackageID = EnvConverter.ToInt32(hPackageID.Value);
        Result.Marriage = drpMarriage.SelectedValue;
        Result.Job = txtJob.Text;
        Result.Education = drpEducation.SelectedValue;
        Result.Nation = txtNation.Text;
        Result.LinkTel = txtLinkTel.Text;
        Result.Address = txtAddress.Text;
        Result.Mobile = txtMobile.Text;
        Result.EMail = txtEMail.Text;
        Result.Photo = hPhoto.Value;
        Result.CheckDate = EnvConverter.ToDateTime(txtCheckDate.Text);
        Result.RegisterDate = EnvConverter.ToDateTime(txtRegisterDate.Text);
        if (!String.IsNullOrEmpty(hGroups.Value)) {
            String[] ItemGroups = hGroups.Value.Split(',');
            Result.Groups = ItemGroups.Select(p => Convert.ToInt32(p)).ToList();
        }
        return Result;
    }

    private void BindCheckedGroups(String RegisterNo) {
        GroupsRepeater.DataSource = m_Registration.GetCheckedGroups(RegisterNo);
        GroupsRepeater.DataBind();
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
            btnNew.Enabled = CanEditData;
            btnEdit.Enabled = CanEditData;
            btnDelete.Enabled = CanEditData;
            btnSave.Enabled = false;
        }
        if (State == "New") {
            SetUIStatus(true);
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        if (State == "Edit") {
            SetUIStatus(true);
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            txtRegisterDate.Enabled = false;
            txtDeptName.Enabled = false;
            txtPackageName.Enabled = false;
        }
        txtRegisterNo.Enabled = false;
        txtDeptName.Enabled = false;
        txtPackageName.Enabled = false;
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object sender, EventArgs e) {
        RegistrationViewEntity Result = GetRegistrationUI();
        m_Registration.SaveRegistration(Result);
        ShowMessage("体检登记数据保存成功!");
        //int Succeed = m_Registration.SaveRegistration(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        BindCheckedGroups(Result.RegisterNo);
        SetUIState("Default");
    }

    protected void btnNew_Click(object sender, EventArgs e) {
        ClearcheckpersonUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDelete_Click(object sender, EventArgs e) {
        m_Registration.DeleteRegistration(RegisterNo);
        ShowMessage("删除体检登记数据成功!");
        //int Succeed = m_Registration.DeleteRegistration(GetRegistrationUI());
        //if (Succeed > 0) ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        DataBind();
        SetUIState("Default");
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

    protected void GroupsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "delete") {
            int GroupID = Convert.ToInt32(e.CommandArgument);
            m_Registration.DeleteCheckedGroup(RegisterNo, GroupID);
            BindCheckedGroups(RegisterNo);
            ShowMessage("组合项删除成功！");
        }
    }


    #endregion


}