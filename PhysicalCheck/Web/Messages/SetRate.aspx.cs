using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Messages_SetRate : BasePage
{
   
    private Maticsoft.BLL.messages.messages_rate bll = new Maticsoft.BLL.messages.messages_rate();
    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack)
        {
            InitUI();

        }
        base.OnLoad(e);
    }

    public void InitUI()
    {

        for (int i = 1; i < 24; i++)
        {
            drpMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }

        List<Maticsoft.Model.messages.messages_rate> list = new List<Maticsoft.Model.messages.messages_rate>();
        list = bll.GetModelList("");

        if (list != null && list.Count > 0)
        {
            drpMonth.SelectedValue = list[0].rate.ToString();

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<Maticsoft.Model.messages.messages_rate> list = new List<Maticsoft.Model.messages.messages_rate>();
        list=bll.GetModelList("");

        Maticsoft.Model.messages.messages_rate model=new Maticsoft.Model.messages.messages_rate ();


        if (list == null || list.Count == 0)
        {
            model.rate = Convert.ToInt16(drpMonth.SelectedValue);

            model.upd_time = DateTime.Now;
            bll.Add(model);
        }
        else
        {
            model = list[0];
            model.rate = Convert.ToInt16(drpMonth.SelectedValue);

            model.upd_time = DateTime.Now;
            bll.Update(model);
        }

        ShowMessage("设置成功！");

    }



}