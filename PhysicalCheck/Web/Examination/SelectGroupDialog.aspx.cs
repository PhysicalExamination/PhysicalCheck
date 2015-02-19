using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.SysConfig;
using DataEntity.Examination;
using BusinessLogic.Examination;

public partial class Examination_SelectGroupDialog : BasePage {

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
            DataBind();
        }
    }

    public override void DataBind() {
        using (ItemGroupBusiness ItemGroup = new ItemGroupBusiness()) {
            int RecordCount = 0;
            String SearchKey = txtName.Text;
            ItemGroupRepeater.DataSource = ItemGroup.GetItemGroups(Pager.CurrentPageIndex, Pager.PageSize,
                SearchKey, ItemGroupSex, out RecordCount);
            Pager.RecordCount = RecordCount;
        }
        base.DataBind();
    }

    #endregion

    #region 事件

    protected void btnSearch_Click(Object Source, EventArgs e) {
        DataBind();
    }

    protected void Pager_PageChanged(object source, EventArgs e) {
        DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e) {
        RepeaterItemCollection Items = ItemGroupRepeater.Items;
        CheckBox chkSelected;
        Literal lblGroupID, lblDeptID;
        String RegisterNo = Request.Params["RegisterNo"];
        int PackageID = Convert.ToInt32(Request.Params["PackageID"]);
        foreach (RepeaterItem Item in Items) {
            chkSelected = (CheckBox)Item.FindControl("chkSelected");
            lblGroupID = (Literal)Item.FindControl("lblGroupID");
            lblDeptID = (Literal)Item.FindControl("lblDeptID");
            if (chkSelected.Checked) {
                GroupResultEntity GroupResult = new GroupResultEntity {
                    ID = new GroupResultPK {
                        RegisterNo = RegisterNo,
                        GroupID = Convert.ToInt32(lblGroupID.Text)
                    },
                    DeptID = Convert.ToInt32(lblDeptID.Text),
                    IsOver = false,
                    PackageID = PackageID
                };
                using (RegistrationBusiness Business = new RegistrationBusiness()) {
                    Business.SaveGroupResult(GroupResult);
                }
            }
        }
        ShowMessage("数据保存成功！");
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

    #region 私有方法

    private String ItemGroupSex {
        get {
            if (Request.Params["Sex"] == "男") return "1";
            if (Request.Params["Sex"] == "女") return "0";
            return "";
        }
    }

    #endregion
}