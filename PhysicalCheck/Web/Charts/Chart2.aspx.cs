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
/// 从业工种分析
/// </summary>
public partial class Charts_Chart2 : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            ClientInitial();
            DataBind();
        }
    }

    private void ClientInitial() {
       

        //工种
        string strSql = "  Category=3 ";
        
        DataTable dt = new Maticsoft.BLL.BaseInfo.BaseInfo().GetList_CommonCode(strSql).Tables[0];

        drpTrades.Items.Clear();

        drpTrades.DataTextField = "Name";
        drpTrades.DataValueField = "Code";

        drpTrades.DataSource = dt;
        drpTrades.DataBind();
    }

    public override void DataBind()
    {
        base.DataBind();

        Title m_Title = Chart1.Titles[0];
        m_Title.Font = new Font("宋体", 12f);
        m_Title.Font = new Font("宋体", 12f, System.Drawing.FontStyle.Bold);
        m_Title.Text = "历年" + drpTrades.SelectedItem.Text + "从业人员体检人数分布";
        ChartArea chartaera = Chart1.ChartAreas["ChartArea1"];
        chartaera.AxisX.LabelStyle.Font = new Font("宋体", 9.75f);
        chartaera.AxisY.LabelStyle.Font = new Font("宋体", 9.75f);
        Series Series1 = Chart1.Series[0];
        Series1.Points.Clear();

        //DateTime startDateTime = new DateTime(Convert.ToInt32(drpYears.SelectedValue) - 1, 1, 1), endDateTime = new DateTime(Convert.ToInt32(drpYears.SelectedValue) - 1, 12, 31);
        //DateTime DateTime = new DateTime(Convert.ToInt32(drpYears.SelectedValue) - 1, 1, 1);


        int yearBegin=DateTime.Now.AddYears(-10).Year;
        int yearEnd = DateTime.Now.Year;

        int pointValue;

        string strSql = string.Format("   LEFT(RegisterNo,4)>='{0}' And LEFT(RegisterNo,4)<='{1}' And B.TradeCode='{2}' ", yearBegin, yearEnd,drpTrades.SelectedValue);
        DataTable dt = new Maticsoft.BLL.chart.chart().GetList_TradeYear(strSql).Tables[0];
        
        for (int i = yearBegin; i <= yearEnd; i++)
        {
            //
            //DateTime = DateTime.AddYears(1);

            DataRow[] rows2 = dt.Select("nian='" + i.ToString() + "'");
            if (rows2.Length > 0)
                pointValue = Convert.ToInt32(rows2[0]["pointValue"].ToString());
            else
                pointValue = 0;

            Series1.Points.AddXY(i.ToString(), pointValue);
        
        }

    }


    protected void btnSearch_Click(object sender, EventArgs e) {
       // ClientInitial();

        DataBind();
    }
}