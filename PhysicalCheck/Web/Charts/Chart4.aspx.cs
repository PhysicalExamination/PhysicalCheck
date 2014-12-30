using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common.FormatProvider;
using Maticsoft.BLL;
public partial class Charts_PhysicalDepartmentCharge : BasePage
{

    protected string checknum_sum;
    protected string ActualCharge_sum;
    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack)
        {

            DataBind();
        }
        base.OnLoad(e);
    }
    protected void Pager_PageChanged(object source, EventArgs e)
    {
        DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }
    /// <summary>
    /// 缴费信息数据绑定
    /// </summary>
    public override void DataBind()
    {
        Maticsoft.BLL.chart.chart bll = new Maticsoft.BLL.chart.chart();


        // string sqlw = string.Format(" RegisterDate>'{0}' And RegisterDate<'{1}' And IsCheckOver='1'");
        string sqlw = " 1=1 ";

        if (txtStartDate.Text != "")
            sqlw += string.Format(" And  PaymentDate>'{0}' ", Convert.ToDateTime(txtStartDate.Text));

        if (txtEndDate.Text != "")
            sqlw += string.Format("  And PaymentDate<'{0}' ", Convert.ToDateTime(txtEndDate.Text));

        DataSet ds = bll.GetListByPage_DepartmentCharge(sqlw, "",(Pager.CurrentPageIndex-1)*Pager.PageSize,(Pager.CurrentPageIndex)*Pager.PageSize );

        Pager.RecordCount = bll.GetRecordCount_DepartmentCharge(sqlw);

        ReportRepeater.DataSource = ds.Tables[0];

        DataSet dssum = bll.GetSum_DepartmentCharge(sqlw);

        lblchecknum.Text = dssum.Tables[0].Rows[0][0].ToString();
        lblActualCharge.Text = dssum.Tables[0].Rows[0][1].ToString();

        base.DataBind();
    }
   
}