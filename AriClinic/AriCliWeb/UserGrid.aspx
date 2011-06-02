<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserGrid.aspx.cs" Inherits="UserGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>
      Usuarios
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
<style type="text/css">
#TitleArea
{
z-index: 1;
left: 5px;
top: 0px;
position: absolute;
height: 19px;
width: 441px;
}
#GridArea
{
z-index: 1;
left: 7px;
top: 34px;
position: absolute;
height: 291px;
width: 441px;
}
#Messages
{
z-index: 1;
left: 6px;
top: 336px;
position: absolute;
height: 34px;
width: 441px;
}
.style1
{
width: 27px;
height: 20px;
}
</style>
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
        <script type="text/javascript">
          //Replace old radconfirm with a changed version.   
          var oldConfirm = radconfirm;
          //TELERIK
          //window.radconfirm = function(text, mozEvent)
          //We will change the radconfirm function so it takes all the original radconfirm attributes
          window.radconfirm = function (text, mozEvent, oWidth, oHeight, callerObj, oTitle)
          {
              var ev = mozEvent ? mozEvent : window.event; //Moz support requires passing the event argument manually   
              //Cancel the event   
              ev.cancelBubble = true;
              ev.returnValue = false;
              if (ev.stopPropagation) ev.stopPropagation();
              if (ev.preventDefault) ev.preventDefault();

              //Determine who is the caller   
              var callerObj = ev.srcElement ? ev.srcElement : ev.target;

              //Call the original radconfirm and pass it all necessary parameters   
              if (callerObj)
              {
                  //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again.   
                  var callBackFn = function (arg)
                  {
                      if (arg)
                      {
                          callerObj["onclick"] = "";
                          if (callerObj.click) callerObj.click(); //Works fine every time in IE, but does not work for links in Moz   
                          else if (callerObj.tagName == "A") //We assume it is a link button!   
                          {
                              try
                              {
                                  eval(callerObj.href)
                              }
                              catch (e)
                              {
                              }
                          }
                      }
                  }
                  //TELERIK
                  //oldConfirm(text, callBackFn, 300, 100, null, null);       
                  //We will need to modify the oldconfirm as well                
                  oldConfirm(text, callBackFn, oWidth, oHeight, callerObj, oTitle);
              }
              return false;
          }
        </script>
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
          function NewUserRecord()
          {
              var w1 = window.open("UserForm.aspx", null, "width=450, height=360,resizable=1");
              w1.focus();
          }
          function EditUserRecord(id)
          {
              var w1 = window.open("UserForm.aspx?UserId=" + id, null, "width=450, height=360,resizable=1");
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
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="350px" 
                            Width="450px" 
                            style="z-index: 1; left: 0px; top: 0px; position: absolute; height: 371px; width: 459px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          
          <asp:Label ID="lblTitle" runat="server" Text="Usuarios"></asp:Label>
        </div>
        <div id="GridArea" class="normalText">
          <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007" Width="436px" 
                           AllowPaging="true" PageSize="6" 
                           onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                           onneeddatasource="RadGrid1_NeedDataSource" Height="282px">
            <MasterTableView AutoGenerateColumns="false" datakeynames="UserId" CommandItemDisplay="Top">
              <Columns>
                <telerik:GridBoundColumn DataField="UserId" DataType="System.Int32" 
                                         HeaderText="ID" ReadOnly="true" Visible="true" 
                                         UniqueName="UserId" SortExpression="UserId"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Name" DataType="System.String"
                                         HeaderText="Usuario" ReadOnly="true" Visible="true" 
                                         UniqueName="Name" SortExpression="Name"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Login" DataType="System.String"
                                         HeaderText="Login" ReadOnly="true" Visible="true" 
                                         UniqueName="Login" SortExpression="Login"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="UserGroup.Name" DataType="System.String"
                                         HeaderText="Grupo" ReadOnly="true" Visible="true" 
                                         UniqueName="UserGroup.Name" SortExpression="UserGroup.Name"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn UniqueName="Template" AllowFiltering="false" HeaderText="Acciones" >
                  <ItemTemplate>
                    <asp:ImageButton ID="Select" runat="server" ImageUrl="~/images/document_gear_16.png" 
                                     ToolTip="Seleccionar este registro y volver con su información" />
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
                                   OnClientClick="NewUserRecord();" />
                  <asp:ImageButton ID="Exit" runat="server" ImageUrl="~/images/document_out.png" 
                                   ToolTip="Salir sin cambios"
                                   OnClientClick="CloseWindow();" />
                </div>
              </CommandItemTemplate>
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
