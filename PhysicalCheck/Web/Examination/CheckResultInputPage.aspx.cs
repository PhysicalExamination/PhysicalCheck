using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using Common.FormatProvider;
using DataEntity.Examination;

public partial class Examination_CheckResultInputPage : BasePage {

    #region 私有成员

    private ItemResultBusiness m_ItemResult;
    private GroupResultBusiness m_GroupResut;

    private int? PackageID {
        get {
            if (ViewState["PackageID"] == null) return null;
            return (int?)ViewState["PackageID"];
        }
        set {
            ViewState["PackageID"] = value;
        }

    }

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
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
        int RecordCount = 0;
        String RegisterNo = txtsRegisterNo.Text.Trim();
        ItemResultRepeater.DataSource = m_ItemResult.GetDeptItemResults(Pager.CurrentPageIndex,
            Pager.PageSize, RegisterNo, DepartNo, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object Source, EventArgs e) {
        Literal lblItemID;
        int? GroupID = Convert.ToInt32(drpGroups.SelectedValue), ItemID;
        ItemResultEntity ItemResult;
        RepeaterItemCollection Items = ItemResultRepeater.Items;
        foreach (RepeaterItem Item in Items) {
            lblItemID = (Literal)Item.FindControl("lblItemID");
            ItemID = EnvConverter.ToInt32(lblItemID.Text);
            ItemResult = new ItemResultEntity {
                ID = new ItemResultPK { ItemID = ItemID, GroupID = GroupID },
                DeptID = DepartNo,
                CheckDate = DateTime.Now.Date,
                CheckDoctor = UserName,
                CheckedResult = ""
            };
            m_ItemResult.SaveItemResult(ItemResult);
        }

        GroupResultEntity Group = new GroupResultEntity {
            ID = new GroupResultPK { GroupID = GroupID, RegisterNo = txtsRegisterNo.Text },
            DeptID = DepartNo,
            CheckDate = DateTime.Now.Date,
            CheckDoctor = UserName,
            IsOver = true,
            Summary = txtSummary.Text,
            PackageID = null
        };
        m_GroupResut.SaveGroupResult(Group);

    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void txtsRegisterNo_TextChanged(object sender, EventArgs e) {
        String RegisterNo = txtsRegisterNo.Text.Trim();
        List<GroupResultViewEntity> List = m_GroupResut.GetGroupResults(RegisterNo);
        if (List.Count > 0) {
            PackageID = List[0].PackageID;
            drpGroups.DataSource = List.Where(p => p.DeptID == DepartNo).ToList();
            drpGroups.DataTextField = "GroupName";
            drpGroups.DataValueField = "ID.GroupID";
            drpGroups.DataBind();
        }
    }
    #endregion


}