using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

/// <summary>
/// 检查项目数量分布
/// </summary>
public partial class Charts_Chart5 : BasePage {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            DataBind();
        }
    }


    public override void DataBind() {
        Title m_Title = Chart1.Titles[0];
        m_Title.Font = new Font("宋体", 12f);
        m_Title.Font = new Font("宋体", 12f, System.Drawing.FontStyle.Bold);
        m_Title.Text = String.Format("历年{0}体检人数分布情况", drpItems.Text);
        ChartArea chartaera = Chart1.ChartAreas["ChartArea1"];
        chartaera.AxisX.LabelStyle.Font = new Font("宋体", 9.75f);
        chartaera.AxisY.LabelStyle.Font = new Font("宋体", 9.75f);
        Series S1 = Chart1.Series[0];       
        Random rand = new Random();
        for (int year = 2008; year < 2016;year++ ) {
            S1.Points.AddXY(new DateTime(year, 1, 1), rand.NextDouble() * 1000);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

}