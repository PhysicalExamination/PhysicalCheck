<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="customerArchiveList.aspx.cs" Inherits="Examination_customerArchive" %>

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
    <div>
        <div class="l-navigationbars">
            <div class="l-navigationbars-l">
                <a href="#" style="left: 100px; text-decoration: none;">综合查询</a></div>
        </div>
        <asp:UpdatePanel ID="UP1" runat="Server">
            <ContentTemplate>
                登记号：
                <asp:TextBox ID="txtRegisterNo" runat="server"></asp:TextBox>
                单位：
                <asp:TextBox ID="txtDeptName" runat="server"></asp:TextBox>
                名称：
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                身份证：
                <asp:TextBox ID="txtIdNumber" runat="server"></asp:TextBox>
                <br />
                总检：
                <asp:TextBox ID="txtOverallDoctor" runat="server"></asp:TextBox>
                登记日期：<asp:TextBox CssClass="inputCss Wdate" ID="txtStartDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                到<asp:TextBox CssClass="inputCss Wdate" ID="txtEndDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                <asp:Button ID="Button2" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
                <asp:Repeater ID="ReportRepeater" OnItemDataBound="rptMain_ItemDataBound" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <th>
                                    登记号
                                </th>
                                <th>
                                    套餐
                                </th>
                                <th>
                                    姓名
                                </th>
                                <th>
                                    年龄
                                </th>
                                <th>
                                    性别
                                </th>
                                <th>
                                    体检日期
                                </th>
                                <th>
                                    体检状态
                                </th>
                                <th>
                                    已体检
                                </th>
                                <th>
                                    未体检
                                </th>
                                <th>
                                    操作
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                            <td class="VLine" align="center">
                                <asp:Literal ID="lblRegisterNo" runat="server" Text=' <%# Eval("RegisterNo")%>' />
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("PackageName")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("Name")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("age")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("sex")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("CheckDate")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("IsCheckOver ").ToString() == "False" ? "进行中" : "完成"%>
                            </td>

                            <td class="VLine" align="center">
                                <asp:Literal ID="ltDO" runat="server" Text="" />
                            </td>
                            <td class="VLine" align="center">
                                <asp:Literal ID="ltNoDo" runat="server" Text="" />
                            </td>

                            <td class="VLine" align="center">
                                <a href="customerArchive.aspx?id=<%# Eval("RegisterNo") %>" target="_self">详情</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                            <td class="VLine" align="center">
                                <asp:Literal ID="lblRegisterNo" runat="server" Text=' <%# Eval("RegisterNo")%>' />
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("PackageName")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("Name")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("age")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("sex")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("CheckDate")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("IsCheckOver").ToString()=="False" ? "进行中" : "完成"%>
                            </td>
                             <td class="VLine" align="center">
                                <asp:Literal ID="ltDO" runat="server" Text="" />
                            </td>
                            <td class="VLine" align="center">
                                <asp:Literal ID="ltNoDo" runat="server" Text="" />
                            </td>
                            <td class="VLine" align="center">
                                <a href="customerArchive.aspx?id=<%# Eval("RegisterNo") %>" target="_self">详情</a>
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
</asp:Content>
