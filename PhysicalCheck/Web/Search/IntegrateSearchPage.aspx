<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="IntegrateSearchPage.aspx.cs"
    Inherits="Search_IntegrateSearchPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function PrintReport() {
            var YearMonth = $("#<%=txtYearMonth.ClientID%>").val();
            var Category = $("#<%=drpCategory.ClientID%>").val();
            var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?YearMonth=" + YearMonth +
                       "&Category=" + Category + "&ReportKind=64";
            window.open(sURL, "_blank", "", true);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    年月 
    <asp:TextBox ID="txtYearMonth" runat="server" CssClass="textbox31  Wdate"
        onclick="new WdatePicker(this,'%Y-%M',false,'whyGreen')" />
    统计类别<asp:DropDownList ID="drpCategory" runat="server">
        <asp:ListItem Value="1">按套餐统计</asp:ListItem>
        <asp:ListItem Value="2">按行业分组</asp:ListItem>
        <asp:ListItem Value="3">按工种分组</asp:ListItem>
        <asp:ListItem Value="4">按地区分组</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnSearch" runat="server" Text="检索" OnClick="btnSearch_Click" CssClass="buttonCss" />
    <input id="btnExport" type="button" value="导出" class="buttonCss" onclick="PrintReport();" />
    <asp:Repeater ID="Repeater" runat="server">
        <HeaderTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th>分组名称</th>
                    <th>合格人数（人）</th>
                    <th>不合格人数（人）</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                <td class="VLine" align="center">
                    <%# Eval("GroupName") %>
                </td>
                <td class="VLine" align="center">
                    <%# Eval("PassedCount") %>
                </td>
                <td class="VLine" align="center">
                    <%# Eval("UnpassedCount") %>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                <td class="VLine" align="center">
                    <%# Eval("GroupName") %>
                </td>
                <td class="VLine" align="center">
                    <%# Eval("PassedCount") %>
                </td>
                <td class="VLine" align="center">
                    <%# Eval("UnpassedCount") %>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

