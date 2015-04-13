<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true" CodeFile="unitcheckreport.aspx.cs" Inherits="Examination_unitcheckreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script href="../Scripts/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $("#packagetabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }


        //体检报告
        function Printrpt(kind ) {
            var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?";
            sURL += "ReportKind="+kind ;
            sURL += "&DeptId=" + $("select#<%=drpItems.ClientID%>").find('option:selected').val();  
            sURL += "&DeptName=" + $("select#<%=drpItems.ClientID%>").find('option:selected').text();
            sURL += "&StartDate=" + $("#<%=txtStartDate.ClientID%>").val();
            sURL += "&EndDate=" + $("#<%=txtEndDate.ClientID%>").val();
            window.open(sURL, "_blank", "", true);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div>
        <asp:UpdatePanel ID="UP1" runat="Server">
            <ContentTemplate>
                体检单位：<asp:DropDownList ID="drpItems" runat="server">
                </asp:DropDownList>

                登记日期：<asp:TextBox CssClass="inputCss Wdate" ID="txtStartDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                到<asp:TextBox CssClass="inputCss Wdate" ID="txtEndDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />

                <input type="button" class="buttonCss" value="疾病统计打印"  style="width:120px;" onclick="Printrpt(71);" />
                <input type="button" class="buttonCss" value="结果综述打印" style="width:120px;" onclick="Printrpt(72);" />

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

