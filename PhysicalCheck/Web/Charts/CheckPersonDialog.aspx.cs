using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Admin;
using System.Data;

public partial class Admin_DepartmentDialog : BasePage {

    //private readonly String[] Categorys = { "检验科室", "检查科室", "功能科室" };

    private Maticsoft.BLL.messages.checkperson bll = new Maticsoft.BLL.messages.checkperson();

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();
        }
    }

    public override void DataBind() {
        
        string sqlw = " 1=1 ";

        if (txtName.Text != "")
            sqlw += string.Format("  And Name like'%{0}%' ", txtName.Text);


        DataSet ds = bll.GetListByPage(sqlw, "", (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex) * Pager.PageSize);

        Pager.RecordCount = bll.GetRecordCount(sqlw);
        rptMain.DataSource = ds.Tables[0];

        rptMain.DataBind();
    }
    
    #endregion

   
    #region 事件

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }

    #endregion
}