<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogGrid.aspx.cs" Inherits="LogGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
     Log de accesos
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
      <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
      </telerik:RadWindowManager>
      <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

      </telerik:RadScriptBlock>

      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                              onajaxrequest="RadAjaxManager1_AjaxRequest">
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
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="600" 
                            Width="100%">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          
          <asp:Label ID="lblTitle" runat="server" Text="Log de accesos"></asp:Label>
        </div>
        <div id="GridArea" class="normalText">
          <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" Width="100%" 
                           AllowPaging="true" PageSize="15"  Height="100%" OnNeedDataSource="RadGrid1_NeedDataSource1">
            <MasterTableView AutoGenerateColumns="false" datakeynames="LogId">
              <Columns>
                <telerik:GridBoundColumn DataField="LogId" DataType="System.Int32" 
                                         HeaderText="ID" ReadOnly="true" Visible="true" 
                                         UniqueName="LogId" SortExpression="LogId"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Stamp" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}" 
                                         HeaderText="Fecha / Hora" ReadOnly="true" Visible="true" 
                                         UniqueName="Stamp" SortExpression="Stamp"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="User.Name" DataType="System.String"
                                         HeaderText="Usuario" ReadOnly="true" Visible="true" 
                                         UniqueName="User.Name" SortExpression="User.Name"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="RemoteAddress" DataType="System.String"
                                         HeaderText="Desde IP" ReadOnly="true" Visible="true" 
                                         UniqueName="RemoteAddress" SortExpression="RemoteAddress"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Action" DataType="System.String"
                                         HeaderText="Acción" ReadOnly="true" Visible="true" 
                                         UniqueName="Action" SortExpression="Action"></telerik:GridBoundColumn>
              </Columns>
            </MasterTableView>
          </telerik:RadGrid>
        </div>
        <div id="Messages" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes"></asp:Label>
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
