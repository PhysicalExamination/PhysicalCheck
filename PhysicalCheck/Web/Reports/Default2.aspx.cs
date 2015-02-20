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
public partial class Reports_Default : Page {

    private RegistrationBusiness m_Registration;

    #region 重写方法

    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        m_Registration = new RegistrationBusiness();
    }

    protected override void OnUnload(EventArgs e) {
        base.OnUnload(e);
        m_Registration.Dispose();
        m_Registration = null;
    }

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            BuildIntroductionListReport();
            String RegisterNo = Request.Params["RegisterNo"];//"20141214000043"
            String ReportKind = Request.Params["ReportKind"];
            if (ReportKind == "1") BuildBarCodeReport(RegisterNo);// 条码
            if (ReportKind == "2") BuildCheckReport(RegisterNo);//体检报告
            if (ReportKind == "3") BuildIntroductionReport(RegisterNo);//体检引导单
            if (ReportKind == "4") BuildIntroductionListReport();//体检引导单批量打印
            if (ReportKind == "5") BuildBarCodeListReport();//条码单批量打印
            if (ReportKind == "61") BuildSearch_Composed();//组合查询
            if (ReportKind == "62") BuildSearch_workload_package();//查询-科室工作量
            if (ReportKind == "63") BuildSearch_workload_checkItem();//查询-检查医生工作量
            //BuildIntroduction(RegisterNo);
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
        {
            sqlw += string.Format("  And DeptName like '%{0}%' ", Request.Params["DeptName"]);
            blDate = false;
        }
        if (Request.Params["Name"] != "")
        {
            sqlw += string.Format("  And Name like '%{0}%' ", Request.Params["Name"]);
            blDate = false;
        }

        if (Request.Params["IdNumber"] != "")
        {
            sqlw += string.Format("  And IdNumber like '{0}%' ", Request.Params["IdNumber"]);
            blDate = false;
        }
        if (Request.Params["OverallDoctor"] != "")
        {
            sqlw += string.Format("  And OverallDoctor like '{0}%' ", Request.Params["OverallDoctor"]);
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

        WebReport1.Report.Load(Server.MapPath("workload_package.frx"));


        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        string sqlw = " 1=1 ";

        if (Request.Params["DeptID"] != "")
            sqlw += string.Format("  And A.DeptID = '{0}' ", Request.Params["DeptID"]);

        if (Request.Params["StartDate"] != "")
            sqlw += string.Format(" And  A.CheckDate>='{0}' ", Convert.ToDateTime(Request.Params["StartDate"]));

        if (Request.Params["EndDate"] != "")
            sqlw += string.Format("  And A.CheckDate<'{0}' ", Convert.ToDateTime(Request.Params["EndDate"]).AddDays(1));

        DataSet ds = bll.GetList_workload_package(sqlw);

        WebReport1.Report.SetParameterValue("DeptName", Request.Params["DeptName"]);
        WebReport1.Report.SetParameterValue("StartDate", Request.Params["StartDate"]);
        WebReport1.Report.SetParameterValue("EndDate", Request.Params["EndDate"]);
        WebReport1.Report.RegisterData(ds.Tables[0], "workload_package");
        //WebReport1.Report = a;

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

    /// <summary>
    /// 个人条码打印
    /// </summary>
    /// <param name="RegisterNo"></param>
    private void BuildBarCodeReport(String RegisterNo) {
        WebReport1.ReportFile = Server.MapPath("BarCode.frx");
        WebReport1.Report.RegisterData(GetBarCodes(RegisterNo), "BarCodes");
        WebReport1.Report.Prepare();
    }

    /// <summary>
    /// 条码批量打印
    /// </summary>
    private void BuildBarCodeListReport() {
        WebReport1.ReportFile = Server.MapPath("BarCode.frx");
        DateTime? RegisterDate = null;
        if (!String.IsNullOrWhiteSpace(Request.Params["RegisterDate"])) {
            RegisterDate = Convert.ToDateTime(Request.Params["RegisterDate"]);
        }
        String DeptName = HttpUtility.UrlDecode(Request.Params["DeptName"]);
        List<RegistrationViewEntity> Registrations = m_Registration.GetRegistrationForReport(RegisterDate, DeptName);
        List<BarCode> BarCodes = new List<BarCode>();
        foreach (RegistrationViewEntity Registration in Registrations) {
            BarCodes.AddRange(GetBarCodes(Registration.RegisterNo));
        }
        WebReport1.Report.RegisterData(BarCodes, "BarCodes");
        WebReport1.Report.Prepare();
    }

    /// <summary>
    /// 体检报告打印
    /// </summary>
    /// <param name="RegisterNo"></param>
    private void BuildCheckReport(String RegisterNo) {
        WebReport1.ReportFile = Server.MapPath("CheckReport.frx");
        //WebReport1.Report.RegisterData(GetBarCodes(RegisterNo), "BarCodes");            
        RegistrationViewEntity Registration = m_Registration.GetRegistration(RegisterNo);
        List<RegistrationViewEntity> Registrations = new List<RegistrationViewEntity>();
        Registrations.Add(Registration);
        List<GroupItemResult> GroupItemResults = GetGroupResults(RegisterNo);
        List<ItemResult> ItemResults = new List<ItemResult>();
        foreach (GroupItemResult GroupResult in GroupItemResults) {
            ItemResults.AddRange(GetItemResults(RegisterNo, GroupResult.GroupID));
        }
        WebReport1.Report.RegisterData(Registrations, "Registration");
        WebReport1.Report.RegisterData(GroupItemResults, "ItemGroupResult");
        WebReport1.Report.RegisterData(ItemResults, "ItemResult");
        WebReport1.Prepare();
    }

    /// <summary>
    /// 个人体检引导单打印
    /// </summary>
    /// <param name="RegisterNo"></param>
    private void BuildIntroductionReport(String RegisterNo) {
        WebReport1.ReportFile = Server.MapPath("IntroductionReport.frx");
        RegistrationViewEntity Registration = m_Registration.GetRegistration(RegisterNo);
        List<RegistrationViewEntity> Registrations = new List<RegistrationViewEntity>();
        Registrations.Add(Registration);
        List<Package> Packages = GetPackageItems(RegisterNo,Registration.PackageID.Value);
        List<GroupItem> GroupItems = GetGroupItems(RegisterNo,Registration.PackageID.Value);
        WebReport1.Report.RegisterData(Registrations, "Registration");
        WebReport1.Report.RegisterData(Packages, "Packages");
        WebReport1.Report.RegisterData(GroupItems, "ItemGroups");
        WebReport1.Prepare();
    }

    /// <summary>
    /// 引导单批量打印
    /// </summary>
    private void BuildIntroductionListReport() {
        WebReport1.ReportFile = Server.MapPath("IntroductionListReport.frx");
        DateTime? RegisterDate = null;
        if (!String.IsNullOrWhiteSpace(Request.Params["RegisterDate"])) {
            RegisterDate = Convert.ToDateTime(Request.Params["RegisterDate"]);
        }        
        String DeptName = HttpUtility.UrlDecode(Request.Params["DeptName"]);
        List<RegistrationViewEntity> Registrations = m_Registration.GetRegistrationForReport(RegisterDate, DeptName);
        //Registrations.Add(Registration);
        List<Package> Packages = new List<Package>();
        List<GroupItem> GroupItems = new List<GroupItem>();
        foreach (RegistrationViewEntity Registration in Registrations) {
            Packages.AddRange(GetPackageItems(Registration.RegisterNo,Registration.PackageID.Value));
            GroupItems.AddRange(GetGroupItems(Registration.RegisterNo, Registration.PackageID.Value));
        }
        //List<Package> Packages = GetPackageItems(Registration.PackageID.Value);
        //List<GroupItem> GroupItems = GetGroupItems(Registration.PackageID.Value);
        WebReport1.Report.RegisterData(Registrations, "Registration");
        WebReport1.Report.RegisterData(Packages, "Packages");
        WebReport1.Report.RegisterData(GroupItems, "ItemGroups");
        WebReport1.Prepare();
    }

    private List<GroupItemResult> GetGroupResults(String RegisterNo) {
        List<GroupResultViewEntity> GroupResults = m_Registration.GetGroupResults(RegisterNo);
        var q = from p in GroupResults
                select new GroupItemResult {
                    GroupID = p.ID.GroupID,
                    GroupName = p.GroupName,
                    DeptName = p.DeptName,
                    CheckDoctor = p.CheckDoctor,
                    CheckDate = p.CheckDate,
                    Summary = p.Summary
                };
        return q.ToList();
    }

    private List<ItemResult> GetItemResults(String RegisterNo, int GroupID) {
        List<ItemResultViewEntity> ItemResultList = m_Registration.GetItemResults(RegisterNo, GroupID);
        var q = from p in ItemResultList
                select new ItemResult {
                    GroupID = p.ID.GroupID.Value,
                    ItemName = p.ItemName,
                    CheckedResult = p.CheckedResult,
                    MeasureUnit = p.MeasureUnit,
                    LowerLimit = p.LowerLimit,
                    UpperLimit = p.UpperLimit,
                    NormalTips = p.NormalTips,
                    CheckDoctor = p.CheckDoctor,
                    CheckDate = p.CheckDate
                };
        return q.ToList();
    }

    private List<BarCode> GetBarCodes(String RegisterNo) {
        using (RegistrationBusiness Business = new RegistrationBusiness()) {
            var q = from p in Business.GetGroupResults(RegisterNo)
                    select new BarCode { RegisterNo = p.ID.RegisterNo, GroupName = p.GroupName };
            return q.ToList();
        }
    }


    private List<Package> GetPackageItems(String RegisterNo,int PackageID) {
        //0 检查科室 1 检验科室 2 功能科室
        String[] Names = new String[] { "抽血及其它化验项目", "医生检查项目", "功能检查项目" };
        List<Package> List = new List<Package>();
        List<DepartmentEntity> Departments;
        List<PackageGroupViewEntity> Groups;
        using (PackageBusiness Business = new PackageBusiness()) {
            Groups = Business.GetPackageGroups(PackageID);
        }
        using (DepartmentBusiness Depart = new DepartmentBusiness()) {
            Departments = Depart.GetDepartments();
        }
        var q = from a in Groups
                join b in Departments on a.DeptID equals b.DeptID
                group b by b.DeptKind into g
                select new Package {
                    RegisterNo = RegisterNo,
                    GroupID = Convert.ToInt32(g.Key),
                    PackageName = Names[Convert.ToInt32(g.Key)] + g.Count() + "项"
                };
        return q.ToList();
    }

    private List<GroupItem> GetGroupItems(String RegisterNo, int PackageID) {
        List<DepartmentEntity> Departments;
        List<PackageGroupViewEntity> Groups;
        using (PackageBusiness Business = new PackageBusiness()) {
            Groups = Business.GetPackageGroups(PackageID);
        }
        using (DepartmentBusiness Depart = new DepartmentBusiness()) {
            Departments = Depart.GetDepartments();
        }
        var q = from a in Groups
                join b in Departments on a.DeptID equals b.DeptID
                select new GroupItem {
                    RegisterNo = RegisterNo,
                    GroupID = Convert.ToInt32(b.DeptKind),
                    GroupName = a.GroupName,
                    Clinical = a.Clinical,
                    Notice = a.Notice
                };
        return q.ToList();
    }



    #endregion
}

