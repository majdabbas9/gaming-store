<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditMyComments.aspx.cs" Inherits="EditMyComments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<asp:GridView ID="GridViewComments" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="CommentID" 
         EmptyDataText="No Comments" 
        Height="90px" Width="882px" 
        onrowcancelingedit="GridViewComments_RowCancelingEdit" 
        onrowcommand="GridViewComments_RowCommand" 
        onrowediting="GridViewComments_RowEditing" 
        onrowupdating="GridViewComments_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="CommentID" InsertVisible="False" 
                SortExpression="CommentID">
                <EditItemTemplate>
                    <asp:Label ID="LabelCID" runat="server" Text='<%# Eval("CommentID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelCID" runat="server" Text='<%# Bind("CommentID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CommentName" SortExpression="CommentName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxN" runat="server" Text='<%# Bind("CommentName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Name Filed Missing" ForeColor=Red ControlToValidate="TextBoxN" ValidationGroup="Update"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CommentName") %>'></asp:Label>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CommentTitle" SortExpression="CommentTitle">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxT" runat="server" Text='<%# Bind("CommentTitle") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Title Filed Missing" ForeColor=Red ControlToValidate="TextBoxT" ValidationGroup="Update"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("CommentTitle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CommentB" SortExpression="CommentBody">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxB" runat="server" Text='<%# Bind("CommentBody") %>' TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Body Filed Missing" ForeColor=Red ControlToValidate="TextBoxB" ValidationGroup="Update"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("CommentBody") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CommentDate" SortExpression="CommentDate">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("CommentDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server"  CommandName="Update" ValidationGroup="Update"  CommandArgument="CommentID">Update</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
            </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LBDelte" runat="server" CommandName="RowDelete" CommandArgument='<%# Bind("CommentID") %>'>Delete</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

