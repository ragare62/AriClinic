<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabTestForm.aspx.cs" Inherits="LabTestForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Prueba de laboratorio
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    <link href="dialog_box.css" rel="stylesheet" type="text/css" />
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
      <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript" src="GeneralFormFunctions.js">
          //Put your JavaScript code here.
        </script>
        <script type="text/javascript" src="dialog_box.js"></script>
        <script type="text/javascript">
          function refreshField(v1, v2, v3, v4, type)
          {
          if (type)
          {
              switch (type)
              {
                  case "UnitType":
                      combo = $find("<%= rdcUnitType.ClientID %>");
                      loadCombo(combo, v1, v3);
                      $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest(v1);
                      break;
              }
          }

          function loadCombo(combo, v1, v3)
          {
              var items = combo.get_items();
              items.clear();
              var comboItem = new Telerik.Web.UI.RadComboBoxItem();
              comboItem.set_text(v3);
              comboItem.set_value(v1);
              items.add(comboItem);
              combo.commitChanges();
              comboItem.select();
          }      
        </script>

      </telerik:RadCodeBlock>

      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
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
      <div id="content" style="height:0px">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
          <table width="100%">
            <tr>
              <td colspan="2">
                <div id="TitleArea" class="titleBar2">
                  <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                  <asp:Label ID="lblTitle" runat="server" Text="Prueba de laboratorio"></asp:Label>
                </div>
              </td>
            </tr>
            <tr>
              <td>
                <div id="LabTestId" class="normalText">
                  <asp:Label ID="lblLabTestId" runat="server" Text="ID:" 
                             ToolTip="Identificador de la prueba de laboratorio, lo usa internamente el sistema"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtLabTestId" runat="server" Enabled="false" Width="89px" TabIndex="1"></asp:TextBox>
                </div>
              </td>
              <td>
                <div id="Name" class="normalText">
                  <asp:Label ID="lblName" runat="server" Text="Nombre de la prueba:" 
                             ToolTip="Nombre del tipo de unidad"></asp:Label>
                  <br />
                  <telerik:RadTextBox ID="txtName" runat="server" Width="280px" TabIndex="2">
                  </telerik:RadTextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td>
              </td>
              <td>
                <div id="UnitType" class="normalText">
                  <asp:Label ID="lblUnitType1" runat="server" Text="Tipo de unidad:" 
                             ToolTip="Tipo de unidades de la prueba"></asp:Label>
                  <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                   ImageUrl="~/images/search_mini.png" OnClientClick="searchUnitType()" 
                                   ToolTip="Haga clic aquí para buscar tipos de unidades" />
                  <br />
                  <telerik:RadComboBox ID="rdcUnitType" runat="server" AutoPostBack="True" 
                                       EmptyMessage="Escriba aquí ..." EnableLoadOnDemand="true" 
                                       EnableVirtualScrolling="true" Height="100px" ItemsPerRequest="10" 
                                       onitemsrequested="rdcUnitType_ItemsRequested" 
                                       onselectedindexchanged="rdcUnitType_SelectedIndexChanged" 
                                       ShowMoreResultsBox="true" TabIndex="3" Width="285px">
                  </telerik:RadComboBox>
                </div>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div id="MaxValue" class="normalText">
                  <asp:Label ID="lblMaxValue" runat="server" Text="Valor máximo:" 
                             ToolTip="Valor máximo de resultado dentro de la normalidad"></asp:Label>
                  <br />
                  <telerik:RadNumericTextBox ID="txtMaxValue" runat="server" Width="280px" TabIndex="4">
                  </telerik:RadNumericTextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td></td>
              <td>
                <div id="MinValue" class="normalText">
                  <asp:Label ID="lblMinValue" runat="server" Text="Valor mínimo:" 
                             ToolTip="Valor mínimo de resultado dentro de la normalidad"></asp:Label>
                  <br />
                  <telerik:RadNumericTextBox ID="txtMinValue" runat="server" Width="280px" TabIndex="5">
                  </telerik:RadNumericTextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <div ID="Buttons" class="buttonsFomat">
                  <asp:ImageButton ID="btnAccept" runat="server" 
                                   ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                   ToolTip="Guardar y salir" />
                  &nbsp;
                  <asp:ImageButton ID="btnCancel" runat="server" CausesValidation="False" 
                                   ImageUrl="~/images/document_out.png" onclick="btnCancel_Click" 
                                   ToolTip="Salir sin guardar" />
                </div>
              </td>
            </tr>
          </table>                      

        </telerik:RadAjaxPanel>
      </div>
    </form>
  </body>
</html>
