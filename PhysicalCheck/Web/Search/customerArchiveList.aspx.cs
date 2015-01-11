using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.FormatProvider;
using DataEntity.Examination;
using BusinessLogic.Examination;
using BusinessLogic.SysConfig;
using System.Data;
public partial class Examination_customerArchive : BasePage
{
    #region 私有成员

    private RegistrationBusiness m_Registration;

    #endregion

    #region 属性

   
    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            txtStartDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            txtEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            DataBind();
          
        }
    }

    protected override void OnInit(EventArgs e)
    {
        m_Registration = new RegistrationBusiness();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e)
    {
        m_Registration.Dispose();
        m_Registration = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind()
    {
        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        string sqlw = " 1=1 ";

        if (txtRegisterNo.Text != "")
            sqlw += string.Format("  And RegisterNo like '%{0}%' ", txtRegisterNo.Text);

        if (txtDeptName.Text != "")
            sqlw += string.Format("  And DeptName like '%{0}%' ", txtDeptName.Text);

        if (txtName.Text != "")
            sqlw += string.Format("  And Name like '%{0}%' ", txtName.Text);


        if (txtIdNumber.Text != "")
            sqlw += string.Format("  And IdNumber like '{0}%' ", txtIdNumber.Text);

        if (txtOverallDoctor.Text != "")
            sqlw += string.Format("  And OverallDoctor like '{0}%' ", txtOverallDoctor.Text);


        if (txtStartDate.Text != "")
            sqlw += string.Format(" And  RegisterDate>='{0}' ", Convert.ToDateTime(txtStartDate.Text));

        if (txtEndDate.Text != "")
            sqlw += string.Format("  And RegisterDate<'{0}' ", Convert.ToDateTime(txtEndDate.Text).AddDays(1));


        DataSet ds = bll.GetListByPage_Composed(sqlw, "", (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex) * Pager.PageSize);

        Pager.RecordCount = bll.GetRecordCount_Composed(sqlw);
        ReportRepeater.DataSource = ds.Tables[0];

        base.DataBind();
    }
    
    #endregion

    #region 私有成员

   


    #endregion

    #region 事件


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }
    protected void Pager_PageChanged(object source, EventArgs e)
    {
        DataBind();
    }

    protected void rptMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        //判断里层repeater处于外层repeater的哪个位置（ AlternatingItemTemplate，FooterTemplate，

        //HeaderTemplate，，ItemTemplate，SeparatorTemplate）
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //Repeater rep = e.Item.FindControl("rptSub") as Repeater;//找到里层的repeater对象
            DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
            string RegisterNo = Convert.ToString(rowv["RegisterNo"]); //获取填充子类的id 

            //string GroupID = Convert.ToString(rowv["GroupID"]); //获取填充子类的id 

            Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

            string sql = "";

            sql += string.Format(" RegisterNo='{0}' ", RegisterNo);

            DataTable dt = bll.GetList_GroupResult(sql).Tables[0];

            Literal ltDo = e.Item.FindControl("ltDo") as Literal;//找到里层的repeater对象
            Literal ltNoDo = e.Item.FindControl("ltNoDo") as Literal;//找到里层的repeater对象

            if (dt!=null)
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["IsOver"].ToString() == "0")
                        ltNoDo.Text += dt.Rows[i]["GroupName"].ToString()+"-";
                    else
                        ltDo.Text += dt.Rows[i]["GroupName"].ToString() + "-";
                }

        }
    }

    #endregion
}