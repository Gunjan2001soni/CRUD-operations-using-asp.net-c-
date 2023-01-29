<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userRegis.aspx.cs" Inherits="GunjanForm.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous" />

</head>
<body>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.3/dist/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
    <form runat="server">
        <div class="p-3 mb-2 bg-secondary text-white">Fill the Registration Form</div>
        <table runat="server" class="table table-striped">
            <tr>
                <td>
                    <asp:Label ID="label1" runat="server" Text="Username"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" ToolTip="Enter your name"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter your username"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblSID" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label7" runat="server" Text="Address"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" ToolTip="Enter your Address"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter your address"
                        ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label2" runat="server" Text="Email"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" ToolTip="Enter your Email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Please enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label4" runat="server" Text="Password"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" ToolTip="Enter your Password"></asp:TextBox><asp:RequiredFieldValidator ID="pass" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Please enter a password" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label3" runat="server" Text="Mobile"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" MaxLength="4" ToolTip="Enter your phone no."></asp:TextBox>
                    <%--   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                        ErrorMessage="Please enter a valid phone number" ValidationExpression="^[\s\S]{10,10}$"
                        ForeColor="Red"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID='vldNumber' ControlToValidate='txtMobile' Display='Dynamic' ErrorMessage='Not a number' ValidationExpression='(^([0-9]*|\d*\d{1}?\d*)$)' runat='server'>
                    </asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label5" runat="server" Text="Gender"></asp:Label></td>
                <td>
                    <asp:RadioButton ID="Gendermale" runat="server" Text="Male" GroupName="gender" AutoPostBack="True" />
                    <asp:RadioButton ID="Genderfemale" runat="server" Text="FeMale" GroupName="gender" AutoPostBack="True" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label6" runat="server" Text="Select the course:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="">Please Select</asp:ListItem>
                        <asp:ListItem>Maths </asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                        <asp:ListItem>Hindi</asp:ListItem>
                        <asp:ListItem>French</asp:ListItem>
                        <asp:ListItem>none</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false"
                        OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Clear" Visible="false" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>

</html>

