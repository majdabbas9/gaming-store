<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditReplays.aspx.cs" Inherits="EditReplays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:GridView ID="GridViewST" runat="server" AutoGenerateColumns="False"  DataKeyNames="ProductID"
         Width="883px" 
         EmptyDataText="No Replays for this product" 
        onrowcommand="GridViewST_RowCommand">
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
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonShowAll" runat="server" CommandName="ShowAllReplays" CommandArgument='<%# Bind("ProductID")  %>' >ShowAllReplays</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
           </Columns>
           </asp:GridView>
    </asp:Content>

