using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Admin;
using DataEntity.Admin;

public partial class Admin_RolePage : BasePage {

	#region 私有成员

	private RoleBusiness m_Role;

	#endregion

	#region 属性

	private string RoleNo {
		get {
			if (ViewState["RoleNo"] == null) return string.Empty;
			return (string)ViewState["RoleNo"];
		}
		set {
			ViewState["RoleNo"] = value;
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
		m_Role = new RoleBusiness();
		base.OnInit(e);
	}

	protected override void OnUnload(EventArgs e) {
		m_Role.Dispose();
		m_Role = null;
		base.OnUnload(e);
	}

	/// <summary>
	/// 系统角色数据绑定
	/// </summary>
	public override void DataBind() {
		RoleDataList.DataSource = m_Role.GetRoles();
		base.DataBind();
		Literal lblRoleNo;
		Button btnDetail;
		foreach (RepeaterItem Item in RoleDataList.Items) {
			lblRoleNo = (Literal)Item.FindControl("lblRoleNo");
			btnDetail = (Button)Item.FindControl("btnDetail");
			btnDetail.Attributes.Add("onclick", String.Format("onSelected(1,\"{0}\");",lblRoleNo.Text));			
		}
	}


	#endregion

	#region 私有成员

	private void BindRoleMember() {
		RoleMemberList.DataSource = m_Role.GetRoleMembers(RoleNo);
		RoleMemberList.DataBind();
	}

	private void BindUserList() {
		using (SysUserBusiness user = new SysUserBusiness()) {
			if (IsAdmin) UserList.DataSource = user.GetSysUsers();			
			UserList.DataBind();
		}
	}

	/// <summary>
	/// 设置系统角色界面控件显示状态
	/// </summary>
	/// <param name="Enabled"></param>
	private void SetUIStatus(bool Enabled) {
		ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
		foreach (Control ctrl in Controls) {
			if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
		}
	}
	/// <summary>
	/// 设置系统角色界面按钮显示状态
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
		//if (!IsAdmin) {
		//    SetUIStatus(false);
		//    btnNew.Enabled = false;
		//    btnEdit.Enabled = false;
		//    btnDelete.Enabled = false;
		//    btnSave.Enabled = false;
		//}
	}

	/// <summary>
	/// 重置系统角色界面
	/// </summary>
	private void ClearRoleUI() {
		RoleNo = "";
		txtRoleName.Text = "";
		txtDescription.Text = "";
		txtOrderNo.Text = "";
	}

	/// <summary>
	/// 填充系统角色界面
	/// </summary>
	private void SetRoleUI() {
		RoleEntity Result = m_Role.GetRole(RoleNo);
		if (Result == null) return;
		RoleNo = Result.RoleNo;
		txtRoleName.Text = Result.RoleName;
		txtDescription.Text = Result.Description;
		txtOrderNo.Text = Result.OrderNo + "";
	}

	/// <summary>
	/// 从界面获取系统角色对象
	/// </summary>
	/// <returns></returns>
	private RoleEntity GetRoleUI() {
		RoleEntity Result = new RoleEntity();
		Result.RoleNo = RoleNo;
		Result.RoleName = txtRoleName.Text;
		Result.Description = txtDescription.Text;
		Result.OrderNo = Convert.ToInt32(txtOrderNo.Text);
		return Result;
	}

	#endregion

	#region 事件

	protected void btnSaveRole_Click(object sender, EventArgs e) {
		RoleEntity Result = GetRoleUI();
		int Succeed = m_Role.SaveRole(Result);
		if (Succeed > 0) ShowMessage("系统角色数据保存成功!");
		if (Succeed < 0) ShowMessage("系统角色数据保存失败!");
		RoleNo = Result.RoleNo;
		DataBind();		
		SetUIState("Default");
	}

	protected void btnNewRole_Click(object sender, EventArgs e) {
		ClearRoleUI();
		btnSave.Enabled = CanEditData;
		SetUIState("New");
	}

	protected void btnDeleteRole_Click(object sender, EventArgs e) {
		int Succeed = m_Role.DeleteRole(GetRoleUI());
		if (Succeed > 0) ShowMessage("系统角色数据删除成功!");
		if (Succeed < 0) ShowMessage("系统角色数据删除失败!");
		DataBind();
		SetUIState("Default");
	}

	protected void btnEditRole_Click(object sender, EventArgs e) {
		SetUIState("Edit");
	}

	protected void btnCancelRole_Click(object sender, EventArgs e) {
		SetUIState("Default");
	}

	protected void RoleItemCommand(object source, RepeaterCommandEventArgs e) {
		if (e.CommandName.ToLower() == "select") {
			Literal lblRoleNo = (Literal)e.Item.FindControl("lblRoleNo");
			RoleNo = lblRoleNo.Text;		
			SetRoleUI();
			BindRoleMember();
			BindUserList();
			SetUIState("Default");
		}
	}

	/// <summary>
	/// 添加角色成员
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void UserList_OnItemCommand(object sender, RepeaterCommandEventArgs e) {
		if (String.IsNullOrEmpty(RoleNo)) {
			ShowMessage("请在角色列表中选择一个角色！");
			return;
		}
		string userNo = (string)e.CommandArgument;
		RoleMemberEntity roleMember = new RoleMemberEntity();
		roleMember.RoleNo = RoleNo;
		roleMember.UserNo = userNo;
		m_Role.SaveRoleMember(roleMember);
		BindRoleMember();
	}

	/// <summary>
	/// 移除角色成员
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void RoleMemberList_OnItemCommand(object sender, RepeaterCommandEventArgs e) {
		string userNo = (string)e.CommandArgument;
		RoleMemberEntity roleMember = new RoleMemberEntity();
		roleMember.RoleNo = RoleNo;
		roleMember.UserNo = userNo;
		m_Role.DeleteRoleMember(roleMember);
		BindRoleMember();
	}

	#endregion
}