using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using Common.FormatProvider;
using DataEntity.Examination;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;

public partial class Examination_CheckResultInputPage : BasePage {

    #region 私有成员

    //private ItemResultBusiness m_ItemResult;
    private GroupResultBusiness m_GroupResut;
    private RegistrationBusiness m_Regist;

    private int? PackageID {
        get {
            if (ViewState["PackageID"] == null) {
                using (RegistrationBusiness Registration = new RegistrationBusiness()) {
                    String RegisterNo = txtsRegisterNo.Text.Trim();
                    ViewState["PackageID"] = Registration.GetRegistration(RegisterNo).PackageID;
                }
            }
            return (int?)ViewState["PackageID"];
        }
    }

    protected bool InputEnabled {
        get {
            if (ViewState["InputEnabled"] == null) return true;
            return (bool)ViewState["InputEnabled"];
        }
        set {
            ViewState["InputEnabled"] = value;
        }
    }

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();
        }
    }

    protected override void OnInit(EventArgs e) {

        m_GroupResut = new GroupResultBusiness();
        m_Regist = new RegistrationBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {

        m_GroupResut.Dispose();
        m_GroupResut = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        if (txtsRegisterNo.Text.Trim() != "") {
            RegistrationViewEntity en = m_Regist.GetRegistration(txtsRegisterNo.Text.Trim());
            if (en != null && en.IsCheckOver) {
                ShowMessage("此登记号已经体检完毕。");
                return;
            }
        }
        String RegisterNo = txtsRegisterNo.Text.Trim();
        ItemResultRepeater.DataSource = m_GroupResut.GetGroupResults(RegisterNo);
        base.DataBind();
    }

    #endregion

    #region 事件



    protected void btnSearch_Click(object sender, EventArgs e) {

        DataBind();
    }


    #endregion

    #region 私有方法



    #endregion


}