<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<html>
<head id="Head1" runat="server">
    <title>健康体检管理系统</title>
</head>
<frameset rows="67,*" frameborder="no" border="0" framespacing="0">
	<frame src="Header.aspx" noresize="noresize" frameborder="no" name="topFrame" scrolling="no" marginwidth="0" marginheight="0" target="main" />
  <frameset cols="245,10,*"  id="content">
	<frame src="Left.aspx" id="leftFrame" name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="0" scrolling="auto" target="main" />
	<frame src="Middle.aspx" id="middleFrame"  noresize="noresize" marginwidth="0" marginheight="0" frameborder="0" scrolling="no"/>
	<frame src="ContentPage.aspx" id="mainFrame" name="mainFrame" marginwidth="0" marginheight="0" frameborder="0" scrolling="auto" target="_self" />
  </frameset>
</frameset>

</html>
