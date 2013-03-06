<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="disp_main.aspx.cs" Inherits="VivaldiSite.disp_main" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">

 <script type="text/javascript" language="javascript">

     function call_disp_main_service() {
         $('#errorMsg_1')
     }
 </script>
<div id="Div3" class ="menuv_header_2" >
 <p>Entornos</p>
</div>
<div id="menuv" class  ="menuv">
    <ul>
        <li><a class="menuv_a" href="/disp_searchlist.aspx"  title="Administrar dispatcher">Administrar dispatcher</a></li>
        <li><a class="menuv_a" href="/sec_main.aspx" title="Seguridad particular">Seguridad</a></li>
    
    </ul>

</div>

<div id="Div1" class ="menuv_header_2" >
 <p>.............. </p>
</div>
<div id="Div2" class  ="menuv">
    <ul>
        <li><a class="menuv_a" href='<%=this.dire %>' title="Administrar dispatcher">Servicios</a></li>
        <li><a class="menuv_a" href="sec_main_metadata.aspx" title="Seguridad particular">Metadata providers</a></li>
     <li><a class="menuv_a" href="sec_main_cnnstr.aspx" title="Seguridad particular">Security</a></li>
    </ul>

</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
<div class="article_wrap">
    <div style="margin-left: 5px;">
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
    <div class="clear"></div>
  
       
    <div class="frm_row" style="height: 450px;margin-top:15px; margin-left: 5px;">

        
 

     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                <ContentTemplate>
                    <asp:Panel ID="pHeader" runat="server" CssClass="cpHeaderExpand">
                        <asp:Label ID="Label4" runat="server" Text="Ocurrio un error al conctarce al dispatcher" ForeColor="#CC0066" />
                    </asp:Panel>
                    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                        <div id="divError">
                            <div class="frm-error-message">
                                <asp:Label ID="msgError" CssClass="" Height="40" Width="600" Visible="true" ForeColor="Maroon"
                                    runat="server" />
                            </div>
                            <div>
                                <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refrescar conexión"
                                    Font-Size="10" Font-Bold="true" TabIndex="100" BorderStyle="Inset" CssClass="grid_Button grid_Button_send"
                                    Width="235px" Height="20" BorderColor="#CC3300" />
                            </div>
                        </div>
                        
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pBody"
                        CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                        CollapsedText="+ Contraer" ExpandedText="- Expandir"
                        CollapsedSize="0">
                    </ajax:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>



        <ajax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="787px"
             Height="300px">
            <ajax:TabPanel runat="server" HeaderText="Metadata providers" ID="TabPanel1">
                <ContentTemplate>
                    <h4>
                        Metadata providers</h4>
                    <p>
                        Aqui se listan todos los proveedores configurados en el Web.congfig o exe.config
                        del dispatcher
                    </p>
                    <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server">
                        <ContentTemplate>
                            <div>
                                <asp:GridView ID="grid_ServerSettings" runat="server" AutoGenerateColumns="False"
                                    BorderWidth="2" ToolTip="Metadata providers" Width="700px" AllowPaging="True"
                                    CellPadding="4" GridLines="Vertical" OnRowCommand="grid_ServerSettings_RowCommand"
                                    OnRowDataBound="grid_ServerSettings_RowDataBound" OnRowUpdating="grid_ServerSettings_RowUpdating"
                                    ShowFooter="True">
                                    <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                                        Mode="NextPreviousFirstLast"></PagerSettings>
                                    <Columns>
                                        <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False" />
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("key") %>' CommandName="View"
                                                    runat="server" CssClass="icon_edit" Width="15"> 
                                              
                                                </asp:LinkButton>
                                                <asp:Label ID="IdLabel" Font-Bold="true" Width="250" runat="server" Text='<%# Eval("key") %>'></asp:Label>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Configuracion">
                                            <ItemTemplate>
                                                <asp:Label ID="ValueLabel" runat="server" Text='<%# Eval("Value") %>'  Width="175px"></asp:Label>
                                                <asp:TextBox ID="Value" runat="server" Text='<%# Eval("Value") %>' Width="175px"
                                                    Visible="false"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="grid_Header" />
                                    <RowStyle CssClass="grid_Row" />
                                    <AlternatingRowStyle CssClass="grid_AlternateRow" />
                                </asp:GridView>
                                <br />
                                <br />
                                <asp:Label ID="Message" runat="server" CssClass="message"></asp:Label>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </ContentTemplate>
            </ajax:TabPanel>
            <ajax:TabPanel runat="server" HeaderText="Connextions strings" ID="TabPanel2">
                <ContentTemplate>
                    <h4>
                        Connection string</h4>
                    <p>
                        Aqui se listan todos las cadenas de conexión configurados en el Web.congfig o exe.config
                        del dispatcher
                    </p>

                    <asp:GridView ID="grid_CnnStrings" runat="server" AutoGenerateColumns="False"
                        CSSSelectorClass="YodaGrilla" OnRowCommand="grid_ServerSettings_RowCommand" ToolTip="Connection string"
                        Width="700px" AllowPaging="True">
                        <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                            Mode="NextPreviousFirstLast"></PagerSettings>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("key") %>' CommandName="View"
                                        runat="server" CssClass="icon_edit" Width="40"> 
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="key" HeaderText="key" SortExpression="key" />
                            <asp:BoundField DataField="Value" HeaderText="Valor" SortExpression="Value" />
                        </Columns>
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </ContentTemplate>
            </ajax:TabPanel>
        </ajax:TabContainer>
    </div>
</div>

</asp:Content>
