using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using Common.FormatProvider;
using DataEntity.Examination;
using BusinessLogic.SysConfig;
using BusinessLogic.Admin;

public partial class Examination_CheckResultInputPage : BasePage {

    #region 私有成员

    private ItemResultBusiness m_ItemResult;
    private GroupResultBusiness m_GroupResut;

    private String RegisterNo {
        get {
            if (ViewState["RegisterNo"] == null) return "";
            return (String)ViewState["RegisterNo"];
        }
        set {
            ViewState["RegisterNo"] = value;
        }
    }
    private int? PackageID {
        get {
            if (ViewState["PackageID"] == null) {
                using (RegistrationBusiness Registration = new RegistrationBusiness()) {
                    ViewState["PackageID"] = Registration.GetRegistration(RegisterNo).PackageID;
                }
            }
            return (int?)ViewState["PackageID"];
        }
    }

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            ClientInitial();
            DataBind();
        }
    }

    protected override void OnInit(EventArgs e) {
        m_ItemResult = new ItemResultBusiness();
        m_GroupResut = new GroupResultBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_ItemResult.Dispose();
        m_ItemResult = null;
        m_GroupResut.Dispose();
        m_GroupResut = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        using (RegistrationBusiness Registration = new RegistrationBusiness()) {
            int RecordCount = 0;
            DateTime CheckDate = Convert.ToDateTime(txtCheckedDate.Text);
            RegistrationRepeater.DataSource = Registration.GetCheckedList(Pager.CurrentPageIndex, Pager.PageSize,
            CheckDate, out RecordCount);
            Pager.RecordCount = RecordCount;
        }
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object Source, EventArgs e) {
        if (ItemResultRepeater.Items.Count <= 0) return;
        Literal lblItemID, lblGroupID;
        TextBox txtCheckResult;
        int? GroupID, ItemID;
        ItemResultEntity ItemResult;
        RepeaterItemCollection Items = ItemResultRepeater.Items;
        foreach (RepeaterItem Item in Items) {
            lblItemID = (Literal)Item.FindControl("lblItemID");
            lblGroupID = (Literal)Item.FindControl("lblGroupID");
            txtCheckResult = (TextBox)Item.FindControl("txtCheckResult");
            ItemID = EnvConverter.ToInt32(lblItemID.Text);
            GroupID = EnvConverter.ToInt32(lblGroupID.Text);
            ItemResult = new ItemResultEntity {
                ID = new ItemResultPK { ItemID = ItemID, GroupID = GroupID, RegisterNo = RegisterNo },
                DeptID = Convert.ToInt32(drpDepts.SelectedValue),
                CheckDate = DateTime.Now.Date,
                CheckDoctor = UserName,
                CheckedResult = txtCheckResult.Text
            };
            m_ItemResult.SaveItemResult(ItemResult);
        }
        lblGroupID = (Literal)Items[0].FindControl("lblGroupID");
        GroupID = Convert.ToInt32(lblGroupID.Text);
        GroupResultEntity Group = new GroupResultEntity {
            ID = new GroupResultPK { GroupID = GroupID, RegisterNo = RegisterNo },
            DeptID = Convert.ToInt32(drpDepts.SelectedValue),
            CheckDate = DateTime.Now.Date,
            CheckDoctor = UserName,
            IsOver = true,
            Summary = txtSummary.Text,
            IsPassed = chkIsPassed.Checked,
            PackageID = PackageID
        };
        m_GroupResut.SaveGroupResult(Group);
        ShowMessage("数据保存成功！");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object sender, RepeaterCommandEventArgs e) {
        Literal lblRegisterNo = (Literal)e.Item.FindControl("lblRegisterNo");
        RegisterNo = lblRegisterNo.Text;
        ItemResultBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void Pager1_PageChanged(object source, EventArgs e) {
        ItemResultBind();
    }

    protected void drpDepts_SelectedIndexChanged(object sender, EventArgs e) {
        ItemResultBind();
    }
    #endregion

    #region 私有方法

    private void ClientInitial() {
        txtCheckedDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        using (DepartmentBusiness Department = new DepartmentBusiness()) {
            drpDepts.DataSource = Department.GetDepartments().OrderBy(p=>p.DeptID);
            drpDepts.DataValueField = "DeptID";
            drpDepts.DataTextField = "DeptName";
            drpDepts.DataBind();
        }
    }

    private void ItemResultBind() {
        int RecordCount = 0;
        int DeptID = Convert.ToInt32(drpDepts.SelectedValue);
        ItemResultRepeater.DataSource = m_ItemResult.GetDeptItemResults(Pager1.CurrentPageIndex,
            Pager1.PageSize, RegisterNo, DeptID, out RecordCount);
        Pager1.RecordCount = RecordCount;
        ItemResultRepeater.DataBind();
    }

    #endregion


    
}