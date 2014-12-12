function writeCookie(name, value) {
    document.cookie = name + "=" + escape(value) + "; path=/";
}

function readCookie(name) {
    var cookieValue = "";
    var search = name + "=";
    if (document.cookie.length > 0) {
        offset = document.cookie.indexOf(search);
        if (offset != -1) {
            offset += search.length;
            end = document.cookie.indexOf(";", offset);
            if (end == -1) end = document.cookie.length;
            cookieValue = unescape(document.cookie.substring(offset, end))
        }
    }
    return cookieValue;
}

function openDetailWindow(sEnterpriseID, sEnterpriseName,sURL) {
    writeCookie("EnterpriseID", sEnterpriseID);
    writeCookie("EnterpriseName", sEnterpriseName);
    var height = screen.availHeight;
    var width = screen.availWidth;
    window.showModalDialog(sURL, null, "dialogHeight:" + height +",dialogWidth:" + width);    
}