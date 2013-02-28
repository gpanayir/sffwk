<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="disp_main.aspx.cs" Inherits="VivaldiSite.disp_main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">

    <div style="margin-left: 100px;">
        <div style="background-color: #FFFFFF; margin-top: 10px; margin-bottom: 5px">
            <div class="frm_label_2">
                Nombre de instancia del Dispatcher
            </div>
            <div class="grid_8">
                <asp:TextBox ID="txtInstanceName" runat="server" Font-Bold="True" TabIndex="1" TextMode="SingleLine"
                    Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
            <div class="grid_3">
                <input id="Submit2" class="grid_Button grid_Button_confirm" type="submit" tabindex="11"
                    style="width: 190px; height: 30px" value="Virificar disponibilidad" onclick="ChekDisponibility();return false;" />
            </div>
            <div class="clearfix">
            </div>
            <div id="sussefullMsg_1" class="frm-message" style="margin-left: 30px; width: 400px;
                display: none; height: 20px; background-color: #F7F7F7;">
                <p>
                    El nombre de instancia esta disponible.
                </p>
            </div>
            <div id="errorMsg_1" class="frm-error-message" style="margin-left: 36px; width: 400px;
                height: 20px; display: none; color: Black;">
            </div>
        </div>
        <div style="background-color: #FFFFFF; margin-top: 10px; margin-bottom: 5px">
            <div class="frm_label_2">
                Empresa
            </div>
            <div>
                <asp:TextBox ID="txtCompany" runat="server" Font-Bold="True" TabIndex="2" TextMode="SingleLine"
                    Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
        </div>
        <div class="">
            <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
        </div>
        <div style="margin-top: 5px">
            <div class="frm_label_2">
                Server Name
            </div>
            <div>
                <asp:TextBox ID="txtServerName" runat="server" Font-Bold="True" TabIndex="3" TextMode="SingleLine"
                    Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
        </div>
        <div style="margin-top: 15px">
            <div class="frm_label_2">
                Auditoria de servicio
            </div>
            <div style="width: 300px">
                <asp:DropDownList ID="cmbAuditMode" CssClass="loging_textbox frm_fieldvalue" runat="server"
                    Width="300px" DataTextField="Nombre" DataValueField="Id" Height="25px" TabIndex="4">
                    <asp:ListItem Value="0">Requerido</asp:ListItem>
                    <asp:ListItem Value="1">Opcional</asp:ListItem>
                    <asp:ListItem Value="2">Ninguno</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div style="margin-top: 15px">
            <div class="frm_label_2">
                Tecnologia
            </div>
            <div style="width: 300px">
                <asp:DropDownList ID="cmbWrapperType" CssClass="loging_textbox frm_fieldvalue" runat="server"
                    Enabled="false" Width="300px" DataTextField="Nombre" DataValueField="Id" Height="25px"
                    TabIndex="4" onchange="javascript:WrapperTypeOnChange()">
                    <asp:ListItem Value="0">Web Service</asp:ListItem>
                    <asp:ListItem Value="1">Remoting</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="frm_row" style="height: 150px">
            <div id="divUrlWebservice" style="margin: 15px; display: block;">
                <div class="frm_label_1">
                    Url Web service
                </div>
                <div class="grid_8">
                    <asp:TextBox ID="txtUrl" runat="server" Height="23px" Width="453px" TabIndex="10"
                        CssClass="loging_textbox frm_fieldvalue">http://localhost:38091/SingleService.asmx</asp:TextBox>
                </div>
                <div class="grid_3">
                    <input id="Submit1" class="grid_Button grid_Button_confirm" type="submit" tabindex="11"
                        style="width: 100px; height: 30px" value="Check url" onclick="ConnectToWebService();return false;" />
                </div>
            </div>
            <div class="clearfix">
            </div>
            <div id="sussefullMsg" class="frm-message" style="margin-left: 30px; width: 400px;
                display: none; height: 20px; background-color: #F7F7F7;">
                <p>
                    La conexión al despachador de servicio web fue exitosa</p>
            </div>
            <div id="errorMsg" class="frm-error-message" style="margin-left: 36px; width: 400px;
                height: 20px; display: none; color: Black;">
                No es posible la conexión con el servicio
            </div>
            <div id="divPort" style="margin: 15px; display: none;">
                <div class="frm_label_1">
                    Puerto</div>
                <div>
                    <asp:TextBox ID="txtPort" runat="server" Height="23px" Width="500px" TabIndex="201"
                        CssClass="loging_textbox frm_fieldvalue"></asp:TextBox>
                </div>
            </div>
            <div id="divIp" style="margin: 15px; display: none;">
                <div class="frm_label_1">
                    Dirección Ip o nombre de host</div>
                <div>
                    <asp:TextBox ID="txtIp" runat="server" Height="23px" Width="300px" TabIndex="21"
                        CssClass="loging_textbox frm_fieldvalue"></asp:TextBox>
                </div>
            </div>
        </div>
        <div style="margin-top: 10px;">
            <div class=" frm_label_2">
                Texto descriptivo general
            </div>
            <div class="frm_fieldvalue" style="margin-top: 4px">
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="600px"
                    Height="80px" CssClass="frm_fieldvalue" TabIndex="22" />
            </div>
        </div>
    </div>
</asp:Content>
