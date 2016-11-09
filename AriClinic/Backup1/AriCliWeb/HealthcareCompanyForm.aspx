<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HealthcareCompanyForm.aspx.cs" Inherits="HealthcareCompanyForm" %>

<%@ Register src="UscAddressGrid.ascx" tagname="UscAddressGrid" tagprefix="uc1" %>

<%@ Register src="UscTelephoneGrid.ascx" tagname="UscTelephoneGrid" tagprefix="uc2" %>

<%@ Register src="UscEmailGrid.ascx" tagname="UscEmailGrid" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Empresa sanitaria
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
            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
            </telerik:RadWindowManager>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Position="TopCenter" AutoTooltipify="true">
            </telerik:RadToolTipManager>
            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                <script type="text/javascript">
                    //Replace old radconfirm with a changed version.   
                    var oldConfirm = radconfirm;
                    //TELERIK
                    //window.radconfirm = function(text, mozEvent)
                    //We will change the radconfirm function so it takes all the original radconfirm attributes
                    window.radconfirm = function (text, mozEvent, oWidth, oHeight, callerObj, oTitle) {
                        var ev = mozEvent ? mozEvent : window.event; //Moz support requires passing the event argument manually   
                        //Cancel the event   
                        ev.cancelBubble = true;
                        ev.returnValue = false;
                        if (ev.stopPropagation)
                            ev.stopPropagation();
                        if (ev.preventDefault)
                            ev.preventDefault();
                    
                        //Determine who is the caller   
                        var callerObj = ev.srcElement ? ev.srcElement : ev.target;
                    
                        //Call the original radconfirm and pass it all necessary parameters   
                        if (callerObj) {
                            //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again.   
                            var callBackFn = function (arg) {
                                if (arg) {
                                    callerObj["onclick"] = "";
                                    if (callerObj.click)
                                        callerObj.click(); //Works fine every time in IE, but does not work for links in Moz   
                                    else if (callerObj.tagName == "A") //We assume it is a link button!   
                                    {
                                        try {
                                            eval(callerObj.href)
                                        }
                                        catch (e) {
                                        }
                                    }
                                }
                            }
                            //TELERIK
                            //oldConfirm(text, callBackFn, 300, 100, null, null);       
                            //We will need to modify the oldconfirm as well                
                            oldConfirm(text, callBackFn, oWidth, oHeight, callerObj, oTitle);
                        }
                        return false;
                    }
                </script>
                <script type="text/javascript">
                    //Put your JavaScript code here.
                    // In order to show item changes in the grid
                    function refreshGrid(arg) {
                        //alert("Hello from refreshGrid");
                        if (!arg) {
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("");
                        }
                        else {
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                        }
                    }
                    function NewAddressRecord() {
                        var w1 = window.open("AddressForm.aspx?HcId=" + gup('HcId'), null, "width=700, height=350,resizable=1");
                        w1.focus();
                    }
                    function EditAddressRecord(id) {
                        var w1 = window.open("AddressForm.aspx?HcId=" + gup('HcId') + "&AddressId=" + id
                                             , null
                                             , "width=700, height=350,resizable=1");
                        w1.focus();
                    }
                    function NewTelephoneRecord() {
                        var w1 = window.open("TelephoneForm.aspx?HcId=" + gup('HcId'), null, "width=650, height=250,resizable=1");
                        w1.focus();
                    }
                    function EditTelephoneRecord(id) {
                        var w1 = window.open("TelephoneForm.aspx?HcId=" + gup('HcId') + "&TelephoneId=" + id
                                             , null
                                             , "width=650, height=250,resizable=1");
                        w1.focus();
                    }
                    function NewEmailRecord() {
                        var w1 = window.open("EmailForm.aspx?HcId=" + gup('HcId'), null, "width=650, height=250,resizable=1");
                        w1.focus();
                    }
                    function EditEmailRecord(id) {
                        var w1 = window.open("EmailForm.aspx?HcId=" + gup('HcId') + "&EmailId=" + id
                                             , null
                                             , "width=650, height=250,resizable=1");
                        w1.focus();
                    }
                </script>
                <script type="text/javascript" src="GeneralFormFunctions.js">
                    //Put your JavaScript code here.
                </script>
            </telerik:RadScriptBlock>
            <script type="text/javascript" src="GeneralFormFunctions.js">
                //Put your JavaScript code here.
            </script>
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
                        <telerik:TargetInput ControlID="txtName" />
                        <telerik:TargetInput ControlID="txtVATIN" />
                    </TargetControls>
                </telerik:TextBoxSetting>
            </telerik:RadInputManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                                  style="z-index: 1; left: 0px; top:0px; position: absolute; height: 584px; width: 732px">
                <table width="100%">
                    <tr>
                        <td colspan="4">
                            <div id="TitleArea" class="titleBar2">
                                <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                <asp:Label ID="lblTitle" runat="server" Text="Empresa sanitaria"></asp:Label>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="HcId" class="normalText">
                                <asp:Label ID="lblHcId" runat="server" Text="ID:" 
                                           ToolTip="Identificador de grupo, lo usa internamente el sistema"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtHcId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                            </div>

                        </td>
                        <td colspan="3">
                            <div id="Name" class="normalText">
                                <asp:Label ID="lblName" runat="server" Text="Nombre de la empresa:" 
                                           ToolTip="Nombre a asignar al grupo"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtName" runat="server" Width="379px"></asp:TextBox>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <div ID="VATIN" class="normalText">
                                <asp:Label ID="lblVATIN" runat="server" Text="NIF:" 
                                           ToolTip="Identificación fiscal"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtVATIN" runat="server" Width="77px"></asp:TextBox>
                            </div>

                        </td>
                        <td>
                            <div ID="SERIAL" class="normalText">
                                <asp:Label ID="lblSERIAL" runat="server" Text="SERIE FACT:" 
                                           ToolTip="Identificación fiscal"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtSERIAL" runat="server" Width="65px"></asp:TextBox>
                            </div>

                        </td>
                        <td>
                            <div ID="SERIAL2" class="normalText">
                                <asp:Label ID="lblSERIAL2" runat="server" Text="SERIE RECT:" 
                                           ToolTip="Serie de rectificativas"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtSERIAL2" runat="server" Width="65px"></asp:TextBox>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div ID="Address" class="embGrid">
                                <asp:Label ID="lblAddress" runat="server" Text="Direcciones:" 
                                           ToolTip="Direcciones postales de la empresa. La resaltada es la principal"></asp:Label>
                                <br />
                                <uc1:UscAddressGrid ID="UscAddressGrid1" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div ID="Telephones" class="embGrid">
                                <asp:Label ID="lblTelephones" runat="server" Text="Teléfonos:" 
                                           ToolTip="Teléfonos asociados. El resaltado es el principal"></asp:Label>
                                <br />
                                <uc2:UscTelephoneGrid ID="UscTelephoneGrid1" runat="server" />
                            </div>

                        </td>
                        <td colspan="2">
                            <div ID="Emails" class="embGrid">
                                <asp:Label ID="lblEmails" runat="server" Text="Correos electrónicos:" 
                                           ToolTip="Correos asociados. El resaltado es el principal."></asp:Label>
                                <br />
                                <uc3:UscEmailGrid ID="UscEmailGrid1" runat="server" />
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
                    