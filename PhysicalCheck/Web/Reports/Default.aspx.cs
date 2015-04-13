using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FastReport;
using BusinessLogic.Examination;
using System.Data;
using DataEntity.Examination;

public partial class Reports_Default : BasePage
{

    private ReportUtility m_ReportUtil;
    private RegistrationBusiness m_Registration;

    #region 重写方法

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        m_Registration = new RegistrationBusiness();
        m_ReportUtil = new ReportUtility();
    }

    protected override void OnUnload(EventArgs e)
    {
        base.OnUnload(e);
        m_Registration.Dispose();
        m_Registration = null;
        m_ReportUtil = null;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            String RegisterNo = Request.Params["RegisterNo"];//"20141214000043"
            String ReportKind = Request.Params["ReportKind"];
            if (ReportKind == "1") BuildBarCodeReport(RegisterNo);// 条码
            if (ReportKind == "2") BuildCheckReport(RegisterNo);//体检报告
            if (ReportKind == "3") BuildIntroductionReport(RegisterNo);//引导单
            if (ReportKind == "4") BuildIntroductionListReport();//体检引导单批量打印
            if (ReportKind == "5") BuildBarCodeListReport();//条码单批量打印
            if (ReportKind == "6") BuildIntroductionsReport();//根据选择的体检登记号打印引导单
            if (ReportKind == "61") BuildSearch_Composed();//组合查询
            if (ReportKind == "62") BuildSearch_workload_package();//查询-科室工作量
            if (ReportKind == "63") BuildSearch_workload_checkItem();//查询-检查医生工作量
            if (ReportKind == "64") BuildSearch_workload_ItemGroup();//查询-检查组合项目工作量

            if (ReportKind == "71") BuildUnit_Disease_sum();//体检单位-体检疾病统计表（汇总）
            if (ReportKind == "72") BuildUnit_jieguozhongshu();//体检单位-体检结果综述（汇总）
           

        }
    }

    #endregion

    #region 单位体检报告

    /// <summary>
    /// 体检单位-体检结果综述（汇总）
    /// </summary>
    /// <param name="RegisterNo"></param>
    public void BuildUnit_jieguozhongshu()
    {
        Report a = new Report();
        a.Load(Server.MapPath("unit_Jieguozhongshu.frx"));

        Maticsoft.BLL.BaseInfo.BaseInfo bll = new Maticsoft.BLL.BaseInfo.BaseInfo(); 
       
        string sqlw = " 1=1 ";

        if (Request.Params["DeptName"] != "")
        {
            sqlw += string.Format("  And DeptName like '{0}%' ", Request.Params["DeptName"]);

        }


        if (Request.Params["StartDate"] != "")
            sqlw += string.Format(" And  RegisterDate>='{0}' ", Convert.ToDateTime(Request.Params["StartDate"]));

        if (Request.Params["EndDate"] != "")
            sqlw += string.Format("  And RegisterDate<'{0}' ", Convert.ToDateTime(Request.Params["EndDate"]).AddDays(1));


        DataTable dt = bll.GetList_Table("registrationview", sqlw).Tables[0];

        a.SetParameterValue("RowsCunt", dt.Rows.Count);

        a.RegisterData(dt, "Main");

        WebReport1.Report = a;
        WebReport1.Prepare();
    }


    /// <summary>
    /// 体检单位-体检疾病统计表（汇总）
    /// </summary>
    /// <param name="RegisterNo"></param>
    public void BuildUnit_Disease_sum()
    {
        Report a = new Report();
        a.Load(Server.MapPath("unit_disease_sum.frx"));

        Maticsoft.BLL.UnitReport.UnitReport bll = new Maticsoft.BLL.UnitReport.UnitReport();
        
        string sqlw = " 1=1 ";

        if (Request.Params["DeptName"] != "")
        {
            sqlw += string.Format("  And DeptName like '{0}%' ", Request.Params["DeptName"]);
            
        }


        if (Request.Params["StartDate"] != "")
            sqlw += string.Format(" And  RegisterDate>='{0}' ", Convert.ToDateTime(Request.Params["StartDate"]));

        if (Request.Params["EndDate"] != "")
            sqlw += string.Format("  And RegisterDate<'{0}' ", Convert.ToDateTime(Request.Params["EndDate"]).AddDays(1));


        DataTable dt1 = bll.GetUnitDiseasesumMain(sqlw).Tables[0];
        DataTable dt2 = bll.GetUnitDiseasesumSub(sqlw).Tables[0];

        dt2.Columns.Add(new DataColumn("DeptName", typeof(string)));
        dt2.Columns.Add(new DataColumn("NanNum", typeof(int)));
        dt2.Columns.Add(new DataColumn("NvNum", typeof(int)));
        dt2.Columns.Add(new DataColumn("RenNum", typeof(int)));
        dt2.Columns.Add(new DataColumn("Bili", typeof(string)));

        if (dt1.Rows.Count>0)
        for (int i = 0; i < dt2.Rows.Count;i++ )
        {
            dt2.Rows[i]["DeptName"] = dt1.Rows[0]["DeptName"];
            dt2.Rows[i]["NanNum"] = dt1.Rows[0]["NanNum"];
            dt2.Rows[i]["NvNum"] = dt1.Rows[0]["NvNum"];
            dt2.Rows[i]["RenNum"] = Convert.ToInt32( dt1.Rows[0]["NvNum"]) + Convert.ToInt32( dt1.Rows[0]["NanNum"]);

            if (Convert.ToInt32(dt2.Rows[i]["num"]) != 0)
                dt2.Rows[i]["Bili"] = (Convert.ToInt32(dt2.Rows[i]["num"]) / Convert.ToDecimal(dt2.Rows[i]["RenNum"]) * 100).ToString("##.##") + '%';
            else
                dt2.Rows[i]["Bili"] = "";
        }
        a.SetParameterValue("dates", Request.Params["StartDate"]);

        a.SetParameterValue("dateE", Request.Params["EndDate"]);
       
        a.RegisterData(dt2, "disease");

        WebReport1.Report = a;          
        WebReport1.Prepare();
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

        sqlw += " order by RegisterNo Desc";

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


    //科室医生组合项目查询
    public void BuildSearch_workload_ItemGroup()
    {

        Report a = new Report();

        a.Load(Server.MapPath("workload_ItemGroup.frx"));


        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        string sqlw = " 1=1 ";

        if (Request.Params["DeptID"] != "")
            sqlw += string.Format("  And A.DeptID = '{0}' ", Request.Params["DeptID"]);

        if (Request.Params["StartDate"] != "")
            sqlw += string.Format(" And  A.CheckDate>='{0}' ", Convert.ToDateTime(Request.Params["StartDate"]));

        if (Request.Params["EndDate"] != "")
            sqlw += string.Format("  And A.CheckDate<'{0}' ", Convert.ToDateTime(Request.Params["EndDate"]).AddDays(1));

        DataSet ds = bll.GetList_workload_itemgroup(sqlw);

        //a.SetParameterValue("CheckDoctor", Request.Params["CheckDoctor"]);

        a.SetParameterValue("DeptName", Request.Params["DeptName"]);
        a.SetParameterValue("StartDate", Request.Params["StartDate"]);
        a.SetParameterValue("EndDate", Request.Params["EndDate"]);
        a.RegisterData(ds.Tables[0], "workload_ItemGroup");
        WebReport1.Report = a;

        WebReport1.Prepare();

    }


    #endregion

    #region 私有方法

    /// <summary>
    /// 个人条码打印
    /// </summary>
    /// <param name="RegisterNo"></param>
    private void BuildBarCodeReport(String RegisterNo)
    {
        WebReport1.ReportFile = Server.MapPath("BarCode.frx");
        WebReport1.Report.RegisterData(m_ReportUtil.GetBarCodes(RegisterNo), "BarCodes");
        WebReport1.Report.Prepare();
        //WebReport1.Report.Print();
    }

    /// <summary>
    /// 条码批量打印
    /// </summary>
    private void BuildBarCodeListReport()
    {
        WebReport1.ReportFile = Server.MapPath("BarCode.frx");
        DateTime? RegisterDate = null;
        if (!String.IsNullOrWhiteSpace(Request.Params["RegisterDate"]))
        {
            RegisterDate = Convert.ToDateTime(Request.Params["RegisterDate"]);
        }
        String DeptName = HttpUtility.UrlDecode(Request.Params["DeptName"]);
        List<RegistrationViewEntity> Registrations = m_Registration.GetRegistrationForReport(RegisterDate, DeptName);
        List<BarCode> BarCodes = new List<BarCode>();
        foreach (RegistrationViewEntity Registration in Registrations)
        {
            BarCodes.AddRange(m_ReportUtil.GetBarCodes(Registration.RegisterNo));
        }
        WebReport1.Report.RegisterData(BarCodes, "BarCodes");
        WebReport1.Report.Prepare();
    }

    /// <summary>
    /// 体检报告打印
    /// </summary>
    /// <param name="RegisterNo"></param>
    private void BuildCheckReport(String RegisterNo)
    {
        WebReport1.ReportFile = Server.MapPath("CheckReport.frx");
        //WebReport1.Report.RegisterData(GetBarCodes(RegisterNo), "BarCodes");            
        RegistrationViewEntity Registration = m_Registration.GetRegistration(RegisterNo);
        List<RegistrationViewEntity> Registrations = new List<RegistrationViewEntity>();
        Registrations.Add(Registration);
        List<GroupItemResult> GroupItemResults = m_ReportUtil.GetGroupResults(RegisterNo);
        List<ItemResult> ItemResults = new List<ItemResult>();
        foreach (GroupItemResult GroupResult in GroupItemResults)
        {
            ItemResults.AddRange(m_ReportUtil.GetItemResults(RegisterNo, GroupResult.GroupID));
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
    private void BuildIntroductionReport(String RegisterNo)
    {
        WebReport1.ReportFile = Server.MapPath("IntroductionReport.frx");
        RegistrationViewEntity Registration = m_Registration.GetRegistration(RegisterNo);
        List<RegistrationViewEntity> Registrations = new List<RegistrationViewEntity>();
        Registrations.Add(Registration);
        List<Package> Packages = m_ReportUtil.GetPackageItems(RegisterNo, Registration.PackageID.Value);
        List<GroupItem> GroupItems = m_ReportUtil.GetGroupItems(RegisterNo, Registration.PackageID.Value);
        WebReport1.Report.RegisterData(Registrations, "Registration");
        WebReport1.Report.RegisterData(Packages, "Packages");
        WebReport1.Report.RegisterData(GroupItems, "ItemGroups");
        WebReport1.Prepare();
    }

    /// <summary>
    /// 引导单批量打印
    /// </summary>
    private void BuildIntroductionListReport()
    {
        WebReport1.ReportFile = Server.MapPath("IntroductionListReport.frx");
        DateTime? RegisterDate = null;
        if (!String.IsNullOrWhiteSpace(Request.Params["RegisterDate"]))
        {
            RegisterDate = Convert.ToDateTime(Request.Params["RegisterDate"]);
        }
        String DeptName = HttpUtility.UrlDecode(Request.Params["DeptName"]);
        List<RegistrationViewEntity> Registrations = m_Registration.GetRegistrationForReport(RegisterDate, DeptName);
        //Registrations.Add(Registration);
        List<Package> Packages = new List<Package>();
        List<GroupItem> GroupItems = new List<GroupItem>();
        foreach (RegistrationViewEntity Registration in Registrations)
        {
            Packages.AddRange(m_ReportUtil.GetPackageItems(Registration.RegisterNo, Registration.PackageID.Value));
            GroupItems.AddRange(m_ReportUtil.GetGroupItems(Registration.RegisterNo, Registration.PackageID.Value));
        }
        //List<Package> Packages = GetPackageItems(Registration.PackageID.Value);
        //List<GroupItem> GroupItems = GetGroupItems(Registration.PackageID.Value);
        WebReport1.Report.RegisterData(Registrations, "Registration");
        WebReport1.Report.RegisterData(Packages, "Packages");
        WebReport1.Report.RegisterData(GroupItems, "ItemGroups");
        WebReport1.Prepare();
        //WebReport1.Report.PrintSettings.ShowDialog = false;
        //WebReport1.Report.Print();

    }

    private void BuildIntroductionsReport()
    {
        List<String> List = (List<String>)Session["Registrations"];
        if (List == null) return;
        WebReport1.ReportFile = Server.MapPath("IntroductionListReport.frx");
        List<RegistrationViewEntity> Registrations = new List<RegistrationViewEntity>();
        foreach (String RegisterNo in List)
        {
            Registrations.Add(m_Registration.GetRegistration(RegisterNo));
        }
        List<Package> Packages = new List<Package>();
        List<GroupItem> GroupItems = new List<GroupItem>();
        foreach (RegistrationViewEntity Registration in Registrations)
        {
            Packages.AddRange(m_ReportUtil.GetPackageItems(Registration.RegisterNo, Registration.PackageID.Value));
            GroupItems.AddRange(m_ReportUtil.GetGroupItems(Registration.RegisterNo, Registration.PackageID.Value));
        }
        WebReport1.Report.RegisterData(Registrations, "Registration");
        WebReport1.Report.RegisterData(Packages, "Packages");
        WebReport1.Report.RegisterData(GroupItems, "ItemGroups");
        WebReport1.Prepare();
        Session.Remove("Registrations");
    }

    #endregion
}


