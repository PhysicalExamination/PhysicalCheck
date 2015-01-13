<%@ page language="C#" masterpagefile="~/MasterPage/ContentDetailMasterPage.master" autoeventwireup="true" inherits="Admin_DepartmentDialog, App_Web_tqwjkfab" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function onSelected(deptID,deptName) {          
            var returnValues = Array(2);
            returnValues[0] = deptID;
            returnValues[1] = deptName;
            window.returnValue = returnValues;
            window.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server"
    ClientIDMode="Static">
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="DepartmentRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                序号
                            </th>
                            <th>
                                科室名称
                            </th>
                            <th>
                                科室类别
                            </th>
                            <th>
                                科室位置
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <%# Container.ItemIndex + 1 %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName") %>
                            
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptKind")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DepLlocation")%>
                        </td>
                        <td class="VLine" align="center">
                          <input type="button" class="buttonCss" value="选择" onclick="onSelected(<%# Eval("DeptID")%>, '<%# Eval("DeptName") %>')" />
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <%# Container.ItemIndex + 1 %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName") %>                           
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptKind")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DepLlocation")%>
                        </td>
                        <td class="VLine" align="center">
                           <input type="button" class="buttonCss" value="选择" onclick="onSelected(<%# Eval("DeptID")%>, '<%# Eval("DeptName") %>')" />
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
</asp:Content>
