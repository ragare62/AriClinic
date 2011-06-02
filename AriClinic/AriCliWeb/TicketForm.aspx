<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketForm.aspx.cs" Inherits="TicketForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Ticket
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
/* Line 2 */
#TicketId
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

/* Line 3 */
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
/* Line 4 */
#Clinic
{
z-index: 1;
left: 11px;
top: 155px;
position: absolute;
height: 44px;
width: 222px;
bottom: 109px;
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
#Amount
{
z-index: 1;
left: 565px;
top: 155px;
position: absolute;
height: 44px;
width: 108px;
}             
/* Line 5 */
#Message
{
z-index: 1;
left: 12px;
top: 425px;
position: absolute;
height: 44px;
width: 677px;
}
/* Line 6 */
#Buttons
{
z-index: 1;
left: 14px;
top: 482px;
position: absolute;
height: 26px;
width: 674px;
}
#ProfessionalId
{
z-index: 1;
left: 13px;
top: 209px;
position: absolute;
height: 44px;
width: 82px;
}
#ProfessionalName
{
z-index: 1;
left: 110px;
top: 207px;
position: absolute;
height: 44px;
width: 319px;
}
#ProcedureId
{
z-index: 1;
left: 14px;
top: 262px;
position: absolute;
height: 44px;
width: 82px;
}
#ProcedureName
{
z-index: 1;
left: 111px;
top: 261px;
position: absolute;
height: 44px;
width: 319px;
}
#Checked
{
z-index: 1;
left: 445px;
top: 205px;
position: absolute;
height: 47px;
width: 238px;
}
#Comments
{
z-index: 1;
left: 13px;
top: 261px;
position: absolute;
height: 153px;
width: 672px;
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
        <script type="text/javascript" src="GeneralFormFunctions.js">
        </script>
        <script type="text/javascript" src="dialog_box.js"></script>
        <script type="text/javascript">
          //Put your JavaScript code here.
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
                      case "InsuranceService":
                          document.getElementById('<%= txtInsuranceServiceId.ClientID %>').value = v1;
                          document.getElementById('<%= txtInsuranceServiceName.ClientID %>').value = v3;
                          document.getElementById('<%= txtDescription.ClientID %>').value = v3;
                          document.getElementById('<%= txtAmount.ClientID %>').value = v2;
                          break;
                      case "Professional":
                          document.getElementById('<%= txtProfessionalId.ClientID %>').value = v1;
                          document.getElementById('<%= txtProfessionalName.ClientID %>').value = v3;
                          break;
                  }
              }
          }
          function ariDialog(title, message, type, modal, width, height) {
              showDialog(title, message, type, modal, width, height);
              setTimeout("ObtainSelected()", 100);
          }
          function ObtainSelected(tag) {
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
              <telerik:AjaxUpdatedControl ControlID="rdcbPolicy" />
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
            <telerik:TargetInput ControlID="txtTicketId" />
            <telerik:TargetInput ControlID="txtCustomerId" />
            <telerik:TargetInput ControlID="txtInsuranceServiceId" />
          </TargetControls>
        </telerik:NumericTextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="2" 
                                       DecimalSeparator="," GroupSeparator="." 
                                       GroupSizes="3" NegativePattern="-n" 
                                       PositivePattern="n" Validation-IsRequired="true" 
              MaxValue="999999" MinValue="-999999">
            <TargetControls>
                <telerik:TargetInput ControlID="txtAmount" />
            </TargetControls>

          <Validation IsRequired="True"></Validation>
        </telerik:NumericTextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
          
                            
                            
          style="z-index: 1; left: 0px; top:0px; position: absolute; height: 518px; width: 705px">
        <%--Line 1--%>
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Ticket"></asp:Label>
        </div>
        <%--Line 2--%>
        <div id="TicketId" class="normalText">
          <asp:Label ID="lblTicketId" runat="server" Text="ID:" 
                     ToolTip="Identificador de ticket, lo usa internamente el sistema" ></asp:Label>
          <br />
          <asp:TextBox ID="txtTicketId" runat="server" Enabled="false" Width="89px" TabIndex="1" ></asp:TextBox>
        </div>
        <div ID="CustomerId" class="normalText">
          <asp:Label ID="lblCustomerId" runat="server" Text="CLI ID:" 
                     ToolTip="Identificador del cliente, lo usa internamente el sistema"></asp:Label>
          <asp:ImageButton ID="btnCustomerId" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                           OnClientClick="searchCustomer();" 
                           ToolTip="Haga clic aquí para buscar un cliente" style="height: 10px" />
          <br />
          <asp:TextBox ID="txtCustomerId" runat="server" TabIndex="2" 
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
          <telerik:RadDatePicker ID="rddpTicketDate" Runat="server" TabIndex="4" 
                                 Culture="es-ES" MinDate="1900-01-01" >
            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                      ViewSelectorText="x">
            </Calendar>
            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="5">
            </DateInput>
            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="5" />
          </telerik:RadDatePicker>
        </div>
        <%--Line 3--%>
        <div ID="Policy" class="normalText">
          <asp:Label ID="lblPolicy" runat="server" Text="Póliza:" 
                     ToolTip="Aseguradora ligada a la póliza"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbPolicy" runat="server" TabIndex="6" Width="222px"  >
          </telerik:RadComboBox>
        </div>
        <div ID="InsuranceServiceId" class="normalText">
          <asp:Label ID="lblInsuranceServiceId" runat="server" Text="SER ID:" 
                     ToolTip="Identificador de servicio asegurado, lo usa internamente el sistema"></asp:Label>
          <asp:ImageButton ID="btnInsuranceServiceId" runat="server" 
                           ImageUrl="~/images/search_mini.png" CausesValidation="false"
                           ToolTip="Haga clic aquí para buscar servicio asegurado" 
                           onclick="btnInsuranceServiceId_Click" />
          <br />
          <asp:TextBox ID="txtInsuranceServiceId" runat="server" TabIndex="7" 
                       Width="89px" AutoPostBack="True" 
                       ontextchanged="txtInsuranceServiceId_TextChanged"></asp:TextBox>
        </div>
        <div ID="InsuranceServiceName" class="normalText">
          <asp:Label ID="lblInsuranceServiceName" runat="server" Text="Servicio:" 
                     ToolTip="Serivicio del ticket"></asp:Label>
          <br />
          <asp:TextBox ID="txtInsuranceServiceName" runat="server" Enabled="False" TabIndex="8" 
                       Width="324px"></asp:TextBox>
        </div>
        <%--Line 4--%>
        <div ID="Clinic" class="normalText">
          <asp:Label ID="lblClinic" runat="server" Text="Clinica:" 
                     ToolTip="Clínica a la que asigna el ticket"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbClinic" runat="server" TabIndex="9" 
                               Width="220px">
          </telerik:RadComboBox>
        </div>
        <div ID="Description" class="normalText">
          <asp:Label ID="lblDescription" runat="server" Text="Descripción del servicio:" 
                     ToolTip="Dexripción del servicio del ticket"></asp:Label>
          <br />
          <asp:TextBox ID="txtDescription" runat="server" TabIndex="10" 
                       Width="287px"></asp:TextBox>
        </div>
        <div ID="Amount" class="normalTextRight">
          <asp:Label ID="lblAmount" runat="server" Text="Importe:" 
                     ToolTip="Importe del ticket"></asp:Label>
          <br />
          <asp:TextBox ID="txtAmount" runat="server"
                       TabIndex="11" Width="98px" style="text-align:right" ></asp:TextBox>
        </div>
        <%--Line 5--%>
        <div ID="ProfessionalId" class="normalText">
          <asp:Label ID="lblProfessionalId" runat="server" Text="PROF ID:" 
                     ToolTip="Identificador del profesional, lo usa internamente el sistema"></asp:Label>
          <asp:ImageButton ID="btnProfessionalId" runat="server" 
                           CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                           OnClientClick="searchProfessional();"  
                           ToolTip="Haga clic aquí para buscar profesionales" />
          <br />
          <asp:TextBox ID="txtProfessionalId" runat="server" AutoPostBack="True" 
                       TabIndex="12" 
                       Width="75px" ontextchanged="txtProfessionalId_TextChanged"></asp:TextBox>
        </div>
        <div ID="ProfessionalName" class="normalText">
          <asp:Label ID="lblProfessionalName" runat="server" Text="Profesional:" 
                     ToolTip="Profesional asignado al ticket"></asp:Label>
          <br />
          <asp:TextBox ID="txtProfessionalName" runat="server" Enabled="False" 
                       TabIndex="13" Width="307px"></asp:TextBox>
        </div>
        <div ID="Checked" class="normalText">
          <asp:Label ID="lblChecked" runat="server" Text="Verificado:" 
                     ToolTip="Indica si el ticket se ha verificado adminstrativamente"></asp:Label>
          <br />
          <asp:CheckBox ID="chkChecked" runat="server" 
                        Text="Se dispone de comprobante." TabIndex="14" />
        </div>
        <%--Line 6--%>
        <%--Line 7--%>
        <div ID="Comments" class="normalText">
          <asp:Label ID="lblComments" runat="server" Text="Observaciones:" 
                     ToolTip="Observaciones del ticket"></asp:Label>
          <br />
          <asp:TextBox ID="txtComments" runat="server" TabIndex="17" 
                       Width="668px" Height="134px" TextMode="MultiLine"></asp:TextBox>
        </div>
        <%--Line 8--%>
        <div ID="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>
        <%--Line 9--%>
        <div ID="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" TabIndex="18" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" TabIndex="19" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
