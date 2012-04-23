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
#PatientId
{
z-index: 1;
left: 5px;
top: 40px;
position: absolute;
height: 44px;
width: 99px;
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

#Surname1
{
z-index: 1;
left: 118px;
top: 40px;
position: absolute;
height: 40px;
width: 143px;
right: 467px;
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

#Comments
{
z-index: 1;
left: 11px;
top: 127px;
position: absolute;
height: 44px;
width: 581px;
right: 168px;
}

#Message
{
z-index: 1;
left: 6px;
top: 548px;
position: absolute;
height: 27px;
width: 708px;
}
#Buttons
{
z-index: 1;
left: 5px;
top: 607px;
position: absolute;
height: 26px;
width: 714px;
}

#Address
{
z-index: 1;
left: 9px;
top: 188px;
position: absolute;
height: 148px;
width: 741px;
}

#Telephones
{
z-index: 1;
left: 11px;
top: 371px;
position: absolute;
height: 122px;
width: 304px;
right: 445px;
}

#Emails
{
z-index: 1;
left: 339px;
top: 369px;
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
#LastUpdate
{
z-index: 1;
left: 604px;
top: 132px;
position: absolute;
height: 44px;
width: 142px;
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
left: 280px;
top: 93px;
position: absolute;
height: 132px;
width: 133px;
right: 347px;
}
#Clinic
{
z-index: 10000;
left: 150px;
top: 93px;
position: absolute;
height: 132px;
width: 133px;
right: 347px;
}
#Source
{
z-index: 10000;
left: 437px;
top: 93px;
position: absolute;
height: 132px;
width: 192px;
right: 131px;
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
left: 7px;
top: 90px;
position: absolute;
height: 44px;
width: 143px;
right: 610px;
}


#Sex0
{
z-index: 10000;
left: 273px;
top: 95px;
position: absolute;
height: 132px;
width: 133px;
right: 354px;
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
              var w1 = window.open("AddressForm.aspx?PatientId=" + gup('PatientId'), "Patient_na", "width=700, height=350,resizable=1");
              w1.focus();
          }
          function EditAddressRecord(id)
          {
              var w2 = window.open("AddressForm.aspx?PatientId=" + gup('PatientId') + "&AddressId=" + id
                                   , "Patient_ea"
                                   , "width=700, height=350,resizable=1");
              w2.focus();
          }
          function NewTelephoneRecord()
          {
              var w3 = window.open("TelephoneForm.aspx?PatientId=" + gup('PatientId'), "Patient_nt", "width=650, height=250,resizable=1");
              w3.focus();
          }
          function EditTelephoneRecord(id)
          {
              var w4 = window.open("TelephoneForm.aspx?PatientId=" + gup('PatientId') + "&TelephoneId=" + id
                                   , "Patient_et"
                                   , "width=650, height=250,resizable=1");
              w4.focus();
          }
          function NewEmailRecord()
          {
              var w5 = window.open("EmailForm.aspx?PatientId=" + gup('PatientId'), "Patient_ne", "width=650, height=250,resizable=1");
              w5.focus();
          }
          function EditEmailRecord(id)
          {
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
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 678px; width: 764px">
        <div id="TitleArea" runat="server" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Paciente"></asp:Label>
        </div>
        <div id="PatientId" class="normalText">
          <asp:Label ID="lblPatientId" runat="server" Text="ID:" 
                     ToolTip="Identificador de paciente, lo usa internamente el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtPatientId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
        </div>
        <div id="Name" class="normalText">
          <asp:Label ID="lblName" runat="server" Text="Nombre del paciente:" 
                     ToolTip="Nombre a asignar a la Patienta" TabIndex="0"></asp:Label>
          <br />
          <asp:TextBox ID="txtName" runat="server" Width="151px"></asp:TextBox>
        </div>
        <div ID="Surname1" class="normalText">
          <asp:Label ID="lblSurname1" runat="server" Text="Primer apellido:" 
                     ToolTip="Primer apellido del paciente" TabIndex="1"></asp:Label>
          <br />
          <asp:TextBox ID="txtSurname1" runat="server" Width="132px"></asp:TextBox>
        </div>
        <div ID="Surname2" class="normalText">
          <asp:Label ID="lblSurname2" runat="server" Text="Segundo apellido:" 
                     ToolTip="Segundo apellido del paciente" TabIndex="2"></asp:Label>
          <br />
          <asp:TextBox ID="txtSurname2" runat="server" Width="132px"></asp:TextBox>
        </div>
        <div ID="Comments" class="normalText">
          <asp:Label ID="lblComments" runat="server" Text="Observaciones:" 
                     ToolTip="Observaciones" TabIndex="2"></asp:Label>
          <br />
          <asp:TextBox ID="txtComments" runat="server" Width="575px" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div ID="VATIN" class="normalText">
          <asp:Label ID="lblVATIN" runat="server" Text="NIF:" 
                     ToolTip="NIF del paciente" TabIndex="4"></asp:Label>
          <br />
          <asp:TextBox ID="txtVATIN" runat="server" Width="132px"></asp:TextBox>
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
                     ToolTip="Direcciones postales de la Patienta. La resaltada es la principal"></asp:Label>
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

        <div ID="BornDate" class="normalText">
          <asp:Label ID="lblBornDate" runat="server" Text="Fecha nacimiento:" 
                     ToolTip="Fecha de nacimiento"></asp:Label>
          <br />
          <telerik:RadDatePicker ID="rddpBornDate" runat="server" Culture="es-ES" 
                MinDate="" TabIndex="3">
              <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                  ViewSelectorText="x">
              </Calendar>
              <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
              </DateInput>
              <DatePopupButton HoverImageUrl="" ImageUrl="" />
          </telerik:RadDatePicker>
        </div>
        <div ID="Clinic" class="normalText">
          <asp:Label ID="lblClinic" runat="server" Text="Clínica:" 
                     ToolTip="Clínica a la que pertenece el paciente"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbClinic" runat="server" Width="126px" 
                Skin="Office2007" TabIndex="5">
          </telerik:RadComboBox>
        </div>

        <div ID="Sex" class="normalText">
          <asp:Label ID="lblSex" runat="server" Text="Sexo:" 
                     ToolTip="Nombre a asignar a la Patienta"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbSex" runat="server" Width="126px" 
                Skin="Office2007" TabIndex="5">
          </telerik:RadComboBox>
        </div>

        <div ID="Source" class="normalText">
          <asp:Label ID="lblSource" runat="server" Text="Procedencia:" 
                     ToolTip="Procedencia"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbProcedencia" runat="server" Width="189px" 
                Skin="Office2007" TabIndex="6" Height="100px">
          </telerik:RadComboBox>
        </div>

        <div ID="Age" class="normalText" style="text-align:right">
          <asp:Label ID="lblAge" runat="server" Text="Edad:" 
                     ToolTip="Edad calculada del paciente basándose en la fecha actual"></asp:Label>
          <br />
          <asp:TextBox ID="txtAge" runat="server" Width="76px" Enabled="false"></asp:TextBox>
        </div>
        <div ID="LastUpdate" class="normalText" style="text-align:right">
          <asp:Label ID="lblLastUpdate" runat="server" Text="Última actualización:" 
                     ToolTip="Fecha y hora de la última actulaización sobre esta historia"></asp:Label>
          <br />
          <asp:TextBox ID="txtLastUpdate" runat="server" Width="140px" Enabled="false"></asp:TextBox>
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

