<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Test" %>

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
            function ariDialog(title, message, type, modal, width, height) {
                showDialog(title, message, type, modal, width, height);
                setTimeout("ObtainSelected()", 100);
            }

            function ObtainSelected(tag) {
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
      <div id="toolb">
          <telerik:RadToolBar ID="RadToolBar1" Runat="server" Width="100%" 
              Skin="Office2007" onbuttonclick="RadToolBar1_ButtonClick">
              <Items>
                  <telerik:RadToolBarSplitButton runat="server" Text="Personas" Value="person">
                      <Buttons>
                          <telerik:RadToolBarButton runat="server" 
                              ImageUrl="~/images/toolbar/users_family.png" Text="Pacientes" Value="patient">
                          </telerik:RadToolBarButton>
                          <telerik:RadToolBarButton runat="server" ImageUrl="~/images/toolbar/users3.png" 
                              Text="Clientes" Value="customer">
                          </telerik:RadToolBarButton>
                      </Buttons>
                  </telerik:RadToolBarSplitButton>
                  <telerik:RadToolBarSplitButton runat="server" Text="Agendas" Value="diary">
                      <Buttons>
                          <telerik:RadToolBarButton runat="server" ImageUrl="~/images/toolbar/books.png" 
                              Text="Agendas (Todas)" Value="diary">
                          </telerik:RadToolBarButton>
                      </Buttons>
                  </telerik:RadToolBarSplitButton>
                  <telerik:RadToolBarSplitButton runat="server" 
                      ImageUrl="~/images/toolbar/calculator.png" Text="Notas de servicio">
                      <Buttons>
                          <telerik:RadToolBarButton runat="server" 
                              ImageUrl="~/images/toolbar/calculator.png" Text="N.Servi. (General)">
                          </telerik:RadToolBarButton>
                          <telerik:RadToolBarButton runat="server" 
                              ImageUrl="~/images/toolbar/calculator.png" Text="N.Servi (Anestesia)">
                          </telerik:RadToolBarButton>
                      </Buttons>
                  </telerik:RadToolBarSplitButton>
              </Items>
          </telerik:RadToolBar>
      </div>
      <div id="fx">
          <telerik:RadFileExplorer ID="RadFileExplorer1" runat="server" Skin="Office2007" 
              Width="100%" EnableCopy="True" style="margin-top: 0px">
              <Configuration ViewPaths="/docs" UploadPaths="/docs"
                        DeletePaths="docs" />
          </telerik:RadFileExplorer>
      </div>
<telerik:RadUpload ID="RadUpload1" runat="server">
</telerik:RadUpload>

      <telerik:RadProgressManager ID="RadProgressManager1" Runat="server" />

    </form>
  </body>
</html>
