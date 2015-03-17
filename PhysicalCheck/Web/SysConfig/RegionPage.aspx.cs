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
public partial class SysConfig_RegionPage : BasePage {

    #region 私有成员

    private RegionBusiness m_Region;

    #endregion

    #region 属性

    private string RegionCode {
        get {
            if (ViewState["RegionCode"] == null) return string.Empty;
            return (string)ViewState["RegionCode"];
        }
        set {
            ViewState["RegionCode"] = value;
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
        m_Region = new RegionBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Region.Dispose();
        m_Region = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        RegionRepeater.DataSource = m_Region.GetRegions("620600000");
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
    private void ClearregionUI() {
        txtRegionCode.Text = "";
        txtRegionName.Text = "";
        txtSpell.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetregionUI() {
        RegionEntity Result = m_Region.GetRegion(RegionCode);
        if (Result == null) return;
        txtRegionCode.Text = Result.RegionCode;
        txtRegionName.Text = Result.RegionName;
        txtSpell.Text = Result.Spell;
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private RegionEntity GetregionUI() {
        RegionEntity Result = new RegionEntity();
        Result.RegionCode = txtRegionCode.Text;
        Result.RegionName = txtRegionName.Text;
        Result.Spell = txtSpell.Text;
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveRegion_Click(object sender, EventArgs e) {
        RegionEntity Result = GetregionUI();
        m_Region.SaveRegion(Result);
        ShowMessage("数据保存成功!");
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewRegion_Click(object sender, EventArgs e) {
        ClearregionUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteRegion_Click(object sender, EventArgs e) {
        m_Region.DeleteRegion(GetregionUI());
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

    protected void RegionItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblRegionCode = (Literal)e.Item.FindControl("lblRegionCode");
            RegionCode = lblRegionCode.Text;
            SetregionUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}
