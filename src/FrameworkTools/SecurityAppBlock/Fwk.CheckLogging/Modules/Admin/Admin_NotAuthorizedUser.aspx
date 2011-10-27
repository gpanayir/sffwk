<%@ Page Title="" Language="C#" MasterPageFile="~/Security_Master.Master" AutoEventWireup="true" CodeBehind="Admin_NotAuthorizedUser.aspx.cs" Inherits="Security.Modules.Admin.Admin_NotAuthorizedUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
    <div class="EnvelopeCont">
        <div id="msg" style="font-size: xx-large; width: 100%; height: 248px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/warning.png" EnableTheming="False"
                EnableViewState="False" Height="54px" Width="44px" />
            <span style="color: #666666">&nbsp;&nbsp; No es un usuario autorizado para realizar
                esta acción.
                <br />
            </span>
            <br style="color: #666666" />
            <span style="color: #666666">Por favor inicie sesión.- </span>
        </div>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="Login1$LoginButton">
            <asp:Login ID="Login1" runat="server" FailureText="Su intento de inicio de sesión no se realizó correctamente. Por favor, inténtelo de nuevo."
                LoginButtonText="Iniciar" PasswordRequiredErrorMessage="La password es requerida."
                RememberMeText="Recordar mis datos la próxima vez" UserNameLabelText="Nombre de usuario:"
                UserNameRequiredErrorMessage="El nombre ed usuario es requerido." CssClass="logingcontrol"
                TitleText="Iinicie sesión" OnLoginError="Login1_LoginError">
                <LabelStyle Font-Bold="False" Font-Size="11" />
                <TextBoxStyle Font-Bold="False" Font-Size="11" />
                <LoginButtonStyle CssClass="btGrisNegrita" />
                <CheckBoxStyle CssClass="login_check" />
                <TitleTextStyle Font-Bold="false" VerticalAlign="Top" Font-Size="14" />
            </asp:Login>
        </asp:Panel>
    </div>
</asp:Content>
