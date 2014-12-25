<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="ReviewPage.aspx.cs" Inherits="Examination_CheckedRepeatPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        $(function () {
            $("#tabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">浏览</a></li>
        </ul>
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <%-- 体检套餐<asp:DropDownList ID="drpPackages" runat="server">
                    </asp:DropDownList>
                    所属区域<asp:DropDownList ID="drpRegions" runat="server">
                    </asp:DropDownList>--%>
                    复检日期<asp:TextBox CssClass="textbox31  Wdate" ID="txtStartDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                    至<asp:TextBox CssClass="textbox31  Wdate" ID="txtEndDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                    是否已发：
                    <asp:DropDownList ID="drpisSend" runat="server">
                        <asp:ListItem Value="0" Text="全部"> </asp:ListItem>
                        <asp:ListItem Value="否" Text="否" Selected="True"> 
                        </asp:ListItem>
                        <asp:ListItem Value="是" Text="是"> 
                        </asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="Button2" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
                    <a href="javascript:;" onclick="$(':checkbox').attr('checked','checked');" id="all">
                        全部选择</a> <a href="javascript:;" onclick="$(':checkbox').removeAttr('checked');" id="delAll">
                            取消选择</a>
                    <asp:Button ID="btnMessages" runat="server" CssClass="buttonCss" Text="群 发" OnClick="btnMessages_Click" />
                    <asp:Repeater ID="ReportRepeater" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        选 择
                                    </th>
                                    <th>
                                        体检编号
                                    </th>
                                    <th>
                                        姓名
                                    </th>
                                    <th>
                                        年龄
                                    </th>
                                    <th>
                                        性别
                                    </th>
                                    <th>
                                        复查概要
                                    </th>
                                    <th>
                                        预定复检日期
                                    </th>
                                    <th>
                                        已发送
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:CheckBox ID="checkbox1" runat="server" />
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Literal ID="lblRegisterNo" runat="server" Text=' <%# Eval("RegisterNo")%>' />
                                    <asp:Literal ID="lblPersonID" runat="server" Text=' <%# Eval("PersonID")%>' Visible="false" />
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Name")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("age")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("sex")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("ReviewSummary")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("ReviewDate")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# string.IsNullOrEmpty(Eval("messagesId ").ToString()) ? "否" :"是"  %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <asp:CheckBox ID="checkbox1" runat="server" />
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Literal ID="lblRegisterNo" runat="server" Text=' <%# Eval("RegisterNo")%>' />
                                    <asp:Literal ID="lblPersonID" runat="server" Text=' <%# Eval("PersonID")%>' Visible="false" />
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Name")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("age")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("sex")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("ReviewSummary")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("ReviewDate")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# string.IsNullOrEmpty(Eval("messagesId ").ToString()) ? "否" :"是"  %>
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
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
