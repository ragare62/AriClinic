<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceForm.aspx.cs" Inherits="InvoiceForm" %>

<%@ Register src="UscInvoiceLineGrid.ascx" tagname="UscInvoiceLineGrid" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Factura
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
width: 646px;
}
/* Line 2 */
#InvoiceId
{
z-index: 1;
left: 5px;
top: 40px;
position: absolute;
height: 44px;
width: 99px;
}
#InvoiceFrame
{
z-index: 1;
left: 128px;
top: 35px;
position: absolute;
height: 59px;
width: 340px;
}
#InvoiceSerial
{
z-index: 1;
top: 5px;
position: absolute;
height: 44px;
width: 70px;
right: 263px;
}
#Year
{
z-index: 1;
left: 101px;
top: 5px;
position: absolute;
height: 44px;
width: 70px;
right: 169px;
}
#InvoiceNumber
{
z-index: 1;
left: 186px;
top: 5px;
position: absolute;
height: 44px;
width: 146px;
right: 8px;
}
            
#InvoiceDate
{
z-index: 1;
left: 493px;
top: 40px;
position: absolute;
height: 44px;
width: 157px;
}

/* Line 3 */
#CustomerId
{
z-index: 1;
left: 13px;
top: 105px;
position: absolute;
height: 43px;
width: 93px;
}
#CustomerName
{
z-index: 1;
left: 129px;
top: 105px;
position: absolute;
height: 44px;
width: 339px;
}
            
#InvoiceTotal
{
z-index: 1;
left: 490px;
height: 44px;
width: 159px;
}


/* Line 4 */
            
#InvoiceLines
{
z-index: 1;
left: 14px;
width: 632px;
}
      
/* Line 5 */
#Message
{
z-index: 1;
left: 10px;
height: 44px;
width: 641px;
}
/* Line 6 */
#Buttons
{
z-index: 1;
left: 10px;
height: 26px;
width: 642px;
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
            function refreshGrid(arg) {
                //alert("Hello from refreshGrid");
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(arg);
                }
            }
            function NewInvoiceLineRecord() {

                var w1 = window.open("InvoiceLineForm.aspx?InvoiceId=" + gup("InvoiceId"), "invl_nr1", "width=720, height=320,resizable=1");
                w1.focus();
            }
            function EditInvoiceLineRecord(id) {
                var w2 = window.open("InvoiceLineForm.aspx?InvoiceId=" + gup("InvoiceId") + "&InvoiceLineId=" + id, "invl_er1", "width=720, height=320,resizable=1");
                w2.focus();
            }
            function CloseWindow() {
                window.close();
            }
            // To return selected values to caller 
            function Selection(v1, v2, v3, v4, type) {
                window.opener.refreshField(v1, v2, v3, v4, type);
                window.close();
                return false;
            }
          //Put your JavaScript code here.
          function refreshField(v1, v2, v3, v4, type)
          {
              if (type)
              {
                  switch (type)
                  {
                      case "Customer":
                          document.getElementById('<%= txtCustomerId.ClientID %>').value = v1;
                          document.getElementById('<%= txtCustomerName.ClientID %>').value = v3;
                          //$find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
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
          </TargetControls>
        </telerik:TextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="0" 
                                       DecimalSeparator="," GroupSeparator="." 
              GroupSizes="3" MaxValue="999999999" 
                                       MinValue="0" NegativePattern="-n" 
              PositivePattern="n" Validation-IsRequired="true">

<Validation IsRequired="True"></Validation>
        </telerik:NumericTextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="2" 
                                       DecimalSeparator="," GroupSeparator="." 
                                       GroupSizes="3" NegativePattern="-n" 
                                       PositivePattern="n" Validation-IsRequired="true">
          <TargetControls>
            
          </TargetControls>

          <Validation IsRequired="True"></Validation>
        </telerik:NumericTextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            style="z-index: 1; left: 0px; top:0px; position:absolute; height: 478px; width: 664px">
        <%--Line 1--%>
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Factura"></asp:Label>
        </div>
        <%--Line 2--%>
        <div id="InvoiceId" class="normalText">
          <asp:Label ID="lblInvoiceId" runat="server" Text="FAC ID:" 
                     ToolTip="Identificador de factura, lo usa internamente el sistema" ></asp:Label>
          <br />
          <asp:TextBox ID="txtInvoiceId" runat="server" Enabled="false" Width="89px" TabIndex="1" ></asp:TextBox>
        </div>
        <div ID="InvoiceFrame" class="normalText frameData">
          <div ID="InvoiceSerial" class="normalText">
            <asp:Label ID="lblInvoiceSerial" runat="server" Text="Serie:" 
                       ToolTip="Serie de la factura"></asp:Label>
            <br />
            <asp:TextBox ID="txtInvoiceSerial" runat="server" Enabled="False" 
                         TabIndex="8" Width="64px"></asp:TextBox>
          </div>
          <div ID="Year" class="normalText">
            <asp:Label ID="lblYear" runat="server" Text="Año:" 
                       ToolTip="Año de la factura"></asp:Label>
            <br />
            <asp:TextBox ID="txtYear" runat="server" Enabled="False" TabIndex="8" 
                         Width="64px"></asp:TextBox>
          </div>
          <div ID="InvoiceNumber" class="normalText">
            <asp:Label ID="lblInvoiceNumber" runat="server" Text="Número:"
                       ToolTip="Número de factura. Consecutivo según serie y año"></asp:Label>
            <br />
            <asp:TextBox ID="txtInvoiceNumber" runat="server" Enabled="False" TabIndex="8" 
                         Width="137px"></asp:TextBox>
          </div>
        </div>
        <div ID="InvoiceDate" class="normalText">
          <asp:Label ID="lblInvoiceDate" runat="server" Text="Fecha de factura:" 
                     ToolTip="Fecha de emisión de la factura"></asp:Label>
          <br />
          <telerik:RadDatePicker ID="rddpInvoiceDate" runat="server">
          </telerik:RadDatePicker>
        </div>
        <%--Line 3--%>
        <div ID="CustomerId" class="normalText">
          <asp:Label ID="lblCustomerId" runat="server" Text="CLI ID:" 
                     ToolTip="Identificador de cliente, lo usa internamente el sistema"></asp:Label>
          <asp:ImageButton ID="btnCustomerId" runat="server" 
                           ImageUrl="~/images/search_mini.png" CausesValidation="false"
                           ToolTip="Haga clic aquí para buscar un cliente" 
                           onclick="btnCustomerId_Click" />
          <br />
          <asp:TextBox ID="txtCustomerId" runat="server" TabIndex="7" 
                       Width="89px" AutoPostBack="True" 
                       ontextchanged="txtCustomerId_TextChanged"></asp:TextBox>
        </div>
        <div ID="CustomerName" class="normalText">
          <asp:Label ID="lblCustomerName" runat="server" Text="Nombre del cliente:" 
                     ToolTip="Nombre comercial del cliente al que se le emite la factura"></asp:Label>
          <br />
          <asp:TextBox ID="txtCustomerName" runat="server" TabIndex="10" Width="330px"></asp:TextBox>
        </div>
        <div ID="InvoiceTotal" class="normalTextRight">
          <asp:Label ID="lblInvoiceTotal" runat="server" Text="Total factura:" 
                     ToolTip="Total factura (iva incluido)"></asp:Label>
          <br />
          <asp:TextBox ID="txtInvoiceTotal" runat="server" TabIndex="10" Width="152px" style="text-align:right"></asp:TextBox>
        </div>
        <div style="position: absolute; top: 160px">
        <%--Line 4--%>
        <div id="InvoiceLines" class="normalText">
          <asp:Label ID="lblInvoiceLines" runat="server" Text="Lineas de factura:" 
                     ToolTip="Nombre comercial del cliente al que se le emite la factura"></asp:Label>
          <br />
          <uc1:UscInvoiceLineGrid ID="UscInvoiceLineGrid1" runat="server" />
        </div>
        <%--Line 5--%>
        <div id="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>
        <%--Line 6--%>
        <div id="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" TabIndex="6" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" TabIndex="7" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
        </div>
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
