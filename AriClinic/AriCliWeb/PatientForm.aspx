<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientForm.aspx.cs" Inherits="PatientForm" %>

<%@ Register src="UscAddressGrid.ascx" tagname="UscAddressGrid" tagprefix="uc1" %>

<%@ Register src="UscTelephoneGrid.ascx" tagname="UscTelephoneGrid" tagprefix="uc2" %>

<%@ Register src="UscEmailGrid.ascx" tagname="UscEmailGrid" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Paciente
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
        <link href="StyleAdvanced.css" rel="stylesheet" type="text/css" />
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
                    window.radconfirm = function (text, mozEvent, oWidth, oHeight, callerObj, oTitle){
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
                        if (callerObj){
                            //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again.   
                            var callBackFn = function (arg){
                                if (arg){
                                    callerObj["onclick"] = "";
                                    if (callerObj.click)
                                        callerObj.click(); //Works fine every time in IE, but does not work for links in Moz   
                                    else if (callerObj.tagName == "A"){
                                        try{
                                            eval(callerObj.href)
                                        }
                                        catch (e){
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
                    function PatientRecord(id) {
                        var w2 = window.open("PatientForm.aspx?PatientId=" + id, null, "width=770, height=680,resizable=1");
                        w2.focus();
                        //window.close();
                    }
                </script>
                <script type="text/javascript">
                    //Put your JavaScript code here.
                    // In order to show item changes in the grid
                    function refreshGrid(arg){
                        //alert("Hello from refreshGrid");
                        if (!arg){
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("");
                        }
                        else{
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                        }
                    }
                    function NewAddressRecord(){
                        var w1 = window.open("AddressForm.aspx?PatientId=" + gup('PatientId'), "Patient_na", "width=700, height=350,resizable=1");
                        w1.focus();
                    }
                    function EditAddressRecord(id){
                        var w2 = window.open("AddressForm.aspx?PatientId=" + gup('PatientId') + "&AddressId=" + id
                                             , "Patient_ea"
                                             , "width=700, height=350,resizable=1");
                        w2.focus();
                    }
                    function NewTelephoneRecord(){
                        var w3 = window.open("TelephoneForm.aspx?PatientId=" + gup('PatientId'), "Patient_nt", "width=650, height=250,resizable=1");
                        w3.focus();
                    }
                    function EditTelephoneRecord(id){
                        var w4 = window.open("TelephoneForm.aspx?PatientId=" + gup('PatientId') + "&TelephoneId=" + id
                                             , "Patient_et"
                                             , "width=650, height=250,resizable=1");
                        w4.focus();
                    }
                    function NewEmailRecord(){
                        var w5 = window.open("EmailForm.aspx?PatientId=" + gup('PatientId'), "Patient_ne", "width=650, height=250,resizable=1");
                        w5.focus();
                    }
                    function EditEmailRecord(id){
                        var w6 = window.open("EmailForm.aspx?PatientId=" + gup('PatientId') + "&EmailId=" + id
                                             , "Patient_ee"
                                             , "width=650, height=250,resizable=1");
                        w6.focus();
                    }
                </script>
                <script type="text/javascript" src="GeneralFormFunctions.js">
                    //Put your JavaScript code here.
                </script>
            </telerik:RadScriptBlock>
            <script type="text/javascript" src="GeneralFormFunctions.js">
                //Put your JavaScript code here.
            </script>

            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
            </telerik:RadSkinManager>
            <telerik:RadInputManager ID="RadInputManager1" runat="server">
                <telerik:TextBoxSetting Validation-IsRequired="true">
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtName" />
                        <telerik:TargetInput ControlID="txtSurname1" />
                    </TargetControls>

                    <Validation IsRequired="True"></Validation>
                </telerik:TextBoxSetting>
                <telerik:TextBoxSetting>
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtAge" />
                        <telerik:TargetInput ControlID="txtSurname2" />
                    </TargetControls>
                </telerik:TextBoxSetting>
            </telerik:RadInputManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                                    onajaxrequest="RadAjaxManager1_AjaxRequest" >
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
                                  style="z-index: 1; left: 0px; top:0px; position: absolute; height: 678px; width: 843px">
                <div id="main-container">
                    <table>
                        <!-- Title line -->
                        <tr>
                            <td colspan="7">
                                <div id="TitleArea" runat="server" class="titleBar2">
                                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                    <asp:Label ID="lblTitle" runat="server" Text="Paciente"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <!-- Main data -->
                        <tr>
                            <td colspan="6">
                                <div ID="Buttons0" class="buttonsFomat ghost" runat="server">
                                    <asp:ImageButton ID="btnAccept0" runat="server" 
                                                     ImageUrl="~/images/document_ok.png"
                                                     onclick="btnAccept0_Click" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCancel0" runat="server" CausesValidation="False" 
                                                     ImageUrl="~/images/document_out.png" onclick="btnCancel_Click" 
                                                     ToolTip="Salir sin guardar" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="PatientId" class="normalText">
                                    <asp:Label ID="lblPatientId" runat="server" Text="ID:" 
                                               ToolTip="Identificador de paciente, lo usa internamente el sistema"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtPatientId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <!-- Former record number FRN -->
                                <div id="Frn" class="normalText">
                                    <asp:Label ID="lblFrn" runat="server" Text="FRN:" 
                                               ToolTip="Antiguo número de historia"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtFrn" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                                </div>
                            </td>

                            <td>
                                <div ID="Surname1" class="normalText">
                                    <asp:Label ID="lblSurname1" runat="server" Text="Primer apellido:" 
                                               ToolTip="Primer apellido del paciente"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSurname1" runat="server" Width="132px" TabIndex="1"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div ID="Surname2" class="normalText">
                                    <asp:Label ID="lblSurname2" runat="server" Text="Segundo apellido:" 
                                               ToolTip="Segundo apellido del paciente" ></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSurname2" runat="server" Width="132px" TabIndex="2"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div id="Name" class="normalText">
                                    <asp:Label ID="lblName" runat="server" Text="Nombre del paciente:" 
                                               ToolTip="Nombre a asignar a la Patienta" ></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtName" runat="server" Width="151px" TabIndex="3"></asp:TextBox>
                                </div>
                            </td>
                            <td style="text-align:center;">
                                <div ID="BornDate" class="normalText" >
                                    <asp:Label ID="lblBornDate" runat="server" Text="Fecha nacimiento:" 
                                               ToolTip="Fecha de nacimiento"></asp:Label>
                                    <br />
                                    <telerik:RadDatePicker ID="rddpBornDate" runat="server" Culture="es-ES" CssClass="myCenter"  
                                                           MinDate=""  TabIndex="4">
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
                            <td>
                                <div ID="VATIN" class="normalText">
                                    <asp:Label ID="lblVATIN" runat="server" Text="NIF:" 
                                               ToolTip="NIF del paciente"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtVATIN" runat="server" Width="132px"  TabIndex="5"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div ID="Clinic" class="normalText">
                                    <asp:Label ID="lblClinic" runat="server" Text="Clínica:" 
                                               ToolTip="Clínica a la que pertenece el paciente"></asp:Label>
                                    <br />
                                    <telerik:RadComboBox ID="rdcbClinic" runat="server" Width="126px" 
                                                         Skin="Office2007" TabIndex="6">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td>
                                <div ID="Sex" class="normalText">
                                    <asp:Label ID="lblSex" runat="server" Text="Sexo:" 
                                               ToolTip="Nombre a asignar a la Patienta"></asp:Label>
                                    <br />
                                    <telerik:RadComboBox ID="rdcbSex" runat="server" Width="126px" 
                                                         Skin="Office2007" TabIndex="7">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td colspan="2">

                                <div ID="Source" class="normalText">
                                    <asp:Label ID="lblSource" runat="server" Text="Procedencia:" 
                                               ToolTip="Procedencia"></asp:Label>
                                    <br />
                                    <telerik:RadComboBox ID="rdcbProcedencia" runat="server" Width="189px" 
                                                         Skin="Office2007" TabIndex="8" Height="100px">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td>
                                <div ID="Age" class="normalText" style="text-align:center">
                                    <asp:Label ID="lblAge" runat="server" Text="Edad:" 
                                               ToolTip="Edad calculada del paciente basándose en la fecha actual"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtAge" runat="server" Width="45px" Enabled="false" CssClass="myCenter"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <div id="InsuranceInformation" class="normalText">
                                    <asp:Label ID="lblInsuranceInformation" runat="server" Text="Información de asegurado:" 
                                               ToolTip="Información sobre el asegurado" ></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtInsuranceInformation" runat="server" Width="100%" TabIndex="3"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <div ID="Comments" class="normalText">
                                    <asp:Label ID="lblComments" runat="server" Text="Observaciones:" 
                                               ToolTip="Observaciones" ></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtComments" runat="server" Width="100%" Height="60px" TextMode="MultiLine" TabIndex="10"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div ID="LastUpdate" class="normalText" style="text-align:center">
                                    <asp:Label ID="lblLastUpdate" runat="server" Text="Última actualización:" 
                                               ToolTip="Fecha y hora de la última actulaización sobre esta historia"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtLastUpdate" runat="server" Width="100px" Enabled="false"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div ID="Address" class="embGrid">
                                    <asp:Label ID="lblAddress" runat="server" Text="Direcciones:" 
                                               ToolTip="Direcciones postales de la Patienta. La resaltada es la principal"></asp:Label>
                                    <br />
                                    <uc1:UscAddressGrid ID="UscAddressGrid1" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div ID="Telephones" class="embGrid">
                                    <asp:Label ID="lblTelephones" runat="server" Text="Teléfonos:" 
                                               ToolTip="Teléfonos asociados. El resaltado es el principal"></asp:Label>
                                    <br />
                                    <uc2:UscTelephoneGrid ID="UscTelephoneGrid1" runat="server" />
                                </div>
                            </td>
                            <td colspan="3">
                                <div ID="Emails" class="embGrid">
                                    <asp:Label ID="lblEmails" runat="server" Text="Correos electrónicos:" 
                                               ToolTip="Correos asociados. El resaltado es el principal."></asp:Label>
                                    <br />
                                    <uc3:UscEmailGrid ID="UscEmailGrid1" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
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
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>

