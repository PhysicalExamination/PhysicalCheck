<%@ Page Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master" AutoEventWireup="true"
    CodeFile="Chart2.aspx.cs" Inherits="Charts_Chart2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p align="left">
        工种<asp:DropDownList ID="drpTrades" runat="server">
           
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="分析" CssClass="buttonCss" OnClick="btnSearch_Click" /></p>
    
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <asp:Chart ID="Chart1" runat="server" BorderlineColor="26, 59, 105" TextAntiAliasingQuality="Normal"
                BorderLineStyle="Solid" BackGradientType="TopBottom" BackGradientEndColor="65, 140, 240"
                Width="800px" Height="600px" runat="server" ImageLocation="<%=ApplicationPath %>/TempImages/ChartPic_#SEQ(300,3)">
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
