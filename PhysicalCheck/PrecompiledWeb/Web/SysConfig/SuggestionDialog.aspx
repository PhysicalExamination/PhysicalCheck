<%@ page language="C#" masterpagefile="~/MasterPage/ContentDetailMasterPage.master" autoeventwireup="true" inherits="SysConfig_SuggestionDialog, App_Web_012lntyb" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">

        function SaveReturn() {
            var sReturnValues = "";           
            var $parent;
            $(":checked").each(function (index, item) {              
                $parent = $(item).parent().parent();
                sReturnValues += "\n" + trim($parent.children().eq(1).text()) + "\n";                
                sReturnValues += trim($parent.children().eq(2).text());
            });
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
                            <input type="checkbox" />
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
                            <input type="checkbox" />
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
