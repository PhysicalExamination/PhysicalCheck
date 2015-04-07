<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="CheckResultInputPage.aspx.cs" Inherits="Examination_CheckResultInputPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="<%=ApplicationPath%>/Styles/jquery-easyui-1.2.3/tree.css" />
    <script type="text/javascript" src="<%=ApplicationPath%>/Scripts/jquery-easyui-1.2.3/jquery.draggable.js"></script>
    <script type="text/javascript" src="<%=ApplicationPath%>/Scripts/jquery-easyui-1.2.3/jquery.droppable.js"></script>
    <script type="text/javascript" src="<%=ApplicationPath%>/Scripts/jquery-easyui-1.2.3/jquery.tree.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({               
                cache: false
            });
        });
        function onSelected(el, registerNo) {
            $("#datagrid tr").removeClass("Selected");
            $(el).addClass("Selected");
            var url = "Services.ashx?Action=GetCheckedGroup&RegisterNo=" + registerNo;
            $.get(url, "", function (data, statusText) {
                var html = "";
                var onGroupClick = "";
                var index = 1;
                $.each(data, function (i, item) {
                    index = parseInt(i, 10) + 1;
                    onGroupClick = "onGroupClick(this,'" + registerNo + "'," + item.GroupID + ");";
                    html += "<tr style=\"cursor:pointer\" onclick=" + onGroupClick + ">";
                    html += "<td class=\"VLine\" align=\"center\">" + index + "</td>";
                    html += "<td class=\"VLine\" align=\"center\">" + item.GroupName + "</td>";
                    html += "</tr>";
                });
                $("#Groups").html(html);
                $("#Groups tr:even").addClass("tr1");
                $("#Groups tr:odd").addClass("tr2");
            }, "json");
        }

        function onGroupClick(el, registerNo, groupID) {          
            $("#Groups tr").removeClass("Selected");
            $(el).addClass("Selected");
            $("#<%=hRegisterNo.ClientID%>").val(registerNo);
            $("#<%=hGroupID.ClientID%>").val(groupID);
            $("#<%=btnGetItemResult.ClientID%>").click();
            $("#hSelected").val(registerNo);
            $("#<%=hGroupSummary.ClientID%>").val("");
        }

        function onSetSummary() {
            var GroupID = $("#<%=hGroupID.ClientID%>").val();
            if ((GroupID == "") || (GroupID == undefined) || (GroupID == null)) return;
            var sURL = "<%=ApplicationPath%>/SysConfig/SuggestionDialog.aspx?rand=" + Math.random();
            var sFeatures = "dialogWidth:800px;dialogHeight:600px;center:yes;help:no;status:no;rsizable:yes";
            var sResult = window.showModalDialog(sURL, null, sFeatures);
            if ((sResult == undefined) || (sResult == null)) return;
            var Summary = $("#<%=txtSummary.ClientID %>").val() + sResult[0];
            $("#<%=txtSummary.ClientID %>").val(Summary);
            $("#<%=hGroupSummary.ClientID%>").val(sResult[1]);
        }

        function setUIStatus() {
            var id = $("#hSelected").val();
            $("#" + id).addClass("Selected");
        }

        function saveData() {
            $("#<%=btnSave.ClientID%>").click();
        }
        function closeWindow() {
            open("CheckResultInputlist.aspx", "_self", "", false);
        }
        /*onBeforeExpand:function(node,param){                         
        $('#taskTree').tree('options').url = ctx + "/rims/rescue/loadRescueTaskTreeRootNodes.do?parentId="+node.id;    */
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div>
        体检日期<asp:TextBox CssClass="textbox21  Wdate" ID="txtCheckDate" runat="server"
            onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
        体检单位<asp:TextBox CssClass="textbox21" ID="txtDeptName" runat="server" />
        登记号/身份证号<asp:TextBox CssClass="textbox21" ID="txtRegisterNo" runat="server" />
        <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
    </div>
    <asp:UpdatePanel ID="UP3" runat="Server">
        <ContentTemplate>
            <asp:Repeater ID="Registrations" runat="server">
                <HeaderTemplate>
                    <table id="datagrid" width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>序号</th>
                            <th>登记号
                            </th>
                            <th>姓名
                            </th>
                            <th>年龄
                            </th>
                            <th>工作单位
                            </th>
                            <th>登记日期
                            </th>
                            <th>体检日期
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="tr1" id='<%# Eval("RegisterNo") %>' onclick='onSelected(this,"<%# Eval("RegisterNo") %>")' style="cursor:pointer">
                        <td class="VLine" align="center"><%#Container.ItemIndex + 1 %></td>
                        <td class="VLine" align="center"><%# Eval("RegisterNo") %></td>
                        <td class="VLine" align="center"><%# Eval("Name") %></td>
                        
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("Age")) %>
                        </td>
                        <td class="VLine" align="center"><%# Eval("DeptName") %></td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("RegisterDate"))%>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("CheckDate"))%>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="tr2" id='<%# Eval("RegisterNo") %>' onclick='onSelected(this,"<%# Eval("RegisterNo") %>")' style="cursor:pointer">
                        <td class="VLine" align="center"><%#Container.ItemIndex + 1 %></td>
                        <td class="VLine" align="center"><%# Eval("RegisterNo") %></td>
                        <td class="VLine" align="center"><%# Eval("Name") %></td>
                         <td class="VLine" align="center">
                            <%# EnvShowFormater.GetNumberString(Eval("Age")) %>
                        </td>
                        <td class="VLine" align="center"><%# Eval("DeptName") %></td>
                       
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("RegisterDate"))%>
                        </td>
                        <td class="VLine" align="center">
                            <%# EnvShowFormater.GetShortDate(Eval("CheckDate"))%>
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
                PageSize="5">
            </asp:AspNetPager>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGetItemResult" />
        </Triggers>
    </asp:UpdatePanel>
    <div style="width: 30%; float: left;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <thead>
                <tr>
                    <th>序号</th>
                    <th>检查项目</th>
                </tr>
            </thead>
            <tbody id="Groups">
            </tbody>
        </table>
    </div>
    <div style="width: 70%; float: right">
        <asp:UpdatePanel ID="UP1" runat="Server">
            <ContentTemplate>
                <asp:Repeater ID="ItemResultRepeater" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <th>检查项目
                                </th>
                                <th>检查结果
                                </th>
                                <th>单位
                                </th>
                                <th>参考下限
                                </th>
                                <th>参考上限
                                </th>
                                <th>检查提示
                                </th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                            <td class="VLine" align="center">
                                <%-- <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />--%>
                                <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("ID.ItemID") %>' Visible="false" />
                                <%# Eval("ItemName")%>
                            </td>
                            <td class="VLine" align="center">
                                <asp:TextBox ID="txtCheckResult" runat="server" CssClass="textbox31" Text='<%# Eval("CheckedResult")%>' />
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("MeasureUnit")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("LowerLimit")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("UpperLimit")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("QualitativeResult")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                            <td class="VLine" align="center">
                                <%-- <asp:Literal runat="server" ID="lblGroupID" Text='<%# Eval("GroupID") %>' Visible="false" />--%>
                                <asp:Literal runat="server" ID="lblItemID" Text='<%# Eval("ID.ItemID") %>' Visible="false" />
                                <%# Eval("ItemName")%>
                            </td>
                            <td class="VLine" align="center">
                                <asp:TextBox ID="txtCheckResult" runat="server" CssClass="textbox31" Text='<%# Eval("CheckedResult")%>' />
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("MeasureUnit")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("LowerLimit")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("UpperLimit")%>
                            </td>
                            <td class="VLine" align="center">
                                <%# Eval("QualitativeResult")%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGetItemResult" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UP2" runat="Server" UpdateMode="Always">
            <ContentTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="HVLine">小结
                        </td>
                        <td class="HVLine">
                            <asp:TextBox CssClass="inputCss" TextMode="MultiLine" ID="txtSummary" runat="server"
                                Height="80px" Width="99%" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="VLine" align="center">
                            <asp:Button ID="btnSave" runat="server" CssClass="buttonCss" Text="保存" OnClick="btnSave_Click" />
                            <input type="button" class="buttonCss" value="导入小结" onclick="onSetSummary();" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
             <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div style="display: none;">
        <asp:HiddenField ID="hRegisterNo" runat="server" />
        <asp:HiddenField ID="hGroupID" runat="server" />
        <asp:Button ID="btnGetItemResult" runat="server" Text="获取结果明细" OnClick="btnGetItemResult_Click" />
        <input type="hidden" id="hSelected" />
        <asp:HiddenField ID="hGroupSummary" runat="server" />
     </div>
</asp:Content>
