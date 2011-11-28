<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabTestForm.aspx.cs" Inherits="LabTestForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Tipo de prueba de laboratorio
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    <link href="dialog_box.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico"/>
  </head>
  <body>
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
      <script type="text/javascript" src="GeneralFormFunctions.js">
        //Put your JavaScript code here.
      </script>
      <script type="text/javascript" src="dialog_box.js"></script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
          <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
              <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" />
            </UpdatedControls>
          </telerik:AjaxSetting>
        </AjaxSettings>
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <div id="content" style="height:0px">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
          <table width="100%">
            <tr>
              <td colspan="2">
                <div id="TitleArea" class="titleBar2">
                  <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                  <asp:Label ID="lblTitle" runat="server" Text="Tipo de prueba de laboratorio"></asp:Label>
                </div>
              </td>
            </tr>
            <tr>
              <td width="20%">
                <div id="LabTestId" class="normalText">
                  <asp:Label ID="lblLabTestId" runat="server" Text="ID:" 
                             ToolTip="Identificador del tipo de prueba, lo usa internamente el sistema"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtLabTestId" runat="server" Enabled="false" Width="100%" TabIndex="1"></asp:TextBox>
                </div>
              </td>
              <td>
                <div id="Name" class="normalText">
                  <asp:Label ID="lblName" runat="server" Text="Nombre del tipo de unidad:" 
                             ToolTip="Nombre del tipo de prueba"></asp:Label>
                  <br />
                  <telerik:RadTextBox ID="txtName" runat="server" Width="100%" TabIndex="2">
                  </telerik:RadTextBox>
                  <br />
                  <asp:RequiredFieldValidator ID="valName" runat="server" Display="Dynamic" 
                                              ControlToValidate="txtName" CssClass="normalTextRed"
                                              ErrorMessage="Se necesita un nombre el tipo de prueba">
                  </asp:RequiredFieldValidator>
                </div>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div id="GeneralType" class="normalText">
                  <asp:Label ID="lblGeneralType" runat="server" Text="Tipo general"></asp:Label>
                  <br />
                  <telerik:RadComboBox ID="rdcGeneralType" runat="server" Width="100%" TabIndex="3">
                  </telerik:RadComboBox>
                </div>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div id="UnitType" class="normalText">
                  <asp:Label ID="lblUnitType" runat="server" Text="Unidades"></asp:Label>
                  <br />
                  <telerik:RadComboBox ID="rdcUnitType" runat="server" Width="100%" TabIndex="4">
                  </telerik:RadComboBox>
                </div>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div id="MinValue" class="normalText">
                  <asp:Label runat="server" ID="lblMinValue" Text="Valor mínimo"></asp:Label>
                  <br />
                  <telerik:RadNumericTextBox ID="txtMinValue" runat="server" Width="100%" TabIndex="5" 
                  DataType="System.Decimal" NumberFormat-DecimalDigits="5">
                  </telerik:RadNumericTextBox>
                  <br />
                  <asp:CustomValidator runat="server" ID="valMinValue" ControlToValidate="txtMinValue" 
                                       ErrorMessage="Debe proporcionar un valor, cero si no hay control de mínimo"
                                       ValidateEmptyText= "true"
                                       CssClass="normalTextRed" OnServerValidate="valMinValue_ServerValidate" >
                  </asp:CustomValidator>
                </div>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div id="MaxValue" class="normalText">
                  <asp:Label runat="server" ID="lblMaxValue" Text="Valor máximo"></asp:Label>
                  <br />
                  <telerik:RadNumericTextBox ID="txtMaxValue" runat="server" Width="100%" TabIndex="6" 
                  DataType="System.Decimal" NumberFormat-DecimalDigits="5">
                  </telerik:RadNumericTextBox>
                  <br />
                  <asp:CustomValidator runat="server" ID="valMaxValue" ControlToValidate="txtMaxValue" 
                                       ErrorMessage="Debe proporcionar un valor, cero si no hay control de máximo" 
                                       CssClass="normalTextRed" ValidateEmptyText="True"
                                       OnServerValidate="valMaxValue_ServerValidate" ></asp:CustomValidator>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <div ID="Buttons" class="buttonsFomat">
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
          <div id="FooterArea">
            <telerik:RadNotification ID="RadNotification1" runat="server" 
                                     ContentIcon="images/warning_32.png" AutoCloseDelay="0" 
                                     TitleIcon="images/warning_16.png" EnableRoundedCorners="True" EnableShadow="True" 
                                     Height="100px" Position="Center" Title="WARNING" Width="300px">
            </telerik:RadNotification>
          </div>
        </telerik:RadAjaxPanel>
      </div>
    </form>
  </body>
</html>
