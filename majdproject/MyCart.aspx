<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyCart.aspx.cs" Inherits="AddToMyCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:GridView ID="GridViewCart" runat="server" DataKeyNames="CartID" 
        AutoGenerateColumns="False" Width="885px" 
        onrowdeleting="GridViewCart_RowDeleting" EmptyDataText="No Result">
    <Columns>
    <asp:TemplateField HeaderText="CartID">
    <ItemTemplate>
    <asp:Label ID="LabelC" runat="server" Text='<%# Eval("CartID") %>'></asp:Label>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="ProductName" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="LabelPN" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
    <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="LabelP" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Warranty" SortExpression="Warranty">
                <ItemTemplate>
                    <asp:Label ID="LabelW" runat="server" Text='<%# Eval("Warranty") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <ItemTemplate>
                    <asp:Label ID="LabelQ" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                <ItemTemplate>
                    <asp:Label ID="LabelT" runat="server" Text='<%# Eval("TypeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Photo" SortExpression="Photo">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Photo") %>' Width=150 Height=150 />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?');">Delete</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
    </Columns>
    </asp:GridView>
   <center>
    <asp:Button ID="Button1"  runat="server" Text="Pay" Height="30px" Width="106px" 
           onclick="Button1_Click" />
    </center>
</asp:Content>

