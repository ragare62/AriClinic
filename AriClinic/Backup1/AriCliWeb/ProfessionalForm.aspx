<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalForm.aspx.cs" Inherits="ProfessionalForm" %>

<%@ Register src="UscAddressGrid.ascx" tagname="UscAddressGrid" tagprefix="uc1" %>

<%@ Register src="UscTelephoneGrid.ascx" tagname="UscTelephoneGrid" tagprefix="uc2" %>

<%@ Register src="UscEmailGrid.ascx" tagname="UscEmailGrid" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Profesional
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
width: 743px;
}

/* Line2 */

#ProfessionalId
{
z-index: 1;
left: 10px;
top: 40px;
position: absolute;
height: 44px;
width: 143px;
right: 10px;
}
#FullName
{
z-index: 1;
left: 126px;
top: 40px;
position: absolute;
height: 40px;
width: 466px;
right: 168px;
}
#VATIN
{
z-index: 1;
left: 607px;
top: 40px;
position: absolute;
height: 44px;
width: 143px;
right: 10px;
}
/* Line 3 */
#ComercialName
{
z-index: 1;
left: 10px;
top: 92px;
position: absolute;
height: 40px;
width: 336px;
right: 414px;
}
#Type
{
z-index: 1;
left: 606px;
top: 92px;
position: absolute;
height: 44px;
width: 143px;
right: 11px;
}
#User
{
z-index: 1;
left: 360px;
top: 92px;
position: absolute;
height: 45px;
width: 227px;
right: 436px;
}
/* line 4 */
#License
{
z-index: 1;
left: 11px;
top: 140px;
position: absolute;
height: 44px;
width: 143px;
right: 606px;
}
#TaxWithholding
{
z-index: 1;
left: 165px;
top: 140px;
position: absolute;
height: 44px;
width: 143px;
right: 452px;
}
#InvoiceSerial
{
z-index: 1;
left: 604px;
top: 140px;
position: absolute;
height: 44px;
width: 143px;
right: 13px;
}
#Commision
{
z-index: 1;
left: 360px;
top: 140px;
position: absolute;
height: 44px;
width: 143px;
right: 257px;
}
/* Line 5 */
#Address
{
z-index: 1;
left: 12px;
top: 195px;
position: absolute;
height: 148px;
width: 741px;
}

/* Line 6 */

#Telephones
{
z-index: 1;
left: 23px;
top: 415px;
position: absolute;
height: 122px;
width: 304px;
right: 433px;
}

#Emails
{
z-index: 1;
left: 362px;
top: 415px;
position: absolute;
height: 145px;
width: 377px;
}

/* Line 7 */

#Message
{
z-index: 1;
left: 15px;
top: 602px;
position: absolute;
height: 44px;
width: 733px;
}

/* Line 8 */
#Buttons
{
z-index: 1;
left: 19px;
top: 655px;
position: absolute;
height: 26px;
width: 725px;
}
#Buttons0
{
z-index: 1;
left: 5px;
top: 0px;
position: absolute;
height: 26px;
width: 714px;
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
      <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
      </telerik:RadWindowManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" Position="TopCenter" AutoTooltipify="true">
      </telerik:RadToolTipManager>
      <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
          //Put your JavaScript code here.
          // In order to show item changes in the grid
          function refreshGrid(arg)
          {
              //alert("Hello from refreshGrid");
              if (!arg)
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("");
              }
              else
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
              }
          }
          function NewAddressRecord()
          {
              var w1 = window.open("AddressForm.aspx?ProfessionalId=" + gup('ProfessionalId'), "Customer_na", "width=700, height=350,resizable=1");
              w1.focus();
          }
          function EditAddressRecord(id)
          {
              var w2 = window.open("AddressForm.aspx?ProfessionalId=" + gup('ProfessionalId') + "&AddressId=" + id
                                   , "Customer_ea"
                                   , "width=700, height=350,resizable=1");
              w2.focus();
          }
          function NewTelephoneRecord()
          {
              var w3 = window.open("TelephoneForm.aspx?ProfessionalId=" + gup('ProfessionalId'), "Customer_nt", "width=650, height=250,resizable=1");
              w3.focus();
          }
          function EditTelephoneRecord(id)
          {
              var w4 = window.open("TelephoneForm.aspx?ProfessionalId=" + gup('ProfessionalId') + "&TelephoneId=" + id
                                   , "Customer_et"
                                   , "width=650, height=250,resizable=1");
              w4.focus();
          }
          function NewEmailRecord()
          {
              var w5 = window.open("EmailForm.aspx?ProfessionalId=" + gup('ProfessionalId'), "Customer_ne", "width=650, height=250,resizable=1");
              w5.focus();
          }
          function EditEmailRecord(id)
          {
              var w6 = window.open("EmailForm.aspx?ProfessionalId=" + gup('ProfessionalId') + "&EmailId=" + id
                                   , "Customer_ee"
                                   , "width=650, height=250,resizable=1");
              w6.focus();
          }
        </script>
        <script type="text/javascript" src="GeneralFormFunctions.js">
          //Put your JavaScript code here.
        </script>
      </telerik:RadScriptBlock>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                              onajaxrequest="RadAjaxManager1_AjaxRequest" 
                              meta:resourcekey="RadAjaxManager1Resource1">
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
            <telerik:TargetInput ControlID="txtVATIN" />
            <telerik:TargetInput ControlID="txtFullName" />
            <telerik:TargetInput ControlID="txtComercialName" />
          </TargetControls>
          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
        <telerik:TextBoxSetting>
          <TargetControls>
          </TargetControls>
        </telerik:TextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="2" 
                                       DecimalSeparator="," GroupSeparator="." GroupSizes="3" MaxValue="100" 
                                       MinValue="0" NegativePattern="-n" PositivePattern="n">
          <TargetControls>
            <telerik:TargetInput ControlID="txtCommision" />
          </TargetControls>
        </telerik:NumericTextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 693px; width: 764px">

        <%--Line 1--%>
        <div id="TitleArea" runat="server" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Profesional"></asp:Label>
        </div>
        <%--Line 2--%>
        <div id="ProfessionalId" class="normalText">
          <asp:Label ID="lblProfessionalId" runat="server" Text="ID:" 
                     ToolTip="Identificador del profesional, lo usa internamente el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtProfessionalId" runat="server" Enabled="false" Width="89px" TabIndex="1"></asp:TextBox>
        </div>
        <div ID="FullName" class="normalText">
          <asp:Label ID="lblFullName" runat="server" TabIndex="1" 
                     Text="Nombre profesional:" ToolTip="Nombre completo del profesional"></asp:Label>
          <br />
          <asp:TextBox ID="txtFullName" runat="server" Width="456px" TabIndex="2"></asp:TextBox>
        </div>
        <div ID="VATIN" class="normalText">
          <asp:Label ID="lblVATIN" runat="server" Text="NIF:" 
                     ToolTip="NIF del paciente"></asp:Label>
          <br />
          <asp:TextBox ID="txtVATIN" runat="server" Width="132px" TabIndex="3"></asp:TextBox>
        </div>
        <%--Line 3--%>
        <div ID="ComercialName" class="normalText">
          <asp:Label ID="lblComercialName" runat="server" Text="Nombre comercial:" 
                     ToolTip="Nombre comercial del cliente" ></asp:Label>
          <br />
          <asp:TextBox ID="txtComercialName" runat="server" Width="323px" TabIndex="4"></asp:TextBox>
        </div>
        <div ID="User" class="normalText">
          <asp:Label ID="lblUser" runat="server" Text="Usuario:" 
                     ToolTip="Usuario asociado a este profesional"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbUser" runat="server" Width="229px" TabIndex="5">
          </telerik:RadComboBox>
        </div>
        <div ID="Type" class="normalText">
          <asp:Label ID="lblType" runat="server" Text="Tipo:" 
                     ToolTip="Tipo del professional"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbType" runat="server" Width="143px" TabIndex="6">
          </telerik:RadComboBox>
        </div>

        <%--Line 4--%>
        <div ID="License" class="normalText">
          <asp:Label ID="lblLicense" runat="server" Text="Num. Colegiado:" 
                     ToolTip="Número de colegiado"></asp:Label>
          <br />
          <asp:TextBox ID="txtLicense" runat="server" Width="132px" TabIndex="7"></asp:TextBox>
        </div>

        <div ID="TaxWithholding" class="normalText">
          <asp:Label ID="lblTaxWithholding" runat="server" Text="Tipo retención:" 
                     ToolTip="Tipo de retención que se aplica al profesional (solo profesionales externos)"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbTaxWithholding" runat="server" Width="143px" TabIndex="8">
          </telerik:RadComboBox>
        </div>
        <div ID="Commision" class="normalText">
          <asp:Label ID="lblCommision" runat="server" Text="Comisión (%):" 
                     ToolTip="Comisión pagada al profesional por sus servicios"></asp:Label>
          <br />
          <asp:TextBox ID="txtCommision" runat="server" Width="132px" TabIndex="9"></asp:TextBox>
        </div>
        <div ID="InvoiceSerial" class="normalText">
          <asp:Label ID="lblInvoiceSerial" runat="server" Text="Serie Facturación:" 
                     ToolTip="Serie con la que se emitirán las facturas"></asp:Label>
          <br />
          <asp:TextBox ID="txtInvoiceSerial" runat="server" Width="132px" TabIndex="10"></asp:TextBox>
        </div>
        <%-- Line 5 --%>
        <div ID="Address" class="embGrid">
          <asp:Label ID="lblAddress" runat="server" Text="Direcciones:" 
                     ToolTip="Direcciones postales del profesional. La resaltada es la principal"></asp:Label>
          <br />
          <uc1:UscAddressGrid ID="UscAddressGrid1" runat="server" />
        </div>
        <%-- Line 6 --%>
        <div ID="Telephones" class="embGrid">
          <asp:Label ID="lblTelephones" runat="server" Text="Teléfonos:" 
                     ToolTip="Teléfonos asociados. El resaltado es el principal"></asp:Label>
          <br />
          <uc2:UscTelephoneGrid ID="UscTelephoneGrid1" runat="server" />
        </div>
        <div ID="Emails" class="embGrid">
          <asp:Label ID="lblEmails" runat="server" Text="Correos electrónicos:" 
                     ToolTip="Correos asociados. El resaltado es el principal."></asp:Label>
          <br />
          <uc3:UscEmailGrid ID="UscEmailGrid1" runat="server" />
        </div>
        <%-- Line 7 --%>
        <div ID="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>
        <%-- Line 8 --%>
        <div ID="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" TabIndex="11" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" TabIndex="12" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
        </div>
        <div ID="Buttons0" class="buttonsFomat ghost" runat="server">
          <asp:ImageButton ID="btnAccept0" runat="server" TabIndex="11" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                           ToolTip="Guardar registro" />
          &nbsp;
          <asp:ImageButton ID="btnCancel0" runat="server" CausesValidation="False" TabIndex="12"
                           ImageUrl="~/images/document_out.png" onclick="btnCancel_Click" 
                           ToolTip="Salir sin guardar" />
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>

