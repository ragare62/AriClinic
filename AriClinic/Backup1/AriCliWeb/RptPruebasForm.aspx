<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptPruebasForm.aspx.cs" Inherits="AriCliWeb.RptPruebasForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pruebas informes</title>
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
    #contenido
          {
              z-index: 1;
              left: 5px;
              top: 0px;
              position: absolute;
              width: 400px;
          }
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="componnetes">
    <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
        <Scripts>
          <%--Needed for JavaScript IntelliSense in VS2010--%>
          <%--For VS2008 replace RadScriptManager with ScriptManager--%>
          <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
          <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
          <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
        </Scripts>
      </telerik:RadScriptManager>
      <script type="text/javascript" src="GeneralFormFunctions.js"></script>
      <script type="text/javascript" src="ReportFunctions.js"></script>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
    </div>
    <div id="contenido" class="normalText">
        <div id="" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Pruebas informes"></asp:Label>
        </div>
        <div>
        <br />
            <asp:Label ID="Label1" runat="server" Text="Id Ticket: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtIdTicket" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAccept" runat="server" Text="Ver informe" onclick="Button1_Click" />
        </div>
        <div>
        <br />
            <asp:Label ID="Label2" runat="server" Text="Id Nota Servicio: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtServNote" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnServNote" runat="server" Text="Ver informe" 
                onclick="btnServNote_Click"  />
        </div>
        <div>
        <br />
            <asp:Label ID="Label3" runat="server" Text="Id Nota Anestésico: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAnesNote" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAnesNote" runat="server" Text="Ver informe" 
                onclick="btnAnesNote_Click"/>
        </div>
        <div>
        <br />
            <asp:Label ID="Label4" runat="server" Text="Factura: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtInvoice" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnInvoice" runat="server" Text="Ver informe" 
                onclick="BtnInvoice_Click" />
        </div>
        <div>
        <br />
            <asp:Label ID="Label5" runat="server" Text="Desde: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <telerik:RadDatePicker ID="pikdesde" runat="server">
            </telerik:RadDatePicker>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Hasta: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <telerik:RadDatePicker ID="pikhasta" runat="server">
            </telerik:RadDatePicker>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnparaminvoice" runat="server" Text="Ver informe" 
                onclick="btnparaminvoice_Click" />
        </div>
    </div>
    </form>
</body>
</html>
