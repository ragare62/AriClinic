// Refresh the grid in caller
function CloseAndRebind(arg)
{
    window.opener.refreshGrid(arg);
    window.close();
    return false;
}
// Close current window and nothing more
function CancelEdit()
{
    window.close();
}
// gup stands from Get Url Parameters
function gup(name)
{
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.href);
    if (results == null)
        return "";
    else
        return results[1];
}
// call service grid in order to select one
function searchService()
{
    var w1 = window.open("ServiceGrid.aspx?Type=S", "SER", "width=800, height=600,resizable=1");
    w1.focus();
}
function searchPatient()
{
    var w1 = window.open("PatientGrid.aspx?Type=S", "PAT", "width=600, height=500,resizable=1");
    w1.focus();
}
function searchInsuranceService(insuranceId)
{
    var w1 = window.open("InsuranceServiceGrid.aspx?Type=S" + "&InsuranceId=" + insuranceId, "INSURANCESERVICE", "width=600, height=500,resizable=1");
    w1.focus();
}
function searchTicket(customerId)
{
    var w1 = window.open("TicketGrid.aspx?Type=S&CustomerId=" + customerId, "TICKET", "width=1000, height=500,resizable=1");
    w1.focus();
}
function searchTicketAll()
{
    var w1 = window.open("TicketGrid.aspx?Type=S&NotPaid=yes", "TICKET", "width=1000, height=500,resizable=1");
    w1.focus();
}
function searchCustomer()
{
    var w1 = window.open("CustomerGrid.aspx?Type=S", "CUSTOMERG", "width=600, height=500,resizable=1");
    w1.focus();
}
function searchProfessional()
{
    var w1 = window.open("ProfessionalGrid.aspx?Type=S", "PROFESSIONALSG", "width=600, height=500,resizable=1");
    w1.focus();
}
function searchProfessional2()
{
    var w1 = window.open("ProfessionalGrid.aspx?Type=S&CallNumber=2", "PROFESSIONALS2", "width=600, height=500,resizable=1");
    w1.focus();
}
function searchProcedure()
{
    var w1 = window.open("ProcedureGrid.aspx?Type=S", "PROCEDURES", "width=600, height=500,resizable=1");
    w1.focus();
}
function searchProcedure1()
{
    var w1 = window.open("ProcedureGrid.aspx?Type=S&CallNumber=1", "PROCEDURES", "width=600, height=500,resizable=1");
    w1.focus();
}
function searchProcedure2()
{
    var w1 = window.open("ProcedureGrid.aspx?Type=S&CallNumber=2", "PROCEDURES", "width=600, height=500,resizable=1");
    w1.focus();
}
function searchDiary()
{
    var w1 = window.open("DiaryGrid.aspx?Type=S", "DIARIES", "width=600,height=500,resizable=1");
    w1.focus();
}
function searchAppointmentType()
{
    var w1 = window.open("AppointmentTypeGrid.aspx?Type=S", "APPOINTMENTS", "width=600,height=500,resizable=1");
    w1.focus();
}
function searchDiagnostic()
{
    var w1 = window.open("DiagnosticGrid.aspx?Type=S", "DIAGNOSTICS", "width=500,height=400,resizable=1");
    w1.focus;
}
function searchDrug()
{
    var w1 = window.open("DrugGrid.aspx?Type=S", "DRUGS", "width=500,height=400,resizable=1");
    w1.focus;
}
function searchExamination(arg)
{
    var w1;
    if (!arg)
    {
        w1 = window.open("ExaminationGrid.aspx?Type=S", "EXAMINATIONS", "width=800,height=400,resizable=1");
    }
    else
    {
        w1 = window.open("ExaminationGrid.aspx?Type=S&GT=" + arg, "EXAMBYTYPE", "width=500,height=400,resizable=1");
    }
    w1.focus;
}
function searchLabTest()
{
    var w1 = window.open("LabTestGrid.aspx?Type=S", "LABTESTS", "width=800,height=500,resizable=1");
    w1.focus;
}

