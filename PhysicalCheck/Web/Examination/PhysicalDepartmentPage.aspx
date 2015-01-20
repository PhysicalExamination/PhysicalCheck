<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="PhysicalDepartmentPage.aspx.cs" Inherits="Examination_PhysicalDepartmentPage" %>

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
            体检单位<asp:TextBox ID="txtSearch" CssClass="textbox31" runat="server" />
            <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="PhysicalDepartmentRepeater" runat="server" OnItemCommand="PhysicalDepartmentItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        单位名称
                                    </th>
                                    <th>
                                        单位负责人
                                    </th>
                                    <th>
                                        联系电话
                                    </th>
                                    <th>
                                        传真
                                    </th>
                                    <th>
                                        通讯地址
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblDeptID" Text='<%# Eval("DeptID") %>' Visible="false" />
                                    <%# Eval("DeptName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Leader") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("LinkTel") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Fax") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Address") %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblDeptID" Text='<%# Eval("DeptID") %>' Visible="false" />
                                    <%# Eval("DeptName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Leader") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("LinkTel") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Fax") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Address") %>
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
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                体检单位<font color="red">*</font>
                            </td>
                            <td class="HVLine" colspan="3">
                                <asp:TextBox CssClass="validate[required] textbox51" ID="txtDeptName" runat="server" Width="99%" data-errormessage-value-missing="体检单位不能为空!"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                联系人<font color="red">*</font>
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtLeader" runat="server" data-errormessage-value-missing="联系人不能为空!"/>
                            </td>
                            <td class="VLine">
                                联系电话<font color="red">*</font>
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtLinkTel" runat="server" data-errormessage-value-missing="联系电话不能为空!"/>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                传 真
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtFax" runat="server" />
                            </td>
                            <td class="VLine">
                                邮政编码
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtPostCode" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                通讯地址
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox51" ID="txtAddress" runat="server" Width="99%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                开户行
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtBank" runat="server" />
                            </td>
                            <td class="VLine">
                                银行账号
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtBankAccount" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                企业性质
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:DropDownList ID="drpNature" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                备 注
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="inputCss" TextMode="MultiLine" Width="99%" Height="80px" ID="txtComment"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewPhysicalDepartment_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditPhysicalDepartment_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeletePhysicalDepartment_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSavePhysicalDepartment_Click" 
                                    OnClientClick="return checkForm();"/>
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelPhysicalDepartment_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
