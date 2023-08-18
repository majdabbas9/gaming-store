<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayPage.aspx.cs" Inherits="PayPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="LabelMSG" runat="server" Text=""></asp:Label>
<table border=1>
<tr><td>VisaNr&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBoxvnr" runat="server"></asp:TextBox> </td></tr>
<tr><td>VisavalidUnti<asp:DropDownList ID="DropDownListDay" runat="server" 
        AutoPostBack="True">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownListmonth" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListmonth_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownListYear" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownListYear_SelectedIndexChanged">
    </asp:DropDownList>
</td></tr>
<tr><td>
    <asp:Button ID="ButtonPay" runat="server" Text="Pay" 
        onclick="ButtonPay_Click" /></td></tr>

</table>
</asp:Content>

