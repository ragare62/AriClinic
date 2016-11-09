<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AntSegmentForm.aspx.cs" Inherits="AntSegmentForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Motilidad y anejos
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
                <div id="Conjunctiva" class="normalText">
                  <asp:Label ID="lblConjunctiva" runat="server" Text="Conjuntiva:" 
                             ToolTip="Información relativa a la conjuntiva"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtConjunctiva" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>

            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Cornea" class="normalText">
                  <asp:Label ID="lblCornea" runat="server" Text="Cornea:" 
                             ToolTip="Información relativa a la cornea"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtCornea" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>

            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Chamber" class="normalText">
                  <asp:Label ID="lblChamber" runat="server" Text="Cámara:" 
                             ToolTip="Información relativa a la cornea"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtChamber" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>


            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Tyndall" class="normalText">
                  <asp:Label ID="lblTyndall" runat="server" Text="Tyndall:" 
                             ToolTip="Información Tyndall"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtTyndall" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Iris" class="normalText">
                  <asp:Label ID="lblIris" runat="server" Text="Iris:" 
                             ToolTip="Información relativa al iris"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtIris" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Pupila" class="normalText">
                  <asp:Label ID="lblPupil" runat="server" Text="Pupila:" 
                             ToolTip="Información relativa a la pupila"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtPupil" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>

            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Crystalline" class="normalText">
                  <asp:Label ID="lblCrystalline" runat="server" Text="Cristalino:" 
                             ToolTip="Información relativa al cristalino"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtCrystalline" runat="server" TextMode="MultiLine" Height="30px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>

            <%--Zona de títulos--%>

            <tr>
              <td></td>
              <td>
                
              </td>
              <td>
                
              </td>
                
              <td></td>
              <td class="underlined normalText">
                <asp:Label ID="Label1" runat="server" Text="OJO DERECHO"></asp:Label>
              </td>
              <td class="underlined normalText">
                <asp:Label ID="Label2" runat="server" Text="OJO IZQUIERDO"></asp:Label>
              </td>
            </tr>

            <tr class="normalText">
              <td>
                
              </td>
              <td>
              </td>
              <td>
              </td>
                
              <td>
                <asp:Label ID="lblEyestrain" runat="server" Text="Tensión ocular:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtEyestrainRE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtEyestrainLE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
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
