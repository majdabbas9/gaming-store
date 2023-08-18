<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowAllComments.aspx.cs" Inherits="ShowAllComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="LabelMSG" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridViewComments" runat="server" AutoGenerateColumns="False" 
        Width="880px" >
        <Columns>
            <asp:TemplateField HeaderText="UserName" SortExpression="UserName">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CommentName" SortExpression="CommentName">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CommentName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CommentName") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CommentTitle" SortExpression="CommentTitle">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("CommentTitle") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CommentTitle") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CommentBody" SortExpression="CommentBody">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("CommentBody") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CommentBody") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CommentDate" SortExpression="CommentDate">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("CommentDate") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("CommentDate") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

