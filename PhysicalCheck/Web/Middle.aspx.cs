using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Configuration;

public partial class Middle : System.Web.UI.Page {
	protected void Page_Load(object sender, EventArgs e) {
		//Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
		////配置文件的虚拟目录，如果null则取根目录下的web.config
		//SystemWebSectionGroup ws = (SystemWebSectionGroup)configuration.GetSectionGroup("system.web");
		//PagesSection ps = ws.Pages;
		//Console.WriteLine(ps.Theme);
		////CompilationSection cp = ws.Compilation;
		////用cp.Debug;就可以得到compilation节内关于"debug"的配置
		////AuthenticationSection as = ws.Authentication; 

		//System.Web.Configuration.PagesSection ps1 = (System.Web.Configuration.PagesSection)System.Configuration.ConfigurationManager.GetSection("system.web/pages");
		//Console.WriteLine(ps1.Theme);

	}

	protected override void OnPreInit(EventArgs e) {
		PagesSection ps = (PagesSection)ConfigurationManager.GetSection("system.web/pages");
		if (!String.IsNullOrEmpty(ps.Theme)) Theme = ps.Theme;
		Console.WriteLine(ps.Theme);
		base.OnPreInit(e);
	}
}