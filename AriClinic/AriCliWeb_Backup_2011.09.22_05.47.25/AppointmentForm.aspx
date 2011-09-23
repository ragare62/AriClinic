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
          function refreshField(v1, v2, v3, v4, type)
          {
              if (type)
              {
                  switch (type)
                  {
                      case "Patient":
                          document.getElementById('<%= txtPatientId.ClientID %>').value = v1;
                          document.getElementById('<%= txtPatientName.ClientID %>').value = v3;
                          break;
                      case "Diary":
                          document.getElementById('<%= txtDiaryId.ClientID %>').value = v1;
                          document.getElementById('<%= txtDiaryName.ClientID %>').value = v3;
                          break;
                      case "Professional":
                          document.getElementById('<%= txtProfessionalId.ClientID %>').value = v1;
                          document.getElementById('<%= txtProfessionalName.ClientID %>').value = v3;
                          break;
                      case "AppointmentType":
                          document.getElementById('<%= txtAppointmentType.ClientID %>').value = v1;
                          document.getElementById('<%= txtAppointmentTypeName.ClientID %>').value = v3;
                          break;
                  }
              }
          }
        </script>
      </telerik:RadScriptBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
          <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
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
                               TabIndex="1" Width="75px" ></asp:TextBox>
                </div>
              </td>
              <td>
                <div ID="PatientId" class="normalText">
                  <asp:Label ID="lblPatientId" runat="server" Text="PAT ID:" 
                             ToolTip="Identificador del paciente asociado, lo usa interPatientNamente el sistema"></asp:Label>
                  <asp:ImageButton ID="btnPatientId" runat="server" 
                                   ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                   ToolTip="Haga clic aquí para buscar un paciente" 
                                   OnClientClick="searchPatient();" />
                  <br />
                  <asp:TextBox ID="txtPatientId" runat="server" TabIndex="2" 
                               Width="89px" AutoPostBack="True" 
                               ontextchanged="txtPatientId_TextChanged"></asp:TextBox>
                </div>
              </td>
              <td colspan="2">
                <div ID="PatientName" class="normalText">
                  <asp:Label ID="lblPatientName" runat="server" Text="Nombre:" 
                             ToolTip="Nombre del tipo de cita"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtPatientName" runat="server" 
                               TabIndex="21" Width="247px" Enabled="False"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div ID="DiaryId" class="normalText">
                  <asp:Label ID="lblDiaryId" runat="server" Text="AGEN ID:" 
                             ToolTip="Identificador del la agenda a la que pertenece, lo usa internamente el sistema"></asp:Label>
                  <asp:ImageButton ID="btnDiaryId" runat="server" 
                                   CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                   OnClientClick="searchDiary();" 
                                   ToolTip="Haga clic aquí para buscar una agenda" />
                  <br />
                  <asp:TextBox ID="txtDiaryId" runat="server" AutoPostBack="True" 
                               ontextchanged="txtDiaryId_TextChanged" TabIndex="3" Width="89px"></asp:TextBox>
                </div>
              </td>
              <td colspan="2">
                <div ID="DiaryName" class="normalText">
                  <asp:Label ID="lblDiaryName" runat="server" Text="Agenda:" 
                             ToolTip="Nombre de la agenda"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtDiaryName" runat="server" TabIndex="22" 
                               Width="247px" Enabled="False"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td>
              </td>
              <td>
                <div ID="AppointmentTypeId" class="normalText">
                  <asp:Label ID="lblAppointmentTypeId" runat="server" Text="TCIT ID:" 
                             ToolTip="Identificador del tipo de cita asociado, lo usa interPatientNamente el sistema"></asp:Label>
                  <asp:ImageButton ID="ibtnAppointmentTypeId" runat="server" 
                                   CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                   OnClientClick="searchAppointmentType();"
                                   ToolTip="Haga clic aquí para buscar un paciente" />
                  <br />
                  <asp:TextBox ID="txtAppointmentType" runat="server" AutoPostBack="True" 
                               ontextchanged="txtAppointmentTypeId_TextChanged" TabIndex="4" 
                               Width="89px"></asp:TextBox>
                </div>
              </td>
              <td colspan="2">
                <div ID="AppointmentTypeName" class="normalText">
                  <asp:Label ID="lblAppointmentTypeName" runat="server" Text="Tipo de cita:" 
                             ToolTip="Nombre del tipo de cita"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtAppointmentTypeName" runat="server" TabIndex="23" 
                               Width="247px" Enabled="False"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td>

              </td>
              <td>
                <div ID="ProfessionalId" class="normalText">
                  <asp:Label ID="lblProfessionalId" runat="server" Text="PROF ID:" 
                             ToolTip="Identificador del paciente, lo usa internamente el sistema"></asp:Label>
                  <asp:ImageButton ID="btnProfessionalId" runat="server" 
                                   ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                   ToolTip="Haga clic aquí para buscar un professional" 
                                   OnClientClick="searchProfessional();" />
                  <br />
                  <asp:TextBox ID="txtProfessionalId" runat="server" TabIndex="5" 
                               Width="89px" AutoPostBack="True" 
                               ontextchanged="txtProfessionalId_TextChanged"></asp:TextBox>
                </div>
              </td>
              <td colspan="2">
                <div ID="ProfessionalName" class="normalText">
                  <asp:Label ID="lblProfessionalName" runat="server" Text="Professional sanitario:" 
                             ToolTip="Nombre del profesinalsanitario"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtProfessionalName" runat="server" 
                               TabIndex="24" Width="247px" Enabled="False"></asp:TextBox>
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
                    <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="6" />
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
                    <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="7" />
                  </telerik:RadDateTimePicker>
                </div>
              </td>
              <td>
                <div id="Duration" class="normalText">
                  <asp:Label ID="lblDuration" runat="server" Text="Duración:"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtDuration" runat="server" Width="58px" TabIndex="8" 
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
                  <telerik:RadTimePicker ID="rddtArrival" runat="server" TabIndex="9">
                    <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                              ViewSelectorText="x">
                    </Calendar>
                    <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" TabIndex="9" 
                                     Visible="False" />
                    <TimeView CellSpacing="-1" Culture="es-ES">
                    </TimeView>
                    <TimePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                    <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="9" 
                               Width="">
                    </DateInput>
                  </telerik:RadTimePicker>
                </div>
              </td>
              <td colspan="2">
                <div id="Status" class="normalText">
                  <asp:Label ID="lblStatus" runat="server" Text="Estado:"></asp:Label>
                  <br />
                  <asp:DropDownList ID="ddlStatus" runat="server" Width="200px" TabIndex="10">
                  </asp:DropDownList>
                </div>
                  
              </td>
            </tr>
            <tr>
              <td colspan="4">
                <div ID="Subject" class="normalText">
                  <asp:Label ID="lblSubject" runat="server" Text="Asunto:" 
                             ToolTip="Este es el texto que aparecerá en el calendario"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtSubject" runat="server" Enabled="false" 
                               TabIndex="11" Width="507px" Height="23px"></asp:TextBox>
                </div>
              </td>
            </tr>            <tr>
              <td colspan="4">
                <div ID="Comments" class="normalText">
                  <asp:Label ID="lblComments" runat="server" Text="Observaciones:" 
                             ToolTip="Observaciones"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtComments" runat="server" 
                               TabIndex="11" Width="507px" Height="116px" TextMode="MultiLine"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="4">
                <div ID="Buttons" class="buttonsFomat">
                  <asp:ImageButton ID="btnAccept" runat="server" TabIndex="12" 
                                   ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                   ToolTip="Guardar y salir" />
                  &nbsp;
                  <asp:ImageButton ID="btnCancel" runat="server" TabIndex="13" 
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
