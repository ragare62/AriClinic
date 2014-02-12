<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="UserForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Usuario
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
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
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
        <table width="100%">
            <tr>
                <td colspan="10">
                    <div id="TitleArea" class="titleBar2">
                      <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                      <asp:Label ID="lblTitle" runat="server" Text="Usuario"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="UserId" class="normalText">
                      <asp:Label ID="lblUserId" runat="server" Text="ID:" 
                                 ToolTip="Identificador de usuario, lo usa internamente el sistema"></asp:Label>
                      <br />
                      <asp:TextBox ID="txtUserId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                    </div>
                </td>
                <td colspan="8">
                    <div id="Name" class="normalText">
                      <asp:Label ID="lblName" runat="server" Text="Nombre de usuario:" 
                                 ToolTip="Nombre del usuario"></asp:Label>
                      <br />
                      <asp:TextBox ID="txtName" runat="server" Width="287px" TabIndex="1"></asp:TextBox>
                    </div>
                </td>
            </tr>
        <tr>
            <td colspan="5">
                <div ID="Login" class="normalText">
                  <asp:Label ID="lblLogin" runat="server" Text="Login:" 
                             ToolTip="Login a utilizar para conectarse"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtLogin" runat="server" Width="159px" TabIndex="2"></asp:TextBox>
                </div>
            </td>
            <td colspan ="5">
                <div ID="Password1" class="normalText">
                  <asp:Label ID="lblPassword1" runat="server" Text="Contraseña:" 
                             ToolTip="Contraseña del acceso, si no se desea cambiar no escriba nada"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtPassword1" runat="server" Width="199px" TextMode="Password" TabIndex="3"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <div ID="Group" class="normalText">
                  <asp:Label ID="lblGroup" runat="server" Text="Grupo:" 
                             ToolTip="Grupo al que pertenece"></asp:Label>
                  <br />
                  <asp:DropDownList ID="ddlGroup" runat="server" Height="22px" Width="164px" 
                        TabIndex="5">
                  </asp:DropDownList>
                </div>
            </td>
            <td colspan="5">
                <div ID="Password2" class="normalText">
                  <asp:Label ID="lblPassword2" runat="server" Text="Repita contraseña:" 
                             ToolTip="Debe coincidir con la del campo anterior"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtPassword2" runat="server" Width="199px" TextMode="Password" TabIndex="4"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="10">
               <div ID="Professional" class="normalText">
                  <asp:Label ID="lblProfessional" runat="server" Text="Profesional asociado:" 
                             ToolTip="Profesional con el que se realaciona"></asp:Label>
                  <br />
                  <asp:DropDownList ID="ddlProfessional" runat="server" Height="22px" Width="386px" 
                        TabIndex="5">
                  </asp:DropDownList>
               </div>
            </td>
        </tr>

        <tr>
            <td colspan="10">
               <div ID="Profile" class="normalText">
                  <asp:Label ID="lblProfile" runat="server" Text="Perfil básico del usuario:" 
                             ToolTip="Perfil por defecto del usuario"></asp:Label>
                  <br />
                  <asp:DropDownList ID="ddlProfile" runat="server" Height="22px" Width="386px" 
                        TabIndex="5">
                      <asp:ListItem Value="0">Medico - administrativo</asp:ListItem>
                      <asp:ListItem Selected="True" Value="1">Médico</asp:ListItem>
                      <asp:ListItem Value="2">Administrativo</asp:ListItem>
                      <asp:ListItem Value="3">Administrativo - Clínica</asp:ListItem>
                  </asp:DropDownList>
               </div>
            </td>
        </tr>
        <tr>
            <td colspan="10">
               <div ID="BaseVisitType" class="normalText">
                  <asp:Label ID="lblBaseVisitType" runat="server" Text="Tipo de visita por defecto:" 
                             ToolTip="Tipo de visita por defecto"></asp:Label>
                  <br />
                  <asp:DropDownList ID="ddlBaseVisitType" runat="server" Height="22px" Width="386px" 
                        TabIndex="6">
                  </asp:DropDownList>
               </div>
            </td>
        </tr>
        <tr>
            <td colspan="10">
               <div ID="Clinic" class="normalText">
                  <asp:Label ID="lblClini" runat="server" Text="Clínica del usuario:" 
                             ToolTip="Clínica del usuario"></asp:Label>
                  <br />
                  <asp:DropDownList ID="ddlClinic" runat="server" Height="22px" Width="386px" 
                        TabIndex="7">
                  </asp:DropDownList>
               </div>
            </td>
        </tr>
        <tr>
            <td colspan="10">
                <div ID="Message" class="messageText">
                  <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="10">
                <div ID="Buttons" class="buttonsFomat">
                  <asp:ImageButton ID="btnAccept" runat="server" 
                                   ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="8" />
                  &nbsp;
                  <asp:ImageButton ID="btnCancel" runat="server" 
                                   ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                   onclick="btnCancel_Click" ToolTip="Salir sin guardar"  TabIndex="9"/>
                </div>
            </td>
        </tr>
        </table>

      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
