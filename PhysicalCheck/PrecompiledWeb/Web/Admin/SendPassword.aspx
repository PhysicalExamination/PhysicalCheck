<%@ page title="" language="C#" masterpagefile="~/MasterPage/ContentDetailMasterPage.master" autoeventwireup="true" inherits="Admin_SendPassword, App_Web_tqwjkfab" theme="redmond" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <p>
    </p>
 <%--   <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>--%>
            <table align="center" width="400px" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        用户账号
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserAccount" CssClass="textbox31" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        验证码
                    </td>
                    <td>
                        <asp:TextBox ID="txtValidateCode" CssClass="textbox31" runat="server" />
                        <img src="ValidateCode.aspx" onclick="this.src='ValidateCode.aspx?r=' + Math.random();" alt="看不清楚,点击换一张"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <p align="center">
                            <asp:Button ID="btnSend" runat="server" Text="发送密码" CssClass="buttonCss" 
                                onclick="btnSend_Click" />
                             <input type="button" value="关闭"  class="buttonCss" onclick="javascript:self.close();" />                     
                        </p>
                    </td>
                </tr>
            </table>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
