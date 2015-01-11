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
            txtStartDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            txtEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            InitData();
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
        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        string sqlw = " 1=1 ";

        
        if (drpdepartment.Text != "")
            sqlw += string.Format("  And A.DeptID = '{0}' ", drpdepartment.SelectedValue);

        if (txtStartDate.Text != "")
            sqlw += string.Format(" And  A.CheckDate>='{0}' ", Convert.ToDateTime(txtStartDate.Text));

        if (txtEndDate.Text != "")
            sqlw += string.Format("  And A.CheckDate<'{0}' ", Convert.ToDateTime(txtEndDate.Text).AddDays(1));

        ReportRepeater.DataSource =bll.GetList_workload_package(sqlw).Tables[0];

        base.DataBind();
    }
    
    #endregion

    #region 私有成员


    private void InitData()
    {
        Maticsoft.BLL.BaseInfo.BaseInfo bll = new  Maticsoft.BLL.BaseInfo.BaseInfo();

        DataTable dt =  bll.GetList_department("").Tables[0];

        drpdepartment.Items.Clear();

        drpdepartment.DataTextField = "DeptName";
        drpdepartment.DataValueField = "DeptID";

        drpdepartment.DataSource = dt;
        drpdepartment.DataBind();

    
    }


    #endregion

    #region 事件


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }
  
    #endregion
}