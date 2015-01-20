using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Messages_Messages :BasePage
{
    private Maticsoft.BLL.messages.messages bll = new Maticsoft.BLL.messages.messages();

   

    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack)
        {

            txtdates.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            txtDateE.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            DataBind();
        }
        base.OnLoad(e);
    }


    public override void DataBind()
    {

        string sqlWhere = " 1=1 ";
        //string searchText = ttbSearchMessage.Text.Trim();
        if (!String.IsNullOrEmpty(txtdates.Text))
        {

            sqlWhere +=string.Format( " And sendTime>'{0}'  ",Convert.ToDateTime( txtdates.Text));
        }
        if (!String.IsNullOrEmpty(txtDateE.Text))
        {
            sqlWhere += string.Format(" And sendTime<'{0}'  ", Convert.ToDateTime(txtDateE.Text).AddDays(1));
        }
        if (drptype.SelectedValue != "0")
        {
            sqlWhere += string.Format(" And type='{0}'", drptype.SelectedValue);
        }

        int s = Pager.PageSize * (Pager.CurrentPageIndex-1);
        int e = Pager.PageSize * Pager.CurrentPageIndex;

        DataTable dt = bll.GetListByPage(sqlWhere, " id ", s, e).Tables[0];
        Pager.RecordCount = bll.GetRecordCount(sqlWhere);      
        CompanyRepeater.DataSource = dt;
        CompanyRepeater.DataBind();

        base.DataBind();

    }

    protected void Pager_PageChanged(object source, EventArgs e)
    {
        DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }
}