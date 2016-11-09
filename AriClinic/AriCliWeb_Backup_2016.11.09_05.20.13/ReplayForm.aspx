<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplayForm.aspx.cs" Inherits="ReplayForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Respuesta a solicitud
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
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript" src="GeneralFormFunctions.js"></script>
                <script type="text/javascript" src="dialog_box.js"></script>
                <script type="text/javascript">
                    function refreshField(v1, v2, v3, v4, type) {
                        if (type) {
                            switch (type) {
                                case "Channel":
                                    combo = $find("<%= rdcChannel.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                                case "Service":
                                    combo = $find("<%= rdcService.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    function loadCombo(combo, v1, v3) {
                        var items = combo.get_items();
                        items.clear();
                        var comboItem = new Telerik.Web.UI.RadComboBoxItem();
                        comboItem.set_text(v3);
                        comboItem.set_value(v1);
                        items.add(comboItem);
                        combo.commitChanges();
                        comboItem.select();
                    }
                    function CloseAndRequest() {
                        // the request status has changed to "ANSWERED" and
                        window.opener.CloseAndRebind('');
                        window.close();
                    }
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxReplay="RadAjaxManager1_AjaxReplay">
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
            </telerik:RadSkinManager>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                       AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
            </telerik:RadToolTipManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="550px" 
                                  Width="100%">
                <div id="content">
                    <table width="100%">
                        <tr>
                            <td colspan="6">
                                <div id="TitleArea" class="titleBar2">
                                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                    <asp:Label ID="lblTitle" runat="server" Text="Respuesta a solicitud"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="ReplayId" class="normalText">
                                    <asp:Label ID="lblReplayId" runat="server" Text="ID:" 
                                               ToolTip="Identificador de canal, lo usa internamente el sistema"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtReplayId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2"></td>
                            <td colspan="2">
                                <div ID="ReplayDate" class="normalText" >
                                    <asp:Label ID="lblReplayDate" runat="server" Text="Fecha respuesta:" 
                                               ToolTip="Fecha en la que se responde a la solicitud"></asp:Label>
                                    <br />
                                    <telerik:RadDatePicker ID="rdtReplayDate" runat="server" Culture="es-ES" CssClass="myCenter"  
                                                           MinDate=""  TabIndex="1">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" class="requestData">
                                <asp:Label ID="lblRequestPerson" runat="server" Text="Quien pregunta"></asp:Label>
                                <br />
                                <asp:Label ID="lblRequestService" runat="server" Text="Servicio por el que se interesa"></asp:Label>
                                <br />
                                <asp:Label ID="lblRequestComments" runat="server" Text="Obsevaciones de la solicitud"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="2">
                                <div id="Channel" class="normalText">
                                    <asp:Label ID="lblChannel" runat="server" Text="Canal de respuesta " 
                                               ToolTip="Canal por el que se responde"></asp:Label>
                                    <asp:ImageButton ID="imgChannel" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     OnClientClick="searchChannel();" 
                                                     ToolTip="Haga clic aquí para buscar un canal" style="height: 10px" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcChannel" Height="100px" Width="100%" ItemsPerReplay="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." TabIndex="15" AutoPostBack="True"
                                                         onitemsrequested="rdcChannel_ItemsRequested">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td colspan="4">
                                <div id="Service" class="normalText">
                                    <asp:Label ID="lblService" runat="server" Text="Servicio que se aconseja " 
                                               ToolTip="Servicio que se aconsenja"></asp:Label>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     OnClientClick="searchService();" 
                                                     ToolTip="Haga clic aquí para buscar un servicio" style="height: 10px" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcService" Height="100px" Width="100%" ItemsPerReplay="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." TabIndex="15" AutoPostBack="True"
                                                         onitemsrequested="rdcService_ItemsRequested">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div ID="Comments" class="normalText">
                                    <asp:Label ID="lblComments" runat="server" Text="Observaciones:" 
                                               ToolTip="Observaciones" ></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtComments" runat="server" Width="100%" Height="60px" TextMode="MultiLine" TabIndex="16"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div ID="Message" class="messageText">
                                    <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div ID="Buttons" class="buttonsFomat">
                                    <asp:ImageButton ID="btnAccept" runat="server" 
                                                     ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="17" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCancel" runat="server" 
                                                     ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                                     onclick="btnCancel_Click" ToolTip="Salir sin guardar" TabIndex="18" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
