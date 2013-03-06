<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="disp_main_services.aspx.cs" Inherits="VivaldiSite.disp_main_services" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">

Servicios
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
<div class="article_wrap">
<div style="margin-left: 100px;">
        <div style="background-color: #FFFFFF; margin-top: 10px; margin-bottom: 5px">
            <div class="grid_5 frm_label_2">
                Dispatcher
            <div class="grid_8">
                <asp:TextBox ID="txtInstanceName" runat="server" Font-Bold="True" TabIndex="1" TextMode="SingleLine"
                    Width="300" Height="25px" Enabled="false" CssClass="frm_fieldvalue" />
            </div>
            
        </div>
        
      <div class="clearfix"></div>
        <div style="margin-top: 5px">
            <div class="grid_5 frm_label_2">
                Server Name
            </div>
            <div>
                <asp:TextBox ID="txtServerName" runat="server" Enabled="false" Font-Bold="True" TabIndex="3" TextMode="SingleLine"
                    Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
        </div>
     
        
        <div class="frm_row" style="height: 150px">
            <div id="divUrlWebservice" style="margin: 15px; display: block;">
                <div class="grid_5 frm_label_1">
                    Url Web service
                </div>
                <div class="grid_8">
                    <asp:Label ID="txtUrl" runat="server" Height="23px" Width="453px" TabIndex="10"
                        CssClass="loging_textbox frm_fieldvalue"></asp:Label>
                </div>
               
            </div>
     
        </div>
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
                           
                        </div>
                        
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pBody"
                        CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                        CollapsedText="+ Contraer" ExpandedText="- Expandir"
                        CollapsedSize="0">
                    </ajax:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>

                 <h4>
                        Lista de servicios</h4>
                    <p>
                        Aqui se listan todos los servicios configurados en el dispatcher
                    </p>
                    <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server">
                        <ContentTemplate>
                            <div>
                                <asp:GridView ID="grid_ServerSettings" runat="server" AutoGenerateColumns="False"
                                    BorderWidth="2" ToolTip="Servicios" Width="700px" AllowPaging="True"
                                    CellPadding="4" GridLines="Vertical" 
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
       </div>
    </div>
</div>
</asp:Content>
