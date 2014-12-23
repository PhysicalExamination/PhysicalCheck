using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spire.Barcode;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

public partial class Default2 : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        BarcodeSettings settings = new BarcodeSettings();
        settings.ShowText = true;
        settings.Data = "2014122100001";
        settings.BarHeight = 100;
        settings.Unit = System.Drawing.GraphicsUnit.Pixel;
        settings.Type = BarCodeType.Code128;
        BarCodeGenerator generator = new BarCodeGenerator(settings);
        System.Drawing.Image barcode  = generator.GenerateImage();
        using (MemoryStream ms = new MemoryStream()) {
            barcode.Save(ms, ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();           
        }  
    }
}