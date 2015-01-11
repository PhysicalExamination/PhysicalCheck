using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using DataEntity.Examination;
using Common.FormatProvider;

/// <summary>
/// 体检单位管理
/// </summary>
public partial class Examination_CompanyPage : BasePage
{

    #region 私有成员

    private Maticsoft.BLL.messages.messagesSend m_Company;

    #endregion

    #region 属性

    private int CompanyID
    {
        get
        {
            if (ViewState["CompanyID"] == null) return -1;
            return (int)ViewState["CompanyID"];
        }
        set
        {
            ViewState["CompanyID"] = value;
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
        }
    }

    protected override void OnInit(EventArgs e)
    {
        m_Company = new Maticsoft.BLL.messages.messagesSend();
        base.OnInit(e);
    }

    protected override void OnUnload(EventArgs e)
    {

        m_Company = null;
        base.OnUnload(e);
    }

    /// <summary>
    /// 体检单位管理数据绑定
    /// </summary>
    public override void DataBind()
    {
        string sql = "";

        if (drpisSend.SelectedValue != "0")
        {
            if (drpisSend.SelectedValue == "是")
                sql = " messagesid is not null  ";
            else
                sql = " messagesid is null  ";
        }

        //int s = Pager.PageSize * (Pager.CurrentPageIndex - 1);
        //int e = Pager.PageSize * Pager.CurrentPageIndex;

        //DataTable dt = bll.GetListByPage(sqlWhere, " id ", s, e).Tables[0];
        //Pager.RecordCount = bll.GetRecordCount(sqlWhere);
        //CompanyRepeater.DataSource = dt;
        //CompanyRepeater.DataBind();


        CompanyRepeater.DataSource = m_Company.GetList_PhysicalDepartment(sql).Tables[0];
        base.DataBind();
    }
    /// <summary>
    /// 设置体检单位管理界面控件显示状态
    /// </summary>
    /// <param name="Enabled"></param>
    private void SetUIStatus(bool Enabled)
    {

        foreach (Control ctrl in Controls)
        {
            if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
        }
    }

    #endregion

    #region 私有成员


    protected void Pager_PageChanged(object source, EventArgs e)
    {
        DataBind();
    }

    #endregion

    #region 事件


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void CompanyItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //if (e.CommandName.ToLower() == "select") {
        //    Literal lblCompanyID = (Literal)e.Item.FindControl("lblCompanyID");
        //    CompanyID = EnvConverter.ToInt32(lblCompanyID.Text).Value;
        //    SetCompanyUI();
        //    SetUIState("Default");
        //}
    }


    #endregion
    protected void btnMessages_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < this.CompanyRepeater.Items.Count; i++)
        {
            CheckBox cb = (CheckBox)CompanyRepeater.Items[i].FindControl("checkbox1");
            Literal ltid = (Literal)CompanyRepeater.Items[i].FindControl("lblCompanyID");
            if (cb.Checked)
            {
                //Maticsoft.Model.messages.messagesjoin  en = new  Maticsoft.Model.messages.messagesjoin();

                //en = m_Company.GetCompany(Convert.ToInt32(ltid.Text));

                PhysicalDepartmentEntity en = new PhysicalDepartmentEntity();

                en = new PhysicalDepartmentBusiness().GetPhysicalDepartment(Convert.ToInt32(ltid.Text));

                if (en != null)
                {

                    //string smsResult = SMS.Send("",en.telephone);

                    Maticsoft.BLL.messages.messages_type bllType = new Maticsoft.BLL.messages.messages_type();

                    Maticsoft.Model.messages.messages model = new Maticsoft.Model.messages.messages();

                    model.type = messagesType.单位体检通知.ToString();
                    model.rcvMan = en.Leader;
                    model.rcvTel = en.LinkTel;
                    model.unit = en.DeptName;
                    model.sendTime = DateTime.Now;

                   // bllType.GetModel(messagesType.单位体检通知.GetTypeCode());

                    model.content = string.Format("贵单位已经到了体检日期， 欢迎您来[YYMC]医院进行体检。");

                    model.status = "成功";

                    Maticsoft.BLL.messages.messages bll = new Maticsoft.BLL.messages.messages();
                    if (bll.Add(model))
                    {

                        Maticsoft.Model.messages.messagesjoin modeljoin = new Maticsoft.Model.messages.messagesjoin();

                        Maticsoft.BLL.messages.messagesjoin blljoin = new Maticsoft.BLL.messages.messagesjoin();

                        if (blljoin.Exists("PhysicalDepartment", en.DeptID.ToString()))
                        {
                            string sqlW = string.Format(" jointable='PhysicalDepartment' And tableCode='{0}'", en.DeptID.ToString());
                            modeljoin = blljoin.GetModelList(sqlW)[0];

                            modeljoin.messagesid = bll.GetMaxId() - 1;


                            blljoin.Update(modeljoin);
                        }
                        else
                        {
                            modeljoin.jointable = "PhysicalDepartment";
                            modeljoin.tableCode = en.DeptID.ToString();
                            modeljoin.messagesid = bll.GetMaxId() - 1;

                            blljoin.Add(modeljoin);
                        }
                    }

                }
            }
        }
        DataBind();
    }
}
