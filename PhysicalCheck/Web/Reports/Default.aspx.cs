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

public partial class Reports_Default : BasePage {

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
            String RegisterNo = Request.Params["RegisterNo"];//"20141214000043"
            String ReportKind = Request.Params["ReportKind"];
            if (ReportKind == "1") BuildBarCodeReport(RegisterNo);// 条码
            if (ReportKind == "2") BuildCheckReport(RegisterNo);//体检报告
            if (ReportKind == "3") BuildIntroductionReport(RegisterNo);
            //BuildIntroduction(RegisterNo);
        }
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
        using (PackageBusiness Business = new PackageBusiness()) {
            Business.GetPackageGroups(1);
        }
        List<Package> Packages = GetPackageItems(Registration.PackageID.Value);
        List<GroupItem> GroupItems = GetGroupItems(Registration.PackageID.Value);
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


    private List<Package> GetPackageItems(int PackageID) {
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
                    GroupID = Convert.ToInt32(g.Key),
                    PackageName = Names[Convert.ToInt32(g.Key)] + g.Count() + "项"
                };
        return q.ToList();
    }

    private List<GroupItem> GetGroupItems(int PackageID) {
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