using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Admin;
using System.Web.Security;

public partial class Admin_UserChangePasswordPage : BasePage {

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);
		if (!IsPostBack) {
			txtConfirmPassword.CssClass = String.Format("validate[required,equals[{0}]] textbox41", txtNewPassword.ClientID);
		}
	}

	protected void btnSave_Click(object sender, EventArgs e) {
		using (SysUserBusiness Business = new SysUserBusiness()) {
			String pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtOldPassword.Text, "MD5");
            bool passed = Business.Authentication(UserAccount, pwd);
			if (!passed) {
				ShowMessage("旧密码输入错误请重新输入！");
			}
			if (passed) {
				pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(txtConfirmPassword.Text, "MD5");
                Business.ChangedPassword(UserAccount, pwd);
				ShowMessage("恭喜你，修改密码成功！");
			}
		}
	}
}