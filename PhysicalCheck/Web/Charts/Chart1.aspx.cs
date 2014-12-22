using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

/// <summary>
/// 体检人数同比分析
/// </summary>
public partial class Charts_Chart1 :BasePage {
    protected override void OnLoad(EventArgs e) {
        if (!IsPostBack) {
            base.OnLoad(e);
            DataBind();
        }
    }

    public override void DataBind() {
        base.DataBind();
        ClientInitial();
    }

    private void ClientInitial() {
        Title m_Title = Chart1.Titles[0];
        m_Title.Font = new Font("宋体", 12f);
        m_Title.Font = new Font("宋体", 12f, System.Drawing.FontStyle.Bold);
        m_Title.Text = "体检人数同比分析";
        ChartArea chartaera = Chart1.ChartAreas["OutputChartArea"];
        chartaera.AxisX.LabelStyle.Font = new Font("宋体", 9.75f);
        chartaera.AxisY.LabelStyle.Font = new Font("宋体", 9.75f);
        Series Series1 = Chart1.Series[0];
        Series Series2 = Chart1.Series[1];
        Series1.Points.Clear();
        Series2.Points.Clear();
        DateTime startDateTime = new DateTime(2013,1,1), endDateTime = new DateTime(2013,12,31);
        DateTime DateTime = new DateTime(2013,1,1);        
        Random rand = new Random();
        double pointValue;
        while (DateTime <= endDateTime) {
            pointValue = rand.NextDouble()*1000;
            Series1.Points.AddXY(DateTime, pointValue);
            pointValue = rand.NextDouble() * 1000;
            Series2.Points.AddXY(DateTime, pointValue);
            DateTime = DateTime.AddMonths(1);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }
}

