<%@ page language="C#" masterpagefile="~/MasterPage/ContentDetailMasterPage.master" autoeventwireup="true" inherits="Admin_DepartmentDialog, App_Web_rgng05qa" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function onSelected(PersonID, Name) {
            var returnValues = Array(2);
            returnValues[0] = PersonID;
            returnValues[1] = Name;
            window.returnValue = returnValues;
            window.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server"
    ClientIDMode="Static">
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            名称：
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
            <asp:Repeater ID="rptMain" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>
                                名称
                            </th>
                            <th>
                                性别
                            </th>
                            <th>
                                出生日期
                            </th>
                            <th>
                                电话
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <%# Container.ItemIndex + 1 %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("sex")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Birthday")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("  Mobile")%>
                        </td>
                        <td class="VLine" align="center">
                            <input type="button" class="buttonCss" value="选择" onclick="onSelected(<%# Eval("PersonID")%>, '<%# Eval("Name") %>')" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <%# Container.ItemIndex + 1 %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("sex")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Birthday")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Mobile")%>
                        </td>
                        <td class="VLine" align="center">
                            <input type="button" class="buttonCss" value="选择" onclick="onSelected(<%# Eval("PersonID")%>, '<%# Eval("Name") %>')" />
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
</asp:Content>
