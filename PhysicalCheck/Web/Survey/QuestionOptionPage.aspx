<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentDetailMasterPage.master" AutoEventWireup="true" CodeFile="QuestionOptionPage.aspx.cs" Inherits="Survey_QuestionOptionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="Repeater" runat="server" OnItemCommand="ItemCommand">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>序号</th>
                            <th>选项标题</th>
                            <th>选项值</th>
                            <th>操作</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <%# Eval("SN") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("OptionTitle") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("OptionValue") %>
                        </td>
                        <td class="VLine" align="center">
                            <asp:Button ID="btnDetail" runat="server" Text="查看" CommandArgument='<%# Eval("SN") %>'
                                CommandName="Select" CssClass="buttonCss" OnClientClick="onSelected(1)" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <%# Eval("SN") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("OptionTitle") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("OptionValue") %>
                        </td>
                        <td class="VLine" align="center">
                            <asp:Button ID="btnDetail1" runat="server" Text="查看" CommandArgument='<%# Eval("SN") %>'
                                CommandName="Select" CssClass="buttonCss" OnClientClick="onSelected(1)" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
    <p>
    </p>
    <asp:UpdatePanel ID="UP2" runat="Server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="HVLine">选项标题</td>
                    <td class="HVLine">
                        <asp:TextBox CssClass="inputCss" ID="txtOptionTitle" runat="server" /></td>
                    <td class="HVLine">选项值</td>
                    <td class="HVLine">
                        <asp:TextBox CssClass="inputCss" ID="txtOptionValue" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="4" align="center" class="VLine">
                        <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNew_Click" />
                        <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEdit_Click" />
                        <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"
                            OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                        <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                        <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

