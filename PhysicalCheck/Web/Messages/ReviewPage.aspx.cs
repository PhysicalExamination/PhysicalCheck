using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Examination;
using DataEntity.Examination;
using System.Data;
/// <summary>
/// 复查通知书
/// </summary>
public partial class Examination_CheckedRepeatPage : BasePage
{
    #region 重写方法
    Maticsoft.BLL.messages.messagesSend bll = new Maticsoft.BLL.messages.messagesSend();
    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack)
        {

            DataBind();
        }
        base.OnLoad(e);
    }

    public override void DataBind()
    {
        string isSend = drpisSend.SelectedValue;


        // string sqlw = string.Format(" RegisterDate>'{0}' And RegisterDate<'{1}' And IsCheckOver='1'");
        string sqlw = " 1=1 ";

        if (txtStartDate.Text != "")
            sqlw += string.Format(" And  RegisterDate>'{0}' ", Convert.ToDateTime(txtStartDate.Text));

        if (txtEndDate.Text != "")
            sqlw += string.Format("  And RegisterDate<'{0}' ", Convert.ToDateTime(txtEndDate.Text));

        if (isSend == "是")
        {
            sqlw += " And messagesid is not NULL ";
        }
        else if (isSend == "否")
            sqlw += " And messagesid is NULL ";


        DataSet ds = bll.GetListByPage_Registration(sqlw, "", (Pager.CurrentPageIndex-1)*Pager.PageSize,(Pager.CurrentPageIndex)*Pager.PageSize );

        Pager.RecordCount = bll.GetRecordCount_Registration(sqlw);
        ReportRepeater.DataSource = ds.Tables[0];

        base.DataBind();
    }

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

    protected void btnMessages_Click(object sender, EventArgs e)
    {
        RegistrationBusiness Registration = new RegistrationBusiness();

        for (int i = 0; i < this.ReportRepeater.Items.Count; i++)
        {
            CheckBox cb = (CheckBox)ReportRepeater.Items[i].FindControl("checkbox1");
            Literal ltPersonID = (Literal)ReportRepeater.Items[i].FindControl("lblPersonID");
            Literal ltlblDeptName = (Literal)ReportRepeater.Items[i].FindControl("lblDeptName");
            Literal ltRegisterNo = (Literal)ReportRepeater.Items[i].FindControl("lblRegisterNo");
            if (cb.Checked)
            {

                Maticsoft.Model.messages.checkperson en = new Maticsoft.Model.messages.checkperson();

                en = new Maticsoft.BLL.messages.checkperson().GetModel(Convert.ToInt32(ltPersonID.Text));

                if (en != null)
                {

                    //string smsResult = SMS.Send("",en.telephone);
                    Maticsoft.Model.messages.messages model = new Maticsoft.Model.messages.messages();

                    model.type = messagesType.复检通知.ToString();
                    model.rcvMan = en.Name;
                    model.rcvTel = en.Mobile;
                    model.unit = ltlblDeptName.Text;
                    model.sendTime = DateTime.Now;

                    model.content = string.Format("[{0}]您好!您在[YYMC]的体检完成,网上www.tophim.com查询体检结果的帐号[ZH]密码[MM]", en.Name);

                    model.status = "成功";

                    Maticsoft.BLL.messages.messages bll = new Maticsoft.BLL.messages.messages();
                    if (bll.Add(model))
                    {
                        Maticsoft.Model.messages.messagesjoin modeljoin = new Maticsoft.Model.messages.messagesjoin();

                        Maticsoft.BLL.messages.messagesjoin blljoin = new Maticsoft.BLL.messages.messagesjoin();

                        if (blljoin.Exists("registration", ltRegisterNo.Text))
                        {
                            string sqlW = string.Format(" jointable='registration' And tableCode='{0}'", en.DeptID.ToString());
                            modeljoin = blljoin.GetModelList(sqlW)[0];

                            modeljoin.messagesid = bll.GetMaxId() - 1;


                            blljoin.Update(modeljoin);
                        }
                        else
                        {
                            modeljoin.jointable = "registration";
                            modeljoin.tableCode = ltRegisterNo.Text;
                            modeljoin.messagesid = bll.GetMaxId() - 1;

                            blljoin.Add(modeljoin);
                        }
                    }
                }
            }
        }
        DataBind();
    }

    #endregion
}