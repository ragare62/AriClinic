﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalInvoiceGrid.aspx.cs" Inherits="AriCliWeb.ProfessionalInvoiceGrid" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head id="Head1" runat="server">
    <title>
      Facturas
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
        <script type="text/javascript" src="GeneralFormFunctions.js"></script>
        <script type="text/javascript">
            //Put your JavaScript code here.
            // In order to show item changes in the grid
            function refreshGrid(arg) {
                if (!arg) {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("");
                }
                else {
                    $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("new");
                }
            }
            function NewInvoiceRecord() {

                var w1 = window.open("ProfessionalInvoiceForm.aspx", "tck_nr1", "width=700, height=490,resizable=1");
                w1.focus();
            }
            function EditInvoiceRecord(id) {
                var w2 = window.open("ProfessionalInvoiceForm.aspx?InvoiceId=" + id, "tck_er1", "width=700, height=490,resizable=1");
                w2.focus();
            }
            function reportInvoice(invoice) {
                var w1 = window.open("RptView.aspx?Report=professionalinvoice"
                                   + "&Invoice=" + invoice
                                   , "RTICKETS2", "width=800, height=600,resizable=1");
                w1.focus();
            }
//            function NewInvoiceRecordInTab() {
//                var w1 = window.open("InvoiceForm.aspx?CustomerId=" + gup('CustomerId')
//                                   , "tcktb_nr", "width=700, height=490,resizable=1");
//                w1.focus();
//            }
//            function EditInvoiceRecordInTab(id) {
//                var w2 = window.open("InvoiceForm.aspx?CustomerId=" + gup('CustomerId')
//                                   + "&InvoiceId=" + id, "tcktb_er", "width=700, height=490,resizable=1");
//                w2.focus();
//            }
            function CloseWindow() {
                window.close();
            }
            // To return selected values to caller 
            function Selection(v1, v2, v3, v4, type) {
                window.opener.refreshField(v1, v2, v3, v4, type);
                window.close();
                return false;
            }
        </script>
      </telerik:RadScriptBlock>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="True" RelativeTo="Element" 
                                 Position="TopCenter" meta:resourcekey="RadToolTipManager1Resource1" >
      </telerik:RadToolTipManager>
      <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                                   Skin="Office2007">
      </telerik:RadAjaxLoadingPanel>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                              onajaxrequest="RadAjaxManager1_AjaxRequest" 
                              meta:resourcekey="RadAjaxManager1Resource1">
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

      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" 
                            HorizontalAlign="NotSet" 
                            meta:resourcekey="RadAjaxPanel1Resource1" LoadingPanelID="RadAjaxLoadingPanel1">
        <%--    This is not necessary inside TAB--%>
        <div id="TitleArea" class="titleBar2" runat="server">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Facturas" 
                     meta:resourcekey="lblTitleResource1"></asp:Label>
        </div>
        
        <div id="GridArea" class="normalText" style="width:100%">
          <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" Width="100%" 
                           AllowPaging="True" AllowFilteringByColumn="True" Culture="es-ES" 
                           AllowSorting="True" ShowGroupPanel="True"
                           onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                           onneeddatasource="RadGrid1_NeedDataSource" GridLines="None"
                           meta:resourcekey="RadGrid1Resource1">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings AllowDragToGroup="True">
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                             DataKeyNames="InvoiceId">
              <CommandItemSettings ExportToPdfText="Export to Pdf" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
              </RowIndicatorColumn>
              <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
              </ExpandCollapseColumn>
              <Columns>
                <telerik:GridBoundColumn DataField="InvoiceId" DataType="System.Int32" 
                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                         HeaderText="ID" 
                                         meta:resourceKey="GridBoundColumnResource1" ReadOnly="True" 
                                         SortExpression="InvoiceId" UniqueName="InvoiceId">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Serial" 
                                         FilterControlToolTip="Filtrar por serie" FilterImageToolTip="Filtro"
                                         HeaderText="Serie" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="Professional.InvoiceSerial" UniqueName="Professional.InvoiceSerial">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Year" 
                                         FilterControlToolTip="Filtrar por año" FilterImageToolTip="Filtro"
                                         HeaderText="Año" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="Year" UniqueName="Year">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="InvoiceNumber" DataFormatString="{0:000000}"
                                         FilterControlToolTip="Filtrar por número" FilterImageToolTip="Filtro"
                                         HeaderText="Num. Factura" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="InvoiceNumber" UniqueName="InvoiceNumber">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="InvoiceDate" 
                                         FilterControlToolTip="Filtrar por fecha" FilterImageToolTip="Filtro"
                                         HeaderText="Fecha factura" DataFormatString="{0:dd/MM/yyyy}" 
                                         meta:resourceKey="GridBoundColumnResource2" ReadOnly="True" 
                                         SortExpression="InvoiceDate" UniqueName="InvoiceDate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Professional.ComercialName" 
                                         FilterControlToolTip="Filtrar por profesional" FilterImageToolTip="Filtro"
                                         HeaderText="Profesional" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="Professional.ComercialName" UniqueName="Professional.ComercialName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Amount" DataType="System.Decimal" DataFormatString="{0:C}"
                                         FilterControlToolTip="Filtrar por importe" FilterImageToolTip="Filtro"
                                         HeaderText="Total"
                                         ReadOnly="True" SortExpression="Total" 
                                         UniqueName="Total">
                  <HeaderStyle HorizontalAlign="Right" />
                  <ItemStyle HorizontalAlign="Right" />
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn AllowFiltering="False" 
                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                            meta:resourceKey="GridTemplateColumnResource1" UniqueName="Template">
                  <ItemTemplate>
                    <asp:ImageButton ID="Select" runat="server" 
                                     ImageUrl="~/images/document_gear_16.png" meta:resourceKey="SelectResource1" 
                                     ToolTip="Seleccionar este registro y volver con su información" />
                    <asp:ImageButton ID="Edit" runat="server" 
                                     ImageUrl="~/images/document_edit_16.png" meta:resourceKey="EditResource1" 
                                     ToolTip="Editar este registro" />
                    <asp:ImageButton ID="Pay" runat="server" Visible="false" 
                                     ImageUrl="~/images/currency_euro_16.png" meta:resourceKey="PayResource1" 
                                     ToolTip="Cobrar este ticket" />
                    <asp:ImageButton ID="Delete" runat="server" 
                                     ImageUrl="~/images/document_delete_16.png" meta:resourceKey="DeleteResource1" 
                                     ToolTip="Eliminar este registro" />
                    <asp:ImageButton ID="Print" runat="server" 
                                     ImageUrl="~/images/printer.png" meta:resourceKey="PrintResource1" 
                                     ToolTip="Imprimir este ticket" />
                  </ItemTemplate>
                </telerik:GridTemplateColumn>
              </Columns>
              <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
              </EditFormSettings>
              <CommandItemTemplate>
                <div ID="ButtonAdd" style="padding:2px;">
                  <asp:ImageButton ID="New" runat="server" ImageUrl="~/images/document_add.png" 
                                   meta:resourceKey="NewResource1" OnClientClick="NewInvoiceRecord();" 
                                   ToolTip="Añadir un nuevo registro" />
                  <asp:ImageButton ID="Exit" runat="server" ImageUrl="~/images/document_out.png" 
                                   meta:resourceKey="ExitResource1" OnClientClick="CloseWindow();" 
                                   ToolTip="Salir sin cambios" />
                </div>
              </CommandItemTemplate>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Office2007">
            </HeaderContextMenu>
          </telerik:RadGrid>
        </div>
        <div id="Separator">
          &nbsp;
        </div>
        <div id="Messages" class="messageText" style="width:100%">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes" 
                     meta:resourcekey="lblMessageResource1"></asp:Label>
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>

