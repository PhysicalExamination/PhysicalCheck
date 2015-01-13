<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage/ContentMasterPage.master" inherits="Left, App_Web_cw2w04oz" theme="redmond" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        $(function () {

            // Accordion
            $("#accordion").accordion({
                header: "h3",
                autoHeight: false,
                navigation: true
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
