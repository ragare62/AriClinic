<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Test" %>














<%@ Register Assembly="Telerik.OpenAccess.Web, Version=2013.1.418.2, Culture=neutral, PublicKeyToken=7ce17eeaf1d59342" Namespace="Telerik.OpenAccess" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link rel="stylesheet" type="text/css" href="dialog_box.css" />
<style type="text/css">
#content
{
z-index: 1;
left: 34px;
top: 27px;
position: absolute;
height: 451px;
width: 782px;
}
    #rdcauto
    {
        height: 176px;
    }
</style>
  </head>
  <body>
    <form id="form1" runat="server">
      <telerik:RadScriptManager ID="RadScriptManager1" runat="server" >
        <Scripts>
          <%--Needed for JavaScript IntelliSense in VS2010--%>
          <%--For VS2008 replace RadScriptManager with ScriptManager--%>
          <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
          <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
          <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
      </telerik:RadScriptManager>
      <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="dialog_box.js">
        </script>
        <script type="text/javascript">
          function ariDialog(title, message, type, modal, width, height)
          {
              showDialog(title, message, type, modal, width, height);
              setTimeout("ObtainSelected()", 100);
          }

          function ObtainSelected(tag)
          {
              if (DLGRESULT == 0)
                  setTimeout("ObtainSelected()", 100); // continue asking
              else if (DLGRESULT == 1) // accept
              {
                  //process value
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("yes");
              }
              else //cancel;
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("no");
              }
              return;
          }
        </script>
      </telerik:RadCodeBlock>
  
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                              onajaxrequest="RadAjaxManager1_AjaxRequest" >
        <AjaxSettings>
          <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
              <telerik:AjaxUpdatedControl ControlID="lblTest" />
            </UpdatedControls>
          </telerik:AjaxSetting>
        </AjaxSettings>
      </telerik:RadAjaxManager>
      <div id="rdcauto">
        <telerik:RadComboBox runat="server" ID="RadComboBox1" Height="100px" 
            EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
            EmptyMessage="Type here ..." onitemsrequested="RadComboBox1_ItemsRequested1" ItemsPerRequest="10" 
              Width="446px" >
        </telerik:RadComboBox>
      </div>

    </form>
  </body>

</html>
