using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainPage : System.Web.UI.Page {

    protected override void OnUnload(EventArgs e) {
        //FormsAuthentication.SignOut();
        base.OnUnload(e);
    }

}
