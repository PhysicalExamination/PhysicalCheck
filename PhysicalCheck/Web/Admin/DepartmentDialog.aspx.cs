using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Admin;

public partial class Admin_DepartmentDialog : BasePage {

    private readonly String[] Categorys = { "检验科室", "检查科室", "功能科室" };

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();
        }
    }

    public override void DataBind() {
        using (DepartmentBusiness Department = new DepartmentBusiness()) {
            int RecordCount = 0;
            DepartmentRepeater.DataSource = Department.GetDepartments(Pager.CurrentPageIndex, 
                Pager.PageSize, out RecordCount);
            Pager.RecordCount = RecordCount;
            base.DataBind();
        }       
    }
    

    #endregion

    #region 受保护方法

    protected String GetDeptCategory(Object Category) {
        int index = Convert.ToInt32(Category);
        if ((index >= 0) && (index <= 2)) return Categorys[index];
        return "";
    }
    #endregion    

    #region 事件

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    #endregion
}