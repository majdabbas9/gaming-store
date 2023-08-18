<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="paytest.aspx.cs" Inherits="paytest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <asp:RangeValidator ID="RangeValidator1" runat="server" 
        ControlToValidate="TextBox1" ErrorMessage="RangeValidator" ForeColor="Red" 
        MaximumValue="0" ValidationGroup="InsertGroup">x field must be greater than 0</asp:RangeValidator>
    <asp:CustomValidator ID="CustomValidator1" runat="server" 
        ErrorMessage="CustomValidator"></asp:CustomValidator>
</asp:Content>

