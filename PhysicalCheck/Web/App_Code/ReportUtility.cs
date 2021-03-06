﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLogic.SysConfig;
using BusinessLogic.Examination;
using DataEntity.SysConfig;
using BusinessLogic.Admin;
using DataEntity.Examination;

/// <summary>
///报表辅助工具类
/// </summary>
public class ReportUtility {

    #region 私有成员

    private RegistrationBusiness m_Registration;

    #endregion

    #region 构造器

    public ReportUtility() {
        m_Registration = new RegistrationBusiness();
    }

    #endregion

    #region 公共方法

    public List<GroupItemResult> GetGroupResults(String RegisterNo) {
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
                    NormalTips = p.QualitativeResult,
                    CheckDoctor = p.CheckDoctor,
                    CheckDate = p.CheckDate
                };
        return q.ToList();
    }

    public List<BarCode> GetBarCodes(String RegisterNo) {
        ItemGroupBusiness ItemGroup = new ItemGroupBusiness();
        List<ItemGroupViewEntity> Groups = ItemGroup.GetItemGroups();
        var q = from A in m_Registration.GetGroupResults(RegisterNo)
                join B in Groups on A.ID.GroupID equals B.GroupID
                where B.HasBarCode == true
                select new BarCode { RegisterNo = A.ID.RegisterNo, GroupName = A.GroupName };
        return q.ToList();
    }


    public List<Package> GetPackageItems(String RegisterNo, int PackageID) {
        //0 检查科室 1 检验科室 2 功能科室
        String[] Names = new String[] { "医生检查项目", "抽血及其它化验项目", "功能检查项目" };
        GroupResultBusiness GroupResult = new GroupResultBusiness();
        DepartmentBusiness Department = new DepartmentBusiness();
        var q = from a in GroupResult.GetGroupResults(RegisterNo)
                join b in Department.GetDepartments() on a.DeptID equals b.DeptID
                group b by b.DeptKind into g
                select new Package {
                    RegisterNo = RegisterNo,
                    GroupID = Convert.ToInt32(g.Key),
                    PackageName = Names[Convert.ToInt32(g.Key)] + g.Count() + "项"
                };
        //return q.ToList();
        //Added by pyf 2015-02-26 按23医院要求排序（化验项目 医生检查项目 功能项目）
        List<Package> Groups = q.ToList();
        List<Package> Result = new List<Package>();
        List<Package> Temps = Groups.Where(p => p.GroupID == 1).ToList();
        if (Temps.Count > 0) Result.AddRange(Temps);
        Temps = Groups.Where(p =>( p.GroupID == 0 || p.GroupID==2)).ToList();
        Result.AddRange(Temps);
        //End of added
        return Result;
    }

    public List<GroupItem> GetGroupItems(String RegisterNo, int PackageID) {
        ItemGroupBusiness ItemGroup = new ItemGroupBusiness();
        GroupResultBusiness GroupResult = new GroupResultBusiness();
        DepartmentBusiness Department = new DepartmentBusiness();
        var q = from a in GroupResult.GetGroupResults(RegisterNo)
                join b in ItemGroup.GetItemGroups() on a.ID.GroupID equals b.GroupID
                join c in Department.GetDepartments() on a.DeptID equals c.DeptID
                select new GroupItem {
                    RegisterNo = RegisterNo,
                    GroupID = Convert.ToInt32(c.DeptKind),
                    GroupName = a.GroupName,
                    Clinical = b.Clinical,
                    Notice = b.Notice,
                    Price = b.Price.Value
                };
        q = q.OrderBy(p => p.GroupID);
        return q.ToList();
    }

    #endregion
}

#region 内部类

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

    public decimal Price {
        get;
        set;
    }
}

#endregion