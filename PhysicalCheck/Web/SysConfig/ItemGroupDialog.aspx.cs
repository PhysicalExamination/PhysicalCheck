using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.SysConfig;

public partial class SysConfig_ItemGroupDialog : BasePage {

    #region 属性

    private int PackageID {
        get {
            if (ViewState["PackageID"] == null) return int.MinValue;
            return (int)ViewState["PackageID"];
        }
        set {
            ViewState["PackageID"] = value;
        }
    }

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            PackageID = Convert.ToInt32(Request.Params["PackageID"]);
            DataBind();
        }
    }

    public override void DataBind() {
        using (ItemGroupBusiness ItemGroup = new ItemGroupBusiness()) {
            int RecordCount = 0;
            ItemGroupRepeater.DataSource = ItemGroup.GetItemGroups(Pager.CurrentPageIndex,
                Pager.PageSize, out RecordCount);
            Pager.RecordCount = RecordCount;
            base.DataBind();
            InitialItemGroup();
        }
    }

    #endregion

    #region 私有方法

    private void InitialItemGroup() {
        PackageBusiness Package = new PackageBusiness();
        int RecordCount = 0;
        List<PackageGroupViewEntity> List = Package.GetPackageGroups(1, 200, PackageID, out RecordCount);
        RepeaterItemCollection Items = ItemGroupRepeater.Items;
        CheckBox chkSelected;
        Literal lblGroupID;
        int GroupID, Count;
        foreach (RepeaterItem Item in Items) {
            chkSelected = (CheckBox)Item.FindControl("chkSelected");
            lblGroupID = (Literal)Item.FindControl("lblGroupID");
            GroupID = Convert.ToInt32(lblGroupID.Text);
            Count = List.Count(p => p.ID.PackageID == PackageID && p.ID.GroupID == GroupID);
            if (Count > 0) chkSelected.Checked = true;
        }
    }

    #endregion

    #region 受保护方法

    protected String GetSex(Object obj) {
        String val = (String)obj;
        if (val == "%") return "不限";
        if (val == "0") return "女";
        if (val == "1") return "男";
        return "";
    }

    #endregion

    #region 事件

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e) {
        PackageBusiness Package = new PackageBusiness();
        RepeaterItemCollection Items = ItemGroupRepeater.Items;
        CheckBox chkSelected;
        Literal lblGroupID;
        PackageGroupEntity PackageGroup;
        foreach (RepeaterItem Item in Items) {
            chkSelected = (CheckBox)Item.FindControl("chkSelected");
            lblGroupID = (Literal)Item.FindControl("lblGroupID");
            PackageGroup = new PackageGroupEntity();
            PackageGroup.ID = new PackageGroupPK {
                PackageID = PackageID,
                GroupID = Convert.ToInt32(lblGroupID.Text)
            };
            if (chkSelected.Checked) Package.SavePackageGroup(PackageGroup);
            if (!chkSelected.Checked) Package.DeletePackageGroup(PackageGroup);
        }
        decimal PackageCharge = Package.GetPackagePrice(PackageID);
        hValue.Value = PackageCharge + "";
        Package.UpdatePackagePrice(PackageID, PackageCharge);
        ShowMessage("套餐组合项保存成功！");
    }

    #endregion


}