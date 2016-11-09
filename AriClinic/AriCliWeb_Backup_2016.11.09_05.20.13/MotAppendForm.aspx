<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MotAppendForm.aspx.cs" Inherits="MotAppendForm" %>

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
                <div id="EyeMotility" class="normalText">
                  <asp:Label ID="lblEyeMotility" runat="server" Text="Motilidad ocular:" 
                             ToolTip="Información relativa a la motilidad ocular"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtEyeMotility" runat="server" TextMode="MultiLine" Height="60px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>

            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Eyebrows" class="normalText">
                  <asp:Label ID="lblEyebrows" runat="server" Text="Cejas:" 
                             ToolTip="Información relativa a las cejas"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtEyebrows" runat="server" TextMode="MultiLine" Height="60px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="PeriocularArea" class="normalText">
                  <asp:Label ID="lblPeriocularArea" runat="server" Text="Area periocular:" 
                             ToolTip="Información relativa al area periocular"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtPeriocularArea" runat="server" TextMode="MultiLine" Height="60px" 
                                       Width="100%"></telerik:RadTextBox >
                </div>
              </td>
            </tr>

            <%--Zona de títulos--%>

            <tr>
              <td></td>
              <td class="underlined normalText">
                <asp:Label ID="lblRE1" runat="server" Text="OJO DERECHO"></asp:Label>
              </td>
              <td class="underlined normalText">
                <asp:Label ID="lblLE1" runat="server" Text="OJO IZQUIERDO"></asp:Label>
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
                <asp:Label ID="Label3" runat="server" Text="Dist. interpalpebral:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC1RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC1LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
                
              <td>
                <asp:Label ID="lblC7" runat="server" Text="Lagoftalmos:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC7RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC7LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
            </tr>
            <tr class="normalText">
              <td>
                <asp:Label ID="lblC2" runat="server" Text="MRD1:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC2RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC2LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
                
              <td>
                <asp:Label ID="lblC8" runat="server" Text="Fenom. de Bell:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC8RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC8LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
            </tr>
            <tr class="normalText">
              <td>
                <asp:Label ID="lblC3" runat="server" Text="Ele tras fenil (MRDf):"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC3RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC3LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
                
              <td>
                <asp:Label ID="lblC9" runat="server" Text="Tono orbicular:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC9RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC9LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
            </tr>
            <tr class="normalText">
              <td>
                <asp:Label ID="lblC4" runat="server" Text="Expos. escleral:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC4RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC4LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
                
              <td>
                <asp:Label ID="lblC10" runat="server" Text="Laxitud párpado:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC10RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC10LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
            </tr>
            <tr class="normalText">
              <td>
                <asp:Label ID="lblC5" runat="server" Text="Pliegue párpado sup.:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC5RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC5LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
                
              <td>
                <asp:Label ID="lblC11" runat="server" Text="Exp. pliegue párpado sup.:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC11RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC11LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
            </tr>
            <tr class="normalText">
              <td>
                <asp:Label ID="lblC6" runat="server" Text="Funcion elevador:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC6RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC6LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
                
              <td>
                <asp:Label ID="lblC12" runat="server" Text="Exp. pliegue párpado inf.:"></asp:Label>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC12RE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
              <td>
                <telerik:RadNumericTextBox ID="txtC12LE" runat="server" CssClass="centered">
                </telerik:RadNumericTextBox>
              </td>
            </tr>
            <tr>
              <td colspan="6" style="text-align:left;">
                <div id="Comments" class="normalText">
                  <asp:Label ID="lblComments" runat="server" Text="Observaciones:" 
                             ToolTip="Observaciones"></asp:Label>
                  <br />
                  <telerik:RadTextBox  ID="txtComments" runat="server" TextMode="MultiLine" Height="60px" 
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
