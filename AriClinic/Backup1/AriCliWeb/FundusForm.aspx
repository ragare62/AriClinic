<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FundusForm.aspx.cs" Inherits="FundusForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Fondo de ojo
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    <link href="dialog_box.css" rel="stylesheet" type="text/css" />
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
      <script type="text/javascript" src="dialog_box.js"></script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
          <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
              <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" />
            </UpdatedControls>
          </telerik:AjaxSetting>
        </AjaxSettings>
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadInputManager ID="RadInputManager1" runat="server">
        <telerik:TextBoxSetting Validation-IsRequired="true">
          <TargetControls>
            <telerik:TargetInput ControlID="txtName" /> 
          </TargetControls>
        </telerik:TextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <div id="content" style="height:0px">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
          <table width="100%" class="normalText" style="text-align:center;">
            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="OpticalNerve" class="normalText">
                  <asp:Label ID="lblOpticalNerve" runat="server" Text="Nervio óptico:" 
                             ToolTip="Información relativa a la conjuntiva"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtOpticalNerve" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>

            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Vessels" class="normalText">
                  <asp:Label ID="lblVessels" runat="server" Text="Vasos:" 
                             ToolTip="Información relativa a la cornea"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtVessels" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>

            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Macula" class="normalText">
                  <asp:Label ID="lblMacula" runat="server" Text="Mácula:" 
                             ToolTip="Información relativa a la cornea"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtMacula" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>


            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Vitreous" class="normalText">
                  <asp:Label ID="lblVitreous" runat="server" Text="Vítreo:" 
                             ToolTip="Información Vitreous"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtVitreous" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Periphery" class="normalText">
                  <asp:Label ID="lblPeriphery" runat="server" Text="Periferia:" 
                             ToolTip="Información relativa al iris"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtPeriphery" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="6">
                <div ID="Buttons" class="buttonsFomat">
                  <asp:ImageButton ID="btnAccept" runat="server" 
                                   ImageUrl="~/images/disk_blue_ok.png" onclick="btnAccept_Click" ToolTip="Guardar" />
                </div>
              </td>
            </tr>
          </table>                      

        </telerik:RadAjaxPanel>
      </div>
    </form>
  </body>
</html>
