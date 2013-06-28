<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstimateLineForm.aspx.cs" Inherits="EstimateLineForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Línea de presupuesto
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
            <script type="text/javascript">
                function refreshField(v1, v2, v3, v4, type) {
                    if (type) {
                        switch (type) {
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
                        <td colspan="6">
                            <div id="TitleArea" class="titleBar2">
                                <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                <asp:Label ID="lblTitle" runat="server" Text="Línea presupuesto"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1">
                            <div id="EstimateLineId" class="normalText">
                                <asp:Label ID="lblEstimateLineId" runat="server" Text="ID:" 
                                           ToolTip="Identificador de canal, lo usa internamente el sistema"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtEstimateLineId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                            </div>
                        </td>
                        <td colspan="2">
                            <div ID="Insurance" class="normalText">
                                <asp:Label ID="lblInsurance" runat="server" Text="Insuranceo:" 
                                           ToolTip="Nombre a asignar a la Patienta"></asp:Label>
                                <br />
                                <telerik:RadComboBox ID="rdcbInsurance" runat="server" Width="100%" 
                                                     Skin="Office2007" TabIndex="9" Culture="es-ES">
                                </telerik:RadComboBox>
                            </div>
                        </td>
                        <td colspan="3">
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
                        <td colspan="1">

                        </td>
                        <td colspan="2">
                            <div id="Amount" class="normalText">
                                <asp:Label ID ="lblAmount" runat="server" Text="Precio"></asp:Label>
                                <br />
                                <telerik:RadNumericTextBox ID="txtAmount" runat="server" Enabled="false"></telerik:RadNumericTextBox>
                            </div>
                        </td>

                        <td colspan="1">
                            <div id="Discount" class="normalText">
                                <asp:Label ID ="lblDiscount" runat="server" Text="Descuento"></asp:Label>
                                <br />
                                <telerik:RadNumericTextBox ID="txtDiscount" runat="server"></telerik:RadNumericTextBox>
                            </div>
                        </td>
                        <td colspan="2">
                            <div id="Total" class="normalText">
                                <asp:Label ID ="lblTotal" runat="server" Text="Importe"></asp:Label>
                                <br />
                                <telerik:RadNumericTextBox ID="txtTotal" runat="server" Enabled="false"></telerik:RadNumericTextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <div id="Description" class="normalText">
                                <asp:Label ID ="lblDescription" runat="server" Text="Descripción"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
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
                                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="4" />
                                &nbsp;
                                <asp:ImageButton ID="btnCancel" runat="server" 
                                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" TabIndex="5" />
                            </div>
                        </td>
                    </tr>
                </table>

            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
