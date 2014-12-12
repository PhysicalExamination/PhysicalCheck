<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="HospitalPage.aspx.cs" Inherits="SysConfig_HospitalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:UpdatePanel ID="UP2" runat="Server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="HVLine">
                        医院名称
                    </td>
                    <td class="HVLine" colspan="3">
                        <asp:TextBox CssClass="inputCss" ID="txtHospitalName" runat="server"  Width="99%"/>
                    </td>
                </tr>
                <tr>
                    <td class="VLine">
                        联系电话
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox51" ID="txtLinkTel" runat="server" />
                    </td>
                     <td class="VLine">
                        传 真
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox51" ID="txtFax" runat="server" />
                    </td>
                </tr>                
                <tr>
                    <td class="VLine">
                        邮政编码
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox51" ID="txtPostCode" runat="server" />
                    </td>
                    <td class="VLine">
                        网站
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox51" ID="txtWebsite" runat="server" />
                    </td>
                </tr>
               
                <tr>
                    <td class="VLine">
                        地址
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox51" ID="txtAddress" runat="server" />
                    </td>
                    <td class="VLine">
                        微博
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox51" ID="txtBlog" runat="server" />
                    </td>
                </tr>
                
                <tr>
                    <td class="VLine">
                        微信
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox51" ID="txtWeChat" runat="server" />
                    </td>
                    <td class="VLine">
                        徽标
                    </td>
                    <td class="VLine">
                        <asp:TextBox CssClass="textbox51" ID="txtLogo" runat="server" />
                    </td>
                </tr>                
                <tr>
                    <td colspan="4" align="center" class="VLine">
                        <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditHospital_Click" />
                        <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveHospital_Click" />
                        <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelHospital_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
