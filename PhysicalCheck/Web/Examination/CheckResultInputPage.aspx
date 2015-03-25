<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="CheckResultInputPage.aspx.cs" Inherits="Examination_CheckResultInputPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="<%=ApplicationPath%>/Styles/jquery-easyui-1.2.3/tree.css" />
    <script type="text/javascript" src="<%=ApplicationPath%>/Scripts/jquery-easyui-1.2.3/jquery.draggable.js"></script>
    <script type="text/javascript" src="<%=ApplicationPath%>/Scripts/jquery-easyui-1.2.3/jquery.droppable.js"></script>
    <script type="text/javascript" src="<%=ApplicationPath%>/Scripts/jquery-easyui-1.2.3/jquery.tree.js"></script>
    <script type="text/javascript">
        Date.prototype.Format = function (fmt) { //author: meizz   
            var o = {
                "M+": this.getMonth() + 1,                 //月份   
                "d+": this.getDate(),                    //日   
                "h+": this.getHours(),                   //小时   
                "m+": this.getMinutes(),                 //分   
                "s+": this.getSeconds(),                 //秒   
                "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
                "S": this.getMilliseconds()             //毫秒   
            };
            if (/(y+)/.test(fmt))
                fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
            for (var k in o)
                if (new RegExp("(" + k + ")").test(fmt))
                    fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
            return fmt;
        }

        $(function () {
            //Loading(true);
            var CheckDate = new Date().format("yyyy-MM-dd");
            $("#txtCheckDate").val(CheckDate);
            $("#btnSearch").bind("click", loadRegisterTree);
            loadRegisterTree();
        });


        function loadRegisterTree() {
            var CheckDate = $("#txtCheckDate").val();
            var DeptName = $("#txtDeptName").val();
            var RegisterNo = $("#txtRegisterNo").val();
            $('#RegisterTree').tree({
                checkbox: false,
                cascadeCheck: false,
                url: "Services.ashx?Action=BuildRegisterTree&RegisterNo=" + RegisterNo +
                     "&DeptName=" + DeptName + "&CheckDate=" + CheckDate,
                onClick: function (node) {
                    var RegisterDatas = node.id.split(",");
                    if (RegisterDatas.length == 2) {
                        $("#<%=hRegisterNo.ClientID%>").val(RegisterDatas[0]);
                        $("#<%=hGroupID.ClientID%>").val(RegisterDatas[1]);
                        $("#<%=btnGetItemResult.ClientID%>").click();
                    }
                    $('#RegisterTree').tree("toggle", node.target)
                },
                onLoadSuccess: function (node, data) {
                    if (node) {
                        $('#RegisterTree').tree('collapseAll', node.target);
                    } else {
                        $('#RegisterTree').tree('collapseAll');
                        //Loading(false);
                    }
                }
            });
        }

        function onSetSummary() {
            var GroupID = $("#<%=hGroupID.ClientID%>").val();           
            if ((GroupID == "") || (GroupID == undefined) || (GroupID == null)) return;
            var sURL = "<%=ApplicationPath%>/SysConfig/SuggestionDialog.aspx?rand=" + Math.random();
            var sFeatures = "dialogWidth:800px;dialogHeight:600px;center:yes;help:no;status:no;rsizable:yes";
            var sResult = window.showModalDialog(sURL, null, sFeatures);
            var Summary = $("#<%=txtSummary.ClientID %>").val() + sResult;
            $("#<%=txtSummary.ClientID %>").val(Summary);
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
        登记日期<input type="text" class="textbox21  Wdate" id="txtCheckDate"
            onclick="new WdatePicker(this, '%Y-%M-%D', false, 'whyGreen')" />
        体检单位<input type="text" class="textbox21" id="txtDeptName" />
        登记号/身份证号<input type="text" class="textbox21" id="txtRegisterNo" />
        <input type="button" id="btnSearch" class="buttonCss" value="检索" />
    </div>
    <p></p>
    <div style="width: 15%; float: left;">
        <ul id="RegisterTree">
        </ul>
    </div>
    <div style="width: 85%; float: right">
        
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

        <asp:UpdatePanel ID="UP2" runat="Server">
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
           <%-- <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" />
            </Triggers>--%>
        </asp:UpdatePanel>
    </div>
    <div style="display: none;">
        <asp:HiddenField ID="hRegisterNo" runat="server" />
        <asp:HiddenField ID="hGroupID" runat="server" />
        <asp:Button ID="btnGetItemResult" runat="server" Text="获取结果明细" OnClick="btnGetItemResult_Click" />

    </div>
</asp:Content>
