<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    AutoEventWireup="true" CodeFile="ContentPage.aspx.cs" Inherits="ContentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        #checkeddiv {
            width: 1037px;
            height: 60px;
            background-color: #FFF;
            margin: 0 auto;
        }

            #checkeddiv a {
                float: left;
                display: block;
                width: 148px;
                height: 60px;
            }

        .aset:hover {
            background-color: #cccccc;
        }

        #mainshow {
            width: 100%;
            height: 100%;
            background-color: #FFF;
            margin-left: auto;
            margin-right: auto;
            margin-top: 2px;
        }

        img {
            border: 0;
        }

        .splitimgdiv {
            background-image: url(images/home/20.png);
            width: 47px;
            height: 47px;
            float: left;
            margin-top: 30px;
        }

        .showdiv {
            width: 1037px;
            height: 120px;
            margin-top: 60px;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">

    <%--<div id="mainshow">
            <div class="showdiv">
                <a id="p5" style="margin-left: 650px; float: left;" href="<%=CertificatePage%>">
                    <img alt="" src="images/home/5.png" /></a>
            </div>
            <div style="width: 200px; height: 60px; float: left; margin-left: 700px">
                <img src="images/home/21.png" alt="" />
            </div>
            <div style="width: 1037px">
                <a id="p1" style="margin-left: 47px; float: left;" href="<%=ChargePage%>">
                    <img alt="" src="images/home/1.png" /></a>
                <div class="splitimgdiv">
                </div>
                <a id="p2" style="float: left" href="<%=RegistrationPage%>">
                    <img alt="" src="images/home/2.png" /></a>
                <div class="splitimgdiv">
                </div>
                <a id="p3" style="float: left" href="<%=CheckResultInputPage%>">
                    <img alt="" src="images/home/3.png" /></a>
                <div class="splitimgdiv">
                </div>
                <a id="p4" style="float: left" href="<%=CertificatePage%>">
                    <img alt="" src="images/home/4.png" /></a>
                <div class="splitimgdiv">
                </div>
                <a id="p6" style="float: left" href="<%=IntegratedSearch%>">
                    <img alt="" src="images/home/6.png" /></a>
            </div>
            <div style="width: 200px; height: 60px; float: left; margin-left: 690px">
                <img src="images/home/22.png" alt="" />
            </div>
            <div style="width: 1037px">
                <a id="p7" style="margin-left: 550px; float: left" href="#">
                    <img alt="" src="images/home/7.png" /></a> <a id="p8" style="margin-left: 47px; float: left"
                        href="<%=OverallCheckedPage%>">
                        <img alt="" src="images/home/8.png" /></a>
            </div>
        </div>--%>
    <div style="margin: 0 auto; width: 800px">
        <img src="images/CDCMain.jpg" alt="" usemap="#Map"/>
        <map name="Map" id="Map">
            <area shape="rect" coords="641,150,737,252" href="#" target="_self" alt="报告打印" />
            <area shape="rect" coords="642,264,738,366" href="#" target="_self" alt="报告打印" />
            <area shape="rect" coords="639,30,735,132" href="#" target="_self" alt="报告打印" />
            <area shape="rect" coords="642,378,738,480" href="<%=CheckReport%>" target="_self" alt="报告打印" />
            <area shape="rect" coords="498,275,594,377" href="<%=CertificatePage%>" target="_self" alt="证卡打印" />
            <area shape="rect" coords="395,274,491,376" href="<%=OverallCheckedPage%>" target="_self" alt="体检总检" />
            <area shape="rect" coords="293,275,389,377" href="<%=CheckResultInputPage%>" target="_self" alt="结果录入" />
            <area shape="rect" coords="171,34,267,136" href="<%=RegistrationPage%>" target="_self" alt="体检登记" />
            <area shape="rect" coords="171,272,267,374" href="<%=BarCodePrint%>" target="_self" alt="条码打印" />
            <area shape="rect" coords="171,157,267,259" href="<%=IntroductionPrint%>" target="_self" alt="指引单打印" />
            <area shape="rect" coords="26,192,122,294" href="<%=ChargePage%>" target="_self" alt="体检收费" />
        </map>
    </div>
</asp:Content>
