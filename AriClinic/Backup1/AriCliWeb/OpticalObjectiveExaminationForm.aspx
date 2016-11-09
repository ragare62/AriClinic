<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpticalObjectiveExaminationForm.aspx.cs" Inherits="OpticalObjectiveExaminationForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Sin gafas
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
              <td colspan="5" class="underlined">
                <asp:Label ID="lblRightEye" runat="server" Text="Ojo derecho"></asp:Label>
              </td>
              <td colspan="5" class="underlined">
                <asp:Label ID="lblLeftEye" runat="server" Text="Ojo izquierdo"></asp:Label>
              </td>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td>
              </td>
              <td>
                <asp:Label ID="lblEsfRight" runat="server" Text="Esferici."></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblCylRight" runat="server" Text="Cilindro"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblAxisRight" runat="server" Text="Eje"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblPrismRight" runat="server" Text="Prisma"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblVisAcuRight" runat="server" Text="A. Visual"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblEsfLeft" runat="server" Text="Esferici."></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblCylLeft" runat="server" Text="Cilindro"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblAxisLeft" runat="server" Text="Eje"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblPrismLeft" runat="server" Text="Prisma"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblVisAcuLeft" runat="server" Text="A. Visual"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblCenter" runat="server" Text="Centros"></asp:Label>
              </td>
              <td>
                <asp:Label ID="lblAcu" runat="server" Text="A. Visual"></asp:Label>
              </td>
            </tr>


            <tr>
              <td>
                <asp:Label ID="lblFar" runat="server" Text="Lejos"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtFarSphericityRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarCylinderRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarAxisRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarPrismRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarVisualAcuityRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarSphericityLefttEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarCylinderLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarAxisLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarPrismLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarVisualAcuityLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarCenter" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtFarAcuity" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Label ID="lblClose" runat="server" Text="Cerca"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtCloseSphericityRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseCylinderRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseAxisRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtClosePrismRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseVisualAcuityRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseSphericityLefttEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseCylinderLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseAxisLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtClosePrismLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseVisualAcuityLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseCenter" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtCloseAcuity" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>

            </tr> 
            <tr>
              <td>
                <asp:Label ID="lblBoth" runat="server" Text="Ambos"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtBothSphericityRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothCylinderRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothAxisRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothPrismRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothVisualAcuityRightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothSphericityLefttEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothCylinderLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothAxisLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothPrismLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothVisualAcuityLeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothCenter" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
              <td>
                <asp:TextBox ID="txtBothAcuity" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
              </td>
            
            </tr>
            <tr>
                <td colspan="4"></td>
                <td>K1</td>
                <td>
                    <asp:TextBox ID="txtK1RightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtK1LeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
                </td>
                <td colspan="6"></td>
            </tr>
            <tr>
                <td colspan="4"></td>
                <td>K2</td>
                <td>
                    <asp:TextBox ID="txtK2RightEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtK2LeftEye" runat="server" CssClass="centered" Width="50px"></asp:TextBox>
                </td>
                <td colspan="6"></td>
            </tr>
            <tr>
              <td colspan="13" style="text-align:left;">
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
              <td colspan="13">
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
