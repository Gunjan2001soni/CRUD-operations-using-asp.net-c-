<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail_in_Grid.aspx.cs" Inherits="GunjanForm.detail_in_Grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div><asp:Button ID="btnAddUser" runat="server" Text="Add new User" OnClick="btnAddUser_Click" /></div>
        <div style="padding: 10px; margin: 0px; width: 100%;">
                    <p>
                        Total Student:<asp:Label ID="lbltotalcount" runat="server" Font-Bold="true"></asp:Label>
                    </p>
                    <asp:GridView ID="GridViewuser" runat="server" DataKeyNames="user_id"
                                OnSelectedIndexChanged="GridViewuser_SelectedIndexChanged"

                        OnRowDeleting="GridViewuser_RowDeleting">
                        <Columns>
                            <asp:CommandField HeaderText="Update" ShowSelectButton="True" />
                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
    </form>
</body>
</html>
