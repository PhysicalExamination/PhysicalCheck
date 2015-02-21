using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using Common.FormatProvider;

/// <summary>
/// 体检报告
/// </summary>
public partial class Examination_ExaminationReportPage :BasePage {

    #region 私有成员

    private RegistrationBusiness m_Registration;

    #endregion

    #region 属性

    private string RegisterNo {
        get {
            if (ViewState["RegisterNo"] == null) return string.Empty;
            return (string)ViewState["RegisterNo"];
        }
        set {
            ViewState["RegisterNo"] = value;
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
        m_Registration = new RegistrationBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e) {
        m_Registration.Dispose();
        m_Registration = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定体检登记
    /// </summary>
    public override void DataBind() {
        int RecordCount = 0;
        DateTime? RegisterDate = EnvConverter.ToDateTime(txtSRegisterDate.Text);
        String DeptName = txtsDeptName.Text.Trim();
        String RegisterNo = txtsRegisterNo.Text.Trim();
        RegistrationRepeater.DataSource = m_Registration.GetCheckReports(Pager.CurrentPageIndex, Pager.PageSize,
            RegisterDate, DeptName, RegisterNo, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }

    #endregion

    #region 私有成员

    private void ClientInitial() {
        txtSRegisterDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
    }

    #endregion

    #region 事件

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void ItemCommand(object source,RepeaterCommandEventArgs e) {
        if (e.CommandName.ToLower() == "cancel") {
            RegisterNo = (String)e.CommandArgument;            
            int Succeed = m_Registration.CancelOverallCheck(RegisterNo, UserName);
            String msg = String.Format("登记号：{0}总检撤销成功！", RegisterNo);
            if (Succeed < 1)
                msg = "撤销总检的用户必须是给出总检的人。";
            ShowMessage(msg);
            DataBind();
        }
    }
    #endregion
}