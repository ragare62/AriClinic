<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestForm.aspx.cs" Inherits="RequestForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Solicitud de información
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
                                case "Campaign":
                                    combo = $find("<%= rdcCampaign.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                                case "Channel":
                                    combo = $find("<%= rdcChannel.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                                case "Source":
                                    combo = $find("<%= rdcSource.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                                case "Patient":
                                    combo = $find("<%= rdcPatient.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    // I don't know at the moment if I need that
                                    //$find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
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
                    function NewReplayRecord(id2) {
                        //window.close();
                        var w1 = window.open("ReplayForm.aspx?Caller=RequestForm&RequestId=" + id2, "NRPLY", "width=800, height=750,resizable=1");
                        w1.focus();
                    }
                    function EditReplayRecord(id, id2) {
                        //window.close();
                        var w2 = window.open("ReplayForm.aspx?Caller=RequestForm&RequestId=" + id2 + "&ReplayId=" + id, "ERPLY", "width=800, height=750,resizable=1");
                        w2.focus();
                    }
                    function NewEstimateRecord(id2) {
                        //window.close();
                        var w1 = window.open("EstimateForm.aspx?Caller=RequestForm&RequestId=" + id2, "NEST", "width=800, height=750,resizable=1");
                        w1.focus();
                    }
                    function EditEstimateRecord(id, id2) {
                        //window.close();
                        var w2 = window.open("EstimateForm.aspx?Caller=RequestForm&RequestId=" + id2 + "&EstimateId=" + id, "EEST", "width=800, height=750,resizable=1");
                        w2.focus();
                    }
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
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
                                    <asp:Label ID="lblTitle" runat="server" Text="Solicitud de información"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="RequestId" class="normalText">
                                    <asp:Label ID="lblRequestId" runat="server" Text="ID:" 
                                               ToolTip="Identificador de canal, lo usa internamente el sistema"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtRequestId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div ID="RequestDateTime" class="normalText" >
                                    <asp:Label ID="lblRequestDateTime" runat="server" Text="Fecha solicitud:" 
                                               ToolTip="Fecha en la que se abrió la historia"></asp:Label>
                                    <br />
                                    <telerik:RadDatePicker ID="rdtRequestDateTime" runat="server" Culture="es-ES" CssClass="myCenter"  
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
                            <td colspan="2">
                                <div id="Status" class="normalText">
                                    <asp:Label ID="lblStatus" runat="server" Text="Estado" 
                                               ToolTip="Estado en el que se encuentra la solicitud"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtStatus" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Campaign" class="normalText">
                                    <asp:Label ID="lblCampaign" runat="server" Text="Campaña " 
                                               ToolTip="Campaña, si hay ua"></asp:Label>
                                    <asp:ImageButton ID="imgCampaña" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     OnClientClick="searchCampaign();" 
                                                     ToolTip="Haga clic aquí para buscar una campaña" style="height: 10px" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcCampaign" Height="100px" Width="100%" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." TabIndex="2" AutoPostBack="True"
                                                         onitemsrequested="rdcCampaign_ItemsRequested">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="Channel" class="normalText">
                                    <asp:Label ID="lblChannel" runat="server" Text="Canal " 
                                               ToolTip="Canal por el que llega la solicitud"></asp:Label>
                                    <asp:ImageButton ID="imgChannel" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     OnClientClick="searchChannel();" 
                                                     ToolTip="Haga clic aquí para buscar un canal" style="height: 10px" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcChannel" Height="100px" Width="100%" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." TabIndex="3" AutoPostBack="True"
                                                         onitemsrequested="rdcChannel_ItemsRequested">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="Source" class="normalText">
                                    <asp:Label ID="lblSource" runat="server" Text="Origen " 
                                               ToolTip="Origen de la solicitud"></asp:Label>
                                    <asp:ImageButton ID="imgSource" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     OnClientClick="searchSource();" 
                                                     ToolTip="Haga clic aquí para buscar un origen" style="height: 10px" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcSource" Height="100px" Width="100%" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." TabIndex="4" AutoPostBack="True"
                                                         onitemsrequested="rdcSource_ItemsRequested">
                                    </telerik:RadComboBox>
                                </div>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="6">
                                <br />
                                <div class="titleBar2">SI YA ES CLIENTE O PACIENTE</div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">

                                <div id="Patient" class="normalText">
                                    <asp:Label ID="lblPatient" runat="server" Text="Paciente / Cliente:" 
                                               ToolTip="Cliente del ticket"></asp:Label>
                                    <asp:ImageButton ID="btnCustomerId" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     OnClientClick="searchPatient();" 
                                                     ToolTip="Haga clic aquí para buscar un paciente" style="height: 10px" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcPatient" Height="100px" Width="100%" ItemsPerRequest="10" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." TabIndex="5" AutoPostBack="True"
                                                         onitemsrequested="rdcPatient_ItemsRequested">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <br />
                                <div class="titleBar2">SI NO ES CLIENTE O PACIENTE</div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Surname1" class="normalText">
                                    <asp:Label ID="lblSurname1" runat="server" Text="Primer apellido" 
                                               ToolTip="Primer apellido"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSurname1" runat="server" Width="100%" TabIndex="6"></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="Surname2" class="normalText">
                                    <asp:Label ID="lblSurname2" runat="server" Text="Segundo apellido"
                                               ToolTip="Segundo apellido"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSurname2" runat="server" Width="100%" TabIndex="7"></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="Name" class="normalText">
                                    <asp:Label ID="lblName" runat="server" Text="Nombre" 
                                               ToolTip="Nombre"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtName" runat="server" Width="100%" TabIndex="8"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div ID="Sex" class="normalText">
                                    <asp:Label ID="lblSex" runat="server" Text="Sexo:" 
                                               ToolTip="Nombre a asignar a la Patienta"></asp:Label>
                                    <br />
                                    <telerik:RadComboBox ID="rdcbSex" runat="server" Width="126px" 
                                                         Skin="Office2007" TabIndex="9" Culture="es-ES">
                                        <Items>
                                            <telerik:RadComboBoxItem runat="server" />
                                            <telerik:RadComboBoxItem runat="server" Text="Mujer" Value="W" />
                                            <telerik:RadComboBoxItem runat="server" Text="Hombre" Value="M" />
                                        </Items>
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div ID="BornDate" class="normalText" >
                                    <asp:Label ID="lblBornDate" runat="server" Text="Fecha nacimiento:" 
                                               ToolTip="Fecha de nacimiento"></asp:Label>
                                    <br />
                                    <telerik:RadDatePicker ID="rdtBornDate" runat="server" Culture="es-ES" CssClass="myCenter"  
                                                           MinDate=""  TabIndex="10" AutoPostBack="True">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" AutoPostBack="True">
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="PostalCode" class="normalText">
                                    <asp:Label ID="lblPostalCode" runat="server" Text="Cod. Postal" 
                                               ToolTip="Código postal"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtCodPostal" runat="server" TabIndex="11" ></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Dni" class="normalText">
                                    <asp:Label ID="lblDni" runat="server" Text="DNI" 
                                               ToolTip="Identificación"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtDni" runat="server" TabIndex="12"></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="Email" class="normalText">
                                    <asp:Label ID="lblEmail" runat="server" Text="Corro electrónico" 
                                               ToolTip="Correo electrónico"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtEmail" runat="server" TabIndex="13" ></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="Telephone" class="normalText">
                                    <asp:Label ID="lblTelephone" runat="server" Text="Teléfono" 
                                               ToolTip="Teléfono"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtTelephone" runat="server" TabIndex="14" ></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <br />
                                <div class="titleBar2">INFORMACIÓN SOLICITADA</div>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="6">
                                <div id="Service" class="normalText">
                                    <asp:Label ID="lblService" runat="server" Text="Servicio" 
                                               ToolTip="Servicio por el que se interesa"></asp:Label>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     OnClientClick="searchService();" 
                                                     ToolTip="Haga clic aquí para buscar un servicio" style="height: 10px" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcService" Height="100px" Width="100%" ItemsPerRequest="10" 
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
                                    <asp:ImageButton ID="btnEstimate" runat="server" 
                                                     ImageUrl="~/images/document_certificate.png" onclick="btnEstimate_Click" ToolTip="Hacer presupuesto" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCopy" runat="server" 
                                                     ImageUrl="~/images/document_exchange.png" onclick="btnCopy_Click" ToolTip="Copiar / duplicar solicitud" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnReplay" runat="server" 
                                                     ImageUrl="~/images/document_check.png" onclick="btnReply_Click" ToolTip="Responder la solicitud" />
                                    &nbsp;
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
