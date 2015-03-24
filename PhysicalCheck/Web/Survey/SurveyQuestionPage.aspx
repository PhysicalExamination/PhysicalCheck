<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true" CodeFile="SurveyQuestionPage.aspx.cs" Inherits="Survey_SurveyQuestionPage" %>

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
                    <asp:Repeater ID="QuestionRepeater" runat="server" OnItemCommand="ItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>序号</th>
                                    <th>标题</th>
                                    <th>是否必填</th>
                                    <th>题型</th>
                                    <th>是否多选</th>
                                    <th>描述</th>
                                    <th>操作</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Title") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Required") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("QType") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Multipe") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Description") %>
                                </td>

                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss" OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <%# Container.ItemIndex + 1%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Title") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Required") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("QType") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Multipe") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Description") %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail1" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss" OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="VLine">标题</td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtTitle" runat="server" /></td>
                            <td class="VLine">题型</td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpQTypes" runat="server">
                                    <asp:ListItem Value="1">填空题</asp:ListItem>
                                    <asp:ListItem Value="2">单选题</asp:ListItem>
                                    <asp:ListItem Value="3">多选题</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">是否必填</td>
                            <td class="VLine">
                                <asp:CheckBox ID="chkRequired" runat="server" />
                            </td>
                            <td class="VLine">是否多选</td>
                            <td class="VLine">
                                <asp:CheckBox ID="chkMultipe" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="VLine">正常下限</td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtNormalLower" runat="server" /></td>
                            <td class="VLine">正常上限</td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtNormalUpper" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="VLine">有效下限</td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtValidLower" runat="server" /></td>
                            <td class="VLine">有效上限</td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtValidUpper" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="VLine">单位</td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="inputCss" ID="txtUnit" runat="server" /></td>
                        </tr>
                        <tr>
                            <td class="VLine">描述</td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="inputCss" TextMode="MultiLine" Width="99%" Height="80px" ID="txtDescription" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewSurveyQuestion_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditSurveyQuestion_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteSurveyQuestion_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveSurveyQuestion_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelSurveyQuestion_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

