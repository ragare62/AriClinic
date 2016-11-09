<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscAddressGrid.ascx.cs" Inherits="AriCliWeb.UscAddressGrid" %>
<link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
<div id="AddessGridArea">
  <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" Width="100%" 
                   AllowPaging="true" PageSize="3" 
                   onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                   onneeddatasource="RadGrid1_NeedDataSource" Height="100%" >
    <MasterTableView AutoGenerateColumns="false" datakeynames="AddressId" CommandItemDisplay="Top">
      <Columns>
        <telerik:GridBoundColumn DataField="AddressId" DataType="System.Int32" 
                                 HeaderText="ID" ReadOnly="true" Visible="false" 
                                 UniqueName="AddressId" SortExpression="AddressId"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Type" DataType="System.String"
                                 HeaderText="Tipo" ReadOnly="true" Visible="false" 
                                 UniqueName="Type" SortExpression="Type"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Street" DataType="System.String"
                                 HeaderText="Direccion" ReadOnly="true" Visible="true" 
                                 UniqueName="Street" SortExpression="Street"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="PostCode" DataType="System.String"
                                 HeaderText="Cod.Postal" ReadOnly="true" Visible="true" 
                                 UniqueName="PostCode" SortExpression="PostalCode"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="City" DataType="System.String"
                                 HeaderText="Ciudad" ReadOnly="true" Visible="true" 
                                 UniqueName="City" SortExpression="City"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Province" DataType="System.String"
                                 HeaderText="Provincia" ReadOnly="true" Visible="true" 
                                 UniqueName="Province" SortExpression="Province"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Country" DataType="System.String"
                                 HeaderText="Pais" ReadOnly="true" Visible="true" 
                                 UniqueName="Country" SortExpression="Country"></telerik:GridBoundColumn>
        <telerik:GridTemplateColumn UniqueName="Template" AllowFiltering="false" HeaderText="Acciones" >
          <ItemTemplate>
            <asp:ImageButton ID="Edit" runat="server" ImageUrl="~/images/document_edit_16.png" 
                             ToolTip="Editar este registro" />
            <asp:ImageButton ID="Delete" runat="server" ImageUrl="~/images/document_delete_16.png" 
                             ToolTip="Eliminar este registro" />
          </ItemTemplate>                
        </telerik:GridTemplateColumn>
      </Columns>
      <CommandItemTemplate>
        <div id="ButtonAdd" style="padding:2px;">
          <asp:ImageButton ID="New" runat="server" ImageUrl="~/images/document_add.png" 
                           ToolTip="Añadir un nuevo registro"
                           OnClientClick="NewAddressRecord();" />
        </div>
      </CommandItemTemplate>
    </MasterTableView>
  </telerik:RadGrid>
</div>
