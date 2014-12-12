<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentDetailMasterPage.master"
    AutoEventWireup="true" CodeFile="CheckedItemDialog.aspx.cs" Inherits="SysConfig_CheckedItemDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function CloseWindow() {                   
            window.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    检查科室<asp:DropDownList ID="drpDepts" runat="server" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="CheckedItemRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                            </th>
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
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <asp:CheckBox ID="chkSelected" runat="server" />
                        </td>
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
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <asp:CheckBox ID="chkSelected" runat="server" />
                        </td>
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
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
    <p align="center">
        <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存" OnClick="btnSave_Click" />
        <input type="button" class="buttonCss" value="关闭" onclick="CloseWindow();" />
    </p>    
    <strong><font color="red">注意：</font></strong>翻页前请单击【保存】按钮保存当前结果。
</asp:Content>
