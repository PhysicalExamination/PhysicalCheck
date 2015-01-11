using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

/// <summary>
/// 从业工种分析
/// </summary>
public partial class Charts_Chart7 : BasePage {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            ClientInitial();
        }
    }

    private void ClientInitial() {
        Title m_Title = Chart1.Titles[0];
        m_Title.Font = new Font("宋体", 12f);
        m_Title.Font = new Font("宋体", 12f, System.Drawing.FontStyle.Bold);
        m_Title.Text = "历年" + drpTrades.Text + "从业人员体检人数分布";
        ChartArea chartaera = Chart1.ChartAreas["ChartArea1"];
        chartaera.AxisX.LabelStyle.Font = new Font("宋体", 9.75f);
        chartaera.AxisY.LabelStyle.Font = new Font("宋体", 9.75f);
        Series Series1 = Chart1.Series[0];       
        Series1.Points.Clear();      
        DateTime  endDateTime = new DateTime(2015, 3, 31);
        DateTime DateTime = new DateTime(2008, 1, 1);
        Random rand = new Random();
        double pointValue;
        while (DateTime <= endDateTime) {
            pointValue = rand.NextDouble() * 1000;
            Series1.Points.AddXY(DateTime, pointValue);
            DateTime = DateTime.AddYears(1);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        ClientInitial();
    }
}