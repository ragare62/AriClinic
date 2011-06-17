<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptInvoicePeriodForm.aspx.cs" Inherits="AriCliWeb.RptInvoicePeriodForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>
            Informe de categorías, profesionales y servicios prestados asociados
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
          #content
          {
              left: 10px;
              }
          /* Line 1 */
          #TitleArea
          {
              z-index: 1;
              left: 5px;
              top: 0px;
              height: 19px;
              width: 400px;
          }
          .subtitle
          {
              border-bottom-style: solid; 
              border-bottom-width: thin; 
              border-bottom-color: #158AFF; 
              font-size:small;
              }
          /* Line 2 */
          #FromDate
          {
              z-index: 1;
              left: 9px;
              height: 44px;
              width: 180px;
          }
          #ToDate
          {
              z-index: 1;
              height: 44px;
              width: 180px;
          }
          /* Line 3 */
          #anInvoice
          {
              z-index: 1;
              left: 9px;
              height: 44px;
              }
              /* Line 4 */
          #Message
          {
              z-index: 1;
              left: 6px;
              height: 31px;
              width: 403px;
          }
          /* Line 5 */
          #Buttons
          {
              z-index: 1;
              left: 6px;
              height: 26px;
              width: 403px;
          }
          
          </style>
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
            <script type="text/javascript" src="GeneralFormFunctions.js"></script>
            <script type="text/javascript" src="ReportFunctions.js"></script>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
            </telerik:RadSkinManager>
            <telerik:RadInputManager ID="RadInputManager1" runat="server">
                <telerik:TextBoxSetting Validation-IsRequired="true">
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtFromDate" />
                    </TargetControls>
                </telerik:TextBoxSetting>
            </telerik:RadInputManager>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                       AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
            </telerik:RadToolTipManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="300px" Width="420px" 
                                  style="z-index: 1; left: 0px; top:0px; position: absolute; height: 231px; width: 420px">
                <div id="content" class="normalText">
                    <%--  Line 1 --%>
                    <div id="TitleArea" class="titleBar2">
                        <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                        <asp:Label ID="lblTitle" runat="server" Text="Informe de facturas"></asp:Label>
                    </div>
                    <%--  Line 2 --%>
                    <div id="subtitle1" class="subtitle">
                        <br />
                        <asp:Label ID="lblPeriodo" runat="server" Text="Seleccionar un ciclo de facturación:"></asp:Label>
                    </div>
                    <table id="DateTable">
                        <tr>
                            <td>
                                <div id="FromDate">
                                    <asp:Label ID="lblFromDate" runat="server" Text="Desde fecha:" 
                                               ToolTip="Fecha inicial para el informe"></asp:Label>
                                    <br />
                                    <telerik:RadDatePicker ID="rddpFromDate" runat="server" ToolTip="Seleccionar fecha ">
                                    </telerik:RadDatePicker>
                                </div>
                            </td>
                            <td>
                                <div id="ToDate">
                                    <asp:Label ID="lblToDate" runat="server" Text="Hasta fecha:" 
                                               ToolTip="Fecha final para el informe"></asp:Label>
                                    <br />
                                    <telerik:RadDatePicker ID="rddpToDate" runat="server" ToolTip="Seleccionar fecha ">
                                    </telerik:RadDatePicker>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <%--  Line 3 --%>
<%--                    <div id="subtitle2" class="subtitle">
                        <br />
                        <asp:Label ID="lblfact" runat="server" Text="Seleccionar una factura:"></asp:Label>
                    </div>
                    <div id="anInvoice">
                        <asp:Label ID="lblnumfact" runat="server" Text="Serie-Número:" ToolTip="Introduzca la factura en formato Serie-número"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtfact" runat="server"></asp:TextBox>
                    </div>
                    <br />--%>
                    <%--  Line 4 --%>
                    <div ID="Message" class="messageText">
                        <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
                    </div>
                    <%--  Line 5 --%>
                    <div ID="Buttons" class="buttonsFomat">
                        <asp:ImageButton ID="btnAccept" runat="server" 
                                         ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Ver informe" />
                        &nbsp;
                        <asp:ImageButton ID="btnCancel" runat="server" 
                                         ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                         onclick="btnCancel_Click" ToolTip="Salir" />
                    </div>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
