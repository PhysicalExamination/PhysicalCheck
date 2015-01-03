using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using BusinessLogic.Examination;
using DataEntity.Examination;

public partial class SysConfig_PackageDialog : BasePage {

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            ClientInitial();
            DataBind();
        }
    }

    public override void DataBind() {
        int RecordCount = 0;
        int SelectedIndex = drpCategory.SelectedIndex;
        String SearchKey = txtName.Text.Trim();
        int DeptID = Convert.ToInt32(Request.Params["DeptID"]);
        if (SelectedIndex == 0) {
            //团体体检或体检收费

            List<DepartmentGroupViewEntity> DataSource;
            //检索团体体检是否设置了套餐
            using (DepartmentGroupBusiness DeptGroup = new DepartmentGroupBusiness()) {
                DataSource = DeptGroup.GetDepartmentGroups(DeptID);
            }
            //团体客户有体检套餐设置
            if (DataSource.Count > 0) {
                PackageRepeater.DataSource = DataSource;
                Pager.RecordCount = DataSource.Count;
            }
            //团体客户未设置体检套餐
            if (DataSource.Count <= 0) {
                using (PackageBusiness Package = new PackageBusiness()) {
                    PackageRepeater.DataSource = Package.GetPackages(Pager.CurrentPageIndex,
                        Pager.PageSize, SearchKey, out RecordCount); ;
                    Pager.RecordCount = RecordCount;
                }
            }

            Pager.Visible = true;
            Pager1.Visible = false;
            Panel.Visible = false;
        }
        if (SelectedIndex == 1) {
            using (ItemGroupBusiness ItemGroup = new ItemGroupBusiness()) {
                ItemGroupRepeater.DataSource = ItemGroup.GetItemGroups(Pager1.CurrentPageIndex, Pager1.PageSize,
                    SearchKey, out RecordCount);
                Pager1.RecordCount = RecordCount;
            }
            Pager.Visible = false;
            Pager1.Visible = true;
            Panel.Visible = true;
        }
        base.DataBind();
    }

    #endregion

    #region 私有方法

    private void ClientInitial() {
        String DeptID = Request.Params["DeptID"];
        if (DeptID != "1") drpCategory.Enabled = false;
    }

    #endregion

    #region 事件

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e) {
        DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e) {
        RepeaterItemCollection Items = ItemGroupRepeater.Items;
        CheckBox chkSelected;
        Literal lblGroupID;
        List<String> Groups = new List<string>();
        Groups.AddRange(hGroups.Value.Split(','));
        foreach (RepeaterItem Item in Items) {
            chkSelected = (CheckBox)Item.FindControl("chkSelected");
            lblGroupID = (Literal)Item.FindControl("lblGroupID");
            if (chkSelected.Checked) Groups.Add(lblGroupID.Text);
            if (!chkSelected.Checked) Groups.Remove(lblGroupID.Text);
        }
        hGroups.Value = String.Join(",", Groups.ToArray());
        hGroups.Value = hGroups.Value.Substring(1, hGroups.Value.Length - 1);
        //ShowMessage(hGroups.Value);
    }

    protected void btnSearch_Click(Object Source, EventArgs e) {
        DataBind();
    }

    #endregion

}