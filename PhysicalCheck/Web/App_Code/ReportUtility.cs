using BusinessLogic.Admin;
using BusinessLogic.Examination;
using BusinessLogic.SysConfig;
using DataEntity.Admin;
using DataEntity.Examination;
using DataEntity.SysConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ReportUtility 的摘要说明
/// </summary>
public class ReportUtility {

    private RegistrationBusiness m_Registration;

    public ReportUtility() {
        m_Registration = new RegistrationBusiness();
    }

    public List<GroupItemResult> GetGroupResults(String RegisterNo) {
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

    public List<ItemResult> GetItemResults(String RegisterNo, int GroupID) {
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

    public List<BarCode> GetBarCodes(String RegisterNo) {
        var q = from p in m_Registration.GetGroupResults(RegisterNo)
                select new BarCode {
                    RegisterNo = p.ID.RegisterNo,
                    GroupName = p.GroupName
                };
        return q.ToList();
    }

    /// <summary>
    /// 武威市古浪县条码打印
    /// </summary>
    /// <param name="RegisterNo"></param>
    /// <returns></returns>
    public List<BarCode> GetBarCodesForGuLang(String RegisterNo) {
        List<BarCode> Result = new List<BarCode>();
        RegistrationViewEntity RegInfo = m_Registration.GetRegistration(RegisterNo);
        Result.Add(new BarCode {
            RegisterNo = RegInfo.RegisterNo,
            GroupName = RegInfo.Name
        });
        return Result;

    }

    public List<Package> GetPackageItems(int PackageID) {
        //0 检查科室 1 检验科室 2 功能科室
        String[] Names = new String[] { "医生检查项目", "抽血及其它化验项目", "功能检查项目" };
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

    public List<GroupItem> GetGroupItems(int PackageID) {
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

public class HealthCardInfo {

    public String RegisterNo {
        get;
        set;
    }

    public DateTime CheckDate {
        get;
        set;
    }

    public DateTime LimitDate {
        get;
        set;
    }

    public String Sex {
        get;
        set;
    }

    public String Name {
        get;
        set;
    }

    public byte[] Photo {
        get;
        set;
    }
}