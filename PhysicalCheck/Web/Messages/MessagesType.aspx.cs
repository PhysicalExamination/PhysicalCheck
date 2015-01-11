using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Admin;
using DataEntity.Admin;
using Common.FormatProvider;

public partial class Admin_DepartmentPage : BasePage {

	#region 私有成员

    private Maticsoft.BLL.messages.messages_type bll = new Maticsoft.BLL.messages.messages_type();

	#endregion

	#region 属性

	private int id {
		get {
            if (ViewState["id"] == null) return 0;
			return (int)ViewState["id"];
		}
		set {
			ViewState["id"] = value;
		}
	}



	#endregion

	#region 重写方法

	protected override void OnLoad(EventArgs e) {
		base.OnLoad(e);
		if (!IsPostBack) {			
			DataBind();
			SetUIState("Default");
		}
	}

	protected override void OnInit(EventArgs e) {
		
		base.OnInit(e);
	}

	protected override void OnUnload(EventArgs e) {
        
		base.OnUnload(e);
	}

	/// <summary>
	/// 检查科室数据绑定
	/// </summary>
	public override void DataBind() {

        DepartmentRepeater.DataSource = bll.GetList(" 1=1 order by code ");
       
		base.DataBind();
	}
	/// <summary>
    /// 设置检查科室界面控件显示状态
	/// </summary>
	/// <param name="Enabled"></param>
	private void SetUIStatus(bool Enabled) {
		ControlCollection Controls = UP2.ContentTemplateContainer.Controls;
		foreach (Control ctrl in Controls) {
			if (ctrl is WebControl) ((WebControl)ctrl).Enabled = Enabled;
		}
	}

	/// <summary>
    /// 设置检查科室界面按钮显示状态
	/// </summary>
	/// <param name="State"></param>
	private void SetUIState(string State) {		
		if (State == "Default") {
			SetUIStatus(false);
			btnNew.Enabled = CanEditData;
			btnEdit.Enabled = CanEditData;
			btnDelete.Enabled = CanEditData;
			btnSave.Enabled = false;
		}
		if (State == "New") {
			SetUIStatus(true);
			btnNew.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnSave.Enabled = true;
		}

		if (State == "Edit") {
			SetUIStatus(true);
			btnNew.Enabled = false;
			btnEdit.Enabled = false;
			btnDelete.Enabled = false;
			btnSave.Enabled = true;
		}		
	}

	#endregion

    

    #region 私有成员

    /// <summary>
    /// 重置检查科室界面
	/// </summary>
	private void ClearUserUI() {
        id = 0;
		txtCode.Text = "";
        txtTemplet.Text = "";
        txtType_name.Text = "";
	}
	/// <summary>
    /// 填充检查科室界面
	/// </summary>
	private void SetUserUI() {
		
        Maticsoft.Model.messages.messages_type Result = new Maticsoft.Model.messages.messages_type();

        Result = bll.GetModel(Convert.ToInt32( id));
		if (Result == null) return;
        txtType_name.Text = Result.type_name;
		txtCode.Text = Result.code;
        
        txtTemplet.Text = Result.templet;

	}

	/// <summary>
    /// 从界面获取检查科室对象
	/// </summary>
	/// <returns></returns>
    private Maticsoft.Model.messages.messages_type GetUserUI()
    {
        Maticsoft.Model.messages.messages_type Result = new Maticsoft.Model.messages.messages_type();

		Result.id = id;
        Result.code = txtCode.Text.Trim();
        Result.type_name = txtType_name.Text;
        Result.templet = txtTemplet.Text;
        Result.upd_time = DateTime.Now;
		return Result;
	}

	#endregion

	#region 事件

    protected void btnSaveUser_Click(object sender, EventArgs e)
    {
        Maticsoft.Model.messages.messages_type  Result = GetUserUI();

        bool Succeed = true;
        if (Result.id == 0)
        {
            Succeed = bll.Add(Result);
        }
        else
        {
            Succeed = bll.Update(Result);
        }

        if (Succeed ) ShowMessage("保存成功!");
        else
            ShowMessage("保存失败!");
        
        DataBind();
        SetUIState("Default");
    }

    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        ClearUserUI();
        btnSave.Enabled = CanEditData;
        SetUIState("New");
    }

    protected void btnDeleteUser_Click(object sender, EventArgs e)
    {

        bool Succeed = true;
        if (id == 0)
        {
            
        }
        else
        {
            Succeed = bll.Delete(id);
        }

        if (Succeed) ShowMessage("删除成功!");
        else
            ShowMessage("删除失败!");
      
        DataBind();
        SetUIState("Default");
    }
    protected void btnEditUser_Click(object sender, EventArgs e)
    {
        SetUIState("Edit");
    }

    protected void btnCancelUser_Click(object sender, EventArgs e)
    {
        SetUIState("Default");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void UserItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "select")
        {
            Literal lblId = (Literal)e.Item.FindControl("lblId");
            id = Convert.ToInt32(lblId.Text);
            SetUserUI();
            SetUIState("Default");
        }
    }

   
	#endregion
}