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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server" >

<div id="mainshow">
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
        </div>
</asp:Content>
