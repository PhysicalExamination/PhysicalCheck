using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.FormatProvider;
using BusinessLogic.Examination;
using FastReport;
using FastReport.Web;
using DataEntity.Examination;
using System.IO;
using System.Drawing.Printing;

//体检指引单
public partial class Examination_IntroductionPage : BasePage {

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
        DateTime? RegisterDate = EnvConverter.ToDateTime(txtSRegisterDate.Text);
        String DeptName = txtsDeptName.Text.Trim();
        String RegisterNo = txtsRegisterNo.Text.Trim();
        RegistrationRepeater.DataSource = m_Registration.GetRegistrations(Pager.CurrentPageIndex, Pager.PageSize,
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


    protected void Pager_PageChanged(object sender, EventArgs e) {
        DataBind();
    }


    protected void btnBatchPrint_Click(object sender, EventArgs e) {
        //ReportUtility ReportUtil = new ReportUtility();
        //List<RegistrationViewEntity> Registrations = new List<RegistrationViewEntity>();
        List<String> Registrations = new List<string>();
        CheckBox chkSelected;
        RepeaterItemCollection Items = RegistrationRepeater.Items;
        foreach (RepeaterItem Item in Items) {
            chkSelected = (CheckBox)Item.FindControl("chkSelected");
            if (chkSelected.Checked) Registrations.Add(chkSelected.ToolTip);
        }
        if (Registrations.Count <= 0) return;
        Session["Registrations"] =  Registrations;
        String js = "window.open('" + ApplicationPath + "/Reports/Default.aspx?ReportKind=6','_blank')";
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "PrintReport", js, true);
        //if (Registrations.Count <= 0) return;
        //List<Package> Packages = new List<Package>();
        //List<GroupItem> GroupItems = new List<GroupItem>();
        //foreach (RegistrationViewEntity Registration in Registrations) {
        //    Packages.AddRange(ReportUtil.GetPackageItems(Registration.RegisterNo, Registration.PackageID.Value));
        //    GroupItems.AddRange(ReportUtil.GetGroupItems(Registration.RegisterNo, Registration.PackageID.Value));
        //}
       
        //using (WebReport Report = new WebReport()) {
        //    Report.ReportFile = Server.MapPath(ApplicationPath + "/Reports/IntroductionListReport.frx");
        //    Report.Report.RegisterData(Registrations, "Registration");
        //    Report.Report.RegisterData(Packages, "Packages");
        //    Report.Report.RegisterData(GroupItems, "ItemGroups");
        //    Report.Report.Prepare(true);   
        //    Report.Report.PrintSettings.ShowDialog = false;
        //    Report.Report.Print();
        //}
        //Report.PrintInPdf = true;
        //Report.Report.Print();
    }

    #endregion

}