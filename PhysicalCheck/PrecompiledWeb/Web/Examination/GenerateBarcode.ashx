<%@ WebHandler Language="C#" Class="GenerateBarcode" %>

using System;
using System.Web;
using BarcodeLib;
using Drawing = System.Drawing;
using System.IO;
using Imaging = System.Drawing.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class GenerateBarcode : IHttpHandler {

    public void ProcessRequest(HttpContext context) {
        PDFReport report = new PDFReport();
        report.Print(context, "");
        /*HttpResponse Response = context.Response;
        HttpRequest Request = context.Request;
        String Data = "2014122200001";//Request.Params["Data"];
        Response.ContentType = "application/pdf";
        Response.Charset = "utf-8";
        //Response.AppendHeader("Content-Disposition", "attachment;filename=" + Data);
        //Response.ContentType = "image/png";

        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        b.IncludeLabel = true;
        //b.AlternateLabel = "庞永飞";       
        b.Encode(TYPE.CODE128, Data, 300, 100);
        Document doc = new Document();      
        PdfWriter.GetInstance(doc, Response.OutputStream);
        doc.Open();
        Rectangle pagesize = new Rectangle(3,4);
        doc.SetPageSize(pagesize);
        iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(b.Encoded_Image_Bytes);
        doc.Add(gif);       
        doc.Close();
        Response.Flush();       
        Response.End();*/
        //doc.Close(); 
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}