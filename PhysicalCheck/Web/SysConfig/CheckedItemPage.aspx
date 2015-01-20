<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="CheckedItemPage.aspx.cs" Inherits="SysConfig_CheckedItemPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $("#<%=Form.ClientID%>").validationEngine({ promptPosition: "topLeft", scroll: false, focusFirstField: true });
        });

        function checkForm() {
            return $("#<%=Form.ClientID%>").validationEngine("validate");
        }

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

        function selectDept() {
            var sURL = "<%=ApplicationPath%>/Admin/DepartmentDialog.aspx?rand=" + Math.random();
            var urlValue = window.showModalDialog(sURL, '', "center:yes;help:no;status:no;rsizable:yes");
            //var urlValue = window.showModalDialog(sURL, null, "dialogHeight=" + height + "px;dialogWidth=" + width + "px");
            if (urlValue != null || urlValue != undefined) {
                $("#<%=txtDeptID.ClientID %>").val(urlValue[0]);
                $("#<%=txtDeptName.ClientID %>").val(urlValue[1]);
            }
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div class="blank5">
    </div>
    检查科室<asp:DropDownList ID="drpDepts" runat="server" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <div class="blank5">
    </div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">浏览</a></li>
            <li><a href="#tabs-2">编辑</a></li>
        </ul>
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="CheckedItemRepeater" runat="server" OnItemCommand="CheckedItemItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        项目名称
                                    </th>
                                    <th>
                                        计量单位
                                    </th>
                                    <th>
                                        参考下限
                                    </th>
                                    <th>
                                        参考上限
                                    </th>
                                    <th>
                                        正常提示
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("ItemID") %>' Visible="false" />
                                    <%# Eval("ItemName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("MeasureUnit") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("LowerLimit") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("UpperLimit") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("NormalTips") %>
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
                                    <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("ItemID") %>' Visible="false" />
                                    <%# Eval("ItemName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("MeasureUnit") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("LowerLimit") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("UpperLimit") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("NormalTips") %>
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
                                项目名称<font color="red">*</font>
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtItemName" runat="server" data-errormessage-value-missing="项目名称不能为空!" />
                            </td>
                            <td class="HVLine">
                                检查科室<font color="red">*</font>
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtDeptName" runat="server" ReadOnly="true" data-errormessage-value-missing="检查科室不能为空!"/>
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择检查科室"
                                    onclick="selectDept();" align="middle" border="0" />
                                <div style="display: none">
                                    <asp:TextBox ID="txtDeptID" runat="server" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                计量单位
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtMeasureUnit" runat="server" />
                            </td>
                            <td class="VLine">
                                适用性别
                            </td>
                            <td class="VLine">
                               <asp:DropDownList ID="drpSex" runat="server">
                                    <asp:ListItem Value="%">不限性别</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                参考下限
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtLowerLimit" runat="server" />
                            </td>
                            <td class="VLine">
                                参考上限
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtUpperLimit" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                正常提示
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtNormalTips" runat="server" />
                            </td>
                            <td class="VLine">
                                偏低提示
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtLowerTips" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                偏高提示
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtUpperTips" runat="server" />
                            </td>
                            <td class="VLine">
                                是否入小结
                            </td>
                            <td class="VLine">
                                <asp:CheckBox ID="chkIsSummary" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewCheckedItem_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditCheckedItem_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteCheckedItem_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveCheckedItem_Click" 
                                    OnClientClick="return checkForm();"/>
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelCheckedItem_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
