<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>健康体检管理系统</title>
    <link href="Styles/Logon/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="Scripts/cloud.js"></script>
    <script type="text/javascript">
        $(function () {
            //云彩位移
            $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            $(window).resize(function () {
                $('.loginbox').css({ 'position': 'absolute', 'left': ($(window).width() - 692) / 2 });
            });
            $("#loginbtn").bind("click", loginbtn_Click);
            $("#UserPwd").keypress(function () {
                if (event.keyCode == 13) $("#loginbtn").click();
            });
            $.ajaxSetup({ error: onError, cache: false });
        });

        function loginbtn_Click() {
            var data = new Object();
            data.UserName = $("#UserName").val();
            data.Password = $("#UserPwd").val();
            var url = "Admin/Services.ashx?Action=UserLogin";
            $.post(url, data, successCallback, "json");
        }

        function successCallback(data) {
            if (data.Succeed) {
                top.location = data.Message;
                return;
            }
            alert(data.Message);
        }
        function onError(XMLHttpRequest, textStatus, errorThrown) {
            alert("服务器故障请稍后登录！");
        }
    </script>

</head>
<body style="background-color: #1c77ac; background-image: url(images/light.png);
    background-repeat: no-repeat; background-position: center top; overflow: hidden;">
    <div id="mainBody">
        <div id="cloud1" class="cloud">
        </div>
        <div id="cloud2" class="cloud">
        </div>
    </div>
    <div class="loginbody">
        <span class="systemlogo"></span>
        <form action="/" method="post">
        <div class="loginbox">
            <ul>
                <li>
                    <input class="loginuser"  id="UserName" name="UserName"
                        placeholder="请输入用户名" type="text" value="" />                   
                    </li>
                <li>
                    <input class="loginpwd" id="UserPwd"
                        name="UserPwd" placeholder="请输入密码" type="password" value="" />                  
                    </li>
                <li>
                    <input type="button" id="loginbtn" class="loginbtn" name="slogin" value="登录" />
                    <label>
                        <input checked="checked" id="RememberMe"
                            name="RememberMe" type="checkbox" value="true" />记住密码
                    </label>
                    <label>
                        <a href="javascript:;">忘记密码？</a>
                    </label>
                </li>
            </ul>
        </div>
        </form>
    </div>
    <div class="loginbm">
       Copyright © 2013 中国人民解放军第23医院&nbsp;&nbsp; 系统维护：中国人民解放军第四军医大学流行病教研室       
    </div>
</body>
</html>
