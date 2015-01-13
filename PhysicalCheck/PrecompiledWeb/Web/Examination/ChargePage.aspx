<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Examination_ChargePage, App_Web_2avxo4hp" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

        function selectDept() {
            var sURL = "<%=ApplicationPath%>/Examination/DepartmentDialog.aspx?DeptID=-1&rand=" + Math.random();
            var sFeatures = "center:yes;help:no;status:no;rsizable:yes";
            var vArguments = "";
            var urlValue = window.showModalDialog(sURL, vArguments, sFeatures);

            if (urlValue != null || urlValue != undefined) {
                $("#<%=hDeptID.ClientID %>").val(urlValue[0]);
                $("#<%=txtPayer.ClientID %>").val(urlValue[1]);
            }
        }

        function selectPackage() {
            var sURL = "<%=ApplicationPath%>/SysConfig/PackageDialog.aspx?rand=" + Math.random();
            var urlValue = window.showModalDialog(sURL, '', "center:yes;help:no;status:no;rsizable:yes");
//            console.log(urlValue);
            //var urlValue = window.showModalDialog(sURL, null, "dialogHeight=" + height + "px;dialogWidth=" + width + "px");
            if (urlValue != null || urlValue != undefined) {
                $("#<%=hPackageID.ClientID %>").val(urlValue[0]);
                $("#<%=txtPackageName.ClientID %>").val(urlValue[1]);
                $("#hPackagePrice").val(urlValue[2]);
                CalcCharge();
            }
        }

        function CalcCharge() {
            var price = parseFloat($("#hPackagePrice").val());
            var count = parseInt($("#<%=txtCheckNum.ClientID %>").val());
//            console.log($("#<%=txtCheckNum.ClientID %>").val());
//            console.log("price=" + price + "Count=" + count);
            var Charge = price * count;
            $("#<%=txtCharge.ClientID %>").val(Charge);
            $("#<%=txtActualCharge.ClientID %>").val(Charge);
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
                    缴费人<asp:TextBox ID="txtPaymentMan" runat="server" CssClass="textbox31" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
                    <div class="blank5"></div>
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
                                        应收费用（元）
                                    </th>
                                    <th>
                                        实收费用（元）
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
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                缴费人
                            </td>
                            <td class="HVLine" colspan="3">
                                <asp:TextBox CssClass="textbox31" ID="txtPayer" runat="server" Width="90%" />
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择体检单位"
                                    onclick="selectDept();" align="middle" border="0" />
                                <asp:HiddenField ID="hDeptID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                体检套餐
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtPackageName" runat="server" ReadOnly="true" />
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择检查科室"
                                    onclick="selectPackage();" align="middle" border="0" align="middle" />
                                <asp:HiddenField ID="hPackageID" runat="server" />
                            </td>
                            <td class="VLine">
                                体检人数
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtCheckNum" runat="server" onchange="javascript:CalcCharge();" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                应收费用（元）
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtCharge" runat="server" Enabled="false" />
                            </td>
                            <td class="VLine">
                                实收费用（元）
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtActualCharge" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                缴费方式
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpPaymentMethod" runat="server">
                                    <asp:ListItem Value="1">现金</asp:ListItem>
                                    <asp:ListItem Value="2">暂时不收</asp:ListItem>
                                    <asp:ListItem Value="3">免费</asp:ListItem>
                                    <asp:ListItem Value="4">转账</asp:ListItem>
                                    <asp:ListItem Value="5">信汇</asp:ListItem>
                                    <asp:ListItem Value="6">托收</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                缴费时间
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31 Wdate" ID="txtPaymentDate" runat="server" onfocus="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')"
                                    ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                收费人
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtChargePerson" runat="server" Enabled="false" />
                            </td>
                            <td class="VLine">
                            </td>
                            <td class="VLine">
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
    <input type="hidden" value="0" id="hPackagePrice" />
</asp:Content>
