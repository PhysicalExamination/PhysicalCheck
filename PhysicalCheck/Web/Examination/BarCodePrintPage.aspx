﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="BarCodePrintPage.aspx.cs" Inherits="Examination_BarCodePrintPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function PrintBarCode(RegisterNo) {
            var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?RegisterNo=" + RegisterNo + "&ReportKind=1";
            window.open(sURL, "_blank", "", true);
        }
        function PrintBarCodes() {
            var RegisterDate = $("#<%=txtSRegisterDate.ClientID %>").val();
            var DeptName = encodeURI($("#<%=txtsDeptName.ClientID %>").val());
            var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?RegisterDate=" + RegisterDate + 
                       "&DeptName=" + DeptName + "&ReportKind=5";
            window.open(sURL, "_blank", "", true);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    登记日期<asp:TextBox CssClass="textbox31  Wdate" ID="txtSRegisterDate" runat="server"
        onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
    体检单位<asp:TextBox CssClass="textbox31" ID="txtsDeptName" runat="server" />
    登记号/身份证号<asp:TextBox CssClass="textbox31" ID="txtsRegisterNo" runat="server" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <input type="button" class="buttonCss" value="批量打印" onclick="PrintBarCodes();" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="RegistrationRepeater" runat="server" OnItemCommand="ItemCommand">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                登记号
                            </th>
                            <th>
                                体检单位
                            </th>
                            <th>
                                姓名
                            </th>
                            <th>
                                年龄
                            </th>
                            <th>
                                登记日期
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblRegisterNo" Text='<%# Eval("RegisterNo") %>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("Age")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("RegisterDate"))%>
                        </td>
                        <td class="VLine" align="center">
                            <input type="button" class="buttonCss" value="打印" onclick="PrintBarCode('<%# Eval("RegisterNo")%>');" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblRegisterNo" Text='<%# Eval("RegisterNo") %>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("Age")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%#EnvShowFormater.GetShortDate(Eval("RegisterDate"))%>
                        </td>
                        <td class="VLine" align="center">
                            <input type="button" class="buttonCss" value="打印" onclick="PrintBarCode('<%# Eval("RegisterNo")%>');" />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:AspNetPager ID="Pager" runat="server" PageAlign="center" PageIndexBox="DropDownList"
                ButtonImageNameExtension="enable/" CustomInfoTextAlign="Center" DisabledButtonImageNameExtension="disable/"
                HorizontalAlign="Center" ImagePath="~/images/" MoreButtonType="Text" NavigationButtonType="Image"
                NumericButtonType="Text" PagingButtonType="Image" AlwaysShow="True" PagingButtonSpacing="8px"
                NumericButtonCount="5" EnableTheming="True" PageSize="15">
            </asp:AspNetPager>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
