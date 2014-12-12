using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;
using BusinessLogic.Admin;

public partial class SysConfig_CheckedItemDialog : BasePage {

    #region 属性

    private int GroupID {
        get {
            if (ViewState["GroupID"] == null) return int.MinValue;
            return (int)ViewState["GroupID"];
        }
        set {
            ViewState["GroupID"] = value;
        }
    }

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            ClientInitial();
            GroupID = Convert.ToInt32(Request.Params["GroupID"]);
            DataBind();
        }
    }

    public override void DataBind() {
        using (CheckedItemBusiness CheckedItem = new CheckedItemBusiness()) {
            int RecordCount = 0;
            int DeptID = Convert.ToInt32(drpDepts.SelectedValue);
            CheckedItemRepeater.DataSource = CheckedItem.GetCheckedItems(Pager.CurrentPageIndex,
                Pager.PageSize, DeptID, out RecordCount);
            Pager.RecordCount = RecordCount;
            base.DataBind();
            InitialItemGroup();
        }
    }

    #endregion

    #region 私有方法

    private void ClientInitial() {
        using (DepartmentBusiness Department = new DepartmentBusiness()) {
            int RecordCount = 0;
            drpDepts.DataSource = Department.GetDepartments(1, 100, out RecordCount);
            drpDepts.DataValueField = "DeptID";
            drpDepts.DataTextField = "DeptName";
            drpDepts.DataBind();
        }
    }

    private void InitialItemGroup() {
        ItemGroupBusiness Group = new ItemGroupBusiness();       
        List<ItemGroupDetailViewEntity> List = Group.GetItemGroupDetails(GroupID);
        RepeaterItemCollection Items = CheckedItemRepeater.Items;
        CheckBox chkSelected;
        Literal lblItemID;
        int ItemID, Count;
        foreach (RepeaterItem Item in Items) {
            chkSelected = (CheckBox)Item.FindControl("chkSelected");
            lblItemID = (Literal)Item.FindControl("lblItemID");
            ItemID = Convert.ToInt32(lblItemID.Text);
            Count = List.Count(p => p.ID.GroupID == GroupID && p.ID.ItemID == ItemID);
            if (Count > 0) chkSelected.Checked = true;
        }
    }

    #endregion

    #region 事件

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e) {
        DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e) {
        ItemGroupBusiness Group = new ItemGroupBusiness(); 
        RepeaterItemCollection Items = CheckedItemRepeater.Items;
        CheckBox chkSelected;
        Literal lblItemID;
        ItemGroupDetailEntity ItemGroupDetail;
        int ItemID;
        foreach (RepeaterItem Item in Items) {
            chkSelected = (CheckBox)Item.FindControl("chkSelected");
            lblItemID = (Literal)Item.FindControl("lblItemID");
            ItemID = Convert.ToInt32(lblItemID.Text);
            ItemGroupDetail = new ItemGroupDetailEntity();
            ItemGroupDetail.ID = new ItemGroupDetailPK {
                 GroupID = GroupID,
                ItemID = Convert.ToInt32(lblItemID.Text)               
            };
            if (chkSelected.Checked) Group.SaveItemGroupDetail(ItemGroupDetail);
            if (!chkSelected.Checked) Group.DeleteItemGroupDetail(ItemGroupDetail);
        }        
        ShowMessage("组合项目检查明细保存成功！");
    }

    #endregion
}