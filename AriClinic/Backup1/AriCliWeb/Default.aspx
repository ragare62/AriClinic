<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

<%@ Register src="UscLogin.ascx" tagname="UscLogin" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      AriClinic (c) Ariadna Software S.L. comercial@ariclinic.com  (902 888 878)
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    <link href="dialog_box.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
          #LoginArea
          {
              z-index: 1;
              left: 10px;
              top: 102px;
              position: absolute;
              height: 500px;
              width: 1007px;
          }
          #AuxControls
          {
              z-index: 1;
              left: 10px;
              top: 900px;
              position: absolute;
              height: 44px;
              width: 1007px;
          }
      </style>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico"/>
  </head>
  <body>
    <form id="form1" runat="server">
      <div id="AuxControls">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
          <Scripts>
            <%--Needed for JavaScript IntelliSense in VS2010--%>
            <%--For VS2008 replace RadScriptManager with ScriptManager--%>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
          </Scripts>
        </telerik:RadScriptManager>
        <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
        </telerik:RadSkinManager>
        <script type="text/javascript" src="dialog_box.js"></script>
        <script type="text/javascript">
          //Put your JavaScript code here.
        </script>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
        </telerik:RadAjaxLoadingPanel>
      </div>
      <div id="Title">

        <table class="titleBar">
          <tr>
            <td>
              <asp:Label ID="lblApplication" runat="server" Text="AriClinic VRS 2.0" CssClass="titleBigBar"></asp:Label>
            </td>
            <td>
              <img alt="logo" src="images/logo_web.png" align="right" />
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblHealthcareCompany" runat="server" Text="Empresa sanitaria"></asp:Label>
            </td>
            <td>
              &nbsp;
            </td>
          </tr>
        </table>

      </div>
      <div id="LoginArea">
        <div id="content">
          <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="200px" Width="300px">
            <uc1:UscLogin ID="UscLogin1" runat="server" />
          </telerik:RadAjaxPanel>
        </div>
      </div>
    </form>
  </body>
</html>
