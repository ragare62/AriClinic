<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralPaymentForm2.aspx.cs" Inherits="GeneralPaymentForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Cobro general
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
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
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            </telerik:RadWindowManager>
            <div id="MainArea">
                <table class="normalText" width="100%">
                    <tr id="l1">
                        <td colspan="3" class="titleBar2">
                            <p>
                                Cobro General
                            </p>
                        </td>
                    </tr>
                    <tr id="l2">
                        <td id="GeneralPayment" style="padding:5px">
                            <asp:Label ID="lblGeneralPayment" runat="server" Text="ID"></asp:Label>
                            <br />
                            <telerik:RadTextBox ID="txtGeneralPaymentId" runat="server" TabIndex="1">
                            </telerik:RadTextBox>
                            <br />
                            &nbsp;
                        </td>
                        <td id="Clinic" style="padding:5px">
                            <asp:Label ID="lblClinic" runat="server" Text="Clínica"></asp:Label>
                            <br />
                            <telerik:RadComboBox ID="rdcbClinic" runat="server" TabIndex="2" Width="200px" Height="100px">
                            </telerik:RadComboBox>
                            <br />
                            <asp:RequiredFieldValidator ID="valClinic" ControlToValidate="rdcbClinic" runat="server" 
                                                        ErrorMessage="Se necesita una clínica" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td id="GeneralPaymentDate" style="padding:5px">
                            <asp:Label ID="lblGeneralPaymentDate" runat="server" Text="Fecha del cobro"></asp:Label>
                            <br />
                            <telerik:RadDatePicker ID="rddpGeneralPaymentDate" runat="server" TabIndex="3">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="" TabIndex="3"></DateInput>
                                <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="3"></DatePopupButton>
                            </telerik:RadDatePicker>
                            <br />
                            <asp:RequiredFieldValidator ID="valGeneralPaymentDate" ControlToValidate="rddpGeneralPaymentDate" runat="server" 
                                                        ErrorMessage="Se necesita una fecha" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="l3">
                        <td id="ServiceNoteData" colspan="3" style="padding:5px">
                            <asp:Label ID="lblServiceNoteData" runat="server" Text="Información de la nota de servicio"></asp:Label>
                            <br />
                            <telerik:RadTextBox ID="txtServiceNoteData" runat="server" Enabled="false" TabIndex="4" Width="100%">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr id="l4">
                        <td id="PaymentMethod" colspan="2" style="padding:5px">
                            <asp:Label ID="lblPaymentMethod" runat="server" Text="Forma de pago"></asp:Label>
                            <br />
                            <telerik:RadComboBox ID="rdcbPaymentMethod" runat="server" TabIndex="5" Width="200px" Height="100px">
                            </telerik:RadComboBox>
                            <br />
                            <asp:RequiredFieldValidator ID="valPaymentMethod" ControlToValidate="rdcbPaymentMethod" runat="server" 
                                                        ErrorMessage="Se necesita una forma de pago" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td id="Amount" style="padding:5px">
                            <asp:Label ID="lblAmount" runat="server" Text="Importe"></asp:Label>
                            <br />
                            <telerik:RadNumericTextBox ID="txtAmount" runat="server"  TabIndex="6" Width="98px">
                            </telerik:RadNumericTextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="valAmount" ControlToValidate="txtAmount"
                                                        runat="server" ErrorMessage="Se necesita importe" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td id="Comments" colspan="3" style="padding:5px">
                            <asp:Label ID = "lblComments" runat="server" Text="Comentarios:"></asp:Label>
                            <br />
                            <telerik:RadTextBox ID="txtComments" runat="server" Enabled="false" TabIndex="7" Width="100%" Height="100px" TextMode="MultiLine">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td id="Buttons" colspan="3" class="buttonsFomat">
                            <asp:ImageButton ID="btnAccept" runat="server" TabIndex="8" CausesValidation="true" 
                                             ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                            &nbsp;
                            <asp:ImageButton ID="btnCancel" runat="server" TabIndex="9" 
                                             ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                             onclick="btnCancel_Click" ToolTip="Salir sin guardar" />                            
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>
