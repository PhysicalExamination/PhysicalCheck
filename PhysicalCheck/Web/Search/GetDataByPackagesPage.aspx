<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true" CodeFile="GetDataByPackagesPage.aspx.cs" Inherits="Search_GetDataByPackagesPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function PrintReport() {
            var StartDate = $("#<%=txtStartDate.ClientID%>").val();
            var EndDate = $("#<%=txtEndDate.ClientID%>").val();
            var PackageID = $("#<%=drpPackages.ClientID%>").val();
            var PackageName = $("#<%=drpPackages.ClientID%>").find("option:selected").text();
            var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?PackageID=" + PackageID +
                       "&PackageName=" + PackageName + "&StartDate=" + StartDate +
                       "&EndDate=" + EndDate + "&ReportKind=66";
            window.open(sURL, "_blank", "", true);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    体检日期<asp:TextBox CssClass="textbox31  Wdate" ID="txtStartDate" runat="server"
        onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />至
    <asp:TextBox CssClass="textbox31  Wdate" ID="txtEndDate" runat="server"
        onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
    体检套餐<asp:DropDownList ID="drpPackages" runat="server" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <input type="button" class="buttonCss" value="导出" onclick="PrintReport();"/>

    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="Repeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>体检编号</th>
                            <th>姓名</th>
                            <th>身份证号</th>
                            <th>性别 </th>
                            <th>年龄</th>
                            <th>工种</th>
                            <th>行业</th>
                            <th>工作单位</th>
                            <th>体检套餐</th>
                            <th>主检医生</th>
                            <th>检查结论</th>
                            <th>报告日期</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <%# Eval("RegisterNo") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("IDNumber") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Sex") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Age") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("TradeName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("IndustryName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("PackageName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("OverallDoctor") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# GetHealthCondition(Eval("HealthCondition")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("OverallDate")) %>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <%# Eval("RegisterNo") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("IDNumber") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Sex") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Age") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("TradeName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("IndustryName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("PackageName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("OverallDoctor") %>
                        </td>
                        <td class="VLine" align="center">
                            <%#GetHealthCondition(Eval("HealthCondition")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("OverallDate")) %>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:AspNetPager ID="Pager" runat="server" PageAlign="center" PageIndexBox="DropDownList"
                OnPageChanged="Pager_PageChanged" ButtonImageNameExtension="enable/" CustomInfoTextAlign="Center"
                DisabledButtonImageNameExtension="disable/" HorizontalAlign="Center" ImagePath="~/images/"
                MoreButtonType="Text" NavigationButtonType="Image" NumericButtonType="Text" PagingButtonType="Image"
                AlwaysShow="True" PagingButtonSpacing="8px" NumericButtonCount="5" EnableTheming="True"
                PageSize="15">
            </asp:AspNetPager>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

