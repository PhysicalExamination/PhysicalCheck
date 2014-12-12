<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="ModulePage.aspx.cs" Inherits="Admin_ModulePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" rel="stylesheet" href="../css/jquery-easyui-1.2.3/tree.css" />
    <script language="javascript" type="text/javascript" src="../js/jquery-easyui-1.2.3/jquery.draggable.js"></script>
    <script language="javascript" type="text/javascript" src="../js/jquery-easyui-1.2.3/jquery.droppable.js"></script>
    <script language="javascript" type="text/javascript" src="../js/jquery-easyui-1.2.3/jquery.tree.js"></script>
    <script type="text/javascript">
        $(function () {
            //Loading(true);
            loadTreeModule();
        });
        var moduleNo = "";
        function loadTreeModule() {
            $('#ModuleTree').tree({
                checkbox: false,
                cascadeCheck: false,
                url: "Services.ashx?Action=GetModueTree",
                onClick: function (node) {
                    moduleNo = node.id;
                    var parentNode = $('#ModuleTree').tree('getParent', node.target);
                    $("#txtParentModule").val(parentNode.text);
                    $("#txtModuleName").val(node.text);
                    $("#drpModuleIcon").val(node.attributes.ModuleIcon);
                    $("#txtURL").val(node.attributes.URL);
                    $("#txtModuleDescription").val(node.attributes.Description);
                    $("#txtOrderNo").val(node.attributes.OrderNo);
                    $('#ModuleTree').tree("toggle", node.target)
                },
                onLoadSuccess: function (node, data) {
                    if (node) {
                        $('#ModuleTree').tree('collapseAll', node.target);
                    } else {
                        $('#ModuleTree').tree('collapseAll');
                        //Loading(false);
                    }
                }
            });
        }

        function btnNewModule_Click() {
            moduleNo = "";
			var node = $('#ModuleTree').tree("getSelected");
			$("#txtParentModule").val(node.text);
            $("#txtModuleName").val("");
            //$("#drpModuleIcon").val("");
            $("#txtURL").val("");
            $("#txtModuleDescription").val("");
        }

        function btnEditModule_Click() {
        }

        function btnDeleteModule_Click() {
            var module = new Object();
            var node = $('#ModuleTree').tree("getSelected");
            module.ParentModuleNo = "Root";
            if (node == null) return;
            var parentNode = $('#ModuleTree').tree("getParent", node.target);
            if (parentNode) module.ParentModuleNo = parentNode.id;
            module.ModuleNo = node.id;
            module.ModuleName = $("#txtModuleName").val();
            module.ModuleIcon = $("#drpModuleIcon").val();
            module.ModueURL = $("#txtURL").val();
            module.Description = $("#txtModuleDescription").val();
            $.post("Services.ashx?Action=DeleteModule", module, function (data) {
                if (data.Succeed) $('#ModuleTree').tree("remove", node.target);
                alert(data.Message)
            }, "json");
        }

        function btnSaveModule_Click() {
            var module = new Object();
            var node = $('#ModuleTree').tree("getSelected");
            module.ParentModuleNo = "Root";
            module.ModuleNo = moduleNo;
            if ((moduleNo == "") && (node != null)) {
                module.ParentModuleNo = node.id;
            }
            if ((moduleNo != "") && (node != null)) {
                var parentNode = $('#ModuleTree').tree("getParent", node.target);
                if (parentNode) module.ParentModuleNo = parentNode.id;
            }
            module.ModuleName = $("#txtModuleName").val();
            module.ModuleIcon = $("#drpModuleIcon").val();
            module.ModueURL = $("#txtURL").val();
            module.Description = $("#txtModuleDescription").val();
            module.OrderNo = $("#txtOrderNo").val();
            
            $.post("Services.ashx?Action=SaveModue", module, function (data) {
                if (data.Succeed) {
                    var nodeData;
                    if (node != null) {
                        nodeData = $('#ModuleTree').tree("find", data.Data[0].id);
                        if (nodeData == null) {
                            $('#ModuleTree').tree('append', {
                                parent: node.target, data: data.Data
                            });
                        } else {
                            node.text = module.ModuleName;
                            node.attributes.URL = module.ModueURL;
                            node.attributes.Description = module.OrderNo;
                            node.attributes.ModuleIcon = module.ModuleIcon;
                        }

                    } else {
                        $('#ModuleTree').tree('append', {
                            parent: null, data: data.Data
                        });
                    }
                }
                alert(data.Message)
            }, "json");
        }

        function btnCancelModule_Click() {
            $('#ModuleTree').tree("select", "");
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div style="width: 30%; float: left">
        <ul id="ModuleTree">
        </ul>
    </div>
    <div style="width: 70%; float: right">
        <asp:UpdatePanel ID="UP2" runat="Server">
            <ContentTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="HVLine">
                            父模块
                        </td>
                        <td class="HVLine" colspan="3">
                            <input type="text" class="inputCss" id="txtParentModule" disabled="disabled" style="width: 99%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="VLine">
                            模块名称
                        </td>
                        <td class="VLine" colspan="3">
                            <input type="text" class="inputCss" id="txtModuleName"  style="width: 99%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="VLine">
                            序号
                        </td>
                        <td class="VLine">
                            <input type="text" class="inputCss" id="txtOrderNo" style="width: 99%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="VLine">
                            模块图标
                        </td>
                        <td class="VLine" colspan="3">
                            <select id="drpModuleIcon" style="width: 99%">
                                <option value="department.png">department</option>
                                <option value="Department1.png">Department1</option>
                                <option value="Module.png">Module</option>
                                <option value="TrialProduction.png">TrialProduction</option>
                                <option value="user.png">user</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td class="VLine">
                            URL地址
                        </td>
                        <td class="VLine" colspan="3">
                            <input type="text" class="inputCss" id="txtURL" style="width: 99%" />
                        </td>
                    </tr>
                    <tr>
                        <td class="VLine">
                            模块功能描述
                        </td>
                        <td class="VLine" colspan="3">
                            <textarea id="txtModuleDescription" class="multiLine" style="height: 100px">
                            </textarea>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center" class="VLine">
                            <input type="button" class="buttonCss" id="btnNew" value="新建" onclick="btnNewModule_Click();" />
                            <input type="button" class="buttonCss" id="btnSave" value="保存" onclick="btnSaveModule_Click();" />
                            <input type="button" class="buttonCss" id="btnDelete" value="删除" onclick="btnDeleteModule_Click();" />
                            <input type="button" class="buttonCss" id="btnCancel" value="取消" onclick="btnCancelModule_Click();" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
