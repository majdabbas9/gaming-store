<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProduct.aspx.cs" Inherits="ViewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:DropDownList ID="DropDownListT" runat="server"  DataTextField="TypeName" 
        DataValueField="TypeName">
    </asp:DropDownList>
    <asp:Button ID="ButtonShow" runat="server" Text="Show Product By The Selected Type" 
    onclick="ButtonShow_Click" />
    <asp:Button ID="ButtonSearch" runat="server" Text="Search" 
        onclick="ButtonSearch_Click" ValidationGroup="Search" />
    <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBoxSearch" ErrorMessage="RequiredFieldValidator" 
        ForeColor="Red" ValidationGroup="Search">Product Name Missing</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="LabelMSG" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
    <asp:GridView ID="GridViewST" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ProductID" Width="883px" 
        onrowcommand="GridViewST_RowCommand" EmptyDataText="No Result">
        <Columns>
        <asp:TemplateField headertext="ProductID">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
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
                <asp:LinkButton ID="LinkButtonLike" runat="server" CommandName="Like" CommandArgument='<%# Bind("ProductID") %>'>Like</asp:LinkButton><br />
                <asp:LinkButton ID="LinkButtonDisLike" runat="server" CommandName="DisLike" CommandArgument='<%# Bind("ProductID") %>'>DisLike</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=Likes>
            <ItemTemplate>
                <asp:Label ID="Label112" runat="server" Text='<%# Bind("Likes") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=DisLikes>
            <ItemTemplate>
            <asp:Label ID="Label111" runat="server" Text='<%# Bind("DisLikes") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton runat="server" commandname="AddTomycart" CommandArgument='<%# Eval("ProductID") %>'>Add To My cart</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonAddReplay" CommandName="AddReplay" runat="server" CommandArgument='<%# Eval("ProductID") %>'>AddReplay</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonShowAllReplays" CommandName="ShowAllReplays" runat="server" CommandArgument='<%# Eval("ProductID") %>'>ShowReplays</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

