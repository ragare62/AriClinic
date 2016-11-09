<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcedureAssignedForm.aspx.cs" Inherits="ProcedureAssignedForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Procedimiento
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
          function refreshField(v1, v2, v3, v4, type) {
              var combo;
              if (type)
              {
                  switch (type)
                  {
                      case "Patient":
                          combo = $find("<%= rdcPatient.ClientID %>");
                          loadCombo(combo, v1, v3);
                          break;
                      case "Procedure":
                          combo = $find("<%= rdcProcedure.ClientID %>");
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
                <div id="TitleArea" class="titleBar2">
                  <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                  <asp:Label ID="lblTitle" runat="server" Text="Procedimiento"></asp:Label>
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
                <div id="ProcedureDate" class="normalText" style="padding:5px">
                  <asp:Label ID="lblProcedureDate" runat="server" Text="Fecha del procedimiento:" 
                             ToolTip="Fecha en la que se diagnostic�"></asp:Label>
                  <br />
                  <telerik:RadDatePicker ID="rdpProcedureDate" runat="server" Width="100%">
                  </telerik:RadDatePicker>
                </div>
              </td>
            </tr>
            <tr>
              <td class="normalText" style="padding:5px">
                <div id="Procedure">
                  <asp:Label ID="lblProcedure" runat="server" Text="Prueba:" 
                             ToolTip="Prueba a asignar"></asp:Label>
                  <asp:ImageButton ID="btnProcedure" runat="server" 
                                   ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                   ToolTip="Haga clic aqu� para buscar una prueba" 
                                   OnClientClick="searchProcedure();" />
                  <br />
                  <telerik:RadComboBox runat="server" ID="rdcProcedure" Height="100px" 
                                       EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                       EmptyMessage="Escriba aqu� ..." 
                                       onitemsrequested="rdcProcedure_ItemsRequested" ItemsPerRequest="10" 
                                       Width="100%" >
                  </telerik:RadComboBox>
                </div>
              </td>
              <td>

              </td>
            </tr>
            <tr>
              <td colspan="2">
                <div id="Comments" class="normalText" style="padding:5px">
                  <asp:Label ID="lblComments" runat="server" Text="Comentarios:" 
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
