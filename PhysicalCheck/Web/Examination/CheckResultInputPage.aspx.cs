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
using DataEntity.SysConfig;

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
            RegistrationRepeater.DataSource = Registration.GetCheckedList(Pager.CurrentPageIndex, 
                Pager.PageSize,CheckDate,txtRegisterNo.Text, out RecordCount);
            Pager.RecordCount = RecordCount;
        }
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object Source, EventArgs e) {
        if (ItemResultRepeater.Items.Count <= 0) return;
        Literal lblItemID, /*lblGroupID, */lblDeptID;
        TextBox txtCheckResult;
        int? ItemID;
        int GroupID = Convert.ToInt32(drpGroups.SelectedValue);      
        ItemResultEntity ItemResult;
        RepeaterItemCollection Items = ItemResultRepeater.Items;
        foreach (RepeaterItem Item in Items) {
            lblItemID = (Literal)Item.FindControl("lblItemID");
            //lblGroupID = (Literal)Item.FindControl("lblGroupID");
            lblDeptID = (Literal)Item.FindControl("lblDeptID");
            txtCheckResult = (TextBox)Item.FindControl("txtCheckResult");
            ItemID = EnvConverter.ToInt32(lblItemID.Text);
            
            ItemResult = new ItemResultEntity {
                ID = new ItemResultPK { ItemID = ItemID, GroupID = GroupID, RegisterNo = RegisterNo },
                DeptID = Convert.ToInt32(lblDeptID.Text),
                CheckDate = DateTime.Now.Date,
                CheckDoctor = UserName,
                CheckedResult = txtCheckResult.Text
            };
            m_ItemResult.SaveItemResult(ItemResult);
        }
        //lblGroupID = (Literal)Items[0].FindControl("lblGroupID");
        lblDeptID = (Literal)Items[0].FindControl("lblDeptID");
        String Summary = "【"+ drpGroups.SelectedItem.Text + "】检查" ;
        Summary += chkIsPassed.Checked ? "合格" : "不合格";
        GroupResultEntity Group = new GroupResultEntity {
            ID = new GroupResultPK { GroupID = GroupID, RegisterNo = RegisterNo },
            DeptID = Convert.ToInt32(lblDeptID.Text),
            CheckDate = DateTime.Now.Date,
            CheckDoctor = UserName,
            IsOver = true,
            Summary = Summary,
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

    protected void drpGroups_SelectedIndexChanged(object sender, EventArgs e) {
        ItemResultBind();
        
    }
    #endregion

    #region 私有方法

    private void ClientInitial() {
        txtCheckedDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");       
        using (ItemGroupBusiness Business = new ItemGroupBusiness()) {
            List<ItemGroupViewEntity> ItemGroups = Business.GetItemGroups();
            drpGroups.DataSource = ItemGroups.Where(p => p.DeptID == DepartNo);
            drpGroups.DataValueField = "GroupID";
            drpGroups.DataTextField = "GroupName";
            drpGroups.DataBind();
        }
    }

    private void ItemResultBind() {       
        int GroupID = Convert.ToInt32(drpGroups.SelectedValue);
        List<ItemResultViewEntity> DataSource = m_ItemResult.GetItemResults(RegisterNo, GroupID);
        ItemResultRepeater.DataSource = DataSource;
        Pager1.RecordCount = DataSource.Count;
        ItemResultRepeater.DataBind();       
        GroupResultViewEntity Result = m_GroupResut.GetGroupResult(RegisterNo, GroupID);
        if (Result == null) return;
        //txtSummary.Text = Result.Summary;
        chkIsPassed.Checked = Result.IsPassed;
    }

    #endregion


    
}