<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="CheckResultInputPage.aspx.cs" Inherits="Examination_CheckResultInputPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function onSetSummary() {
            var sURL = "<%=ApplicationPath%>/SysConfig/SuggestionDialog.aspx?rand=" + Math.random();
            var sFeatures = "dialogWidth:800px;dialogHeight:600px;center:yes;help:no;status:no;rsizable:yes";           
            var sResult = window.showModalDialog(sURL, null, sFeatures);
            $("#<%=txtSummary.ClientID %>").val(sResult);           
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    登记号：<asp:TextBox CssClass="textbox31" ID="txtsRegisterNo" runat="server" AutoPostBack="True"
        OnTextChanged="txtsRegisterNo_TextChanged" />
    组合项：<asp:DropDownList ID="drpGroups" runat="server" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="ItemResultRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                检查项目
                            </th>
                            <th>
                                检查结果
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
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <%-- <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />--%>
                            <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("ItemID") %>' Visible="false" />
                            <%# Eval("ItemName")%>
                        </td>
                        <td class="VLine" align="center">
                            <asp:TextBox ID="txtCheckResult" runat="server" CssClass="textbox31" Text='<%# Eval("CheckedResult")%>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("MeasureUnit")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("LowerLimit")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("UpperLimit")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <%-- <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />--%>
                            <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("ItemID") %>' Visible="false" />
                            <%# Eval("ItemName")%>
                        </td>
                        <td class="VLine" align="center">
                            <asp:TextBox ID="txtCheckResult" runat="server" CssClass="textbox31" Text='<%# Eval("CheckedResult")%>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("MeasureUnit")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("LowerLimit")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("UpperLimit")%>
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
            <asp:AsyncPostBackTrigger ControlID="txtsRegisterNo" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UP2" runat="Server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="HVLine">
                        小结
                    </td>
                    <td class="HVLine">
                        <asp:TextBox CssClass="inputCss" TextMode="MultiLine" ID="txtSummary" runat="server"
                            Height="80px" Width="99%" />
                    </td>
                </tr>
                <tr>
                    <td class="VLine" colspan="2" align="center">
                        <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存" />
                        <input type="button" class="buttonCss" value="导入小结"  onclick="onSetSummary();"/>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
