﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="disp_main_service_admin.aspx.cs" Inherits="VivaldiSite.disp_main_service_admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
 <div class="article_wrap">
        
          <div>
            <h5>Configuración de servicio</h5>
                <p>
                    
                </p>
            </div>


            <div style="margin-top: 10px; margin-bottom: 5px;height: 50px">
                <div class="grid_4 frm_label_2">
                    Name
                </div>
                <div class="grid_8">
                    <asp:TextBox ID="txtName" runat="server" Font-Bold="True" TabIndex="1" TextMode="SingleLine"
                        Width="700" Height="25px" Enabled="false" CssClass="frm_fieldvalue" />
                </div>
            </div>
            
            <div style="margin-top: 10px; margin-bottom: 5px;height: 50px">
                <div class="grid_4 frm_label_2">
                    Svc assembly
                </div>
                <div>
                    <asp:TextBox ID="txtSVC" runat="server" Enabled="true" Font-Bold="True" TabIndex="3"
                        TextMode="SingleLine" Width="700" Height="25px" CssClass="frm_fieldvalue" />
                </div>
            </div>

            <div style="margin-top: 10px; margin-bottom: 15px;height: 50px">
                <div class="frm_label_2">
                    Requets assembly
                </div>
                <div>
                    <asp:TextBox ID="txtReq" runat="server" Enabled="true" Font-Bold="True" TabIndex="3"
                        TextMode="SingleLine" Width="900" Height="25px" CssClass="frm_fieldvalue" />
                </div>
            </div>
            <div style="margin-top: 10px; margin-bottom: 15px;height: 50px">
                <div class="frm_label_2">
                    Response assembly
                </div>
                <div>
                    <asp:TextBox ID="txtRes" runat="server" Enabled="true" Font-Bold="True" TabIndex="3"
                        TextMode="SingleLine" Width="900" Height="25px" CssClass="frm_fieldvalue" />
                </div>
            </div>

             <div style="margin-top: 10px; margin-bottom: 5px;height: 50px">
                <div class="grid_4 frm_label_2">
                    Audit 
                </div>
                <div>
                    <asp:CheckBox ID="chkAudit" runat="server" Enabled="true"  Font-Bold="True" TabIndex="3"
                         Width="100" Height="25px" CssClass="frm_fieldvalue" />
                </div>
            </div>
             <div style="margin-top: 10px; margin-bottom: 5px;height: 50px">
                <div class="grid_4 frm_label_2">
                    Available 
                </div>
                <div>
                    <asp:CheckBox ID="chkAvailable" runat="server" Enabled="true"  Font-Bold="True" TabIndex="3"
                         Width="300" Height="25px" CssClass="frm_fieldvalue" />
                </div>
            </div>

            <div style="margin-top: 10px; margin-bottom: 5px;height: 50px">
                <div class="grid_4 frm_label_2">
                    Transactional Behaviour 
                </div>
                <div>
             <asp:DropDownList ID="cmbTransactionalBehaviour" CssClass="loging_textbox frm_fieldvalue" runat="server"
                    Width="300px" DataTextField="Name" DataValueField="Id" Height="25px" TabIndex="4">
                    <asp:ListItem Value="0">Support</asp:ListItem>
                    <asp:ListItem Value="1">Required</asp:ListItem>
                    <asp:ListItem Value="2">RequiresNew</asp:ListItem>
                    <asp:ListItem Value="3">Suppres</asp:ListItem>

                </asp:DropDownList>
               </div>
            </div>


             <div style="margin-top: 10px; margin-bottom: 5px;height: 50px">
                <div class="grid_4 frm_label_2">
                    Isolation Level 
                </div>
                <div>
                    <asp:DropDownList ID="cmbIsolationLevel" CssClass="loging_textbox frm_fieldvalue" runat="server"
                        Width="300px" DataTextField="Name" DataValueField="Id" Height="25px" TabIndex="4">
                        <asp:ListItem Value="1">ReadCommitted</asp:ListItem>
                        <asp:ListItem Value="2">ReadUncommitted</asp:ListItem>
                        <asp:ListItem Value="3">RepeatableRead</asp:ListItem>
                        <asp:ListItem Value="4">Serializable</asp:ListItem>
                        <asp:ListItem Value="5">Snapshot</asp:ListItem>
                    </asp:DropDownList>
                </div>
             </div>

 </div>
</asp:Content>
