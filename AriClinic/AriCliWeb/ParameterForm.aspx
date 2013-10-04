<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParameterForm.aspx.cs" Inherits="ParameterForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Parámetros</title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
        <link href="dialog_box.css" rel="Stylesheet" type="text/css" />
    </head>
    <body id="content">
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
            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                <script type="text/javascript" src="GeneralFormFunctions.js"></script>
                <script type="text/javascript" src="dialog_box.js"></script>
                <script type="text/javascript">
                    function refreshField(v1, v2, v3, v4, type) {
                        if (type) {
                            switch (type) {
                                case "Service":
                                    document.getElementById('<%= txtServiceId.ClientID %>').value = v1;
                                    document.getElementById('<%= txtServiceName.ClientID %>').value = v3;
                                    break;
                            }
                        }
                    }
                </script>
            </telerik:RadScriptBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3">
                                <div id="TitleArea" runat="server" class="titleBar2">
                                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                    <asp:Label ID="lblTitle" runat="server" Text="Parámetros"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div ID="ServiceId" class="normalText">
                                    <asp:Label ID="lblServiceId" runat="server" Text="SERV ID:" 
                                               ToolTip="Identificador del servicio, lo usa internamente el sistema"></asp:Label>
                                    <asp:ImageButton ID="btnServiceId" runat="server" 
                                                     CausesValidation="false" ImageUrl="~/images/search_mini.png" 
                                                     OnClientClick="searchService();"  
                                                     ToolTip="Haga clic aquí para buscar servicios" 
                                                     style="width: 10px" onclick="btnServiceId_Click" />
                                    <br />
                                    <asp:TextBox ID="txtServiceId" runat="server" AutoPostBack="True" 
                                                 TabIndex="1" 
                                                 Width="75px" ontextchanged="txtServiceId_TextChanged"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div ID="ServiceName" class="normalText">
                                    <asp:Label ID="lblServiceName" runat="server" Text="Servicio (Bomba dolor):" 
                                               ToolTip="servicio que corresponde con la bomba de dolor"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtServiceName" runat="server" Enabled="False" 
                                                 TabIndex="2" Width="247px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div ID="Checked" class="normalText">
                                    <asp:Label ID="lblChecked" runat="server" Text="NOMENCLATOR:" 
                                               ToolTip="Utilizar el nomenclator"></asp:Label>
                                    <br />
                                    <asp:CheckBox ID="chkChecked" runat="server" 
                                                  Text="Usar el nomenclator para asignar servicios" TabIndex="14" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <div ID="AppointmentExtension" class="normalText">
                                    <asp:Label ID="lblAppointmentExtension" runat="server" Text="Extension de cita:" 
                                               ToolTip="Utilizar la extensión de cita"></asp:Label>
                                    <br />
                                    <asp:CheckBox ID="chkAppointmentExtension" runat="server" 
                                                  Text="Mostrar información adicional de cita" TabIndex="14" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div ID="SmsEmail" class="normalText">
                                    <asp:Label ID="lblSmsEmail" runat="server" Text="Correo electrónico (SMS):" 
                                               ToolTip="Correo electrónico para acceder al servicio SMS"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSmsEmail" runat="server"
                                                 TabIndex="15" Width="247px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div ID="SmsClave" class="normalText">
                                    <asp:Label ID="lblSmsClave" runat="server" Text="Clave (SMS):" 
                                               ToolTip="Clave para acceder al servicio SMS"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSmsClave" runat="server"
                                                 TabIndex="16" Width="247px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div ID="SmsRemitente" class="normalText">
                                    <asp:Label ID="lblSmsRemitente" runat="server" Text="Remitente (SMS):" 
                                               ToolTip="Remitente del mensaje  SMS"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSmsRemitente" runat="server"
                                                 TabIndex="16" Width="247px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div ID="Buttons" class="buttonsFomat">
                                    <asp:ImageButton ID="btnAccept" runat="server" TabIndex="19" 
                                                     ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCancel" runat="server" TabIndex="20" 
                                                     ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                                     onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
        