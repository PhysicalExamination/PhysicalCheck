using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using DataEntity.Examination;
using Common.FormatProvider;


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

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
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
        ChargeRepeater.DataSource = m_Charge.GetCharges();
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

    #endregion

    #region 私有成员

    /// <summary>
    /// 重置缴费信息界面
    /// </summary>
    private void ClearChargeUI() { 
        txtPayer.Text = "";
        txtPackageID.Text = "";
        txtCheckNum.Text = "";
        txtCharge.Text = "";
        txtActualCharge.Text = "";
        txtPaymentMethod.Text = "";
        txtPaymentDate.Text = "";
        txtChargePerson.Text = "";        
    }
    /// <summary>
    /// 填充缴费信息界面
    /// </summary>
    private void SetChargeUI() {
        ChargeEntity Result = m_Charge.GetCharge(BillNo);
        if (Result == null) return;
        //txtChargeDeptID.Text = Result.ChargeDeptID + "";
        txtPayer.Text = Result.Payer;
        txtPackageID.Text = Result.PackageID + "";
        txtCheckNum.Text = Result.CheckNum + "";
        txtCharge.Text = EnvShowFormater.GetNumberString(Result.Charge);
        txtActualCharge.Text = EnvShowFormater.GetNumberString(Result.ActualCharge);
        txtPaymentMethod.Text = Result.PaymentMethod;
        txtPaymentDate.Text = EnvShowFormater.GetShortDate(Result.PaymentDate);
        txtChargePerson.Text = Result.ChargePerson;
    }
      

    /// <summary>
    /// 从界面获取缴费信息对象
    /// </summary>
    /// <returns></returns>
    private ChargeEntity GetChargeUI() {
        ChargeEntity Result = new ChargeEntity();
        Result.BillNo = BillNo;
        //Result.ChargeDeptID = EnvConverter.ToInt32(txtChargeDeptID.Text);
        Result.Payer = txtPayer.Text;
        Result.PackageID = EnvConverter.ToInt32(txtPackageID.Text);
        Result.CheckNum = EnvConverter.ToInt32(txtCheckNum.Text);
        Result.Charge = EnvConverter.ToDecimal(txtCharge.Text);
        Result.ActualCharge = EnvConverter.ToDecimal(txtActualCharge.Text);
        Result.PaymentMethod = txtPaymentMethod.Text;
        Result.PaymentDate = EnvConverter.ToDateTime(txtPaymentDate.Text);
        Result.ChargePerson = txtChargePerson.Text;       
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveCharge_Click(object sender, EventArgs e) {
        ChargeEntity Result = GetChargeUI();
        m_Charge.SaveCharge(Result);
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