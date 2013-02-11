<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptProfessionalInvoicesForm.aspx.cs" Inherits="AriCliWeb.RptProfessionalInvoicesForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
      Informe de facturas de profesionales
    </title>
    <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
    <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
          /* Line 1 */
          #TitleArea
          {
              z-index: 1;
              left: 5px;
              top: 0px;
              position: absolute;
              height: 19px;
              width: 400px;
          }
          /* Line 2 */
          #FromDate
          {
              z-index: 1;
              left: 9px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 154px;
          }
          #ToDate
          {
              z-index: 1;
              left: 252px;
              top: 40px;
              position: absolute;
              height: 44px;
              width: 154px;
          }
          #Professional
          {
              z-index: 1;
              left: 10px;
              top: 100px;
              position: absolute;
              height: 44px;
              width: 154px;
          }
          /* Line 3 */
          #Message
          {
              z-index: 1;
              left: 6px;
              top: 149px;
              position: absolute;
              height: 31px;
              width: 403px;
          }
          /* Line 4 */
          #Buttons
          {
              z-index: 1;
              left: 6px;
              top: 194px;
              position: absolute;
              height: 26px;
              width: 403px;
          }
          #Insurance
          {
              z-index: 1;
              left: 15px;
              top: 93px;
              position: absolute;
              height: 44px;
              width: 223px;
          }
          #Type
          {
              z-index: 1;
              left: 251px;
              top: 92px;
              position: absolute;
              height: 44px;
              width: 159px;
          }
            .multipleRowsColumns .rcbItem,
            .multipleRowsColumns .rcbHovered
            {
                float:left;
                margin:0 1px;
                min-height:13px;
                overflow:hidden;
                padding:2px 19px 2px 6px;
                width:200px;
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
      <script type="text/javascript" src="GeneralFormFunctions.js"></script>
      <script type="text/javascript" src="ReportFunctions.js"></script>
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>
      <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
      </telerik:RadSkinManager>
      <telerik:RadInputManager ID="RadInputManager1" runat="server">
        <telerik:TextBoxSetting Validation-IsRequired="true">
          <TargetControls>
            <telerik:TargetInput ControlID="txtFromDate" />
          </TargetControls>
        </telerik:TextBoxSetting>
      </telerik:RadInputManager>
      <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                 AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
      </telerik:RadToolTipManager>
      <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="210px" 
                            Width="420px" 
                            style="z-index: 1; left: 0px; top:0px; position: absolute; height: 231px; width: 420px">

        <%--  Line 1 --%>
        <div id="TitleArea" class="titleBar2">
          <img alt="minilogo" src="images/mini_logo.png" align="middle" />
          <asp:Label ID="lblTitle" runat="server" Text="Informe de facturas de profesionales"></asp:Label>
        </div>
        <%--  Line 2 --%>
        <div id="FromDate" class="normalText">
          <asp:Label ID="lblFromDate" runat="server" Text="Desde fecha:" 
                     ToolTip="Fecha inicial para el informe"></asp:Label>
          <br />
          <telerik:RadDatePicker ID="rddpFromDate" runat="server" ToolTip="Seleccionar fecha">
          </telerik:RadDatePicker>
        </div>
        <div id="ToDate" class="normalText">
          <asp:Label ID="lblToDate" runat="server" Text="Hasta fecha:" 
                     ToolTip="Fecha final para el informe"></asp:Label>
          <br />
          <telerik:RadDatePicker ID="rddpToDate" runat="server" ToolTip="Seleccionar fecha">
          </telerik:RadDatePicker>
        </div>
        <%--  Line 3 --%>
        <div id="Professional" class="normalText">
            <asp:Label ID="lblProf" runat="server" Text="Profesional:"></asp:Label>
            <telerik:RadComboBox ID="cmbprof" runat="server"  EnableVirtualScrolling="True" ZIndex="100002"
                                       MarkFirstMatch="true" AllowCustomText="true" EnableScreenBoundaryDetection="false"
                                       Width="400px" ExpandDirection="Down" Height="120px">
            </telerik:RadComboBox>
        </div>
        <%--  Line 4 --%>
        <div id="Message" class="messageText">
          <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
        </div>
        <%--  Line 5 --%>
        <div id="Buttons" class="buttonsFomat">
          <asp:ImageButton ID="btnAccept" runat="server" 
                           ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Ver informe" />
          &nbsp;
          <asp:ImageButton ID="btnCancel" runat="server" 
                           ImageUrl="~/images/document_out.png" CausesValidation="False" 
                           onclick="btnCancel_Click" ToolTip="Salir" />
        </div>

      </telerik:RadAjaxPanel>
    </form>
  </body>
</html>
