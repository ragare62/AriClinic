<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicyForm.aspx.cs" Inherits="PolicyForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Póliza
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
              width: 535px;
          }
          /* Line 2 */
          #PolicyId
          {
              z-index: 1;
              left: 5px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 99px;
          }
          #Customer
          {
              z-index: 1;
              left: 121px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 291px;
          }
          #Type
          {
              z-index: 1;
              left: 423px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 116px;
          }
          /* Line 3 */
          #Insurance
          {
              z-index: 1;
              left: 8px;
              top: 95px;
              position: absolute;
              height: 44px;
              width: 165px;
          }
          #BeginDate
          {
              z-index: 1;
              left: 230px;
              top: 95px;
              position: absolute;
              height: 44px;
              width: 147px;
              right: 166px;
          }
          #EndDate
          {
              z-index: 1;
              left: 394px;
              top: 95px;
              position: absolute;
              height: 44px;
              width: 147px;
              right: 2px;
          }
          /* Line 4 */
          #Message
          {
              z-index: 1;
              left: 5px;
              top: 204px;
              position: absolute;
              height: 44px;
              width: 537px;
          }
          /* Line 5 */
          #Buttons
          {
              z-index: 1;
              left: 5px;
              top: 258px;
              position: absolute;
              height: 26px;
              width: 532px;
          }
          #PolicyNumber
          {
              z-index: 1;
              left: 229px;
              top: 147px;
              position: absolute;
              height: 44px;
              width: 291px;
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
      <script type="text/javascript" src="GeneralFormFunctions.js">
        //Put your JavaScript code here.
      </script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadInputManager ID="RadInputManager1" runat="server">
        <telerik:TextBoxSetting Validation-IsRequired="true">
          <TargetControls>
            <telerik:TargetInput ControlID="txtCustomer" />

          </TargetControls>

          <Validation IsRequired="True"></Validation>
        </telerik:TextBoxSetting>
        <telerik:TextBoxSetting>
          <TargetControls>
            <telerik:TargetInput ControlID="txtPolicyNumber" />
          </TargetControls>
        </telerik:TextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            
                            
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 277px; width: 550px">
        <%--Line 1--%>
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Póliza"></asp:Label>
        </div>
        <%--Line 2--%>
        <div id="PolicyId" class="normalText">
          <asp:Label ID="lblPolicyId" runat="server" Text="ID:" 
                     ToolTip="Identificador de póliza, lo usa internamente el sistema" ></asp:Label>
          <br />
          <asp:TextBox ID="txtPolicyId" runat="server" Enabled="false" Width="89px" TabIndex="1" ></asp:TextBox>
        </div>
        <div id="Customer" class="normalText">
          <asp:Label ID="lblCustomer" runat="server" Text="Paciente / Cliente:" 
                     ToolTip="Cliente de la póliza"></asp:Label>
          <br />
          <asp:TextBox ID="txtCustomer" runat="server" Width="287px" TabIndex="2" 
                       Enabled="False" ></asp:TextBox>
        </div>
        <div ID="Type" class="normalText">
          <asp:Label ID="lblType" runat="server" Text="Tipo:" 
                     ToolTip="Tipo de póliza, la prinicpal será la usada por defecto."></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbType" runat="server" Width="119px" TabIndex="1" >
          </telerik:RadComboBox>
        </div>
        <%--Line 3--%>
        <div ID="Insurance" class="normalText">
          <asp:Label ID="lblInsurance" runat="server" Text="Aseguradora:" 
                     ToolTip="Aseguradora ligada a la póliza"></asp:Label>
          <br />
          <telerik:RadComboBox ID="rdcbInsurance" runat="server" TabIndex="3" >
          </telerik:RadComboBox>
        </div>
        <div ID="BeginDate" class="normalText">
          <asp:Label ID="lblBeginDate" runat="server" Text="Fecha de inicio:" 
                     ToolTip="Fecha de inicio de la póliza"></asp:Label>
          <br />
          <telerik:RadDatePicker ID="rddpBeginDate" Runat="server" TabIndex="4" 
                                 Culture="es-ES" MaxDate="2500-12-31" >
            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                      ViewSelectorText="x">
            </Calendar>
            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="4">
            </DateInput>
            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="4" />
          </telerik:RadDatePicker>
        </div>
        <div ID="EndDate" class="normalText">
          <asp:Label ID="lblEndDate" runat="server" Text="Fecha fin:" 
                     ToolTip="Fecha fin de la póliza"></asp:Label>
          <br />
          <telerik:RadDatePicker ID="rddpEndDate" Runat="server" TabIndex="5" 
                                 Culture="es-ES" MaxDate="2500-12-31"  >
            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                      ViewSelectorText="x">
            </Calendar>
            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="5">
            </DateInput>
            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="5" />
          </telerik:RadDatePicker>
        </div>
        <%--Line 4--%>
        <div ID="PolicyNumber" class="normalText">
          <asp:Label ID="lblPolicyNumber" runat="server" Text="Número de póliza:" 
                     ToolTip="Número de la póliza"></asp:Label>
          <br />
          <asp:TextBox ID="txtPolicyNumber" runat="server" TabIndex="6" 
                       Width="287px"></asp:TextBox>
        </div>        
        <%--Line 5--%>
        <div ID="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>
        <%--Line 6--%>
        <div ID="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" TabIndex="7" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" TabIndex="8" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
        </div>

      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
