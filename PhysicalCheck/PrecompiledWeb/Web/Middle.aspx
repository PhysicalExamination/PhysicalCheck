<%@ page language="C#" autoeventwireup="true" inherits="Middle, App_Web_eth0igbe" theme="redmond" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>湖南省环保厅“三同时”管理平台</title>
     <script type="text/javascript" src="Scripts/jquery-1.8.3.js" >
     </script>
   
    <script type="text/javascript">
        var toggle = false;
        $(function () {
            var height = $(document).height();
            var img = document.getElementById("img");
            //$("#img").height(height);
            img.style.top = (height - 24) / 2 + "px";
        });

        $(window).resize(function () {
            var height = $(document).height();
            //$("#img").height(height);       
            img.style.top = (height - 24) / 2 + "px";
        });

        function Toggle() {
            var cols = parent.content.cols;
            if (toggle) {
                $("#img").attr("src", "images/arrow_right.png");
                parent.content.cols = "0,10,*";
            } else {
                $("#img").attr("src", "images/arrow_left.png");
                parent.content.cols = "245,10,*";
            }
            toggle = !toggle;
        }
        
    </script>
</head>
<body style="margin:0px" class="middle">
<img alt="" src="images/arrow_left.png" id="img" 
        style="position: absolute; top: 0px; left: 0px;cursor:hand;" onclick=" Toggle();" /> 
</body>
</html>
