<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loginpage.aspx.cs" Inherits="loginpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style3
        {
            width: 448px;
            height: 34px;
        }
        .style4
        {
            width: 1013px;
            height: 34px;
        }
        .style6
        {
            width: 448px;
            height: 26px;
        }
        .style7
        {
            width: 1013px;
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <font size=4 color=green>
<table bgcolor=black border=1 class=w3-container>
<tr><td class="style4">Username<asp:TextBox ID="TextBoxUserName" runat="server" 
        Width="128px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBoxUserName" ErrorMessage="RequiredFieldValidator" 
        ForeColor="Red">UserName Is missing</asp:RequiredFieldValidator>
    </td>
    <td class="style3">Password<asp:TextBox ID="TextBoxPassword" runat="server" 
            TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBoxPassword" ErrorMessage="RequiredFieldValidator" 
            ForeColor="Red">Password Is missing</asp:RequiredFieldValidator>
    </td></tr>
<tr><td class="style7">
    <asp:Button ID="Buttonlogin" runat="server" Text="login" BackColor="Black" 
        Font-Size="Large" ForeColor="Green" onclick="Buttonlogin_Click" />
    <asp:Label ID="LabelMSG" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
    </td><td class="style6">
        <asp:Button ID="Buttoncancel" runat="server" Text="cancel" BackColor="Black" 
            Font-Size="Large" ForeColor="Green" style="margin-left: 1px" 
            CausesValidation="False" onclick="Buttoncancel_Click" /></td></tr>
        
</table>
</font>
</asp:Content>

