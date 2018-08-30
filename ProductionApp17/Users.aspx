<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" 
    CodeBehind="Users.aspx.vb" Inherits="ProductionApp17.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="UsersKeyNumber" CssClass="Grid" AutoGenerateColumns="False" Font-Size="Small" HorizontalAlign="Left" Width="1018px">    
        <Columns>
            <asp:BoundField DataField="UsersKeyNumber" HeaderText="User ID" SortExpression="UsersKeyNumber" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
            <asp:BoundField DataField="LastLogin" HeaderText="Last Login" SortExpression="Last Login" />
            <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Edit" CommandArgument = '<%#Eval("UsersKeyNumber")%>'  OnClick = "Button1_Click" />
            </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>
    <br/><br/>
    <asp:Button ID="btnAddNewUser" runat="server" Text="Add New User" OnClick = "btnAddNewUser_Click" />

</asp:Content>
