<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailForm.aspx.cs" Inherits="EmailForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Correo electrónico
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
              width: 628px;
          }
          #EmailId
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
              width: 318px;
          }
          #Message
          {
              z-index: 1;
              left: 7px;
              top: 148px;
              position: absolute;
              height: 44px;
              width: 629px;
          }
          #Buttons
          {
              z-index: 1;
              left: 11px;
              top: 203px;
              position: absolute;
              height: 26px;
              width: 624px;
          }
          #Type
          {
              z-index: 1;
              left: 450px;
              top: 39px;
              position: absolute;
              height: 44px;
              width: 190px;
          }
          #Url
          {
              z-index: 1;
              left: 117px;
              top: 90px;
              position: absolute;
              height: 44px;
              width: 522px;
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
            <telerik:TargetInput ControlID="txtUrl" />
          </TargetControls>

          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
        <telerik:RegExpTextBoxSetting ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
          <TargetControls>
            <telerik:TargetInput ControlID="txtUrl" />
          </TargetControls>
        </telerik:RegExpTextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 229px; width: 648px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Correo electrónico"></asp:Label>
        </div>
        <div id="EmailId" class="normalText">
          <asp:Label ID="lblEmailId" runat="server" Text="ID:" 
                     ToolTip="Identificador de email, lo usa internamente el sistema."></asp:Label>
          <br />
          <asp:TextBox ID="txtEmailId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
        </div>
        <div id="Caller" class="normalText">
          <asp:Label ID="lblCaller" runat="server" Text="Correo electrónico de:" 
                     ToolTip="A quien se asigna este correo"></asp:Label>
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
        <div ID="Url" class="normalText">
          <asp:Label ID="lblUrl" runat="server" Text="Correo:" 
                     ToolTip="Correo electrónico"></asp:Label>
          <br />
          <asp:TextBox ID="txtUrl" runat="server" Width="310px" TabIndex="2"></asp:TextBox>
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
