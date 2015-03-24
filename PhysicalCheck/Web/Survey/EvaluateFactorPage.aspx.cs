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
public partial class Survey_EvaluateFactorPage : BasePage {

    #region 私有成员

    private EvaluateFactorBusiness m_EvaluateFactor;

    #endregion

    #region 属性

    private int EID {
        get {
            if (ViewState["EID"] == null) return int.MinValue;
            return (int)ViewState["EID"];
        }
        set {
            ViewState["EID"] = value;
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
        m_EvaluateFactor = new EvaluateFactorBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_EvaluateFactor.Dispose();
        m_EvaluateFactor = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        FactorRepeater.DataSource = m_EvaluateFactor.GetEvaluateFactors(Pager.CurrentPageIndex,
            Pager.PageSize, out RecordCount);
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
    private void ClearEvaluateFactorUI() {
        EID = int.MinValue;
        txtFactorName.Text = "";
        txtFactorRate.Text = "";
        txtCriticalValue.Text = "";
        txtMedicine.Text = "";
        txtSuggestion.Text = "";       
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetEvaluateFactorUI() {
        EvaluateFactorEntity Result = m_EvaluateFactor.GetEvaluateFactor(EID);
        if (Result == null) return;       
        txtFactorName.Text = Result.FactorName;
        txtFactorRate.Text = EnvShowFormater.GetNumberString(Result.FactorRate);
        txtCriticalValue.Text = Result.CriticalValue + "";
        txtMedicine.Text = Result.Medicine;
        txtSuggestion.Text = Result.Suggestion;
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private EvaluateFactorEntity GetEvaluateFactorUI() {
        EvaluateFactorEntity Result = new EvaluateFactorEntity();
        Result.EID = EID;
        Result.FactorName = txtFactorName.Text;
        Result.FactorRate = EnvConverter.ToDouble(txtFactorRate.Text).Value ;
        Result.CriticalValue = EnvConverter.ToInt32(txtCriticalValue.Text).Value ;
        Result.Medicine = txtMedicine.Text;
        Result.Suggestion = txtSuggestion.Text;
        return Result;
    }



    #endregion

    #region 事件

    protected void btnSaveEvaluateFactor_Click(object sender, EventArgs e) {
        EvaluateFactorEntity Result = GetEvaluateFactorUI();
        try {
            m_EvaluateFactor.SaveEvaluateFactor(Result);
            EID = Result.EID;
            ShowMessage("数据保存成功!");
        }
        catch {
            ShowMessage("数据保存失败!");
        }     
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewEvaluateFactor_Click(object sender, EventArgs e) {
        ClearEvaluateFactorUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteEvaluateFactor_Click(object sender, EventArgs e) {
        try {
            m_EvaluateFactor.DeleteEvaluateFactor(GetEvaluateFactorUI());
            ShowMessage("数据删除成功!");
        }
        catch {
            ShowMessage("数据删除失败!");
        }      
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditEvaluateFactor_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelEvaluateFactor_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {
            EID = Convert.ToInt32(e.CommandArgument);          
            SetEvaluateFactorUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    #endregion
}
