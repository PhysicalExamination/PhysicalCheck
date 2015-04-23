using BusinessLogic.SysConfig;
using DataEntity.SysConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SysConfig_JobPage : BasePage {

    #region 私有成员

    private CommonCodeBusiness m_CommonCode;

    #endregion

    #region 属性

    private string CommonCode {
        get {
            if (ViewState["CommonCode"] == null) return string.Empty;
            return (string)ViewState["CommonCode"];
        }
        set {
            ViewState["CommonCode"] = value;
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
        m_CommonCode = new CommonCodeBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_CommonCode.Dispose();
        m_CommonCode = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        JobRepeater.DataSource = m_CommonCode.GetCommonCodes("003");
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
    }

    #endregion

    #region 私有成员

    /// <summary>
    /// 重置界面
    /// </summary>
    private void ClearUI() {
        txtCode.Text = "";
        txtName.Text = "";      
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetUI() {
        CommonCodeEntity Result = m_CommonCode.GetCommonCode(CommonCode);
        if (Result == null) return;
        txtCode.Text = Result.Code;
        txtName.Text = Result.Name;       
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private CommonCodeEntity GetUI() {
        CommonCodeEntity Result = new CommonCodeEntity();
        Result.Code = txtCode.Text;
        Result.Name = txtName.Text;
        Result.Category = "003";
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveRegion_Click(object sender, EventArgs e) {
        CommonCodeEntity Result = GetUI();
        m_CommonCode.SaveCommonCode(Result);
        ShowMessage("数据保存成功!");
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewRegion_Click(object sender, EventArgs e) {
        ClearUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteRegion_Click(object sender, EventArgs e) {
        m_CommonCode.DeleteCommonCode(GetUI());
        ShowMessage("数据删除成功!");
        //if (Succeed > 0) ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditRegion_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelRegion_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            CommonCode = (String)e.CommandArgument;
            SetUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}