using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// 复检通知
/// </summary>
public partial class Examination_ReviewPage : BasePage {

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {          
            DataBind();            
        }
    }   

    /// <summary>
    /// 数据绑定体检登记
    /// </summary>
    public override void DataBind() {
        //int RecordCount = 0;
        //DateTime? RegisterDate = EnvConverter.ToDateTime(txtSRegisterDate.Text);
        //String DeptName = txtsDeptName.Text.Trim();
        //String RegisterNo = txtsRegisterNo.Text.Trim();
        //RegistrationRepeater.DataSource = m_Registration.GetOveralls(Pager.CurrentPageIndex, Pager.PageSize,
        //    RegisterDate, DeptName, RegisterNo, out RecordCount);
        //Pager.RecordCount = RecordCount;
        ReviewRepeater.DataBind();
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSave_Click(object sender, EventArgs e) {

    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }


    #endregion
}