<%@ page language="C#" masterpagefile="~/MasterPage/ContentDetailMasterPage.master" autoeventwireup="true" inherits="Examination_ChargeDialog, App_Web_lbndgfpo" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function onSelected(BillNo, PackageID, PackageName, ChargeDeptID, Payer) {
            var returnValues = Array(5);
            returnValues[0] = BillNo;
            returnValues[1] = PackageID;
            returnValues[2] = PackageName;
            returnValues[3] = ChargeDeptID;
            returnValues[4] = Payer;
            window.returnValue = returnValues;
            window.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    缴费人/单位<asp:TextBox ID="txtSearchKey" runat="server" CssClass="textbox31" />
    <asp:Button ID="btnSearch" runat="server" Text="检索" CssClass="buttonCss" OnClick="btnSearch_Click" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="ChargeRepeater" runat="server">
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
                                体检人数
                            </th>
                            <th>
                                体检套餐
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <%# Eval("BillNo") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Payer") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("CheckNum")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("PackageName")%>
                        </td>
                        <td class="VLine" align="center">
                            <input type="button" class="buttonCss" value="选择" onclick="onSelected('<%# Eval("BillNo")%>', <%# Eval("PackageID") %>,'<%#Eval("PackageName")%>',<%#Eval("ChargeDeptID")%>,'<%#Eval("Payer")%>')" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <%# Eval("BillNo") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Payer") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("CheckNum")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("PackageName")%>
                        </td>
                        <td class="VLine" align="center">
                            <input type="button" class="buttonCss" value="选择" onclick="onSelected('<%# Eval("BillNo")%>', <%# Eval("PackageID") %>,'<%#Eval("PackageName")%>',<%#Eval("ChargeDeptID")%>,'<%#Eval("Payer")%>')" />
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
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
