using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using DataEntity.Admin;
using BusinessLogic.Admin;
using Common.FormatProvider;

public partial class Admin_SysUserPage : BasePage {

	#region 私有成员

	private SysUserBusiness m_User;
	//private bool m_UserExists = false;
	protected string ClientCallback;

	#endregion

	#region 属性

	private new string UserID {
		get {
			if (ViewState["UserID"] == null) return string.Empty;
			return (string)ViewState["UserID"];
		}
		set {
			ViewState["UserID"] = value;
		}
	}

	private string UIState {
		get {
			if (ViewState["UIState"] == null) return "Default";
			return (String)ViewState["UIState"];
		}
		set {
			ViewState["UIState"] = value;
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
		m_User = new SysUserBusiness();
		base.OnInit(e);
	}

	protected override void OnUnload(EventArgs e) {
        m_User.Dispose();
		m_User = null;
		base.OnUnload(e);
	}

	/// <summary>
	/// 系统用户数据绑定
	/// </summary>
	public override void DataBind() {
		int recordCount = 0;
		UserRepeater.DataSource = m_User.GetSysUsers(Pager.CurrentPageIndex, Pager.PageSize, out recordCount);
        using (DepartmentBusiness Dept = new DepartmentBusiness()) {
            drpDeparts.DataSource = Dept.GetDepartments();
            drpDeparts.DataTextField = "DeptName";
            drpDeparts.DataValueField = "DeptID";
        }
        Pager.RecordCount = recordCount;
		base.DataBind();
	}
	/// <summary>
	/// 设置系统用户界面控件显示状态
	/// </summary>
	/// <param name="Enabled"></param>
	private void SetUIStatus(bool Enabled) {
		ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
		foreach (Control ctrl in Controls) {
			if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
		}
	}
	/// <summary>
	/// 设置系统用户界面按钮显示状态
	/// </summary>
	/// <param name="State"></param>
	private void SetUIState(string State) {
		UIState = State;
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
		if (!IsAdmin) {
			drpUserCategory.Enabled = false;
			//drpDeparts.Enabled = false;
		}
	}

	#endregion

	#region 私有成员

	/// <summary>
	/// 重置系统用户界面
	/// </summary>
	private void ClearUserUI() {
		UserID = "";
		drpUserCategory.SelectedIndex = 0;
		txtUserAccount.Text = "";
		txtUserName.Text = "";
		txtPosition.Text = "";
		txtLinkTel.Text = "";
		txtMobile.Text = "";
		txtPassWord.Text = "";
		//txtOrderNo.Text = "";
	}
	/// <summary>
	/// 填充系统用户界面
	/// </summary>
	private void SetUserUI() {
		SysUserEntity Result = m_User.GetSysUser(UserID);
		if (Result == null) return;
		UserID = Result.UserNo;
		txtUserAccount.Text = Result.UserAccount;
		txtUserName.Text = Result.UserName;
		txtPosition.Text = Result.Position;
		txtLinkTel.Text = Result.LinkTel;
		txtMobile.Text = Result.Mobile;
		drpDeparts.SelectedValue = Result.DeptNo+"";
		drpUserCategory.SelectedValue = Result.UserCategory;
		txtPassWord.Text = Result.PassWord;
        //txtEmail.Text = Result.EMail;
		//txtOrderNo.Text = Result.OrderNo + "";        
	}

	/// <summary>
	/// 从界面获取系统用户对象
	/// </summary>
	/// <returns></returns>
	private SysUserEntity GetUserUI() {
		SysUserEntity Result = new SysUserEntity();
		Result.UserNo = UserID;
		Result.UserAccount = txtUserAccount.Text.Trim();
		Result.UserName = txtUserName.Text;
		Result.Position = txtPosition.Text;
		Result.LinkTel = txtLinkTel.Text;
		Result.Mobile = txtMobile.Text;
		Result.DeptNo = EnvConverter.ToInt32(drpDeparts.SelectedValue);
		Result.UserCategory = drpUserCategory.SelectedValue;
		Result.PassWord = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassWord.Text, "MD5");
        //Result.EMail = txtEmail.Text;
		Result.OrderNo = 1;// EnvConverter.ToInt32(txtOrderNo.Text);
		return Result;
	}

	#endregion

	#region 事件

	protected void btnSaveUser_Click(object sender, EventArgs e) {
		SysUserEntity Result = GetUserUI();
		if ((UIState == "New") && (m_User.CheckUserExists(Result.UserAccount))) {
			ShowMessage("该用户账号已经存在请重新选择用户账号!");
			return;
		}
		int Succeed = m_User.SaveSysUser(Result);
		if (Succeed > 0) ShowMessage("系统用户数据保存成功!");
		if (Succeed < 0) ShowMessage("系统用户数据保存失败!");
		DataBind();
		SetUIState("Default");
	}

	protected void btnNewUser_Click(object sender, EventArgs e) {
		ClearUserUI();
		btnSave.Enabled = CanEditData;
		SetUIState("New");
	}

	protected void btnDeleteUser_Click(object sender, EventArgs e) {
		int Succeed = m_User.DeleteSysUser(GetUserUI());
		if (Succeed > 0) ShowMessage("系统用户数据删除成功!");
		if (Succeed < 0) ShowMessage("系统用户数据删除失败!");
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
			Literal lblUserNo = (Literal)e.Item.FindControl("lblUserNo");
			UserID = lblUserNo.Text;
			SetUserUI();
			SetUIState("Default");
		}
	}

	protected void Pager_PageChanged(object sender, EventArgs e) {
		//Pager.PageChanged +=new EventHandler(Pager_PageChanged);
		DataBind();
	}


	#endregion

}