<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="SysUserPage.aspx.cs" Inherits="Admin_SysUserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function() {
            $("#tabs").tabs();
           $("#<%=Form.ClientID%>").validationEngine({ promptPosition: "topLeft", scroll: false, focusFirstField: true });
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

        function checkForm() {
            return $("#<%=Form.ClientID%>").validationEngine("validate");
        }
        
        function CheckUserAccount() {
            var argument = $("#<%=txtUserAccount.ClientID %>").val();           
            <%=ClientCallback %>; 
        }
        
        function processCallback(result,context){ 
            if (result != "") {
               alert("用户已经存在！");
               return;
            }            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">浏览</a></li>
            <li><a href="#tabs-2">编辑</a></li>
        </ul>
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="UserRepeater" runat="server" OnItemCommand="UserItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        序号
                                    </th>
                                    <th>
                                        用户名
                                    </th>
                                    <th>
                                        登录账号
                                    </th>
                                    <th>
                                        职务
                                    </th>
                                    <th>
                                        联系电话
                                    </th>
                                    <th>
                                        手机
                                    </th>
                                    <th>
                                        所在部门
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <%# Container.ItemIndex + 1 %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("UserName") %>
                                    <asp:Literal runat="server" ID="lblUserNo" Text='<%# Eval("UserNo") %>' Visible="false" />
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("UserAccount")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Position") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("LinkTel") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Mobile") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("DeptName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <%# Container.ItemIndex + 1 %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("UserName") %>
                                    <asp:Literal runat="server" ID="lblUserNo" Text='<%# Eval("UserNo") %>' Visible="false" />
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("UserAccount")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Position") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("LinkTel") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Mobile") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("DeptName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail1" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
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
                        PageSize="20">
                    </asp:AspNetPager>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:AspNetPager ID="AspNetPager1" runat="server">
            </asp:AspNetPager>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                用户名<font color="red">*</font>
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="validate[required] inputCss" ID="txtUserName" runat="server" data-errormessage-value-missing="用户名不能为空!"/>
                            </td>
                            <td class="HVLine">
                                登录账号<font color="red">*</font>
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="validate[required] inputCss" ID="txtUserAccount" runat="server" data-errormessage-value-missing="登录账号不能为空!"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                职务
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtPosition" runat="server" />
                            </td>
                            <td class="VLine">
                                联系电话
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtLinkTel" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                手机
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtMobile" runat="server" />
                            </td>
                            <td class="VLine">
                                所在部门<font color="red">*</font>
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpDeparts" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                用户类别
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpUserCategory" runat="server">
                                    <asp:ListItem Value="1" Selected="True">普通用户</asp:ListItem>
                                    <asp:ListItem Value="0">管理员</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                密码
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" TextMode="Password" ID="txtPassWord" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                电子邮件
                            </td>
                            <td class="VLine" colspan="3">
                                 <asp:TextBox CssClass="inputCss"  ID="txtEmail" runat="server" Width="99%" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewUser_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditUser_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteUser_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveUser_Click" 
                                    OnClientClick="return checkForm();"/>
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelUser_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
