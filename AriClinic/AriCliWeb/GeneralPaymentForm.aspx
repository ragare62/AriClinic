<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralPaymentForm.aspx.cs" Inherits="GeneralPaymentForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Cobro
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
            /* Line 1 */
            #TitleArea
            {
            z-index: 1;
            left: 5px;
            top: 0px;
            position: absolute;
            height: 19px;
            width: 410px;
                bottom: 273px;
            }
            /* Line 2 */
            #GeneralPaymentId
            {
            z-index: 1;
            left: 5px;
            top: 40px;
            position: absolute;
            height: 44px;
            width: 62px;
            }

            #Clinic
            {
            z-index: 1;
            left: 75px;
            top: 40px;
            position: absolute;
            height: 43px;
            width: 93px;
            }
            
            #GeneralPaymentDate
            {
            z-index: 1;
            left: 259px;
            top: 40px;
            position: absolute;
            height: 44px;
            width: 152px;
            }


            /* Line 3 */
            #TicketId
            {
            z-index: 1;
            left: 13px;
            top: 100px;
            position: absolute;
            height: 43px;
            width: 93px;
            }

            #ServiceNoteData
            {
            z-index: 1;
            left: 11px;
            top: 100px;
            position: absolute;
            height: 44px;
            width: 401px;
            }

            /* Line 4 */
            #PaymentMethod
            {
            z-index: 1;
            left: 14px;
            top: 155px;
            position: absolute;
            height: 44px;
            width: 223px;
            bottom: 139px;
            }
            #Amount
            {
            z-index: 1;
            left: 303px;
            top: 155px;
            position: absolute;
            height: 44px;
            width: 108px;
            }             
            /* Line 5 */
            #Comments
            {
            z-index: 1;
            left: 12px;
            top: 208px;
            position: absolute;
            height: 80px;
            width: 400px;
            }
            #Message
            {
            z-index: 1;
            left: 12px;
            top: 308px;
            position: absolute;
            height: 44px;
            width: 400px;
            }
            /* Line 6 */
            #Buttons
            {
            z-index: 1;
            left: 11px;
            top: 365px;
            position: absolute;
            height: 26px;
            width: 401px;
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
            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                <script type="text/javascript" src="GeneralFormFunctions.js">
                </script>
            </telerik:RadScriptBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                                    onajaxrequest="RadAjaxManager1_AjaxRequest">
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
            </telerik:RadSkinManager>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                       AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
            </telerik:RadToolTipManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 

                                  style="z-index: 1; left: 0px; top:0px; position: absolute; height: 281px; width: 427px">
                <%--Line 1--%>
                <div id="TitleArea" class="titleBar2">
                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                    <asp:Label ID="lblTitle" runat="server" Text="Cobro general"></asp:Label>
                </div>
                <%--Line 2--%>
                <div id="GeneralPaymentId" class="normalText">
                    <asp:Label ID="lblGeneralPaymentId" runat="server" Text="COB ID:" 
                               ToolTip="Identificador del cobro, lo usa internamente el sistema" ></asp:Label>
                    <br />
                    <asp:TextBox ID="txtGeneralPaymentId" runat="server" Enabled="false" Width="46px" 
                                 TabIndex="1" ></asp:TextBox>
                </div>
                <div ID="Clinic" class="normalText">
                    <asp:Label ID="lblClinic" runat="server" Text="Clínica:" 
                               ToolTip="Clinica en la que se realiza el cobro"></asp:Label>
                    <br />
                    <telerik:RadComboBox ID="rdcbClinic" runat="server" TabIndex="6" Width="165px" 
                                         Height="100px" >
                    </telerik:RadComboBox>
                </div>
                <div ID="GeneralPaymentDate" class="normalText">
                    <asp:Label ID="lblGeneralPaymentDate" runat="server" Text="Fecha del cobro:" 
                               ToolTip="Fecha en que se produce este cobro"></asp:Label>
                    <br />
                    <telerik:RadDatePicker ID="rddpGeneralPaymentDate" runat="server">
                    </telerik:RadDatePicker>
                </div>
                <%--Line 3--%>
                <div ID="ServiceNoteData" class="normalText">
                    <asp:Label ID="lblServiceNoteData" runat="server" Text="Información de la nota de servicio:" 
                               ToolTip="Información de la nota de servicio asociada"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtServiceNoteData" runat="server" TabIndex="10" Width="390px" Enabled="false"></asp:TextBox>
                </div>
                <%--Line 4--%>
                <div ID="PaymentMethod" class="normalText">
                    <asp:Label ID="lblPaymentMethod" runat="server" Text="Forma de pago:" 
                               ToolTip="Forma de pago de utilizada"></asp:Label>
                    <br />
                    <telerik:RadComboBox ID="rdcbPaymentMethod" runat="server" TabIndex="6" Width="222px" >
                    </telerik:RadComboBox>
                </div>
                <div ID="Amount" class="normalTextRight">
                    <asp:Label ID="lblAmount" runat="server" Text="Importe:" 
                               ToolTip="Importe del ticket"></asp:Label>
                    <br />
                    <telerik:RadNumericTextBox ID="txtAmount" runat="server"  TabIndex="11" Width="98px">
                    </telerik:RadNumericTextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="valAmount" ControlToValidate="txtAmount"
                        runat="server" ErrorMessage="Se necesita importe" CssClass="normalTextRed"></asp:RequiredFieldValidator>
                </div>
                <%--Line 5--%>
                <div id="Comments" class="normalText">
                    <asp:Label ID="lblComments" runat="server" Text="Comentarios:" 
                               ToolTip="Comentarios al pago"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtComments" runat="server" TabIndex="10" Width="390px" 
                                 Enabled="true" Height="56px" TextMode="MultiLine"></asp:TextBox>
                </div>
                <%--Line 5--%>
                <div ID="Message" class="messageText">
                    <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
                </div>
                <%--Line 6--%>
                <div ID="Buttons" class="buttonsFomat">
                    <asp:ImageButton ID="btnAccept" runat="server" TabIndex="6" 
                                     ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                    &nbsp;
                    <asp:ImageButton ID="btnCancel" runat="server" TabIndex="7" 
                                     ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                     onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
                </div>

            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
