<%@ page title="" language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Examination_customerArchive, App_Web_ijkjgchv" theme="redmond" %>

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
        function Printrpt() {
                        var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?ReportKind=62";
                        sURL += "&DeptId=" + $("select#<%=drpdepartment.ClientID%>").find('option:selected').val();           
                        sURL += "&DeptName=" + $("select#<%=drpdepartment.ClientID%>").find('option:selected').text();  
                        sURL += "&StartDate=" + $("#<%=txtStartDate.ClientID%>").val();
                        sURL += "&EndDate=" + $("#<%=txtEndDate.ClientID%>").val();
                        window.open(sURL, "_blank", "", true);

            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div>
        <div class="l-navigationbars">
            <div class="l-navigationbars-l">
                <a href="#" style="left: 100px; text-decoration: none;">体检科室工作量查询 </a>
            </div>
        </div>
        <asp:UpdatePanel ID="UP1" runat="Server">
            <ContentTemplate>
                
                科室：
                <asp:DropDownList ID="drpdepartment" runat="server">
                </asp:DropDownList>                
                日期：<asp:TextBox CssClass="inputCss Wdate" ID="txtStartDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                到<asp:TextBox CssClass="inputCss Wdate" ID="txtEndDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                <asp:Button ID="Button2" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
                <input type="button" class="buttonCss" value="打印" onclick="Printrpt();" />
                <asp:Repeater ID="ReportRepeater" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                              
                                <th>
                                    套餐
                                </th>
                                <th>
                                    工作量
                                </th>

                                  <th>
                                    合计价格
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                            <td class="VLine" align="center">
                                <asp:Literal ID="PackageName" runat="server" Text=' <%# Eval("PackageName")%>' />
                            </td>
                         
                            <td class="VLine" align="center">
                                <%# Eval("sumNum")%>
                            </td>
                               <td class="VLine" align="center">
                                <%# Eval("sumPrice")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                           <td class="VLine" align="center">
                                <asp:Literal ID="PackageName" runat="server" Text=' <%# Eval("PackageName")%>' />
                            </td>
                         
                            <td class="VLine" align="center">
                                <%# Eval("sumNum")%>
                            </td>
                               <td class="VLine" align="center">
                                <%# Eval("sumPrice")%>
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
</asp:Content>
