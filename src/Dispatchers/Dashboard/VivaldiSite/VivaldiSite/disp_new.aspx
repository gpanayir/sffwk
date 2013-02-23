<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="disp_new.aspx.cs" Inherits="VivaldiSite.disp_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">

<script type="text/javascript" language="javascript">

    //refresh windows
    $(window).load(function () {

        $('#divUrlWebservice').css('display', 'none');

        $('#divPort').css('display', 'block');
        $('#divIp').css('display', 'block');
        $('#divObjectUri').css('display', 'block');

    });

    function WrapperTypeOnChange() {

        var combo = document.getElementById("wrappercombo");
        var code = combo.value;
    
         if (code == 'remoting') {
             $('#divUrlWebservice').css('display', 'none');

             $('#divPort').css('display', 'block');
             $('#divIp').css('display', 'block');
             $('#divObjectUri').css('display', 'block');
         }
         else {
             $('#divUrlWebservice').css('display', 'block');

             $('#divPort').css('display', 'none');
             $('#divIp').css('display', 'none');
             $('#divObjectUri').css('display', 'none');
         }
         return false;
    }
   
    function ReceiveServerData_btnAcept(arg, context) {
        alert(arg);
        location.replace("~/disp_dash.aspx");
    }

    </script>
    <div style="margin-left: 100px;">
        <div style="background-color: #FFFFFF; margin-top: 10px; margin-bottom: 5px">
            <div class="frm_label_2">
                Nombre de instancia del Dispatcher
            </div>
            <div>
                <asp:TextBox ID="txtInstanceName" runat="server" Font-Bold="True" TabIndex="1" TextMode="SingleLine"
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
                <asp:TextBox ID="txtServerName" runat="server" Font-Bold="True" TabIndex="1" TextMode="SingleLine"
                    Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
        </div>
        <div style="margin-top: 15px">
            <div class="frm_label_2">
                Tecnologia
            </div>
            <div style="width: 300px">
                <select id="wrappercombo" class="loging_textbox frm_fieldvalue" style="width: 300px"
                    onchange="javascript:WrapperTypeOnChange()">
                    <option value="webservice">Web Service </option>
                    <option value="remoting">Remoting </option>
                </select>
            </div>
        </div>
        <div class="frm_row" style="height: 150px">
            <div id="divUrlWebservice" style="margin: 15px; display: block;">
                <div class="frm_label_1">
                    Url Web service
                </div>
                <div>
                    <asp:TextBox ID="txtUrl" runat="server" Height="23px" Width="400px" TabIndex="11"
                        CssClass="loging_textbox frm_fieldvalue"></asp:TextBox>
                </div>
            </div>
            <div id="divPort" style="margin: 15px; display: none;">
                <div class="frm_label_1">
                    Puerto</div>
                <div>
                    <asp:TextBox ID="txtPort" runat="server" Height="23px" Width="500px" TabIndex="11"
                        CssClass="loging_textbox frm_fieldvalue"></asp:TextBox>
                </div>
            </div>
            <div id="divIp" style="margin: 15px; display: none;">
                <div class="frm_label_1">
                    Dirección Ip o nombre de host</div>
                <div>
                    <asp:TextBox ID="txtIp" runat="server" Height="23px" Width="300px" TabIndex="11"
                        CssClass="loging_textbox frm_fieldvalue"></asp:TextBox>
                </div>
            </div>
    
        </div>
        <div style="margin-top: 10px;">
            <div class="frm_label_2">
                Texto descriptivo general
            </div>
            <div class="frm_fieldvalue" style="margin-top: 4px">
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="600px"
                    Height="80px" CssClass="frm_fieldvalue" TabIndex="2" />
            </div>
        </div>
    </div>
       <div style="height: 70px; margin-top: 30px; margin-left: 100px">
        <asp:Button ID="btnAcept" runat="server" OnClick="Button1_Click" Text="Registrar"
            TabIndex="100" CssClass="btGrisNegrita" Width="120" Height="2em" />
    </div>
</asp:Content>
