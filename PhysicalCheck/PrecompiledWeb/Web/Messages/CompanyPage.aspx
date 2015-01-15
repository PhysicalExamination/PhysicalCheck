<%@ page title="" language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Examination_CompanyPage, App_Web_cukzgset" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {


        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
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
                    <asp:Label ID="lbltitle" runat="server"></asp:Label>
                    <asp:Repeater ID="CompanyRepeater" runat="server" OnItemCommand="CompanyItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        选 择
                                    </th>
                                    <th>
                                        单位名称
                                    </th>
                                    <th>
                                        行业类别
                                    </th>
                                    <th>
                                        联系电话
                                    </th>
                                    <th>
                                        联系人
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
                                    <asp:Literal runat="server" ID="lblCompanyID" Text='<%# Eval("DeptID") %>' Visible="false" />
                                    <%# Eval("DeptName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Nature")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("LinkTel")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Leader")%>
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
                                    <asp:Literal runat="server" ID="lblCompanyID" Text='<%# Eval("DeptID") %>' Visible="false" />
                                    <%# Eval("DeptName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Nature")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("LinkTel")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Leader")%>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
