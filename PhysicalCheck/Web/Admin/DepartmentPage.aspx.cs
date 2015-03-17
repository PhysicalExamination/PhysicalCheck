using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Admin;
using DataEntity.Admin;
using Common.FormatProvider;

public partial class Admin_DepartmentPage : BasePage {

	#region 私有成员

    private readonly String[] Categorys = { "检查科室", "检验科室", "功能科室" };

	private DepartmentBusiness m_Dept;
	

	#endregion

	#region 属性

	private int? DeptNo {
		get {
			if (ViewState["DeptNo"] == null) return null;
			return (int)ViewState["DeptNo"];
		}
		set {
			ViewState["DeptNo"] = value;
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
		m_Dept = new DepartmentBusiness();
		base.OnInit(e);
	}

	protected override void OnUnload(EventArgs e) {
        m_Dept.Dispose();
        m_Dept = null;
		base.OnUnload(e);
	}

	/// <summary>
	/// 检查科室数据绑定
	/// </summary>
	public override void DataBind() {
        int RecordCount = 0;
		DepartmentRepeater.DataSource = m_Dept.GetDepartments(Pager.CurrentPageIndex,Pager.PageSize,out RecordCount);
        Pager.RecordCount = RecordCount;
		base.DataBind();
	}
	/// <summary>
    /// 设置检查科室界面控件显示状态
	/// </summary>
	/// <param name="Enabled"></param>
	private void SetUIStatus(bool Enabled) {
		ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
		foreach (Control ctrl in Controls) {
			if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
		}
	}

	/// <summary>
    /// 设置检查科室界面按钮显示状态
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

    #region 受保护方法

    protected String GetDeptCategory(Object Category) {
        int index =Convert.ToInt32(Category);
        if ((index >= 0) && (index <= 2)) return Categorys[index];
        return "";
    }
    #endregion

    #region 私有成员

    /// <summary>
    /// 重置检查科室界面
	/// </summary>
	private void ClearUserUI() {
		DeptNo = int.MinValue;
		txtDeptName.Text = "";
        drpDeptKind.SelectedIndex = -1;
        txtDepLlocation.Text = "";
	}
	/// <summary>
    /// 填充检查科室界面
	/// </summary>
	private void SetUserUI() {
		DepartmentEntity Result = m_Dept.GetDepartment(DeptNo.Value);
		if (Result == null) return;
		DeptNo = Result.DeptID.Value;
		txtDeptName.Text = Result.DeptName;
        drpDeptKind.SelectedValue = Result.DeptKind;
        txtDepLlocation.Text = Result.DepLlocation;
	}

	/// <summary>
    /// 从界面获取检查科室对象
	/// </summary>
	/// <returns></returns>
	private DepartmentEntity GetUserUI() {
		DepartmentEntity Result = new DepartmentEntity();
		Result.DeptID = DeptNo;
		Result.DeptName = txtDeptName.Text.Trim();
        Result.DeptKind = drpDeptKind.SelectedValue;
        Result.DepLlocation = txtDepLlocation.Text;
		return Result;
	}

	#endregion

	#region 事件

	protected void btnSaveUser_Click(object sender, EventArgs e) {
		DepartmentEntity Result = GetUserUI();		
		int Succeed = m_Dept.SaveDepartment(Result);
		if (Succeed > 0) ShowMessage("检查科室数据保存成功!");
		if (Succeed < 0) ShowMessage("检查科室数据保存失败!");
		DataBind();
		SetUIState("Default");
	}

	protected void btnNewUser_Click(object sender, EventArgs e) {
		ClearUserUI();
		btnSave.Enabled = CanEditData;
		SetUIState("New");
	}

	protected void btnDeleteUser_Click(object sender, EventArgs e) {
		int Succeed = m_Dept.DeleteDepartment(GetUserUI());
		if (Succeed > 0) ShowMessage("检查科室数据删除成功!");
		if (Succeed < 0) ShowMessage("检查科室数据删除失败!");
		DataBind();
		SetUIState("Default");
	}
	protected void btnEditUser_Click(object sender, EventArgs e) {
		SetUIState("Edit");
	}

	protected void btnCancelUser_Click(object sender, EventArgs e) {
		SetUIState("Default");
	}

	protected void btnSearch_Click(object sender, EventArgs e) {
		DataBind();
	}

	protected void UserItemCommand(object source, RepeaterCommandEventArgs e) {
		if (e.CommandName.ToLower() == "select") {
			Literal lblDeptNo = (Literal)e.Item.FindControl("lblDeptNo");
			DeptNo = EnvConverter.ToInt32(lblDeptNo.Text);
			SetUserUI();
			SetUIState("Default");
		}
	}

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

	#endregion
}