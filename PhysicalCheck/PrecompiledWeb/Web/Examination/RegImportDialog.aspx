<%@ page language="C#" masterpagefile="~/MasterPage/ContentDetailMasterPage.master" autoeventwireup="true" inherits="Examination_RegImportDialog, App_Web_lbndgfpo" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
<asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnDataImport" runat="server" Text="导入" OnClick="btnDataImport_Click" />
    <input type="button" value="关闭" onclick="window.close();" />
    <%--<p>
        <strong>重要提示：</strong></p>
    <ol>
        <li>数据导入前请确认设备名称与设备集中的设备名称是否匹配，否则会造成导入失败！</li>
        <li>新导入的数据会覆盖原有设备特征量。</li>
    </ol>--%>
</asp:Content>
