<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnestheticServiceNoteForm.aspx.cs" Inherits="AnestheticServiceNoteForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Nota de servicio anestésico
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    <link href="dialog_box.css" rel="Stylesheet" type="text/css" />
<style type="text/css">
/* Line 1 */
#TitleArea
{
z-index: 1;
left: 5px;
top: 0px;
position: absolute;
height: 19px;
width: 676px;
}
#AnestheticServiceNoteId
{
z-index: 1;
left: 5px;
top: 40px;
position: absolute;
height: 44px;
width: 99px;
}
#CustomerId
{
z-index: 1;
left: 121px;
top: 40px;
position: absolute;
height: 44px;
width: 99px;
}
#ComercialName
{
z-index: 1;
left: 234px;
top: 40px;
position: absolute;
height: 44px;
width: 291px;
}
#TicketDate
{
z-index: 1;
left: 538px;
top: 40px;
position: absolute;
height: 44px;
width: 147px;
right: 7px;
}
#Policy
{
z-index: 1;
left: 8px;
top: 95px;
position: absolute;
height: 44px;
width: 223px;
bottom: 169px;
}
#InsuranceServiceId
{
z-index: 1;
left: 245px;
top: 95px;
position: absolute;
height: 44px;
width: 93px;
}
#InsuranceServiceName
{
z-index: 1;
left: 350px;
top: 95px;
position: absolute;
height: 44px;
width: 337px;
}
#Clinic
{
z-index: 1;
left: 11px;
top: 97px;
position: absolute;
height: 44px;
width: 178px;
bottom: 430px;
}       
#Description
{
z-index: 1;
left: 247px;
top: 155px;
position: absolute;
height: 44px;
width: 291px;
}
#Total
{
z-index: 1;
left: 565px;
top: 96px;
position: absolute;
height: 44px;
width: 120px;
}
/* */
#SurgeonId
{
z-index: 1;
left: 11px;
top: 151px;
position: absolute;
height: 44px;
width: 73px;
right: 617px;
}
#SurgeonName
{
z-index: 1;
left: 91px;
top: 150px;
position: absolute;
height: 44px;
width: 195px;
}             

#ProfessionalId
{
z-index: 1;
left: 202px;
top: 96px;
position: absolute;
height: 44px;
width: 82px;
}

#ProfessionalName
{
z-index: 1;
left: 292px;
top: 97px;
position: absolute;
height: 44px;
width: 254px;
right: 155px;
}

#ProcedureId
{
z-index: 1;
left: 327px;
top: 281px;
position: absolute;
height: 44px;
width: 82px;
}

#ProcedureName
{
z-index: 1;
left: 434px;
top: 280px;
position: absolute;
height: 44px;
width: 252px;
}

#Checked
{
z-index: 1;
left: 14px;
top: 239px;
position: absolute;
height: 68px;
width: 259px;
}

#tickets
{
z-index: 1;
left: 13px;
top: 320px;
position: absolute;
height: 277px;
width: 676px;
}
#Buttons
{
z-index: 1;
left: 17px;
top: 618px;
position: absolute;
height: 26px;
width: 674px;
}

#Procedures
{
z-index: 1;
left: 293px;
top: 155px;
position: absolute;
height: 156px;
width: 392px;
}             

</style>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico"/>
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
                      case "Customer":
                          document.getElementById('<%= txtCustomerId.ClientID %>').value = v1;
                          document.getElementById('<%= txtComercialName.ClientID %>').value = v3;
                          $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
                          break;
                      case "Professional":
                          document.getElementById('<%= txtProfessionalId.ClientID %>').value = v1;
                          document.getElementById('<%= txtProfessionalName.ClientID %>').value = v3;
                          break;
                      case "Professional2":
                          document.getElementById('<%= txtSurgeonId.ClientID %>').value = v1;
                          document.getElementById('<%= txtSurgeonName.ClientID %>').value = v3;
                          break;
                      case "Procedure":
                          document.getElementById('<%= txtProcedureId1.ClientID %>').value = v1;
                          document.getElementById('<%= txtProcedureName1.ClientID %>').value = v3;
                          break;
                      case "Procedure1":
                          document.getElementById('<%= txtProcedureId2.ClientID %>').value = v1;
                          document.getElementById('<%= txtProcedureName2.ClientID %>').value = v3;
                          break;
                      case "Procedure2":
                          document.getElementById('<%= txtProcedureId3.ClientID %>').value = v1;
                          document.getElementById('<%= txtProcedureName3.ClientID %>').value = v3;
                          break;
                  }
              }
          }
          function updateTotal()
          {
              //alert("Inside updateTotal()");
              $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("updateTotal");
          }
        </script>
        <script type="text/javascript">
          function ariDialog(title, message, type, modal, width, height)
          {
              showDialog(title, message, type, modal, width, height);
              setTimeout("ObtainSelected()", 100);
          }

          function ObtainSelected(tag)
          {
              if (DLGRESULT == 0)
                  setTimeout("ObtainSelected()", 100); // continue asking
              else if (DLGRESULT == 1) // accept
              {
                  //process value
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("yes");
              }
              else //cancel;
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("no");
              }
              return;
          }
        </script>

      </telerik:RadScriptBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                              onajaxrequest="RadAjaxManager1_AjaxRequest">
        <AjaxSettings>
          <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
              <telerik:AjaxUpdatedControl ControlID="txtTotal" />
            </UpdatedControls>
          </telerik:AjaxSetting>
        </AjaxSettings>
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadInputManager ID="RadInputManager1" runat="server">
        <telerik:TextBoxSetting Validation-IsRequired="true">
          <TargetControls>
            <telerik:TargetInput ControlID="txtDescription" />
          </TargetControls>
          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
        <telerik:TextBoxSetting>
          <TargetControls>
            <telerik:TargetInput ControlID="txtComercialName" />
            <telerik:TargetInput ControlID="txtInsuranceServiceId" />
            <telerik:TargetInput ControlID="txtInsuranceServiceName" />
          </TargetControls>
        </telerik:TextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="0" 
                                       DecimalSeparator="." GroupSeparator="." GroupSizes="3" MaxValue="999999999" 
                                       MinValue="0" NegativePattern="-n" PositivePattern="n">
          <TargetControls>
            <telerik:TargetInput ControlID="txtAnestheticServiceNoteId" />
            <telerik:TargetInput ControlID="txtCustomerId" />
            <telerik:TargetInput ControlID="txtInsuranceServiceId" />
            <telerik:TargetInput ControlID="txtProfessionalId" />
            <telerik:TargetInput ControlID="txtSurgeonId" />
            <telerik:TargetInput ControlID="txtProcedureId" />
          </TargetControls>
        </telerik:NumericTextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="2" 
                                       DecimalSeparator="," GroupSeparator="." 
                                       GroupSizes="3" NegativePattern="-n" 
                                       PositivePattern="n" Validation-IsRequired="true">

          <Validation IsRequired="True"></Validation>
        </telerik:NumericTextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" 
          Position="TopCenter" TabIndex="3">
      </telerik:RadToolTipManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"           
          style="z-index: 1; left: 0px; top:0px; position: absolute; height: 645px; width: 705px">
        <%--Line 1--%>
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Nota de servicio anestésico"></asp:Label>
        </div>
        <%--Line 2--%>
        <div id="AnestheticServiceNoteId" class="normalText">
          <asp:Label ID="lblAnestheticServiceNoteId" runat="server" Text="ID:" 
                     ToolTip="Identificador de ticket, lo usa internamente el sistema" ></asp:Label>
          <br />
          <asp:TextBox ID="txtAnestheticServiceNoteId" runat="server" Enabled="false" Width="89px" TabIndex="1" ></asp:TextBox>
        </div>
        <div ID="CustomerId" class="normalText">
          <asp:Label ID="lblCustomerId" runat="server" Text="CLI ID:" 
                     ToolTip="Identificador del cliente, lo usa internamente el sistema"></asp:Label>
          <asp:ImageButton ID="btnCustomerId" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                           OnClientClick="searchCustomer();" 
                           ToolTip="Haga clic aquí para buscar un cliente" style="height: 10px" />
          <br />
          <asp:TextBox ID="txtCustomerId" runat="server" TabIndex="1" 
                       Width="89px" AutoPostBack="True" 
                       ontextchanged="txtCustomerId_TextChanged"></asp:TextBox>
        </div>
        <div id="ComercialName" class="normalText">
          <asp:Label ID="lblComercialName" runat="server" Text="Paciente / Cliente:" 
                     ToolTip="Cliente del ticket"></asp:Label>
          <br />
          <asp:TextBox ID="txtComercialName" runat="server" Width="287px" TabIndex="3" 
                       Enabled="False" ></asp:TextBox>
        </div>
        <div ID="TicketDate" class="normalText">
          <asp:Label ID="lblTicketDate" runat="server" Text="Fecha:" 
                     ToolTip="Fecha del ticket"></asp:Label>
          <br />
          <telerik:RadDatePicker ID="rddpServiceNoteDate" Runat="server" TabIndex="2" 
                                 Culture="es-ES" MinDate="1900-01-01" >
            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                      ViewSelectorText="x">
            </Calendar>
            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="2">
            </DateInput>
            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="2" />
          </telerik:RadDatePicker>
        </div>
        <%--Line 3--%>
        <div ID="Clinic" class="normalText">
          <asp:Label ID="lblClinic" runat="server" Text="Clinica:" 
                     ToolTip="Clínica a la que asigna el ticket"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbClinic" runat="server" TabIndex="3" 
                               Width="171px" Height="24px">
          </telerik:RadComboBox>
        </div>
        <div ID="ProfessionalId" class="normalText">
          <asp:Label ID="lblProfessionalId" runat="server" Text="PROF ID:" 
                     ToolTip="Identificador del profesional, lo usa internamente el sistema"></asp:Label>
          <asp:ImageButton ID="btnProfessionalId" runat="server" 
                           CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                           OnClientClick="searchProfessional();"  
                           ToolTip="Haga clic aquí para buscar profesionales" />
          <br />
          <asp:TextBox ID="txtProfessionalId" runat="server" AutoPostBack="True" 
                       TabIndex="4" 
                       Width="75px" ontextchanged="txtProfessionalId_TextChanged"></asp:TextBox>
        </div>
        <div ID="ProfessionalName" class="normalText">
          <asp:Label ID="lblProfessionalName" runat="server" Text="Profesional:" 
                     ToolTip="Profesional asignado al ticket"></asp:Label>
          <br />
          <asp:TextBox ID="txtProfessionalName" runat="server" Enabled="False" 
                       TabIndex="13" Width="247px"></asp:TextBox>
        </div>
        <div ID="Total" class="normalTextRight">
          <asp:Label ID="lblTotal" runat="server" Text="Total:" 
                     ToolTip="Total de los tickets de esta nota"></asp:Label>
          <br />
          <asp:TextBox ID="txtTotal" runat="server"
                       TabIndex="11" Width="98px" style="text-align:right" ></asp:TextBox>
        </div>
        <%--Line 4--%>
        <div ID="Checked" class="normalText">
          <asp:Label ID="lblChecked" runat="server" Text="VERIFICAR:" 
                     ToolTip="Se debe marcar si se han producido estas circunstancias"></asp:Label>
          <br />
          <asp:CheckBox ID="chkChecked" runat="server" 
                        Text="Se incluye bomba dolor." TabIndex="9" />
          <br />
          <asp:CheckBox ID="chkCkecked2" runat="server" 
                        Text="Todos con comprobante" TabIndex="10" />
        </div>
        <%--Line 4.1--%>
        <%--Line 4.2--%>
        <div ID="SurgeonId" class="normalText">
          <asp:Label ID="lblSurgeonId" runat="server" Text="CRG ID:" 
                     ToolTip="Identificador del cirujano (Profesional también)"></asp:Label>
          <asp:ImageButton ID="btnSurgeonId" runat="server" CausesValidation="false" 
                           ImageUrl="~/images/search_mini.png" OnClientClick="searchProfessional2();" 
                           ToolTip="Haga clic aquí para buscar profesionales (cirujanos)" />
          <br />
          <asp:TextBox ID="txtSurgeonId" runat="server" AutoPostBack="True" 
                       ontextchanged="txtSurgeonId_TextChanged" TabIndex="5" Width="60px"></asp:TextBox>
        </div>
        <div ID="SurgeonName" class="normalText">
          <asp:Label ID="lblSurgeonName" runat="server" Text="Cirujano:" 
                     ToolTip="Cirujano que ha participado"></asp:Label>
          <br />
          <asp:TextBox ID="txtSurgeonName" runat="server" Enabled="False" 
                       TabIndex="16" Width="191px"></asp:TextBox>
        </div>
        <%--Line 5--%>
        <div ID="tickets" class="embGrid">
          <asp:Label ID="lblTicket" runat="server" Text="Tickets relacionados:"></asp:Label>
          <br />
          <iframe id="ifTickets" frameborder="0" runat="server" style="width:100%; height:100%">
          </iframe>
        </div>
        <%--Line 6--%>
        <div ID="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" TabIndex="20" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" TabIndex="21" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
        </div>
        <div ID="Procedures" class="embGrid">
          <asp:Label ID="lblProcedures" runat="server" Text="Intervenciones practicadas:" 
                     ToolTip="Procedimientos"></asp:Label>
          <br />
          <table style="width: 100%;">
            <tr>
              <td>
                <div ID="ProcedureId1" class="normalText">
                  <asp:Label ID="lblProcedureId1" runat="server" Text="PROC ID(1):" 
                             ToolTip="Identificador del procedimiento, lo usa internamente el sistema"></asp:Label>
                  <asp:ImageButton ID="ImageButton1" runat="server" 
                                   CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                   OnClientClick="searchProcedure();" 
                                   ToolTip="Haga clic aquí para buscar procedimientos" />
                  <br />
                  <asp:TextBox ID="txtProcedureId1" runat="server" AutoPostBack="True" 
                               TabIndex="6" Width="75px" 
                               ontextchanged="txtProcedureId1_TextChanged"></asp:TextBox>
                </div>
              </td>
              <td>
                <div ID="ProcedureName1" class="normalText">
                  <asp:Label ID="lblProcedureName1" runat="server" Text="Procedimiento:" 
                             ToolTip="Procedimiento asignado al ticket"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtProcedureName1" runat="server" Enabled="False" 
                               TabIndex="18" Width="241px"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td>
                <div ID="ProcedureId2" class="normalText">
                  <asp:Label ID="lblProcedureId2" runat="server" Text="PROC ID (2):" 
                             ToolTip="Identificador del procedimiento, lo usa internamente el sistema"></asp:Label>
                  <asp:ImageButton ID="ImageButton2" runat="server" 
                                   CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                   OnClientClick="searchProcedure1();" 
                                   ToolTip="Haga clic aquí para buscar procedimientos" />
                  <br />
                  <asp:TextBox ID="txtProcedureId2" runat="server" AutoPostBack="True" 
                               TabIndex="7" Width="75px" 
                               ontextchanged="txtProcedureId2_TextChanged"></asp:TextBox>
                </div>
              </td>
              <td>
                <div ID="ProcedureName2" class="normalText">
                  <asp:Label ID="lblProcedureName2" runat="server" Text="Procedimiento:" 
                             ToolTip="Procedimiento asignado al ticket"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtProcedureName2" runat="server" Enabled="False" 
                               TabIndex="18" Width="241px"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td>
                <div ID="ProcedureId3" class="normalText">
                  <asp:Label ID="lblProcedureId3" runat="server" Text="PROC ID (3):" 
                             ToolTip="Identificador del procedimiento, lo usa internamente el sistema"></asp:Label>
                  <asp:ImageButton ID="ImageButton3" runat="server" 
                                   CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                   OnClientClick="searchProcedure2();" 
                                   ToolTip="Haga clic aquí para buscar procedimientos" />
                  <br />
                  <asp:TextBox ID="txtProcedureId3" runat="server" AutoPostBack="True" 
                               TabIndex="8" Width="75px" 
                               ontextchanged="txtProcedureId3_TextChanged"></asp:TextBox>
                </div>
              </td>
              <td>
                <div ID="ProcedureName3" class="normalText">
                  <asp:Label ID="lblProcedureName3" runat="server" Text="Procedimiento:" 
                             ToolTip="Procedimiento asignado al ticket"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtProcedureName3" runat="server" Enabled="False" 
                               TabIndex="18" Width="241px"></asp:TextBox>
                </div>
              </td>
            </tr>
          </table>
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
