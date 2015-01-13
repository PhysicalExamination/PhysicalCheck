<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="SysConfig_PackagePage, App_Web_dez24fga" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

        function onSetItemGroup() {
            var PackageID = parseInt($("#<%=hValue.ClientID %>").val(), 10);           
            if ((PackageID < 0) || isNaN(PackageID)) {
                alert("请您先保存当前套餐，然后设置套餐组合项目。");
                return;
            }
            var sURL = "ItemGroupDialog.aspx?PackageID=" + PackageID + "&rand=" + Math.random();
            var sFeatures = "dialogWidth:800px;dialogHeight:600px;center:yes;help:no;status:no;rsizable:yes";
            var sResult = window.showModalDialog(sURL, null, sFeatures);          
            var price = parseFloat(sResult);           
            if ((sResult != null || sResult != undefined) && (price > 0)) {               
                $("#<%=txtPrice.ClientID %>").val(price);
            }
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">浏览</a></li>
            <li><a href="#tabs-2">编辑</a></li>
            <li><a href="#tabs-3">组合项目明细</a></li>
        </ul>
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="PackageRepeater" runat="server" OnItemCommand="PackageItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        套餐名称
                                    </th>
                                    <th>
                                        价格（元）
                                    </th>
                                    <th>
                                        类别
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblPackageID" Text='<%# Eval("PackageID") %>' Visible="false" />
                                    <%# Eval("PackageName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetCurrencyString(Eval("Price"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetCategory(Eval("Category"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnSelect" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblPackageID" Text='<%# Eval("PackageID") %>' Visible="false" />
                                    <%# Eval("PackageName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetCurrencyString(Eval("Price"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetCategory(Eval("Category"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnSelect" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
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
                                套餐名称
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="inputCss" ID="txtPackageName" runat="server" />
                            </td>
                            <td class="HVLine">
                                价格（元）
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="inputCss" ID="txtPrice" runat="server" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                类 别
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:DropDownList ID="drpCategorys" runat="server">
                                    <asp:ListItem Value="0">不分性别套餐</asp:ListItem>
                                    <asp:ListItem Value="1">男士套餐</asp:ListItem>
                                    <asp:ListItem Value="2">女士套餐</asp:ListItem>
                                    <asp:ListItem Value="3">儿童套餐</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewPackage_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditPackage_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeletePackage_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSavePackage_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelPackage_Click" />
                                <input type="button" id="btnSetGroup" value="设置组合项" class="buttonCss" onclick="onSetItemGroup();" />
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hValue" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-3">
            <asp:UpdatePanel ID="UP3" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="ItemGroupRepeater" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        组合项目
                                    </th>
                                    <th>
                                        单价（元）
                                    </th>
                                    <th>
                                        适用性别
                                    </th>
                                    <th>
                                        临床意义
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <%# Eval("GroupName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Price")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetSex(Eval("Sex"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Clinical")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <%# Eval("GroupName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Price")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# GetSex(Eval("Sex"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Clinical")%>
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
