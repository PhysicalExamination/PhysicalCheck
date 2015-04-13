using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Examination_unitcheckreport :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            InitData();
        }

    }

    private void InitData()
    {

        DataTable dt = new Maticsoft.BLL.BaseInfo.BaseInfo().GetList_physicaldepartment("DeptID<>1").Tables[0];

        drpItems.Items.Clear();

        drpItems.DataTextField = "DeptName";
        drpItems.DataValueField = "DeptID";

        drpItems.DataSource = dt;
        drpItems.DataBind();

    }

}