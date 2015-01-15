<%@ page language="C#" masterpagefile="~/MasterPage/ContentDetailMasterPage.master" autoeventwireup="true" inherits="Admin_UserChangePasswordPage, App_Web_totrh500" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script language="javascript" type="text/javascript">

        $(function () {
            $("#<%=Form.ClientID%>").validationEngine({ promptPosition: "topLeft", scroll: false, focusFirstField: true });
        });

        function checkForm() {
            return $("#<%=Form.ClientID%>").validationEngine("validate");
        }        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="Server">
    <div align="right">
        <img src="<%=ApplicationPath %>/images/ClosePage.gif" alt="" width="90" height="39"
            onclick="window.close()" style="cursor: hand">
    </div>
    <div class="blank10">
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="HVLine">
                旧密码<font color="red">*</font>
            </td>
            <td class="HVLine">
                <asp:TextBox CssClass="validate[required]  textbox41" TextMode="Password" ID="txtOldPassword"
                    runat="server" data-errormessage-value-missing="旧密码不能为空!" />
            </td>
        </tr>
        <tr>
            <td class="VLine">
                新密码<font color="red">*</font>
            </td>
            <td class="VLine">
                <asp:TextBox CssClass="validate[required] textbox41" TextMode="Password" ID="txtNewPassword"
                    runat="server" data-errormessage-value-missing="新密码不能为空!" />
            </td>
        </tr>
        <tr>
            <td class="VLine">
                确认密码<font color="red">*</font>
            </td>
            <td class="VLine">
                <asp:TextBox CssClass="textbox41" TextMode="Password" ID="txtConfirmPassword" runat="server"
                    data-errormessage-value-missing="确认密码不能为空!" data-errormessage-pattern-mismatch="您输入的新密码与确认密码不匹配！" />
            </td>
        </tr>
        <tr>
            <td class="VLine" colspan="3" align="center">
                <asp:Button Text="保存" ID="btnSave" CssClass="buttonCss" runat="server"
                     onclick="btnSave_Click" OnClientClick="return checkForm();" />
                <input type="button" class="buttonCss" value="关闭" onclick="window.close()" />
            </td>
        </tr>
    </table>
</asp:Content>
