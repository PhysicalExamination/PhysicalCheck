<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Examination_ReviewPage, App_Web_lbndgfpo" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    复检日期<asp:TextBox CssClass="textbox31  Wdate" ID="txtStartDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
    至<asp:TextBox CssClass="textbox31  Wdate" ID="txtEndDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
   
   <div class="blank5"></div>
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="ReviewRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                登记号
                            </th>
                            <th>
                                姓名
                            </th>
                            <th>
                                联系电话
                            </th>
                            <th>
                                手机号码
                            </th>
                            <th>
                                通知情况
                            </th>
                            <th>
                                复查概要
                            </th>
                            <th>
                                预定复检日期
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblRegisterNo" Text='<%# Eval("RegisterNo") %>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("LinkTel")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Mobile")%>
                        </td>
                        <td class="VLine" align="center">
                            <asp:DropDownList ID="drpInformResult" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="0">未留联系方式</asp:ListItem>
                                <asp:ListItem Value="1">未联系到</asp:ListItem>
                                <asp:ListItem Value="2">已通知</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("ReviewSummary")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("ReviewDate"))%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblRegisterNo" Text='<%# Eval("RegisterNo") %>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("LinkTel")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Mobile")%>
                        </td>
                        <td class="VLine" align="center">
                            <asp:DropDownList ID="drpInformResult" runat="server">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="0">未留联系方式</asp:ListItem>
                                <asp:ListItem Value="1">未联系到</asp:ListItem>
                                <asp:ListItem Value="2">已通知</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("ReviewSummary")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("ReviewDate"))%>
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
            <asp:AsyncPostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
    <p align="center">
     <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存" OnClick="btnSave_Click"/></p>
</asp:Content>
