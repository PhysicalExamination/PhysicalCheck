<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="RolePage.aspx.cs" Inherits="Admin_RolePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="<%=ApplicationPath%>/Styles/jquery-easyui-1.2.3/tree.css" />
    <script type="text/javascript" src="<%=ApplicationPath%>/scripts/jquery-easyui-1.2.3/jquery.draggable.js"></script>
    <script type="text/javascript" src="<%=ApplicationPath%>/scripts/jquery-easyui-1.2.3/jquery.droppable.js"></script>
    <script type="text/javascript" src="<%=ApplicationPath%>/scripts/jquery-easyui-1.2.3/jquery.tree.js"></script>
    <script type="text/javascript">
        var RoleNo;
        $(function () {
            //此处是扩展tree的两个方法. 
            $.extend($.fn.tree.methods, {
                getCheckedExt: function (jq) {//扩展getChecked方法,使其能实心节点也一起返回
                    var checked = $(jq).tree("getChecked");
                    var checkbox2 = $(jq).find("span.tree-checkbox2").parent();
                    $.each(checkbox2, function () {
                        var node = $.extend({}, $.data(this, "tree-node"), {
                            target: this
                        });
                        checked.push(node);
                    });
                    return checked;
                },
                getSolidExt: function (jq) {//扩展一个能返回实心节点的方法 
                    var checked = [];
                    var checkbox2 = $(jq).find("span.tree-checkbox2").parent();
                    $.each(checkbox2, function () {
                        var node = $.extend({}, $.data(this, "tree-node"), {
                            target: this
                        });
                        checked.push(node);
                    });
                    return checked;
                }
            });
        });


        $(function () {
            //$.ajaxSetup({ cache: false, success: function (data, textStatus) { alert(data); } });
            $("#tabs").tabs();
            $('#RoleModuleTree').tree({
                checkbox: true,
                cascadeCheck: false,
                animate: true,
                lines: true,
                url: "Services.ashx?Action=GetRoleModuleTree"
            });
            $("#<%=Form.ClientID%>").validationEngine({ promptPosition: "topLeft", scroll: false, focusFirstField: true });
        });

        function checkForm() {
            return $("#<%=Form.ClientID%>").validationEngine("validate");
        }

        function onSelected(index, roleNo) {
            RoleNo = roleNo;
            $("#tabs").tabs("option", "active", index);
            $('#RoleModuleTree').tree({
                checkbox: true,
                cascadeCheck: false,
                lines: true,
                animate: true,
                url: "Services.ashx?Action=GetRoleModuleTree&RoleNo=" + roleNo
            });            
        }

        function btnSave_Click() {
            var moduleList = new Array();
            debugger;
            var checkedNodes = $("#RoleModuleTree").tree("getCheckedExt");
            var parentNode;
            for (var index in checkedNodes) {
                moduleList.push(checkedNodes[index].id);
            }
            var url = "Services.ashx?Action=SaveRoleModule&RoleNo=" + RoleNo;
            $.post(url, { Modules: moduleList.toString() }, function (data) {
                alert(data.Message);
            }, "json");
            //alert("角色编号是" + RoleNo);
        }


        function onCheck(node, checked) {              
            var child = $("#RoleModuleTree").tree("getChildren",node.target);            
            $.each(child, function (index, item) {
                if (checked) $("#RoleModuleTree").tree("check", item.target);
                if (!checked) $("#RoleModuleTree").tree("uncheck", item.target);              
            });
       }
       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">角色列表</a></li>
            <li><a href="#tabs-2">角色信息</a></li>
            <li><a href="#tabs-3">角色权限</a></li>
            <li><a href="#tabs-4">角色用户</a></li>
        </ul>
        <div id="tabs-1">
            <asp:UpdatePanel ID="UP1" runat="server">
                <ContentTemplate>
                    <asp:Repeater ID="RoleDataList" runat="server" OnItemCommand="RoleItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <th>
                                        角色名称
                                    </th>
                                    <th>
                                        描述
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal ID="lblRoleNo" runat="server" Text='<%#Eval("RoleNo") %>' Visible="false" />
                                    <%# Eval("RoleName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Description") %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <asp:Literal ID="lblRoleNo" runat="server" Text='<%#Eval("RoleNo") %>' Visible="false" />
                                    <%# Eval("RoleName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <%# Eval("Description") %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                角色<font color="red">*</font>
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="validate[required]  inputCss" ID="txtRoleName" runat="server" data-errormessage-value-missing="角色名称不能为空!" />
                            </td>
                            <td class="HVLine">
                                序号
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="inputCss" ID="txtOrderNo" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                描述
                            </td>
                            <td class="VLine" colspan="3">
                                <asp:TextBox CssClass="multiLine" ID="txtDescription" TextMode="MultiLine" Height="80px"
                                    Width="99%" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNewRole_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEditRole_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDeleteRole_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSaveRole_Click" OnClientClick="checkForm();" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancelRole_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-3">
            <ul id="RoleModuleTree">
            </ul>
            <p align="center">
                <input type="button" class="buttonCss" value="保存" onclick="btnSave_Click();" />
            </p>
        </div>
        <div id="tabs-4">
            <asp:UpdatePanel ID="UP4" runat="server">
                <ContentTemplate>
                    <asp:Repeater runat="server" ID="RoleMemberList" OnItemCommand="RoleMemberList_OnItemCommand">
                        <HeaderTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <th>
                                        用户
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <%# Eval("UserName") %>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("UserNo") %>'
                                        CommandName="delete" Text="移除" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <%# Eval( "UserName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("UserNo") %>'
                                        CommandName="delete" Text="移除" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="blank10">
                    </div>
                    请选择将要添加的用户
                    <asp:Repeater ID="UserList" runat="server" OnItemCommand="UserList_OnItemCommand">
                        <HeaderTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <th>
                                        用户
                                    </th>
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <%# Eval("UserName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="Button3" CommandArgument='<%#Eval("UserNo") %>' CommandName="add"
                                        Text="添加" runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className;this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <%# Eval("UserName")%>
                                </td>
                                <td class="VLine" align="center">
                                    <asp:Button ID="Button4" CommandArgument='<%# Eval("UserNo") %>' runat="server" CommandName="add"
                                        Text="添加" />
                                </td>
                            </tr>
                        </AlternatingItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
