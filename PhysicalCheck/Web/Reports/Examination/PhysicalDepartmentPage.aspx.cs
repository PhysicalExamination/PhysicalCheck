using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using DataEntity.Examination;
using BusinessLogic.SysConfig;

public partial class Examination_PhysicalDepartmentPage :BasePage {

    #region 私有成员

    private PhysicalDepartmentBusiness m_PhysicalDepartment;

    #endregion

    #region 属性

    private int DeptID {
        get {
            if (ViewState["DeptID"] == null) return int.MinValue;
            return (int)ViewState["DeptID"];
        }
        set {
            ViewState["DeptID"] = value;
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
        m_PhysicalDepartment = new PhysicalDepartmentBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_PhysicalDepartment.Dispose();
        m_PhysicalDepartment = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        String DeptName = txtSearch.Text.Trim();
        PhysicalDepartmentRepeater.DataSource = m_PhysicalDepartment.GetPhysicalDepartments(Pager.CurrentPageIndex,
            Pager.PageSize, DeptName, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }

    #endregion

    #region 私有成员

    private void ClientInitial() {
        using (CommonCodeBusiness Business = new CommonCodeBusiness()) {
            drpNature.DataSource = Business.GetFactNatures();
            drpNature.DataValueField = "Code";
            drpNature.DataTextField = "Name";
            drpNature.DataBind();
        }
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
        }
    }

    /// <summary>
    /// 重置界面
    /// </summary>
    private void ClearPhysicalDepartmentUI() {
        DeptID = int.MinValue;
        txtDeptName.Text = "";
        txtLeader.Text = "";
        txtLinkTel.Text = "";
        txtFax.Text = "";
        txtPostCode.Text = "";
        txtAddress.Text = "";
        txtBank.Text = "";
        txtBankAccount.Text = "";
        drpNature.SelectedIndex = -1;
        txtComment.Text = "";       
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetPhysicalDepartmentUI() {
        PhysicalDepartmentEntity Result = m_PhysicalDepartment.GetPhysicalDepartment(DeptID);
        if (Result == null) return;       
        txtDeptName.Text = Result.DeptName;
        txtLeader.Text = Result.Leader;
        txtLinkTel.Text = Result.LinkTel;
        txtFax.Text = Result.Fax;
        txtPostCode.Text = Result.PostCode;
        txtAddress.Text = Result.Address;
        txtBank.Text = Result.Bank;
        txtBankAccount.Text = Result.BankAccount;
        drpNature.SelectedValue = Result.Nature;
        txtComment.Text = Result.Comment;
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private PhysicalDepartmentEntity GetPhysicalDepartmentUI() {
        PhysicalDepartmentEntity Result = new PhysicalDepartmentEntity();
        Result.DeptID = DeptID;
        Result.DeptName = txtDeptName.Text;
        Result.Leader = txtLeader.Text;
        Result.LinkTel = txtLinkTel.Text;
        Result.Fax = txtFax.Text;
        Result.PostCode = txtPostCode.Text;
        Result.Address = txtAddress.Text;
        Result.Bank = txtBank.Text;
        Result.BankAccount = txtBankAccount.Text;
        Result.Nature = drpNature.SelectedValue;
        Result.Comment = txtComment.Text;
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSavePhysicalDepartment_Click(object sender, EventArgs e) {
        PhysicalDepartmentEntity Result = GetPhysicalDepartmentUI();
        m_PhysicalDepartment.SavePhysicalDepartment(Result);
        ShowMessage("体检单位数据保存成功!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewPhysicalDepartment_Click(object sender, EventArgs e) {
        ClearPhysicalDepartmentUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeletePhysicalDepartment_Click(object sender, EventArgs e) {
        PhysicalDepartmentEntity PhysicalDepartment = GetPhysicalDepartmentUI();
        if (PhysicalDepartment.DeptID == 1) {
            ShowMessage("该体检单位为系统保留项不能删除！");
            return;
        }
        m_PhysicalDepartment.DeletePhysicalDepartment(PhysicalDepartment);
        ShowMessage("体检单位数据删除成功!");       
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditPhysicalDepartment_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelPhysicalDepartment_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void PhysicalDepartmentItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblDeptID = (Literal)e.Item.FindControl("lblDeptID");
            DeptID = Convert.ToInt32(lblDeptID.Text);          
            SetPhysicalDepartmentUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion

}