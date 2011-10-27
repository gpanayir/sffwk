<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_Search_Control.ascx.cs" Inherits="Security.Usercontrol.News_Search_Control" %>


<link href="../Styles/Common.css" rel="stylesheet" type="text/css" />
<link href="../Styles/News.css" rel="stylesheet" type="text/css" />
<link href="../App_Themes/Brown/Grd960.css" rel="stylesheet" type="text/css" />
<div class ="searhLeftBox box_roun_shadow">    
        <h1> Buscar novedades</h1>
    
    <div class ="searhLeftBox_txt">
        <span id="spam2">
            <asp:TextBox ID="txtSearch" runat="server" Width="323px" ToolTip="Ingrese parte del título de la noticia"></asp:TextBox>
        </span><span id="Span1">
            <asp:ImageButton ID="btnSeach" runat="server" ImageUrl="~/Images/search.png" Text="buscar"
                OnClick="btnSeach_Click" Height="20px" /></span>
    </div>
</div>