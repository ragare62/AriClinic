<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerForm.aspx.cs" Inherits="CustomerForm" %>

<%@ Register src="UscAddressGrid.ascx" tagname="UscAddressGrid" tagprefix="uc1" %>

<%@ Register src="UscTelephoneGrid.ascx" tagname="UscTelephoneGrid" tagprefix="uc2" %>

<%@ Register src="UscEmailGrid.ascx" tagname="UscEmailGrid" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Cliente
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    <link href="dialog_box.css" rel="Stylesheet" type="text/css" />
<style type="text/css">
#TitleArea
{
z-index: 1;
left: 5px;
top: 0px;
position: absolute;
height: 19px;
width: 743px;
}
#CustomerId
{
z-index: 1;
left: 5px;
top: 40px;
position: absolute;
height: 44px;
width: 71px;
}
#Name
{
z-index: 1;
left: 434px;
top: 40px;
position: absolute;
height: 44px;
width: 154px;
}

#ComercialName
{
z-index: 1;
left: 84px;
top: 40px;
position: absolute;
height: 40px;
width: 225px;
right: 451px;
}

#Surname2
{
z-index: 1;
left: 278px;
top: 40px;
position: absolute;
height: 44px;
width: 143px;
right: 339px;
}
#Message
{
z-index: 1;
left: 15px;
top: 468px;
position: absolute;
height: 44px;
width: 733px;
}
#Buttons
{
z-index: 1;
left: 20px;
top: 530px;
position: absolute;
height: 26px;
width: 725px;
}

#Address
{
z-index: 1;
left: 12px;
top: 100px;
position: absolute;
height: 148px;
width: 741px;
}

#Telephones
{
z-index: 1;
left: 13px;
top: 276px;
position: absolute;
height: 122px;
width: 304px;
right: 443px;
}

#Emails
{
z-index: 1;
left: 354px;
top: 277px;
position: absolute;
height: 145px;
width: 377px;
}


#Age
{
z-index: 1;
left: 435px;
top: 90px;
position: absolute;
height: 44px;
width: 154px;
}

#BornDate
{
z-index: 1;
left: 600px;
top: 40px;
position: absolute;
height: 44px;
width: 154px;
}


#Sex
{
z-index: 10000;
left: 435px;
top: 90px;
position: absolute;
height: 132px;
width: 133px;
right: 192px;
}


#Age
{
z-index: 1;
left: 648px;
top: 90px;
position: absolute;
height: 44px;
width: 102px;
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


#VATIN
{
z-index: 1;
left: 322px;
top: 38px;
position: absolute;
height: 44px;
width: 88px;
right: 350px;
}

#Insurance
{
z-index: 1;
left: 423px;
top: 39px;
position: absolute;
height: 44px;
width: 170px;
right: 167px;
}

#PolicyNumber
{
z-index: 1;
left: 608px;
top: 38px;
position: absolute;
height: 44px;
width: 140px;
right: 12px;
}


</style>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico"/>
  </head>
  <body id="content">
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
          window.radconfirm = function (text, mozEvent, oWidth, oHeight, callerObj, oTitle)
          {
              var ev = mozEvent ? mozEvent : window.event; //Moz support requires passing the event argument manually   
              //Cancel the event   
              ev.cancelBubble = true;
              ev.returnValue = false;
              if (ev.stopPropagation) ev.stopPropagation();
              if (ev.preventDefault) ev.preventDefault();

              //Determine who is the caller   
              var callerObj = ev.srcElement ? ev.srcElement : ev.target;

              //Call the original radconfirm and pass it all necessary parameters   
              if (callerObj)
              {
                  //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again.   
                  var callBackFn = function (arg)
                  {
                      if (arg)
                      {
                          callerObj["onclick"] = "";
                          if (callerObj.click) callerObj.click(); //Works fine every time in IE, but does not work for links in Moz   
                          else if (callerObj.tagName == "A") //We assume it is a link button!   
                          {
                              try
                              {
                                  eval(callerObj.href)
                              }
                              catch (e)
                              {
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
              var w1 = window.open("AddressForm.aspx?CustomerId=" + gup('CustomerId'), "Customer_na", "width=700, height=350,resizable=1");
              w1.focus();
          }
          function EditAddressRecord(id)
          {
              var w2 = window.open("AddressForm.aspx?CustomerId=" + gup('CustomerId') + "&AddressId=" + id
                                   , "Customer_ea"
                                   , "width=700, height=350,resizable=1");
              w2.focus();
          }
          function NewTelephoneRecord()
          {
              var w3 = window.open("TelephoneForm.aspx?CustomerId=" + gup('CustomerId'), "Customer_nt", "width=650, height=250,resizable=1");
              w3.focus();
          }
          function EditTelephoneRecord(id)
          {
              var w4 = window.open("TelephoneForm.aspx?CustomerId=" + gup('CustomerId') + "&TelephoneId=" + id
                                   , "Customer_et"
                                   , "width=650, height=250,resizable=1");
              w4.focus();
          }
          function NewEmailRecord()
          {
              var w5 = window.open("EmailForm.aspx?CustomerId=" + gup('CustomerId'), "Customer_ne", "width=650, height=250,resizable=1");
              w5.focus();
          }
          function EditEmailRecord(id)
          {
              var w6 = window.open("EmailForm.aspx?CustomerId=" + gup('CustomerId') + "&EmailId=" + id
                                   , "Customer_ee"
                                   , "width=650, height=250,resizable=1");
              w6.focus();
          }
        </script>
        <script type="text/javascript" src="GeneralFormFunctions.js">
          //Put your JavaScript code here.
        </script>
        <script type="text/javascript" src="dialog_box.js"></script>
      </telerik:RadScriptBlock>


      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadInputManager ID="RadInputManager1" runat="server">
        <telerik:TextBoxSetting Validation-IsRequired="true">
          <TargetControls>
            <telerik:TargetInput ControlID="txtVATIN" />
            <telerik:TargetInput ControlID="txtComercialName" />
          </TargetControls>

          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
        <telerik:TextBoxSetting>
          <TargetControls>
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
            <telerik:AjaxSetting AjaxControlID="txtVATIN">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtVATIN" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
      </telerik:RadAjaxManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server"
                            
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 564px; width: 764px">
        <div id="TitleArea" runat="server" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Cliente"></asp:Label>
        </div>
        <div id="CustomerId" class="normalText">
          <asp:Label ID="lblCustomerId" runat="server" Text="ID:" 
                     ToolTip="Identificador de cliente, lo usa internamente el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtCustomerId" runat="server" Enabled="false" Width="63px"></asp:TextBox>
        </div>
        <div ID="ComercialName" class="normalText">
          <asp:Label ID="lblComercialName" runat="server" Text="Nombre comercial:" 
                     ToolTip="Nombre comercial del cliente" TabIndex="1"></asp:Label>
          <br />
          <asp:TextBox ID="txtComercialName" runat="server" Width="222px"></asp:TextBox>
        </div>
        <div ID="VATIN" class="normalText">
          <asp:Label ID="lblVATIN" runat="server" Text="NIF:" 
                     ToolTip="NIF del paciente" TabIndex="4"></asp:Label>
          <br />
          <asp:TextBox ID="txtVATIN" runat="server" Width="90px" 
                ontextchanged="txtVATIN_TextChanged" AutoPostBack="True"></asp:TextBox>
        </div>
        <div ID="Insurance" class="normalText">
          <asp:Label ID="lblInsurance" runat="server" Text="Aseguradora Principal:" 
                     ToolTip="Aseguradora principal" TabIndex="4"></asp:Label>
          <br />

          <telerik:RadComboBox ID="rdcbIsurance" Runat="server">
          </telerik:RadComboBox>

        </div>
        <div ID="PolicyNumber" class="normalText">
          <asp:Label ID="lblPolicyNumber" runat="server" Text="Número de Poliza:" 
                     ToolTip="Número de pólixza asociada" TabIndex="4"></asp:Label>
          <br />
          <asp:TextBox ID="txtPolicyNumber" runat="server" Width="135px"></asp:TextBox>
        </div>        
        <div ID="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>


        <div ID="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
        </div>
        <div ID="Address" class="embGrid">
          <asp:Label ID="lblAddress" runat="server" Text="Direcciones:" 
                     ToolTip="Direcciones postales de la Customera. La resaltada es la principal"></asp:Label>
          <br />
          <uc1:UscAddressGrid ID="UscAddressGrid1" runat="server" />
        </div>
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

        <div ID="Buttons0" class="buttonsFomat ghost" runat="server">
          <asp:ImageButton ID="btnAccept0" runat="server" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                           ToolTip="Guardar registro" />
          &nbsp;
          <asp:ImageButton ID="btnCancel0" runat="server" CausesValidation="False" 
                           ImageUrl="~/images/document_out.png" onclick="btnCancel_Click" 
                           ToolTip="Salir sin guardar" />
        </div>

      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>

