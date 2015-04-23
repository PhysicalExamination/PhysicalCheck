using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using DataEntity.Examination;
using Common.FormatProvider;
using BusinessLogic.SysConfig;


/// <summary>
/// 缴费信息
/// </summary>
public partial class Examination_ChargePage : BasePage
{
    #region 私有成员

    private ChargeBusiness m_Charge;

    #endregion

    #region 属性

    private string BillNo {
        get {
            if (ViewState["BillNo"] == null) return string.Empty;
            return (string)ViewState["BillNo"];
        }
        set {
            ViewState["BillNo"] = value;
        }
    }

    /// <summary>
    /// 已体检人数
    /// </summary>
    private int CheckedCount {
        get {
            if (ViewState["CheckedCount"] == null) return 0;
            return (int)ViewState["CheckedCount"];
        }
        set {
            ViewState["CheckedCount"] = value;
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
        m_Charge = new ChargeBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Charge.Dispose();
        m_Charge = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 缴费信息数据绑定
    /// </summary>
    public override void DataBind() {
        String PaymentMan = txtPaymentMan.Text.Trim();
        int RecordCount = 0;
        ChargeRepeater.DataSource = m_Charge.GetCharges(Pager.CurrentPageIndex,
            Pager.PageSize,PaymentMan,out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }
    /// <summary>
    /// 设置缴费信息界面控件显示状态
    /// </summary>
    /// <param name="Enabled"></param>
    private void SetUIStatus(bool Enabled) {
        ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
        foreach (Control ctrl in Controls) {
            if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
        }
    }
    /// <summary>
    /// 设置缴费信息界面按钮显示状态
    /// </summary>
    /// <param name="State"></param>
    private void SetUIState(string State) {
        if (State == "Default") {
            SetUIStatus(false);
            btnNew.Enabled = CanEditData;
            btnEdit.Enabled = CanEditData;
            btnDelete.Enabled = IsAdmin;
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
        txtPackageName.Enabled = false;
        txtCharge.Enabled = false;
        txtChargePerson.Enabled = false;
    }

    #endregion

    #region 私有方法

    private void ClientInitial() {
        using (RegionBusiness Region = new RegionBusiness()) {
            drpRegions.DataSource = Region.GetRegions("620600000");
            drpRegions.DataTextField = "RegionName";
            drpRegions.DataValueField = "RegionCode";
            drpRegions.DataBind();
        }
    }

    #endregion

    #region 私有成员

    /// <summary>
    /// 重置缴费信息界面
    /// </summary>
    private void ClearChargeUI() {
        BillNo = "";
        hDeptID.Value = "1";
        hPackageID.Value = "";
        txtPayer.Text = "";
        txtPackageName.Text = "";
        txtCheckNum.Text = "1";
        txtCharge.Text = "";
        txtActualCharge.Text = "";
        drpPaymentMethod.SelectedIndex =-1;
        txtPaymentDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        txtChargePerson.Text = UserName;
        CheckedCount = 0;
        drpRegions.SelectedIndex = -1;
        txtAddress.Text = "";

    }
    /// <summary>
    /// 填充缴费信息界面
    /// </summary>
    private void SetChargeUI() {
        ChargeViewEntity Result = m_Charge.GetCharge(BillNo);
        if (Result == null) return;
        hDeptID.Value = Result.ChargeDeptID + "";
        txtPayer.Text = Result.Payer;
        hPackageID.Value = Result.PackageID + "";
        txtPackageName.Text = Result.PackageName;
        txtCheckNum.Text = Result.CheckNum + "";
        txtCharge.Text = EnvShowFormater.GetNumberString(Result.Charge);
        txtActualCharge.Text = EnvShowFormater.GetNumberString(Result.ActualCharge);
        drpPaymentMethod.SelectedValue = Result.PaymentMethod;
        txtPaymentDate.Text = EnvShowFormater.GetShortDate(Result.PaymentDate);
        txtChargePerson.Text = Result.ChargePerson;
        CheckedCount = Result.CheckedCount;
        drpRegions.SelectedValue = Result.RegionCode;
        txtAddress.Text = Result.Address;
    }
      

    /// <summary>
    /// 从界面获取缴费信息对象
    /// </summary>
    /// <returns></returns>
    private ChargeEntity GetChargeUI() {
        ChargeEntity Result = new ChargeEntity();
        Result.BillNo = BillNo;
        Result.ChargeDeptID = EnvConverter.ToInt32(hDeptID.Value);
        Result.Payer = txtPayer.Text;
        Result.PackageID = EnvConverter.ToInt32(hPackageID.Value);
        Result.CheckNum = EnvConverter.ToInt32(txtCheckNum.Text);
        Result.Charge = EnvConverter.ToDecimal(txtCharge.Text);
        Result.ActualCharge = EnvConverter.ToDecimal(txtActualCharge.Text);
        Result.PaymentMethod = drpPaymentMethod.SelectedValue;
        Result.PaymentDate = EnvConverter.ToDateTime(txtPaymentDate.Text);
        Result.ChargePerson = txtChargePerson.Text;
        Result.CheckedCount = CheckedCount;
        Result.RegionCode = drpRegions.SelectedValue;
        Result.Address = txtAddress.Text;
        return Result;
    }

    #endregion

    #region 事件

    protected void btnSaveCharge_Click(object sender, EventArgs e) {
        if (String.IsNullOrEmpty(hPackageID.Value)) {
            ShowMessage("请您选择套餐!");
            return;
        }
        ChargeEntity Result = GetChargeUI();
        m_Charge.SaveCharge(Result);
        BillNo = Result.BillNo;
        ShowMessage("缴费信息数据保存成功!");
        //int Succeed = m_Charge.SaveCharge(Result);
        //if (Succeed > 0) ShowMessage("缴费信息数据保存成功!");
        //if (Succeed < 0) ShowMessage("缴费信息数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewCharge_Click(object sender, EventArgs e) {
        ClearChargeUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteCharge_Click(object sender, EventArgs e) {
        m_Charge.DeleteCharge(GetChargeUI());
        ShowMessage("缴费信息数据删除成功!");
        //int Succeed = m_Charge.DeleteCharge(GetChargeUI());
        //if (Succeed > 0) ShowMessage("缴费信息数据删除成功!");
        //if (Succeed < 0) ShowMessage("缴费信息数据删除失败!");
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditCharge_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelCharge_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ChargeItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblBillNo = (Literal)e.Item.FindControl("lblBillNo");
            BillNo = lblBillNo.Text;          
            SetChargeUI();
            SetUIState("Default");
        }
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}