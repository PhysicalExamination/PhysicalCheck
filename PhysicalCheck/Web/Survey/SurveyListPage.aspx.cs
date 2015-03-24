using BusinessLogic.Survey;
using Common.FormatProvider;
using DataEntity.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 调查问卷模板
/// </summary>
public partial class Survey_SurveyListPage : BasePage {

    #region 私有成员

    private SurveyListBusiness m_SurveyList;

    #endregion

    #region 属性

    private int SID {
        get {
            if (ViewState["SID"] == null) return int.MinValue;
            return (int)ViewState["SID"];
        }
        set {
            ViewState["SID"] = value;
        }
    }


    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();
            SetUIState("Default");
        }
    }

    protected override void OnInit(EventArgs e) {
        m_SurveyList = new SurveyListBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_SurveyList.Dispose();
        m_SurveyList = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 调查问卷模板数据绑定
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        SurveyRepeater.DataSource = m_SurveyList.GetSurveyLists(Pager.CurrentPageIndex,
            Pager.PageSize, out RecordCount);
        base.DataBind();
    }
    /// <summary>
    /// 设置界面控件显示状态
    /// </summary>
    /// <param name="Enabled"></param>
    private void SetUIStatus(bool Enabled) {
        ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
        foreach (Control ctrl in Controls) {
            if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
        }
    }
    /// <summary>
    /// 设置界面按钮显示状态
    /// </summary>
    /// <param name="State"></param>
    private void SetUIState(string State) {
        if (State == "Default") {
            SetUIStatus(false);
            btnNew.Enabled = CanEditData;
            btnEdit.Enabled = CanEditData;
            btnDelete.Enabled = CanEditData;
            btnSave.Enabled = false;
        }
        if (State == "New") {
            SetUIStatus(true);
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        if (State == "Edit") {
            SetUIStatus(true);
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
    }

    #endregion

    #region 私有成员

    /// <summary>
    /// 重置界面
    /// </summary>
    private void ClearSurveyListUI() {
        SID = int.MinValue;
        txtSurveyName.Text = "";
        drpSex.SelectedIndex =-1;
        txtDisease.Text = "";       
        txtDescription.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetSurveyListUI() {
        SurveyListEntity Result = m_SurveyList.GetSurveyList(SID);
        if (Result == null) return;       
        txtSurveyName.Text = Result.SurveyName;
        drpSex.SelectedValue = Result.Sex;
        txtDisease.Text = Result.Disease;
        txtDescription.Text = Result.Description;
    }

    /// <summary>
    /// 从界面获取调查问卷模板对象
    /// </summary>
    /// <returns></returns>
    private SurveyListEntity GetSurveyListUI() {
        SurveyListEntity Result = new SurveyListEntity();
        Result.SID = SID;
        Result.SurveyName = txtSurveyName.Text;
        Result.Sex = drpSex.SelectedValue;
        Result.Disease = txtDisease.Text;
        Result.Description = txtDescription.Text;
        return Result;
    }

    #endregion

    #region  受保护方法

    protected String GetSex(object SexValue) {
        String Sex = SexValue as String;
        if (Sex == "%") return "所有性别";
        if (Sex == "1") return "男";
        if (Sex == "2") return "女";
        return "";
    }

    #endregion

    #region 事件

    protected void btnSaveSurveyList_Click(object sender, EventArgs e) {
        SurveyListEntity Result = GetSurveyListUI();
        try {
            m_SurveyList.SaveSurveyList(Result);
            SID = Result.SID;
            ShowMessage("数据保存成功!");  
        }
        catch {
            ShowMessage("数据保存失败!");  
        }             
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewSurveyList_Click(object sender, EventArgs e) {
        ClearSurveyListUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteSurveyList_Click(object sender, EventArgs e) {      
        try {
            m_SurveyList.DeleteSurveyList(GetSurveyListUI());
            ShowMessage("数据删除成功!");
        }
        catch {
            ShowMessage("数据删除失败!");
        }          
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditSurveyList_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelSurveyList_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {           
            SID =Convert.ToInt32(e.CommandArgument);          
            SetSurveyListUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}
