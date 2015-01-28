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
    //private ChargeBusiness m_Charge;
    private string RegisterNo
    {
        get
        {
            if (ViewState["RegisterNo"] == null) return Request.QueryString["id"].ToString();
            return (string)ViewState["RegisterNo"];
        }
        set
        {
            ViewState["RegisterNo"] = value;
        }
    }


    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (!IsPostBack)
        {
            DataBind();

            ClientIntial();
           
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
        //using (ChargeBusiness Charge = new ChargeBusiness())
        //{
        //    int RecordCount = 0;
        //    ChargeRepeater.DataSource = Charge.GetCharges(Pager.CurrentPageIndex, Pager.PageSize, "", out RecordCount);
        //    Pager.RecordCount = RecordCount;
        //}
        Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

        string sql = "";

        sql += string.Format(" RegisterNo='{0}'", RegisterNo);

      
        rptMain.DataSource = bll.GetList_GroupResult(sql);
        
        base.DataBind();
    }
    /// <summary>
    /// 设置界面控件显示状态
    /// </summary>
    /// <param name="Enabled"></param>
    private void SetUIStatus(bool Enabled)
    {
        ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
        foreach (Control ctrl in Controls)
        {
            if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
        }
    }
    /// <summary>
    

    #endregion

    #region 私有成员

    private void ClientIntial()
    {

        SetRegsitrationUI();

    }

 
        /// <summary>
    /// 填充界面
    /// </summary>
    private void SetRegsitrationUI() {

        RegistrationViewEntity Result = m_Registration.GetRegistration(RegisterNo);
        if (Result == null) return;
       // PersonID = Result.PersonID.Value;
        hDeptID.Value = Result.DeptID.Value+"";
        hPackageID.Value = Result.PackageID + "";
        txtRegisterNo.Text = Result.RegisterNo;
        txtPackageName.Text = Result.PackageName;
        txtRegisterDate.Text = EnvShowFormater.GetShortDate(Result.RegisterDate);
        txtCheckDate.Text = EnvShowFormater.GetShortDate(Result.CheckDate);
        txtDeptName.Text = Result.DeptName;
        txtName.Text = Result.Name;
        drpSex.SelectedValue = Result.Sex;
        txtIDNumber.Text = Result.IDNumber;
        txtBirthday.Text = EnvShowFormater.GetShortDate(Result.Birthday);
        txtAge.Text = EnvShowFormater.GetNumberString(Result.Age);
        drpMarriage.SelectedValue = Result.Marriage;
        txtJob.Text = Result.Job;
        drpEducation.SelectedValue = Result.Education;
        txtNation.Text = Result.Nation;
        txtLinkTel.Text = Result.LinkTel;
        txtAddress.Text = Result.Address;
        txtMobile.Text = Result.Mobile;
        txtEMail.Text = Result.EMail;
    }


    #endregion

    #region 事件

   
   
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }


    protected void rptMain_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        //判断里层repeater处于外层repeater的哪个位置（ AlternatingItemTemplate，FooterTemplate，

        //HeaderTemplate，，ItemTemplate，SeparatorTemplate）
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rep = e.Item.FindControl("rptSub") as Repeater;//找到里层的repeater对象
            DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
            string DeptID = Convert.ToString(rowv["DeptID"]); //获取填充子类的id 

            string GroupID = Convert.ToString(rowv["GroupID"]); //获取填充子类的id 

            Maticsoft.BLL.Search.Search bll = new Maticsoft.BLL.Search.Search();

            string sql = "";

            sql += string.Format(" RegisterNo='{0}' And DeptID='{1}' And GroupID='{2}'  ", RegisterNo, DeptID,GroupID);

            rep.DataSource = bll.GetList_itemresult(sql);
            rep.DataBind();

        }
    }




    #endregion
}