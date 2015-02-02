<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="ItemGroupPage.aspx.cs" Inherits="SysConfig_ItemGroupPage" %>

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

        function selectDept() {
            var sURL = "<%=ApplicationPath%>/Admin/DepartmentDialog.aspx?rand=" + Math.random();
            var urlValue = window.showModalDialog(sURL, '', "center:yes;help:no;status:no;rsizable:yes");
            if (urlValue != null || urlValue != undefined) {
                $("#<%=hDeptID.ClientID %>").val(urlValue[0]);
                $("#<%=txtDeptName.ClientID %>").val(urlValue[1]);
            }
        }

        function onSetCheckedItem() {
            var GroupID = parseInt($("#<%=hValue.ClientID %>").val(), 10);
            if ((GroupID < 0) || isNaN(GroupID)) {
                alert("请您先保存当前组合项目，然后设置组合项目检查明细项。");
                return;
            }
            var sURL = "CheckedItemDialog.aspx?GroupID=" + GroupID + "&rand=" + Math.random();
            var sFeatures = "dialogWidth:800px;dialogHeight:600px;center:yes;help:no;status:no;rsizable:yes";
            window.showModalDialog(sURL, null, sFeatures);
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">浏览</a></li>
            <li><a href="#tabs-2">编辑</a></li>
            <li><a href="#tabs-3">项目明细</a></li>
        </ul>
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="ItemGroupRepeater" runat="server" OnItemCommand="ItemGroupItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        组合名称
                                    </th>
                                    <th>
                                        检查科室
                                    </th>
                                    <th>
                                        检查类别
                                    </th>
                                    <th>
                                        适用性别
                                    </th>
                                    <th>
                                        单价
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />
                                    <%# Eval("GroupName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("DeptName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetCategory(Eval("CheckCategory"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%#GetSex(Eval("Sex")) %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetNumberString(Eval("Price")) %>
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
                                    <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />
                                    <%# Eval("GroupName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("DeptName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetCategory(Eval("CheckCategory"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%#GetSex(Eval("Sex")) %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetNumberString(Eval("Price")) %>
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
                                组合名称<font color="red">*</font>
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtGroupName" runat="server"
                                    data-errormessage-value-missing="组合项名称不能为空!" />
                            </td>
                            <td class="HVLine">
                                检查科室<font color="red">*</font>
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtDeptName" runat="server"
                                    ReadOnly="true" data-errormessage-value-missing="检查科室不能为空!" />
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择检查科室"
                                    onclick="selectDept();" align="middle" border="0" />
                                <asp:HiddenField ID="hDeptID" runat="server" />
                                <%--<div style="display: none">
                                    <asp:TextBox ID="txtDeptID" runat="server" /></div>--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                检查类别
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpCheckCategory" runat="server">
                                    <asp:ListItem Value="0">检验项目</asp:ListItem>
                                    <asp:ListItem Value="1">医生检查</asp:ListItem>
                                    <asp:ListItem Value="2">功能检查</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                适用性别
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpSex" runat="server">
                                    <asp:ListItem Value="%">不限</asp:ListItem>
                                    <asp:ListItem Value="0">女</asp:ListItem>
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                单价<font color="red">*</font>
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtPrice" runat="server"
                                    data-errormessage-value-missing="组合项单价不能为空!" />
                            </td>
                            <td class="VLine">
                                正常描述
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtNormalDesc" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                提示信息
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="inputCss" ID="txtNotice" runat="server" Width="99%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                临床意义
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="inputCss" TextMode="MultiLine" Height="80px" Width="99%" ID="txtClinical"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                是否需要标本
                            </td>
                            <td class="VLine">
                                <asp:CheckBox ID="chkHasSpecimen" runat="server" />
                            </td>
                            <td class="VLine">
                                标本类型
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpSpecimen" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                结果获取方式
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpResultMode" runat="server">
                                    <asp:ListItem Value="0">手动录入</asp:ListItem>
                                    <asp:ListItem Value="1">自动获取</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                是否需要条码
                            </td>
                            <td class="VLine">
                                <asp:CheckBox ID="chkHasBarCode" runat="server" />
                            </td>
                        </tr>

                        <tr>
                            <td class="VLine">
                                LISCode
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtLisCode" runat="server" />
                            </td>
                            <td class="VLine">
                                PacsCode
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox41" ID="txtPacsCode" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewItemGroup_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditItemGroup_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteItemGroup_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveItemGroup_Click"
                                    OnClientClick="return checkForm();" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelItemGroup_Click" />
                                <input type="button" class="buttonCss" value="设置项目" onclick="onSetCheckedItem();" />
                                <asp:HiddenField ID="hValue" runat="server" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-3">
            <asp:UpdatePanel ID="UP3" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="CheckedItemRepeater" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        名称
                                    </th>
                                    <th>
                                        单位
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
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
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
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
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
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:AspNetPager ID="Pager1" runat="server" PageAlign="center" PageIndexBox="DropDownList"
                        OnPageChanged="Pager1_PageChanged" ButtonImageNameExtension="enable/" CustomInfoTextAlign="Center"
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
