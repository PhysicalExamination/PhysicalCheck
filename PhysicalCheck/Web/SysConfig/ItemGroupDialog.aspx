<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentDetailMasterPage.master"
    AutoEventWireup="true" CodeFile="ItemGroupDialog.aspx.cs" Inherits="SysConfig_ItemGroupDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function CloseWindow() {
            window.returnValue = $("#<%=hValue.ClientID %>").val();           
            window.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UP1" runat="Server">
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
                            <asp:CheckBox ID="chkSelected" runat="server" />
                        </td>
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />
                            <%# Eval("GroupName") %>
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
                    <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <asp:CheckBox ID="chkSelected" runat="server" />
                        </td>
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />
                            <%# Eval("GroupName") %>
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
            <asp:AspNetPager ID="Pager" runat="server" PageAlign="center" PageIndexBox="DropDownList"
                OnPageChanged="Pager_PageChanged" ButtonImageNameExtension="enable/" CustomInfoTextAlign="Center"
                DisabledButtonImageNameExtension="disable/" HorizontalAlign="Center" ImagePath="~/images/"
                MoreButtonType="Text" NavigationButtonType="Image" NumericButtonType="Text" PagingButtonType="Image"
                AlwaysShow="True" PagingButtonSpacing="8px" NumericButtonCount="5" EnableTheming="True"
                PageSize="15">
            </asp:AspNetPager>
            <p align="center">
                <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存" 
                    onclick="btnSave_Click" />
                <input type="button" class="buttonCss" value="关闭" onclick="CloseWindow();" />
            </p>
            <asp:HiddenField ID="hValue" runat="server" Value="0" />
            <strong><font color="red">注意：</font></strong>翻页前请单击【保存】按钮保存当前结果。
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
