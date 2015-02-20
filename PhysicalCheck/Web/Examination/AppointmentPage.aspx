<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="AppointmentPage.aspx.cs" Inherits="Examination_AppointmentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Panel").hide();
            $('#btnAppointment').click(function () {
                $("#dialog").dialog({
                    resizable: false,
                    height: 150,
                    width: 260,
                    modal: true,
                    buttons: {
                        "确定": function () {
                            $(this).dialog("close");
                            var argument ="CheckDate="+$("#txtCheckDate").val();
                            var values = "";
                             $("tbody tr input[type='checkbox']:checked").each(function(i,item){
                                  values += $(this).val() +",";
                             });
                            argument += ";Values = "+ values;
                            <%=ClientCallback %>; 
                        },
                        "取消": function () {
                            $(this).dialog("close");
                        }
                    }
                });
            });
        });

        function selectedAll() {
            var checked = $("#chkCheckedAll").get(0).checked;
            $("tbody tr input[type='checkbox']").attr("checked", checked);
           
        }

        function processCallback(result, context) {
            alert(result);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    登记日期<asp:TextBox CssClass="textbox21  Wdate" ID="txtSRegisterDate" runat="server"
        onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
    体检单位<asp:TextBox CssClass="textbox21" ID="txtsDeptName" runat="server" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <input type="button" value="预约" class="buttonCss" id="btnAppointment" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="RegistrationRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                <input type="checkbox" id="chkCheckedAll" onclick="selectedAll();" value="" />
                            </th>
                            <th>
                                登记号
                            </th>
                            <th>
                                体检单位
                            </th>
                            <th>
                                姓名
                            </th>
                            <th>
                                年龄
                            </th>
                            <th>
                                登记日期
                            </th>                           
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <input type="checkbox" value='<%# Eval("RegisterNo") %>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("RegisterNo") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("Age")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("RegisterDate"))%>
                        </td>                       
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <input type="checkbox" value='<%# Eval("RegisterNo") %>' />
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("RegisterNo") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("Name") %>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("Age")) %>
                        </td>
                        <td class="VLine" align="center">
                            <%#EnvShowFormater.GetShortDate(Eval("RegisterDate"))%>
                        </td>                       
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </tbody></table>
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
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="dialog" title="选择预约体检日期" style="display: none;">
        体检日期：
        <input type="text" id="txtCheckDate" class="textbox21  Wdate" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
    </div>
</asp:Content>
