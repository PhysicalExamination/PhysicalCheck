<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentDetailMasterPage.master"
    AutoEventWireup="true" CodeFile="SuggestionDialog.aspx.cs" Inherits="SysConfig_SuggestionDialog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function SaveReturn() {
            var sReturnValues = new Array();                
            var list = new Array();
            var summary = "";
            var $parent;
            $(":checked").each(function (index, item) {               
                list.push($(item).attr("id"));                        
                $parent = $(item).parent().parent();
                summary += "\n" + trim($parent.children().eq(1).text()) + "\n";
                summary += trim($parent.children().eq(2).text());
            });           
            sReturnValues.push(summary);
            sReturnValues.push(list);
            window.returnValue = sReturnValues;
            window.close();
        }

        function trim(sValue) {
            if (sValue == null) return "";
            return sValue.replace(/^\s\s*/, '').replace(/\s\s*$/, '')
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    关键字：<asp:TextBox ID="txtSearchKey" runat="server" CssClass="textbox31" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="SuggestionRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                            </th>
                            <th>
                                关键字
                            </th>
                            <th>
                                建议
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <input type="checkbox" id="<%#Eval("SNO") %>" />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("KeyWord") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Suggestion") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                           <input type="checkbox" id="<%#Eval("SNO") %>"  />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("KeyWord") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Suggestion") %>
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
    <p align="center">
        <input type="button" class="buttonCss" value="保存返回" onclick="SaveReturn();" />
    </p>
</asp:Content>
