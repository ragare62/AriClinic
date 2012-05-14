<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="UserForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Usuario
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
          #UserId
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
              left: 6px;
              top: 258px;
              position: absolute;
              height: 44px;
              width: 403px;
          }
          #Buttons
          {
              z-index: 1;
              left: 5px;
              top: 314px;
              position: absolute;
              height: 26px;
              width: 403px;
          }
          #Group
          {
              z-index: 1;
              left: 9px;
              top: 154px;
              position: absolute;
              height: 33px;
              width: 169px;
          }
          #Professional
          {
              z-index: 1;
              left: 10px;
              top: 206px;
              position: absolute;
              height: 33px;
              width: 391px;
          }          
          #Login
          {
              z-index: 1;
              left: 8px;
              top: 93px;
              position: absolute;
              height: 44px;
              width: 170px;
          }
          #Password1
          {
              z-index: 1;
              left: 200px;
              top: 93px;
              position: absolute;
              height: 44px;
              width: 206px;
          }
          #Password2
          {
              z-index: 1;
              left: 199px;
              top: 148px;
              position: absolute;
              height: 44px;
              width: 206px;
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
            <telerik:TargetInput ControlID="txtLogin" />
          </TargetControls>

          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 342px; width: 417px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Usuario"></asp:Label>
        </div>
        <div id="UserId" class="normalText">
          <asp:Label ID="lblUserId" runat="server" Text="ID:" 
                     ToolTip="Identificador de usuario, lo usa internamente el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtUserId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
        </div>
        <div id="Name" class="normalText">
          <asp:Label ID="lblName" runat="server" Text="Nombre de usuario:" 
                     ToolTip="Nombre del usuario"></asp:Label>
          <br />
          <asp:TextBox ID="txtName" runat="server" Width="287px" TabIndex="1"></asp:TextBox>
        </div>
        <div ID="Login" class="normalText">
          <asp:Label ID="lblLogin" runat="server" Text="Login:" 
                     ToolTip="Login a utilizar para conectarse"></asp:Label>
          <br />
          <asp:TextBox ID="txtLogin" runat="server" Width="159px" TabIndex="2"></asp:TextBox>
        </div>
        <div ID="Password1" class="normalText">
          <asp:Label ID="lblPassword1" runat="server" Text="Contraseña:" 
                     ToolTip="Contraseña del acceso, si no se desea cambiar no escriba nada"></asp:Label>
          <br />
          <asp:TextBox ID="txtPassword1" runat="server" Width="199px" TextMode="Password" TabIndex="3"></asp:TextBox>
        </div>
        <div ID="Password2" class="normalText">
          <asp:Label ID="lblPassword2" runat="server" Text="Repita contraseña:" 
                     ToolTip="Debe coincidir con la del campo anterior"></asp:Label>
          <br />
          <asp:TextBox ID="txtPassword2" runat="server" Width="199px" TextMode="Password" TabIndex="4"></asp:TextBox>
        </div>
        <div ID="Group" class="normalText">
          <asp:Label ID="lblGroup" runat="server" Text="Grupo:" 
                     ToolTip="Grupo al que pertenece"></asp:Label>
          <br />
          <asp:DropDownList ID="ddlGroup" runat="server" Height="22px" Width="164px" 
                TabIndex="5">
          </asp:DropDownList>
        </div>

       <div ID="Professional" class="normalText">
          <asp:Label ID="lblProfessional" runat="server" Text="Profesional asociado:" 
                     ToolTip="Profesional con el que se realaciona"></asp:Label>
          <br />
          <asp:DropDownList ID="ddlProfessional" runat="server" Height="22px" Width="386px" 
                TabIndex="5">
          </asp:DropDownList>
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
