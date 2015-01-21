using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using BusinessLogic.Admin;
using DataEntity.Admin;
using System.Web.Configuration;

/// <summary>
/// BasePage 所有页面的基类 
/// </summary>
public class BasePage : System.Web.UI.Page {


	#region 属性

	/// <summary>
	/// 返回虚拟目录路径
	/// </summary>
	public string ApplicationPath {
		get {
			string applicationPath = HttpContext.Current.Request.ApplicationPath;
			if (applicationPath == "/") {
				return string.Empty;
			}
			else {
				return applicationPath;
			}
		}
	}

	protected bool CanEditData {
		get {
			return true;
		}
	}


    protected String UserAccount {
		get {
			return "Admin";
		}
	}

    protected String UserID {
        get {
            using (SysUserBusiness User = new SysUserBusiness()) {
                SysUserEntity UserInfo = User.GetUserByAccount(UserAccount);
                if (UserInfo != null) return UserInfo.UserNo;
                return "";
            }
        }
    }

	protected String UserName {
		get {
			using (SysUserBusiness User = new SysUserBusiness()) {
                SysUserEntity UserInfo = User.GetUserByAccount(UserAccount);
				if (UserInfo != null) return UserInfo.UserName;
				return "";
			}
		}
	}

	protected bool IsAdmin {
		get {
			using (SysUserBusiness User = new SysUserBusiness()) {
                SysUserEntity UserInfo = User.GetUserByAccount(UserAccount);
				if (UserInfo != null) return UserInfo.UserCategory == "0";
				return false;
			}
			//return true;
		}
	}

	protected int DepartNo {
		get {
			using (SysUserBusiness User = new SysUserBusiness()) {
                SysUserEntity UserInfo = User.GetUserByAccount(UserAccount);
				if (UserInfo != null) return UserInfo.DeptNo.Value;
				return int.MinValue;
			}
		}
	}

	#endregion

	#region 重写方法

	protected override void OnLoad(EventArgs e) {
        if (!Request.IsAuthenticated) {
            Response.Redirect(FormsAuthentication.LoginUrl);
            return;
        }
		ScriptManager.RegisterStartupScript(this, GetType(), "InitialInput", "InitialInput();", true);        
		base.OnLoad(e);
	}

	protected override void OnPreInit(EventArgs e) {
		PagesSection ps = (PagesSection)ConfigurationManager.GetSection("system.web/pages");
		if (!String.IsNullOrEmpty(ps.Theme)) Theme = ps.Theme;
		base.OnPreInit(e);
	}

	protected override void OnPreRender(EventArgs e) {
		base.OnPreRender(e);
	}

	#endregion

	#region 受保护方法

	protected void RegisterScriptInclude(string filePath) {
		HtmlGenericControl jsRefControl = new HtmlGenericControl();
		jsRefControl.TagName = "script";
		jsRefControl.Attributes.Add("type", "text/javascript");
		jsRefControl.Attributes.Add("src", ApplicationPath + filePath);
		Page.Header.Controls.Add(jsRefControl);
	}

	protected void RegisterScriptBlock(string javascript) {
		HtmlGenericControl jsControl = new HtmlGenericControl();
		jsControl.TagName = "script";
		jsControl.Attributes.Add("type", "text/javascript");
		jsControl.InnerHtml = javascript;
		Page.Header.Controls.Add(jsControl);
	}


	protected void RegisterStyleInclude(string cssFile) {
		HtmlGenericControl cssControl = new HtmlGenericControl();
		cssControl.TagName = "link";
		cssControl.Attributes.Add("type", "text/css");
		cssControl.Attributes.Add("rel", "stylesheet");
		cssControl.Attributes.Add("href", ApplicationPath + cssFile);
		Page.Header.Controls.Add(cssControl);
	}

	protected void ShowMessage(string message) {
		ScriptManager.RegisterClientScriptBlock(this, GetType(), "Information", "alert('" + message + "')", true);
	}

	#endregion

    //信息类型
    public enum messagesType
    {
        体检过通知 = 1,
        复检通知 = 2,
        单位体检通知 = 3,
        定期通知 = 4,
        其他 = 5
    };


}
