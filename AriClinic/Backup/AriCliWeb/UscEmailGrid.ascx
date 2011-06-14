<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscEmailGrid.ascx.cs" Inherits="AriCliWeb.UscEmailGrid" %>
<link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
<div id="EmailGridArea">
  <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" Width="100%" 
                   AllowPaging="true" PageSize="3" 
                   onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                   onneeddatasource="RadGrid1_NeedDataSource" Height="100%" >
    <MasterTableView AutoGenerateColumns="false" datakeynames="EmailId" CommandItemDisplay="Top">
      <Columns>
        <telerik:GridBoundColumn DataField="EmailId" DataType="System.Int32" 
                                 HeaderText="ID" ReadOnly="true" Visible="false" 
                                 UniqueName="EmailId" SortExpression="EmailId"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Type" DataType="System.String"
                                 HeaderText="Tipo" ReadOnly="true" Visible="false" 
                                 UniqueName="Type" SortExpression="Type"></telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Url" DataType="System.String"
                                 HeaderText="Correo electrónico" ReadOnly="true" Visible="true" 
                                 UniqueName="Url" SortExpression="Url"></telerik:GridBoundColumn>
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
                           OnClientClick="NewEmailRecord();" />
        </div>
      </CommandItemTemplate>
    </MasterTableView>
  </telerik:RadGrid>
</div>
