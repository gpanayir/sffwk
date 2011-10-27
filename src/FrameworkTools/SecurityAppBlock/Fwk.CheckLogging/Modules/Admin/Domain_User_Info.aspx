<%@ Page Title="" Language="C#" MasterPageFile="~/Security_Master_2c.Master" AutoEventWireup="true" CodeBehind="Domain_User_Info.aspx.cs" Inherits="Fwk.CheckLogging.Modules.Admin.Domain_User_Info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
<div class ="grid_16">
<div>
User name:
    <asp:TextBox ID="txtUserName" runat="server" Width="173px"></asp:TextBox>
</div>

<div>
<hr />
Information
   <asp:Table ID="userInfoTable" CssClass="" runat="server" Width="430px" >
        <asp:TableHeaderRow Font-Bold="True">
        <asp:TableCell CssClass="" >User Info</asp:TableCell>
        <asp:TableCell CssClass=""> </asp:TableCell>
        </asp:TableHeaderRow>
           <asp:TableRow ID="TableRow2" runat="server" Height="30">
           </asp:TableRow>
        </asp:Table>
    
</div>

<div>
<hr />
User Groups
   <asp:Table ID="tableUserGroups" CssClass="bill_Color_Grey bill_center_1px" runat="server" Width="430px" >
        <asp:TableHeaderRow Font-Bold="True">
        <asp:TableCell CssClass="">Group name</asp:TableCell>
        </asp:TableHeaderRow>
           <asp:TableRow ID="TableRow1" runat="server" Height="30">
           </asp:TableRow>
        </asp:Table>
    
</div>
</div>

</asp:Content>
