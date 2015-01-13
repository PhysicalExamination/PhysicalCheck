<%@ page title="" language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Examination_customerArchive, App_Web_fcstwkee" theme="redmond" %>

<%@ Import Namespace="Common.FormatProvider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $("#packagetabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div class="l-navigationbars">
        <div class="l-navigationbars-l">
            <a href="#" style="left: 100px; text-decoration: none;">组合查询</a></div>
        <div class="l-navigationbars-r">
            <a href="customerArchiveList.aspx" target="_self">返回</a></div>
    </div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">登记信息</a></li>
            <li><a href="#tabs-2">体检报告</a></li>
        </ul>
        <div id="tabs-1">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="HVLine">
                        登记号
                    </td>
                    <td class="HVLine">
                        <asp:TextBox CssClass="textbox31" ID="txtRegisterNo" runat="server" Enabled="false" />
                    </td>
                    <td class="HVLine">
                        登记日期
                    </td>
                    <td class="HVLine">
                        <asp:TextBox CssClass="textbox31  Wdate" ID="txtRegisterDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        体检单位
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtDeptName" runat="server" ReadOnly="true" />
                        <asp:HiddenField ID="hDeptID" runat="server" />
                    </td>
                    <td class="VLine">
                        套 餐
                    </td>
                    <td class="VLine">
                        <asp:TextBox ID="txtPackageName" runat="server" CssClass="textbox31" />
                        <asp:HiddenField ID="hPackageID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        体检日期
                    </td>
                    <td class="VLine">
                        <asp:TextBox ID="txtCheckDate" runat="server" CssClass="textbox31 Wdate" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                    </td>
                    <td class="VLine">
                        姓 名
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        性 别
                    </td>
                    <td class="VLine">
                        <asp:DropDownList ID="drpSex" runat="server">
                            <asp:ListItem Value="男">男</asp:ListItem>
                            <asp:ListItem Value="女">女</asp:ListItem>
                            <asp:ListItem Value="儿童">儿童</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="VLine">
                        民 族
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtNation" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        身份证号
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtIDNumber" runat="server" />
                    </td>
                    <td class="VLine">
                        出生日期
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31  Wdate" ID="txtBirthday" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        年 龄
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtAge" runat="server" />
                    </td>
                    <td class="VLine">
                        婚姻状况
                    </td>
                    <td class="VLine">
                        <asp:DropDownList ID="drpMarriage" runat="server">
                            <asp:ListItem Value="未婚">未婚</asp:ListItem>
                            <asp:ListItem Value="已婚">已婚</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        职 业
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtJob" runat="server" />
                    </td>
                    <td class="VLine">
                        学 历
                    </td>
                    <td class="VLine">
                        <asp:DropDownList ID="drpEducation" runat="server">
                            <asp:ListItem Value="其他">其他</asp:ListItem>
                            <asp:ListItem Value="初中">初中</asp:ListItem>
                            <asp:ListItem Value="高中">高中</asp:ListItem>
                            <asp:ListItem Value="大专">大专</asp:ListItem>
                            <asp:ListItem Value="大学">大学</asp:ListItem>
                            <asp:ListItem Value="硕士">硕士</asp:ListItem>
                            <asp:ListItem Value="博士">博士</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        联系电话
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtLinkTel" runat="server" />
                    </td>
                    <td class="VLine">
                        联系地址
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtAddress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        手 机
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtMobile" runat="server" />
                    </td>
                    <td class="VLine">
                        电子邮件
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox31" ID="txtEMail" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="rptMain" OnItemDataBound="rptMain_ItemDataBound" runat="server">
                        <ItemTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        <%# Eval("DeptName")%>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr class="tr1">
                                                <td class="VLine" align="center" style="width: 150px;">
                                                    <%# Eval("GroupName")%>
                                                </td>
                                                <td class="VLine" style="width: 150px;" align="center">
                                                    检查医生
                                                </td>
                                                <td class="VLine" align="center">
                                                    <%# Eval("CheckDoctor")%>
                                                </td>
                                                <td class="VLine" style="width: 150px;" align="center">
                                                    检查时间
                                                </td>
                                                <td class="VLine" align="center">
                                                    &nbsp;
                                                    <%# Eval("CheckDate")%>
                                                </td>
                                            </tr>
                                            <tr class="tr1">
                                                <td class="VLine" style="width: 150px;" align="center">
                                                    小结
                                                </td>
                                                <td class="VLine" align="center" colspan="4">
                                                    &nbsp;
                                                    <%# Eval("Summary")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
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
                                                        <asp:Literal ID="lblRegisterNo" runat="server" Text=' <%# Eval("ItemName")%>' />
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("CheckedResult")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("MeasureUnit")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("UpperLimit")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("LowerLimit")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("NormalTips")%>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <AlternatingItemTemplate>
                                                <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                                    <td class="VLine" align="center">
                                                        <asp:Literal ID="lblRegisterNo" runat="server" Text=' <%# Eval("ItemName")%>' />
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("CheckedResult")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("MeasureUnit")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("UpperLimit")%>
                                                    </td>
                                                    <td class="VLine" align="center">
                                                        <%# Eval("LowerLimit")%>
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
                                <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
