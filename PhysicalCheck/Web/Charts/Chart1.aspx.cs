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
/// 体检人数同比分析
/// </summary>
public partial class Charts_Chart1 :BasePage {
    protected override void OnLoad(EventArgs e) {
        if (!IsPostBack) {
            base.OnLoad(e);
           

            drpYears.Items.Clear();

            for (int i=0;i<10;i++)
            {
                drpYears.Items.Add(new ListItem( Convert.ToString( DateTime.Now.Year - i)+"年", (DateTime.Now.Year - i).ToString()));
            }

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

        Series1.IsValueShownAsLabel = true;
        Series2.IsValueShownAsLabel = true;
        Series1.LegendText = Convert.ToString( Convert.ToInt32(drpYears.SelectedValue) - 1);
        Series2.LegendText = drpYears.SelectedValue; 

        string strSql = "";

        strSql = string.Format("   LEFT(RegisterNo,4)>='{0}' And LEFT(RegisterNo,4)<='{1}' ", Convert.ToInt32(drpYears.SelectedValue)-1, drpYears.SelectedValue);
        DataTable dt = new Maticsoft.BLL.chart.chart().GetList_PersonNumber(strSql).Tables[0];

        DateTime startDateTime = new DateTime(Convert.ToInt32(drpYears.SelectedValue)-1, 1, 1), endDateTime = new DateTime(Convert.ToInt32(drpYears.SelectedValue)-1, 12, 31);
        DateTime DateTime = new DateTime(Convert.ToInt32(drpYears.SelectedValue)-1, 1, 1);  

        int pointValue;
        while (DateTime <= endDateTime) {

            DataRow[] rows1 = dt.Select("dateM='"+DateTime.ToString("yyyyMM")+"'");

            if (rows1.Length > 0)
                pointValue = Convert.ToInt32(rows1[0]["pointValue"].ToString());
            else
                pointValue = 0;
            Series1.Points.AddXY(DateTime, pointValue);


            DataRow[] rows2 = dt.Select("dateM='" + DateTime.AddYears(1).ToString("yyyyMM") + "'");

            if (rows2.Length > 0)
                pointValue = Convert.ToInt32(rows2[0]["pointValue"].ToString());
            else
                pointValue = 0;

            Series2.Points.AddXY(DateTime, pointValue);
            DateTime = DateTime.AddMonths(1);


        }
    }
    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }
}

