<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaxTypeForm.aspx.cs" Inherits="TaxTypeForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Tipo de IVA
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
          #TitleArea
          {
              z-index: 1;
              left: 5px;
              top: 0px;
              position: absolute;
              height: 19px;
              width: 400px;
          }
          #TaxTypeId
          {
              z-index: 1;
              left: 5px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 99px;
          }
          #Name
          {
              z-index: 1;
              left: 117px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 291px;
          }
          #Message
          {
              z-index: 1;
              left: 5px;
              top: 152px;
              position: absolute;
              height: 44px;
              width: 403px;
          }
          #Buttons
          {
              z-index: 1;
              left: 5px;
              top: 211px;
              position: absolute;
              height: 26px;
              width: 403px;
          }
          #Percentage
          {
              z-index: 1;
              left: 293px;
              top: 91px;
              position: absolute;
              height: 44px;
              width: 115px;
          }
          </style>
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
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="210px" 
                            Width="420px" 
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 231px; width: 420px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Tipo de IVA"></asp:Label>
        </div>
        <div id="TaxTypeId" class="normalText">
          <asp:Label ID="lblTaxTypeId" runat="server" Text="ID:" 
                     ToolTip="Identificador de tipo de IVA, lo usa internamente el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtTaxTypeId" runat="server" Enabled="false" Width="89px" TabIndex="0"></asp:TextBox>
        </div>

        <div id="Name" class="normalText">
          <asp:Label ID="lblName" runat="server" Text="Nombre de tipo:" 
                     ToolTip="Nombre a asignar al tipo de IVA"></asp:Label>
          <br />
          <asp:TextBox ID="txtName" runat="server" Width="287px" TabIndex="1"></asp:TextBox>
        </div>


        <div ID="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>


        <div ID="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="4" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar" TabIndex="5" />
        </div>


        <div ID="Percentage" class="normalTextRight">
          <asp:Label ID="lblPercentage" runat="server" Text="Porcentaje (%):" 
                     ToolTip="Porcentaje a aplicar para este tipo"></asp:Label>
          <br />
          <asp:TextBox ID="txtPercentage" runat="server" Width="108px" TabIndex="3" style="text-align:right"></asp:TextBox>
        </div>


      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
