<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
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
        //Put your JavaScript code here.
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <div>
        <p>
          Test AriClinic
        </p>
        <asp:Button ID="btnTest" runat="server" Text="TEST" onclick="btnTest_Click" />
        &nbsp;
        <asp:Button 
          ID="btnProgess" runat="server" Text="Progreso" onclick="btnProgess_Click" />
        <br />
        <telerik:radprogressmanager id="RadProgressManager1" runat="server" />
        <telerik:radprogressarea id="RadProgressArea1" runat="server" displaycancelbutton="False"
                                 progressindicators="FilesCountBar,
                                 FilesCount,
                                 FilesCountPercent,                      
                                 SelectedFilesCount,                      
                                 CurrentFileName,                      
                                 TimeElapsed,                      
                                 TimeEstimated">
        </telerik:radprogressarea>
        <br />
        <asp:TextBox ID="txtTest" runat="server" TextMode="MultiLine" Height="204px" 
                     Width="435px"></asp:TextBox>
        <br />

      </div>
    </form>
  </body>
</html>
