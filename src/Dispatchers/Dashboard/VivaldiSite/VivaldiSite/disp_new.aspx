<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="disp_new.aspx.cs" Inherits="VivaldiSite.disp_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
    <script type="text/javascript" language="javascript">
        var varType;
        var varUrl;
        var varData;
        var varContentType;
        var varDataType;
        var varProcessData;
        //refresh windows
        $(window).load(function () {

            $('#divUrlWebservice').css('display', 'block');

            $('#divPort').css('display', 'none');
            $('#divIp').css('display', 'none');
            $('#divObjectUri').css('display', 'none');

        });

        function WrapperTypeOnChange() {
            $('#sussefullMsg').hide();
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





        //Generic function to call AXMX/WCF  Service        
        function CallService() {
            $.ajax({
                type: varType, //GET or POST or PUT or DELETE verb
                url: varUrl, // Location of the service
                data: varData, //Data sent to server
                contentType: varContentType, // content type sent to server
                dataType: varDataType, //Expected data format from server
                processdata: varProcessData, //True or False
                success: function (msg) {//On Successfull service call
                    ServiceSucceeded(msg);
                },
                error: function (response,status, error) {
                    ServiceFailed(response);
                }
            });
           
        }

        function ServiceSucceeded(result, status, error) 
        {
            
            var connected = result.ConnectToWebServiceResult
            if (connected == true) {
                $('#sussefullMsg').show();
            }
            else {
                $('#errorMsg').show();
            }
            varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;
        }
        function ServiceFailed(response) {

            $('#errorMsg').show();
//            var r = jQuery.parseJSON(response);
//            alert(response.responseText);
//              alert("Message: " + r.Message);
//              alert("StackTrace: " + r.StackTrace);
//              alert("ExceptionType: " + r.ExceptionType);

//            alert(request.responseText);
//            alert(xhr.statusText);
//            alert('Fallo la llamada al servicio: ' + request.status + '' + xhr.statusText);
//            alert(thrownError);

            varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;
        }

        function ConnectToWebService() {

            $('#sussefullMsg').hide();
//            if (validate_cotrols() == false) {
//                alert('Por favor verifique todos los datos !!!');
//                return;
//            }

            varType = "POST";
            varUrl = "../../service/wcf_service.svc/ConnectToWebService";
            varData = '{"url": "' + $('#ContentCenter_txtUrl').val() + '"}';
            
            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varProcessData = true;
            CallService();
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
        <div style="background-color: #FFFFFF; margin-top: 10px; margin-bottom: 5px">
            <div class="frm_label_2">
                Empresa
            </div>
            <div>
                <asp:TextBox ID="txtCompany" runat="server" Font-Bold="True" TabIndex="1" TextMode="SingleLine"
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
                Auditoria de servicio
            </div>
            <div style="width: 300px">
                <asp:DropDownList ID="cmbAuditMode" CssClass="loging_textbox frm_fieldvalue" runat="server"
                    Width="300px" DataTextField="Nombre" DataValueField="Id" Height="25px" TabIndex="15">
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
                        CssClass="loging_textbox frm_fieldvalue">http://localhost:38091/SingleService.asmx</asp:TextBox>
                          
                </div>
                <input id="Submit1" type="submit" value="submit" onmousedown="ConnectToWebService();" />
            </div>
            <div id="sussefullMsg" class="frm-message" style="margin-left:30px;  width:400px ; display: none;height:20px; background-color:#F7F7F7;" >
                <p>
                    La conexión al despachador de servicio web fue exitosa</p>
            </div>
             <div id="errorMsg" class="frm-error-message" style="display: none; color: Black;">
                <p>
                    No es posible la conexión con el servicio</p>
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
