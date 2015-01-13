<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Charts_Chart7, App_Web_3knbh0ew" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    $(function () {
        $("#tabs").tabs();
    });

    function onSelected(index) {
        $("#tabs").tabs("option", "active", index);
    }

    function selectPerson() {
        var sURL = "<%=ApplicationPath%>/charts/CheckPersonDialog.aspx?rand=" + Math.random();
        var urlValue = window.showModalDialog(sURL, '', "center:yes;help:no;status:no;rsizable:yes");
        
        if (urlValue != null || urlValue != undefined) {
            $("#<%=txtPersonID.ClientID %>").val(urlValue[0]);
            $("#<%=txtName.ClientID %>").val(urlValue[1]);
        }
    }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p align="left">
        疾病<asp:DropDownList ID="drpTrades" runat="server">
            <asp:ListItem>远视眼</asp:ListItem>
            <asp:ListItem>急性结膜炎</asp:ListItem>
            <asp:ListItem>化脓性结膜溃疡</asp:ListItem>
            <asp:ListItem>角膜软化病</asp:ListItem>
            <asp:ListItem>翼状息肉</asp:ListItem>
            <asp:ListItem>白内障</asp:ListItem>
            <asp:ListItem>玻璃体混浊</asp:ListItem>
            <asp:ListItem>青光眼</asp:ListItem>
            <asp:ListItem>弱视</asp:ListItem>
            <asp:ListItem>斜视</asp:ListItem>
            <asp:ListItem>近视眼</asp:ListItem>
            <asp:ListItem>屈光不正</asp:ListItem>
            <asp:ListItem>色盲</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox CssClass="textbox41" ID="txtName" runat="server" ReadOnly="true" />
        <img src="<%=ApplicationPath%>/images/Distract.gif" style="cursor: hand;" alt="选择体检人"
            onclick="selectPerson();" align="middle" border="0" />
        <div style="display: none">
            <asp:TextBox ID="txtPersonID" runat="server" /></div>
        <asp:Button ID="btnSearch" runat="server" Text="分析" CssClass="buttonCss" OnClick="btnSearch_Click" /></p>
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <asp:Chart ID="Chart1" runat="server" BorderlineColor="26, 59, 105" TextAntiAliasingQuality="Normal"
                BorderLineStyle="Solid" BackGradientType="TopBottom" BackGradientEndColor="65, 140, 240"
                Width="800px" Height="600px" runat="server">
                <Titles>
                    <asp:Title Name="Default" Font="宋体, 12pt" Text="" />
                </Titles>
                <Series>
                    <asp:Series Name="Series1" Color="SteelBlue" ShadowOffset="0" YValueType="Double"
                        XValueType="DateTime" ChartArea="ChartArea1" ChartType="Spline">
                        <EmptyPointStyle BorderWidth="0" />
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="White">
                        <AxisY>
                            <LabelStyle Format="N2"></LabelStyle>
                            <MajorTickMark Enabled="False"></MajorTickMark>
                            <MajorGrid LineColor="LightGray" LineDashStyle="DashDot"></MajorGrid>
                        </AxisY>
                        <AxisX>
                            <LabelStyle Format="yyyy年"></LabelStyle>
                            <MajorGrid LineColor="LightGray" Interval="1" IntervalType="Years" LineDashStyle="DashDot">
                            </MajorGrid>
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <BorderSkin SkinStyle="Emboss" BackColor="DodgerBlue" />
            </asp:Chart>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
