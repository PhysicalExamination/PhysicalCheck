using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;


/// <summary>
/// 当年不同工种从业人员饼图分析
/// </summary>
public partial class Charts_Chart3 : BasePage {
    private readonly String[] Trades ={"餐饮服务","厨师","集体食堂","食品加工","食品销售","非食品销售",
    "客房服务","浴池、游泳馆","美容、美发","水质","卫生用品","收银","其他"};
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            ClientInitial();
        }
    }

    private void ClientInitial() {
        Title m_Title = Chart1.Titles[0];
        m_Title.Font = new Font("宋体", 12f);
        m_Title.Font = new Font("宋体", 12f, System.Drawing.FontStyle.Bold);
        m_Title.Text = drpYears.Text + "从业人员体检人数分布情况";
        ChartArea chartaera = Chart1.ChartAreas["ChartArea1"];
        chartaera.AxisX.LabelStyle.Font = new Font("宋体", 9.75f);
        chartaera.AxisY.LabelStyle.Font = new Font("宋体", 9.75f);
        Random rand = new Random();
        Series Series = Chart1.Series[0];
        Series.Label = "#PERCENT{P2}";
        foreach (String Trade in Trades) {
            Series.Points.AddXY(Trade, rand.NextDouble() * 1000);
            //Series.Points.AddXY(date, rand.NextDouble() * 1000);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e) {
        ClientInitial();
    }
}