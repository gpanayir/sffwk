<%@ Page Language="C#" AutoEventWireup="true" CodeFile="processes.aspx.cs" Inherits="processes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 425px">
            <tr>
                <td>
                    <asp:Button ID="btnConnect" runat="server" Text="Connect" OnClick="btnConnect_Click" Width="70px" />
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="70px" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" Width="70px" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" OnClick="btnDelete_Click" />
                </td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;<asp:GridView ID="grdProcesses" runat="server" AutoGenerateColumns="False" DataKeyNames="Name" PageSize ="20"  AllowPaging ="true" OnPageIndexChanging="grdProcesses_PageIndexChanging">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText=">>" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                            <asp:BoundField DataField="Handler" HeaderText="Handler" SortExpression="Handler" />
                            <asp:BoundField DataField="Request" HeaderText="Request" SortExpression="Request" />
                            <asp:BoundField DataField="Response" HeaderText="Response" SortExpression="Response" />
                            <asp:BoundField DataField="TransactionalBehaviour" HeaderText="TransactionalBehaviour" SortExpression="TransactionalBehaviour" />
                            <asp:BoundField DataField="IsolationLevel" HeaderText="IsolationLevel" SortExpression="IsolationLevel" />
                            <asp:BoundField DataField="Timeout" HeaderText="Timeout" SortExpression="Timeout" />
                            <asp:CheckBoxField DataField="Available" HeaderText="Available" SortExpression="Available" />
                            <asp:CheckBoxField DataField="Audit" HeaderText="Audit" SortExpression="Audit" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
