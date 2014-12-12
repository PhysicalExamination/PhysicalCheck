﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentDetailMasterPage.master"
    AutoEventWireup="true" CodeFile="PackageDialog.aspx.cs" Inherits="SysConfig_PackageDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
           
        function onSelected(packageID,packageName) {          
            var returnValues = Array(2);
            returnValues[0] = packageID;
            returnValues[1] = packageName;
            window.returnValue = returnValues;
            window.close();
        }

    </script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
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
                            <input type="button" class="buttonCss" value="选择"onclick="onSelected(<%# Eval("PackageID")%>, '<%# Eval("PackageName") %>')" />
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
                            <input type="button" class="buttonCss" value="选择" onclick="onSelected(<%# Eval("PackageID")%>, '<%# Eval("PackageName") %>')" />
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