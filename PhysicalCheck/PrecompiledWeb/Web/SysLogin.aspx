<%@ page language="C#" masterpagefile="~/MasterPage/ContentMasterPage.master" autoeventwireup="true" inherits="SysLogin, App_Web_eth0igbe" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .textBoxinputCss
        {
            line-height: 25px;
            height: 25px;
            width: 200px;
            background-color: #FFF;
            border: 1px solid #73A027;
        }
        
        .textBoxinputCssAlt
        {
            line-height: 25px;
            height: 25px;
            width: 200px;
            background-color: #FFFFCC;
            border: 1px solid #3A9AC0;
        }
        
        .labelCss
        {
            color: #73A027;
            font-size: 16px;
            text-align: center;
        }
        
        #login_box
        {
            margin-top: 50px;
            margin-left: 0px;
            padding-left: 0px;
        }
        
        #Bar
        {
            background-image: url(images/login/Bar.png);
            background-repeat: no-repeat;
            width: 332px;
            height: 222px;
            border-width: 0px;
        }
        
        #Container
        {
            width: 1001px;
            height: 456px;
        }
        
        #Footer
        {
            text-align: center;
            color: #558B1C;
            font-size: 14px;
            line-height: 150%;
            width: 1001px;
        }
        .Login
        {
            background: url(images/login/login_Button.png);
            background-repeat: no-repeat;
            border-width: 0;
            line-height: 38px;
            width:135px;
            cursor: hand;
        }
        
        .LoginAlt
        {
            background: url(images/login/login_Button_alt.png);
            background-repeat: no-repeat;
            border-width: 0;
             width:135px;
             height:38px;
            line-height: 38px;
            cursor: hand;
        }
    </style>
    <script type="text/javascript">

      $(function () {
            $(window).bind("resize", windowResize);
            //$("#btnLogin").bind(click,btnLogin_onclick);
            $("input").hover(
	          function () {
	              $(this).addClass("textBoxinputCssAlt");
                 
	          },
	          function () {
	              $(this).removeClass("textBoxinputCssAlt");                 
	          }
	  );     
      $("#btnLogin").hover(
	      function () {
	          //$(this).attr("src", "images/login/login_Button_alt.png");
               $(this).addClass("Login");
               $(this).removeClass("LoginAlt");
	      },
	      function () {
	         // $(this).attr("src", "images/login/login_Button.png");            
              $(this).addClass("LoginAlt");
              $(this).removeClass("Login");
	      }
	);
            windowResize();
        });

        function windowResize() {
            var left = ($(window).width() - $("#Container").outerWidth()) / 2;
            var top = ($(window).height() - $("#Container").outerHeight()) / 2;
            $("#Container").css({
                position: "absolute",
                left: left,
                top: top
            });
            $("#Bar").css({ position: "absolute", top: top, left: left + 600 });
            $("#Footer").css({ position: "absolute", top: top + 460, left: left });
        }

         function btnLogin_onclick() {
            var argument = $("#txtUsername").val() + "," + $("#txtPassword").val();
            <%=ClientCallback %>; 
        }

        function btnCancel_onclick(){
           $("#txtUsername").val("");
           $("#txtPassword").val("");
        }
        
        function processCallback(result,context){ 
            if (result!="") top.location = result;
            if (result =="") alert("用户名或密码不正确请重新输入！");             
        }
        
        $(function(){
            $("#txtPassword").keypress(function(){                
                if(event.keyCode==13) $("#btnLogin").click();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server" ClientIDMode="Static">
    <div id="Container" align="center">
        <img src="images/login/bg.png" /></div>
    <div id="Bar" align="center">
        <div id="login_box">
            <strong class="labelCss">用户名&nbsp;&nbsp;</strong>
            <%--<input type="text" id="txtUsername" class="textBoxinputCss" />--%>
            <asp:TextBox ID="txtUsername" CssClass="textBoxinputCss" runat="server" />
            <br />
            <br />
            <strong class="labelCss">密&nbsp;&nbsp;码&nbsp;&nbsp;</strong>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="textBoxinputCss" TextMode="Password" />
            <%--<input type="password" id="txtPassword" class="textBoxinputCss" />--%>
            <br />
            <br />
            <asp:Button ID="btnLogin" CssClass="LoginAlt" Width="135" Height="38" 
                runat="server" onclick="btnLogin_Click" />
            <%--<img id="btnLogin" src="images/login/login_Button.png" style="cursor: hand;" alt="" onclick="btnLogin_onclick();" />--%>
        </div>
    </div>
    <div id="Footer" align="center">
        Copyright © 2013 武威市疾病预防控制中心<br />
        系统维护：西安北坤电子科技有限公司
    </div>
    <script type="text/javascript">
        windowResize();
    </script>
</asp:Content>
