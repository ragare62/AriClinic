<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchedulerGeneral.aspx.cs" Inherits="SchedulerGeneral" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Agendas
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
        <link href="StyleAdvanced.css" rel="stylesheet" type="text/css" />
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
                <script type="text/javascript" src="GeneralFormFunctions.js"></script>
                <script type="text/javascript" src="SchedulerGeneral.js"></script>
            </telerik:RadScriptBlock>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                       AutoTooltipify="True" RelativeTo="Element" 
                                       Position="TopCenter" meta:resourcekey="RadToolTipManager1Resource1" >
            </telerik:RadToolTipManager>
            <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                                         Skin="Office2007" 
                                         meta:resourcekey="RadAjaxLoadingPanel1Resource1">
            </telerik:RadAjaxLoadingPanel>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                                    onajaxrequest="RadAjaxManager1_AjaxRequest" 
                                    meta:resourcekey="RadAjaxManager1Resource1">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadScheduler1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
            </telerik:RadSkinManager>

            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" 
                                  HorizontalAlign="NotSet" 
                                  meta:resourcekey="RadAjaxPanel1Resource1" LoadingPanelID="RadAjaxLoadingPanel1">
                <div id="TitleArea" class="titleScheduler">
                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          
                    <asp:Label ID="lblTitle" runat="server" Text="Agendas" 
                               meta:resourcekey="lblTitleResource1"></asp:Label>
                </div>
                <div id="scheduler-buttons">
                    <telerik:RadToolBar ID="RadToolBar1" runat="server" Skin="Office2007" 
                                        Width="100%" onbuttonclick="RadToolBar1_ButtonClick">
                        <Items>
                            <telerik:RadToolBarButton runat="server" Text="Ver mañana" Value="morning" 
                                                      ImageUrl="~/images/layout_north.png">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton runat="server" Text="Ver tarde" Value="evening" 
                                                      ImageUrl="~/images/layout_south.png">
                            </telerik:RadToolBarButton>
                            <telerik:RadToolBarButton runat="server" Text="Imprimir" Value="print" 
                                                      ImageUrl="~/images/printer24.png">
                            </telerik:RadToolBarButton>
                        </Items>
                    </telerik:RadToolBar>
                </div>
                <div id="Scheduler" class="messageText" style="width:100%; height:800px">
                    <telerik:RadScheduler ID="RadScheduler1" runat="server"
                                          Culture="es-ES" FirstDayOfWeek="Monday" 
                                          LastDayOfWeek="Sunday"  MinutesPerRow="10"  
                                          Width="100%" Height="100%" 
                                          EditFormTimeFormat="HH:mm" meta:resourcekey="RadScheduler1Resource1" 
                                          onclientappointmentediting="AppointmentEditing" 
                                          onclientappointmentinserting="AppointmentInserting"
                                          onclientappointmentmoveend="AppointmentMoveEnd" 
                                          onclientappointmentresizeend="AppointmentResizeEnd" 
                                          onappointmentdelete="RadScheduler1_AppointmentDelete" 
                                          onappointmentdatabound="RadScheduler1_AppointmentDataBound" 
                                          onnavigationcomplete="RadScheduler1_NavigationComplete"
                                          HoursPanelTimeFormat="HH:mm" WorkDayEndTime="22:00:00">
                        <AppointmentTemplate> 
                            <div id="appointment-container">
                                <div id="appointment-subject">
                                    <asp:Literal ID="AppointmentSubject" runat="server" Text='<%# Eval("Subject") %>'></asp:Literal>
                                </div>
                                <div id="appointment-description">
                                    <asp:Literal ID="lblAppointmentDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                </div>
                            </div>
                        </AppointmentTemplate>
                    </telerik:RadScheduler>
                </div>
                <div id="Separator">
                    &nbsp;
                </div>

            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
