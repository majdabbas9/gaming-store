<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignupPage.aspx.cs" Inherits="SignupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <font color=green size=4>
<table bgcolor=black style="height: 67px; width: 885px" class=w3-container border=1>
<tr><td>UserName<asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBoxUserName" ErrorMessage="RequiredFieldValidator" 
        ForeColor="Red">UserName is missing</asp:RequiredFieldValidator>
    </td><td>DOB<asp:DropDownList ID="DropDownListDay" runat="server" 
            AutoPostBack="True" 
            onselectedindexchanged="DropDownListDay_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListmonth" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownListmonth_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListYear" runat="server" AutoPostBack="True" 
            onselectedindexchanged="DropDownListYear_SelectedIndexChanged">
        </asp:DropDownList>
    </td></tr>
<tr><td>UserEmail<asp:TextBox ID="TextBoxUserEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBoxUserEmail" ErrorMessage="RequiredFieldValidator" 
        ForeColor="Red">Email is missing</asp:RequiredFieldValidator>
    </td><td>UserPassword<asp:TextBox ID="TextBoxPassWord" runat="server" 
            TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="TextBoxPassWord" ErrorMessage="RequiredFieldValidator" 
            ForeColor="Red">PassWord Is missing</asp:RequiredFieldValidator>
    </td></tr>
<tr><td>ISfemale<asp:CheckBox ID="CheckBoxIsfemale" runat="server" 
        AutoPostBack="True" /></td></tr>
<tr><td>
    <asp:Button ID="Buttonsignup" runat="server" Text="Sign up" BackColor="Black" 
        Font-Size="Large" ForeColor="Green" onclick="Buttonsignup_Click" />
    <asp:Label ID="LabelMSG" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
    </td><td>
        <asp:Button ID="Button2" runat="server" Text="Cancel" BackColor="Black" 
            Font-Size="Large" ForeColor="Green" CausesValidation="False" 
            onclick="Button2_Click" /></td></tr>
        </font>
</table>
</asp:Content>

