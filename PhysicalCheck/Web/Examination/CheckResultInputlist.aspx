<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="CheckResultInputlist.aspx.cs" Inherits="Examination_CheckResultInputPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
      function InputCheckResult(RegisterNo,GroupID,DeptID) {
          var src = "CheckResultInputPage.aspx?Rand= " + Math.random() + "&id=" + RegisterNo + 
                    "&GroupId=" + GroupID + "&DeptID=" + DeptID;
            $("#dialogFrame").attr("src", src);
            $("#dialog").dialog({
                resizable: false,
                height: 450,
                width: 750,
                modal: true,
                buttons: {
                    "导入小结": function () {
                        window.frames["dialogFrame"].onSetSummary();
                    },
                    "确定": function () {
                        window.frames["dialogFrame"].saveData();
                        $(this).dialog("close");                       
                    },
                    "取消": function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    登记号：<asp:TextBox CssClass="textbox31" ID="txtsRegisterNo" runat="server" />
    <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    <asp:UpdatePanel ID="UP1" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="ItemResultRepeater" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                套餐
                            </th>
                            <th>
                                组合项
                            </th>
                            <th>
                                科室
                            </th>
                            <th>
                                检查医生
                            </th>
                            <th>
                                小结
                            </th>
                            <th>
                                详情
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("GroupID") %>' Visible="false" />
                            <%# Eval("PackageName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("GroupName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("CheckDoctor")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("summary")%>
                        </td>
                        <td class="VLine" align="center">
                           <input type="button" class="buttonCss" value="详情" onclick="InputCheckResult('<%# Eval("ID.RegisterNo") %>','<%# Eval("ID.GroupID") %>','<%# Eval("DeptID") %>');";
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                        <td class="VLine" align="center">
                            <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("GroupID") %>' Visible="false" />
                            <%# Eval("PackageName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("GroupName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("DeptName")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("CheckDoctor")%>
                        </td>
                        <td class="VLine" align="center">
                            <%# Eval("summary")%>
                        </td>
                        <td class="VLine" align="center">
                        <input type="button" class="buttonCss" value="详情" onclick="InputCheckResult('<%# Eval("ID.RegisterNo") %>','<%# Eval("ID.GroupID") %>','<%# Eval("DeptID") %>');";
                            
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
    <div id="dialog" title="体检结果录入" style="display: block;">
        <iframe id="dialogFrame" frameborder="0" width="720px" height="420px" marginheight="0"
            marginwidth="0" scrolling="no" src="CheckResultInputPage.aspx"></iframe>
    </div>
</asp:Content>
