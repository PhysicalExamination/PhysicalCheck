using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Admin;
using System.Web.Security;


public partial class Header : BasePage,ICallbackEventHandler{

    protected String Callback;
	protected String imageBtnURL;
  
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            Callback = ClientScript.GetCallbackEventReference(this, "args", "processCallback", "context");
			if (Theme == "redmond") imageBtnURL = "images/index/imageBtn.png";
			if (Theme == "lightness") imageBtnURL = "images/index/imageBtn1.png";
			if (Theme == "smoothness") imageBtnURL = "images/index/imageBtn2.png";
			
        }
    }



    #region ICallbackEventHandler 成员

    public string GetCallbackResult() {
        return "";
    }

    public void RaiseCallbackEvent(string eventArgument) {
       
        FormsAuthentication.SignOut();
    }

    #endregion
}
