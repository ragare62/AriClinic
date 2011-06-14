<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceForm.aspx.cs" Inherits="InsuranceForm" %>

<%@ Register src="UscInsuranceServiceGrid.ascx" tagname="UscInsuranceServiceGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Aseguradora
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
width: 658px;
}
#InsuranceId
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
left: 117px;
top: 40px;
position: absolute;
height: 44px;
width: 306px;
}
#Message
{
z-index: 1;
left: 5px;
top: 436px;
position: absolute;
height: 44px;
width: 659px;
}
#Buttons
{
z-index: 1;
left: 5px;
top: 492px;
position: absolute;
height: 26px;
width: 659px;
}
#Internal
{
z-index: 1;
left: 466px;
top: 52px;
position: absolute;
height: 27px;
width: 200px;
}
#Services
{
z-index: 1;
left: 8px;
top: 93px;
position: absolute;
height: 331px;
width: 656px;
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
        <script type="text/javascript">
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
          function NewInsuranceServiceRecord()
          {
              var w1 = window.open("InsuranceServiceForm.aspx?InsuranceId=" + gup('InsuranceId'), "insurance_na", "width=440, height=230,resizable=1");
              w1.focus();
          }
          function EditInsuranceServiceRecord(id)
          {
              var w2 = window.open("InsuranceServiceForm.aspx?InsuranceId=" + gup('InsuranceId') + "&InsuranceServiceId=" + id
                                   , "insurance_ea"
                                   , "width=440, height=230,resizable=1");
              w2.focus();
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
            <telerik:TargetInput ControlID="txtName" />
          </TargetControls>
        </telerik:TextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            
          
          
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 531px; width: 677px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Aseguradora"></asp:Label>
        </div>
        <div id="InsuranceId" class="normalText">
          <asp:Label ID="lblInsuranceId" runat="server" Text="ID:" 
                     ToolTip="Identificador de aseguradora, lo usa internamente el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtInsuranceId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
        </div>

        <div id="Name" class="normalText">
          <asp:Label ID="lblName" runat="server" Text="Nombre de la aseguradora:" 
                     ToolTip="Nombre a asignar a la aseguradora"></asp:Label>
          <br />
          <asp:TextBox ID="txtName" runat="server" Width="298px"></asp:TextBox>
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


        <div ID="Internal" class="normalText">
          <asp:CheckBox ID="chkInternal" runat="server"  Width="167px" 
                        Text="Aseguradora propia" ToolTip="Indica que esta aseguradora en realidad es la propia empresa sanitaria. Usada para pacientes completamente privados"/>
        </div>


        <div ID="Services" class="embGrid">
          <asp:Label ID="lblServices" runat="server" Text="Servicios:" 
                     ToolTip="Servicios asociados a esta aseguradora"></asp:Label>
          <uc1:UscInsuranceServiceGrid ID="UscInsuranceServiceGrid1" runat="server" />
        </div>


      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
