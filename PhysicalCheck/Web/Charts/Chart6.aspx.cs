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
/// 各检查项目人数百分比情况
/// </summary>
public partial class Charts_Chart6 : BasePage {

    private Maticsoft.BLL.chart.chart bll = new Maticsoft.BLL.chart.chart();

    //private readonly String[] CheckItems = { "放射检查","精神系统检查","内科检查","外科检查","问卷调查","五官检查"};
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            InitData();
            DataBind();
        }
    }

    private void InitData()
    {
        drpYears.Items.Clear();

        for (int i = 0; i < 10; i++)
        {
            drpYears.Items.Add(new ListItem(Convert.ToString(DateTime.Now.Year - i) + "年", (DateTime.Now.Year - i).ToString()));
        }

    }

    public override void DataBind() {
        Title m_Title = Chart1.Titles[0];
        m_Title.Font = new Font("宋体", 12f);
        m_Title.Font = new Font("宋体", 12f, System.Drawing.FontStyle.Bold);
        m_Title.Text = drpYears.Text + "按科室体检人数分布情况";
        ChartArea chartaera = Chart1.ChartAreas["ChartArea1"];
        chartaera.AxisX.LabelStyle.Font = new Font("宋体", 9.75f);
        chartaera.AxisY.LabelStyle.Font = new Font("宋体", 9.75f);
        Random rand = new Random();
        Series Series = Chart1.Series[0];
        //Series.Label = "#PERCENT{P2}";
        Series.ToolTip = "#PERCENT{P2}";


        DataTable checkitem = new Maticsoft.BLL.BaseInfo.BaseInfo().GetList_department("").Tables[0];

        string sql = "";
        sql = string.Format(" LEFT(RegisterNo,4)='{0}' ", drpYears.SelectedValue);
        DataTable dt = bll.GetList_itemDepartmentNumberPercent(sql).Tables[0];

        object sumObject = dt.Compute("sum(pointValue)", "TRUE");

        int count =0;
        if (sumObject is DBNull)
        { }
        else
            count = Convert.ToInt32(sumObject);

        decimal bl = 0;
        for (int i=0; i < checkitem.Rows.Count; i++)
        {
            DataRow[] rows2 = dt.Select("DeptID='" + checkitem.Rows[i]["DeptID"] + "'");
            if (rows2.Length > 0)
                bl = Convert.ToDecimal(rows2[0]["pointValue"].ToString())/count ;
            Series.Points.AddXY(checkitem.Rows[i]["DeptName"].ToString(), bl);
           
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }
}