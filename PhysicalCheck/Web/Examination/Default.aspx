<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Examination_Default" %>
<%@ Register Assembly="BarCode" TagPrefix="barcode" Namespace="Cobainsoft.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <barcode:BarcodeImage ID="bar1" runat="server" BarcodeType="CODE128A" Font="宋体" 
        CopyRightText="" Data="1234567890128" Height="80px" BarcodeHeight="80" BarcodeWidth="120" BarWidth="1" />
</asp:Content>

