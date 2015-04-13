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
using Common.FormatProvider;

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
            if (ReportKind == "4") BuildHealthCard(RegisterNo);//健康证
            if (ReportKind == "5") BuildHealthCardBatch();//健康证批量
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
    public void BuildSearch_Composed() {

        Report a = new Report();

        a.Load(Server.MapPath("Search_Composed.frx"));


        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        bool blDate = true;
        string sqlw = " 1=1 ";

        if (Request.Params["RegisterNo"] != "") {
            sqlw += string.Format("  And RegisterNo like '%{0}%' ", Request.Params["RegisterNo"]);
            blDate = false;
        }

        if (Request.Params["DeptName"] != "") {
            sqlw += string.Format("  And DeptName like '%{0}%' ", Request.Params["DeptName"]);
            blDate = false;
        }
        if (Request.Params["Name"] != "") {
            sqlw += string.Format("  And Name like '%{0}%' ", Request.Params["Name"]);
            blDate = false;
        }

        if (Request.Params["IdNumber"] != "") {
            sqlw += string.Format("  And IdNumber like '{0}%' ", Request.Params["IdNumber"]);
            blDate = false;
        }
        if (Request.Params["OverallDoctor"] != "") {
            sqlw += string.Format("  And OverallDoctor like '{0}%' ", Request.Params["OverallDoctor"]);
            blDate = false;
        }

        if (blDate) {
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
    public void BuildSearch_workload_package() {

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
    public void BuildSearch_workload_checkItem() {

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
        if (String.IsNullOrWhiteSpace(RegisterNo)) return;
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
        if (String.IsNullOrWhiteSpace(RegisterNo)) return;
        //String p = @"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";
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

    private void BuildHealthCardBatch() {
        String DeptName = Request.Params["DeptName"];
        String sCheckDate = Request.Params["CheckDate"];
        if (String.IsNullOrWhiteSpace(DeptName)) return;
        if (String.IsNullOrWhiteSpace(sCheckDate)) return;
        DateTime? CheckDate = Convert.ToDateTime(sCheckDate);
        
        int RecordCount = 0;
        var RegInfo = m_Registration.GetCheckReports(1, 2000, CheckDate, DeptName, "", out RecordCount);
        List<HealthCardInfo> Registrations = (from p in RegInfo
                                              select new HealthCardInfo {
                                                  RegisterNo = p.RegisterNo,
                                                  CheckDate = p.CheckDate.Value,
                                                  LimitDate = p.CheckDate.Value.AddYears(1),
                                                  Name = p.Name,
                                                  Sex = p.Sex,
                                                  Photo = Convert.FromBase64String(p.Photo)
                                              }).ToList();
        WebReport1.ReportFile = Server.MapPath("HealthCardList.frx");
        WebReport1.Report.RegisterData(Registrations, "CardData");
        WebReport1.Prepare();
    }


    #endregion
}

