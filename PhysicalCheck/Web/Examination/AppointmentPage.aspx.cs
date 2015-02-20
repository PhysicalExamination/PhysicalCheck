using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using Common.FormatProvider;

/// <summary>
/// 体检预约
/// </summary>
public partial class Examination_AppointmentPage : BasePage, ICallbackEventHandler {

    #region 私有成员

    private RegistrationBusiness m_Registration;
    private String CallbackResult;
    protected String ClientCallback;

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
        //DateTime? RegisterDate = EnvConverter.ToDateTime(txtSRegisterDate.Text);
        String DeptName = txtsDeptName.Text.Trim();
        DateTime? RegisterDate = EnvConverter.ToDateTime(txtSRegisterDate.Text);
        RegistrationRepeater.DataSource = m_Registration.GetAppointments(Pager.CurrentPageIndex, Pager.PageSize,
            RegisterDate, DeptName, out RecordCount);
        Pager.RecordCount = RecordCount;
        base.DataBind();
    }

    #endregion

    #region 私有成员

    private void ClientInitial() {
        txtSRegisterDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        ClientCallback = ClientScript.GetCallbackEventReference(this, "argument", "processCallback", "null");
    }

    #endregion

    #region 事件

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnSave_Click(object source, EventArgs e) {

    }

    #endregion


    public string GetCallbackResult() {
        return CallbackResult;
    }

    public void RaiseCallbackEvent(string eventArgument) {
        CallbackResult = "体检预约保存成功！";
        try {
            String CheckDateArg = eventArgument.Split(';')[0].Split('=')[1];
            DateTime CheckDate = Convert.ToDateTime(CheckDateArg);
            String ValuesArg = eventArgument.Split(';')[1].Split('=')[1];
            String[] Items = ValuesArg.Split(',');
            foreach (String Item in Items) {
                if (!String.IsNullOrWhiteSpace(Item)) m_Registration.SaveCheckAppointment(Item, CheckDate);
            }
        }
        catch{
            CallbackResult = "体检预约数据保存失败！";
        }        
    }
}