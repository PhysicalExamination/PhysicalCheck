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
            if (ReportKind == "3") BuildIntroductionReport(RegisterNo);
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

        string sqlw = " 1=1 ";

        if (Request.Params["RegisterNo"] != "")
            sqlw += string.Format("  And RegisterNo like '%{0}%' ", Request.Params["RegisterNo"]);

        if (Request.Params["DeptName"] != "")
            sqlw += string.Format("  And DeptName like '%{0}%' ",Request.Params["DeptName"] );

        if (Request.Params["Name"] != "")
            sqlw += string.Format("  And Name like '%{0}%' ", Request.Params["Name"]);


        if (Request.Params["IdNumber"] != "")
            sqlw += string.Format("  And IdNumber like '{0}%' ", Request.Params["IdNumber"]);

        if (Request.Params["OverallDoctor"] != "")
            sqlw += string.Format("  And OverallDoctor like '{0}%' ", Request.Params["OverallDoctor"]);


        if (Request.Params["StartDate"] != "")
            sqlw += string.Format(" And  RegisterDate>='{0}' ", Convert.ToDateTime(Request.Params["StartDate"]));

        if (Request.Params["EndDate"] != "")
            sqlw += string.Format("  And RegisterDate<'{0}' ", Convert.ToDateTime(Request.Params["EndDate"]).AddDays(1));



        DataSet ds = bll.GetList_Composed(sqlw );

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
        WebReport1.Report.RegisterData(GetBarCodes(RegisterNo), "BarCodes");
        WebReport1.Report.Prepare();
    }

    public void BuildCheckReport(String RegisterNo) {
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

    public void BuildIntroductionReport(String RegisterNo) {
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

    public void BuildIntroductionListReport() {
        WebReport1.ReportFile = Server.MapPath("IntroductionListReport.frx");
        int RecordCount = 0;
        IList<RegistrationViewEntity> Registrations = m_Registration.GetRegistrations(1, 200, null, "北斗", null, out RecordCount);
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
                    GroupID = p.ID.GroupID.Value,
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

public class GroupItemResult {

    /// <summary>
    /// 组合项目
    /// </summary>		
    public int GroupID {
        get;
        set;
    }

    /// <summary>
    /// 组合项目名称
    /// </summary>		
    public string GroupName {
        get;
        set;
    }
    /// <summary>
    /// 检查科室名称
    /// </summary>		
    public string DeptName {
        get;
        set;
    }

    /// <summary>
    /// 检查医生
    /// </summary>		
    public string CheckDoctor {
        get;
        set;
    }

    /// <summary>
    /// 检查日期
    /// </summary>		
    public DateTime? CheckDate {
        get;
        set;
    }

    /// <summary>
    /// 小结
    /// </summary>		
    public string Summary {
        get;
        set;
    }
}

public class ItemResult {

    /// <summary>
    /// 组合项目
    /// </summary>		
    public int GroupID {
        get;
        set;
    }

    public string ItemName {
        get;
        set;
    }


    /// <summary>
    /// 检查结果
    /// </summary>		
    public string CheckedResult {
        get;
        set;
    }

    /// <summary>
    /// 检查医生
    /// </summary>		
    public string CheckDoctor {
        get;
        set;
    }

    /// <summary>
    /// 检查日期
    /// </summary>		
    public DateTime? CheckDate {
        get;
        set;
    }

    /// <summary>
    /// 计量单位
    /// </summary>		
    public string MeasureUnit {
        get;
        set;
    }

    /// <summary>
    /// 参考下限
    /// </summary>		
    public string LowerLimit {
        get;
        set;
    }

    /// <summary>
    /// 参考上限
    /// </summary>		
    public string UpperLimit {
        get;
        set;
    }

    /// <summary>
    /// 正常提示
    /// </summary>		
    public string NormalTips {
        get;
        set;
    }
}

public class Package {

    public String RegisterNo {
        get;
        set;
    }

    public int GroupID {
        get;
        set;
    }
    public String PackageName {
        get;
        set;
    }
}

public class GroupItem {

    public String RegisterNo {
        get;
        set;
    }

    public int GroupID {
        get;
        set;
    }

    public String GroupName {
        get;
        set;
    }

    public String Clinical {
        get;
        set;
    }

    public String Notice {
        get;
        set;
    }
}