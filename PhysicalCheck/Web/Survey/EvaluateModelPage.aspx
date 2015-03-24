<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true" CodeFile="EvaluateModelPage.aspx.cs" Inherits="Survey_EvaluateModelPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
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
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="ModelRepeater" runat="server" OnItemCommand="ItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>序号</th>
                                    <th>模型名称</th>
                                    <th>病种</th>
                                    <th>临界值</th>
                                    <th>操作</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("ModelName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Disease") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("CriticalValue") %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CommandArgument='<%# Eval("ModelID") %>' CssClass="buttonCss" OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("ModelName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Disease") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("CriticalValue") %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail1" runat="server" Text="查看" CommandName="Select" CommandArgument='<%# Eval("ModelID") %>' CssClass="buttonCss" OnClientClick="onSelected(1)" />
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
                            <td class="VLine">模型名称</td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtModelName" runat="server" /></td>
                            <td class="VLine">病种</td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtDisease" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="VLine">临界值</td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="inputCss" ID="txtCriticalValue" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewEvaluateModel_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditEvaluateModel_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteEvaluateModel_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveEvaluateModel_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelEvaluateModel_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

