<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentDetailMasterPage.master" AutoEventWireup="true" CodeFile="GroupDialog.aspx.cs" Inherits="SysConfig_GroupDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function onSelected(groupID, groupName) {
            var returnValues = Array(2);
            returnValues[0] = groupID;
            returnValues[1] = groupName;
            window.returnValue = returnValues;
            window.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
    检查项目<asp:TextBox ID="txtGroupName" runat="server" CssClass="inputCss" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="ItemGroupRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>                           
                            <th>
                                组合项目
                            </th>
                            <th>
                                单价（元）
                            </th>
                            <th>
                                适用性别
                            </th>
                            <th>
                                临床意义
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" 
                        onmouseout="javascript:this.className='tr1'"
                        onclick="onSelected(<%# Eval("GroupID")%>, '<%# Eval("GroupName") %>')">                        
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />
                            <%# Eval("GroupName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Price")%>
                        </td>
                        <td class="VLine" align="center">
                             <%# GetSex(Eval("Sex"))%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Clinical")%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" 
                        onmouseout="javascript:this.className='tr2'"
                        onclick="onSelected(<%# Eval("GroupID")%>, '<%# Eval("GroupName") %>')">                        
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />
                            <%# Eval("GroupName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Price")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# GetSex(Eval("Sex"))%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Clinical")%>
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

