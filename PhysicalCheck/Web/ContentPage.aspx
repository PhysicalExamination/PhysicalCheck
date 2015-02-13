<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="ContentPage.aspx.cs" Inherits="ContentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #checkeddiv
        {
            width: 1037px;
            height: 60px;
            background-color: #FFF;
            margin: 0 auto;
        }
        #checkeddiv a
        {
            float: left;
            display: block;
            width: 148px;
            height: 60px;
        }
        .aset:hover
        {
            background-color: #cccccc;
        }
        #mainshow
        {
            width: 100%;
            height: 100%;
            background-color: #FFF;
            margin-left: auto;
            margin-right: auto;
            margin-top: 2px;
        }
        img
        {
            border: 0;
        }
        .splitimgdiv
        {
            background-image: url(images/home/20.png);
            width: 47px;
            height: 47px;
            float: left;
            margin-top: 30px;
        }
        .showdiv
        {
            width: 1037px;
            height: 120px;
            margin-top: 60px;
            float: left;
        }
        .style1
        {
            width: 1024px;
            height: 768px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <%--<div id="mainshow">
            <div class="showdiv">
                <a id="p5" style="margin-left: 650px; float: left;" href="Examination/OverallCheckedPage.aspx">
                    <img alt="" src="images/home/5.png" /></a>
            </div>
            <div style="width: 200px; height: 60px; float: left; margin-left: 700px">
                <img src="images/home/21.png" alt="" />
            </div>
            <div style="width: 1037px">
                <a id="p1" style="margin-left: 47px; float: left;" href="Examination/ChargePage.aspx">
                    <img alt="" src="images/home/1.png" /></a>
                <div class="splitimgdiv">
                </div>
                <a id="p2" style="float: left" href="Examination/RegistrationPage.aspx">
                    <img alt="" src="images/home/2.png" /></a>
                <div class="splitimgdiv">
                </div>
                <a id="p3" style="float: left" href="Examination/CheckResultInputPage.aspx">
                    <img alt="" src="images/home/3.png" /></a>
                <div class="splitimgdiv">
                </div>
                <a id="p4" style="float: left" href="Examination/OverallCheckedPage.aspx">
                    <img alt="" src="images/home/4.png" /></a>
                <div class="splitimgdiv">
                </div>
                <a id="p6" style="float: left" href="Examination/OverallCheckedPage.aspx">
                    <img alt="" src="images/home/6.png" /></a>
            </div>
            <div style="width: 200px; height: 60px; float: left; margin-left: 690px">
                <img src="images/home/22.png" alt="" />
            </div>
            <div style="width: 1037px">
                <a id="p7" style="margin-left: 550px; float: left" href="Examination/ReviewPage.aspx">
                    <img alt="" src="images/home/7.png" /></a> <a id="p8" style="margin-left: 47px; float: left"
                        href="Examination/OverallCheckedPage.aspx">
                        <img alt="" src="images/home/8.png" /></a>
            </div>
        </div>--%>
    <div align="center">
        <img alt="" src="images/home/Main.png" usemap="#Map" />
        <map name="Map" id="Map">
            <area shape="rect" coords="159,75,225,149" href="Examination/RegistrationPage.aspx"
                target="_self" alt="个体登记" />
            <area shape="rect" coords="854,510,930,563" href="#拒检登记" />
            <area shape="rect" coords="844,360,920,442" href="#个体数据导出" />
            <area shape="rect" coords="843,211,922,295" href="#团体数据导出" />
            <area shape="rect" coords="846,78,928,150" href="#复检通知" />
            <area shape="rect" coords="426,369,496,433" href="#结果录入" />
            <area shape="rect" coords="697,362,766,442" href="#报告打印" />
            <area shape="rect" coords="553,364,630,441" href="#体检总检" />
            <area shape="rect" coords="286,220,364,303" href="#指引单打印" />
            <area shape="rect" coords="283,380,366,436" href="#条码打印" />
            <area shape="rect" coords="282,69,369,156" href="#体检收费" />
            <area shape="rect" coords="149,468,245,549" href="#正式体检" />
            <area shape="rect" coords="164,600,260,681" href="#体检预约" />
            <area shape="rect" coords="26,600,122,681" href="#团体分组" />
            <area shape="rect" coords="30,468,126,549" href="#团体登记" />
        </map>
    </div>
</asp:Content>
