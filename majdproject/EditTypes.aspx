<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditTypes.aspx.cs" Inherits="EditTypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="LabelMSG" runat="server" ForeColor="Red"></asp:Label>
    <asp:GridView ID="GridViewTypes" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="TypesID" ShowFooter="True" 
    onrowcancelingedit="GridViewTypes_RowCancelingEdit" 
    onrowcommand="GridViewTypes_RowCommand" 
    onrowdeleting="GridViewTypes_RowDeleting" 
    onrowediting="GridViewTypes_RowEditing" 
    onrowupdating="GridViewTypes_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="TypesID" InsertVisible="False" 
                SortExpression="TypesID">
                <ItemTemplate>
                    <asp:Label ID="LabelTID" runat="server" Text='<%# Bind("TypesID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TypeName" SortExpression="TypeName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxEditTN" runat="server" Text='<%# Bind("TypeName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="TypeName is missing" ForeColor=Red ControlToValidate="TextBoxEditTN" ValidationGroup="Update"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelTN" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                <asp:TextBox ID="TextBoxFooterTN" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Text="TypeName is missing" ForeColor=Red ControlToValidate="TextBoxFooterTN" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
            <asp:LinkButton ID="LinkButtonUpdate" runat="server" CommandName="Update" ValidationGroup="Update">Update</asp:LinkButton>
            <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
            </EditItemTemplate>
            <FooterTemplate>
            <asp:LinkButton ID="LinkButtonInsert" runat="server" CommandName="Insert" ValidationGroup="Insert">Insert</asp:LinkButton>
            </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>

