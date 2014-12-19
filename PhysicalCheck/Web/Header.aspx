<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Header.aspx.cs" Inherits="Header" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>健康体检管理系统</title>
    <script language="javascript" type="text/javascript" src="js/InitialInput.js"></script>
    <link href="css/home.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <script language="javascript" type="text/javascript">

        function changedPassword() {
            var sFeatures = "dialogHeight:300px,dialogWidth:300px";
            var sURL = "Admin/UserChangePasswordPage.aspx?rand=" + Math.random()
            window.showModalDialog(sURL, "", sFeatures);
        }
        function logout() {
          var args = "";  
          var context="";
          <%=Callback %>;
          top.location="Default.aspx";
        }

        function processCallback(result, context) {
            
        } 
    </script>
    <form id="Form1" runat="server">
    </form>
    <div id="topmenu" class="l-topmenu">
        <div class="l-topmenu-logo">
        </div>
        <div class="l-topmenu-welcome">
            <span class="l-topmenu-username"><%=UserName%></span>，欢迎您！
        </div>
        <div class="l-topmenu-items">
            <img src="<%=imageBtnURL %>" alt="" align="middle" border="0" usemap="#Map" />
            <map name="Map" id="Map">
                <area shape="rect" coords="0,0,107,40" href="#" onclick="logout();" alt=""/>
                <area shape="rect" coords="107,0,222,40" href="#" onclick="changedPassword();" alt=""/>
            </map>
            <%-- <a href="#"></a>
            <img src="images/index/logout.png" alt="" align="middle" onclick="logout();" /><span onclick="logout();">注销</span>
            <img src="images/index/changepwd.png" alt="" align="middle" onclick="changedPassword();" /><span
                onclick="changedPassword();">修改密码</span>--%>
        </div>
    </div>
</body>
</html>
