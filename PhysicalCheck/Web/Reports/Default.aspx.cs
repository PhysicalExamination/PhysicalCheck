using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FastReport;
using BusinessLogic.Examination;

public partial class Reports_Default : BasePage {

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            WebReport1.ReportFile = Server.MapPath("BarCode.frx");
            String RegisterNo = Request.Params["RegisterNo"];
            WebReport1.Report.RegisterData(GetBarCodes(RegisterNo), "BarCodes");
        }
    }

    #endregion

    #region 私有方法

    private List<BarCode> GetBarCodes(String RegisterNo) {
        using (RegistrationBusiness Business = new RegistrationBusiness()) {
            var q = from p in Business.GetGroupResults(RegisterNo)
                    select new BarCode { RegisterNo = p.ID.RegisterNo, GroupName = p.GroupName };
            return q.ToList();
        }
    }

    #endregion

}

public class BarCode {

    public String RegisterNo {
        get;
        set;
    }

    public String GroupName {
        get;
        set;
    }
}