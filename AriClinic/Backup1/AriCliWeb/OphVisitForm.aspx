<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OphVisitForm.aspx.cs" Inherits="OphVisitForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Visita m�dica
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
        <script type="text/javascript" src="GeneralFormFunctions.js"></script>
        <script type="text/javascript" src="dialog_box.js"></script>
        <script type="text/javascript">
          function refreshField(v1, v2, v3, v4, type)
          {
              var combo;
              if (type)
              {
                  switch (type)
                  {
                      case "Patient":
                          combo = $find("<%= rdcPatient.ClientID %>");
                          loadCombo(combo, v1, v3);
                          break;
                      case "Professional":
                          combo = $find("<%= rdcProfessional.ClientID %>");
                          loadCombo(combo, v1, v3);
                          break;
                      case "VisitReason":
                          combo = $find("<%= rdcVisitReason.ClientID %>");
                          loadCombo(combo, v1, v3);
                          break;
                      case "AppointmentType":
                          combo = $find("<%= rdcAppointmentType.ClientID %>");
                          loadCombo(combo, v1, v3);
                          break;
                  }
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
          function parentReload(url) {
              parent.open(url, "OPHVISIT", "width=800, height=500,resizable=1");
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
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
          <table width="100%">
            <tr>
              <td colspan="2">
                <div id="TitleArea" runat="server" class="titleBar2">
                  <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                  <asp:Label ID="lblTitle" runat="server" Text="Visita m�dica"></asp:Label>
                </div>
              </td>
            </tr>
            <tr>
              <td width="70%">
                <div id="Patient" class="normalText" style="padding:5px">
                  <asp:Label ID="lblPatient" runat="server" Text="Paciente:" 
                             ToolTip="Paciente al que se asigna la prueba"></asp:Label>
                  <asp:ImageButton ID="btnPatient" runat="server" 
                                   ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                   ToolTip="Haga clic aqu� para buscar un paciente" 
                                   OnClientClick="searchPatient();" />
                  <br />
                  <telerik:RadComboBox runat="server" ID="rdcPatient" Height="100px" 
                                       EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                       EmptyMessage="Escriba aqu� ..." 
                                       onitemsrequested="rdcPatient_ItemsRequested" ItemsPerRequest="10" 
                                       Width="100%" >
                  </telerik:RadComboBox>
                </div>
              </td>
              <td>
                <div id="VisitDate" class="normalText" style="padding:5px">
                  <asp:Label ID="lblVisitDate" runat="server" Text="Fecha de la visita" 
                             ToolTip="Fecha en la que se realiz� la visita."></asp:Label>
                  <br />
                  <telerik:RadDatePicker ID="rdpVisitDate" runat="server" Width="100%">
                  </telerik:RadDatePicker>
                </div>
              </td>
            </tr>
          </table>                      
          <table width="100%">
            <tr>
              <td class="normalText" style="padding:5px" width="50%">
                <div ID="Professional">
                  <asp:Label ID="lblProfessional" runat="server" Text="Profesional:" 
                             ToolTip="Prueba a asignar"></asp:Label>
                  <asp:ImageButton ID="btnProfessional" runat="server" CausesValidation="false" 
                                   ImageUrl="~/images/search_mini.png" OnClientClick="searchProfessional();" 
                                   ToolTip="Haga clic aqu� para buscar un profesional" />
                  <br />
                  <telerik:RadComboBox ID="rdcProfessional" runat="server" 
                                       EmptyMessage="Escriba aqu� ..." EnableLoadOnDemand="true" 
                                       EnableVirtualScrolling="true" Height="100px" ItemsPerRequest="10" 
                                       onitemsrequested="rdcProfessional_ItemsRequested" ShowMoreResultsBox="true" 
                                       Width="100%">
                  </telerik:RadComboBox>
                </div>
              </td>

              <td class="normalText" style="padding:5px" width="50%">
                <div ID="AppointmentType">
                  <asp:Label ID="lblAppointmentType" runat="server" Text="Tipo de cita:" 
                             ToolTip="Tipo de cita"></asp:Label>
                  <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                   ImageUrl="~/images/search_mini.png" OnClientClick="searchAppointmentType();" 
                                   ToolTip="Haga clic aqu� para buscar un tipo de cita" />
                  <br />
                  <telerik:RadComboBox ID="rdcAppointmentType" runat="server" 
                                       EmptyMessage="Escriba aqu� ..." EnableLoadOnDemand="true" 
                                       EnableVirtualScrolling="true" Height="100px" ItemsPerRequest="10" 
                                       onitemsrequested="rdcAppointmentType_ItemsRequested" ShowMoreResultsBox="true" 
                                       Width="100%">
                  </telerik:RadComboBox>
                </div>
              </td>
            </tr>
            <tr>
              <td width="50%"></td>
              <td class="normalText" style="padding:5px" width="50%">
                <div ID="VisitReason">
                  <asp:Label ID="lblVisitReason" runat="server" Text="Motivo visita:" 
                             ToolTip="Motivo de la visita"></asp:Label>
                  <asp:ImageButton ID="btnVisitReason" runat="server" CausesValidation="false" 
                                   ImageUrl="~/images/search_mini.png" OnClientClick="searchVisitReason();" 
                                   ToolTip="Haga clic aqu� para buscar un motivo" />
                  <br />
                  <telerik:RadComboBox ID="rdcVisitReason" runat="server" 
                                       EmptyMessage="Escriba aqu� ..." EnableLoadOnDemand="true" 
                                       EnableVirtualScrolling="true" Height="100px" ItemsPerRequest="10" 
                                       onitemsrequested="rdcVisitReason_ItemsRequested" ShowMoreResultsBox="true" 
                                       Width="100%">
                  </telerik:RadComboBox>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <div id="DiagnosticDetails" class="normalText" style="padding:5px">
                  <asp:Label ID="lblDiagnisticDetails" runat="server" Text="Juicio cl�nico:" 
                             ToolTip="Comentarios al diagn�stico"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtDiagnosticDetails" runat="server" TextMode="MultiLine" Height="155px" 
                               Width="100%"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <div id="Comments" class="normalText" style="padding:5px">
                  <asp:Label ID="lblComments" runat="server" Text="Conclusiones:" 
                             ToolTip="Comentarios al diagn�stico"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="155px" 
                               Width="100%"></asp:TextBox>
                </div>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <div ID="Buttons" class="buttonsFomat">
                  <asp:ImageButton ID="btnAccept" runat="server" 
                                   ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" />
                  &nbsp;
                  <asp:ImageButton ID="btnCancel" runat="server" 
                                   ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                   onclick="btnCancel_Click" ToolTip="Salir sin guardar" />
                </div>
              </td>
            </tr>
          </table>

        </telerik:RadAjaxPanel>
      </div>
    </form>
  </body>
</html>
