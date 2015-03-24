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
/// 评估模型
/// </summary>
public partial class Survey_EvaluateModelPage : BasePage {

    #region 私有成员

    private EvaluateModelBusiness m_EvaluateModel;

    #endregion

    #region 属性

    private int ModelID {
        get {
            if (ViewState["ModelID"] == null) return int.MinValue;
            return (int)ViewState["ModelID"];
        }
        set {
            ViewState["ModelID"] = value;
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
        m_EvaluateModel = new EvaluateModelBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_EvaluateModel.Dispose();
        m_EvaluateModel = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        ModelRepeater.DataSource = m_EvaluateModel.GetEvaluateModels(Pager.CurrentPageIndex, 
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
    private void ClearEvaluateModelUI() {
        ModelID = int.MinValue;
        txtModelName.Text = "";
        txtDisease.Text = "";
        txtCriticalValue.Text = "";
    }
    /// <summary>
    /// 填充界面
    /// </summary>
    private void SetEvaluateModelUI() {
        EvaluateModelEntity Result = m_EvaluateModel.GetEvaluateModel(ModelID);
        if (Result == null) return;        
        txtModelName.Text = Result.ModelName;
        txtDisease.Text = Result.Disease;
        txtCriticalValue.Text = Result.CriticalValue + "";
    }

    /// <summary>
    /// 从界面获取对象
    /// </summary>
    /// <returns></returns>
    private EvaluateModelEntity GetEvaluateModelUI() {
        EvaluateModelEntity Result = new EvaluateModelEntity();
        Result.ModelID = ModelID;
        Result.ModelName = txtModelName.Text;
        Result.Disease = txtDisease.Text;
        Result.CriticalValue = EnvConverter.ToInt32(txtCriticalValue.Text).Value;
        return Result;
    }

    #endregion

    #region 事件

    protected void btnSaveEvaluateModel_Click(object sender, EventArgs e) {
        EvaluateModelEntity Result = GetEvaluateModelUI();
        try {
            m_EvaluateModel.SaveEvaluateModel(Result);
            ShowMessage("数据保存成功!");
            ModelID = Result.ModelID;
        }
        catch {
            ShowMessage("数据保存失败!");
        }       
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewEvaluateModel_Click(object sender, EventArgs e) {
        ClearEvaluateModelUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteEvaluateModel_Click(object sender, EventArgs e) {       
        try {
            m_EvaluateModel.DeleteEvaluateModel(GetEvaluateModelUI());
            ShowMessage("数据删除成功!");
        }
        catch {
            ShowMessage("数据删除失败!");
        }    
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditEvaluateModel_Click(object sender, EventArgs e) {
        SetUIState("Edit");
    }

    protected void btnCancelEvaluateModel_Click(object sender, EventArgs e) {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source, RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "select") {            
            ModelID = Convert.ToInt32(e.CommandArgument);           
            SetEvaluateModelUI();
            SetUIState("Default");
        }
    }


    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    #endregion
}
