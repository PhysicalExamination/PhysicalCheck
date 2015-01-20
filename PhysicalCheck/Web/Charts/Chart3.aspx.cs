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
/// 当年不同工种从业人员饼图分析
/// </summary>
public partial class Charts_Chart3 : BasePage {
    //private readonly String[] Trades ={"餐饮服务","厨师","集体食堂","食品加工","食品销售","非食品销售",
    //"客房服务","浴池、游泳馆","美容、美发","水质","卫生用品","收银","其他"};

    private Maticsoft.BLL.chart.chart bll = new Maticsoft.BLL.chart.chart();
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            ClientInitial();
            DataBind();
        }
    }

    private void ClientInitial() {



        drpYears.Items.Clear();

        for (int i = 0; i < 10; i++)
        {
            drpYears.Items.Add(new ListItem(Convert.ToString(DateTime.Now.Year - i) + "年", (DateTime.Now.Year - i).ToString()));
        }

    }

    public override void DataBind()
    {
        Title m_Title = Chart1.Titles[0];
        m_Title.Font = new Font("宋体", 12f);
        m_Title.Font = new Font("宋体", 12f, System.Drawing.FontStyle.Bold);
        m_Title.Text = drpYears.Text + "从业人员体检人数分布情况";
        
        ChartArea chartaera = Chart1.ChartAreas["ChartArea1"];
        chartaera.AxisX.LabelStyle.Font = new Font("宋体", 9.75f);
        chartaera.AxisY.LabelStyle.Font = new Font("宋体", 9.75f);
        Random rand = new Random();
        Series Series = Chart1.Series[0];
        //Series.Label = "#PERCENT{P2}";
        //Series.ToolTip = "#PERCENT{P2}";

        Series["PieLabelStyle"] = "Outside";
        DataTable checkitem = new Maticsoft.BLL.BaseInfo.BaseInfo().GetList_CommonCode(" Category=3").Tables[0];

        string sql = "";

        sql = string.Format(" LEFT(RegisterNo,4)='{0}' ", drpYears.SelectedValue);
        DataTable dt = bll.GetList_TradePercent(sql).Tables[0];

        object sumObject = dt.Compute("sum(pointValue)", "TRUE");

        int count = 0;
        if (sumObject is DBNull)
        { }
        else
            count = Convert.ToInt32(sumObject);

        decimal bl = 0;
        
        for (int i = 0; i < checkitem.Rows.Count; i++)
        {
            DataRow[] rows2 = dt.Select("tradecode='" + checkitem.Rows[i]["code"] + "'");
            if (rows2.Length > 0)
                bl = Convert.ToDecimal(rows2[0]["pointValue"].ToString()) / count;
            Series.Points.AddXY( checkitem.Rows[i]["Name"].ToString(), bl);
           
        }

    }


    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }
}