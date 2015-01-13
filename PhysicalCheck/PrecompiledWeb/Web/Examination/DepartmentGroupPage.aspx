<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Examination_DepartmentGroupPage, App_Web_2avxo4hp" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }
        function selectPackage() {
            var sURL = "<%=ApplicationPath%>/SysConfig/PackageDialog.aspx?rand=" + Math.random();
            var urlValue = window.showModalDialog(sURL, '', "center:yes;help:no;status:no;rsizable:yes");
            //var urlValue = window.showModalDialog(sURL, null, "dialogHeight=" + height + "px;dialogWidth=" + width + "px");
            if (urlValue != null || urlValue != undefined) {
                $("#<%=hPackageID.ClientID %>").val(urlValue[0]);
                $("#<%=txtPackageName.ClientID %>").val(urlValue[1]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">浏览</a></li>
            <li><a href="#tabs-2">单位分组</a></li>
        </ul>
        <div id="tabs-1">
            体检单位<asp:TextBox ID="txtSearch" CssClass="textbox31" runat="server" />
            <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="DepartmentRepeater" runat="server" OnItemCommand="DepartmentItemCommand">
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
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="GroupRepeater" runat="server" OnItemCommand="GroupItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        分组名称
                                    </th>
                                    <th>
                                        适用性别
                                    </th>
                                    <th>
                                        体检套餐
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("ID.GroupID") %>' Visible="false" />
                                    <%# Eval("GroupName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetSex(Eval("Sex"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("PackageName")%>
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
                                    <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("ID.GroupID") %>' Visible="false" />
                                    <%# Eval("GroupName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetSex(Eval("Sex"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("PackageName")%>
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="blank10">
            </div>
            <asp:UpdatePanel ID="UP3" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                分组名称
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="textbox31" ID="txtGroupName" runat="server" />
                            </td>
                            <td class="HVLine">
                                适用性别
                            </td>
                            <td class="HVLine">
                                <asp:DropDownList ID="drpSex" runat="server">
                                    <asp:ListItem Value="%">不限</asp:ListItem>
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                是否儿童体检
                            </td>
                            <td class="VLine">
                                <asp:CheckBox ID="chkIsChildren" runat="server" />
                            </td>
                            <td class="VLine">
                                套餐
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtPackageName" runat="server" ReadOnly="true" />
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择检查科室"
                                    onclick="selectPackage();" align="middle" border="0" align="middle" />
                                <asp:HiddenField ID="hPackageID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                职称
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtDuty" runat="server" />
                            </td>
                            <td class="VLine">
                                职务
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtPosition" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewGroup_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditGroup_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteGroup_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveGroup_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelGroup_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
