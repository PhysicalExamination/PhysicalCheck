using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLogic.Admin;
using DataEntity.Admin;

public partial class Left : BasePage {

    #region 私有成员

    private ModuleBusiness m_Module;
    private SysUserBusiness m_User;

    #endregion

	//#region 属性

	///// <summary>
	///// 返回虚拟目录路径
	///// </summary>
	//public string ApplicationPath {
	//    get {
	//        string applicationPath = HttpContext.Current.Request.ApplicationPath;
	//        if (applicationPath == "/") {
	//            return string.Empty;
	//        }
	//        else {
	//            return applicationPath;
	//        }
	//    }
	//}

	//#endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            BuildMenu();
        }
    }

    protected override void OnInit(EventArgs e) {
        m_Module = new ModuleBusiness();
        m_User = new SysUserBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Module.Dispose();
        m_Module = null;
        m_User.Dispose();
        m_User = null;
        base.OnUnload(e);
    }

    #endregion

    #region 私有方法

    private void BuildMenu() {
        StringBuilder sb = new StringBuilder();
        List<ModuleEntity> ModuleList;
        if (IsAdmin) {
            ModuleList = m_Module.GetModules("Root");
        }
        else {
            ModuleList = m_User.GetUserModules(UserAccount, "Root");
        }
        sb.AppendLine("<div id=\"accordion\" style=\"margin: 0 auto; width: 240px;\">");
        sb.AppendLine(BuildHome());
        foreach (ModuleEntity Module in ModuleList) {
            sb.AppendLine("<div>");
            sb.AppendLine("<h3>");
            sb.AppendLine(Module.ModuleName);
            sb.AppendLine("</h3>");
            sb.AppendLine("<div>");
            sb.AppendLine(BuildSubMenu(Module.ModuleNo));
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
        }
        sb.AppendLine("</div>");
        lblMenu.Text = sb.ToString();
    }

    private String BuildSubMenu(String ParentModuleNo) {
        StringBuilder sb = new StringBuilder();
        List<ModuleEntity> ModuleList;
        //if (IsAdmin) {
            ModuleList = m_Module.GetModules(ParentModuleNo);
        //}
        //else {
        //    ModuleList = m_User.GetUserModules(UserAccount, ParentModuleNo);
        //}
        String URL, ModuleIcon, ModuleName;
        foreach (ModuleEntity Module in ModuleList) {
            sb.AppendLine("<p>");
            URL = ApplicationPath + "/" + Module.URL;
            ModuleIcon = Module.ModuleIcon;
            ModuleName = Module.ModuleName;
			sb.AppendLine(String.Format("<img src=\"images/icons/{0}\" align=\"middle\" alt=\"\" />&nbsp;&nbsp;<span href=\"{1}\" target=\"mainFrame\">{2}</span>", ModuleIcon, URL, ModuleName));
            sb.AppendLine("</p>");
        }
        return sb.ToString();
    }
    #endregion

    private String BuildHome() {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<div>");
        sb.AppendLine("<h3>");
        sb.AppendLine("首页");
        sb.AppendLine("</h3>");
        sb.AppendLine("<div>");
        sb.AppendLine("<p>");
        sb.AppendLine("<img src=\"" + ApplicationPath + "/images/icons/home.png\" align=\"middle\" alt=\"\" />");
        sb.Append("&nbsp;&nbsp;<span href=\"" + ApplicationPath + "/ContentPage.aspx\" target=\"mainFrame\">系统首页</span>");
        sb.AppendLine("</p>");
        sb.AppendLine("</div>");
        sb.AppendLine("</div>");
        return sb.ToString();
    }

}
