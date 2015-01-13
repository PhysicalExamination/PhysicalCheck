// JScript 文件
function fEvent(sType, oInput) {
    switch (sType) {
        case "focus":
            oInput.isfocus = true;
            oInput.style.backgroundColor = '#FFFFD8';
        case "mouseover":
            oInput.style.borderColor = '#99E300';
            oInput.style.borderWidth = 1;
            break;
        case "blur":
            oInput.isfocus = false;
            oInput.style.backgroundColor = "";
        case "mouseout":
            if (!oInput.isfocus) {
                oInput.style.borderColor = '#97C8FB';
                oInput.style.borderWidth = 1;
            }
            break;
    }
}

function InitialInput() {
    var InputList = window.document.getElementsByTagName("input");
    for (var i = 0; i < InputList.length; i++) {
        if ((InputList[i].type == "button") || ((InputList[i].type == "submit")) || ((InputList[i].type == "reset")))
        {
            InputList[i].className = "buttonCss";
            InputList[i].onmouseout = new Function("this.className='buttonCss'");
            InputList[i].onmouseover = new Function("this.className='buttonaltCss'");		    
        }

        if (InputList[i].type == "text") {
            InputList[i].onblur = new Function("fEvent(\"blur\",this)");
            InputList[i].onmouseover = new Function("fEvent(\"mouseover\",this)");
            InputList[i].onfocus = new Function("fEvent(\"focus\",this)");
            InputList[i].onmouseout = new Function("fEvent(\"mouseout\",this)");
        }
    }
}

