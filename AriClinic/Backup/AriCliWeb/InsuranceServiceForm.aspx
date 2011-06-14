<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceServiceForm.aspx.cs" Inherits="InsuranceServiceForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Servicio asegurado
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
width: 400px;
}
#InsuranceServiceId
{
z-index: 1;
left: 5px;
top: 40px;
position: absolute;
height: 44px;
width: 99px;
}
#Insurance
{
z-index: 1;
left: 117px;
top: 40px;
position: absolute;
height: 44px;
width: 291px;
}
#Message
{
z-index: 1;
left: 5px;
top: 148px;
position: absolute;
height: 44px;
width: 403px;
}
#Buttons
{
z-index: 1;
left: 5px;
top: 204px;
position: absolute;
height: 26px;
width: 403px;
}
#TaxType
{
z-index: 1;
left: 8px;
top: 94px;
position: absolute;
height: 44px;
width: 165px;
}
#InsuranceServiceCategory
{
z-index: 1;
left: 189px;
top: 94px;
position: absolute;
height: 44px;
width: 216px;
}
#ServiceId
{
z-index: 1;
left: 10px;
top: 92px;
position: absolute;
height: 44px;
width: 87px;
}
.style1
{
width: 10px;
height: 10px;
}
#ServiceName
{
z-index: 1;
left: 101px;
top: 91px;
position: absolute;
height: 44px;
width: 191px;
right: 124px;
}
#Price
{
z-index: 1;
left: 300px;
top: 91px;
position: absolute;
height: 44px;
width: 108px;
right: 8px;
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
          //Put your JavaScript code here.
          function refreshField(v1, v2, v3, v4, type)
          {
              if (type)
              {
                  switch (type)
                  {
                      case "Service":
                          document.getElementById('<%= txtServiceId.ClientID %>').value = v1;
                          document.getElementById('<%= txtServiceName.ClientID %>').value = v3;
                          break;
                  }
              }
          }
        </script>
      </telerik:RadScriptBlock>

      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" >
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadInputManager ID="RadInputManager1" runat="server">
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="0" 
                                       DecimalSeparator="," GroupSeparator="." GroupSizes="3" MaxValue="999999999" 
                                       MinValue="0" NegativePattern="-n" PositivePattern="n">
          <TargetControls>
            <telerik:TargetInput ControlID="txtServiceId" />
          </TargetControls>
        </telerik:NumericTextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="2" 
                                       DecimalSeparator="," GroupSeparator="." GroupSizes="3" MaxValue="999999" 
                                       MinValue="0" NegativePattern="-n" PositivePattern="n" Validation-IsRequired="true">
          <TargetControls>
            <telerik:TargetInput ControlID="txtPrice" />
          </TargetControls>
        </telerik:NumericTextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="210px" 
                            Width="420px" 
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 231px; width: 420px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Servicio asegurado"></asp:Label>
        </div>
        <div id="InsuranceServiceId" class="normalText">
          <asp:Label ID="lblInsuranceServiceId" runat="server" Text="ID:" 
                     ToolTip="Identificador de servicio asegurado, lo usa internamente el sistema"></asp:Label>
          <br />
          <asp:TextBox ID="txtInsuranceServiceId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
        </div>

        <div id="Insurance" class="normalText">
          <asp:Label ID="lblInsurance" runat="server" Text="Aseguradora:" 
                     ToolTip="Aseguradora a la que se presta el servicio"></asp:Label>
          <br />
          <asp:TextBox ID="txtInsurance" runat="server" Width="287px" TabIndex="1" Enabled="false"></asp:TextBox>
        </div>


        <div ID="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>


        <div ID="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="4" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar" TabIndex="5" />
        </div>


        <div ID="ServiceId" class="normalText">
          <asp:Label ID="lblServiceId" runat="server" Text="ID Serv:" 
                     ToolTip="Aseguradora a la que se presta el servicio"></asp:Label>
          <asp:ImageButton ID="btnService" runat="server" ImageUrl="~/images/search_mini.png" OnClientClick="searchService();" ToolTip="Haga clic aquí para buscar un servicio" />
          <br />
          <asp:TextBox ID="txtServiceId" runat="server" Width="80px" Height="22px" 
                       TabIndex="2" AutoPostBack="true" 
                ontextchanged="txtServiceId_TextChanged"></asp:TextBox>
        </div>


        <div ID="ServiceName" class="normalText">
          <asp:Label ID="lblServiceName" runat="server" Text="Servicio:" 
                     ToolTip="Servicio a asignar"></asp:Label>
          <br />
          <asp:TextBox ID="txtServiceName" runat="server" Width="186px" Enabled="false" Height="22px"></asp:TextBox>
        </div>


        <div ID="Price" class="normalTextRight">
          <asp:Label ID="lblPrice" runat="server" Text="Precio:" 
                     ToolTip="Precio del servicio para esta aseguradora"></asp:Label>
          <br />
          <asp:TextBox ID="txtPrice" runat="server" Width="106px" Height="22px" 
                TabIndex="3" style="text-align:right"></asp:TextBox>
        </div>


      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
