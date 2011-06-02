// global variables //
var TIMER = 5;
var SPEED = 10;
var WRAPPER = 'content';
var DLGRESULT = 0;

// calculate the current window width //
function pageWidth()
{
    return window.innerWidth != null ? window.innerWidth : document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth : document.body != null ? document.body.clientWidth : null;
}

// calculate the current window height //
function pageHeight()
{
    return window.innerHeight != null ? window.innerHeight : document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight : document.body != null ? document.body.clientHeight : null;
}

// calculate the current window vertical offset //
function topPosition()
{
    return typeof window.pageYOffset != 'undefined' ? window.pageYOffset : document.documentElement && document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop ? document.body.scrollTop : 0;
}

// calculate the position starting at the left of the window //
function leftPosition()
{
    return typeof window.pageXOffset != 'undefined' ? window.pageXOffset : document.documentElement && document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft ? document.body.scrollLeft : 0;
}

// build/show the dialog box, populate the data and call the fadeDialog function //
function showDialog(title, message, type, autohide, v_width, v_height)
{
    if (!type)
    {
        type = 'error';
    }
    DLGRESULT = 0; // by default no answer
    var dialog;
    var dialogheader;
    var dialogclose;
    var dialogtitle;
    var dialogcontent;
    var dialogmask;
    var dialogfooter;
    if (!document.getElementById('dialog'))
    {
        dialog = document.createElement('div');
        dialog.id = 'dialog';
        dialogheader = document.createElement('div');
        dialogheader.id = 'dialog-header';
        dialogtitle = document.createElement('div');
        dialogtitle.id = 'dialog-title';
        dialogclose = document.createElement('div');
        dialogclose.id = 'dialog-close'
        dialogcontent = document.createElement('div');
        dialogcontent.id = 'dialog-content';
        dialogmask = document.createElement('div');
        dialogmask.id = 'dialog-mask';
        dialogfooter = document.createElement('div');
        dialogfooter.id = "dialog-footer";
        document.body.appendChild(dialogmask);
        document.body.appendChild(dialog);
        dialog.appendChild(dialogheader);
        dialogheader.appendChild(dialogtitle);
        dialogheader.appendChild(dialogclose);
        dialog.appendChild(dialogcontent);
        dialog.appendChild(dialogfooter);
        dialogclose.setAttribute('onclick', 'hideDialog()');
        dialogclose.onclick = hideDialog;
    }
    else
    {
        dialog = document.getElementById('dialog');
        dialogheader = document.getElementById('dialog-header');
        dialogtitle = document.getElementById('dialog-title');
        dialogclose = document.getElementById('dialog-close');
        dialogcontent = document.getElementById('dialog-content');
        dialogmask = document.getElementById('dialog-mask');
        dialogfooter = document.getElementById('dialog-footer');
        dialogmask.style.visibility = "visible";
        dialog.style.visibility = "visible";
    }
    if (v_width != 0)
        dialog.style.width = v_width + "px";
    if (v_height != 0)
        dialogcontent.style.height = v_height + "px";

    dialog.style.opacity = .00;
    dialog.style.filter = 'alpha(opacity=0)';
    dialog.alpha = 0;
    var width = pageWidth();
    var height = pageHeight();
    var left = leftPosition();
    var top = topPosition();
    var dialogwidth = dialog.offsetWidth;
    var dialogheight = dialog.offsetHeight;
    var topposition = top + (height / 3) - (dialogheight / 2);
    var leftposition = left + (width / 2) - (dialogwidth / 2);
    dialog.style.top = topposition + "px";
    dialog.style.left = leftposition + "px";
    dialogheader.className = type + "header";
    dialogtitle.innerHTML = title;
    dialogcontent.className = type;
    dialogcontent.innerHTML = message;
    if (!autohide) {
        if (type == 'prompt')
            dialogfooter.innerHTML = "<input id='btnOk' type='button' value='Aceptar' onclick='hideDialog(1)' />"
                             + "&nbsp;"
                             + "<input id='btnCancel' type='button' value='Cancelar' onclick='hideDialog(2)' />";
        else
            dialogfooter.innerHTML = "<input id='btnOk' type='button' value='Aceptar' onclick='hideDialog(2)' />"
        dialogfooter.className = type + "footer";
    }
    var content = document.getElementById(WRAPPER);
    dialogmask.style.height = content.offsetHeight + 'px';
    dialog.timer = setInterval("fadeDialog(1)", TIMER);
    if (autohide)
    {
        dialogclose.style.visibility = "hidden";
        window.setTimeout("hideDialog()", (autohide * 1000));
    }
    else
    {
        dialogclose.style.visibility = "visible";
    }
}

// hide the dialog box //
function hideDialog(r)
{
    var dialog = document.getElementById('dialog');
    clearInterval(dialog.timer);
    dialog.timer = setInterval("fadeDialog(0)", TIMER);
    DLGRESULT = r;
}

// fade-in the dialog box //
function fadeDialog(flag)
{
    if (flag == null)
    {
        flag = 1;
    }
    var dialog = document.getElementById('dialog');
    var value;
    if (flag == 1)
    {
        value = dialog.alpha + SPEED;
    }
    else
    {
        value = dialog.alpha - SPEED;
    }
    dialog.alpha = value;
    dialog.style.opacity = (value / 100);
    dialog.style.filter = 'alpha(opacity=' + value + ')';
    if (value >= 99)
    {
        clearInterval(dialog.timer);
        dialog.timer = null;
    }
    else if (value <= 1)
    {
        dialog.style.visibility = "hidden";
        document.getElementById('dialog-mask').style.visibility = "hidden";
        clearInterval(dialog.timer);
    }
}

// Additional functions

