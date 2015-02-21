<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="OverallCheckedPage.aspx.cs" Inherits="Examination_OverallCheckedPage" %>

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
            <li><a href="#tabs-3">检查项目</a></li>
            <li><a href="#tabs-4">检查结果</a></li>
        </ul>
        <div id="tabs-1">
            体检日期<asp:TextBox CssClass="textbox31  Wdate" ID="txtSRegisterDate" runat="server"
                onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
            体检单位<asp:TextBox CssClass="textbox31" ID="txtsDeptName" runat="server" />
            登记号/身份证号<asp:TextBox CssClass="textbox31" ID="txtsRegisterNo" runat="server" />
            <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
            <asp:Button ID="btnBatch" runat="server" CssClass="buttonCss" Text="批量总检" OnClick="btnBatch_Click" />
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
                                        单位
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
                                        体检日期
                                    </th>
                                    <th>
                                        未检项目
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
                                    <%# EnvShowFormater.GetShortDate(Eval("CheckDate"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("UncheckedItems")%>
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
                                    <%# EnvShowFormater.GetShortDate(Eval("CheckDate"))%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("UncheckedItems")%>
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
                    <asp:AsyncPostBackTrigger ControlID="btnBatch" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                姓 名
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="textbox31" ID="txtName" runat="server" />
                            </td>
                            <td class="HVLine">
                                性 别
                            </td>
                            <td class="HVLine">
                                <asp:DropDownList ID="drpSex" runat="server">
                                    <asp:ListItem Value="男">男</asp:ListItem>
                                    <asp:ListItem Value="女">女</asp:ListItem>
                                    <asp:ListItem Value="儿童">儿童</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                登记号
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtRegisterNo" runat="server" Enabled="false" />
                            </td>
                            <td class="VLine">
                                体检单位
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtDeptName" runat="server" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                套 餐
                            </td>
                            <td class="VLine">
                                <asp:TextBox ID="txtPackageName" runat="server" CssClass="textbox31" />
                            </td>
                            <td class="VLine">
                                体检日期
                            </td>
                            <td class="VLine">
                                <asp:TextBox ID="txtCheckDate" runat="server" CssClass="textbox31 Wdate" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                复查日期
                            </td>
                            <td class="VLine">
                                <asp:TextBox ID="txtReviewDate" runat="server" CssClass="textbox31 Wdate" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                            </td>
                            <td class="VLine">
                                复查概要
                            </td>
                            <td class="VLine">
                                <asp:TextBox ID="txtReviewSummary" runat="server" CssClass="textbox61" Width="99%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                办理健康证条件
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpHealthCondition" runat="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="01">合格</asp:ListItem>
                                    <asp:ListItem Value="02">不合格</asp:ListItem>
                                    <asp:ListItem Value="03">缺项</asp:ListItem>
                                    <asp:ListItem Value="04">复查</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                职业能力评定
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpEvaluateResult" runat="server">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="01">本次体检中未发现不宜从事该工种有关的疾病</asp:ListItem>
                                    <asp:ListItem Value="02">本次体检无异常</asp:ListItem>
                                    <asp:ListItem Value="03">动态观察</asp:ListItem>
                                    <asp:ListItem Value="04">转科治疗</asp:ListItem>
                                    <asp:ListItem Value="05">复查</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                体检综述
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox31" TextMode="MultiLine" ID="txtSummary" Height="80px"
                                    Width="99%" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                总检结论
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox31" TextMode="MultiLine" ID="txtConclusion" Height="80px"
                                    Width="99%" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                医生建议
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox31" TextMode="MultiLine" ID="txtRecommend" Height="80px"
                                    Width="99%" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEdit_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-3">
            <asp:UpdatePanel ID="UP3" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="GroupsRepeater" runat="server">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        组合名称
                                    </th>
                                    <th>
                                        检查科室
                                    </th>
                                    <th>
                                        单价（元）
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <%# Eval("GroupName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("DeptName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetCurrencyString(Eval("Price"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <%# Eval("GroupName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("DeptName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# EnvShowFormater.GetCurrencyString(Eval("Price"))%>
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
        <div id="tabs-4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="rptMain" OnItemDataBound="rptMain_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th colspan="5">
                                        <%# Eval("DeptName")%>
                                        <asp:Literal ID="lblGroupID" runat="server" Text='<%# Eval("ID.GroupID")%>'  Visible="false"/>
                                    </th>
                                </tr>
                                <tr>
                                    <td class="VLine" align="center">
                                        <%# Eval("GroupName")%>
                                    </td>
                                    <td class="VLine" align="center">
                                        检查医生
                                    </td>
                                    <td class="VLine" align="center">
                                        <%# Eval("CheckDoctor")%>
                                    </td>
                                    <td class="VLine" align="center">
                                        检查时间
                                    </td>
                                    <td class="VLine" align="center">
                                        <%# EnvShowFormater.GetShortDate(Eval("CheckDate"))%>
                                    </td>
                                </tr>                                
                                <tr>
                                    <td colspan="5">
                                        <asp:Repeater ID="rptSub" runat="server">
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
                                                        <th>
                                                            正常提示
                                                        </th>
                                                    </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                                    <td class="VLine" align="center">
                                                        <%# Eval("ItemName")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("CheckedResult")%>
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
                                                    <td class="VLine" align="center">
                                                        <%# Eval("NormalTips")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                                    <td class="VLine" align="center">
                                                        <%# Eval("ItemName")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("CheckedResult")%>
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
                                                    <td class="VLine" align="center">
                                                        <%# Eval("NormalTips")%>
                                                    </td>
                                                </tr>
                                            </AlternatingItemTemplate>
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="VLine" align="center">
                                        小结
                                    </td>
                                    <td class="VLine" align="center" colspan="4">
                                        <%# Eval("Summary")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
