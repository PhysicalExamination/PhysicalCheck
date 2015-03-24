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
/// 调查问卷
/// </summary>
public partial class Survey_SurveyQuestionPage : BasePage {

    #region 私有成员

    private SurveyQuestionBusiness m_SurveyQuestion;

    #endregion

    #region 属性

    private int QID {
        get {
            if (ViewState["QID"] == null) return int.MinValue;
            return (int)ViewState["QID"];
        }
        set {
            ViewState["QID"] = value;
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
        m_SurveyQuestion = new SurveyQuestionBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_SurveyQuestion.Dispose();
        m_SurveyQuestion = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        QuestionRepeater.DataSource = m_SurveyQuestion.GetSurveyQuestions();
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
    private void ClearSurveyQuestionUI() {
        QID = int.MinValue;
        txtTitle.Text = "";
        txtDescription.Text = "";
        chkRequired.Checked = false;
        drpQTypes.SelectedIndex=-1;;
        chkMultipe.Checked = false;
        txtNormalLower.Text = "";
        txtNormalUpper.Text = "";
        txtValidLower.Text = "";
        txtValidUpper.Text = "";
        txtUnit.Text = "";        
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetSurveyQuestionUI() {
        SurveyQuestionEntity Result = m_SurveyQuestion.GetSurveyQuestion(QID);
        if (Result == null) return;        
        txtTitle.Text = Result.Title;
        txtDescription.Text = Result.Description;
        drpQTypes.SelectedValue = Result.QType;
        chkRequired.Checked = Result.Required;
        chkMultipe.Checked = Result.Multipe;
        txtNormalLower.Text = Result.NormalLower;
        txtNormalUpper.Text = Result.NormalUpper;
        txtValidLower.Text = Result.ValidLower;
        txtValidUpper.Text = Result.ValidUpper;
        txtUnit.Text = Result.Unit;
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private SurveyQuestionEntity GetSurveyQuestionUI() {
        SurveyQuestionEntity Result = new SurveyQuestionEntity();
        Result.QID = QID;
        Result.Title = txtTitle.Text;
        Result.Description = txtDescription.Text;
        Result.QType = drpQTypes.SelectedValue;
        Result.Required = chkRequired.Checked;
        Result.Multipe = chkMultipe.Checked;
        Result.NormalLower = txtNormalLower.Text;
        Result.NormalUpper = txtNormalUpper.Text;
        Result.ValidLower = txtValidLower.Text;
        Result.ValidUpper = txtValidUpper.Text;
        Result.Unit = txtUnit.Text;
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveSurveyQuestion_Click(object sender, EventArgs e) {
        SurveyQuestionEntity Result = GetSurveyQuestionUI();        
        try {
            m_SurveyQuestion.SaveSurveyQuestion(Result);
            QID = Result.QID;
            ShowMessage("数据保存成功!");
        }
        catch {
            ShowMessage("数据保存失败!");
        }      
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewSurveyQuestion_Click(object sender, EventArgs e) {
        ClearSurveyQuestionUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteSurveyQuestion_Click(object sender, EventArgs e) {
        try {
            m_SurveyQuestion.DeleteSurveyQuestion(GetSurveyQuestionUI());
            ShowMessage("数据删除成功!");
        }
        catch {
            ShowMessage("数据删除失败!");
        }     
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditSurveyQuestion_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelSurveyQuestion_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            QID = Convert.ToInt32(e.CommandArgument);
            //EnterpriseID = lblEnterpriseID.Text;
            SetSurveyQuestionUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}
