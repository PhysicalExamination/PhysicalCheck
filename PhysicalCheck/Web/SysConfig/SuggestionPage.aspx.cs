using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataEntity.SysConfig;
using Common.FormatProvider;
using BusinessLogic.SysConfig;

public partial class SysConfig_SuggestionPage : BasePage {

    #region 私有成员

    private SuggestionBusiness m_Suggestion;

    #endregion

    #region 属性

    private int SNo {
        get {
            if (ViewState["SNo"] == null) return int.MinValue;
            return (int)ViewState["SNo"];
        }
        set {
            ViewState["SNo"] = value;
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
        m_Suggestion = new SuggestionBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Suggestion.Dispose();
        m_Suggestion = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        SuggestionRepeater.DataSource = m_Suggestion.GetSuggestions(Pager.CurrentPageIndex,
            Pager.PageSize,out RecordCount);
        Pager.RecordCount = RecordCount;
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
            btnDelete.Enabled = IsAdmin;
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
    private void ClearSuggestionUI() {
        SNo = int.MinValue;
        txtName.Text = "";
        txtKeyWord.Text = "";
        hDeptID.Value = "";
        txtSuggestion.Text = "";
        txtExplain.Text = "";
        //txtDisplayOrder.Text = "";        
    }

    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetSuggestionUI() {
        SuggestionViewEntity Result = m_Suggestion.GetSuggestion(SNo);
        if (Result == null) return;     
        txtName.Text = Result.Name;
        txtKeyWord.Text = Result.KeyWord;
        hDeptID.Value = Result.DeptID + "";
        txtDeptName.Text = Result.DeptName;
        txtSuggestion.Text = Result.Suggestion;
        txtExplain.Text = Result.Explain;
        //txtDisplayOrder.Text = Result.DisplayOrder + "";
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private SuggestionEntity GetSuggestionUI() {
        SuggestionEntity Result = new SuggestionEntity();
        Result.SNo = SNo;
        Result.Name = txtName.Text;
        Result.KeyWord = txtKeyWord.Text;
        Result.DeptID = EnvConverter.ToInt32(hDeptID.Value);
        Result.Suggestion = txtSuggestion.Text;
        Result.Explain = txtExplain.Text;
        //Result.DisplayOrder = EnvConverter.ToInt32(txtDisplayOrder.Text);
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveSuggestion_Click(object sender, EventArgs e) {
        SuggestionEntity Result = GetSuggestionUI();
        m_Suggestion.SaveSuggestion(Result);
        ShowMessage("数据保存成功!");
        //int Succeed = m_Suggestion.SaveSuggestion(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewSuggestion_Click(object sender, EventArgs e) {
        ClearSuggestionUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteSuggestion_Click(object sender, EventArgs e) {
        m_Suggestion.DeleteSuggestion(GetSuggestionUI());
        ShowMessage("数据删除成功!");
        //int Succeed = m_Suggestion.DeleteSuggestion(GetSuggestionUI());
        //if (Succeed > 0) ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditSuggestion_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelSuggestion_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void SuggestionItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            Literal lblSNo = (Literal)e.Item.FindControl("lblSNo");
            SNo = Convert.ToInt32(lblSNo.Text);           
            SetSuggestionUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}