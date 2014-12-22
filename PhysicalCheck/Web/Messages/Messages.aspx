<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Messages_Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                 日期：<asp:TextBox CssClass="inputCss Wdate" ID="txtdates" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                   到<asp:TextBox CssClass="inputCss Wdate" ID="txtDateE" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                    <asp:DropDownList ID="drptype" runat="server">
                        <asp:ListItem Value="0" Text="全部"> </asp:ListItem>
                        <asp:ListItem Value="体检见过通知" Text="体检见过通知" Selected="True"> 
                        </asp:ListItem>
                        <asp:ListItem Value="复检通知" Text="复检通知">                         
                        </asp:ListItem>
                        <asp:ListItem Value="单位体检通知" Text="单位体检通知">                         
                        </asp:ListItem>
                        <asp:ListItem Value="定期通知" Text="定期通知"> 
                        </asp:ListItem>
                         <asp:ListItem Value="其他" Text="其他"> 
                        </asp:ListItem>
                    </asp:DropDownList>

                    <asp:Button ID="Button2" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
                    <a href="javascript:;" onclick="$(':checkbox').attr('checked','checked');" id="all">
                        全部选择</a> <a href="javascript:;" onclick="$(':checkbox').removeAttr('checked');" id="delAll">
                            取消选择</a>
                    <asp:Repeater ID="CompanyRepeater" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        选 择
                                    </th>
                                    <th>
                                        类型
                                    </th>
                                    <th>
                                        接收人
                                    </th>
                                    <th>
                                        单位
                                    </th>
                                    <th>
                                        手机
                                    </th>
                                    <th>
                                        内容
                                    </th>
                                    <th>
                                        时间
                                    </th>
                                    <th>
                                        状态
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:CheckBox ID="checkbox1" runat="server" />
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblCompanyID" Text='<%# Eval("id") %>' Visible="false" />
                                    <%# Eval("type") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("rcvMan")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("unit")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("rcvTel")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("content")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("sendTime")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("status")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <asp:CheckBox ID="checkbox1" runat="server" />
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblCompanyID" Text='<%# Eval("id") %>' Visible="false" />
                                    <%# Eval("type") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("rcvMan")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("unit")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("rcvTel")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("content")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("sendTime")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("status")%>
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
