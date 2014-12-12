using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;

public partial class SysConfig_HospitalPage : BasePage {

    #region 私有成员

    private HospitalBusiness m_Hospital;

    #endregion

    #region 属性

    private int HospitalID {
        get {
            if (ViewState["HospitalID"] == null) return -1;
            return (int)ViewState["HospitalID"];
        }
        set {
            ViewState["HospitalID"] = value;
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
        m_Hospital = new HospitalBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Hospital.Dispose();
        m_Hospital = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        //HospitalRepeater.DataSource = m_Hospital.GetHospitals();
        base.DataBind();
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
            //btnNew.Enabled = CanEditData;
            btnEdit.Enabled = CanEditData;
            //btnDelete.Enabled = CanEditData;
            btnSave.Enabled = false;
        }
        if (State == "New") {
            SetUIStatus(true);
            //btnNew.Enabled = false;
            btnEdit.Enabled = false;
            //btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        if (State == "Edit") {
            SetUIStatus(true);
            //btnNew.Enabled = false;
            btnEdit.Enabled = false;
            //btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
    }

    #endregion

    #region 私有成员

    /// <summary>
    /// 重置界面
    /// </summary>
    private void ClearHospitalUI() {        
        txtHospitalName.Text = "";
        txtLinkTel.Text = "";
        txtFax.Text = "";
        txtPostCode.Text = "";
        txtWebsite.Text = "";
        txtAddress.Text = "";
        txtBlog.Text = "";
        txtWeChat.Text = "";
        txtLogo.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetHospitalUI() {
        HospitalEntity Result = m_Hospital.GetHospital(HospitalID);
        if (Result == null) return;      
        txtHospitalName.Text = Result.HospitalName;
        txtLinkTel.Text = Result.LinkTel;
        txtFax.Text = Result.Fax;
        txtPostCode.Text = Result.PostCode;
        txtWebsite.Text = Result.Website;
        txtAddress.Text = Result.Address;
        txtBlog.Text = Result.Blog;
        txtWeChat.Text = Result.WeChat;
        txtLogo.Text = Result.Logo;
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private HospitalEntity GetHospitalUI() {
        HospitalEntity Result = new HospitalEntity();
        Result.HospitalID = HospitalID;
        Result.HospitalName = txtHospitalName.Text;
        Result.LinkTel = txtLinkTel.Text;
        Result.Fax = txtFax.Text;
        Result.PostCode = txtPostCode.Text;
        Result.Website = txtWebsite.Text;
        Result.Address = txtAddress.Text;
        Result.Blog = txtBlog.Text;
        Result.WeChat = txtWeChat.Text;
        Result.Logo = txtLogo.Text;
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveHospital_Click(object sender, EventArgs e) {
        HospitalEntity Result = GetHospitalUI();
        m_Hospital.SaveHospital(Result);
        //int Succeed = m_Hospital.SaveHospital(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    
    protected void btnEditHospital_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelHospital_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    #endregion
}