<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscTelephoneGrid.ascx.cs" Inherits="AriCliWeb.UscTelephoneGrid" %>
<link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
<div id="AddessGridArea">
  <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" Width="100%" 
                   AllowPaging="true" PageSize="3" 
                   onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                   onneeddatasource="RadGrid1_NeedDataSource" Height="100%" >
    <MasterTableView AutoGenerateColumns="false" datakeynames="TelephoneId" CommandItemDisplay="Top">
      <Columns>
        <telerik:GridBoundColumn DataField="TelephoneId" DataType="System.Int32" 
                                 HeaderText="ID" ReadOnly="true" Visible="false" 
                                 UniqueName="TelephoneId" SortExpression="TelephoneId"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Type" DataType="System.String"
                                 HeaderText="Tipo" ReadOnly="true" Visible="false" 
                                 UniqueName="Type" SortExpression="Type"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Number" DataType="System.String"
                                 HeaderText="Número" ReadOnly="true" Visible="true" 
                                 UniqueName="Number" SortExpression="Number"></telerik:GridBoundColumn>
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
                           OnClientClick="NewTelephoneRecord();" />
        </div>
      </CommandItemTemplate>
    </MasterTableView>
  </telerik:RadGrid>
</div>
