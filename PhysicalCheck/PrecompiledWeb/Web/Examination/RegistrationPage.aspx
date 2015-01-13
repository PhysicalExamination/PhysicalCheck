<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Examination_RegistrationPage, App_Web_lbndgfpo" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });

        function onSelected(index) {
            $("#tabs").tabs("option", "active", index);
        }

        function selectDept() {
            var sRegNo = $("#<%=txtRegisterNo.ClientID %>").val();
            //if ((sRegNo != null) || (sRegNo != "")) return;
            var sURL = "<%=ApplicationPath%>/Examination/DepartmentDialog.aspx?rand=" + Math.random();
            var sFeatures = "center:yes;help:no;status:no;rsizable:yes";
            var vArguments = "";
            var urlValue = window.showModalDialog(sURL, vArguments, sFeatures);

            if (urlValue != null || urlValue != undefined) {
                $("#<%=hDeptID.ClientID %>").val(urlValue[0]);
                $("#<%=txtDeptName.ClientID %>").val(urlValue[1]);
            }
        }

        function selectPackage() {
            var sDeptID = $("#<%=hDeptID.ClientID %>").val();
            var sFeatures = "dialogWidth:800px;dialogHeight:600px;center:yes;help:no;status:no;rsizable:yes";
            var sURL = "<%=ApplicationPath%>/SysConfig/PackageDialog.aspx?rand=" + Math.random() + "&DeptID=" + sDeptID;
            var urlValue = window.showModalDialog(sURL, '', sFeatures);
            //var urlValue = window.showModalDialog(sURL, null, "dialogHeight=" + height + "px;dialogWidth=" + width + "px");
            if (urlValue != null || urlValue != undefined) {
                $("#<%=hPackageID.ClientID %>").val(urlValue[0]);
                $("#<%=txtPackageName.ClientID %>").val(urlValue[1]);
                $("#<%=hGroups.ClientID%>").val(urlValue[3]);
            }
        }

        function selectCharge() {            
            var sFeatures = "dialogWidth:800px;dialogHeight:600px;center:yes;help:no;status:no;rsizable:yes";
            var sURL = "<%=ApplicationPath%>/Examination/ChargeDialog.aspx?rand=" + Math.random();
            var urlValue = window.showModalDialog(sURL, '', sFeatures);
            $("#<%=txtChargeID.ClientID%>").val(urlValue[0]);
            $("#<%=hPackageID.ClientID %>").val(urlValue[1]);
            $("#<%=txtPackageName.ClientID %>").val(urlValue[2]);
            $("#<%=hDeptID.ClientID %>").val(urlValue[3]);
            $("#<%=txtDeptName.ClientID %>").val(urlValue[4]);
        }

        function btnDataImport() {
            var sURL = " RegImportDialog.aspx?rand=" + Math.random();
            var vArguments = "";
            var sFeatures = "dialogHeight=600px;dialogWidth=800px;center:yes;help:no;status:no;rsizable:yes";
            window.showModalDialog(sURL, vArguments, sFeatures);
        }

        function PrintIntroduction(RegisterNo) {
            var sURL = "<%=ApplicationPath%>/Reports/Default.aspx?RegisterNo=" + RegisterNo + "&ReportKind=3";
            window.open(sURL, "_blank", "", true);
        }

        function downLoadTemplate() {
            var sURL = "<%=ApplicationPath%>/DownLoad/团体数据填报模板.zip";
            window.open(sURL, "_blank", "", true);
        }

        var isInit = false;
        function readCard() {
            var CardReader = document.getElementById("CardReader1");
           
            if (false == isInit) {
                obj.setPortNum(0);
                isInit = true;
            }
            CardReader.Flag = 0;
            var ResultCode = CardReader.ReadCard();
            //alert(ResultCode);
            if (ResultCode == 0x90) {
                $("#<%=txtName.ClientID%>").val(CardReader.NameL());
                $("#<%=txtBirthday.ClientID%>").val(CardReader.BornL());
                $("#<%=drpSex.ClientID%>").val(CardReader.SexL());
                $("#<%=txtNation.ClientID%>").val(CardReader.NationL());
                $("#<%=txtIDNumber.ClientID%>").val(CardReader.CardNo());
                $("#<%=txtAddress.ClientID%>").val(CardReader.Address());
                $("#<%=hPhoto.ClientID%>").val(CardReader.GetImage());
                var img = "data:image/png;base64," + CardReader.GetImage();
                $("#Pricture").attr("src",img);
            } else {
                alert("身份证信息读取失败！");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">浏览</a></li>
            <li><a href="#tabs-2">编辑</a></li>
        </ul>
        <div id="tabs-1">
            登记日期<asp:TextBox CssClass="textbox31  Wdate" ID="txtSRegisterDate" runat="server"
                onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
            体检单位<asp:TextBox CssClass="textbox31" ID="txtsDeptName" runat="server" />
            登记号/身份证号<asp:TextBox CssClass="textbox31" ID="txtsRegisterNo" runat="server" />
            <asp:Button ID="btnSearch" runat="server" CssClass="buttonCss" Text="检索" OnClick="btnSearch_Click" />
            <input type="button" class="buttonCss" value="批量导入" onclick="btnDataImport();" />
            <input type="button" class="buttonCss" value="模板下载" onclick="downLoadTemplate();" />
            <asp:UpdatePanel ID="UP1" runat="Server">
                <ContentTemplate>
                    <asp:Repeater ID="RegistrationRepeater" runat="server" OnItemCommand="ItemCommand">
                        <HeaderTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
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
                                    <th>
                                        操作
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tr1" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr1'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblRegisterNo" Text='<%# Eval("RegisterNo") %>' />
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
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
                                    <input type="button" class="buttonCss" value="打印" onclick="PrintIntroduction('<%# Eval("RegisterNo")%>');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr class="tr2" onmouseover="javascript:this.className='tr3';" onmouseout="javascript:this.className='tr2'">
                                <td class="VLine" align="center">
                                    <asp:Literal runat="server" ID="lblRegisterNo" Text='<%# Eval("RegisterNo") %>' />
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
                                <td class="VLine" align="center">
                                    <asp:Button ID="btnDetail1" runat="server" Text="查看" CommandName="Select" CssClass="buttonCss"
                                        OnClientClick="onSelected(1)" />
                                    <input type="button" class="buttonCss" value="打印" onclick="PrintIntroduction('<%# Eval("RegisterNo")%>');" />
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
                        PageSize="15">
                    </asp:AspNetPager>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSearch" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="UP2" runat="Server">
                <ContentTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="HVLine">
                                收费单
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="textbox31" ID="txtChargeID" runat="server" Enabled="false" />
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择收费单"
                                    onclick="selectCharge();" align="middle" border="0" />
                            </td>
                            <td class="HVLine" rowspan="5">
                                照片
                            </td>
                            <td class="HVLine" rowspan="5" align="center">
                                <img src="<%=ApplicationPath%>/images/nopricture.jpg" alt="个人照片" id="Pricture" />
                                <asp:HiddenField ID="hPhoto" Value="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                登记号
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtRegisterNo" runat="server" Enabled="false" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                登记日期
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31  Wdate" ID="txtRegisterDate" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                体检单位
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtDeptName" runat="server" ReadOnly="true" />
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择体检单位"
                                    onclick="selectDept();" align="middle" border="0" />
                                <asp:HiddenField ID="hDeptID" runat="server" Value="1" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                套 餐
                            </td>
                            <td class="VLine">
                                <asp:TextBox ID="txtPackageName" runat="server" CssClass="textbox31" />
                                <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择套餐"
                                    onclick="selectPackage();" align="middle" border="0" />
                                <asp:HiddenField ID="hPackageID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                姓 名
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtName" runat="server" />
                            </td>
                            <td class="HVLine">
                                身份证号
                            </td>
                            <td class="HVLine">
                                <asp:TextBox CssClass="textbox31" ID="txtIDNumber" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                性 别
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpSex" runat="server">
                                    <asp:ListItem Value="男">男</asp:ListItem>
                                    <asp:ListItem Value="女">女</asp:ListItem>
                                    <asp:ListItem Value="儿童">儿童</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                民 族
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtNation" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                出生日期
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31  Wdate" ID="txtBirthday" runat="server" onclick="new WdatePicker(this,'%Y年%M月%D日',false,'whyGreen')" />
                            </td>
                            <td class="VLine">
                                年 龄
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtAge" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                婚姻状况
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpMarriage" runat="server">
                                    <asp:ListItem Value="未婚">未婚</asp:ListItem>
                                    <asp:ListItem Value="已婚">已婚</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                职 业
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtJob" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                学 历
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpEducation" runat="server">
                                    <asp:ListItem Value="其他">其他</asp:ListItem>
                                    <asp:ListItem Value="初中">初中</asp:ListItem>
                                    <asp:ListItem Value="高中">高中</asp:ListItem>
                                    <asp:ListItem Value="大专">大专</asp:ListItem>
                                    <asp:ListItem Value="大学">大学</asp:ListItem>
                                    <asp:ListItem Value="硕士">硕士</asp:ListItem>
                                    <asp:ListItem Value="博士">博士</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="VLine">
                                所在地区
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpRegion" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                从事行业
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpIndustry" runat="server" />
                            </td>
                            <td class="VLine">
                                从事工种
                            </td>
                            <td class="VLine">
                                <asp:DropDownList ID="drpTrade" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                联系电话
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtLinkTel" runat="server" />
                            </td>
                            <td class="VLine">
                                联系地址
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtAddress" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="VLine">
                                手 机
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtMobile" runat="server" />
                            </td>
                            <td class="VLine">
                                电子邮件
                            </td>
                            <td class="VLine">
                                <asp:TextBox CssClass="textbox31" ID="txtEMail" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" class="VLine">
                                <asp:Button CssClass="buttonCss" ID="btnNew" runat="server" Text="新建" OnClick="btnNew_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnEdit" runat="server" Text="编辑" OnClick="btnEdit_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"
                                    OnClientClick="javascript:return confirm('你确定要删除该数据吗？')" />
                                <asp:Button CssClass="buttonCss" ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                                <asp:Button CssClass="buttonCss" ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
                                <input type="button" id="btnReadCard" value="读取身份证" onclick="readCard();" />
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hGroups" runat="server" Value="" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <object id="CardReader1" codebase="FirstActivex.cab#version=1,3,0,1" classid="CLSID:F225795B-A882-4FBA-934C-805E1B2FBD1B"
        width="102" height="126">
        <param name="_Version" value="65536" />
        <param name="_ExtentX" value="2646" />
        <param name="_ExtentY" value="1323" />
        <param name="_StockProps" value="0" />
    </object>
</asp:Content>
