<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackGinecologyForm.aspx.cs" Inherits="BackGinecologyForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Historia clínica anterior
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
        <link href="StyleForms.css" rel="stylesheet" type="text/css" />
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
                    function noHaceNada() {
                    }
                </script>
            </telerik:RadScriptBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            </telerik:RadWindowManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
                <div id="main-container" style="width:100%; height:500px">
                    <div ID="ButtonsTop" class="buttonsFomat">
                        <asp:ImageButton ID="ImageButton1" runat="server" TabIndex="6"  
                                         ImageUrl="~/images/document_ok.png" OnClick="btnAccept_Click" ToolTip="Guardar" />

                    </div>
                    <div id="bckg-form">
                        <div id="menstrual-formula">
                            <asp:Label ID="lblMenstrulaFormula" runat="server" Text="Fórmula menstrual"></asp:Label>
                            <br />
                            <telerik:RadTextBox ID="txtMenstrualFormula" runat="server">
                            </telerik:RadTextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="Rfv1" runat="server" ControlToValidate="txtMenstrualFormula" 
                                                        ErrorMessage ="Falta el valor" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div id="vaginal-deliveries">
                            <asp:Label ID="lblVaginalDeliveries" runat="server" Text="Partos eutócicos"></asp:Label>
                            <br />
                            <telerik:RadNumericTextBox ID="txtVaginalDeliveries" runat="server" 
                                Culture="es">
                                <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVaginalDeliveries" 
                                                        ErrorMessage ="Falta el valor" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div id="cesarean-deliveries">
                            <asp:Label ID="lblCesareanDeliveries" runat="server" Text="Cesáreas"></asp:Label>
                            <br />
                            <telerik:RadNumericTextBox ID="txtCesareanDeliveries" runat="server" Culture="es">
                            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCesareanDeliveries" 
                                                        ErrorMessage ="Falta el valor" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div id="abortions">
                            <asp:Label ID="lblAbortions" runat="server" Text="Abortos"></asp:Label>
                            <br />
                            <telerik:RadNumericTextBox ID="txtAbortions" runat="server" Culture="es">
                            <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                            </telerik:RadNumericTextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAbortions" 
                                                        ErrorMessage ="Falta el valor" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div style="clear:both;"></div>
                        <div id="menarche">
                            <asp:Label ID="lblMenarche" runat="server" Text="Menarquia"></asp:Label>
                            <br />
                            <telerik:RadTextBox ID="txtMenarche" runat="server">
                            </telerik:RadTextBox>
                        </div>
                        <div id="menopause">
                            <asp:Label ID="lblMenopause" runat="server" Text="Menopausia"></asp:Label>
                            <br />
                            <telerik:RadTextBox ID="txtMenopause" runat="server">
                            </telerik:RadTextBox>
                        </div>
                        <div style="clear:both;"></div>
                        <div id="date-of-last-menstrual">
                            <asp:Label ID="lblDateOfLastMenstrual" runat="server" Text="Fecha última regla"></asp:Label>
                            <br />
                            <telerik:RadDatePicker ID="rdcDateOfLastMenstrual" runat="server">
                            </telerik:RadDatePicker>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rdcDateOfLastMenstrual" 
                                                        ErrorMessage ="Falta el valor" CssClass="normalTextRed">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div id="content">
                            <asp:Label ID="lblContent" runat="server" Text="Comentarios"></asp:Label>
                            <br />
                            <telerik:RadEditor ID="txtContent" runat="server" Width="100%" Height="350px" Skin="Office2007" 
                                               ToolsFile="~/Tools/tools.xml">
                            </telerik:RadEditor>
                        </div>

                    </div>
                    <div style="clear:both;"></div>
                    <div ID="Buttons" class="buttonsFomat" style="margin-top:10px">
                        <asp:ImageButton ID="btnAccept" runat="server" TabIndex="6"  
                                         ImageUrl="~/images/document_ok.png" OnClick="btnAccept_Click" ToolTip="Guardar" />

                    </div>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
