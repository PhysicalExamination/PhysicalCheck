using BusinessLogic.Admin;
using DataEntity.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ContentPage : BasePage {

    #region 属性

    protected String CertificatePage {
        get {
            if (ViewState["CertificatePage"] == null) return "#";
            return (String)ViewState["CertificatePage"];
        }
        set {
            ViewState["CertificatePage"] = value;
        }
    }

    protected String ChargePage {
        get {
            if (ViewState["ChargePage"] == null) return "#";
            return (String)ViewState["ChargePage"];
        }
        set {
            ViewState["ChargePage"] = value;
        }
    }

    /// <summary>
    /// 体检登记
    /// </summary>
    protected String RegistrationPage {
        get {
            if (ViewState["RegistrationPage"] == null) return "#";
            return (String)ViewState["RegistrationPage"];
        }
        set {
            ViewState["RegistrationPage"] = value;
        }
    }

    /// <summary>
    /// 体检结果录入
    /// </summary>
    protected String CheckResultInputPage {
        get {
            if (ViewState["CheckResultInputPage"] == null) return "#";
            return (String)ViewState["CheckResultInputPage"];
        }
        set {
            ViewState["CheckResultInputPage"] = value;
        }
    }

    /// <summary>
    /// 体检总检
    /// </summary>
    protected String OverallCheckedPage {
        get {
            if (ViewState["OverallCheckedPage"] == null) return "#";
            return (String)ViewState["OverallCheckedPage"];
        }
        set {
            ViewState["OverallCheckedPage"] = value;
        }
    }

    /// <summary>
    /// 综合查询
    /// </summary>
    protected String IntegratedSearch {
        get {
            if (ViewState["IntegratedSearch"] == null) return "#";
            return (String)ViewState["IntegratedSearch"];
        }
        set {
            ViewState["IntegratedSearch"] = value;
        }
    }

    /// <summary>
    /// 体检报告
    /// </summary>
    protected String CheckReport {
        get {
            if (ViewState["CheckReport"] == null) return "#";
            return (String)ViewState["CheckReport"];
        }
        set {
            ViewState["CheckReport"] = value;
        }
    }

    /// <summary>
    /// 条码打印
    /// </summary>
    protected String BarCodePrint {
        get {
            if (ViewState["BarCodePrint"] == null) return "#";
            return (String)ViewState["BarCodePrint"];
        }
        set {
            ViewState["BarCodePrint"] = value;
        }
    }

    /// <summary>
    /// 指引单打印
    /// </summary>
    protected String IntroductionPrint {
        get {
            if (ViewState["IntroductionPrint"] == null) return "#";
            return (String)ViewState["IntroductionPrint"];
        }
        set {
            ViewState["IntroductionPrint"] = value;
        }
    }

    
    

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            ClientInitial();
        }
    }

    private void ClientInitial() {
        if (IsAdmin) {
            ChargePage = "Examination/ChargePage.aspx";
            RegistrationPage = "Examination/RegistrationPage.aspx";
            CheckResultInputPage = "Examination/CheckResultInputPage.aspx";
            OverallCheckedPage = "Examination/OverallCheckedPage.aspx";
            CertificatePage = " Examination/CertificatePage.aspx";
            IntegratedSearch = "search/customerArchiveList.aspx";
            CheckReport = "Examination/ExaminationReportPage.aspx";
            BarCodePrint = "Examination/BarCodePrintPage.aspx";
            IntroductionPrint = "Examination/IntroductionPage.aspx";
            return;
        }
        using (SysUserBusiness SysUser = new SysUserBusiness()) {           
            if (SysUser.HasModulePermit(UserAccount, "00040")) ChargePage = "Examination/ChargePage.aspx";                      
            if (SysUser.HasModulePermit(UserAccount, "00041")) RegistrationPage = "Examination/RegistrationPage.aspx";
            if (SysUser.HasModulePermit(UserAccount, "00042")) CheckResultInputPage = "Examination/CheckResultInputPage.aspx";
            if (SysUser.HasModulePermit(UserAccount, "00049")) OverallCheckedPage = "Examination/OverallCheckedPage.aspx";
            if (SysUser.HasModulePermit(UserAccount, "00045")) CertificatePage = " Examination/CertificatePage.aspx";
            if (SysUser.HasModulePermit(UserAccount, "6")) IntegratedSearch = "search/customerArchiveList.aspx";
            if (SysUser.HasModulePermit(UserAccount, "00043")) CheckReport = "Examination/ExaminationReportPage.aspx";
            if (SysUser.HasModulePermit(UserAccount, "00048")) BarCodePrint = "Examination/BarCodePrintPage.aspx";
            if (SysUser.HasModulePermit(UserAccount, "00044")) IntroductionPrint = "Examination/IntroductionPage.aspx";          
        }
    }

    #endregion
}