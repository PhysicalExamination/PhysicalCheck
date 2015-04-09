<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true" CodeFile="unitcheckreport.aspx.cs" Inherits="Examination_unitcheckreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script href="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $("#packagetabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }


        function Printrpt() {
            var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?";
            sURL +="ReportKind=71";
            sURL += "&DeptName=" + $("#<%=txtDeptName.ClientID%>").val();            
            sURL += "&StartDate=" + $("#<%=txtStartDate.ClientID%>").val();
            sURL += "&EndDate=" + $("#<%=txtEndDate.ClientID%>").val();
            window.open(sURL, "_blank", "", true);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div>
        <asp:UpdatePanel ID="UP1" runat="Server">
            <ContentTemplate>
                
                单&nbsp;&nbsp; 位：
                <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>               
                登记日期：<asp:TextBox CssClass="inputCss Wdate" ID="txtStartDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                到<asp:TextBox CssClass="inputCss Wdate" ID="txtEndDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                
                <input type="button" class="buttonCss" value="打印" onclick="Printrpt();" />
                
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>

