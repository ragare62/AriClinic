<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionForm.aspx.cs" Inherits="PermissionForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Asignación de permisos
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
          #Group
          {
              z-index: 1;
              left: 5px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 394px;
          }
          #Message
          {
              z-index: 1;
              left: 6px;
              top: 343px;
              position: absolute;
              height: 44px;
              width: 403px;
          }
          #Buttons
          {
              z-index: 1;
              left: 5px;
              top: 398px;
              position: absolute;
              height: 26px;
              width: 403px;
          }
          #Process
          {
              z-index: 1;
              left: 7px;
              top: 86px;
              position: absolute;
              height: 44px;
              width: 392px;
          }
          #View
          {
              z-index: 1;
              left: 8px;
              top: 142px;
              position: absolute;
              height: 44px;
              width: 392px;
          }
          #Create
          {
              z-index: 1;
              left: 8px;
              top: 192px;
              position: absolute;
              height: 44px;
              width: 392px;
          }
          #Modify
          {
              z-index: 1;
              left: 8px;
              top: 241px;
              position: absolute;
              height: 44px;
              width: 392px;
          }
          #Execute
          {
              z-index: 1;
              left: 8px;
              top: 288px;
              position: absolute;
              height: 44px;
              width: 392px;
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
      </telerik:RadInputManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            style="z-index: 1; left: 20px; top:20px; position: absolute; height: 424px; width: 417px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Asignación de permisos"></asp:Label>
        </div>
        <div id="Group" class="normalText">
          <asp:Label ID="lblGroup" runat="server" Text="Grupo:" 
                     ToolTip="Grupo para el que se aplican los permisos"></asp:Label>
          <br />
          <asp:TextBox ID="txtGroup" runat="server" Enabled="false" Width="386px"></asp:TextBox>
        </div>
        <div ID="Process" class="normalText">
          <asp:Label ID="lblProcess" runat="server" Text="Proceso:" 
                     ToolTip="Proceso específico con los permisos"></asp:Label>
          <br />
          <asp:TextBox ID="txtProcess" runat="server" Enabled="false" Width="382px"></asp:TextBox>
        </div>
        <div ID="View" class="normalText">
          <asp:Label ID="lblView" runat="server" Text="Ver:" 
                     ToolTip="Proceso específico con los permisos"></asp:Label>
          <br />
          <asp:CheckBox ID="chkView" runat="server" Text="Si no está activo el proceso ni aparece en menú" />
        </div>
        <div ID="Create" class="normalText">
          <asp:Label ID="lblCreate" runat="server" Text="Crear:" 
                     ToolTip="Proceso específico con los permisos"></asp:Label>
          <br />
          <asp:CheckBox ID="chkCreate" runat="server" 
                        Text="Si está activo el proceso permite crear nuevos registros" />
        </div>
        <div ID="Modify" class="normalText">
          <asp:Label ID="lblModify" runat="server" Text="Modificar:" 
                     ToolTip="Proceso específico con los permisos"></asp:Label>
          <br />
          <asp:CheckBox ID="chkModify" runat="server" 
                        Text="Si está activo el proceso permite modificar registros existentes" />
        </div>
        <div ID="Execute" class="normalText">
          <asp:Label ID="lblExecute" runat="server" Text="Ejecutar:" 
                     ToolTip="Proceso específico con los permisos"></asp:Label>
          <br />
          <asp:CheckBox ID="chkExecute" runat="server" 
                        Text="Si usa en casos especiales, diferentes para cada proceso." />
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
