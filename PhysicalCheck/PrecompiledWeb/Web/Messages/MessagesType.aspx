<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Admin_DepartmentPage, App_Web_cukzgset" theme="redmond" %>

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
        </ul>
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="DepartmentRepeater" runat="server" OnItemCommand="UserItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                  
                                    <th>
                                        编码
                                    </th>
                                    <th>
                                        类型
                                    </th>
                                    <th>
                                        短信格式
                                    </th>
                                    <th>
                                        更新时间
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                               
                                <td class="VLine" align="center">
                                    <%# Eval("Code") %>
                                    <asp:Literal runat="server" ID="lblId" Text='<%# Eval("id") %>' Visible="false" />
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("type_name")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("templet")%>
                                </td>
                                 <td class="VLine" align="center">
                                    <%# Eval("upd_time")%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                              
                                <td class="VLine" align="center">
                                    <%# Eval("Code") %>
                                    <asp:Literal runat="server" ID="lblId" Text='<%# Eval("id") %>' Visible="false" />
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("type_name")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("templet")%>
                                </td>
                                 <td class="VLine" align="center">
                                    <%# Eval("upd_time")%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
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
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                编码
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="textbox41" ID="txtCode" runat="server" />
                            </td>
                             <td class="HVLine">
                                类型
                            </td>
                            <td class="HVLine" >
                            <asp:TextBox CssClass="textbox41" ID="txtType_name" runat="server" />
                                
                            </td>
                        </tr>
                                               
                        <tr>
                            <td class="VLine">
                                短信格式设置                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox41"  ID="txtTemplet" runat="server" Width="99%" />
                            </td>
                        </tr>

                        <tr>
                            <td class="HVLine">
                                更新时间
                            </td>
                            <td class="HVLine">
                                <asp:Literal ID="lblupd_time" runat="server"></asp:Literal>
                            </td>
                             <td class="HVLine">
                                
                            </td>
                            <td class="HVLine" >
                                                               
                            </td>
                        </tr>


                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewUser_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditUser_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteUser_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveUser_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelUser_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
