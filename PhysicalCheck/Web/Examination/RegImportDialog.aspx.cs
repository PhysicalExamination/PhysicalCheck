﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using BusinessLogic.Examination;
using DataEntity.Examination;
using System.Text.RegularExpressions;
using DataEntity.SysConfig;
using BusinessLogic.SysConfig;
using Common.FormatProvider;

/// <summary>
/// 团体体检人员数据导入
/// </summary>
public partial class Examination_RegImportDialog : BasePage {

    #region 私有成员

    private List<PackageEntity> m_Packages;

    #endregion

    #region 重写方法

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!IsPostBack) {
           
        }
    }

    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        using (PackageBusiness Business = new PackageBusiness()) {
            m_Packages = Business.GetPackages();
        }
    }
    #endregion

    #region 事件

    protected void btnDataImport_Click(object sender, EventArgs e) {

        string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();
        if ((IsXls != ".xls") && (IsXls != ".xlsx")) {
            ShowMessage("文件格式不正确，导入的文件必须是Excel文件");
            return;
        }
        try {
            DirectoryInfo path = new DirectoryInfo(Server.MapPath("~\\Attachment\\"));
            foreach (FileInfo f in path.GetFiles()) {
                f.Delete();
            }
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + FileUpload1.FileName;
            //Server.MapPath 获得虚拟服务器相对路径
            string savePath = Server.MapPath(("~\\Attachment\\") + filename);
            //SaveAs 将上传的文件内容保存在服务器上
            FileUpload1.SaveAs(savePath);
            ImportData(savePath);
            ShowMessage("文件导入成功！");
        }
        catch (Exception ex) {
            ShowMessage("文件导入失败，请核对文件重新导入！");
            Console.Write(ex.StackTrace);
        }
    }

    #endregion

    #region 私有方法

    private void ImportData(String filePath) {
        FileInfo fileInfo = new FileInfo(filePath);
        String fileType = fileInfo.Extension;
        if ((fileType != ".xlsx") && (fileType != ".xls")) return;
        String connStr;
        if (fileType == ".xls")
            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileInfo.FullName + ";" + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
        else
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileInfo.FullName + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
        using (OleDbConnection Connection = new OleDbConnection(connStr)) {
            Connection.Open();
            using (DataTable schemaTable = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null)) {
                DataSet ds;
                OleDbDataAdapter DataAdapter;
                String sheetName = (String)schemaTable.Rows[0]["TABLE_NAME"];
                String CommandText = " SELECT * FROM [" + sheetName + "]";
                DataAdapter = new OleDbDataAdapter(CommandText, Connection);
                ds = new DataSet();
                DataAdapter.Fill(ds);
                SaveDataToDB(ds.Tables[0]);
                ds.Dispose();
                DataAdapter.Dispose();
            }
            Connection.Close();
        }
    }

    private void SaveDataToDB(DataTable SourceTable) {
        RegistrationViewEntity RegInfo;
        Regex regex = new Regex(@"/(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/");
        String IDNumber,PackageName,PersonName;       
        using (RegistrationBusiness Registration = new RegistrationBusiness()) {
            DataRowCollection Rows = SourceTable.Rows;
            foreach (DataRow Row in Rows) {
                PackageName = Row[7] + "";
                PersonName = Row[1] + "";
                if (String.IsNullOrWhiteSpace(PackageName)) continue;
                if (String.IsNullOrWhiteSpace(PersonName)) continue;
                RegInfo = new RegistrationViewEntity();
                RegInfo.DeptID = 1;
                RegInfo.RegisterDate = DateTime.Now.Date;
                RegInfo.Name = PersonName;               
                RegInfo.Sex = Row[2] + "";
                IDNumber = Row[3] + "";
                RegInfo.Age = EnvConverter.ToInt32(Row[5] + "");
                if (regex.IsMatch(IDNumber)) {
                    RegInfo.IDNumber = IDNumber;
                    RegInfo.Birthday = GetBirthday(IDNumber);
                    RegInfo.Age = GetAge(IDNumber);
                }
                RegInfo.Marriage = Row[4] + "";
                RegInfo.LinkTel = Row[6] + "";
                RegInfo.PackageID = GetPackage(PackageName);
                RegInfo.Mobile = RegInfo.LinkTel;
                Registration.SaveRegistration(RegInfo);
            }
        }
    }

    private int GetAge(String IDNumber) {
        int CurrentYear = DateTime.Now.Year;
        int BirthYear = Convert.ToInt32(IDNumber.Substring(6, 4));
        return CurrentYear - BirthYear;
    }

    private DateTime? GetBirthday(String IDNumber) {
        int Year = Convert.ToInt32(IDNumber.Substring(6, 4));
        int Month = Convert.ToInt32(IDNumber.Substring(10, 2));
        int Day = Convert.ToInt32(IDNumber.Substring(12, 2));
        return new DateTime(Year, Month, Day);
    }

    private int? GetPackage(String PackageName) {
        var q = from p in m_Packages
                where p.PackageName == PackageName
                select p.PackageID;
        List<int?> List = q.ToList<int?>();
        if (List.Count > 0) return List[0];
        return null;
    }

    #endregion

}