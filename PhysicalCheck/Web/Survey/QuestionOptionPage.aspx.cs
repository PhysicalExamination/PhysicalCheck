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
/// 
/// </summary>
public partial class Survey_QuestionOptionPage : BasePage {

    #region 私有成员

    private QuestionOptionBusiness m_QuestionOption;

    #endregion

    #region 属性

    private string EnterpriseID {
        get {
            if (ViewState["EnterpriseID"] == null) return string.Empty;
            return (string)ViewState["EnterpriseID"];
        }
        set {
            ViewState["EnterpriseID"] = value;
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
        m_QuestionOption = new QuestionOptionBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_QuestionOption.Dispose();
        m_QuestionOption = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        //QuestionOptionRepeater.DataSource = m_QuestionOption.GetQuestionOptions();
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
    private void ClearQuestionOptionUI() {
        //txtQID.Text = "";
        //txtSN.Text = "";
        txtOptionTitle.Text = "";
        txtOptionValue.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetQuestionOptionUI() {
        //QuestionOptionEntity Result = m_QuestionOption.GetQuestionOption(EnterpriseID);
        //if (Result == null) return;
        //txtQID.Text = Result.QID + "";
        //txtSN.Text = Result.SN + "";
        //txtOptionTitle.Text = Result.OptionTitle;
        //txtOptionValue.Text = Result.OptionValue + "";
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private QuestionOptionEntity GetQuestionOptionUI() {
        QuestionOptionEntity Result = new QuestionOptionEntity();
        //Result.QID = EnvConverter.ToInt32(txtQID.Text);
        //Result.SN = EnvConverter.ToInt32(txtSN.Text);
        Result.OptionTitle = txtOptionTitle.Text;
        //Result.OptionValue = EnvConverter.ToInt32(txtOptionValue.Text);
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSave_Click(object sender, EventArgs e) {
        //QuestionOptionEntity Result = GetQuestionOptionUI();
        //int Succeed = m_QuestionOption.SaveQuestionOption(Result);
        //if (Succeed > 0) ShowMessage("数据保存成功!");
        //if (Succeed < 0) ShowMessage("数据保存失败!");
        //DataBind();
        //SetUIState("Default");
    }

    protected void btnNew_Click(object sender, EventArgs e) {
        ClearQuestionOptionUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDelete_Click(object sender, EventArgs e) {
        //int Succeed = m_QuestionOption.DeleteQuestionOption(GetQuestionOptionUI());
        //if (Succeed > 0) ShowMessage("数据删除成功!");
        //if (Succeed < 0) ShowMessage("数据删除失败!");
        //DataBind();
        //SetUIState("Default");
    }
    protected void btnEdit_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancel_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            //Literal lblQID = (Literal)e.Item.FindControl("lblQID");
            //QID = lblQID.Text;
            //Literal lblSN = (Literal)e.Item.FindControl("lblSN");
            //SN = lblSN.Text;
            //EnterpriseID = lblEnterpriseID.Text;
            SetQuestionOptionUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}
