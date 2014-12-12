using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;
using Common.FormatProvider;

public partial class SysConfig_IndustryPage : BasePage {

    #region 私有成员

    private IndustryBusiness m_Industry;

    #endregion

    #region 属性

    private int IndustryID {
        get {
            if (ViewState["IndustryID"] == null) return -1;
            return (int)ViewState["IndustryID"];
        }
        set {
            ViewState["IndustryID"] = value;
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
        m_Industry = new IndustryBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Industry.Dispose();
        m_Industry = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        IndustryRepeater.DataSource = m_Industry.GetIndustrys();
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
    private void ClearIndustryUI() {
        IndustryID = -1;
        txtIndustryName.Text = "";
        txtValidity.Text = "";      
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetIndustryUI() {
        IndustryEntity Result = m_Industry.GetIndustry(IndustryID);
        if (Result == null) return;
        txtIndustryName.Text = Result.IndustryName;
        txtValidity.Text = Result.Validity + "";
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private IndustryEntity GetIndustryUI() {
        IndustryEntity Result = new IndustryEntity();
        Result.IndustryID = IndustryID;
        Result.IndustryName = txtIndustryName.Text;
        Result.Validity = EnvConverter.ToInt32(txtValidity.Text);
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveIndustry_Click(object sender, EventArgs e) {
        IndustryEntity Result = GetIndustryUI();
        m_Industry.SaveIndustry(Result);        
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewIndustry_Click(object sender, EventArgs e) {
        ClearIndustryUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteIndustry_Click(object sender, EventArgs e) {
        m_Industry.DeleteIndustry(GetIndustryUI());
        //int Succeed = m_Industry.DeleteIndustry(GetIndustryUI());
        //if (Succeed > 0) ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditIndustry_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelIndustry_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void IndustryItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblIndustryID = (Literal)e.Item.FindControl("lblIndustryID");
            IndustryID = Convert.ToInt32(lblIndustryID.Text);           
            SetIndustryUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}