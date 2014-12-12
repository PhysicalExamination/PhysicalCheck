using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;
using Common.FormatProvider;

public partial class SysConfig_PackagePage : BasePage {

    #region 私有成员

    private PackageBusiness m_Package;
    private readonly String[] Categorys = { "不分性别套餐","男士套餐","女士套餐","儿童套餐" };

    #endregion

    #region 属性

    private int PackageID {
        get {
            if (ViewState["PackageID"] == null) return int.MinValue;
            return (int)ViewState["PackageID"];
        }
        set {
            ViewState["PackageID"] = value;
            hValue.Value = value + "";
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
        m_Package = new PackageBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Package.Dispose();
        m_Package = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        List<PackageEntity> DataSource = m_Package.GetPackages(Pager.CurrentPageIndex, Pager.PageSize, out RecordCount);
        PackageRepeater.DataSource = DataSource;
        Pager.RecordCount = RecordCount;
        base.DataBind();
        if (DataSource.Count > 0) BindItemGroup(DataSource[0].PackageID.Value);
    }

    #endregion

    #region 受保护方法

    protected String GetCategory(object obj) {
        int Index = Convert.ToInt32(obj);
        if ((Index >= 0) && (Index <= 3)) return Categorys[Index];
        return "";
    }

    #endregion

    #region 私有成员

    private void BindItemGroup(int packageID) {
        int RecordCount = 0;
        ItemGroupRepeater.DataSource = m_Package.GetPackageGroups(Pager1.CurrentPageIndex,
        Pager1.PageSize, packageID, out RecordCount);
        Pager1.RecordCount = RecordCount;
        ItemGroupRepeater.DataBind();
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
    private void ClearPackageUI() {
        PackageID = int.MinValue;
        txtPackageName.Text = "";
        txtPrice.Text = "";
        drpCategorys.SelectedIndex = -1;
    }

    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetPackageUI() {
        PackageEntity Result = m_Package.GetPackage(PackageID);
        if (Result == null) return;
        txtPackageName.Text = Result.PackageName;
        txtPrice.Text = EnvShowFormater.GetNumberString(Result.Price);
        drpCategorys.SelectedValue = Result.Category;
        BindItemGroup(PackageID);
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private PackageEntity GetPackageUI() {
        PackageEntity Result = new PackageEntity();
        Result.PackageName = txtPackageName.Text;
        Result.Price = EnvConverter.ToDecimal(txtPrice.Text);
        Result.Category = drpCategorys.SelectedValue;
        Result.PackageID = PackageID;
        return Result;
    }


    #endregion

    #region 事件

    protected void btnSavePackage_Click(object sender, EventArgs e) {
        PackageEntity Result = GetPackageUI();
        m_Package.SavePackage(Result);
        PackageID = Result.PackageID.Value;
        ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewPackage_Click(object sender, EventArgs e) {
        ClearPackageUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeletePackage_Click(object sender, EventArgs e) {
        m_Package.DeletePackage(GetPackageUI());
        ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditPackage_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelPackage_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void PackageItemCommand(object source, RepeaterCommandEventArgs e) {
        Literal lblPackageID = (Literal)e.Item.FindControl("lblPackageID");
        PackageID = EnvConverter.ToInt32(lblPackageID.Text).Value;
        if (e.CommandName.ToLower() == "select") {
            SetPackageUI();
            SetUIState("Default");
            BindItemGroup(PackageID);
        }
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void Pager1_PageChanged(object source, EventArgs e) {
        BindItemGroup(PackageID);
    }


    #endregion
}