<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="ChargePage.aspx.cs" Inherits="Examination_ChargePage" %>

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
                    <asp:Repeater ID="ChargeRepeater" runat="server" OnItemCommand="ChargeItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        缴费单号
                                    </th>
                                    <th>
                                        缴费人
                                    </th>
                                    <th>
                                        应收费用
                                    </th>
                                    <th>
                                        实收费用
                                    </th>
                                    <th>
                                        缴费时间
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblBillNo" Text='<%# Eval("BillNo") %>' />
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Payer") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetNumberString(Eval("Charge")) %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetNumberString(Eval("ActualCharge")) %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetShortDate(Eval("PaymentDate")) %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblBillNo" Text='<%# Eval("BillNo") %>' />
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Payer") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetNumberString(Eval("Charge")) %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetNumberString(Eval("ActualCharge")) %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetShortDate(Eval("PaymentDate")) %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail1" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
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
                            <td class="VLine">
                                缴费人
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="inputCss" ID="txtPayer" runat="server" Width="99%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                体检套餐
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtPackageID" runat="server" />
                            </td>
                            <td class="VLine">
                                体检人数
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtCheckNum" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                应收费用
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtCharge" runat="server" Enabled="false" />
                            </td>
                            <td class="VLine">
                                实收费用
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtActualCharge" runat="server" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                缴费方式
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtPaymentMethod" runat="server" />
                            </td>
                            <td class="VLine">
                                缴费时间
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtPaymentDate" runat="server" 
                                    onfocus="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                收费人
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtChargePerson" runat="server"  Enabled="false"/>
                            </td>                            
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewCharge_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditCharge_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteCharge_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveCharge_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelCharge_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
