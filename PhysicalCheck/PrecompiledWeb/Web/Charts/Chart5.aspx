<%@ page title="" language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Charts_Chart5, App_Web_d43v5ngv" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    检查项目<asp:DropDownList ID="drpItems" runat="server">
        <asp:ListItem>放射检查</asp:ListItem>
        <asp:ListItem>精神系统检查</asp:ListItem>
        <asp:ListItem>内科检查</asp:ListItem>
        <asp:ListItem>外科检查</asp:ListItem>
        <asp:ListItem>问卷调查</asp:ListItem>
        <asp:ListItem>五官检查</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnSearch" runat="server" Text="检索" CssClass="buttonCss" OnClick="btnSearch_Click" />
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
                        XValueType="DateTime" ChartArea="ChartArea1" ChartType="Column">
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
                <%-- <Legends>
                    <asp:Legend LegendStyle="Row" Docking="Bottom" Name="Default" Font="宋体, 8.75pt" Alignment="Center">
                    </asp:Legend>
                </Legends>--%>
                <BorderSkin SkinStyle="Emboss" BackColor="DodgerBlue" />
            </asp:Chart>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
