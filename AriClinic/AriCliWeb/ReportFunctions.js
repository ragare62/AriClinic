function reportTickets(fromDate, toDate, insuranceId, voucher)
{
    var w1 = window.open("RptView.aspx?Report=tickets"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         + "&InsuranceId=" + insuranceId
                         + "&Voucher=" + voucher
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportTicketsPaid(fromDate, toDate, insuranceId, voucher) {
    var w1 = window.open("RptView.aspx?Report=ticketspaid"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         + "&InsuranceId=" + insuranceId
                         + "&Voucher=" + voucher
                         , "RTICKETSP2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportTicketsNoPaid(fromDate, toDate, insuranceId, voucher) {
    var w1 = window.open("RptView.aspx?Report=ticketsnopaid"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         + "&InsuranceId=" + insuranceId
                         + "&Voucher=" + voucher
                         , "RTICKETSNP2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportPayments(fromDate, toDate, clinicId) {
    var w1 = window.open("RptView.aspx?Report=payments"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         + "&ClinicId=" + clinicId
                         , "RPAYMENTS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportProfesionalSrv(fromDate, toDate, prof) {
    var w1 = window.open("RptView.aspx?Report=professionalsrv"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         +"&Professional="+ prof
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportSurgeonSrv(fromDate, toDate, prof) {
    var w1 = window.open("RptView.aspx?Report=surgeonsrv"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         + "&Professional=" + prof
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportCategorySrv(fromDate, toDate) {
    var w1 = window.open("RptView.aspx?Report=categorysrv"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportTicket(idTicket) {
    var w1 = window.open("RptView.aspx?Report=ticket"
                         + "&idTicket=" + idTicket
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportServiceNote(idServNote) {
    var w1 = window.open("RptView.aspx?Report=servicenote"
                         + "&idServNote=" + idServNote
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
} 
function reportAnesNote(idAntesNote) {
    var w1 = window.open("RptView.aspx?Report=anesthesicnote"
                         + "&idAnesNote=" + idAntesNote
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportInvoice(invoice) {
    var w1 = window.open("RptView.aspx?Report=invoice"
                         + "&Invoice=" + invoice
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportServiceComp() {
    var w1 = window.open("RptView.aspx?Report=servicecomp"
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}

function reportInvoicePeriod(fromDate, toDate) {
    var w1 = window.open("RptView.aspx?Report=invoicePeriod"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         , "RINVPERIOD2", "width=800, height=600,resizable=1");
    w1.focus();
}

function reportPatientInvoice(toDate) {
    var w1 = window.open("RptView.aspx?Report=patientinvoice"
                         + "&ToDate=" + toDate
                         , "RPATINV2", "width=800, height=600,resizable=1");
    w1.focus();
}

function reportParamInvoice(fromDate, toDate) {
    var w1 = window.open("RptView.aspx?Report=paraminvoice"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         , "RTICKETS2", "width=800, height=600,resizable=1");
    w1.focus();
}
function reportprofessionalinvoices(fromDate, toDate, prof) {
    var w1 = window.open("RptView.aspx?Report=professionalinvoices"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         +"&Professional="+ prof
                         , "RINVOICE", "width=800, height=600,resizable=1");
    w1.focus();
}
function RptPCEAForm(fromDate, toDate) {
    var w1 = window.open("RptView.aspx?Report=bombasPCEA"
                         + "&FromDate=" + fromDate
                         + "&ToDate=" + toDate
                         , "RPCEA", "width=800, height=600,resizable=1");
    w1.focus();
}