<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceNoteForm.aspx.cs" Inherits="ServiceNoteForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Nota de servicio
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    <link href="dialog_box.css" rel="Stylesheet" type="text/css" />
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
                          combo = $find("<%= rdcComercialName.ClientID %>");
                          loadCombo(combo, v1, v3);
                          $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
                          break;
                      case "Professional":
                          combo = $find("<%= rdcProfessionalName.ClientID %>");
                          loadCombo(combo, v1, v3);
                          $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
                          break;
                      default: break;
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
          function updateTotal()
          {
              //alert("Inside updateTotal()");
              $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("updateTotal");
          }
          function EditInvoiceRecord(id)
          {
              var w2 = window.open("InvoiceForm.aspx?InvoiceId=" + id + "&Caller=sn"
                                   , "tck_er1"
                                   , "width=700, height=490,resizable=1");
              w2.focus();
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
            <telerik:TargetInput ControlID="txtInsuranceServiceId" />
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
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" >
        <table style="width: 100%;">
          <%--Line 1--%>
          <tr>
            <td colspan="4">
              <div id="TitleArea" class="titleBar2">
                <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                <asp:Label ID="lblTitle" runat="server" Text="Nota de servicio"></asp:Label>
              </div>
            </td>
          </tr>
          <%--Line 2--%>
          <tr>
            <td>
              <div id="ServiceNoteId" class="normalText">
                <asp:Label ID="lblServiceNoteId" runat="server" Text="ID:" 
                           ToolTip="Identificador d la nota, lo usa internamente el sistema" ></asp:Label>
                <br />
                <asp:TextBox ID="txtServiceNoteId" runat="server" Enabled="false" Width="89px" TabIndex="1" ></asp:TextBox>
              </div>
            </td>
            <td>
              <div id="ComercialName" class="normalText">
                <asp:Label ID="lblComercialName" runat="server" Text="Paciente / Cliente:" 
                           ToolTip="Cliente del ticket"></asp:Label>
                <asp:ImageButton ID="btnCustomerId" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                 OnClientClick="searchCustomer();" 
                                 ToolTip="Haga clic aquí para buscar un cliente" style="height: 10px" />
                <br />
               <%-- <asp:TextBox ID="txtComercialName" runat="server" Width="250px" TabIndex="3" 
                             Enabled="False" ></asp:TextBox>--%>
                <telerik:RadComboBox runat="server" ID="rdcComercialName" Height="100px" Width="250px" ItemsPerRequest="10" 
                EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                EmptyMessage="Escriba aquí ..." TabIndex="1" AutoPostBack="True"
                onitemsrequested="rdcComercialName_ItemsRequested">
              </telerik:RadComboBox>
              </div>
            </td>
            <td>
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
            </td>
          </tr>
          <%--Line 3--%>
          <tr>
            <td>
              <div ID="Clinic" class="normalText">
                <asp:Label ID="lblClinic" runat="server" Text="Clinica:" 
                           ToolTip="Clínica a la que asigna el ticket"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rdcbClinic" runat="server" TabIndex="3" 
                                     Width="171px" Height="100px">
                </telerik:RadComboBox>
              </div>
            </td>
            <td>
              <div ID="ProfessionalName" class="normalText">
                <asp:Label ID="lblProfessionalName" runat="server" Text="Profesional:" 
                           ToolTip="Profesional asignado al ticket"></asp:Label>
                <asp:ImageButton ID="btnProfessionalId" runat="server" 
                                 CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                 OnClientClick="searchProfessional();"  ToolTip="Haga clic aquí para buscar profesionales" />
                <br />
                <%--<asp:TextBox ID="txtProfessionalName" runat="server" Enabled="False" 
                             TabIndex="13" Width="250px"></asp:TextBox>--%>
                <telerik:RadComboBox runat="server" ID="rdcProfessionalName" Height="100px" Width="250px" ItemsPerRequest="10" 
                EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True"
                onitemsrequested="rdctxtProfessionalName_ItemsRequested">
              </telerik:RadComboBox>
              </div>
            </td>
            <td>
              <div ID="Total" class="normalTextRight">
                <asp:Label ID="lblTotal" runat="server" Text="Total:" 
                           ToolTip="Total de los tickets de esta nota"></asp:Label>
                <br />
                <asp:TextBox ID="txtTotal" runat="server"
                             TabIndex="6" Width="98px" style="text-align:right" ></asp:TextBox>
              </div>
            </td>
          </tr>
          <tr>
            <td></td>
            <td></td>
            <td>
              <div ID="Paid" class="normalTextRight">
                <asp:Label ID="lblPaid" runat="server" Text="Pagado:" 
                           ToolTip="Total de los pagos de esta nota"></asp:Label>
                <br />
                <asp:TextBox ID="txtPaid" runat="server"
                             TabIndex="6" Width="98px" style="text-align:right" ></asp:TextBox>
              </div>
            </td>
          </tr>
          <%-- Line 4 ---%>
          <tr >
            <td colspan="4">
              <div ID="Tickets" class="embGrid" style="height:250px">
                <asp:Label ID="lblTicket" runat="server" Text="Tickets relacionados:"></asp:Label>
                <br />
                <iframe id="ifTickets" frameborder="0" runat="server" style="width:100%; height:100%">
                </iframe>
              </div>
            </td>
          </tr>
          <%-- Line 5 ---%>
          <tr >
            <td colspan="4">
              <div ID="GeneralPayments" class="embGrid" style="height:250px">
                <asp:Label ID="lblGeneralPayments" runat="server" Text="Pagos relacionados:"></asp:Label>
                <br />
                <iframe id="ifGeneralPayments" frameborder="0" runat="server" style="width:100%; height:100%">
                </iframe>
              </div>
            </td>
          </tr>
          <%--Line 6--%>
          <tr>
            <td colspan="4">
              &nbsp;
              <div ID="Buttons" class="buttonsFomat">
                <asp:ImageButton ID="btnInvoice" runat="server" TabIndex="20" 
                                 ImageUrl="~/images/documents_gear.png" onclick="btnInvoice_Click" ToolTip="Generar factura" />
                &nbsp;
                <asp:ImageButton ID="btnAccept" runat="server" TabIndex="7" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" TabIndex="8" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
              </div>
            </td>
          </tr>
        </table>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
