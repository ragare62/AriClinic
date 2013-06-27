<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreatmentForm.aspx.cs" Inherits="TreatmentForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Tratamientos
        </title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />
        <link href="dialog_box.css" rel="stylesheet" type="text/css" />
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

            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript" src="GeneralFormFunctions.js"></script>
                <script type="text/javascript" src="dialog_box.js"></script>
                <script type="text/javascript">
                    function refreshField(v1, v2, v3, v4, type) {
                        var combo;
                        if (type){
                            switch (type){
                                case "Patient":
                                    combo = $find("<%= rdcPatient.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                                case "Drug":
                                    combo = $find("<%= rdcDrug.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                                case "Professional":
                                    combo = $find("<%= rdcProfessional.ClientID %>");
                                    loadCombo(combo, v1, v3);
                                    break;
                            }
                        }
                    }
                    function loadCombo(combo, v1, v3){
                        var items = combo.get_items();
                        items.clear();
                        var comboItem = new Telerik.Web.UI.RadComboBoxItem();
                        comboItem.set_text(v3);
                        comboItem.set_value(v1);
                        items.add(comboItem);
                        combo.commitChanges();
                        comboItem.select();
                    }
                    function printPrescription(treatment) {
                        var url = "RptView.aspx?Report=prescription&Treatment=" + treatment;
                        var w = window.open(url, "rptview", "width=800,height=600,resizable=1");
                        w.focus();
                    }
                </script>
            </telerik:RadCodeBlock>

            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="RadAjaxPanel1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
            </telerik:RadSkinManager>
            <telerik:RadInputManager ID="RadInputManager1" runat="server">
                <telerik:TextBoxSetting Validation-IsRequired="true">
                    <TargetControls>
                        <telerik:TargetInput ControlID="txtName" />
                    </TargetControls>
                </telerik:TextBoxSetting>
            </telerik:RadInputManager>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                       AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
            </telerik:RadToolTipManager>
            <div id="content" style="height:0px">
                <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                                <div id="TitleArea" class="titleBar2">
                                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                    <asp:Label ID="lblTitle" runat="server" Text="Tratamiento"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="Patient" class="normalText">
                                    <asp:Label ID="lblPatient" runat="server" Text="Paciente:" 
                                               ToolTip="Paciente al que se asigna el diagnóstico"></asp:Label>
                                    <asp:ImageButton ID="btnPatient" runat="server" 
                                                     ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     ToolTip="Haga clic aquí para buscar un paciente" 
                                                     OnClientClick="searchPatient();" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcPatient" Height="100px" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." 
                                                         onitemsrequested="rdcPatient_ItemsRequested" ItemsPerRequest="10" 
                                                         Width="314px" TabIndex="1" >
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td>
                                <div id="TreatmentDate" class="normalText">
                                    <asp:Label ID="lblTreatmentDate" runat="server" Text="Fecha del tratamiento:" 
                                               ToolTip="Fecha en la que se pautó el tratamiento"></asp:Label>
                                    <br />
                                    <telerik:RadDatePicker ID="rdpTreatmentDate" runat="server" TabIndex="2">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" TabIndex="2">
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="2" />
                                    </telerik:RadDatePicker>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="Professional" class="normalText">
                                    <asp:Label ID="lblProfessional" runat="server" Text="Profesional:" 
                                               ToolTip="Profesional que pauta el tratamiento"></asp:Label>
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                                     ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     ToolTip="Haga clic aquí para buscar un profesional" 
                                                     OnClientClick="searchProfessional();" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcProfessional" Height="100px" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." 
                                                         onitemsrequested="rdcProfessional_ItemsRequested" ItemsPerRequest="10" 
                                                         Width="314px" TabIndex="1" >
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="normalText">
                                <div id="Drug">
                                    <asp:Label ID="lblDrug" runat="server" Text="Fármaco:" 
                                               ToolTip="Fármaco a asignar"></asp:Label>
                                    <asp:ImageButton ID="btnDrug" runat="server" 
                                                     ImageUrl="~/images/search_mini.png" CausesValidation="false"
                                                     ToolTip="Haga clic aquí para buscar un fármaco" 
                                                     OnClientClick="searchDrug();" />
                                    <br />
                                    <telerik:RadComboBox runat="server" ID="rdcDrug" Height="100px" 
                                                         EnableLoadOnDemand="true" ShowMoreResultsBox="true" EnableVirtualScrolling="true"
                                                         EmptyMessage="Escriba aquí ..." 
                                                         onitemsrequested="rdcDrug_ItemsRequested" ItemsPerRequest="10" 
                                                         Width="446px" TabIndex="3" >
                                    </telerik:RadComboBox>
                                </div>
                            </td>
                            <td>
                                <div id="Quantity" class="normalText">
                                    <asp:Label ID = "lblQuantity" runat="server" Text="Cantidad"></asp:Label>
                                    <br />

                                </div>
                                <telerik:RadNumericTextBox ID="txtQuantity" runat="server" MinValue="0">
                                    <NumberFormat DecimalDigits="2" ZeroPattern="n" />
                                </telerik:RadNumericTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="Recommend" class="normalText">
                                    <asp:Label ID="lblRecommend" runat="server" Text="Posologia:" 
                                               ToolTip="Posologia o comentarios"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtRecommend" runat="server" TextMode="MultiLine" Height="155px" 
                                                 Width="462px" TabIndex="4"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div ID="Buttons" class="buttonsFomat">
                                    <asp:ImageButton ID="btnPrint" runat="server" 
                                                     ImageUrl="~/images/pill_green.png"  
                                                     ToolTip="Imprimir receta individual" TabIndex="5" 
                                        onclick="btnPrint_Click" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnAccept" runat="server" 
                                                     ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" 
                                                     ToolTip="Guardar y salir" TabIndex="5" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCancel" runat="server" 
                                                     ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                                     onclick="btnCancel_Click" ToolTip="Salir sin guardar" 
                                                     TabIndex="6" />
                                </div>
                            </td>
                        </tr>
                    </table>                      

                </telerik:RadAjaxPanel>
            </div>
        </form>
    </body>
</html>
