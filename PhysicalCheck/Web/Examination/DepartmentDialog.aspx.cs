using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;

public partial class Examination_DepartmentDialog : BasePage {  

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();          
        }
    }


    /// <summary>
    /// 数据绑定
    /// </summary>
    public override void DataBind() {
        using (PhysicalDepartmentBusiness Business = new PhysicalDepartmentBusiness()) {
            int RecordCount = 0;
            String DeptName = txtSearch.Text.Trim();
            DepartmentRepeater.DataSource = Business.GetPhysicalDepartments(Pager.CurrentPageIndex,
                Pager.PageSize, DeptName, out RecordCount);
            Pager.RecordCount = RecordCount;
        }
        base.DataBind();
    }

    #endregion

    #region 事件
    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    #endregion
}