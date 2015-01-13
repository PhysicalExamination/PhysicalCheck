<%@ page language="C#" masterpagefile="~/MasterPage/ContentDetailMasterPage.master" autoeventwireup="true" inherits="SysConfig_PackageDialog, App_Web_x5zn4di3" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function onSelected(packageID, packageName, price) {
            var returnValues = Array(4);
            returnValues[0] = packageID;
            returnValues[1] = packageName;
            returnValues[2] = price;
            returnValues[3] = $("#<%=hGroups.ClientID%>").val();
            window.returnValue = returnValues;
            window.close();
        }        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    类别<asp:DropDownList ID="drpCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpCategory_SelectedIndexChanged">
        <asp:ListItem Value="0">套餐</asp:ListItem>
        <asp:ListItem Value="1">组合项</asp:ListItem>
    </asp:DropDownList>
    名称<asp:TextBox ID="txtName" runat="server" CssClass="textbox31" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索"  OnClick="btnSearch_Click"/>
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="PackageRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>
                                套餐名称
                            </th>
                            <th>
                                套餐价格（元）
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
                            <%# Eval("PackageName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetCurrencyString(Eval("Price"))%>
                        </td>
                        <td class="VLine" align="center">
                            <input type="button" class="buttonCss" value="选择" onclick="onSelected(<%# Eval("PackageID")%>, '<%# Eval("PackageName") %>',<%#Eval("Price")%>)" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <%# Container.ItemIndex + 1 %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("PackageName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetCurrencyString(Eval("Price"))%>
                        </td>
                        <td class="VLine" align="center">
                            <input type="button" class="buttonCss" value="选择" onclick="onSelected(<%# Eval("PackageID")%>, '<%# Eval("PackageName") %>',<%#Eval("Price")%>)" />
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
            <asp:AsyncPostBackTrigger ControlID="drpCategory" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UP2" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="ItemGroupRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                选择
                            </th>
                            <th>
                                组合项目
                            </th>
                            <th>
                                单价（元）
                            </th>                            
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <asp:CheckBox ID="chkSelected" runat="server" />
                        </td>
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />
                            <%# Eval("GroupName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%#EnvShowFormater.GetCurrencyString( Eval("Price"))%>
                        </td>                       
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <asp:CheckBox ID="chkSelected" runat="server" />
                        </td>
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />
                            <%# Eval("GroupName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetCurrencyString(Eval("Price"))%>
                        </td>                       
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:AspNetPager ID="Pager1" runat="server" PageAlign="center" PageIndexBox="DropDownList"
                OnPageChanged="Pager_PageChanged" ButtonImageNameExtension="enable/" CustomInfoTextAlign="Center"
                DisabledButtonImageNameExtension="disable/" HorizontalAlign="Center" ImagePath="~/images/"
                MoreButtonType="Text" NavigationButtonType="Image" NumericButtonType="Text" PagingButtonType="Image"
                AlwaysShow="True" PagingButtonSpacing="8px" NumericButtonCount="5" EnableTheming="True"
                PageSize="15">
            </asp:AspNetPager>
            <asp:Panel runat="server" ID="Panel">
                <p align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存" OnClick="btnSave_Click" />
                <input type="button" class="buttonCss" value="返回" onclick="onSelected(-1,'自定义套餐',0)" /></p>
                <strong><font color="red">注意：</font></strong>翻页或返回前请单击【保存】按钮保存当前结果。
            </asp:Panel>
             <asp:HiddenField ID="hGroups" runat="server" />
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="drpCategory" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
   
</asp:Content>
