<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateViewForm.aspx.cs" Inherits="TemplateViewForm" %>

<%@ Register assembly="Telerik.ReportViewer.WebForms, Version=6.2.13.110, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" namespace="Telerik.ReportViewer.WebForms" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Visor de plantilla
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
        <link href="dialog_box.css" rel="Stylesheet" type="text/css" />
        <link rel="shortcut icon" type="image/x-icon" href="favicon.ico"/>
    </head>
    <body id="content">
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
            <telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
                <script type="text/javascript" src="GeneralFormFunctions.js"></script>
                <script type="text/javascript" src="dialog_box.js"></script>
                <script type="text/javascript">
                    function refreshField(v1, v2, v3, v4, type) {
                        var combo;
                        if (type) {
                            switch (type) {
                                case "Patient":
                                    combo = $find("<%= rdcPatient.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                                case "Professional":
                                    combo = $find("<%= rdcProfessional.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                            }
                        }
                    }
                    function loadCombo(combo, v1, v3) {
                        var items = combo.get_items();
                        items.clear();
                        var comboItem = new Telerik.Web.UI.RadComboBoxItem();
                        comboItem.set_text(v3);
                        comboItem.set_value(v1);
                        items.add(comboItem);
                        combo.commitChanges();
                        comboItem.select();
                    }
                    function parentReload(url) {
                        parent.open(url, "VISIT", "width=800, height=500,resizable=1");
                    }
                    function noHaceNada() {
                    }
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
            </telerik:RadSkinManager>
            <telerik:RadInputManager ID="RadInputManager1" runat="server">
                <telerik:TextBoxSetting Validation-IsRequired="true">
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtName" />
                    </TargetControls>
                    <Validation IsRequired="True"></Validation>
                </telerik:TextBoxSetting>
            </telerik:RadInputManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" >
                <div>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2">
                                <div id="TitleArea" class="titleBar2">
                                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                    <asp:Label ID="lblTitle" runat="server" Text="Visor de plantilla"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="Patient" class="normalText" style="padding:10px">
                                    <asp:Label ID="lblPatient" runat="server" Text="Paciente:" 
                                               ToolTip="Peciente a mostrar en plantilla (campo {0})"></asp:Label>
                                    <asp:ImageButton ID="btnPatient" runat="server" 
                                                     ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     ToolTip="Haga clic aquí para buscar un paciente" 
                                                     OnClientClick="searchPatient();" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcPatient" Height="100px" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." 
                                                         onitemsrequested="rdcPatient_ItemsRequested" ItemsPerRequest="10" 
                                                         Width="90%" >
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td>
                                <div id="Professional" class="normalText" style="padding:10px">
                                    <asp:Label ID="lblProfessional" runat="server" Text="Profesional:" 
                                               ToolTip="Profesional a mostrar en plantilla (Campo {1})"></asp:Label>
                                    <asp:ImageButton ID="btnProfessional" runat="server" CausesValidation="false" 
                                                     ImageUrl="~/images/search_mini.png" OnClientClick="searchProfessional();" 
                                                     ToolTip="Haga clic aquí para buscar un profesional" />
                                    <br />
                                    <telerik:RadComboBox ID="rdcProfessional" runat="server" 
                                                         EmptyMessage="Escriba aquí ..." EnableLoadOnDemand="true" 
                                                         EnableVirtualScrolling="true" Height="100px" ItemsPerRequest="10" 
                                                         onitemsrequested="rdcProfessional_ItemsRequested" ShowMoreResultsBox="true" 
                                                         Width="90%">
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Campo1" class="normalText">
                                    <asp:Label ID="lblCampo1" runat="server" Text="Campo 1" ToolTip="Campo a mostrar (Campo {2})"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtCampo1" runat="server" Width="90%"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Campo2" class="normalText">
                                    <asp:Label ID="lblCampo2" runat="server" Text="Campo 2" ToolTip="Campo a mostrar (Campo {3})"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtCampo2" runat="server" Width="90%"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Campo3" class="normalText">
                                    <asp:Label ID="lblCampo3" runat="server" Text="Campo 3" ToolTip="Campo a mostrar (Campo {4})"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtCampo3" runat="server" Width="90%"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Buttons" class="buttonsFomat">
                                    <asp:ImageButton ID="btnAccept" runat="server" 
                                                     ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                                     ToolTip="Guardar y salir" TabIndex="4" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCancel" runat="server" 
                                                     ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                                     onclick="btnCancel_Click" ToolTip="Salir sin guardar" TabIndex="5" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="ViewArea" class="normalText" style="width:100%; height:550px">
                                    <asp:Label ID="lblVisor" runat="server" Text="Vista previa"></asp:Label>
                                    <br />
                                    <telerik:ReportViewer runat="server" Skin="Office2007" ID="ReportViewer1" Width="100%" 
                                                          Height="600px" meta:resourcekey="ReportViewer1Resource1" ReportBookID="">
                                    </telerik:ReportViewer>

                                </div>
                            </td>
                        </tr>

                    </table>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
