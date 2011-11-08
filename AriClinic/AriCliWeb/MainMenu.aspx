<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="MainMenu" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      AriClinic Menu Prinicipal
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
<style type="text/css">
#AuxControls
{
z-index: 1;
left: 10px;
top: 700px;
position: absolute;
height: 44px;
width: 1007px;
}
.style1
{
width: 94px;
height: 30px;
}
</style>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico"/>
  </head>
  <body>
    <form id="form1" runat="server">
      <div id="AuxControls">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
          <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
          </Scripts>
        </telerik:RadScriptManager>
        <script type="text/javascript">
          //Put your JavaScript code here.
          function LaunchUserGroup()
          {
              var w1 = window.open("UserGroupGrid.aspx", "USG", "width=470, height=380,resizable=1")
              w1.focus();
          }
          function LaunchUser()
          {
              var w1 = window.open("UserGrid.aspx", "US", "width=470, height=380,resizable=1")
              w1.focus();
          }
          function LaunchProcess()
          {
              var w1 = window.open("ProcessGrid.aspx", "PR", "width=470, height=380,resizable=1")
              w1.focus();
          }
          function LaunchPermission()
          {
              var w1 = window.open("PermissionGrid.aspx", "PE", "width=600, height=490,resizable=1")
              w1.focus();
          }
          function LaunchHc(id)
          {
              var w1 = window.open("HealthCareCompanyForm.aspx?HcId=" + id, "HC", "width=750, height=604,resizable=1")
              w1.focus();
          }
          function LaunchClinic()
          {
              var w1 = window.open("ClinicGrid.aspx", "CL", "width=470, height=380,resizable=1")
              w1.focus();
          }
          function LaunchServiceCategory()
          {
              var w1 = window.open("ServiceCategoryGrid.aspx", "SCAT", "width=470, height=380,resizable=1")
              w1.focus();
          }
          function LaunchPaymentMethod()
          {
              var w1 = window.open("PaymentMethodGrid.aspx", "PAYMENTMETHOD", "width=470, height=380,resizable=1")
              w1.focus();
          }
          function LaunchTaxType()
          {
              var w1 = window.open("TaxTypeGrid.aspx", "TAXT", "width=470, height=380,resizable=1")
              w1.focus();
          }
          function LaunchTaxWithholdingType()
          {
              var w1 = window.open("TaxWithholdingTypeGrid.aspx", "TAXWT", "width=470, height=380,resizable=1")
              w1.focus();
          }
          function LaunchService()
          {
              var w1 = window.open("ServiceGrid.aspx", "SER", "width=800, height=600,resizable=1")
              w1.focus();
          }
          function LaunchInsurance()
          {
              var w1 = window.open("InsuranceGrid.aspx", "INS", "width=450, height=400,resizable=1")
              w1.focus();
          }
          function LaunchPatient()
          {
              var w1 = window.open("PatientGrid.aspx", "PAT", "width=600, height=500,resizable=1")
              w1.focus();
          }
          function LaunchProfessional()
          {
              var w1 = window.open("ProfessionalGrid.aspx", "PROFESSIONAL", "width=600, height=500,resizable=1")
              w1.focus();
          }
          function LaunchCustomer()
          {
              var w1 = window.open("CustomerGrid.aspx", "CUSTOMER", "width=600, height=500,resizable=1")
              w1.focus();
          }
          function LaunchTicket()
          {
              var w1 = window.open("TicketGrid.aspx", "TICKET", "fullscreen=yes,resizable=1")
              w1.focus();
          }
          function LaunchSettlement()
          {
              var w1 = window.open("SettlementGrid.aspx", "SETTLEMENT", "fullscreen=yes,resizable=1")
              w1.focus();
          }
          function LaunchChecks() {
              var w1 = window.open("SettlementGrid.aspx?type=comprobante", "CHECKS", "fullscreen=yes,resizable=1")
              w1.focus();
          }
          function LaunchInvoice()
          {
              var w1 = window.open("InvoiceGrid.aspx", "INVOICE", "fullscreen=yes,resizable=1")
              w1.focus();
          }
          function LaunchPayment()
          {
              var w1 = window.open("PaymentGrid.aspx", "PAYMENT", "fullscreen=yes,resizable=1")
              w1.focus();
          }
          function LaunchRTickets()
          {
              var w1 = window.open("RptTicketsForm.aspx", "RTICKETS", "width=440, height=230,resizable=1")
              w1.focus();
          }
          function LaunchRPayments()
          {
              var w1 = window.open("RptPaymentsForm.aspx", "RPAYMENTS", "width=440, height=230,resizable=1")
              w1.focus();
          }
          function LaunchProcedure()
          {
              var w1 = window.open("ProcedureGrid.aspx", "PROCEDURE", "width=580, height=380,resizable=1")
              w1.focus();
          }
          function LaunchAnestheticServiceNote()
          {
              var w1 = window.open("AnestheticServiceNoteGrid.aspx", "ASN", "width=850, height=500,resizable=1")
              w1.focus();
          }
          function LaunchServiceNote()
          {
              var w1 = window.open("ServiceNoteGrid.aspx", "SN", "width=850, height=500,resizable=1")
              w1.focus();
          }
          function LaunchParameter()
          {
              var w1 = window.open("ParameterForm.aspx", "PARAMETER", "width=400, height=300,resizable=1")
              w1.focus();
          }
          function LaunchRProfessionalSrv()
          {
              var w1 = window.open("RptProfessionalSrvForm.aspx", "RPROFESSONALSRV", "width=440, height=300,resizable=1")
              w1.focus();
          }
          function LaunchRSurgeonSrv() {
              var w1 = window.open("RptSurgeonSrvForm.aspx", "RSURGEONSRV", "width=440, height=300,resizable=1")
              w1.focus();
          }
          function LaunchRCategorySrv()
          {
              var w1 = window.open("RptCategorySrvForm.aspx", "RCATEGORYSRV", "width=440, height=280,resizable=1")
              w1.focus();
          }
          function LaunchRComparerPrices()
          {
              var w1 = window.open("RptView.aspx?Report=compprices", "RCOMPPRI", "width=800, height=600,resizable=1");
              w1.focus();
          }
          function Launchrnomenclator()
          {
              var w1 = window.open("RptView.aspx?Report=nomenclator", "RNOMEN", "width=800, height=600,resizable=1");
              w1.focus();
          }
          function LaunchRInvoicesPeriod()
          {
              var w1 = window.open("RptInvoicePeriodForm.aspx", "RINVPERIOD", "width=440, height=300,resizable=1")
              w1.focus();
          }
          function LaunchRPatientDebt()
          {
              var w1 = window.open("RptView.aspx?Report=patdebt", "RPATDEBT", "width=800, height=600,resizable=1");
              w1.focus();
          }
          function LaunchRInsuranceDebt()
          {
              var w1 = window.open("RptView.aspx?Report=insurdebt", "RINSUDEBT", "width=800, height=600,resizable=1");
              w1.focus();
          }
          function LaunchAgenda()
          {
              var w1 = window.open("DiaryGrid.aspx", "AGENDA", "width=580, height=380,resizable=1")
              w1.focus();
          }
          function LaunchAppointmentType()
          {
              var w1 = window.open("AppointmentTypeGrid.aspx", "APPTYPE", "width=580, height=380,resizable=1")
              w1.focus();
          }
          function LaunchAppointment()
          {
              var w1 = window.open("AppointmentGrid.aspx", "APPOINTMENT", "fullscreen=yes,resizable=1")
              w1.focus();
          }
          function LaunchDocuments() {
              var w1 = window.open("DocumentsPatient.aspx", "DOCS", "width=800, height=600,resizable=1")
              w1.focus();
          }
          function LaunchDiagnostic() {
              var w1 = window.open("DiagnosticGrid.aspx", "DIAGNOSTIC", "width=500, height=500,resizable=1")
              w1.focus();
          }
          function LaunchDiagnosticAssigned() {
              var w1 = window.open("DiagnosticAssignedGrid.aspx", "DIAGNOSTICASSIGNED", "width=800, height=600,resizable=1")
              w1.focus();
          }
          function LaunchDrug() {
              var w1 = window.open("DrugGrid.aspx", "DRUG", "width=500, height=500,resizable=1")
              w1.focus();
          }
          function LaunchTreatment() {
              var w1 = window.open("TreatmentGrid.aspx", "TREATMENTS", "width=800, height=600,resizable=1")
              w1.focus();
          }
          function LaunchExamination() {
              var w1 = window.open("ExaminationGrid.aspx", "EXAMINATIONS", "width=500, height=500,resizable=1")
              w1.focus();
          }
          function LaunchExaminationAssigned() {
              var w1 = window.open("ExaminationAssignedGrid.aspx", "EXAMINATIONASSIGNED", "width=800, height=600,resizable=1")
              w1.focus();
          }
          function LaunchUnitType() {
              var w1 = window.open("UnitTypeGrid.aspx", "UNITTYPE", "width=500, height=500,resizable=1")
              w1.focus();
          }

          function LaunchProfiIvoice() {
              var w1 = window.open("ProfessionalInvoiceGrid.aspx","PROFINV", "fullscreen=yes,resizable=1")
              w1.focus();
          }

          function LaunchProfInvoices() {
              var w1 = window.open("RptProfessionalInvoicesForm.aspx", "PROFINVS", "width=440, height=300,resizable=1")
              w1.focus();
          }
        </script>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadSkinManager ID="RadSkinManager1" runat="server">
        </telerik:RadSkinManager>
      </div>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <div id="TitleArea">
          <table class="titleBar">
            <tr>
              <td>
                <asp:Label ID="lblHealthcareCompany" runat="server" Text="Empresa sanitaria"></asp:Label>
              </td>
              <td>
                <img align="right" alt="logo" class="style1" src="images/logo_web_30.png" />
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="lblUser" runat="server" Text="Usuario: Nombre usuario"></asp:Label>
              </td>
              <td align="right">
                <asp:Label ID="lblDeveloper" runat="server" Text="(c) Ariadna Software S.L." CssClass="titleSmallText"></asp:Label>
              </td>
            </tr>
          </table>
        </div>
        <div id="MenuArea">
          <telerik:RadMenu ID="RadMenu1" runat="server" Width="100%"
                           onitemclick="RadMenu1_ItemClick" 
                style="top: 0px; left: 0px; height: 34px">
            <Items>
              <telerik:RadMenuItem runat="server" Text="Administración" Value="admin">
                <Items>
                  <telerik:RadMenuItem runat="server" Text="Interna" Value="admint">
                    <Items>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Grupos de usuarios" Value="usergroup">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Usuarios" Value="user">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Procesos" Value="process">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Permisos" Value="permission">
                      </telerik:RadMenuItem>
                    </Items>
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Parámetros" Value="parameter">
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Empresa" Value="helcom">
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Clinicas" Value="clinic">
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Pacientes" Value="patient">
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Profesionales" Value="professional">
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Procedimientos" Value="procedure">
                  </telerik:RadMenuItem>
                </Items>
              </telerik:RadMenuItem>
              <telerik:RadMenuItem runat="server" Text="Facturación" 
                                   Value="invoicing">
                <Items>
                  <telerik:RadMenuItem runat="server" Text="Datos base" Value="basedata">
                    <Items>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Tipos de IVA" Value="taxt">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Tipos de retención" 
                                           Value="taxwt">
                      </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Owner="" Text="Formas de pago" 
                            Value="paymentmethod">
                        </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" 
                                           Text="Categorias de servicios médicos" Value="scat">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Servicios médicos" 
                                           Value="ser">
                      </telerik:RadMenuItem>
                    </Items>
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Aseguradoras" Value="ins">
                  </telerik:RadMenuItem >
                  <telerik:RadMenuItem runat="server" Text="Clientes" Value="customer">
                  </telerik:RadMenuItem >
                  <telerik:RadMenuItem runat="server" Text="Tickets" Value="ticket">
                  </telerik:RadMenuItem >
                  <telerik:RadMenuItem runat="server" Text="Notas de servicio (General)" Value="servicenote">
                  </telerik:RadMenuItem >
                  <telerik:RadMenuItem runat="server" Text="Notas de servicio (Anestesia)" Value="asn">
                  </telerik:RadMenuItem >
                  <telerik:RadMenuItem runat="server" Text="Facturas" Value="invoice">
                  </telerik:RadMenuItem >
                  <telerik:RadMenuItem runat="server" Text="Cobros" Value="payment">
                  </telerik:RadMenuItem >
                  <telerik:RadMenuItem runat="server" Text="Liquidaciones" Value="settlement">
                  </telerik:RadMenuItem >
                  <telerik:RadMenuItem runat="server" Text="Comprobantes" Value="checks">
                  </telerik:RadMenuItem >
                    <telerik:RadMenuItem runat="server" Text="Profesionales" Value="profInvoice">
                    </telerik:RadMenuItem>
                </Items>
              </telerik:RadMenuItem>
              <telerik:RadMenuItem runat="server" Text="Citación" Value="citation">
                <Items>
                  <telerik:RadMenuItem runat="server" Text="Agendas" Value="agenda">
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Tipos de cita" Value="apptype">
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Citas" Value="appointment">
                  </telerik:RadMenuItem>
                </Items>
              </telerik:RadMenuItem>
              <telerik:RadMenuItem runat="server" Text="Informes" Value="reports">
                <Items>
                  <telerik:RadMenuItem runat="server" Text="Facturación" Value="invoicing">
                    <Items>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Tickets emitidos" 
                                           Value="rtickets">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Cobros realizados" 
                                           Value="rpayments">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Facturas emitidas" 
                                           Value="rinvoicesPeriod">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="Facturas de profesionales" 
                                           Value="profInvoices">
                      </telerik:RadMenuItem>
                    </Items>
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Adeudos" Value="debt">
                    <Items>
                      <telerik:RadMenuItem runat="server" Owner="" Text="de pacientes" 
                                           Value="rpatientdebt">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Owner="" Text="de aseguradoras" 
                                           Value="rinsurancedebt">
                      </telerik:RadMenuItem>
                    </Items>
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Servicios" Value="rservices">
                    <Items>
                      <telerik:RadMenuItem runat="server" Text="por profesional" Value="rprofessionalsrv">
                      </telerik:RadMenuItem>
                       <telerik:RadMenuItem runat="server" Text="por cirujano" Value="rsurgeonsrv">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Text="por categoria" Value="rcategorysrv">
                      </telerik:RadMenuItem>
                      <telerik:RadMenuItem runat="server" Text="comparativa de precios" Value="rsrvcomparer">
                      </telerik:RadMenuItem>
                    </Items>
                  </telerik:RadMenuItem>
                  <telerik:RadMenuItem runat="server" Text="Nomenclator" Value="rnomenclator">
                  </telerik:RadMenuItem>
                </Items>
              </telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" Text="Historia Clinica" 
                    Value="clinicalrecord">
                    <Items>
                        <telerik:RadMenuItem runat="server" Text="Datos básicos" Value="basedata">
                            <Items>
                                <telerik:RadMenuItem runat="server" Text="Diagnósticos" Value="diagnostic">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="Fármacos" Value="drug">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="Exploración" Value="examination">
                                </telerik:RadMenuItem>
                                <telerik:RadMenuItem runat="server" Text="Unidades de medida" Value="unittype">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Documentos" Value="docs">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Diagnósticos asignados" 
                            Value="diagnosticassigned">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Tratamientos" Value="treatment">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" Text="Exploraciones asignadas" 
                            Value="examinationassigned">
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
              <telerik:RadMenuItem runat="server" Text="Salir" Value="exit">
              </telerik:RadMenuItem>
            </Items>
          </telerik:RadMenu>
        </div>
        <div id="ToolArea">
          <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%" 
                              Skin="Office2007" onbuttonclick="RadToolBar1_ButtonClick">
            <Items>
              <telerik:RadToolBarSplitButton runat="server" Text="Personas" Value="person">
                <Buttons>
                  <telerik:RadToolBarButton runat="server" 
                                            ImageUrl="~/images/toolbar/users_family.png" Text="Pacientes" Value="patient">
                  </telerik:RadToolBarButton>
                  <telerik:RadToolBarButton runat="server" ImageUrl="~/images/toolbar/users3.png" 
                                            Text="Clientes" Value="customer">
                  </telerik:RadToolBarButton>
                </Buttons>
              </telerik:RadToolBarSplitButton>
              <telerik:RadToolBarSplitButton runat="server" Text="Agendas" Value="diary">
                <Buttons>
                  <telerik:RadToolBarButton runat="server" ImageUrl="~/images/toolbar/books.png" 
                                            Text="Agendas (Todas)" Value="agenda">
                  </telerik:RadToolBarButton>
                </Buttons>
              </telerik:RadToolBarSplitButton>
              <telerik:RadToolBarSplitButton runat="server" 
                                             ImageUrl="~/images/toolbar/calculator.png" Text="Notas de servicio">
                <Buttons>
                  <telerik:RadToolBarButton runat="server" 
                                            ImageUrl="~/images/toolbar/calculator.png" 
                                            Text="N.Servi. (General)" Value="servicenote">
                  </telerik:RadToolBarButton>
                  <telerik:RadToolBarButton runat="server" 
                                            ImageUrl="~/images/toolbar/calculator.png" 
                                            Text="N.Servi (Anestesia)" Value="asn">
                  </telerik:RadToolBarButton>
                </Buttons>
              </telerik:RadToolBarSplitButton>
                <telerik:RadToolBarButton runat="server" 
                    ImageUrl="~/images/toolbar/creditcards.png" Text="Cobros" Value="payment">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" 
                    ImageUrl="~/images/toolbar/cabinet.png" Text="Documentos" Value="docs">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton runat="server" ImageUrl="~/images/toolbar/exit.png" 
                    Text="Salir" Value="exit">
                </telerik:RadToolBarButton>
            </Items>
          </telerik:RadToolBar>
        </div>
        <div id="MainArea">

          <table style="width:100%;">
            <tr>
              <td class="leftColumnStyle" style="width:10%;" >

              </td>
              <td>
                <div id="lgAriclinic">
                  <asp:Image ID="imgAriClinic" runat="server" 
                             ImageUrl="~/images/logo_blanco_horizontal_w200.png" />
              
                </div>
                <br />
                <div id="labelW" class="wellcomeLabel">
                  <asp:Label ID="lblWellcome" runat="server" Text="Bienvenida, bienvenido."></asp:Label>
                </div>
                <br />
                <div id="textW">
                <p class="wellcomeText">
                    Le recordamos que como usuario de la aplicación AriClinic, usted está sujeto a 
                    las obligaciones que impone la Ley Orgánica de Protección de Datos de carácter 
                    personal (LOPD) y el reglamento de aplicación propio de su empresa. En especial, 
                    la obligación de respetar la confidencialidad de los datos de sus pacientes.
                </p>
                <br />
                <p class="wellcomeText">
                Si no es usuario autorizado de la aplicación, o tiene dudas, debe salir ahora y dirigirse al Responsable del Fichero en su organización.
                </p>
                  

                </div>
              </td>
            </tr>
          </table>

        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
