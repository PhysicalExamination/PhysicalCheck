<%@ WebHandler Language="C#" Class="GenerateBarcode" %>

using System;
using System.Web;
using Spire.Barcode;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

public class GenerateBarcode : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        HttpResponse Response = context.Response;
        HttpRequest Request = context.Request;
        BarcodeSettings settings = new BarcodeSettings();
        settings.ShowText = true;
        settings.Data = Request.Params["Data"];
        settings.BarHeight = 150;
        settings.Unit = System.Drawing.GraphicsUnit.Pixel;
        settings.Type = BarCodeType.Code128;
        BarCodeGenerator generator = new BarCodeGenerator(settings);
        Image barcode = generator.GenerateImage();
        byte[] imageBytes;
        using (MemoryStream ms = new MemoryStream()) {
            barcode.Save(ms, ImageFormat.Png);
            imageBytes = ms.ToArray();
        }
        Response.ClearContent();
        Response.ContentType = "image/png";
        Response.BinaryWrite(imageBytes);       
        Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}