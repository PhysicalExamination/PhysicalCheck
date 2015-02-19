<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentDetailMasterPage.master"
    AutoEventWireup="true" CodeFile="SelectGroupDialog.aspx.cs" Inherits="Examination_SelectGroupDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function CloseWindow() {
            window.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    组合项名称<asp:TextBox ID="txtName" runat="server" CssClass="textbox31" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存" OnClick="btnSave_Click" />
    <input type="button" class="buttonCss" value="关闭" onclick="CloseWindow()" />
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
                                适用性别
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
                            <asp:Literal runat="server" ID="lblDeptID" Text='<%# Eval("DeptID") %>' Visible="false" />
                            <%# Eval("GroupName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# GetSex(Eval("Sex"))%>
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
                            <asp:Literal runat="server" ID="lblDeptID" Text='<%# Eval("DeptID") %>' Visible="false" />
                            <%# Eval("GroupName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# GetSex(Eval("Sex"))%>
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
            <asp:AspNetPager ID="Pager" runat="server" PageAlign="center" PageIndexBox="DropDownList"
                OnPageChanged="Pager_PageChanged" ButtonImageNameExtension="enable/" CustomInfoTextAlign="Center"
                DisabledButtonImageNameExtension="disable/" HorizontalAlign="Center" ImagePath="~/images/"
                MoreButtonType="Text" NavigationButtonType="Image" NumericButtonType="Text" PagingButtonType="Image"
                AlwaysShow="True" PagingButtonSpacing="8px" NumericButtonCount="5" EnableTheming="True"
                PageSize="15">
            </asp:AspNetPager>
            <p>
            </p>
            <strong><font color="red">注意：</font></strong>翻页或关闭前请单击【保存】按钮保存当前结果。
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
