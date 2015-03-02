<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="Chart1.aspx.cs" Inherits="Charts_Chart1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p align="left">
        <asp:DropDownList ID="drpYears" runat="server">
            <asp:ListItem Value="2010">2010年 </asp:ListItem>
            <asp:ListItem Value="2011">2011年 </asp:ListItem>
            <asp:ListItem Value="2012">2012年 </asp:ListItem>
            <asp:ListItem Value="2013">2013年 </asp:ListItem>
            <asp:ListItem Value="2014">2014年 </asp:ListItem>
            <asp:ListItem Value="2015">2015年 </asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="分析" CssClass="buttonCss" OnClick="btnSearch_Click" /></p>
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <asp:Chart ID="Chart1" runat="server" BorderlineColor="26, 59, 105" TextAntiAliasingQuality="Normal"
                BorderLineStyle="Solid" BackGradientType="TopBottom" BackGradientEndColor="65, 140, 240"
                Width="800px" Height="600px" runat="server" ImageLocation="<%=ApplicationPath %>/TempImages/ChartPic_#SEQ(300,3)" >
                <Titles>
                    <asp:Title Name="Default" Font="宋体, 12pt" Text="" />
                </Titles>
                <Series>
                    <asp:Series Name="Series1" Color="SteelBlue" ShadowOffset="0" YValueType="Int32" 
                        XValueType="DateTime" ChartArea="OutputChartArea" LegendText="去年">
                        <EmptyPointStyle BorderWidth="0" />
                    </asp:Series>
                    <asp:Series Name="Series2" ChartArea="OutputChartArea" Color="#66B948" ShadowOffset="0"
                        YValueType="Int32" XValueType="DateTime" LegendText="当年">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="OutputChartArea" BackColor="White">
                        <AxisY>
                            <LabelStyle Format="N2"></LabelStyle>
                            <MajorTickMark Enabled="False"></MajorTickMark>
                            <MajorGrid LineColor="LightGray" LineDashStyle="DashDot"></MajorGrid>
                        </AxisY>
                        <AxisX>
                            <LabelStyle Format="MM月"></LabelStyle>
                            <MajorGrid LineColor="LightGray" Interval="1" IntervalType="Months" LineDashStyle="DashDot">
                            </MajorGrid>
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
                <Legends>
                    <asp:Legend LegendStyle="Row" Docking="Bottom" Name="Default" Font="宋体, 8.75pt" Alignment="Center">
                    </asp:Legend>
                </Legends>
                <BorderSkin SkinStyle="Emboss" BackColor="DodgerBlue" />
            </asp:Chart>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch"  />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
