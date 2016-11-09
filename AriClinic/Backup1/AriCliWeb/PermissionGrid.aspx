<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissionGrid.aspx.cs" Inherits="PermissionGrid" %>
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
width: 540px;
}
#ListGridArea
{
z-index: 1;
left: 12px;
top: 86px;
position: absolute;
height: 271px;
width: 537px;
}
#SelectGroup
{
z-index: 1;
left: 10px;
top: 33px;
position: absolute;
height: 38px;
width: 537px;
}
#Messages
{
z-index: 1;
left: 12px;
top: 368px;
position: absolute;
height: 34px;
width: 540px;
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
          function EditPermissionRecord(id)
          {
              var w1 = window.open("PermissionForm.aspx?PermissionId=" + id, null, "width=450, height=440,resizable=1");
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
              <telerik:AjaxUpdatedControl ControlID="RadTreeList1" />
            </UpdatedControls>
          </telerik:AjaxSetting>
        </AjaxSettings>
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" 
                            style="z-index: 1; left: 0px; top: 0px; position: absolute; height: 394px; width: 558px">
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          
          <asp:Label ID="lblTitle" runat="server" Text="Permisos"></asp:Label>
        </div>
        <div id="SelectGroup" class="normalText">
          <asp:Label ID="lblSelectGroup" runat="server" Text="Grupo de usuarios: "></asp:Label>
          <br />
          <asp:DropDownList ID="ddlSelectGroup" runat="server" Height="23px" 
                            Width="446px" AutoPostBack="True" 
                            onselectedindexchanged="ddlSelectGroup_SelectedIndexChanged"></asp:DropDownList>
          &nbsp;
          <asp:ImageButton ID="ImageButton1" runat="server" 
                           OnClientClick="CloseWindow();" ToolTip="Salir cerrando la ventana" 
                           ImageUrl="~/images/document_out.png" />
        </div>
        <div id="ListGridArea" class="normalText">
          <telerik:RadTreeList ID="RadTreeList1" runat="server" AutoGenerateColumns="false" 
                               DataKeyNames="ProcessId" 
                               ParentDataKeyNames="ParentProcessId" AllowPaging="true" 
                               onitemcommand="RadTreeList1_ItemCommand" 
                               onitemdatabound="RadTreeList1_ItemDataBound" 
                               onneeddatasource="RadTreeList1_NeedDataSource">
            <Columns>
              <telerik:TreeListBoundColumn DataField="PermissionId" DataType="System.Int32" HeaderText="PerID" 
                                           Visible="false" UniqueName="PermissionId">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="ProcessId" DataType="System.Int32" HeaderText="ProID" 
                                           Visible="false" UniqueName="ProcessId">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="ParentProcessId" 
                                           DataType="System.Int32" HeaderText="PaProID" 
                                           Visible="false" UniqueName="ParentProcessID">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="Name" DataType="System.String" HeaderText="Proceso" UniqueName="Name" HeaderStyle-Width="30%">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="View" DataType="System.Boolean" HeaderText="Ver" UniqueName="View">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="Create" DataType="System.Boolean" HeaderText="Crear" UniqueName="Create">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="Modify" DataType="System.Boolean" HeaderText="Modificar" UniqueName="Modify">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListBoundColumn DataField="Execute" DataType="System.Boolean" HeaderText="Ejecutar" UniqueName="Execute">
              </telerik:TreeListBoundColumn>
              <telerik:TreeListTemplateColumn AllowSorting="false" UniqueName="TemplateEditColumn">
                <ItemTemplate>
                  <asp:ImageButton ID="Edit" runat="server" 
                                   ImageUrl="~/images/document_edit_16.png"  ToolTip="Editar estos registros"/>
                </ItemTemplate>
              </telerik:TreeListTemplateColumn>
            </Columns>
          </telerik:RadTreeList>
        </div>

        <div id="Messages" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes"></asp:Label>
        </div>
      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
