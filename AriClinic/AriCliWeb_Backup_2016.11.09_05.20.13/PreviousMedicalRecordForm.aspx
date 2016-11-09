<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreviousMedicalRecordForm.aspx.cs" Inherits="PreviousMedicalRecordForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Historia clínica anterior
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
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
            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                <script type="text/javascript" src="GeneralFormFunctions.js">
                </script>
                <script type="text/javascript">
                    function noHaceNada() { }
                </script>
            </telerik:RadScriptBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        </telerik:RadWindowManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%">
                <div id="main-container" style="width:100%; height:500px">
                    <div id="TitleArea" class="titleBar2">
                        <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                        <asp:Label ID="lblTitle" runat="server" Text="Historial anterior"></asp:Label>
                    </div>
                    <div ID="ButtonsTop" class="buttonsFomat">
                        <asp:ImageButton ID="ImageButton1" runat="server" TabIndex="6"  
                                         ImageUrl="~/images/document_ok.png" OnClick="btnAccept_Click" ToolTip="Guardar" />

                    </div>
                    <div id="dvRadEditor">
                        <telerik:RadEditor ID="RadEditor1" runat="server" Width="100%" Height="500px" Skin="Office2007" 
                                           ToolsFile="~/Tools/ToolsFile.xml">
                        </telerik:RadEditor>
                    </div>
                    <div ID="Buttons" class="buttonsFomat">
                        <asp:ImageButton ID="btnAccept" runat="server" TabIndex="6"  
                                         ImageUrl="~/images/document_ok.png" OnClick="btnAccept_Click" ToolTip="Guardar" />

                    </div>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
