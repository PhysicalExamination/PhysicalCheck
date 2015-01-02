<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="customerArchive.aspx.cs" Inherits="Examination_customerArchive" %>

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
            <a href="#" style="left: 100px; text-decoration: none;">体检档案</a></div>
        <div class="l-navigationbars-r">
            <a href="customerArchiveList.aspx" target="_self">返回</a></div>
    </div>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">登记信息</a></li>
            <li><a href="#tabs-2">缴费信息</a></li>
            <li><a href="#tabs-3">体检报告</a></li>
            <li><a href="#tabs-4">复检通知书</a></li>
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
                        <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择体检单位"
                            onclick="selectDept();" align="middle" border="0" />
                        <asp:HiddenField ID="hDeptID" runat="server" />
                    </td>
                    <td class="VLine">
                        套 餐
                    </td>
                    <td class="VLine">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox31" />
                        <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择套餐"
                            onclick="selectPackage();" align="middle" border="0" />
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
                        <asp:TextBox CssClass="textbox31" ID="TextBox2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        性 别
                    </td>
                    <td class="VLine">
                        <asp:DropDownList ID="DropDownList1" runat="server">
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
                        <asp:TextBox CssClass="textbox31" ID="TextBox3" runat="server" />
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
                        <asp:DropDownList ID="DropDownList2" runat="server">
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
                        <asp:TextBox CssClass="textbox31" ID="TextBox4" runat="server" />
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
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                缴费人
                            </td>
                            <td class="HVLine" colspan="3">
                                <asp:TextBox CssClass="textbox31" ID="txtPayer" runat="server" Width="90%" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                体检套餐
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtPackageName" runat="server" ReadOnly="true" />
                                
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
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-3">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                体检编号
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="inputCss" ID="txtBillNo" runat="server" ReadOnly="true" />
                            </td>
                            <td class="HVLine">
                                检查套餐
                            </td>
                            <td class="HVLine">
                                <asp:TextBox ID="txtPackageName3" runat="server" CssClass="inputCss" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                单位名称
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="inputCss" Width="99%" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                地址
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="inputCss" Width="99%" ReadOnly="true" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                姓名
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtName" runat="server" />
                            </td>
                            <td class="VLine">
                                性别
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpSex" runat="server">
                                    <asp:ListItem Value="0">男</asp:ListItem>
                                    <asp:ListItem Value="1">女</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                年龄
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="inputCss" ID="txtAge" runat="server" />
                            </td>
                            <td class="VLine">
                                文化程度
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpEducation" runat="server">
                                    <asp:ListItem Value="初中">初中</asp:ListItem>
                                    <asp:ListItem Value="高中">高中</asp:ListItem>
                                    <asp:ListItem Value="大专">大专</asp:ListItem>
                                    <asp:ListItem Value="本科">本科</asp:ListItem>
                                    <asp:ListItem Value="硕士">硕士</asp:ListItem>
                                    <asp:ListItem Value="博士">博士</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                所属区域
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpRegion" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                行业类别
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpTrade" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                工种
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpWorkType" runat="server" />
                            </td>
                            <td class="VLine">
                                单位性质
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpNature" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                经办人
                            </td>
                            <td class="VLine">
                                <asp:TextBox ID="txtOperator" runat="server" CssClass="inputCss" />
                            </td>
                            <td class="VLine">
                                登记日期
                            </td>
                            <td class="VLine">
                                <asp:TextBox ID="txtRegDate" runat="server" CssClass="inputCss Wdate" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-4">

        </div>
    </div>
</asp:Content>
