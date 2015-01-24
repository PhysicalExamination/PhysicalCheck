using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Admin;
using DataEntity.Admin;
using Common.FormatProvider;
using System.Data;
public partial class Admin_DepartmentPage : BasePage {

	#region 私有成员

   
	//private DepartmentBusiness m_Dept;

    private Maticsoft.BLL.Examination.advise bll = new Maticsoft.BLL.Examination.advise();

	#endregion

	#region 属性

    //private int? DeptNo {
    //    get {
    //        if (ViewState["DeptNo"] == null) return null;
    //        return (int)ViewState["DeptNo"];
    //    }
    //    set {
    //        ViewState["DeptNo"] = value;
    //    }
    //}

    private int Id
    {
        get
        {
            if (ViewState["Id"] == null) return 0;
            return (int)ViewState["Id"];
        }
        set
        {
            ViewState["Id"] = value;
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

        DataSet ds = bll.GetListByPage("", "", (Pager.CurrentPageIndex - 1) * Pager.PageSize, (Pager.CurrentPageIndex) * Pager.PageSize);

        Pager.RecordCount = bll.GetRecordCount("");
        DepartmentRepeater.DataSource = ds.Tables[0];

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
        txtRegisterNo.Text = "";
        txtContent.Text = "";
        txtContent2.Text = "";
        txtContent3.Text = "";
        txtDoctor.Text = "";
        txtInvestigation.Text = "";

        txtadd_time.Text = "";
	}
	/// <summary>
    /// 填充检查科室界面
	/// </summary>
	private void SetUserUI() {
        
        Maticsoft.Model.Examination.advise model = bll.GetModel(Id);

        if (model == null)
            return;
        txtRegisterNo.Text = model.RegisterNo;
        txtContent.Text = model.content;
        txtContent2.Text = model.content2;
        txtContent3.Text = model.content3;
        txtDoctor.Text = model.Doctor;
        txtInvestigation.Text = model.investigation;

        txtadd_time.Text = model.add_time.ToString();
	}

	#endregion

	#region 事件

	protected void btnSaveUser_Click(object sender, EventArgs e) {

        Maticsoft.Model.Examination.advise model = new Maticsoft.Model.Examination.advise();

        model.id = Id;
       model.RegisterNo= txtRegisterNo.Text  ;
         model.content=txtContent.Text;
         model.content2 =txtContent2.Text ;
         model.content3=txtContent3.Text ;
         model.Doctor=txtDoctor.Text ;
        model.investigation= txtInvestigation.Text ;

        model.add_time=DateTime.Now;

        bool Succeed = true;
        if (Id == 0)
            Succeed= bll.Add(model);
        else
            Succeed = bll.Update(model);



        if (Succeed) ShowMessage("数据保存成功!");
        else
            ShowMessage("数据保存成功!");

		DataBind();
		SetUIState("Default");
	}

	protected void btnNewUser_Click(object sender, EventArgs e) {
		ClearUserUI();
		btnSave.Enabled = CanEditData;
		SetUIState("New");
	}

	protected void btnDeleteUser_Click(object sender, EventArgs e) {
        
        if ( bll.Delete(Id))
            ShowMessage("删除成功!");
        else
            ShowMessage("删除成功!");
        
		DataBind();
		SetUIState("Default");
	}
	protected void btnEditUser_Click(object sender, EventArgs e) {
		SetUIState("Edit");
	}

	protected void btnCancelUser_Click(object sender, EventArgs e) {
		SetUIState("Default");
	}

	protected void btnSearch_Click(object sender, EventArgs e) {
		DataBind();
	}

	protected void UserItemCommand(object source, RepeaterCommandEventArgs e) {
		if (e.CommandName.ToLower() == "select") {
            Literal lblId = (Literal)e.Item.FindControl("lblId");
            Id = EnvConverter.ToInt32(lblId.Text).Value;
			SetUserUI();
			SetUIState("Default");
		}
	}

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

	#endregion
}