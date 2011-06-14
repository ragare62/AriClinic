<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentTypeForm.aspx.cs" Inherits="AppointmentTypeForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Tipos de cita</title>
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
                  //                      case "Service":
                  //                          document.getElementById('<%= txtAppointmentTypeId.ClientID %>').value = v1;
                  //                          document.getElementById('<%= txtName.ClientID %>').value = v3;
                  //                          break;
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
          <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
          </TargetControls>
        </telerik:TextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="0" 
                                       DecimalSeparator="," GroupSeparator="." GroupSizes="3" MaxValue="60" 
                                       MinValue="1" NegativePattern="-n" PositivePattern="n" Validation-IsRequired="true">
          <TargetControls>
            <telerik:TargetInput ControlID="txtDuration" />
          </TargetControls>
        </telerik:NumericTextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
        <div>
          <table style="width: 100%;">
            <tr>
              <td colspan="3">
                <div id="TitleArea" runat="server" class="titleBar2">
                  <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                  <asp:Label ID="lblTitle" runat="server" Text="Tipos de cita"></asp:Label>
                </div>
              </td>
            </tr>
            <tr>
              <td>
                <div ID="AppointmentTypeId" class="normalText">
                  <asp:Label ID="lblAppointmentTypeId" runat="server" Text="TCIT ID:" 
                             ToolTip="Identificador del tipo de cita, lo usa internamente el sistema"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtAppointmentTypeId" runat="server" AutoPostBack="True" 
                               TabIndex="1" Width="75px" ></asp:TextBox>
                </div>
              </td>
              <td colspan="2">
                <div ID="Name" class="normalText">
                  <asp:Label ID="lblName" runat="server" Text="Nombre:" 
                             ToolTip="Nombre del tipo de cita"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtName" runat="server" 
                               TabIndex="2" Width="247px"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td>

              </td>
                
              <td colspan="2">
                <div ID="Duration" class="normalText">
                  <asp:Label ID="lblDuration" runat="server" Text="Duración (min):" 
                             ToolTip="Valor en minutos que se calcula que dura como media este tipo de cita"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtDuration" runat="server" 
                               TabIndex="5" Width="119px"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="3">
                <div ID="Buttons" class="buttonsFomat">
                  <asp:ImageButton ID="btnAccept" runat="server" TabIndex="6" 
                                   ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                  &nbsp;
                  <asp:ImageButton ID="btnCancel" runat="server" TabIndex="7" 
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
