<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressForm.aspx.cs" Inherits="AddressForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Dirección
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
              width: 666px;
          }
          #AddressId
          {
              z-index: 1;
              left: 5px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 99px;
          }
          #Caller
          {
              z-index: 1;
              left: 117px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 321px;
          }
          #Message
          {
              z-index: 1;
              left: 6px;
              top: 258px;
              position: absolute;
              height: 44px;
              width: 672px;
          }
          #Buttons
          {
              z-index: 1;
              left: 5px;
              top: 314px;
              position: absolute;
              height: 26px;
              width: 674px;
          }
          #Type
          {
              z-index: 1;
              left: 485px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 190px;
          }
          #Street
          {
              z-index: 1;
              left: 8px;
              top: 93px;
              position: absolute;
              height: 44px;
              width: 669px;
          }
          #Street2
          {
              z-index: 1;
              left: 8px;
              top: 144px;
              position: absolute;
              height: 44px;
              width: 667px;
          }
          #PostCode
          {
              z-index: 1;
              left: 8px;
              top: 200px;
              position: absolute;
              height: 44px;
              width: 66px;
          }
          #City
          {
              z-index: 1;
              left: 87px;
              top: 200px;
              position: absolute;
              height: 44px;
              width: 243px;
              right: 356px;
          }
          #Province
          {
              z-index: 1;
              left: 341px;
              top: 200px;
              position: absolute;
              height: 44px;
              width: 153px;
              right: 192px;
          }
          #Country
          {
              z-index: 1;
              left: 521px;
              top: 200px;
              position: absolute;
              height: 44px;
              width: 156px;
              right: 9px;
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
            <telerik:TargetInput ControlID="txtCaller" />
            <telerik:TargetInput ControlID="txtStreet" />
            <telerik:TargetInput ControlID="txtCity" />
            <telerik:TargetInput ControlID="txtProvince" />
            <telerik:TargetInput ControlID="txtCountry" />
          </TargetControls>

          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 337px; width: 690px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Dirección"></asp:Label>
        </div>
        <div id="AddressId" class="normalText">
          <asp:Label ID="lblAddressId" runat="server" Text="ID:" 
                     ToolTip="Identificador de usuario, lo usa interCallernte el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtAddressId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
        </div>
        <div id="Caller" class="normalText">
          <asp:Label ID="lblCaller" runat="server" Text="Dirección de:" 
                     ToolTip="A quien se asigna esta dirección"></asp:Label>
          <br />
          <asp:TextBox ID="txtCaller" runat="server" Width="311px" TabIndex="1" 
                       Enabled="False"></asp:TextBox>
        </div>
        <div ID="Type" class="normalText">
          <asp:Label ID="lblType" runat="server" Text="Tipo:" 
                     ToolTip="Grupo al que pertenece"></asp:Label>
          <br />
          <asp:DropDownList ID="ddlType" runat="server" Height="23px" Width="181px" 
                            TabIndex="5">
          </asp:DropDownList>
        </div>
        <div ID="Street" class="normalText">
          <asp:Label ID="lblStreet" runat="server" Text="Dirección:" 
                     ToolTip="Street a utilizar para conectarse"></asp:Label>
          <br />
          <asp:TextBox ID="txtStreet" runat="server" Width="660px" TabIndex="2"></asp:TextBox>
        </div>
        <div ID="Street2" class="normalText">
          <asp:Label ID="lblStreet2" runat="server" Text="Dirección (Ampliación):" 
                     ToolTip="Datos adicionales sobre la dirección"></asp:Label>
          <br />
          <asp:TextBox ID="txtStreet2" runat="server" TabIndex="2" Width="660px"></asp:TextBox>
        </div>
        <div ID="PostCode" class="normalText">
          <asp:Label ID="lblPostCode" runat="server" Text="Cod.Postal:" 
                     ToolTip="Codigo postal"></asp:Label>
          <br />
          <asp:TextBox ID="txtPostCode" runat="server" TabIndex="2" Width="61px"></asp:TextBox>
        </div>
        <div ID="City" class="normalText">
          <asp:Label ID="lblCity" runat="server" Text="Población:" 
                     ToolTip="Población de residencia"></asp:Label>
          <br />
          <asp:TextBox ID="txtCity" runat="server" TabIndex="2" Width="223px"></asp:TextBox>
        </div>
        <div ID="Province" class="normalText">
          <asp:Label ID="lblProvince" runat="server" Text="Provincia:" 
                     ToolTip="provincia de residencia"></asp:Label>
          <br />
          <asp:TextBox ID="txtProvince" runat="server" TabIndex="2" Width="145px"></asp:TextBox>
        </div>
        <div ID="Country" class="normalText">
          <asp:Label ID="lblCountry" runat="server" Text="Pais:" 
                     ToolTip="Pais de residencia"></asp:Label>
          <br />
          <asp:TextBox ID="txtCountry" runat="server" TabIndex="2" Width="147px" ></asp:TextBox>
        </div>
        <div ID="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>
        <div ID="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="6" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar"  TabIndex="7"/>
        </div>

      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
