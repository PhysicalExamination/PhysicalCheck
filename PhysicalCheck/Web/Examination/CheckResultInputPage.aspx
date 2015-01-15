<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="CheckResultInputPage.aspx.cs" Inherits="Examination_CheckResultInputPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function onSetSummary() {
            var DeptID = $("#<%=drpDepts.ClientID %>").val();
            var sURL = "<%=ApplicationPath%>/SysConfig/SuggestionDialog.aspx?rand=" + Math.random() + "&DeptID=" + DeptID;
            var sFeatures = "dialogWidth:800px;dialogHeight:600px;center:yes;help:no;status:no;rsizable:yes";
            var sResult = window.showModalDialog(sURL, null, sFeatures);
            $("#<%=txtSummary.ClientID %>").val(sResult);
        }

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
            <li><a href="#tabs-2">结果登记</a></li>
        </ul>
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                   体检日期<asp:TextBox CssClass="textbox31  Wdate" ID="txtCheckedDate" runat="server"
                        onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
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
                                        体检日期
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
                                    <%# EnvShowFormater.GetShortDate(Eval("RegisterDate"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="结果登记" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
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
                                    <%#EnvShowFormater.GetShortDate(Eval("RegisterDate"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="结果登记" CommandName="Select" CssClass="buttonCss"
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
            体检科室：<asp:DropDownList ID="drpDepts" runat="server" AutoPostBack="true" 
                onselectedindexchanged="drpDepts_SelectedIndexChanged" />
            <asp:UpdatePanel ID="UP2" runat="Server">
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
                                     <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("ID.GroupID") %>' Visible="false" />
                                    <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("ID.ItemID") %>' Visible="false" />
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
                                     <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("ID.GroupID") %>' Visible="false" />
                                    <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("ID.ItemID") %>' Visible="false" />
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
                    <asp:AspNetPager ID="Pager1" runat="server" PageAlign="center" PageIndexBox="DropDownList"
                        OnPageChanged="Pager1_PageChanged" ButtonImageNameExtension="enable/" CustomInfoTextAlign="Center"
                        DisabledButtonImageNameExtension="disable/" HorizontalAlign="Center" ImagePath="~/images/"
                        MoreButtonType="Text" NavigationButtonType="Image" NumericButtonType="Text" PagingButtonType="Image"
                        AlwaysShow="True" PagingButtonSpacing="8px" NumericButtonCount="5" EnableTheming="True"
                        PageSize="20">
                    </asp:AspNetPager>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="drpDepts" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UP3" runat="server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                检查是否合格
                            </td>
                            <td class="HVLine">
                                <asp:CheckBox ID="chkIsPassed" runat="server" Checked="false" />
                            </td>
                        </tr>
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
                                <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存" OnClick="btnSave_Click" />
                                <input type="button" class="buttonCss" value="导入小结" onclick="onSetSummary();" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
