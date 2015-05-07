using Cobainsoft.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Examination_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //byte[] imges;      
        using ( FileStream fs = new FileStream(@"d:\barcode1.gif", FileMode.OpenOrCreate)){
            bar1.Barcode.BarcodeType = BarcodeType.CODE128A;
            bar1.Barcode.MakeImage(ImageFormat.Gif, 30, 100, false, false, "123456789", fs);
            fs.Flush();
            fs.Close();
            //imges = ms.ToArray();
            //bar1.Barcode.SaveImage(ImageFormat.Png, 30, 80, false, true, "123456789", @"d:\barcode.png");
            //ms.Read(imges, 0, Convert.ToInt32(ms.Length));           
        }
    }
}