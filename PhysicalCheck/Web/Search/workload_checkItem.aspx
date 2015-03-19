﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="workload_checkItem.aspx.cs" Inherits="Examination_customerArchive" %>

<%@ Import Namespace="Common.FormatProvider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $("#packagetabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }
        function Printrpt() {
            var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?ReportKind=63";
            sURL += "&DeptId=" + $("select#<%=drpdepartment.ClientID%>").find('option:selected').val();
            sURL += "&DeptName=" + $("select#<%=drpdepartment.ClientID%>").find('option:selected').text();
            sURL += "&CheckDoctor=" + $("#<%=txtCheckDoctor.ClientID%>").val();
            sURL += "&StartDate=" + $("#<%=txtStartDate.ClientID%>").val();
            sURL += "&EndDate=" + $("#<%=txtEndDate.ClientID%>").val();
            window.open(sURL, "_blank", "", true);


        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    科室：
                <asp:DropDownList ID="drpdepartment" runat="server">
                </asp:DropDownList>
    体检医生：
                <asp:TextBox ID="txtCheckDoctor" runat="server"></asp:TextBox>
    日期：<asp:TextBox CssClass="inputCss Wdate" ID="txtStartDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
    到<asp:TextBox CssClass="inputCss Wdate" ID="txtEndDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <input type="button" class="buttonCss" value="打印" onclick="Printrpt();" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="ReportRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>科室
                            </th>
                            <th>检测项
                            </th>
                            <th>工作量
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <asp:Literal ID="DeptName" runat="server" Text=' <%# Eval("DeptName")%>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("ItemName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("sumNum")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <asp:Literal ID="DeptName" runat="server" Text=' <%# Eval("DeptName")%>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("ItemName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("sumNum")%>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
