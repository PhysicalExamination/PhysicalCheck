using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Data;
/// <summary>
/// 检查项目数量分布
/// </summary>
public partial class Charts_Chart5 : BasePage {

    private Maticsoft.BLL.chart.chart bll = new Maticsoft.BLL.chart.chart();

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            InitData();
            DataBind();
        }
    }

    private void InitData()
    {
        DataTable dt = bll.GetList_checkeditem("").Tables[0];

        drpItems.Items.Clear();

        drpItems.DataTextField = "ItemName";
        drpItems.DataValueField = "ItemID";

        drpItems.DataSource = dt;
        drpItems.DataBind();
                    
    }


    public override void DataBind() {
        Title m_Title = Chart1.Titles[0];
        m_Title.Font = new Font("宋体", 12f);
        m_Title.Font = new Font("宋体", 12f, System.Drawing.FontStyle.Bold);
        m_Title.Text = String.Format("历年{0}体检人数分布情况", drpItems.SelectedItem.Text);
        ChartArea chartaera = Chart1.ChartAreas["ChartArea1"];
        chartaera.AxisX.LabelStyle.Font = new Font("宋体", 9.75f);
        chartaera.AxisY.LabelStyle.Font = new Font("宋体", 9.75f);
        Series S1 = Chart1.Series[0];     
        string sql = "";
        sql = string.Format(" itemID='{0}' ",drpItems.SelectedValue);

        DataTable dt = bll.GetList_checkeditemNumber(sql).Tables[0];

        
    
        int pointValue;
        for (int year = DateTime.Now.Year - 8; year <= DateTime.Now.Year; year++)
        {
            

            DataRow[] rows2 = dt.Select("nian='" +year.ToString() + "'");
            if (rows2.Length > 0)
                pointValue = Convert.ToInt32(rows2[0]["pointValue"].ToString());
            else
                pointValue = 0;

            S1.Points.AddXY(new DateTime(year, 1, 1), pointValue);
        }


    }
    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

}