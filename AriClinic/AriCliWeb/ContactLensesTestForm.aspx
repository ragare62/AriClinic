<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactLensesTestForm.aspx.cs" Inherits="ContactLensesTestForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Lentes de contacto
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
              <td></td>
              <td class="underlined">
                <asp:Label ID="lblRightEye" runat="server" Text="Ojo derecho"></asp:Label>
              </td>
              <td class="underlined">
                <asp:Label ID="lblLeftEye" runat="server" Text="Ojo izquierdo"></asp:Label>
              </td>
              <td class="underlined">
                <asp:Label ID="lblBothEyes" runat="server" Text="Ambos ojos"></asp:Label>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="lblFarAcuity" runat="server" Text="Agudeza visual lejos"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtFarAcuityRightEye" runat="server" CssClass="centered"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarAcuityLeftEye" runat="server" CssClass="centered"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarAcuityBothEyes" runat="server" CssClass="centered"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="lblCloseAcuity" runat="server" Text="Agudeza visual cerca" CssClass="centered"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtCloseAcuityRightEye" runat="server" CssClass="centered"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseAcuityLeftEye" runat="server" CssClass="centered"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseAcuityBothEyes" runat="server" CssClass="centered"></asp:TextBox>
              </td>
            </tr> 
            <tr>
              <td colspan="4" style="text-align:left;">
                <div id="Comments" class="normalText">
                  <asp:Label ID="lblComments" runat="server" Text="Resumen:" 
                             ToolTip="Resumen de la refractometría"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="60px" 
                               Width="100%"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="4">
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
