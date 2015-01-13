<%@ page title="" language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Charts_PhysicalDepartmentCharge, App_Web_rgng05qa" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            日期<asp:TextBox CssClass="textbox31  Wdate" ID="txtStartDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
            至<asp:TextBox CssClass="textbox31  Wdate" ID="txtEndDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
            <asp:Button ID="Button2" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
            <asp:Repeater ID="ReportRepeater" runat="server" >
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                单据号码
                            </th>
                            <th>
                                体检单位
                            </th>
                            <%-- <th>
                                体检套餐
                            </th>--%>
                            <th>
                                缴款人
                            </th>
                            <th>
                                体检人数
                            </th>
                            <th>
                                体检费用合计（元）
                            </th>
                            <th>
                                缴费时间
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblBillNo" Text='<%# Eval("BillNo") %>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Payer") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("checknum")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("ActualCharge")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("PaymentDate")) %>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblBillNo" Text='<%# Eval("BillNo") %>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Payer") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("checknum")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("ActualCharge")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("PaymentDate")) %>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                
                </FooterTemplate>
            </asp:Repeater>
            <tr>
                <td class="VLine" align="center">
                    合计：
                </td>
                <td class="VLine" align="center">
                </td>
                <td class="VLine" align="center">
                </td>
                <td class="VLine" align="center">
                    <asp:Literal runat="server" ID="lblchecknum" />
                </td>
                <td class="VLine" align="center">
                    <asp:Literal runat="server" ID="lblActualCharge" />
                </td>
                <td class="VLine" align="center">
                </td>
            </tr>
            </table>
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
