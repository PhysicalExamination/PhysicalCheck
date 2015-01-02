using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.FormatProvider;
using DataEntity.Examination;
using BusinessLogic.Examination;
using BusinessLogic.SysConfig;
public partial class Examination_customerArchive : BasePage
{
    #region 私有成员

    private RegistrationBusiness m_Registration;
    private ChargeBusiness m_Charge;
    private string RegisterNo
    {
        get
        {
            if (ViewState["RegisterNo"] == null) return Request.QueryString["id"].ToString();
            return (string)ViewState["RegisterNo"];
        }
        set
        {
            ViewState["RegisterNo"] = value;
        }
    }


    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            DataBind();

            ClientIntial();
           
        }
    }

    protected override void OnInit(EventArgs e)
    {
        m_Registration = new RegistrationBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e)
    {
        m_Registration.Dispose();
        m_Registration = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind()
    {
        //using (ChargeBusiness Charge = new ChargeBusiness())
        //{
        //    int RecordCount = 0;
        //    ChargeRepeater.DataSource = Charge.GetCharges(Pager.CurrentPageIndex, Pager.PageSize, "", out RecordCount);
        //    Pager.RecordCount = RecordCount;
        //}
        base.DataBind();
    }
    /// <summary>
    /// 设置界面控件显示状态
    /// </summary>
    /// <param name="Enabled"></param>
    private void SetUIStatus(bool Enabled)
    {
        ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
        foreach (Control ctrl in Controls)
        {
            if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
        }
    }
    /// <summary>
    

    #endregion

    #region 私有成员

    private void ClientIntial()
    {

        SetRegistrationUI();

        //using (PartmentBusiness Partment = new PartmentBusiness())
        //{
        //    drpRegion.DataSource = Partment.GetPartments();
        //    drpRegion.DataValueField = "id";
        //    drpRegion.DataTextField = "name";
        //    drpRegion.DataBind();
        //}
        //using (HealthVocationBusiness Vocation = new HealthVocationBusiness())
        //{
        //    drpTrade.DataSource = Vocation.GetHealthVocations();
        //    drpTrade.DataValueField = "id";
        //    drpTrade.DataTextField = "name";
        //    drpTrade.DataBind();
        //}

        //using (CompanyTypeBusiness CompanyType = new CompanyTypeBusiness())
        //{
        //    drpNature.DataSource = CompanyType.GetCompanyTypes();
        //    drpNature.DataValueField = "id";
        //    drpNature.DataTextField = "name";
        //    drpNature.DataBind();
        //}

        //using (HealthPaperTypeBusiness HealthPaperType = new HealthPaperTypeBusiness())
        //{
        //    drpWorkType.DataSource = HealthPaperType.GetHealthPaperTypes();
        //    drpWorkType.DataValueField = "id";
        //    drpWorkType.DataTextField = "name";
        //    drpWorkType.DataBind();

        //}
    }

    /// <summary>
    /// 重置界面
    /// </summary>
    private void ClearRegistrationUI()
    {
        drpRegion.SelectedIndex = -1;
        drpTrade.SelectedIndex = -1;
        drpNature.SelectedIndex = -1;
        drpWorkType.SelectedIndex = -1;
        drpEducation.SelectedIndex = -1;
        drpSex.SelectedIndex = -1;
        txtBillNo.Text = "";
        txtPackageName.Text = "";
        txtCompanyName.Text = "";
        txtAddress.Text = "";
        txtName.Text = "";
        txtAge.Text = "";
        txtOperator.Text = UserName;
        txtRegDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
    }

   
        /// <summary>
    /// 填充界面
    /// </summary>
    private void SetRegistrationUI() {

        RegistrationViewEntity Result = m_Registration.GetRegistration(RegisterNo);
        if (Result == null) return;
       // PersonID = Result.PersonID.Value;
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
    }


    /// <summary>
    /// 填充缴费信息界面
    /// </summary>
    private void SetChargeUI()
    {
        //ChargeViewEntity Result = m_Charge.GetCharge(BillNo);
        //if (Result == null) return;
        //hDeptID.Value = Result.ChargeDeptID + "";
        //txtPayer.Text = Result.Payer;
        //hPackageID.Value = Result.PackageID + "";
        //txtPackageName.Text = Result.PackageName;
        //txtCheckNum.Text = Result.CheckNum + "";
        //txtCharge.Text = EnvShowFormater.GetNumberString(Result.Charge);
        //txtActualCharge.Text = EnvShowFormater.GetNumberString(Result.ActualCharge);
        //drpPaymentMethod.SelectedValue = Result.PaymentMethod;
        //txtPaymentDate.Text = EnvShowFormater.GetShortDate(Result.PaymentDate);
        //txtChargePerson.Text = Result.ChargePerson;
    }


    #endregion

    #region 事件

   
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e)
    {
        DataBind();
    }


    #endregion
}