<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcedureForm.aspx.cs" Inherits="ProcedureForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Procedimiento
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
      <telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
        <script type="text/javascript" src="GeneralFormFunctions.js"></script>
        <script type="text/javascript" src="dialog_box.js"></script>
        <script type="text/javascript">
          function refreshField(v1, v2, v3, v4, type)
          {
              if (type)
              {
                  switch (type)
                  {
                      case "Service":
                          document.getElementById('<%= txtServiceId.ClientID %>').value = v1;
                          document.getElementById('<%= txtServiceName.ClientID %>').value = v3;
                          break;
                  }
              }
          }
        </script>
      </telerik:RadCodeBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadInputManager ID="RadInputManager1" runat="server">
        <telerik:TextBoxSetting Validation-IsRequired="true">
          <TargetControls>
            <telerik:TargetInput ControlID="txtName" />
          </TargetControls>
          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
        <telerik:NumericTextBoxSetting Validation-IsRequired="true"  Culture="es-ES" DecimalDigits="2" 
                                       DecimalSeparator="," GroupSeparator="." 
                                       GroupSizes="3" NegativePattern="-n" 
                                       PositivePattern="n" MaxValue="100" MinValue="0">
          <TargetControls>
            <telerik:TargetInput ControlID="txtPercentage" />
          </TargetControls>
          <Validation IsRequired="True"></Validation>
        </telerik:NumericTextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" >
        <div>
          <table style="width: 100%;">
            <tr>
              <td colspan="2">
                <div id="TitleArea" class="titleBar2">
                  <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                  <asp:Label ID="lblTitle" runat="server" Text="Procedimiento"></asp:Label>
                </div>
              </td>
            </tr>
            <tr>
              <td>
                <div id="ProcedureId" class="normalText">
                  <asp:Label ID="lblProcedureId" runat="server" Text="ID:" 
                             ToolTip="Identificador del procedimiento, lo usa internamente el sistema"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtProcedureId" runat="server" Enabled="false" Width="80px" TabIndex="0"></asp:TextBox>
                </div>  
              </td>
              <td>
                <div id="Name" class="normalText">
                  <asp:Label ID="lblName" runat="server" Text="Nombre de procedimiento:" 
                             ToolTip="Nombre a asignar al procedimiento"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtName" runat="server" Width="247px" TabIndex="1"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td>
                <div ID="ServiceId" class="normalText">
                  <asp:Label ID="lblServiceId" runat="server" Text="SERV ID:" 
                             ToolTip="Identificador del servicio, lo usa internamente el sistema"></asp:Label>
                  <asp:ImageButton ID="btnServiceId" runat="server" 
                                   CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                   OnClientClick="searchService();"  
                                   ToolTip="Haga clic aquí para buscar servicios" 
                                   style="width: 10px"  />
                  <br />
                  <asp:TextBox ID="txtServiceId" runat="server" AutoPostBack="True" 
                               TabIndex="1" 
                               Width="80px" ontextchanged="txtServiceId_TextChanged"></asp:TextBox>
                </div>
              </td>
              <td>
                <div ID="ServiceName" class="normalText">
                  <asp:Label ID="lblServiceName" runat="server" Text="Servicio asociado:" 
                             ToolTip="Servicio que se corresponde con este procedimiento"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtServiceName" runat="server" Enabled="False" 
                               TabIndex="2" Width="247px"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <div ID="Buttons" class="buttonsFomat">
                  <asp:ImageButton ID="btnAccept" runat="server" 
                                   ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                   ToolTip="Guardar y salir" TabIndex="4" />
                  &nbsp;
                  <asp:ImageButton ID="btnCancel" runat="server" 
                                   ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                   onclick="btnCancel_Click" ToolTip="Salir sin guardar" TabIndex="5" />
                </div>
              </td>
            </tr>
          </table>
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
