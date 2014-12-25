using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.FormatProvider;
using DataEntity.Examination;
using BusinessLogic.Examination;
using BusinessLogic.SysConfig;
using System.Data;
public partial class Examination_customerArchive : BasePage
{
    #region 私有成员

    private RegistrationBusiness m_Registration;

    #endregion

    #region 属性

   
    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            DataBind();
          
        }
    }

    protected override void OnInit(EventArgs e)
    {
        m_Registration = new RegistrationBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e)
    {
        m_Registration.Dispose();
        m_Registration = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind()
    {
        Maticsoft.BLL.messages.messagesSend bll = new Maticsoft.BLL.messages.messagesSend();

        string sqlw = " 1=1 ";

        if (txtDeptName.Text != "")
            sqlw += string.Format("  And DeptName like '%{0}%' ", Convert.ToDateTime(txtDeptName.Text));

        if (txtIdNumber.Text != "")
            sqlw += string.Format("  And DeptName like '{0}%' ", Convert.ToDateTime(txtIdNumber.Text));

        if (txtStartDate.Text != "")
            sqlw += string.Format(" And  RegisterDate>'{0}' ", Convert.ToDateTime(txtStartDate.Text));

        if (txtEndDate.Text != "")
            sqlw += string.Format("  And RegisterDate<'{0}' ", Convert.ToDateTime(txtEndDate.Text));

     

        DataSet ds = bll.GetListByPage_Registration(sqlw, "", Pager.CurrentPageIndex, Pager.PageSize);

        Pager.RecordCount = bll.GetRecordCount_Registration(sqlw);
        ReportRepeater.DataSource = ds.Tables[0];

        base.DataBind();
    }
    
    #endregion

    #region 私有成员

   


    #endregion

    #region 事件


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }
    protected void Pager_PageChanged(object source, EventArgs e)
    {
        DataBind();
    }

    #endregion
}