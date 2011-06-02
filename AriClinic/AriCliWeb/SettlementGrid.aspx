<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettlementGrid.aspx.cs" Inherits="SettelmentGrid" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Liquidaciones
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
              
              var w1 = window.open("TicketForm.aspx", "tck_nr1", "width=720, height=650,resizable=1");
              w1.focus();
          }
          function EditTicketRecord(id)
          {
              var w2 = window.open("TicketForm.aspx?TicketId=" + id, "tck_er1", "width=720, height=650,resizable=1");
              w2.focus();
          }
          function NewTicketRecordInTab()
          {
              var w1 = window.open("TicketForm.aspx?CustomerId=" + gup('CustomerId')
                                   , "tcktb_nr", "width=750, height=320,resizable=1");
              w1.focus();
          }
          function EditTicketRecordInTab(id)
          {
              var w2 = window.open("TicketForm.aspx?CustomerId=" + gup('CustomerId')
                                   + "&TicketId=" + id, "tcktb_er", "width=750, height=320,resizable=1");
              w2.focus();
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
          <asp:Label ID="lblTitle" runat="server" Text="Liquidaciones" 
                     meta:resourcekey="lblTitleResource1"></asp:Label>
        </div>
        <div id="Selection" class="normalText" style="width:100%">
          <asp:Label ID="lblFromDate" runat="server" Text="Desde Fecha: "></asp:Label>
          <telerik:RadDatePicker ID="rddpFromDate" runat="server">
          </telerik:RadDatePicker>
          &nbsp;
          <asp:Label ID="lblToDate" runat="server" Text="Hasta Fecha: "></asp:Label>
          <telerik:RadDatePicker ID="rddpToDate" runat="server">
          </telerik:RadDatePicker>
          &nbsp;
          <asp:Label ID="lblInsurance" runat="server" Text="Aseguradora: "></asp:Label>
          <telerik:RadComboBox ID="rdcbInsurance" runat="server">
          </telerik:RadComboBox>
          &nbsp;
          <asp:Label ID="lblType" runat="server" Text="Tipo: "></asp:Label>
          <telerik:RadComboBox ID="rdcbType" runat="server">
            <Items>
              <telerik:RadComboBoxItem runat="server" Text="No pagados" Value="NP" />
              <telerik:RadComboBoxItem runat="server" Text="Pagados" Value="P" />
            </Items>
          </telerik:RadComboBox>
          &nbsp;
          <asp:Button ID="btnSearch" runat="server" Text="Buscar" 
                      onclick="btnSearch_Click" />
        </div>
        <div id="GridArea" class="normalText" style="width:100%">
          <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" Width="100%" 
                           AllowPaging="True" AllowFilteringByColumn="True" Culture="es-ES" 
                           AllowSorting="True" ShowGroupPanel="True" AllowMultiRowSelection="true"
                           onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                           onneeddatasource="RadGrid1_NeedDataSource" GridLines="None"
                           meta:resourcekey="RadGrid1Resource1">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings AllowDragToGroup="True" Selecting-AllowRowSelect="true">
            </ClientSettings>
            <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                             DataKeyNames="TicketId">
              <CommandItemSettings ExportToPdfText="Export to Pdf" />
              <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
              </RowIndicatorColumn>
              <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
              </ExpandCollapseColumn>
              <Columns>
                <telerik:GridClientSelectColumn UniqueName="chkSelected"></telerik:GridClientSelectColumn>
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
                                         FilterControlToolTip="Filtrar por clínica" FilterImageToolTip="Filtro"
                                         HeaderText="Clínica" 
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
                                         FilterControlToolTip="Filtrar por número de póliza" FilterImageToolTip="Filtro"
                                         HeaderText="Número de póliza" 
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
                                         HeaderText="Descripción" 
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
                <telerik:GridBoundColumn DataField="Checked" Visible="false" 
                                         FilterControlToolTip="Filtrar por verificación" FilterImageToolTip="Filtro"
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
                                     ToolTip="Seleccionar este registro y volver con su información" />
                    <asp:ImageButton ID="Edit" runat="server" 
                                     ImageUrl="~/images/document_edit_16.png" meta:resourceKey="EditResource1" 
                                     ToolTip="Editar este registro" />
                    <asp:ImageButton ID="Delete" runat="server" 
                                     ImageUrl="~/images/document_delete_16.png" meta:resourceKey="DeleteResource1" 
                                     ToolTip="Eliminar este registro" />
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
        <div id="Actions" class="normalTextRight" style="width:100%">
          <asp:Label ID="lblClinic" runat="server" Text="Clinica de pago: " Visible="false"></asp:Label>
          <telerik:RadComboBox ID="rdcbClinic" runat="server" Visible="false">
          </telerik:RadComboBox>
          &nbsp;
          <asp:Label ID="lblPayDate" runat="server" Text="Fecha de pago: " Visible="false"></asp:Label>
          <telerik:RadDatePicker ID="rddpPayDate" runat="server" Visible="false">
          </telerik:RadDatePicker>
          &nbsp;
          <asp:Label ID="lblPaymentForm" runat="server" Text="Forma de pago: " Visible="false"></asp:Label>
          <telerik:RadComboBox ID="rdcbPayementForm" runat="server" Visible="false">
          </telerik:RadComboBox>
          &nbsp;
          <asp:Button ID="btnDo" runat="server" Text="Cobrar seleccionados" Visible="false" 
                      onclick="btnDo_Click" />
          &nbsp;
          <asp:Button ID="btnUnDo" runat="server" Text="Deshacer cobros" Visible="false" 
                onclick="btnUnDo_Click" />
        </div>
        <div id="Messages" class="messageText" style="width:100%">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes" 
                     meta:resourcekey="lblMessageResource1"></asp:Label>
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
