<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AmendmentInvoiceLineForm.aspx.cs" Inherits="AmendmentInvoiceLineForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Linea de factura rectificativa
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
            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                <script type="text/javascript" src="GeneralFormFunctions.js">
                </script>
                <script type="text/javascript">
        
                    //Put your JavaScript code here.
                    function refreshField(v1, v2, v3, v4, type) {
                        if (type) {
                            switch (type) {
                            }
                        }
                    }
                </script>
                    
            </telerik:RadScriptBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                                    onajaxrequest="RadAjaxManager1_AjaxRequest">
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
                        <telerik:TargetInput ControlID="txtDescription" />
                    </TargetControls>
                    <Validation IsRequired="True"></Validation>
                </telerik:TextBoxSetting>
                <telerik:TextBoxSetting>
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtPatientName" />
                        <telerik:TargetInput ControlID="txtTicketId" />
                        <telerik:TargetInput ControlID="txtInsuranceServiceName" />
                    </TargetControls>
                </telerik:TextBoxSetting>
                <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="0" 
                                               DecimalSeparator="." GroupSeparator="." GroupSizes="3" MaxValue="999999999" 
                                               MinValue="0" NegativePattern="-n" PositivePattern="n">
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtInvoiceLineId" />
                        <telerik:TargetInput ControlID="txtPatientId" />
                        <telerik:TargetInput ControlID="txtTicketId" />
                    </TargetControls>
                </telerik:NumericTextBoxSetting>
                <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="2" 
                                               DecimalSeparator="," GroupSeparator="." 
                                               GroupSizes="3" NegativePattern="-n" 
                                               PositivePattern="n" Validation-IsRequired="true">
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtAmount" />
                    </TargetControls>
                        
                    <Validation IsRequired="True"></Validation>
                </telerik:NumericTextBoxSetting>
            </telerik:RadInputManager>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                       AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
            </telerik:RadToolTipManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                                  style="z-index: 1; left: 0px; top:0px; position: absolute; height: 319px; width: 664px">
                <table width="100%">
                    <tr>
                        <td colspan="5">
                            <div id="TitleArea" class="titleBar2">
                                <caption>
                                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                    <asp:Label ID="lblTitle" runat="server" Text="Linea de factura"></asp:Label>
                                </caption>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="InvoiceLineId" class="normalText">
                                <asp:Label ID="lblInvoiceLineId" runat="server" Text="FACLIN ID:" 
                                           ToolTip="Identificador de ticket, lo usa internamente el sistema" ></asp:Label>
                                <br />
                                <asp:TextBox ID="txtInvoiceLineId" runat="server" Enabled="false" Width="89px" TabIndex="1" ></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div ID="InvoiceSerial" class="normalText">
                                <asp:Label ID="lblInvoiceSerial" runat="server" Text="Serie:" 
                                           ToolTip="Serie de la factura"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtInvoiceSerial" runat="server" Enabled="False" 
                                             TabIndex="8" Width="64px"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div ID="Year" class="normalText">
                                <asp:Label ID="lblYear" runat="server" Text="Año:" 
                                            ToolTip="Año de la factura"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtYear" runat="server" Enabled="False" TabIndex="8" 
                                                Width="64px"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div ID="InvoiceNumber" class="normalText">
                                <asp:Label ID="lblInvoiceNumber" runat="server" Text="Número:"
                                           ToolTip="Número de factura. Consecutivo según serie y año"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtInvoiceNumber" runat="server" Enabled="False" TabIndex="8" 
                                             Width="137px"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                        <div ID="TaxType" class="normalText">
                            <asp:Label ID="lblTaxType" runat="server" Text="Tipo de IVA:" 
                                       ToolTip="Tipo de IVA aplicable"></asp:Label>
                            <br />
                            <telerik:RadComboBox ID="rdcbTaxType" runat="server" TabIndex="6" Width="222px" 
                                                 AutoPostBack="True" onselectedindexchanged="rdcbTaxType_SelectedIndexChanged"  >
                            </telerik:RadComboBox>
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <div ID="Description" class="normalText">
                                <asp:Label ID="lblDescription" runat="server" Text="Descripción del servicio:" 
                                           ToolTip="Dexripción del servicio del ticket"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtDescription" runat="server" TabIndex="10" 
                                             Width="287px"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div ID="TaxPercentage" class="normalTextRight">
                                <asp:Label ID="lblTaxPercentage" runat="server" Text="IVA (%):" 
                                           ToolTip="Porcentage de IVA aplicado"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtTaxPercentage" runat="server" style="text-align:right" 
                                             TabIndex="11" Width="98px" Enabled="false"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                        <div ID="Amount" class="normalTextRight">
                            <asp:Label ID="lblAmount" runat="server" Text="Importe:" 
                                       ToolTip="Importe del ticket"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtAmount" runat="server"
                                         TabIndex="11" Width="98px" style="text-align:right" ></asp:TextBox>
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <div ID="Message" class="messageText">
                                <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <div ID="Buttons" class="buttonsFomat">
                                <asp:ImageButton ID="btnAccept" runat="server" TabIndex="6" 
                                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                                &nbsp;
                                <asp:ImageButton ID="btnCancel" runat="server" TabIndex="7" 
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
    