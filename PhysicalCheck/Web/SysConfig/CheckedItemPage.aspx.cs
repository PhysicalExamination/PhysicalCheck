﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;
using Common.FormatProvider;
using BusinessLogic.Admin;

/// <summary>
/// 体检项目
/// </summary>
public partial class SysConfig_CheckedItemPage : BasePage {

    #region 私有成员

    private CheckedItemBusiness m_CheckedItem;

    #endregion

    #region 属性

    private int ItemID {
        get {
            if (ViewState["ItemID"] == null) return int.MinValue;
            return (int)ViewState["ItemID"];
        }
        set {
            ViewState["ItemID"] = value;
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
        m_CheckedItem = new CheckedItemBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_CheckedItem.Dispose();
        m_CheckedItem = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        int DeptID = Convert.ToInt32(drpDepts.SelectedValue);
        CheckedItemRepeater.DataSource = m_CheckedItem.GetCheckedItems(Pager.CurrentPageIndex,
            Pager.PageSize, DeptID, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }
  
    #endregion

    #region 私有成员

    private void ClientInitial() {
        using (DepartmentBusiness Department = new DepartmentBusiness()) {
            int RecordCount = 0;
            drpDepts.DataSource = Department.GetDepartments(1, 100, out RecordCount);
            drpDepts.DataValueField = "DeptID";
            drpDepts.DataTextField = "DeptName";
            drpDepts.DataBind();
        }
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


    /// <summary>
    /// 重置界面
    /// </summary>
    private void ClearCheckedItemUI() {
        ItemID = int.MinValue;
        txtItemName.Text = "";
        txtDeptID.Text = "";
        txtMeasureUnit.Text = "";
        txtLowerLimit.Text = "";
        txtUpperLimit.Text = "";
        txtNormalTips.Text = "";
        txtLowerTips.Text = "";
        txtUpperTips.Text = "";
        txtSex.Text = "";
        chkIsSummary.Checked = false;    
    }

    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetCheckedItemUI() {
        CheckedItemEntity Result = m_CheckedItem.GetCheckedItem(ItemID);
        if (Result == null) return;
        ItemID = Result.ItemID.Value;
        txtItemName.Text = Result.ItemName;
        txtDeptID.Text = Result.DeptID + "";
        txtMeasureUnit.Text = Result.MeasureUnit;
        txtLowerLimit.Text = Result.LowerLimit;
        txtUpperLimit.Text = Result.UpperLimit;
        txtNormalTips.Text = Result.NormalTips;
        txtLowerTips.Text = Result.LowerTips;
        txtUpperTips.Text = Result.UpperTips;
        txtSex.Text = Result.Sex;
        chkIsSummary.Checked = false;
        if (Result.IsSummary.HasValue) chkIsSummary.Checked = Result.IsSummary.Value;
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private CheckedItemEntity GetCheckedItemUI() {
        CheckedItemEntity Result = new CheckedItemEntity();
        Result.ItemID = ItemID;
        Result.ItemName = txtItemName.Text;
        Result.DeptID = EnvConverter.ToInt32(txtDeptID.Text);
        Result.MeasureUnit = txtMeasureUnit.Text;
        Result.LowerLimit = txtLowerLimit.Text;
        Result.UpperLimit = txtUpperLimit.Text;
        Result.NormalTips = txtNormalTips.Text;
        Result.LowerTips = txtLowerTips.Text;
        Result.UpperTips = txtUpperTips.Text;
        Result.Sex = txtSex.Text;
        Result.IsSummary = chkIsSummary.Checked;
        return Result;
    }

    #endregion

    #region 事件

    protected void btnSaveCheckedItem_Click(object sender, EventArgs e) {
        CheckedItemEntity Result = GetCheckedItemUI();
        m_CheckedItem.SaveCheckedItem(Result);
        //int Succeed = m_CheckedItem.SaveCheckedItem(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewCheckedItem_Click(object sender, EventArgs e) {
        ClearCheckedItemUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteCheckedItem_Click(object sender, EventArgs e) {
        m_CheckedItem.DeleteCheckedItem(GetCheckedItemUI());
        //int Succeed = m_CheckedItem.DeleteCheckedItem(GetCheckedItemUI());
        //if (Succeed > 0) ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditCheckedItem_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelCheckedItem_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void CheckedItemItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblItemID = (Literal)e.Item.FindControl("lblItemID");
            ItemID = Convert.ToInt32(lblItemID.Text);
            SetCheckedItemUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}