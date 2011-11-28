<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentForm.aspx.cs" Inherits="PaymentForm" %>

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
}
/* Line 2 */
#PaymentId
{
z-index: 1;
left: 5px;
top: 40px;
position: absolute;
height: 44px;
width: 99px;
}
            
#PaymentDate
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
#TicketData
{
z-index: 1;
left: 121px;
top: 100px;
position: absolute;
height: 44px;
width: 291px;
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
#Message
{
z-index: 1;
left: 12px;
top: 208px;
position: absolute;
height: 44px;
width: 400px;
}
/* Line 6 */
#Buttons
{
z-index: 1;
left: 11px;
top: 265px;
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
        <script type="text/javascript">
        
          //Put your JavaScript code here.
          function refreshField(v1, v2, v3, v4, type)
          {
              if (type)
              {
                  switch (type)
                  {
                      case "Ticket":
                          document.getElementById('<%= txtTicketId.ClientID %>').value = v1;
                          document.getElementById('<%= txtTicketData.ClientID %>').value = v3;
                          document.getElementById('<%= txtAmount.ClientID %>').value = v2;
                          break;
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
            <telerik:TargetInput ControlID="txtInsuranceServiceName" />
          </TargetControls>
        </telerik:TextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="0" 
                                       DecimalSeparator="." GroupSeparator="." GroupSizes="3" MaxValue="999999999" 
                                       MinValue="0" NegativePattern="-n" PositivePattern="n">
          <TargetControls>
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
          
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 281px; width: 427px">
        <%--Line 1--%>
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Cobro"></asp:Label>
        </div>
        <%--Line 2--%>
        <div id="PaymentId" class="normalText">
          <asp:Label ID="lblPaymentId" runat="server" Text="COB ID:" 
                     ToolTip="Identificador del cobro, lo usa internamente el sistema" ></asp:Label>
          <br />
          <asp:TextBox ID="txtPaymentId" runat="server" Enabled="false" Width="89px" TabIndex="1" ></asp:TextBox>
        </div>
        <div ID="PaymentDate" class="normalText">
          <asp:Label ID="lblPaymentDate" runat="server" Text="Fecha del cobro:" 
                     ToolTip="Fecha en que se produce este cobro"></asp:Label>
          <br />
          <telerik:RadDatePicker ID="rddpPaymentDate" runat="server">
          </telerik:RadDatePicker>
        </div>
        <%--Line 3--%>
        <div ID="TicketId" class="normalText">
          <asp:Label ID="lblTicketId" runat="server" Text="TCK ID:" 
                     ToolTip="Identificador de ticket asociado, lo usa internamente el sistema"></asp:Label>
          <asp:ImageButton ID="btnTicketId" runat="server" 
                           ImageUrl="~/images/search_mini.png" CausesValidation="false"
                           ToolTip="Haga clic aquí para buscar un ticket" 
                           onclick="btnTicketId_Click" />
          <br />
          <asp:TextBox ID="txtTicketId" runat="server" TabIndex="7" 
                       Width="89px" AutoPostBack="True" 
                       ontextchanged="txtTicketId_TextChanged"></asp:TextBox>
        </div>
        <div ID="TicketData" class="normalText">
          <asp:Label ID="lblTicketData" runat="server" Text="Ticket asociado:" 
                     ToolTip="Ticket asociado, cuando esta factura proviene de un ticket"></asp:Label>
          <br />
          <asp:TextBox ID="txtTicketData" runat="server" TabIndex="10" Width="287px"></asp:TextBox>
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
          <asp:TextBox ID="txtAmount" runat="server"
                       TabIndex="11" Width="98px" style="text-align:right" ></asp:TextBox>
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
