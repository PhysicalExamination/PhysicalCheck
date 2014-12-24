using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

/// <summary>
///PDFReport 的摘要说明
/// </summary>
public class PDFReport:BaseReport {
    private Document m_Document;
    private PdfWriter m_Writer;

    protected override void Initialize(HttpContext context) {
        context.Response.ContentType = "application/pdf";
        m_Document = new Document();
        m_Writer = PdfWriter.GetInstance(m_Document, context.Response.OutputStream);
        m_Document.Open();
    }

    protected override void BuildHeader() {
        
    }

    protected override void BuildContent() {
        string fontPath = Environment.GetEnvironmentVariable("WINDIR") + "\\FONTS\\SIMHEI.TTF";//强制中文字体，否则无法显示中文,simsun.ttc
        BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font = new Font(baseFont, 10, Font.NORMAL);
        PdfPTable table = new PdfPTable(5);       
       
        table.WidthPercentage = 100;
        PdfPCell cell;
        cell = new PdfPCell(new Phrase("一般情况检查",font));
        //cell.Width =
        cell.FixedHeight = 25;
        cell.Colspan = 5;
        cell.BackgroundColor = BaseColor.GRAY;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("身高、体重、血压", font));
        cell.FixedHeight = 25;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("检查日期", font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("2014 年 11 月 12 日", font));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("检查医生", font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("张占波", font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);


        cell = new PdfPCell(new Phrase("检查项目", font));
        cell.FixedHeight = 25;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("检查结果", font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("单位", font));
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("参考范围", font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);

        cell = new PdfPCell(new Phrase("提示", font));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        table.AddCell(cell);
        m_Document.Add(table);
        String path = System.Environment.SystemDirectory;
    }

    protected override void BuildFooter() {
        
    }

    protected override void Release(HttpContext context) {
        m_Document.Close();
        context.Response.Flush();
        context.Response.End();
    }
}