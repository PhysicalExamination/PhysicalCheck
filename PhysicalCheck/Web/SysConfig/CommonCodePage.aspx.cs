using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;

/// <summary>
/// 
/// </summary>
public partial class SysConfig_CommonCodePage : BasePage {

    #region 私有成员

    private CommonCodeBusiness m_CommonCode;

    #endregion

    #region 属性

    private string Code {
        get {
            if (ViewState["CommonCode"] == null) return string.Empty;
            return (string)ViewState["CommonCode"];
        }
        set {
            ViewState["CommonCode"] = value;
        }
    }

    private string Category {
        get {
            if (ViewState["Category"] == null) return string.Empty;
            return (string)ViewState["Category"];
        }
        set {
            ViewState["Category"] = value;
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
        CommonCodeRepeater.DataSource = m_CommonCode.GetCommonCodes("003");
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
    /// 重置界面
    /// </summary>
    private void ClearCommonCodeUI() {
        txtCode.Text = "";
        txtName.Text = "";        
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetCommonCodeUI() {
        CommonCodeEntity Result = m_CommonCode.GetCommonCode(Code);
        if (Result == null) return;
        txtCode.Text = Result.Code;
        txtName.Text = Result.Name;        
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private CommonCodeEntity GetCommonCodeUI() {
        CommonCodeEntity Result = new CommonCodeEntity();
        Result.Code = txtCode.Text;
        Result.Name = txtName.Text;
        Result.Category = "003";
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveCommonCode_Click(object sender, EventArgs e) {
        CommonCodeEntity Result = GetCommonCodeUI();
        m_CommonCode.SaveCommonCode(Result);
        ShowMessage("数据保存成功!");
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewCommonCode_Click(object sender, EventArgs e) {
        ClearCommonCodeUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteCommonCode_Click(object sender, EventArgs e) {
        m_CommonCode.DeleteCommonCode(GetCommonCodeUI());
        ShowMessage("数据删除成功!");
        //int Succeed = m_CommonCode.DeleteCommonCode(GetCommonCodeUI());
        //if (Succeed > 0) ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditCommonCode_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelCommonCode_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void CommonCodeItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblCode = (Literal)e.Item.FindControl("lblCode");
            Code = lblCode.Text;           
            SetCommonCodeUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}
