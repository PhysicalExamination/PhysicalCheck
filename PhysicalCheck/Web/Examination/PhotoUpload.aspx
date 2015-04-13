<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentDetailMasterPage.master" AutoEventWireup="true" CodeFile="PhotoUpload.aspx.cs" Inherits="Examination_PhotoUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function onClose() {
            window.returnValue = $("#<%=hPhoto.ClientID%>").val();
            window.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">   
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnDataImport" runat="server" Text="上传" OnClick="btnDataImport_Click" />
    <input type="button" value="关闭" onclick="onClose();" />
    <asp:HiddenField ID="hPhoto" runat="server" />
</asp:Content>

