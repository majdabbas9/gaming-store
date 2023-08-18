<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowMyProFile.aspx.cs" Inherits="ShowMyProFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            width: 66px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table border=1>
<tr><td>username
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="UserName Required" ControlToValidate="TextBoxUN" 
        ForeColor="Red">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
        ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="username required" ControlToValidate="TextBoxUN2" 
        ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:CompareValidator
            ID="CompareValidator1" runat="server" 
        ErrorMessage="username missmatch" ControlToCompare="TextBoxUN2" 
        ControlToValidate="TextBoxUN" ForeColor="Red">*</asp:CompareValidator></td>
<td class="style4"><asp:TextBox ID="TextBoxUN" runat="server"></asp:TextBox></td><td>
    <asp:TextBox ID="TextBoxUN2" runat="server"></asp:TextBox></td></tr>
<tr><td>password
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="password required" ControlToValidate="TextBoxPW" 
        ForeColor="Red">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
        ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="password required" ControlToValidate="TextBoxPW2" 
        ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:CompareValidator
            ID="CompareValidator2" runat="server" 
        ErrorMessage="password missmatch" ControlToCompare="TextBoxPW2" 
        ControlToValidate="TextBoxPW" ForeColor="Red">*</asp:CompareValidator></td>
<td class="style4"><asp:TextBox ID="TextBoxPW" runat="server"></asp:TextBox></td><td>
    <asp:TextBox ID="TextBoxPW2" runat="server"></asp:TextBox></td></tr>
<tr><td>email
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ErrorMessage="email required" ControlToValidate="TextBoxE" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator
        ID="RequiredFieldValidator6" runat="server" ErrorMessage="email required" 
        ControlToValidate="TextBoxE2" ForeColor="Red">*</asp:RequiredFieldValidator>
    <asp:CompareValidator
            ID="CompareValidator3" runat="server" ErrorMessage="email missmatch" 
        ControlToCompare="TextBoxE2" ControlToValidate="TextBoxE" ForeColor="Red">*</asp:CompareValidator></td>
<td class="style4"><asp:TextBox ID="TextBoxE" runat="server"></asp:TextBox></td><td>
    <asp:TextBox ID="TextBoxE2" runat="server"></asp:TextBox></td></tr>
<tr><td>DOB
 <asp:DropDownList ID="DropDownListDay" runat="server" AutoPostBack="True"></asp:DropDownList>
 <asp:DropDownList ID="DropDownListmonth" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListmonth_SelectedIndexChanged" 
        style="height: 22px"></asp:DropDownList>
 <asp:DropDownList ID="DropDownListYear" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListYear_SelectedIndexChanged"></asp:DropDownList>
</td></tr>
<tr><td>
    <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
    </td><td class="style4">
        <asp:Button ID="Button2" runat="server" Text="Cancel" CausesValidation="False" 
            onclick="Button2_Click" /></td></tr>
</table>
</asp:Content>

