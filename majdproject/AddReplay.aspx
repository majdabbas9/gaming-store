<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddReplay.aspx.cs" Inherits="AddReplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<font size=4 color=green>
<table border=1 bgcolor=black>
<tr><td class="style4">CommentTitle</td><td class="style3">
    <asp:TextBox ID="TextBoxCommentTitle" runat="server" Width="650px"></asp:TextBox><asp:RequiredFieldValidator
        ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxCommentTitle" 
        ForeColor="Red">Title Is missing</asp:RequiredFieldValidator>
    </td></tr>
<tr><td class="style4">CommentName</td><td class="style3">
<font size=4 color=green>
    <asp:TextBox ID="TextBoxCommentName" runat="server" Width="650px"></asp:TextBox><asp:RequiredFieldValidator
        ID="RequiredFieldValidator2" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxCommentName" 
        ForeColor="Red">CommentName Is missing</asp:RequiredFieldValidator>
</font>
    </td></tr>
<tr><td class="style4">commentBody</td><td class="style3">
<font size=4 color=green>
    <asp:TextBox ID="TextBoxBody" runat="server" Width="650px" TextMode="MultiLine"></asp:TextBox><asp:RequiredFieldValidator
        ID="RequiredFieldValidator3" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxBody" 
        ForeColor="Red">Body Is missing</asp:RequiredFieldValidator>
</font>
    </td></tr>
<tr><td class="style4">
    <asp:Button ID="ButtonSend" runat="server" Text="Send" Height="30px" OnClientClick="return confirm('Are you sure?');"
        onclick="ButtonSend_Click" Width="225px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="LabelMSG" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
    </td></tr>
</table>
</font>
</asp:Content>

