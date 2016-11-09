<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UscLogin.ascx.cs" Inherits="AriCliWeb.UscLogin" %>
<link href="AriClinicStyle.css" rel="stylesheet" type="text/css" />

<div id="LoginMain" style="width:400px; height:500px">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAccept" />
        </Triggers>
        <ContentTemplate>--%>
            <div id="Login" class="normalText" 
                 style="z-index: 1; left: 67px; top: 39px; position: absolute; height: 41px; width: 142px">
                <asp:Label ID="lblLogin" runat="server" Text="Usuario:"></asp:Label>
                <br />
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
            </div>
            <div id="Password" class="normalText"
                 style="z-index: 1; left: 68px; top: 92px; position: absolute; height: 46px; width: 143px">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña:"></asp:Label>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div id="Buttons" class="buttonsFomat" 
                 style="z-index: 1; left: 68px; top: 205px; position: absolute; height: 27px; width: 296px; bottom: 153px;">
                <asp:Button ID="btnAccept" runat="server" Text="Entrar" 
                            onclick="btnAccept_Click" />
            </div>
            <div id="MessageArea" class="messageText" 
       
                 style="z-index: 1; left: 67px; top: 245px; position: absolute; height: 70px; width: 297px">
                <asp:Label ID="lblMessage" runat="server" Text="Mensajes:"></asp:Label>
            </div>
            <div id="AuxControls" style="z-index: 1; left: 66px; top: 345px; position: absolute; height: 70px; width: 297px">
                <telerik:RadInputManager ID="RadInputManagerLogin" runat="server">
                    <telerik:TextBoxSetting Validation-IsRequired="true" >
                        <TargetControls>
                            <telerik:TargetInput ControlID="txtLogin" />
                            <telerik:TargetInput ControlID="txtPassword" />
                            <telerik:TargetInput ControlID="ddlClinica" />
                        </TargetControls>

                        <Validation IsRequired="True"></Validation>
                    </telerik:TextBoxSetting>
                </telerik:RadInputManager>
                <br />
            </div>
            <div id="Clinica" class="normalText"
                 style="z-index: 1; left: 70px; top: 146px; position: absolute; height: 46px; width: 261px">
                <asp:Label ID="lblClinica" runat="server" Text="Clinica:" ToolTip="Clinica a la que desea conectarse"></asp:Label>
                <br />
                <telerik:RadComboBox ID="rdcbClinic" Runat="server">
                </telerik:RadComboBox>
            </div>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>

</div>