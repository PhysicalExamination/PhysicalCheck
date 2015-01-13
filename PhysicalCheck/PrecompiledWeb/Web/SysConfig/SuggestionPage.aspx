<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="SysConfig_SuggestionPage, App_Web_x5zn4di3" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

        function selectDept() {
            var sURL = "<%=ApplicationPath%>/Admin/DepartmentDialog.aspx?rand=" + Math.random();
            var urlValue = window.showModalDialog(sURL, '', "center:yes;help:no;status:no;rsizable:yes");
            //var urlValue = window.showModalDialog(sURL, null, "dialogHeight=" + height + "px;dialogWidth=" + width + "px");
            if (urlValue != null || urlValue != undefined) {
                $("#<%=hDeptID.ClientID %>").val(urlValue[0]);
                $("#<%=txtDeptName.ClientID %>").val(urlValue[1]);
            }
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
                    <asp:Repeater ID="SuggestionRepeater" runat="server" OnItemCommand="SuggestionItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>                                    
                                    <th>
                                        关键字
                                    </th>
                                    <th>
                                        检查科室
                                    </th>
                                    <th>
                                        建议
                                    </th>                                    
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblSNo" Text='<%# Eval("SNo") %>' Visible="false" />
                                     <%# Eval("KeyWord") %>
                                </td>                                
                                <td class="VLine" align="center">
                                    <%# Eval("DeptName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Suggestion") %>
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
                                    <asp:Literal runat="server" ID="lblSNo" Text='<%# Eval("SNo") %>' Visible="false" />
                                    <%# Eval("KeyWord") %>
                                </td>                                
                                <td class="VLine" align="center">
                                    <%# Eval("DeptName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Suggestion") %>
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
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                名称
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="textbox31" ID="txtName" runat="server" />
                            </td>
                            <td class="HVLine">
                                关键字
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="textbox31" ID="txtKeyWord" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                检查科室
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox31" ID="txtDeptName" runat="server" ReadOnly="true" />
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择检查科室"
                                    onclick="selectDept();" align="middle" border="0" />
                                <asp:HiddenField ID="hDeptID" runat="server" />
                            </td>
                           
                        </tr>
                        <tr>
                            <td class="VLine">
                                建议
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox31" TextMode="MultiLine" Height="80px" Width="99%" ID="txtSuggestion"
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                说明
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="textbox31" ID="txtExplain" TextMode="MultiLine" Height="80px"
                                    Width="99%" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewSuggestion_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditSuggestion_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteSuggestion_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveSuggestion_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelSuggestion_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
