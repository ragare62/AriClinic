<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentForm.aspx.cs" Inherits="AppointmentForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Cita
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
        <link href="dialog_box.css" rel="Stylesheet" type="text/css" />
    </head>
    <body id="content">
        <form id="form1" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <%--Needed for JavaScript IntelliSense in VS2010--%>
                    <%--For VS2008 replace RadScriptManager with ScriptManager--%>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>
            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                <script type="text/javascript" src="GeneralFormFunctions.js"></script>
                <script type="text/javascript" src="dialog_box.js"></script>
                <script type="text/javascript">
                    function refreshField(v1, v2, v3, v4, type) {
                        if (type) {
                            switch (type) {
                                case "Patient":
                                    combo = $find("<%= rdcPatient.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
                                    break;
                                case "Professional":
                                    combo = $find("<%= rdcProfessional.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
                                    break;
                                case "Diary":
                                    combo = $find("<%= rdcDiary.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
                                    break;
                                case "AppointmentType":
                                    combo = $find("<%= rdcAppointmentType.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    function loadCombo(combo, v1, v3) {
                        var items = combo.get_items();
                        items.clear();
                        var comboItem = new Telerik.Web.UI.RadComboBoxItem();
                        comboItem.set_text(v3);
                        comboItem.set_value(v1);
                        items.add(comboItem);
                        combo.commitChanges();
                        comboItem.select();
                    }


                    function ViewHisAdm(id) {
                        var w2 = window.open("PatientTab.aspx?PatientId=" + id, null, "width=900, height=650,resizable=1, scrollbars=1");
                        w2.focus();
                    }
                    function CreateVisit(id) {
                        var w2 = window.open("VisitTab.aspx?AppointmentId= " + id , "VISIT", "width=800, height=500,resizable=1");
                        w2.focus;
                    }
                    function EditVisit(id) {
                        var w2 = window.open("VisitTab.aspx?VisitId= " + id + "&Caller=Appointment", "VISIT", "width=800, height=500,resizable=1");
                        w2.focus;
                    }
                    function JSendSmsOK() {
                        $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("SmsOK");
                    }
                    function doNothing() {
                    }
                </script>
            </telerik:RadScriptBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                                    onajaxrequest="RadAjaxManager1_AjaxRequest">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="rdcAppointmentType">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="rdcAppointmentType" />
                            <telerik:AjaxUpdatedControl ControlID="rddtEndDateTime" />
                            <telerik:AjaxUpdatedControl ControlID="txtDuration" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadInputManager ID="RadInputManager1" runat="server">
                <telerik:TextBoxSetting Validation-IsRequired="true">

                    <Validation IsRequired="True"></Validation>
                </telerik:TextBoxSetting>
                <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="0" 
                                               DecimalSeparator="," GroupSeparator="." GroupSizes="3" MaxValue="60" 
                                               MinValue="1" NegativePattern="-n" PositivePattern="n" Validation-IsRequired="true">
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtDuration" />
                    </TargetControls>

                    <Validation IsRequired="True"></Validation>
                </telerik:NumericTextBoxSetting>
            </telerik:RadInputManager>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server"></telerik:RadWindowManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="4">
                                <div id="TitleArea" runat="server" class="titleBar2">
                                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                    <asp:Label ID="lblTitle" runat="server" Text="Cita"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div ID="AppointmentId" class="normalText">
                                    <asp:Label ID="lblAppointmentId" runat="server" Text="TCIT ID:" 
                                               ToolTip="Identificador del tipo de cita, lo usa interPatientNamente el sistema"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtAppointmentId" runat="server" AutoPostBack="True" 
                                                 Width="75px" ></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="3">
                                <div ID="PatientId" class="normalText">
                                    <asp:Label ID="lblPatientId" runat="server" Text="Paciente" 
                                               ToolTip="Paciente citado"></asp:Label>
                                    <asp:ImageButton ID="btnPatientId" runat="server" 
                                                     ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     ToolTip="Haga clic aqu� para buscar un paciente" 
                                                     OnClientClick="searchPatient();" TabIndex="100" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcPatient" Height="100px" 
                                        Width="99%" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aqu� ..." TabIndex="1" AutoPostBack="True"
                                                         onitemsrequested="rdcPatient_ItemsRequested" 
                                        CausesValidation="False">
                                    </telerik:RadComboBox>

                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="3">
                                <div ID="DiaryId" class="normalText">
                                    <asp:Label ID="lblDiaryId" runat="server" Text="Agenda:" 
                                               ToolTip="Agenda para que se cita"></asp:Label>
                                    <asp:ImageButton ID="btnDiaryId" runat="server" 
                                                     CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                                     OnClientClick="searchDiary();" 
                                                     ToolTip="Haga clic aqu� para buscar una agenda" 
                                        TabIndex="100" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcDiary" Height="100px" Width="99%" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aqu� ..." TabIndex="2" AutoPostBack="True"
                                                         onitemsrequested="rdcDiary_ItemsRequested" 
                                        CausesValidation="False">
                                    </telerik:RadComboBox>
                                </div>
                            </td>

                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td colspan="3">
                                <div ID="AppointmentTypeId" class="normalText">
                                    <asp:Label ID="lblAppointmentTypeId" runat="server" Text="Tipo cita:" 
                                               ToolTip="Tipo de cita de la que se trata"></asp:Label>
                                    <asp:ImageButton ID="ibtnAppointmentTypeId" runat="server" 
                                                     CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                                     OnClientClick="searchAppointmentType();"
                                                     ToolTip="Haga clic aqu� para buscar un paciente" 
                                        TabIndex="100" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcAppointmentType" AutoPostBack="true" 
                                                         Height="100px" Width="99%" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aqu� ..." TabIndex="3"
                                                         onitemsrequested="rdcAppointmentType_ItemsRequested" 
                                                         
                                        onselectedindexchanged="rdcAppointmentType_SelectedIndexChanged" 
                                        CausesValidation="False">
                                    </telerik:RadComboBox>                                
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td colspan="3">
                                <div ID="ProfessionalId" class="normalText">
                                    <asp:Label ID="lblProfessionalId" runat="server" Text="Profesional:" 
                                               ToolTip="Profesional para el que se cita."></asp:Label>
                                    <asp:ImageButton ID="btnProfessionalId" runat="server" 
                                                     ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     ToolTip="Haga clic aqu� para buscar un professional" 
                                                     OnClientClick="searchProfessional();" TabIndex="100" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcProfessional" Height="100px" 
                                        Width="99%" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aqu� ..." TabIndex="4" AutoPostBack="True"
                                                         onitemsrequested="rdcProfessional_ItemsRequested" 
                                        CausesValidation="False">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>
                                <div id="BeginDateTime" class="normalText">
                                    <asp:Label ID="lblBeginDateTime" runat="server" Text="Inicio:"></asp:Label>
                                    <br />
                                    <telerik:RadDateTimePicker ID="rddtBeginDateTime" runat="server" TabIndex="6" 
                                                               AutoPostBackControl="Both" 
                                                               onselecteddatechanged="rddtBeginDateTime_SelectedDateChanged">
                                        <TimeView CellSpacing="-1" Culture="es-ES">
                                        </TimeView>
                                        <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="6" 
                                                   AutoPostBack="True">
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="5" />
                                    </telerik:RadDateTimePicker>
                                </div>
                            </td>
                            <td>
                                <div id="EndDateTime" class="normalText">
                                    <asp:Label ID="lblEndDateTime" runat="server" Text="Final:"></asp:Label>
                                    <br />
                                    <telerik:RadDateTimePicker ID="rddtEndDateTime" runat="server" TabIndex="7">
                                        <TimeView CellSpacing="-1" Culture="es-ES">
                                        </TimeView>
                                        <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="7">
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="6" />
                                    </telerik:RadDateTimePicker>
                                </div>
                            </td>
                            <td>
                                <div id="Duration" class="normalText">
                                    <asp:Label ID="lblDuration" runat="server" Text="Duraci�n:"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtDuration" runat="server" Width="58px" TabIndex="7" 
                                                 ontextchanged="txtDuration_TextChanged" AutoPostBack="True"></asp:TextBox>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td>
                                <div id="Arrival" class="normalText">
                                    <asp:Label ID="lblArrival" runat="server" Text="Llegada:"></asp:Label>
                                    <br />
                                    <telerik:RadTimePicker ID="rddtArrival" runat="server" TabIndex="8">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" TabIndex="9" 
                                                         Visible="False" />
                                        <TimeView CellSpacing="-1" Culture="es-ES">
                                        </TimeView>
                                        <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="10" 
                                                   Width="">
                                        </DateInput>
                                    </telerik:RadTimePicker>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="Status" class="normalText">
                                    <asp:Label ID="lblStatus" runat="server" Text="Estado:"></asp:Label>
                                    <br />
                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="200px" TabIndex="11" 
                                        AutoPostBack="True" onselectedindexchanged="ddlStatus_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div ID="Subject" class="normalText">
                                    <asp:Label ID="lblSubject" runat="server" Text="Asunto:" 
                                               ToolTip="Este es el texto que aparecer� en el calendario"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSubject" runat="server" Enabled="false" 
                                                 TabIndex="12" Width="99%" Height="23px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div ID="Description" class="normalText">
                                    <asp:Label ID="lblDescription" runat="server" Text="Descripci�n:" 
                                               ToolTip="Este es el texto que aparecer� en el calendario"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtDescription" runat="server" Enabled="false" 
                                                 TabIndex="12" Width="99%" Height="23px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div ID="Comments" class="normalText">
                                    <asp:Label ID="lblComments" runat="server" Text="Observaciones:" 
                                               ToolTip="Observaciones"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtComments" runat="server" 
                                                 TabIndex="13" Width="99%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="SMS" class="normalTextBlue">
                                    <asp:CheckBox ID="chkSMS" runat="server" Text="Mandar recordatorio SMS" OnCheckedChanged="chkSMS_CheckedChanged" AutoPostBack="true" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div ID="MovilSMS" class="normalText">
                                    <asp:Label ID="LblMovilSms" runat="server" Text="M�vil"
                                               ToolTip="N�mero de m�vil al que se enviar� el mensaje"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtMovilSms" runat="server" AutoPostBack="True" 
                                                 Width="99%" ></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div ID="RemitenteSMS" class="normalText">
                                    <asp:Label ID="lblRemitenteSms" runat="server" Text="Remitente" 
                                               ToolTip="Remitente que figurar� en el mensaje SMS"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtRemitenteSms" runat="server" AutoPostBack="True" 
                                                 Width="99%" ></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="SendDateTime" class="normalText">
                                    <asp:Label ID="lblSendDateTime" runat="server" Text="Fecha y hora de env�o"></asp:Label>
                                    <br />
                                    <telerik:RadDateTimePicker ID="rddtSendDateTime" runat="server" TabIndex="6" 
                                                               AutoPostBackControl="Both">
                                        <TimeView CellSpacing="-1" Culture="es-ES">
                                        </TimeView>
                                        <TimePopupButton HoverImageUrl="" ImageUrl="" />
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="6" 
                                                   AutoPostBack="True">
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="5" />
                                    </telerik:RadDateTimePicker>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div ID="SmsMessage" class="normalText">
                                    <asp:Label ID="lblSmsMessage" runat="server" Text="Mensaje SMS" 
                                               ToolTip="SMS a enviar"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSmsMessage" runat="server" 
                                                 TabIndex="13" Width="99%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div ID="Buttons" class="buttonsFomat">
                                    <asp:ImageButton ID="btnVisit" runat="server" TabIndex="16" 
                                                     ImageUrl="~/images/gears_run.png" onclick="btnVisit_Click" 
                                                     ToolTip="Generar visita" Visible="False" /> 
                                    &nbsp;
                                    <asp:ImageButton ID="btnMedicalRecord" runat="server" TabIndex="17" 
                                                     ImageUrl="~/images/folder_cubes.png" onclick="btnMedicalRecord_Click" 
                                                     ToolTip="Abrir historial" Visible="False" /> 
                                    &nbsp;
                                    <asp:ImageButton ID="btnAccept" runat="server" TabIndex="14" 
                                                     ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                                     ToolTip="Guardar y salir" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCancel" runat="server" TabIndex="15" 
                                                     ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                                     onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
