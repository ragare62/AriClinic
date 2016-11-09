<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentsPatient.aspx.cs" Inherits="DocumentsPatient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Documentos</title>
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
      <script type="text/javascript">
          function OnExplorerFileOpen(oExplorer, args) {
              if (!args.get_item().isDirectory()) {
                  setTimeout(function () {
                      var oWindowManager = oExplorer.get_windowManager();
                      var previewWinow = oWindowManager.getActiveWindow(); // Gets the current active widow.
                      previewWinow.setSize(500, 500); // resize the window
                      previewWinow.set_behaviors(Telerik.Web.UI.WindowBehaviors.Move + Telerik.Web.UI.WindowBehaviors.Close + Telerik.Web.UI.WindowBehaviors.Resize
                      + Telerik.Web.UI.WindowBehaviors.Maximize + Telerik.Web.UI.WindowBehaviors.Minimize)
                      //previewWinow.maximize(); //alternatively, maximize it. You can use its entire API
                  }, 100);   // Some timeout is required in order to allow the window to become active
              }
          }
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
          onajaxrequest="RadAjaxManager1_AjaxRequest">
      </telerik:RadAjaxManager>
 
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <div id="TitleArea" runat="server" class="titleBar2">
        <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          
        <asp:Label ID="lblTitle" runat="server" Text="Documentos" 
                   meta:resourcekey="lblTitleResource1"></asp:Label>
      </div>
      <div id="FileExplorerContainer">

        <telerik:RadFileExplorer ID="RadFileExplorer1" Runat="server" Width="100%" OnClientFileOpen="OnExplorerFileOpen"
                                 EnableCopy="True" style="margin-top: 0px">
          <Configuration ViewPaths="/docs" UploadPaths="/docs"
                         DeletePaths="docs" />
        </telerik:RadFileExplorer>

      </div>
    </form>
  </body>
</html>
