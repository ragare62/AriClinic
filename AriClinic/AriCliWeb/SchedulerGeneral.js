// Javascript functions related to Scheduler

var w;

function printDiary(dt, diary) {
    var url = "RptView.aspx?Report=rappointmentday&FDate=" + dt + "&Diary=" + diary;
    w = window.open(url, "rptview", "width=800,height=600,resizable=1");
    w.focus();
}

function openAppointment(url) {
    w = window.open(url, "scheduler", "width=600,height=700,resizable=1");
    w.focus();
}
function AppointmentEditing(sender, eventArgs) {
    //alert("Appointment Editing");
    var apt = eventArgs.get_appointment();
    var url = "AppointmentForm.aspx?AppointmentId=" + apt.get_id() + "&DiaryId=" + gup("DiaryId");
    openAppointment(url);
    eventArgs.set_cancel(true);
}

function AppointmentInserting(sender, eventArgs) {
    //alert("Appointment Inserting");
    var start = formatDate(eventArgs.get_startTime());
    //var isAllDay = eventArgs.get_isAllDay();
    var url = "AppointmentForm.aspx?BeginDateTime=" + start + "&DiaryId=" + gup("DiaryId");
    openAppointment(url);
    eventArgs.set_cancel(true);
}


function AppointmentMoveEnd(sender, eventArgs) {
    //alert("Appointment MoveEnd");
    var apt = eventArgs.get_appointment();
    var url = "AppointmentForm.aspx?AppointmentId=" + apt.get_id()
                        + "&BeginDateTime=" + formatDate(eventArgs.get_newStartTime());
    openAppointment(url);
    eventArgs.set_cancel(false);
}
function AppointmentResizeEnd(sender, eventArgs) {
    //alert("Appointment ResizeEnd");
    var apt = eventArgs.get_appointment();
    url = "AppointmentForm.aspx?AppointmentId=" + apt.get_id()
                    + "&BeginDateTime=" + formatDate(apt.get_start())
                    + "&EndDateTime=" + formatDate(eventArgs.get_newEndTime());
    openAppointment(url);
    eventArgs.set_cancel(false);
}
function padNumber(number, totalDigits) {
    number = number.toString();
    var padding = '';
    if (totalDigits > number.length) {
        for (i = 0; i < (totalDigits - number.length); i++) {
            padding += '0';
        }
    }

    return padding + number.toString();
}

function formatDate(date) {
    var year = padNumber(date.getFullYear(), 4);
    var month = padNumber(date.getMonth() + 1, 2);
    var day = padNumber(date.getDate(), 2);
    var hour = padNumber(date.getHours(), 2);
    var minute = padNumber(date.getMinutes(), 2);

    return year + month + day + hour + minute;
}

function refreshGrid() {
    var ajaxManager = $find("RadAjaxManager1");
    ajaxManager.ajaxRequest('RebindScheduler');
    w.close();
}
