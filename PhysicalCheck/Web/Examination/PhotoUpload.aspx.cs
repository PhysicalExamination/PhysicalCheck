using BusinessLogic.Examination;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Examination_PhotoUpload : BasePage {

    #region 事件

    protected void btnDataImport_Click(object sender, EventArgs e) {
        string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();
        if ((IsXls != ".jpg") && (IsXls != ".png") && (IsXls != ".bmp") && (IsXls != ".gif")) {
            ShowMessage("文件格式不正确，上传的照片必须是jpg或png或bmp或gif文件");
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
            SavePhoto(savePath);
            ShowMessage("照片上传成功！");           
        }
        catch (Exception ex) {
            ShowMessage("照片上传失败，请核对文件重新上传！");
            Console.Write(ex.StackTrace);
        }
    }

    #endregion

    #region 私有方法

    private void SavePhoto(String filePath) {
        Bitmap bmp = new Bitmap(filePath);     
        using (MemoryStream ms = new MemoryStream()) {
            bmp.Save(ms, ImageFormat.Png);
            byte[] buffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buffer, 0, (int)ms.Length);
            hPhoto.Value = Convert.ToBase64String(buffer);            
        }       
    }

    #endregion
}