<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessForm.aspx.cs" Inherits="ProcessForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Procesos
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
              left: 113px;
              top: 100px;
              position: absolute;
              height: 44px;
              width: 291px;
          }
          #Message
          {
              z-index: 1;
              left: 6px;
              top: 322px;
              position: absolute;
              height: 44px;
              width: 403px;
          }
          #Buttons
          {
              z-index: 1;
              left: 5px;
              top: 377px;
              position: absolute;
              height: 26px;
              width: 403px;
          }
          #Group
          {
              z-index: 1;
              left: 115px;
              top: 204px;
              position: absolute;
              height: 44px;
              width: 291px;
          }
          #Description
          {
              z-index: 1;
              left: 10px;
              top: 151px;
              position: absolute;
              height: 102px;
              width: 399px;
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
          #Code
          {
              z-index: 1;
              left: 115px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 291px;
          }
          #ParentProcess
          {
              z-index: 1;
              left: 112px;
              top: 261px;
              position: absolute;
              height: 44px;
              width: 295px;
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
            <telerik:TargetInput ControlID="txtCode" />
            <telerik:TargetInput ControlID="txtName" />
            <telerik:TargetInput ControlID="txtDescription" />
          </TargetControls>

          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            
                            
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 402px; width: 420px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Proceso"></asp:Label>
        </div>
        <div id="UserId" class="normalText">
          <asp:Label ID="lblProcessId" runat="server" Text="ID:" 
                     ToolTip="Identificador de proceso, lo usa internamente el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtProcessId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
        </div>
        <div ID="Code" class="normalText">
          <asp:Label ID="lblCode" runat="server" Text="Codigo:" 
                     ToolTip="Codigo interno que identifica el proceso. Si lo desconoce debe hablar con desarrollo"></asp:Label>
          <br />
          <asp:TextBox ID="txtCode" runat="server" TabIndex="1" Width="287px"></asp:TextBox>
        </div>
        <div id="Name" class="normalText">
          <asp:Label ID="lblName" runat="server" Text="Nombre del proceso:" 
                     ToolTip="Nombre del proceso"></asp:Label>
          <br />
          <asp:TextBox ID="txtName" runat="server" Width="287px" TabIndex="2"></asp:TextBox>
        </div>
        <div ID="Description" class="normalText">
          <asp:Label ID="lblDescription" runat="server" Text="Descripción:" 
                     ToolTip="Descripción del proceso"></asp:Label>
          <br />
          <asp:TextBox ID="txtDescription" runat="server" Width="393px" TabIndex="3" 
                       Height="83px" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div ID="ParentProcess" class="normalText">
          <asp:Label ID="lblParentProcess" runat="server" Text="Proceso padre:" 
                     ToolTip="Proceso del que depende según menú o en el que está incluido."></asp:Label>
          <br />
          <asp:DropDownList ID="ddlParentProcess" runat="server" Height="23px" 
                            Width="292px" TabIndex="4">
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
