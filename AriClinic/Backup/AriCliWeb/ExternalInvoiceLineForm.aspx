<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExternalInvoiceLineForm.aspx.cs" Inherits="ExternalInvoiceLineForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Linea de factura
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
<style type="text/css">
            
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
                          //alert("V1: " + v1 + " V2:" + v2 + " V3:" + v3);
                          document.getElementById('<%= txtTicketId.ClientID %>').value = v1;
                          document.getElementById('<%= txtTicketData.ClientID %>').value = v3;
                          document.getElementById('<%= txtAmount.ClientID %>').value = v2;
                          $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
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
            <telerik:TargetInput ControlID="txtTicketId" />
            <telerik:TargetInput ControlID="txtInsuranceServiceName" />
          </TargetControls>
        </telerik:TextBoxSetting>
        <telerik:NumericTextBoxSetting Culture="es-ES" DecimalDigits="0" 
                                       DecimalSeparator="." GroupSeparator="." GroupSizes="3" MaxValue="999999999" 
                                       MinValue="0" NegativePattern="-n" PositivePattern="n">
          <TargetControls>
            <telerik:TargetInput ControlID="txtInvoiceLineId" />
            <telerik:TargetInput ControlID="txtPatientId" />
            <telerik:TargetInput ControlID="txtTicketId" />
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
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 319px; width: 664px">
        <%--Line 1--%>
        <table style="width: 100%;">
          <tr>
            <%-- line1 --%>
            <td colspan="6">
              <div id="TitleArea" class="titleBar2">
                <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                <asp:Label ID="lblTitle" runat="server" Text="Linea de factura"></asp:Label>
              </div>
            </td>
          </tr>
          <tr>
            <%-- line2 --%>
            <td>
              <div id="InvoiceLineId" class="normalText">
                <asp:Label ID="lblInvoiceLineId" runat="server" Text="FACLIN ID:" 
                           ToolTip="Identificador de ticket, lo usa internamente el sistema" ></asp:Label>
                <br />
                <asp:TextBox ID="txtInvoiceLineId" runat="server" Enabled="false" Width="89px" TabIndex="1" ></asp:TextBox>
              </div>
            </td>
            <td colspan="2">
              &nbsp;
            </td>
            <td>
              <div ID="InvoiceSerial" class="normalText frameData" style="padding:2px; text-align:center;">
                <asp:Label ID="lblInvoiceSerial" runat="server" Text="Serie:" 
                           ToolTip="Serie de la factura"></asp:Label>
                <br />
                <asp:TextBox ID="txtInvoiceSerial" runat="server" Enabled="False" 
                             TabIndex="8" Width="64px"></asp:TextBox>
              </div>
            </td>
            <td>
              <div ID="Year" class="normalText frameData" style="padding:2px; text-align:center;">
                <asp:Label ID="lblYear" runat="server" Text="Año:" 
                           ToolTip="Año de la factura"></asp:Label>
                <br />
                <asp:TextBox ID="txtYear" runat="server" Enabled="False" TabIndex="8" 
                             Width="64px"></asp:TextBox>
              </div>
            </td>
            <td>
              <div ID="InvoiceNumber" class="normalText frameData" style="padding:2px; text-align:center;">
                <asp:Label ID="lblInvoiceNumber" runat="server" Text="Número:"
                           ToolTip="Número de factura. Consecutivo según serie y año"></asp:Label>
                <br />
                <asp:TextBox ID="txtInvoiceNumber" runat="server" Enabled="False" TabIndex="8" 
                             Width="137px"></asp:TextBox>
              </div>
            </td>
          </tr>
          <tr>
            <%-- line3 --%>
            <td>
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
            </td>
            <td colspan="2">
              <div ID="TicketData" class="normalText">
                <asp:Label ID="lblTicketData" runat="server" Text="Ticket asociado:" 
                           ToolTip="Ticket asociado, cuando esta factura proviene de un ticket"></asp:Label>
                <br />
                <asp:TextBox ID="txtTicketData" runat="server" TabIndex="10" Width="287px"></asp:TextBox>
              </div>
            </td>
            <td>
              &nbsp;
            </td>
            <td colspan="2">
              <div ID="TaxType" class="normalText">
                <asp:Label ID="lblTaxType" runat="server" Text="Tipo de IVA:" 
                           ToolTip="Tipo de IVA aplicable"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rdcbTaxType" runat="server" TabIndex="6" Width="222px" 
                                     AutoPostBack="True" onselectedindexchanged="rdcbTaxType_SelectedIndexChanged"  >
                </telerik:RadComboBox>
              </div>
            </td>
          </tr>
          <tr>
            <%-- line4 --%>
            <td colspan="3">
              <div ID="Description" class="normalText">
                <asp:Label ID="lblDescription" runat="server" Text="Descripción del servicio:" 
                           ToolTip="Dexripción del servicio del ticket"></asp:Label>
                <br />
                <asp:TextBox ID="txtDescription" runat="server" TabIndex="10" 
                             Width="287px"></asp:TextBox>
              </div>
            </td>
            <td>
              <div ID="TaxPercentage" class="normalTextRight">
                <asp:Label ID="lblTaxPercentage" runat="server" Text="IVA (%):" 
                           ToolTip="Porcentage de IVA aplicado"></asp:Label>
                <br />
                <asp:TextBox ID="txtTaxPercentage" runat="server" style="text-align:right" 
                             TabIndex="11" Width="98px" Enabled="false"></asp:TextBox>
              </div>
            </td>
            <td>
              <div ID="Amount" class="normalTextRight">
                <asp:Label ID="lblAmount" runat="server" Text="Importe:" 
                           ToolTip="Importe del ticket"></asp:Label>
                <br />
                <asp:TextBox ID="txtAmount" runat="server"
                             TabIndex="11" Width="98px" style="text-align:right" ></asp:TextBox>
              </div>
            </td>
            <td>
              <div ID="ComissionAmount" class="normalTextRight">
                <asp:Label ID="lblComissionAmount" runat="server" Text="Importe comision:" 
                           ToolTip="Importe del ticket"></asp:Label>
                <br />
                <asp:TextBox ID="txtComissionAmount" runat="server"
                             TabIndex="11" Width="98px" style="text-align:right" ></asp:TextBox>
              </div>
            </td>
          </tr>
          <tr>
            <%-- line5 --%>
            <td colspan="6">
              <div ID="Buttons" class="buttonsFomat">
                <asp:ImageButton ID="btnAccept" runat="server" TabIndex="6" 
                                 ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                &nbsp;
                <asp:ImageButton ID="btnCancel" runat="server" TabIndex="7" 
                                 ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                 onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
              </div>
            </td>
          </tr>

        </table>

        <%--Line 2--%>

        <%--Line 3--%>



        <%--Line 4--%>



        <%--Line 5--%>
<%--        <div ID="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>--%>
      <%--Line 6--%>

      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
