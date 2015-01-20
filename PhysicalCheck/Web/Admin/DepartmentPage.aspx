<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="DepartmentPage.aspx.cs" Inherits="Admin_DepartmentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $("#<%=Form.ClientID%>").validationEngine({ promptPosition: "topLeft", scroll: false, focusFirstField: true });
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

        function checkForm() {
            return $("#<%=Form.ClientID%>").validationEngine("validate");
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
                    <asp:Repeater ID="DepartmentRepeater" runat="server" OnItemCommand="UserItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        序号
                                    </th>
                                    <th>
                                        科室名称
                                    </th>
                                    <th>
                                        科室类别
                                    </th>
                                    <th>
                                        科室位置
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
                                    <%# Eval("DeptName") %>
                                    <asp:Literal runat="server" ID="lblDeptNo" Text='<%# Eval("DeptID") %>' Visible="false" />
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetDeptCategory(Eval("DeptKind"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("DepLlocation")%>
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
                                    <%# Eval("DeptName") %>
                                    <asp:Literal runat="server" ID="lblDeptNo" Text='<%# Eval("DeptID") %>' Visible="false" />
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetDeptCategory(Eval("DeptKind"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("DepLlocation")%>
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
                        PageSize="15">
                    </asp:AspNetPager>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                科室名称<font color="red">*</font>
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtDeptName" runat="server" />
                            </td>
                             <td class="HVLine">
                                科室类别
                            </td>
                            <td class="HVLine" >
                            <asp:DropDownList ID="drpDeptKind" runat="server">
                            <asp:ListItem Value="0">检查科室</asp:ListItem>
                            <asp:ListItem Value="1">检验科室</asp:ListItem>
                            <asp:ListItem Value="2">功能科室</asp:ListItem>
                            </asp:DropDownList>
                                
                            </td>
                        </tr>                       
                        <tr>
                            <td class="VLine">
                                科室位置
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox41" ID="txtDepLlocation" runat="server" Width="99%" />
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
