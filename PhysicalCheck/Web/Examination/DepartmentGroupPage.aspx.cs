using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using DataEntity.Examination;
using Common.FormatProvider;

public partial class Examination_DepartmentGroupPage : BasePage {

    #region 私有成员

    private DepartmentGroupBusiness m_DeptGroup;

    #endregion

    #region 属性

    private int DeptID {
        get {
            if (ViewState["DeptID"] == null) return int.MinValue;
            return (int)ViewState["DeptID"];
        }
        set {
            ViewState["DeptID"] = value;
        }
    }

    private int GroupID {
        get {
            if (ViewState["GroupID"] == null) return int.MinValue;
            return (int)ViewState["GroupID"];
        }
        set {
            ViewState["GroupID"] = value;
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
        m_DeptGroup = new DepartmentGroupBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_DeptGroup.Dispose();
        m_DeptGroup = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        using (PhysicalDepartmentBusiness Department = new PhysicalDepartmentBusiness()) {
            int RecordCount = 0;
            String DeptName = txtSearch.Text.Trim();
            IList<PhysicalDepartmentEntity> DataSource = Department.GetPhysicalDepartments(Pager.CurrentPageIndex,
                 Pager.PageSize, DeptName, out RecordCount);            
            DepartmentRepeater.DataSource = DataSource;
            Pager.RecordCount = RecordCount;
            if (DataSource.Count > 0) BindDepartmentGroup(DataSource[0].DeptID.Value);
            if (DataSource.Count <= 0) BindDepartmentGroup(DeptID);
        }
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

    #endregion

    #region 私有成员

    private void BindDepartmentGroup(int DeptID) {
        GroupRepeater.DataSource = m_DeptGroup.GetDepartmentGroups(DeptID);
        GroupRepeater.DataBind();
    }

    /// <summary>
    /// 设置界面控件显示状态
    /// </summary>
    /// <param name="Enabled"></param>
    private void SetUIStatus(bool Enabled) {
        ControlCollection Controls = UP3.ContentTemplateContainer.Controls;
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
    private void ClearDepartmentGroupUI() {
        GroupID = int.MinValue;
        txtGroupName.Text = "";
        drpSex.SelectedIndex = -1;
        chkIsChildren.Checked = false;
        txtDuty.Text = "";
        txtPosition.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetDepartmentGroupUI() {
        DepartmentGroupViewEntity Result = m_DeptGroup.GetDepartmentGroup(DeptID, GroupID);
        if (Result == null) return;
        txtGroupName.Text = Result.GroupName;
        drpSex.SelectedValue = Result.Sex;
        chkIsChildren.Checked = false;
        if (Result.IsChildren.HasValue) chkIsChildren.Checked = Result.IsChildren.Value;
        txtDuty.Text = Result.Duty;
        txtPosition.Text = Result.Position;
        txtPackageName.Text = Result.PackageName;
        hPackageID.Value = Result.PackageID + "";
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private DepartmentGroupEntity GetDepartmentGroupUI() {
        DepartmentGroupEntity Result = new DepartmentGroupEntity();
        DepartmentGroupPK ID = new DepartmentGroupPK { DeptID = DeptID, GroupID = GroupID };
        Result.ID = ID;
        Result.GroupName = txtGroupName.Text;
        Result.Sex = drpSex.SelectedValue;
        Result.IsChildren = chkIsChildren.Checked;
        Result.Duty = txtDuty.Text;
        Result.Position = txtPosition.Text;
        Result.PackageID = EnvConverter.ToInt32(hPackageID.Value);
        return Result;
    }

    #endregion

    #region 事件

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void btnSaveGroup_Click(object sender, EventArgs e) {
        DepartmentGroupEntity Result = GetDepartmentGroupUI();
        m_DeptGroup.SaveDepartmentGroup(Result);
        ShowMessage("单位分组数据保存成功!");
        //int Succeed = m_DeptGroup.SaveDepartmentGroup(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        //DataBind();
        BindDepartmentGroup(DeptID);
        SetUIState("Default");
    }

    protected void btnNewGroup_Click(object sender, EventArgs e) {
        ClearDepartmentGroupUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteGroup_Click(object sender, EventArgs e) {
        m_DeptGroup.DeleteDepartmentGroup(GetDepartmentGroupUI());
        ShowMessage("单位分组数据删除成功!");
        BindDepartmentGroup(DeptID);
        //int Succeed = m_DeptGroup.DeleteDepartmentGroup(GetDepartmentGroupUI());
        //if (Succeed > 0) ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        //DataBind();
        SetUIState("Default");
    }
    protected void btnEditGroup_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelGroup_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void DepartmentItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblDeptID = (Literal)e.Item.FindControl("lblDeptID");
            DeptID = Convert.ToInt32(lblDeptID.Text);
            BindDepartmentGroup(DeptID);
        }
    }

    protected void GroupItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblGroupID = (Literal)e.Item.FindControl("lblGroupID");
            GroupID = Convert.ToInt32(lblGroupID.Text);
            SetUIState("Default");
            SetDepartmentGroupUI();
        }
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    #endregion
}