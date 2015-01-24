<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="AdvisePage.aspx.cs" Inherits="Admin_DepartmentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
            $("#<%=Form.ClientID%>").validationEngine({ promptPosition: "topLeft", scroll: false, focusFirstField: true });
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

        function checkForm() {
            return $("#<%=Form.ClientID%>").validationEngine("validate");
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
                                        序号
                                    </th>
                                    <th>
                                        登记号
                                    </th>
                                    <th>
                                        姓名
                                    </th>
                                     <th>
                                       医生建议
                                    </th>

                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <%# Container.ItemIndex + 1 %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("RegisterNo")%>
                                    <asp:Literal runat="server" ID="lblId" Text='<%# Eval("id") %>' Visible="false" />
                                </td>
                                
                                 <td class="VLine" align="center">
                                    <%# Eval("Name")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Content3")%>
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
                                    <%# Container.ItemIndex + 1 %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("RegisterNo")%>
                                    <asp:Literal runat="server" ID="lblId" Text='<%# Eval("id") %>' Visible="false" />
                                </td>
                                
                                 <td class="VLine" align="center">
                                    <%# Eval("Name")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Content3")%>
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
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                            <td class="HVLine">
                                登记号<font color="red">*</font>
                            </td>
                            <td class="HVLine" >
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtRegisterNo" runat="server" data-errormessage-value-missing="科室名称不能为空!"/>
                            </td>
                            <td class="HVLine">
                                姓名<font color="red">*</font>
                            </td>
                            <td class="HVLine" >
                                <asp:TextBox CssClass="validate[required] textbox41" ID="TextBox2" runat="server" data-errormessage-value-missing="科室名称不能为空!"/>
                            </td>
                        </tr>

                        <tr>
                            <td class="VLine">
                                总论<font color="red">*</font>
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="validate[required] textbox41" TextMode="MultiLine" Width="99%"  Enabled=false ID="TextBox3" runat="server"  Height="200px" />
                            </td>
                            
                        </tr>     

                         <tr>
                            <td class="VLine">
                                调查<font color="red">*</font>
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="validate[required] textbox41" ID="txtInvestigation" Width="99%" Height="200px" TextMode="MultiLine"  runat="server" data-errormessage-value-missing="不能为空!"/>
                            </td>
                            
                        </tr>                       
                        <tr>
                            <td class="VLine">
                                饮食
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox41" ID="txtContent" TextMode="MultiLine" runat="server" Width="99%" Height="200px" />

                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                运动
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox41" ID="txtContent2" TextMode="MultiLine" runat="server" Width="99%" Height="200px" />
                            </td>
                            
                        </tr>                       
                        <tr>
                            <td class="VLine">
                                医生建议
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox41" ID="txtContent3" TextMode="MultiLine" runat="server" Width="99%" Height="200px"/>

                            </td>
                        </tr>

                        <tr>
                            <td class="VLine">
                                医生
                            </td>
                            <td class="VLine" >
                                <asp:TextBox CssClass="textbox41" ID="txtDoctor"  runat="server" Width="99%" />

                            </td>
                            <td class="VLine">
                                时间
                            </td>
                            <td class="VLine" >
                                <asp:TextBox CssClass="textbox41" ID="txtadd_time"  Enabled=false  runat="server" Width="99%" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewUser_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditUser_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteUser_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveUser_Click" 
                                     OnClientClick="return checkForm();"/>
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelUser_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
