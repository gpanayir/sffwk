<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit.aspx.cs" Inherits="edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 325px">
            <tr>
                <td colspan = "6">
                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    <br/>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="255" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan = "6">
                    <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                    <br/>
                    <asp:TextBox ID="txtDescription" runat="server" Height="80px" MaxLength="1000" Width="401px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td colspan = "6">
                    <asp:Label ID="Label5" runat="server" Text="Handler"></asp:Label>
                    <br/>
                    <asp:TextBox ID="txtHandler" runat="server" Width="400px"></asp:TextBox>                
                </td>
            </tr>
            <tr>
                <td colspan = "6">
                    <asp:Label ID="Label3" runat="server" Text="Request"></asp:Label>
                    <br/>
                    <asp:TextBox ID="txtRequest" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan = "6">
                    <asp:Label ID="Label4" runat="server" Text="Response"></asp:Label>
                    <br/>
                    <asp:TextBox ID="txtResponse" runat="server" Width="400px"></asp:TextBox>                
                </td>
            </tr>


            
            <tr>
                <td style="width: 108px">
                    <asp:Label ID="Label6" runat="server" Text="Request"></asp:Label><br />
                    <asp:DropDownList ID="cboTransactionalBehaviour" runat="server" Width="150px">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Request"></asp:Label>
                    <asp:DropDownList ID="cboIsolationLevel" runat="server" Width="150px">
                    </asp:DropDownList></td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Request"></asp:Label><br />
                    <asp:TextBox ID="txtTimeout" runat="server" Width="90px"></asp:TextBox></td>
                <td>
                    <asp:CheckBox ID="ckAvailable" runat="server" Text="Available" /></td>                
                <td style="width: 26px">
                    <asp:CheckBox ID="ckAudit" runat="server" Text="Audit" /></td>
                <td style="width: 3px">
                    <asp:CheckBox ID="chkCacheable" runat="server" Text="Cacheable" /></td>                
            </tr>
            
            <tr>
                <td colspan = "6" style="text-align: right" >
                    <asp:Button ID="btnOk" Text ="Ok" runat="server" OnClick="btnOk_Click" Width="70px" />
                    <asp:Button ID="btnCancel" Text ="Cancel" runat="server" OnClick="btnCancel_Click" Width="70px"/>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
