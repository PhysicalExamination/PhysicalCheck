<%@ page title="" language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="Charts_Chart3, App_Web_3knbh0ew" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <p align="left">
        年度<asp:DropDownList ID="drpYears" runat="server">
            <asp:ListItem Value="2010">2010年 </asp:ListItem>
            <asp:ListItem Value="2011">2011年 </asp:ListItem>
            <asp:ListItem Value="2012">2012年 </asp:ListItem>
            <asp:ListItem Value="2013">2013年 </asp:ListItem>
            <asp:ListItem Value="2014">2014年 </asp:ListItem>
            <asp:ListItem Value="2015">2015年 </asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="检索" CssClass="buttonCss" OnClick="btnSearch_Click" /></p>
    <asp:UpdatePanel ID="UP1" runat="server">
        <ContentTemplate>
            <asp:Chart ID="Chart1" runat="server" BorderlineColor="26, 59, 105" TextAntiAliasingQuality="Normal"
                BorderLineStyle="Solid" BackGradientType="TopBottom" BackGradientEndColor="65, 140, 240"
                Width="800px" Height="600px" runat="server">
                <Titles>
                    <asp:Title Name="Default" Font="宋体, 12pt" Text="" />
                </Titles>
                <Series>
                    <asp:Series ChartArea="ChartArea1" ChartType="Pie" Name="Series1" XValueType="String"
                        YValueType="Double">
                    </asp:Series>
                </Series>
                <Legends>
                    <asp:Legend  Name="Default"  Font="宋体, 8.75pt">
                        <CellColumns>
                            <asp:LegendCellColumn ColumnType="SeriesSymbol" Name="Column1" 
                                Alignment="TopLeft" Font="宋体, 10.5pt">
                                <Margins Left="15" Right="15" />
                            </asp:LegendCellColumn>
                            <asp:LegendCellColumn Name="Column2" Text="#VALX  #PERCENT" 
                                Alignment="TopRight">
                                <Margins Left="15" Right="15" />
                            </asp:LegendCellColumn>
                        </CellColumns>
                    </asp:Legend>
                </Legends>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="White">
                    <Area3DStyle Enable3D="true" />
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
