<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientTab.aspx.cs" Inherits="PatientTab" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Historial: Paciente
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
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
      <telerik:RadWindowManager ID="RadWindowManager1" runat="server" 
                                meta:resourcekey="RadWindowManager1Resource1">
      </telerik:RadWindowManager>
      <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
      </telerik:RadScriptBlock>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="True" RelativeTo="Element" 
                                 Position="TopCenter" meta:resourcekey="RadToolTipManager1Resource1" >
      </telerik:RadToolTipManager>
      <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                                   Skin="Office2007">
      </telerik:RadAjaxLoadingPanel>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                              meta:resourcekey="RadAjaxManager1Resource1">
        <AjaxSettings>
          <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
            <UpdatedControls>
              <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
            </UpdatedControls>
          </telerik:AjaxSetting>
        </AjaxSettings>
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>

      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" 
                            HorizontalAlign="NotSet" 
                            meta:resourcekey="RadAjaxPanel1Resource1" LoadingPanelID="RadAjaxLoadingPanel1">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          
          <asp:Label ID="lblTitle" runat="server" Text="Historial: Paciente" 
                     meta:resourcekey="lblTitleResource1"></asp:Label>
        </div>
        <div id="TabArea" class="normalText" style="width:100%">
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
                ontabclick="RadTabStrip1_TabClick" SelectedIndex="0">
                <Tabs>
                    <telerik:RadTab runat="server" Text="Filiación" Value="patient" Selected="True">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="His. Administrativo" Value="policy" 
                        SelectedIndex="0">
                        <Tabs>
                            <telerik:RadTab runat="server" Owner="" Text="Pólizas" Value="policy" 
                                Selected="True">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Owner="" Text="Tickets" Value="ticket">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Owner="" Text="Nota de servicio" Value="servnote">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Owner="" Text="Nota de anestésico" Value="anesnote">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Owner="" Text="Cobros" Value="payment" 
                                Selected="True">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Owner="" Text="Facturas" Value="invoice">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTab>
                    <telerik:RadTab runat="server" Text="Hist. Clínica" Value="diagnosticassigned">
                        <Tabs>
                            <telerik:RadTab runat="server" Text="Diagnósticos" Value="diagnosticassigned">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Tratamientos" Value="treatment">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Exploraciones" Value="examination">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Citas" Value="appointment">
                            </telerik:RadTab>
                            <telerik:RadTab runat="server" Text="Documentos" Value="docs">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <div id="BodyArea" class="normalText" style="width:100%">
           <iframe id="FrmArea" runat="server" width="100%" height="700px">
           </iframe>
        </div>
        <div id="Separator">
          &nbsp;
        </div>
        <div id="Messages" class="messageText" style="width:100%">
          <asp:Label ID="lblMessage" runat="server" Text="" 
                     meta:resourcekey="lblMessageResource1"></asp:Label>
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
