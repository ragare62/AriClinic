<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstimateForm.aspx.cs" Inherits="EstimateForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>
            Presupuesto
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
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript" src="GeneralFormFunctions.js"></script>
                <script type="text/javascript" src="dialog_box.js"></script>
                <script type="text/javascript">
                    function refreshGrid(arg) {
                        //alert("Hello from refreshGrid");
                        if (!arg) {
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("");
                        }
                        else {
                            $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("new");
                        }
                    }
                    function NewEstimateLine(id2) {
                        var w1 = window.open("EstimateLineForm.aspx?EstimateId=" + id2, "NELN", "width=650, height=550,resizable=1,scrollbars=1");
                        w1.focus();
                    }
                    function EditEstimateLine(id, id2) {
                        var w2 = window.open("EstimateLineForm.aspx?EstimateLineId=" + id + "&EstimateId=" + id2, "EELN", "width=650, height=550,resizable=1,scrollbars=1");
                        w2.focus();
                    }
                </script>
                <script type="text/javascript">
                    function refreshField(v1, v2, v3, v4, type) {
                        if (type) {
                            switch (type) {
                                default:
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
                </script>
            </telerik:RadCodeBlock>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" OnAjaxRequest="RadAjaxManager1_AjaxRequest">
                <AjaxSettings>
                    <telerik:AjaxSetting AjaxControlID="RadAjaxManager1">
                        <UpdatedControls>
                            <telerik:AjaxUpdatedControl ControlID="lblTotal" />
                            <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                        </UpdatedControls>
                    </telerik:AjaxSetting>
                </AjaxSettings>
            </telerik:RadAjaxManager>
            <telerik:RadSkinManager ID="RadSkinManager1" Runat="server" Skin="Office2007">
            </telerik:RadSkinManager>
            <telerik:RadToolTipManager ID="RadToolTipManager1" runat="server" 
                                       AutoTooltipify="true" RelativeTo="Element" Position="TopCenter">
            </telerik:RadToolTipManager>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="550px" 
                                  Width="100%">
                <div id="content">
                    <table width="100%">
                        <tr>
                            <td colspan="6">
                                <div id="TitleArea" class="titleBar2">
                                    <img alt="minilogo" src="images/mini_logo.png" align="middle" />
                                    <asp:Label ID="lblTitle" runat="server" Text="Presupuestos"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="EstimateId" class="normalText">
                                    <asp:Label ID="lblEstimateId" runat="server" Text="PRESUPUESTO ID:" 
                                               ToolTip="Identificador de presupuesto, lo usa internamente el sistema"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtEstimateId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div id="Request.RequestId" class="normalText">
                                    <asp:Label ID="lblRequestRequestId" runat="server" Text="SOLICITUD ID:" 
                                               ToolTip="Identificador de solicitud, lo usa internamente el sistema"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtRequestRequestId" runat="server" Enabled="false" Width="89px"></asp:TextBox>
                                </div>
                            </td>
                            <td colspan="2">
                                <div ID="EstimateDate" class="normalText" >
                                    <asp:Label ID="lblEstimateDate" runat="server" Text="Fecha presupuesto:" 
                                               ToolTip="Fecha en la que se abrió la historia"></asp:Label>
                                    <br />
                                    <telerik:RadDatePicker ID="rdtEstimateDate" runat="server" Culture="es-ES" CssClass="myCenter"  
                                                           MinDate=""  TabIndex="1">
                                        <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" 
                                                  ViewSelectorText="x">
                                        </Calendar>
                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy">
                                        </DateInput>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div id="FullName" class="normalText">
                                    <asp:Label ID="lblFullName" runat="server" Text="INTERESAD@:" 
                                               ToolTip="Identificador de solicitud, lo usa internamente el sistema"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtFullName" runat="server" Enabled="false" Width="100%"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                            </td>
                            <td colspan="1">
                                <div id="Total" class="totalText">
                                    <asp:Label ID="lblTotal" runat="server" Text="TOTAL:"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div id="EstimateLineGrid" class="normalText" style="width:100%">
                                    <telerik:RadGrid ID="RadGrid1" runat="server" Skin="Office2007"
                                                     AllowPaging="True" PageSize="6" AllowFilteringByColumn="True" 
                                                     onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                                                     onneeddatasource="RadGrid1_NeedDataSource" GridLines="None" 
                                                     meta:resourcekey="RadGrid1Resource1">
                                        <MasterTableView AutoGenerateColumns="False" datakeynames="EstimateLineId" 
                                                         CommandItemDisplay="Top">
                                            <CommandItemSettings ExportToPdfText="Export to Pdf" />
                                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                            </RowIndicatorColumn>
                                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                            </ExpandCollapseColumn>
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="EstimateLineId" DataType="System.Int32" 
                                                                         FilterControlAltText="Filter ChannelId column" HeaderText="LID" 
                                                                         meta:resourcekey="GridBoundColumnResource1" ReadOnly="True" 
                                                                         SortExpression="EstimateLineId" UniqueName="EstimateLineId">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Description" 
                                                                         FilterControlAltText="Filter Name column" HeaderText="Concepto" 
                                                                         meta:resourcekey="GridBoundColumnResource2" ReadOnly="True" 
                                                                         SortExpression="Description" UniqueName="Description">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Amount" DataFormatString="{0:C}" 
                                                                         FilterControlToolTip="Filtrar por precio" FilterImageToolTip="Filtro"
                                                                         HeaderText="Importe" meta:resourceKey="GridBoundColumnResource5" 
                                                                         ReadOnly="True" SortExpression="Amount" 
                                                                         UniqueName="Amount">
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Discount" DataFormatString="{0:C}" 
                                                                         FilterControlToolTip="Filtrar por descuento" FilterImageToolTip="Filtro"
                                                                         HeaderText="Descuento" meta:resourceKey="GridBoundColumnResource5" 
                                                                         ReadOnly="True" SortExpression="Discount" 
                                                                         UniqueName="Discount">
                                                    <HeaderStyle HorizontalAlign="Right" />
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="False" 
                                                                            FilterControlAltText="Filter Template column" HeaderText="Acciones" 
                                                                            meta:resourcekey="GridTemplateColumnResource1" UniqueName="Template">
                                                    <ItemTemplate>
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
                                                                     meta:resourcekey="NewResource1" OnClientClick="NewEstimateLine();" 
                                                                     ToolTip="Añadir un nuevo registro" />
                                                </div>
                                            </CommandItemTemplate>
                                        </MasterTableView>
                                        <FilterMenu EnableImageSprites="False">
                                        </FilterMenu>
                                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Office2007">
                                        </HeaderContextMenu>
                                    </telerik:RadGrid>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div id="Comments" class="normalText">
                                    <asp:Label ID ="lblComments" runat="server" Text="Observaciones"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div ID="Message" class="messageText">
                                    <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <div ID="Buttons" class="buttonsFomat">
                                    <asp:ImageButton ID="btnAccept" runat="server" 
                                                     ImageUrl="~/images/document_ok.png" onclick="btnAccept_Click" ToolTip="Guardar y salir" TabIndex="17" />
                                    &nbsp;
                                    <asp:ImageButton ID="btnCancel" runat="server" 
                                                     ImageUrl="~/images/document_out.png" CausesValidation="False" 
                                                     onclick="btnCancel_Click" ToolTip="Salir sin guardar" TabIndex="18" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </telerik:RadAjaxPanel>
        </form>
    </body>
</html>
