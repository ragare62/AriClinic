<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketGrid.aspx.cs" Inherits="TicketGrid" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Tickets
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    <link href="dialog_box.css" rel="Stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico"/>
  </head>
  <body id="content">
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
        <script type="text/javascript" src="dialog_box.js"></script>
        <script type="text/javascript">
          //Put your JavaScript code here.
          // In order to show item changes in the grid
          function refreshGrid(arg)
          {
              //alert("Hello from refreshGrid");
              if (!arg)
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("");
              }
              else
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("new");
              }
          }
          function NewTicketRecord()
          {
              
              var w1 = window.open("TicketForm.aspx", "tck_nr1", "width=900, height=600,resizable=1");
              w1.focus();
          }
          function EditTicketRecord(id)
          {
              var w2 = window.open("TicketForm.aspx?TicketId=" + id, "tck_er1", "width=900, height=600,resizable=1");
              w2.focus();
          }
          function NewTicketRecordInTab()
          {
              var w1 = window.open("TicketForm.aspx?CustomerId=" + gup('CustomerId')
                                   , "tcktb_nr", "width=750, height=600,resizable=1");
              w1.focus();
          }
          function EditTicketRecordInTab(id)
          {
              var w2 = window.open("TicketForm.aspx?CustomerId=" + gup('CustomerId')
                                   + "&TicketId=" + id, "tcktb_er", "width=900, height=600,resizable=1");
              w2.focus();
          }

          function NewTicketRecordServiceNote(id) {
              var w1 = window.open("TicketForm.aspx?ServiceNoteId=" + id
                                   , "sntcktb_nr", "width=900, height=600,resizable=1");
              w1.focus();
          }
          function EditTicketRecordServiceNote(id, id2) {
              var w2 = window.open("TicketForm.aspx?ServiceNoteId=" + id
                                   + "&TicketId=" + id2, "sntcktb_er", "width=900, height=600,resizable=1");
              w2.focus();
          } 




          function NewAnestheticTicketRecord()
          {
              var w1 = window.open("AnestheticTicketForm.aspx", "atck_nr1", "width=720, height=520,resizable=1");
              w1.focus();
          }
          function EditAnestheticTicketRecord(id)
          {
              var w2 = window.open("AnestheticTicketForm.aspx?TicketId=" + id, "atck_er1", "width=720, height=520,resizable=1");
              w2.focus();
          }
          function NewAnestheticTicketRecordInTab()
          {
              var w1 = window.open("AnestheticTicketForm.aspx?CustomerId=" + gup('CustomerId')
                                   , "atcktb_nr", "width=720, height=520,resizable=1");
              w1.focus();
          }
          function EditAnestheticTicketRecordInTab(id)
          {
              var w2 = window.open("AnestheticTicketForm.aspx?CustomerId=" + gup('CustomerId')
                                   + "&AnestheticTicketId=" + id, "atcktb_er", "width=720, height=520,resizable=1");
              w2.focus();
          }

          function NewAnestheticTicketRecordServiceNote(id) {
              var w1 = window.open("AnestheticTicketForm.aspx?AnestheticServiceNoteId=" + id
                                   , "atcktb_nr", "width=720, height=520,resizable=1");
              w1.focus();
          }
          function EditAnestheticTicketRecordServiceNote(id, id2) {
              var w2 = window.open("AnestheticTicketForm.aspx?AnestheticServiceNoteId=" + id
                                   + "&AnestheticTicketId=" + id2, "atcktb_er", "width=720, height=520,resizable=1");
              w2.focus();
          }

          function OpenPaymentForm(id) {
              var w2 = window.open("PaymentForm.aspx?TicketId=" + id
            , "pymn", "width=450, height=310,resizable=1");
              w2.focus();
          }

          function reportTicket(idTicket) {
              var w1 = window.open("RptView.aspx?Report=ticket"
                         + "&idTicket=" + idTicket
                         , "RTICKETS2", "width=800, height=600,resizable=1");
              w1.focus();
          }

          function CloseWindow()
          {
              window.close();
          }
          // To return selected values to caller 
          function Selection(v1, v2, v3, v4, type)
          {
              window.opener.refreshField(v1, v2, v3, v4, type);
              window.close();
              return false;
          }
        </script>
        <script type="text/javascript">
          function ariDialog(title, message, type, modal, width, height)
          {
              showDialog(title, message, type, modal, width, height);
              setTimeout("ObtainSelected()", 100);
          }

          function ObtainSelected(tag)
          {
              if (DLGRESULT == 0)
                  setTimeout("ObtainSelected()", 100); // continue asking
              else if (DLGRESULT == 1) // accept
              {
                  //process value
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("yes");
              }
              else //cancel;
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("no");
              }
              return;
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
          <asp:Label ID="lblTitle" runat="server" Text="Tickets" 
                     meta:resourcekey="lblTitleResource1"></asp:Label>
        </div>
        <div id="ChekcArea" class="normalText" style="width:100%">
            <asp:CheckBox ID="chkPaid" runat="server" Text="S�lo no pagados" 
                AutoPostBack="True" Checked="True" oncheckedchanged="chkPaid_CheckedChanged" />
        </div>
        <div id="GridArea" class="normalText" style="width:100%">
          <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" Width="100%" 
                           AllowPaging="True" Culture="es-ES" AllowFilteringByColumn="true" PageSize="15" 
                           AllowSorting="True" ShowGroupPanel="True" AllowMultiRowSelection="true"
                           onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                           onneeddatasource="RadGrid1_NeedDataSource" GridLines="None"
                           meta:resourcekey="RadGrid1Resource1">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings AllowDragToGroup="True">
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                             DataKeyNames="TicketId">
              <CommandItemSettings ExportToPdfText="Export to Pdf" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
              </RowIndicatorColumn>
              <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
              </ExpandCollapseColumn>
              <Columns>
                <telerik:GridBoundColumn DataField="TicketId" DataType="System.Int32" 
                                         FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                         HeaderText="ID" 
                                         meta:resourceKey="GridBoundColumnResource1" ReadOnly="True" 
                                         SortExpression="TicketId" UniqueName="TicketId">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TicketDate" 
                                         FilterControlToolTip="" FilterImageToolTip="Filtro"
                                         HeaderText="Fecha ticket" DataFormatString="{0:dd/MM/yyyy}" 
                                         meta:resourceKey="GridBoundColumnResource2" ReadOnly="True" 
                                         SortExpression="TicketDate" UniqueName="TicketDate">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Policy.Customer.FullName" 
                                         FilterControlToolTip="Filtrar por cliente" FilterImageToolTip="Filtro"
                                         HeaderText="Paciente" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="Policy.Customer.FullName" UniqueName="Policy.Customer.FullName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Clinic.Name" 
                                         FilterControlToolTip="Filtrar por cl�nica" FilterImageToolTip="Filtro"
                                         HeaderText="Cl�nica" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="Clinic.Name" UniqueName="Clinic.Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Policy.Insurance.Name" 
                                         FilterControlToolTip="Filtrar por paciente" FilterImageToolTip="Filtro"
                                         HeaderText="Aseguradora" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="Policy.Insurance.Name" UniqueName="Policy.Insurance.Name">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Policy.PolicyNumber"
                                         FilterControlToolTip="Filtrar por n�mero de p�liza" FilterImageToolTip="Filtro"
                                         HeaderText="N�mero de p�liza" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="PolicyNumber" UniqueName="PolicyNumber">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn DataField="Policy.BeginDate" 
                                         FilterControlToolTip="Filtrar por fecha inicio" FilterImageToolTip="Filtro"
                                         HeaderText="Fecha inicio" DataFormatString="{0:dd/MM/yyyy}" 
                                         meta:resourceKey="GridBoundColumnResource4" ReadOnly="True" 
                                         SortExpression="Policy.BeginDate" UniqueName="Policy.BeginDate" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Policy.EndDate" 
                                         FilterControlToolTip="Filtrar por fecha inicio" FilterImageToolTip="Filtro"
                                         HeaderText="Fecha fin" DataFormatString="{0:dd/MM/yyyy}" 
                                         meta:resourceKey="GridBoundColumnResource4" ReadOnly="True" 
                                         SortExpression="Policy.EndDate" UniqueName="Policy.EndDate" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Description" 
                                         FilterControlToolTip="Filtrar por paciente" FilterImageToolTip="Filtro"
                                         HeaderText="Descripci�n" 
                                         meta:resourceKey="GridBoundColumnResource3" ReadOnly="True" 
                                         SortExpression="Description" UniqueName="Description">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Amount" DataType="System.Decimal" DataFormatString="{0:C}"
                                         FilterControlToolTip="Filtrar por importe" FilterImageToolTip="Filtro"
                                         HeaderText="Importe"
                                         ReadOnly="True" SortExpression="Amount" 
                                         UniqueName="Amount">
                  <HeaderStyle HorizontalAlign="Right" />
                  <ItemStyle HorizontalAlign="Right" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Paid" DataType="System.Decimal" DataFormatString="{0:C}"
                                         FilterControlToolTip="Filtrar por pago" FilterImageToolTip="Filtro"
                                         HeaderText="Pagado"
                                         ReadOnly="True" SortExpression="Paid" 
                                         UniqueName="Paid">
                  <HeaderStyle HorizontalAlign="Right" />
                  <ItemStyle HorizontalAlign="Right" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Checked" 
                                         FilterControlToolTip="Filtrar por verificaci�n" FilterImageToolTip="Filtro"
                                         HeaderText="Verificado" 
                                         meta:resourceKey="GridBoundColumnResource4" ReadOnly="True" 
                                         SortExpression="Checked" UniqueName="Checked">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn AllowFiltering="False" 
                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                            meta:resourceKey="GridTemplateColumnResource1" UniqueName="Template">
                  <ItemTemplate>
                    <asp:ImageButton ID="Select" runat="server" 
                                     ImageUrl="~/images/document_gear_16.png" meta:resourceKey="SelectResource1" 
                                     ToolTip="Seleccionar este registro y volver con su informaci�n" />
                    <asp:ImageButton ID="Edit" runat="server" 
                                     ImageUrl="~/images/document_edit_16.png" meta:resourceKey="EditResource1" 
                                     ToolTip="Editar este registro" />
                    <asp:ImageButton ID="Delete" runat="server" 
                                     ImageUrl="~/images/document_delete_16.png" meta:resourceKey="DeleteResource1" 
                                     ToolTip="Eliminar este registro" />
                    <asp:ImageButton ID="Pay" runat="server" 
                                     ImageUrl="~/images/currency_euro_16.png" meta:resourceKey="PayResource1" 
                                     ToolTip="Cobrar este ticket" />
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
                                   meta:resourceKey="NewResource1" OnClientClick="NewTicketRecord();" 
                                   ToolTip="A�adir un nuevo registro" />
                  <asp:ImageButton ID="NewAnesthetic" runat="server" ImageUrl="~/images/form_blue.png" 
                                   meta:resourceKey="NewResource1" OnClientClick="NewAnestheticTicketRecord();" 
                                   ToolTip="A�adir un nuevo ticket anest�sico" />
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
