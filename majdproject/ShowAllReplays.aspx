<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowAllReplays.aspx.cs" Inherits="ShowAllReplays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
 <asp:GridView ID="GridViewST" runat="server" AutoGenerateColumns="False" 
         Width="883px" 
         EmptyDataText="No Replays for this product">
        <Columns>
        <asp:TemplateField HeaderText="ProductName" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="LabelPN" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="LabelP" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Warranty" SortExpression="Warranty">
                <ItemTemplate>
                    <asp:Label ID="LabelW" runat="server" Text='<%# Bind("Warranty") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <ItemTemplate>
                    <asp:Label ID="LabelQ" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                <ItemTemplate>
                    <asp:Label ID="LabelT" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Photo" SortExpression="Photo">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Photo") %>' Width=150 Height=150 />
                </ItemTemplate>
            </asp:TemplateField>
           </Columns>
           </asp:GridView>
    <asp:GridView ID="GridViewAR" runat="server" AutoGenerateColumns="False" 
         Height="92px" Width="881px" EmptyDataText="No Replays for this product">
        <Columns>
            <asp:TemplateField HeaderText="ReplayerName" SortExpression="ReplayerName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ReplayerName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ReplayerName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ReplayeTiltle" SortExpression="ReplayeTiltle">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ReplayeTiltle") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("ReplayeTiltle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ReplayBody" SortExpression="ReplayBody">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ReplayBody") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("ReplayBody") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

