using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;


/// <summary>
/// 各检查项目人数百分比情况
/// </summary>
public partial class Charts_Chart6 : BasePage {
    private readonly String[] CheckItems = { "放射检查","精神系统检查","内科检查","外科检查","问卷调查","五官检查"};
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();
        }
    }
    public override void DataBind() {
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
        foreach (String Item in CheckItems) {
            Series.Points.AddXY(Item, rand.NextDouble() * 1000);
            //Series.Points.AddXY(date, rand.NextDouble() * 1000);
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }
}