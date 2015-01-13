<%@ page title="" language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Messages_SetRate, App_Web_jw1dz2t1" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:UpdatePanel ID="UP2" runat="Server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                   <td colspan="4" align="center" class="VLine">
                        短信提醒按照月为单位进行设置，例如：短信设置为6个月，那么系统会自动给体检超过6个月的用户发送提醒短信。
                    </td>
                </tr>
                <tr>
                    <td class="HVLine">
                        短信提醒频率
                    </td>
                    <td class="HVLine">
                        每隔  <asp:DropDownList ID="drpMonth" runat="server">
                        </asp:DropDownList>
                        月  提醒
                    </td>
                </tr>
                
                <td colspan="4" align="center" class="VLine">
                    <asp:Button CssClass="buttonCss" ID="btnSave" OnClick="btnSave_Click" runat="server" Text="设置" />
                </td>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
