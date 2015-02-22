using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using Common.FormatProvider;

public partial class Examination_FormalCheckPage : BasePage {

    #region 私有成员

    private RegistrationBusiness m_Registration;

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
        DateTime? CheckDate = EnvConverter.ToDateTime(txtCheckDate.Text);
        String DeptName = txtsDeptName.Text.Trim();
        RegistrationRepeater.DataSource = m_Registration.GetFormalRegistrations(Pager.CurrentPageIndex, Pager.PageSize,
            CheckDate, DeptName, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }

    #endregion

    #region 私有成员

    private void ClientInitial() {
        txtCheckDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
    }

    #endregion

    #region 事件

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }


    protected void Pager_PageChanged(object sender, EventArgs e) {
        DataBind();
    }


    protected void btnBatchPrint_Click(object sender, EventArgs e) {
        int RecordCount = 0;
        DateTime? CheckDate = EnvConverter.ToDateTime(txtCheckDate.Text);
        String DeptName = txtsDeptName.Text.Trim();
        var DataSource = m_Registration.GetFormalRegistrations(1, int.MaxValue, CheckDate, DeptName, out RecordCount);
        List<String> Registrations = DataSource.Select(p => p.RegisterNo).ToList();      
        Session["Registrations"] = Registrations;
        String js = "window.open('" + ApplicationPath + "/Reports/Default.aspx?ReportKind=6','_blank')";
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "PrintReport", js, true);       
    }

    #endregion
}