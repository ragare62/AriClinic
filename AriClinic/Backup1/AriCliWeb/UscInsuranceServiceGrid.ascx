<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscInsuranceServiceGrid.ascx.cs" Inherits="AriCliWeb.UscInsuranceServiceGrid" %>
<link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
<div id="GridArea" class="normalText" style="width:100%">
  <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" 
                   AllowPaging="True" AllowFilteringByColumn="True" 
                   AllowSorting="True" ShowGroupPanel="false"
                   onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                   onneeddatasource="RadGrid1_NeedDataSource" GridLines="None"
                   meta:resourcekey="RadGrid1Resource1">
    <GroupingSettings CaseSensitive="False" />
    <ClientSettings AllowDragToGroup="False">
    </ClientSettings>
    <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" 
                     DataKeyNames="InsuranceServiceId">
      <CommandItemSettings ExportToPdfText="Export to Pdf" />
      <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
      </RowIndicatorColumn>
      <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
      </ExpandCollapseColumn>
      <Columns>
        <telerik:GridBoundColumn DataField="InsuranceServiceId" DataType="System.Int32" 
                                 FilterControlToolTip="Filtrar por ID" FilterImageToolTip="Filtro"
                                 HeaderText="ID" 
                                 ReadOnly="True" 
                                 SortExpression="InsuranceServiceId" UniqueName="InsuranceServiceId">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Service.Name" 
                                 FilterControlToolTip="Filtrar por servicio" FilterImageToolTip="Filtro"
                                 HeaderText="Servicio" 
                                 ReadOnly="True" 
                                 SortExpression="Service.Name" UniqueName="Service.Name">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Price" DataType="System.Decimal" DataFormatString="{0:C}"
                                 FilterControlToolTip="Filtrar por precio" FilterImageToolTip="Filtro"
                                 HeaderText="Precio"
                                 ReadOnly="True" SortExpression="Price" 
                                 UniqueName="Price">
          <HeaderStyle HorizontalAlign="Right" />
          <ItemStyle HorizontalAlign="Right" />
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn AllowFiltering="False" 
                                    FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                    UniqueName="Template">
          <ItemTemplate>
            <asp:ImageButton ID="Select" runat="server" 
                             ImageUrl="~/images/document_gear_16.png"
                             ToolTip="Seleccionar este registro y volver con su información" />
            <asp:ImageButton ID="Edit" runat="server" 
                             ImageUrl="~/images/document_edit_16.png"
                             ToolTip="Editar este registro" />
            <asp:ImageButton ID="Delete" runat="server" 
                             ImageUrl="~/images/document_delete_16.png"
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
                           OnClientClick="NewInsuranceServiceRecord();" 
                           ToolTip="Añadir un nuevo registro" />
          <asp:ImageButton ID="Exit" runat="server" ImageUrl="~/images/document_out.png" 
                           OnClientClick="CloseWindow();" 
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