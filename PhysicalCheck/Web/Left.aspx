<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/ContentMasterPage.master"
    CodeFile="Left.aspx.cs" Inherits="Left"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        $(function () {

            // Accordion
            $("#accordion").accordion({
                header: "h3",
                autoHeight: false,
                navigation: true,
                collapsible: true
            });
            $("div span").addClass("menuItem");
            $("div span").click(function () {
                $("div span").removeClass("ItemSelected");
                $(this).addClass("ItemSelected");
                var url = $(this).attr("href");
                var target = $(this).attr("target");
                if (url == null) return;
                open(url, target, null, false);
                //alert($(this).attr("href"));
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
     <asp:Literal ID="lblMenu" runat="server" />    
</asp:Content>
