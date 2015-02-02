using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;
using Common.FormatProvider;

/// <summary>
/// 组合项目
/// </summary>
public partial class SysConfig_ItemGroupPage : BasePage {

    #region 私有成员

    private readonly String[] CheckCategorys = { "检验项目", "医生检查", "功能检查" };
    private ItemGroupBusiness m_ItemGroup;

    #endregion

    #region 属性

    private int GroupID {
        get {
            if (ViewState["GroupID"] == null) return -1;
            return (int)ViewState["GroupID"];
        }
        set {
            ViewState["GroupID"] = value;
            hValue.Value = value + "";
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
        m_ItemGroup = new ItemGroupBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_ItemGroup.Dispose();
        m_ItemGroup = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        List<ItemGroupViewEntity> DataSource = m_ItemGroup.GetItemGroups(Pager.CurrentPageIndex,
            Pager.PageSize, out RecordCount);
        Pager.RecordCount = RecordCount;
        ItemGroupRepeater.DataSource = DataSource;
        if (DataSource.Count > 0) BindCheckedItem(DataSource[0].GroupID.Value);
        base.DataBind();
    }


    #endregion

    #region 受保护方法

    protected String GetSex(Object obj) {
        String val = (String)obj;
        if (val == "%") return "不限";
        if (val == "0") return "女";
        if (val == "1") return "男";
        return "";
    }

    protected String GetCategory(Object obj) {
        int Index = Convert.ToInt32(obj);
        if ((Index >= 0) && (Index <= 2)) return CheckCategorys[Index];
        return "";
    }

    #endregion

    #region 私有成员

    private void ClientInitial() {
        //drpSpecimen
        using (CommonCodeBusiness Business = new CommonCodeBusiness()) {
            List<CommonCodeEntity> List = Business.GetCommonCodes("001");
            var q = from p in List
                    select new ListItem { Value = p.Code, Text = p.Name };
            drpSpecimen.Items.Add("");
            drpSpecimen.Items.AddRange(q.ToArray());
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
    private void ClearItemGroupUI() {
        GroupID = int.MinValue;
        txtGroupName.Text = "";
        hDeptID.Value = "";
        drpCheckCategory.SelectedIndex = -1;
        drpSex.SelectedIndex = -1;
        txtPrice.Text = "0.00";
        txtNotice.Text = "";
        txtClinical.Text = "";
        txtNormalDesc.Text = "";
        chkHasSpecimen.Checked = false;
        drpSpecimen.SelectedIndex = -1;
        drpResultMode.SelectedIndex = -1;
        txtLisCode.Text = "";
        txtPacsCode.Text = "";
        //txtDisplayOrder.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetItemGroupUI() {
        ItemGroupViewEntity Result = m_ItemGroup.GetItemGroup(GroupID);
        if (Result == null) return;
        txtGroupName.Text = Result.GroupName;
      

        hDeptID.Value = Result.DeptID + "";
        txtDeptName.Text = Result.DeptName;
        drpCheckCategory.SelectedValue = Result.CheckCategory;
        drpSex.SelectedValue = Result.Sex;
        txtPrice.Text = EnvShowFormater.GetNumberString(Result.Price);
        txtNotice.Text = Result.Notice;
        txtClinical.Text = Result.Clinical;
        txtNormalDesc.Text = Result.NormalDesc;
        drpSpecimen.SelectedValue = Result.Specimen;
        drpResultMode.SelectedValue = Result.ResultMode;
        chkHasBarCode.Checked = Result.HasBarCode;
        txtLisCode.Text = Result.lisCode;
        txtPacsCode.Text = Result.pacsCode;
        //txtDisplayOrder.Text = Result.DisplayOrder + "";
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private ItemGroupEntity GetItemGroupUI() {
        ItemGroupEntity Result = new ItemGroupEntity();
        Result.GroupID = GroupID;
        Result.GroupName = txtGroupName.Text;
        Result.DeptID = EnvConverter.ToInt32(hDeptID.Value);
        Result.CheckCategory = drpCheckCategory.SelectedValue;
        Result.Sex = drpSex.SelectedValue;
        Result.Price = EnvConverter.ToDecimal(txtPrice.Text);
        Result.Notice = txtNotice.Text;
        Result.Clinical = txtClinical.Text;
        Result.NormalDesc = txtNormalDesc.Text;
        Result.Specimen = drpSpecimen.SelectedValue;
        Result.ResultMode = drpResultMode.SelectedValue;
        Result.HasBarCode = chkHasBarCode.Checked;
        Result.lisCode = txtLisCode.Text;
        Result.pacsCode = txtPacsCode.Text;

        //Result.DisplayOrder = EnvConverter.ToInt32(txtDisplayOrder.Text);
        return Result;
    }

    private void BindCheckedItem(int GroupID) {
        int RecordCount = 0;
        CheckedItemRepeater.DataSource = m_ItemGroup.GetItemGroupDetails(Pager1.CurrentPageIndex,
            Pager1.PageSize, GroupID, out RecordCount);
        Pager1.RecordCount = RecordCount;
        CheckedItemRepeater.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSaveItemGroup_Click(object sender, EventArgs e) {
        ItemGroupEntity Result = GetItemGroupUI();
        m_ItemGroup.SaveItemGroup(Result);
       // GroupID = Result.GroupID.Value;
        ShowMessage("组合项目数据保存成功!");
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewItemGroup_Click(object sender, EventArgs e) {
        ClearItemGroupUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteItemGroup_Click(object sender, EventArgs e) {
        m_ItemGroup.DeleteItemGroup(GetItemGroupUI());
        ShowMessage("组合项目数据删除成功!");
        //if (Succeed > 0) ShowMessage("组合项目数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditItemGroup_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelItemGroup_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemGroupItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblGroupID = (Literal)e.Item.FindControl("lblGroupID");
            GroupID = Convert.ToInt32(lblGroupID.Text);

            SetItemGroupUI();
            SetUIState("Default");
            BindCheckedItem(GroupID);
        }
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void Pager1_PageChanged(object source, EventArgs e) {
        BindCheckedItem(GroupID);
    }


    #endregion
}