<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_ItemList_Link.ascx.cs" Inherits="Security.Usercontrol.News_ItemList_Link" %>

<script type="text/javascript" src="../js2/jQuery/jquery-1.3.2.js"></script>


<link href="../Styles/News.css" rel="stylesheet" type="text/css" />

<div id ="c1" class="news_list">
    <div class="news_list_img">
        <asp:Image ID="Image1" runat="server" ImageUrl="../Images/tilde_guion-griz.png" />
    </div>
    <div class="news_list_link">
       <asp:HyperLink ID="lblTitle" Target="_blank" NavigateUrl="~/Modules/Noticias/NewsFullView.aspx"
                runat="server" CssClass="news_list_link" Font-Underline="False">HyperLink</asp:HyperLink>
    </div>

        <div class="news_list_img_rgh">
            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="../Images/edit.png" Text="Editar"
                Height="16px" DescriptionUrl="~/Modules/Admin/Admin_NewsUpdate.aspx" PostBackUrl="~/Modules/Admin/Admin_NewsUpdate.aspx"
                ToolTip="Editar esta noticia" Width="16px" onclick="btnEdit_Click" />
            <samp>
                <asp:ImageButton ID="btnRemove" runat="server" ImageUrl="../Images/remov_16.png"
                    Text="Eliminar esta noticia" Height="16px" DescriptionUrl="~/Modules/Admin/Admin_NewsUpdate.aspx"
                    ToolTip="Eliminar esta noticia" 
                Style="width: 20px" Width="16px" />
            </samp>
        </div>
        <div class="clearBoth">
        </div>

</div>
