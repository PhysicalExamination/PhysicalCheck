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
using DataEntity.SysConfig;

public partial class Examination_CheckResultInputPage : BasePage {

    #region 私有成员

    private ItemResultBusiness m_ItemResult;
    private GroupResultBusiness m_GroupResut;
    private RegistrationBusiness m_Regist;

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

    protected bool InputEnabled {
        get {
            if (ViewState["InputEnabled"] == null) return true;
            return (bool)ViewState["InputEnabled"];
        }
        set {
            ViewState["InputEnabled"] = value;
        }
    }

    private string RegisterNo {
        get {
            if (ViewState["RegisterNo"] == null) return Request.Params["id"];
            return (string)ViewState["RegisterNo"];
        }
        set {
            ViewState["RegisterNo"] = value;
        }
    }

    private string GroupId {
        get {
            if (ViewState["GroupId"] == null) return Request.Params["GroupId"];
            return (string)ViewState["GroupId"];
        }
        set {
            ViewState["GroupId"] = value;
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
        m_Regist = new RegistrationBusiness();
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
    // public override void DataBind() {
    //int RecordCount = 0;       
    //ItemResultRepeater.DataSource = m_ItemResult.GetDeptItemResults(Pager.CurrentPageIndex,
    //    Pager.PageSize, RegisterNo, Convert.ToInt32( GroupId), out RecordCount);
    //Pager.RecordCount = RecordCount;
    /*ItemResultRepeater.DataSource = m_ItemResult.GetDeptItemResults(
        RegisterNo, Convert.ToInt32(GroupId));
    base.DataBind();
    GroupResultViewEntity GroupResult = m_GroupResut.GetGroupResult(RegisterNo, Convert.ToInt32(GroupId));
    if (GroupResult != null) txtSummary.Text = GroupResult.Summary;
    TextBox txtCheckResult;
    RepeaterItemCollection Items = ItemResultRepeater.Items;
    foreach (RepeaterItem Item in Items) {
        txtCheckResult = (TextBox)Item.FindControl("txtCheckResult");
        txtCheckResult.Enabled = InputEnabled;
    }*/
    //}

    /// <summary>
    /// 数据绑定体检登记
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        DateTime? CheckDate = EnvConverter.ToDateTime(txtCheckDate.Text);
        String DeptName = txtDeptName.Text.Trim();
        String RegisterNo = txtRegisterNo.Text.Trim();
        Registrations.DataSource = m_Regist.GetRegistrations(Pager.CurrentPageIndex, Pager.PageSize,
            CheckDate, DeptName, RegisterNo, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object Source, EventArgs e) {
        RegisterNo = hRegisterNo.Value;
        GroupId = hGroupID.Value;
        if (String.IsNullOrWhiteSpace(RegisterNo)) {
            ShowMessage("数据保存失败，请输入体检登记号。");
            return;
        }
        Literal lblItemID;
        TextBox txtCheckResult;
        int GroupID = Convert.ToInt32(GroupId), ItemID;
        ItemResultEntity ItemResult;
        RepeaterItemCollection Items = ItemResultRepeater.Items;
        foreach (RepeaterItem Item in Items) {
            lblItemID = (Literal)Item.FindControl("lblItemID");
            txtCheckResult = (TextBox)Item.FindControl("txtCheckResult");
            ItemID = Convert.ToInt32(lblItemID.Text);
            //ItemResult = m_ItemResult.GetItemResult(RegisterNo, GroupID, ItemID);
            ItemResult = new ItemResultEntity {
                ID = new ItemResultPK {
                    ItemID = ItemID,
                    GroupID = GroupID,
                    RegisterNo = RegisterNo
                },
                DeptID = DepartNo,
                CheckDate = DateTime.Now.Date,
                CheckDoctor = UserName,
                CheckedResult = txtCheckResult.Text
            };
            m_ItemResult.SaveItemResult(ItemResult);
        }

        GroupResultEntity Group = new GroupResultEntity {
            ID = new GroupResultPK {
                GroupID = GroupID,
                RegisterNo = RegisterNo
            },
            DeptID = DepartNo,
            CheckDate = DateTime.Now.Date,
            CheckDoctor = UserName,
            IsOver = true,
            Summary = txtSummary.Text,
            PackageID = PackageID
        };
        m_GroupResut.SaveGroupResult(Group);
        ShowMessage("数据保存成功！");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnGetItemResult_Click(object sender, EventArgs e) {
        DataBind();
        ItemResultRepeater.DataSource = m_ItemResult.GetDeptItemResults(
            hRegisterNo.Value, Convert.ToInt32(hGroupID.Value));
        base.DataBind();
        GroupResultViewEntity GroupResult = m_GroupResut.GetGroupResult(RegisterNo, Convert.ToInt32(GroupId));
        if (GroupResult != null) txtSummary.Text = GroupResult.Summary;
        TextBox txtCheckResult;
        RepeaterItemCollection Items = ItemResultRepeater.Items;
        foreach (RepeaterItem Item in Items) {
            txtCheckResult = (TextBox)Item.FindControl("txtCheckResult");
            txtCheckResult.Enabled = InputEnabled;
        }
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "setUIStatus", "setUIStatus();", true);

    }
    #endregion

}