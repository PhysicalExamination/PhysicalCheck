using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BusinessLogic.Admin;

public partial class SysLogin : Page, ICallbackEventHandler
{
	protected string ClientCallback;
	private string callBackResult = "";

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);
		if (!IsPostBack) {
			ClientCallback = ClientScript.GetCallbackEventReference(this, "argument", "processCallback", "null");
		}
	}

	protected override void OnInit(EventArgs e) {
		base.OnInit(e);
	}

	#region ICallbackEventHandler 成员

	public string GetCallbackResult() {
		return callBackResult;
	}

	public void RaiseCallbackEvent(string eventArgument) {
		String[] arguments = eventArgument.Split(',');
		String userAccount = arguments[0];
		String password = FormsAuthentication.HashPasswordForStoringInConfigFile(arguments[1], "MD5");
        using (SysUserBusiness user = new SysUserBusiness()) {
            bool passed = user.Authentication(userAccount, password);
            if (passed) {
                FormsAuthentication.SetAuthCookie(userAccount, true);
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userAccount, true);
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, "");
                authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                Response.Cookies.Remove(authCookie.Name);
                Response.Cookies.Add(authCookie);
                callBackResult = FormsAuthentication.DefaultUrl;
            }
        }
        //FormsAuthentication.SetAuthCookie("Admin", true);
        //Server.Transfer(FormsAuthentication.DefaultUrl);
        //callBackResult = FormsAuthentication.DefaultUrl;
	}

	#endregion
    protected void btnLogin_Click(object sender, EventArgs e) {
        String userAccount = txtUsername.Text.Trim();
        String password = txtPassword.Text.Trim();
        if(String.IsNullOrWhiteSpace(userAccount) ||String.IsNullOrWhiteSpace(password)){
            String js = "alert('用户名或密码错误请重新输入！');";
            ClientScript.RegisterClientScriptBlock(GetType(), "Msg", js, true);
        }
        password = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
        using (SysUserBusiness user = new SysUserBusiness()) {
            bool passed = user.Authentication(userAccount, password);
            if (passed) {
                FormsAuthentication.SetAuthCookie(userAccount, true);
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userAccount, true);
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, "");
                authCookie.Value = FormsAuthentication.Encrypt(newTicket);
                Response.Cookies.Add(authCookie);                
                callBackResult = FormsAuthentication.DefaultUrl;
                Server.Transfer(FormsAuthentication.DefaultUrl);
            }
            else {
                String js = "alert('用户名或密码错误请重新输入！');";
                ClientScript.RegisterClientScriptBlock(GetType(), "Msg", js, true);
            }
        }
        //FormsAuthentication.SetAuthCookie(userAccount, true);
        //Server.Transfer(FormsAuthentication.DefaultUrl);
    }
}