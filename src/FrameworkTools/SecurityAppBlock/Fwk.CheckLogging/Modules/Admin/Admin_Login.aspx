<%@ Page Title="" Language="C#" MasterPageFile="~/Security_Admin.master" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="Security.Modules.Admin.Admin_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelLogin" runat="server" DefaultButton="Login1$LoginButton">
  <div style="background-color: #FFFFFF" class="EnvelopeCont">
      <asp:Login ID="Login1" runat="server" Width= "100%" 
          FailureText="Su intento de inicio de sesión no se realizó correctamente. Por favor, inténtelo de nuevo." 
          LoginButtonText="Iniciar" 
          PasswordRequiredErrorMessage="La password es requerida." 
          RememberMeText="Recordar mis datos la próxima vez" 
          UserNameLabelText="Nombre de usuario:" 
          UserNameRequiredErrorMessage="El nombre ed usuario es requerido." 
          CssClass="logingcontrol" TitleText="Iinicie sesión" 
          MembershipProvider="Securitysec">
              <LabelStyle Font-Bold="False"  Font-Size="11" />
          <TextBoxStyle Font-Bold="False" Font-Size="11" />
          <LoginButtonStyle CssClass="btGrisNegrita" />
          <CheckBoxStyle CssClass ="login_check" />
        <TitleTextStyle Font-Bold="false" VerticalAlign="Top" Font-Size="14" />
        
      </asp:Login>
  </div>
 </asp:Panel>

</asp:Content>

