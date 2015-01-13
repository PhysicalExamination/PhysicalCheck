<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Reports_Default, App_Web_unpp45xv" theme="redmond" %>

<%@ Register Assembly="FastReport.Web" Namespace="FastReport.Web" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <cc1:WebReport ID="WebReport1" runat="server" BackColor="White" Font-Bold="False"
        Width="100%" Height="100%"  Padding="5, 5, 5, 5"
        ToolbarColor="Lavender" PrintInPdf="True" PdfEmbeddingFonts="True" Layers="False"
        Zoom="1" ToolbarStyle="Large" ToolbarBackgroundStyle="Light" ToolbarIconsStyle="Blue"
        EnableViewState="True" />
</asp:Content>
