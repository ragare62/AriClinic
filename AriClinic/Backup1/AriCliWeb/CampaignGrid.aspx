<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CampaignGrid.aspx.cs" Inherits="CampaignGrid" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Campa�as de marketing
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
        <script type="text/javascript">
          //Put your JavaScript code here.
          // In order to show item changes in the grid
          function refreshGrid(arg)
          {
              //alert("Hello from refreshGrid");
              if (!arg)
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("Rebind");
              }
              else
              {
                  $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RebindAndNavigate");
              }
          }
          function NewCampaignRecord()
          {
              var w1 = window.open("CampaignForm.aspx", null, "width=450, height=280,resizable=1");
              w1.focus();
          }
          function EditCampaignRecord(id)
          {
              var w2 = window.open("CampaignForm.aspx?CampaignId=" + id, null, "width=450, height=280,resizable=1");
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
          AutoTooltipify="true" RelativeTo="Element" Position="TopCenter" >
    </telerik:RadToolTipManager>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                              onajaxrequest="RadAjaxManager1_AjaxRequest" 
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
          HorizontalAlign="NotSet" meta:resourcekey="RadAjaxPanel1Resource1">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          
          <asp:Label ID="lblTitle" runat="server" Text="Campa�as de marketing" 
                meta:resourcekey="lblTitleResource1"></asp:Label>
        </div>
        <div id="GridArea" class="normalText" style="width:100%">
          <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007"
                           AllowPaging="True" PageSize="6" AllowFilteringByColumn="True" 
                           onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                           onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                meta:resourcekey="RadGrid1Resource1">
            <MasterTableView AutoGenerateColumns="False" datakeynames="CampaignId" 
                  CommandItemDisplay="Top">
                <CommandItemSettings ExportToPdfText="Export to Pdf" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="CampaignId" DataType="System.Int32" 
                        FilterControlAltText="Filter CampaignId column" HeaderText="ID" 
                        meta:resourcekey="GridBoundColumnResource1" ReadOnly="True" 
                        SortExpression="CampaignId" UniqueName="CampaignId">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" 
                        FilterControlAltText="Filter Name column" HeaderText="Campa�a" 
                        meta:resourcekey="GridBoundColumnResource2" ReadOnly="True" 
                        SortExpression="Name" UniqueName="Name">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StartDate" 
                        FilterControlAltText="Filter Name column" HeaderText="Fecha de inicio" 
                        meta:resourcekey="GridBoundColumnResource2" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" 
                        SortExpression="StartDate" UniqueName="StartDate">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EndDate" 
                        FilterControlAltText="Filter Name column" HeaderText="Fecha de fin" 
                        meta:resourcekey="GridBoundColumnResource2" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy}" 
                        SortExpression="EndDate" UniqueName="EndDate">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="False" 
                        FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                        meta:resourcekey="GridTemplateColumnResource1" UniqueName="Template">
                        <ItemTemplate>
                            <asp:ImageButton ID="Select" runat="server" 
                                ImageUrl="~/images/document_gear_16.png" meta:resourcekey="SelectResource1" 
                                ToolTip="Seleccionar este registro y volver con su informaci�n" />
                            <asp:ImageButton ID="Edit" runat="server" 
                                ImageUrl="~/images/document_edit_16.png" meta:resourcekey="EditResource1" 
                                ToolTip="Editar este registro" />
                            <asp:ImageButton ID="Delete" runat="server" 
                                ImageUrl="~/images/document_delete_16.png" meta:resourcekey="DeleteResource1" 
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
                            meta:resourcekey="NewResource1" OnClientClick="NewCampaignRecord();" 
                            ToolTip="A�adir un nuevo registro" />
                        <asp:ImageButton ID="Exit" runat="server" ImageUrl="~/images/document_out.png" 
                            meta:resourcekey="ExitResource1" OnClientClick="CloseWindow();" 
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
