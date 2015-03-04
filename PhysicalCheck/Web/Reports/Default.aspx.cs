using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FastReport;
using BusinessLogic.Examination;
using DataEntity.Examination;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;
using DataEntity.Admin;
using BusinessLogic.Admin;
using System.Data;

public partial class Reports_Default : BasePage {

    private RegistrationBusiness m_Registration;
    private ReportUtility m_Util;

    #region 重写方法

    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        m_Registration = new RegistrationBusiness();
        m_Util = new ReportUtility();
    }

    protected override void OnUnload(EventArgs e) {
        base.OnUnload(e);
        m_Registration.Dispose();
        m_Registration = null;
    }

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            String RegisterNo = Request.Params["RegisterNo"];//"20141214000043"
            String ReportKind = Request.Params["ReportKind"];
            if (ReportKind == "1") BuildBarCodeReport(RegisterNo);// 条码
            if (ReportKind == "2") BuildCheckReport(RegisterNo);//体检报告
            if (ReportKind == "3") BuildIntroductionReport(RegisterNo);//引导单
            if (ReportKind == "4") BuildHealthCard(RegisterNo);
            //if (ReportKind == "5") BuildHealthCertificate(RegisterNo);//健康证
            //if（ReportKind=="6") BuildTransfer(RegisterNo);//调离通知
            //if (ReportKind =="7") BuildReviewNotice(RegisterNo);//复查通知
            if (ReportKind == "61") BuildSearch_Composed();//组合查询
            if (ReportKind == "62") BuildSearch_workload_package();//查询-科室工作量
            if (ReportKind == "63") BuildSearch_workload_checkItem();//查询-检查医生工作量
        }
    }

    #endregion

    #region "查询"

    //组合查询
    public void BuildSearch_Composed()
    {

        Report a = new Report();

        a.Load(Server.MapPath("Search_Composed.frx"));


        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        bool blDate = true;
        string sqlw = " 1=1 ";

        if (Request.Params["RegisterNo"] != "")
        {
            sqlw += string.Format("  And RegisterNo like '%{0}%' ", Request.Params["RegisterNo"]);
            blDate = false;
        }

        if (Request.Params["DeptName"] != "")
        {sqlw += string.Format("  And DeptName like '%{0}%' ", Request.Params["DeptName"]);
        blDate = false;
        }
        if (Request.Params["Name"] != "")
        {   sqlw += string.Format("  And Name like '%{0}%' ", Request.Params["Name"]);
        blDate = false;
        }

        if (Request.Params["IdNumber"] != "")
        {   sqlw += string.Format("  And IdNumber like '{0}%' ", Request.Params["IdNumber"]);
        blDate = false;
        }
        if (Request.Params["OverallDoctor"] != "")
        {   sqlw += string.Format("  And OverallDoctor like '{0}%' ", Request.Params["OverallDoctor"]);
        blDate = false;
        }

        if (blDate)
        {
            if (Request.Params["StartDate"] != "")
                sqlw += string.Format(" And  RegisterDate>='{0}' ", Convert.ToDateTime(Request.Params["StartDate"]));

            if (Request.Params["EndDate"] != "")
                sqlw += string.Format("  And RegisterDate<'{0}' ", Convert.ToDateTime(Request.Params["EndDate"]).AddDays(1));
        }


        DataSet ds = bll.GetList_Composed(sqlw);

        a.SetParameterValue("RegisterNo", Request.Params["RegisterNo"]);
        a.SetParameterValue("DeptName", Request.Params["DeptName"]);
        a.SetParameterValue("Name", Request.Params["Name"]);
        a.SetParameterValue("IdNumber", Request.Params["IdNumber"]);

        a.SetParameterValue("pOverallDoctor", Request.Params["OverallDoctor"]);
        a.SetParameterValue("StartDate", Request.Params["StartDate"]);
        a.SetParameterValue("EndDate", Request.Params["EndDate"]);
        a.RegisterData(ds.Tables[0], "View_Search_Composed");
        WebReport1.Report = a;
        //WebReport1.Report.RegisterData(ds.Tables[0], "View_Search_Composed");
        //WebReport1.Report.SetParameterValue("registerNo", Request.Params["RegisterNo"].ToString());
        // WebReport1.Report.SetParameterValue("pOverallDoctor", "wsw");

        WebReport1.Prepare();

    }

    //科室工作量查询
    public void BuildSearch_workload_package()
    {

        Report a = new Report();

        a.Load(Server.MapPath("workload_package.frx"));


        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        string sqlw = " 1=1 ";

        if (Request.Params["DeptID"] != "")
            sqlw += string.Format("  And A.DeptID = '{0}' ", Request.Params["DeptID"]);

        if (Request.Params["StartDate"] != "")
            sqlw += string.Format(" And  A.CheckDate>='{0}' ", Convert.ToDateTime(Request.Params["StartDate"]));

        if (Request.Params["EndDate"] != "")
            sqlw += string.Format("  And A.CheckDate<'{0}' ", Convert.ToDateTime(Request.Params["EndDate"]).AddDays(1));

        DataSet ds = bll.GetList_workload_package(sqlw);

        a.SetParameterValue("DeptName", Request.Params["DeptName"]);
        a.SetParameterValue("StartDate", Request.Params["StartDate"]);
        a.SetParameterValue("EndDate", Request.Params["EndDate"]);
        a.RegisterData(ds.Tables[0], "workload_package");
        WebReport1.Report = a;

        WebReport1.Prepare();

    }

    //科室医生工作量查询
    public void BuildSearch_workload_checkItem()
    {

        Report a = new Report();

        a.Load(Server.MapPath("workload_checkItem.frx"));


        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        string sqlw = " 1=1 ";

        if (Request.Params["DeptID"] != "")
            sqlw += string.Format("  And A.DeptID = '{0}' ", Request.Params["DeptID"]);

        if (Request.Params["CheckDoctor"] != "")
            sqlw += string.Format("  And B.CheckDoctor= '{0}' ", Request.Params["CheckDoctor"]);

        if (Request.Params["StartDate"] != "")
            sqlw += string.Format(" And  A.CheckDate>='{0}' ", Convert.ToDateTime(Request.Params["StartDate"]));

        if (Request.Params["EndDate"] != "")
            sqlw += string.Format("  And A.CheckDate<'{0}' ", Convert.ToDateTime(Request.Params["EndDate"]).AddDays(1));

        DataSet ds = bll.GetList_workload_checkItem(sqlw);

        a.SetParameterValue("CheckDoctor", Request.Params["CheckDoctor"]);

        a.SetParameterValue("DeptName", Request.Params["DeptName"]);
        a.SetParameterValue("StartDate", Request.Params["StartDate"]);
        a.SetParameterValue("EndDate", Request.Params["EndDate"]);
        a.RegisterData(ds.Tables[0], "workload_checkItem");
        WebReport1.Report = a;

        WebReport1.Prepare();

    }

    #endregion

    #region 私有方法

    public void BuildBarCodeReport(String RegisterNo) {
        WebReport1.ReportFile = Server.MapPath("BarCode.frx");
        WebReport1.Report.RegisterData(m_Util.GetBarCodesForGuLang(RegisterNo), "BarCodes");
        WebReport1.Report.Prepare();
    }

    public void BuildCheckReport(String RegisterNo) {
        WebReport1.ReportFile = Server.MapPath("CheckReport.frx");
        //WebReport1.Report.RegisterData(GetBarCodes(RegisterNo), "BarCodes");            
        RegistrationViewEntity Registration = m_Registration.GetRegistration(RegisterNo);
        List<RegistrationViewEntity> Registrations = new List<RegistrationViewEntity>();
        Registrations.Add(Registration);
        List<GroupItemResult> GroupItemResults = m_Util.GetGroupResults(RegisterNo);
        List<ItemResult> ItemResults = new List<ItemResult>();
        foreach (GroupItemResult GroupResult in GroupItemResults) {
            ItemResults.AddRange(m_Util.GetItemResults(RegisterNo, GroupResult.GroupID));
        }
        WebReport1.Report.RegisterData(Registrations, "Registration");
        WebReport1.Report.RegisterData(GroupItemResults, "ItemGroupResult");
        WebReport1.Report.RegisterData(ItemResults, "ItemResult");
        WebReport1.Prepare();
    }

    public void BuildIntroductionReport(String RegisterNo) {
        WebReport1.ReportFile = Server.MapPath("IntroductionReport.frx");
        RegistrationViewEntity Registration = m_Registration.GetRegistration(RegisterNo);
        List<RegistrationViewEntity> Registrations = new List<RegistrationViewEntity>();
        Registrations.Add(Registration);
        using (PackageBusiness Business = new PackageBusiness()) {
            Business.GetPackageGroups(1);
        }
        List<Package> Packages = m_Util.GetPackageItems(Registration.PackageID.Value);
        List<GroupItem> GroupItems = m_Util.GetGroupItems(Registration.PackageID.Value);
        WebReport1.Report.RegisterData(Registrations, "Registration");
        WebReport1.Report.RegisterData(Packages, "Packages");
        WebReport1.Report.RegisterData(GroupItems, "ItemGroups");
        WebReport1.Prepare();
    }

    public void BuildHealthCard(String RegisterNo) {        
        List<HealthCardInfo> Registrations = new List<HealthCardInfo>();
        var RegInfo = m_Registration.GetRegistration(RegisterNo);
        Registrations.Add(new HealthCardInfo {
            RegisterNo = RegInfo.RegisterNo,
            CheckDate = RegInfo.CheckDate.Value,
            LimitDate = RegInfo.CheckDate.Value.AddYears(1),
            Name = RegInfo.Name,
            Sex = RegInfo.Sex,
            Photo = Convert.FromBase64String(RegInfo.Photo)
        });
        WebReport1.ReportFile = Server.MapPath("HealthCard.frx");
        WebReport1.Report.RegisterData(Registrations, "CardData");      
        WebReport1.Prepare();
    }

    


    #endregion
}

