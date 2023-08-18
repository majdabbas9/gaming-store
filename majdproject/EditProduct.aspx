<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<asp:Label ID="LabelMSG" runat="server" Text=""></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownListT" runat="server" AutoPostBack="True" DataTextField="TypeName" 
        DataValueField="TypeName">
    </asp:DropDownList>
    <asp:Button ID="ButtonShow" runat="server" Text="Show Product By The Selected Type" 
    onclick="ButtonShow_Click" />
    &nbsp;<asp:Button ID="ButtonSeach" runat="server" Text="SearchByProductName" 
        onclick="ButtonSeach_Click" ValidationGroup="Search"/>
    <asp:TextBox ID="TextBoxSearch" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBoxSearch" 
        ForeColor="Red" ValidationGroup="Search">ProdcutName Missing</asp:RequiredFieldValidator>
    <asp:GridView ID="GridViewP" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ProductID" onrowcancelingedit="GridViewP_RowCancelingEdit" 
        onrowcommand="GridViewP_RowCommand" onrowdeleting="GridViewP_RowDeleting" 
        onrowediting="GridViewP_RowEditing" onrowupdating="GridViewP_RowUpdating" 
        ShowFooter="True" EmptyDataText="No Result">
        <Columns>
            <asp:TemplateField HeaderText="ProductID" InsertVisible="False" 
                SortExpression="ProductID">
                <ItemTemplate>
                    <asp:Label ID="LabelPID" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="ProductName" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="LabelPN" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxPN" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ErrorMessage="RequiredFieldValidator" Text="*ProductName field missing" ForeColor=Red ControlToValidate=TextBoxPN ValidationGroup=UpdateGroup></asp:RequiredFieldValidator><br />
                </EditItemTemplate>
                <FooterTemplate>
                <asp:TextBox ID="TextBoxPN" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ErrorMessage="RequiredFieldValidator" Text="*ProductName field missing" ForeColor=Red ControlToValidate=TextBoxPN ValidationGroup=InsertGroup></asp:RequiredFieldValidator><br />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                <ItemTemplate>
                    <asp:Label ID="LabelT" runat="server" Text='<%# Bind("TypeName") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownListEditType" DataTextField="TypeName" DataValueField="TypesID" DataSource='<%#FillTypes() %>' runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownListFooterType" DataTextField="TypeName" DataValueField="TypesID" DataSource='<%#FillTypes() %>' runat="server">
                    </asp:DropDownList>
                    <asp:TextBox ID="TextBoxTF" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="Price">
                <ItemTemplate>
                    <asp:Label ID="LabelP" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxP" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3e" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Price field missing" ForeColor=Red ControlToValidate=TextBoxP ValidationGroup=UpdateGroup></asp:RequiredFieldValidator><br />
                    <asp:RangeValidator ID="RangeValidator3e" runat="server" ErrorMessage="RangeValidator" Text="*price must be between 0 and 100000" ControlToValidate=TextBoxP MinimumValue=0 MaximumValue=100000 Type=Integer ForeColor=Red ValidationGroup=UpdateGroup></asp:RangeValidator>
                </EditItemTemplate>
                <FooterTemplate>
                <asp:TextBox ID="TextBoxP" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Price field missing" ForeColor=Red ControlToValidate=TextBoxP ValidationGroup=InsertGroup></asp:RequiredFieldValidator><br />
                    <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="RangeValidator" Text="*price must be between 0 and 100000" ControlToValidate=TextBoxP MinimumValue=0 MaximumValue=100000 Type=Integer ForeColor=Red ValidationGroup=InsertGroup></asp:RangeValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Warranty" SortExpression="Warranty">
                <ItemTemplate>
                    <asp:Label ID="LabelW" runat="server" Text='<%# Bind("Warranty") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxW" runat="server" Text='<%# Bind("Warranty") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2e" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Warranty field missing" ForeColor=Red ControlToValidate=TextBoxW ValidationGroup=UpdateGroup></asp:RequiredFieldValidator><br />
                    <asp:RangeValidator ID="RangeValidator2e" runat="server" ErrorMessage="RangeValidator" ControlToValidate=TextBoxW ForeColor=Red Type=Integer Text="*Warranty must be between 0 and 5"  MinimumValue=0 MaximumValue=5 ValidationGroup=UpdateGroup></asp:RangeValidator>
                </EditItemTemplate>
                <FooterTemplate>
                <asp:TextBox ID="TextBoxW" runat="server">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Warranty field missing" ForeColor=Red ControlToValidate=TextBoxW ValidationGroup=InsertGroup></asp:RequiredFieldValidator><br />
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="RangeValidator" ControlToValidate=TextBoxW ForeColor=Red Type=Integer Text="*Warranty must be between 0 and 5"  MinimumValue=0 MaximumValue=5 ValidationGroup=InsertGroup></asp:RangeValidator>
                </FooterTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <ItemTemplate>
                    <asp:Label ID="LabelQ" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxQ" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1e" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Quantity field missing" ForeColor=Red ControlToValidate=TextBoxQ ValidationGroup=UpdateGroup></asp:RequiredFieldValidator><br />
                    <asp:RangeValidator ID="RangeValidator1e" runat="server" ErrorMessage="RangeValidator" ControlToValidate=TextBoxQ ForeColor=Red Text="*Quantity must be between 0 and 1000" Type=Integer MinimumValue=0 MaximumValue=1000 ValidationGroup=UpdateGroup></asp:RangeValidator>
                </EditItemTemplate>
                <FooterTemplate>
                <asp:TextBox ID="TextBoxQ" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="*Quantity field missing" ForeColor=Red ControlToValidate=TextBoxQ ValidationGroup=InsertGroup></asp:RequiredFieldValidator><br />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator" ControlToValidate=TextBoxQ ForeColor=Red Text="*Quantity must be between 0 and 1000" Type=Integer MinimumValue=0 MaximumValue=1000 ValidationGroup=InsertGroup></asp:RangeValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Photo" SortExpression="Photo">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Photo") %>' Width=150 Height=150/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUploadEdit" runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                <asp:FileUpload ID="FileUploadFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Update" OnClientClick="return confirm('Are you sure?');" ValidationGroup="UpdateGroup">Update</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Cancel" OnClientClick="return confirm('Are you sure?');">Cancel</asp:LinkButton>
            </EditItemTemplate>
            <FooterTemplate>
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Insert" OnClientClick="return confirm('Are you sure?');" ValidationGroup="InsertGroup">Insert</asp:LinkButton>
            </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
            <ItemTemplate>
            <asp:LinkButton ID="LinkButton6" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure?');">Delete</asp:LinkButton>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

