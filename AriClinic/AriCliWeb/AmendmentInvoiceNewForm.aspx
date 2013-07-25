<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AmendmentInvoiceNewForm.aspx.cs" Inherits="AmendmentInvoiceNewForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Categoria
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
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
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
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
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="210px" 
                                  Width="420px" 
                                  style="z-index: 1; left: 0px; top:0px; position: absolute; height: 231px; width: 420px">
                <table width="100%">
                    <tr>
                        <td colspan="4">
                            <div id="TitleArea" class="titleBar2">
                                <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                <asp:Label ID="lblTitle" runat="server" Text="Crear factura rectificativa"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="normalText pTitle">
                            Datos de la factura a rectificar
                        </td>
                        <td>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="InvoiceSerial" class="normalText">
                                <asp:Label ID="lblInvoiceSerial" runat="server" Text="Serie:" ToolTip="Serie de la factura"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtInvoiceSerial" runat="server" TabIndex="8" Width="64px"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div id="Year" class="normalText">
                                <asp:Label ID="lblYear" runat="server" Text="Año:" ToolTip="Año de la factura"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtYear" runat="server" TabIndex="8" Width="64px"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div id="InvoiceNumber" class="normalText">
                                <asp:Label ID="lblInvoiceNumber" runat="server" Text="Número:" ToolTip="Número de factura. Consecutivo según serie y año"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtInvoiceNumber" runat="server" TabIndex="8" Width="137px"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div ID="InvoiceDate" class="normalText">
                              <asp:Label ID="lblInvoiceDate" runat="server" Text="Fecha de factura:" 
                                         ToolTip="Fecha de emisión de la factura"></asp:Label>
                              <br />
                              <telerik:RadDatePicker ID="rddpInvoiceDate" runat="server">
                              </telerik:RadDatePicker>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div id="Reason" class="normalText">
                                <asp:Label ID="lblReason" runat="server" Text="Motivo de la rectificación:" ToolTip="Motivo por el que se rectifica la factura"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtReason" runat="server" TabIndex="8" TextMode="MultiLine" Height="100px" Width="100%"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div ID="Message" class="messageText">
                                <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div ID="Buttons" class="buttonsFomat">
                                <asp:ImageButton ID="btnAccept" runat="server" 
                                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                                &nbsp;
                                <asp:ImageButton ID="btnCancel" runat="server" 
                                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
                            </div>
                        </td>
                    </tr>
                </table>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
