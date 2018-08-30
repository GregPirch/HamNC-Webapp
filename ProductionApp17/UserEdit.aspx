<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="UserEdit.aspx.vb" Inherits="ProductionApp17.UserEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Table ID="Table2" runat="Server" CellPadding="2" CellSpacing="1" Width="1000px"
        BorderColor="CadetBlue" Caption="Production Edit" BorderWidth="1" BorderStyle="Dashed">
            <asp:TableRow ID="TableRow18" runat="Server">
                <asp:TableCell ID="TableCell39" runat="Server" Width=20%>
                    User Key
                </asp:TableCell>
                <asp:TableCell ID="TableCell40" runat="Server" Width=80%>
                    <asp:TextBox ID="txtUsersKeyNumber" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow19" runat="Server">
                <asp:TableCell ID="TableCell41" runat="Server" Width=20%>
                    First Name
                </asp:TableCell>
                <asp:TableCell ID="TableCell42" runat="Server" Width=80%>
                    <asp:TextBox ID="txtFirstName" runat="server" ></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow21" runat="Server">
                <asp:TableCell ID="TableCell45" runat="Server" Width=20%>
                    Last Name
                </asp:TableCell>
                <asp:TableCell ID="TableCell46" runat="Server" Width=80%>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow5" runat="Server">
                <asp:TableCell ID="TableCell12" runat="Server" Width=20%>
                    Address
                </asp:TableCell>
                <asp:TableCell ID="TableCell13" runat="Server" Width=80%>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow6" runat="Server">
                <asp:TableCell ID="TableCell14" runat="Server" Width=20%>
                    City
                </asp:TableCell>
                <asp:TableCell ID="TableCell15" runat="Server" Width=80%>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow7" runat="Server">
                <asp:TableCell ID="TableCell16" runat="Server" Width=20%>
                    State
                </asp:TableCell>
                <asp:TableCell ID="TableCell18" runat="Server" Width=80%>
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow17" runat="Server">
                <asp:TableCell ID="TableCell37" runat="Server" Width=20%>
                    Zip
                </asp:TableCell>
                <asp:TableCell ID="TableCell38" runat="Server" Width=80%>
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow8" runat="Server">
                <asp:TableCell ID="TableCell19" runat="Server" Width=20%>
                    Phone
                </asp:TableCell>
                <asp:TableCell ID="TableCell20" runat="Server" Width=80%>
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow9" runat="Server">
                <asp:TableCell ID="TableCell21" runat="Server" Width=20%>
                    Email
                </asp:TableCell>
                <asp:TableCell ID="TableCell22" runat="Server" Width=80%>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow10" runat="Server">
                <asp:TableCell ID="TableCell23" runat="Server" Width=20%>
                    User ID
                </asp:TableCell>
                <asp:TableCell ID="TableCell24" runat="Server" Width=80%>
                    <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow11" runat="Server">
                <asp:TableCell ID="TableCell25" runat="Server" Width=20%>
                    Password 
                </asp:TableCell>
                <asp:TableCell ID="TableCell26" runat="Server" Width=80%>
                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:Button ID="btnChgPwd" runat="server" Text="Change Password" />
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow12" runat="Server">
                <asp:TableCell ID="TableCell27" runat="Server" Width=20%>
                    User Type
                </asp:TableCell>
                <asp:TableCell ID="TableCell28" runat="Server" Width=80%>
                        <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem Text="" Value="" />
                        <asp:ListItem Text="S" Value="S" />
                        <asp:ListItem Text="A" Value="A" />
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow16" runat="Server">
                <asp:TableCell ID="TableCell35" runat="Server" Width=20%>
                    Notes
                </asp:TableCell>
                <asp:TableCell ID="TableCell36" runat="Server" Width=80%>
                    <asp:TextBox ID="txtNotes" TextMode="MultiLine" Rows="15" runat="server" Width=500px></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow23" runat="Server">
                <asp:TableCell ID="TableCell49" runat="Server" Width=20%>
                    Last Login
                </asp:TableCell>
                <asp:TableCell ID="TableCell50" runat="Server" Width=80%>
                    <asp:TextBox ID="txtLastLogin" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow24" runat="Server">
                <asp:TableCell ID="TableCell51" runat="Server" Width=20%>
                    Date Created
                </asp:TableCell>
                <asp:TableCell ID="TableCell52" runat="Server" Width=80%>
                    <asp:TextBox ID="txtDateCreated" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow25" runat="Server">
                <asp:TableCell ID="TableCell53" runat="Server" Width=20%>
                    Last Updated
                </asp:TableCell>
                <asp:TableCell ID="TableCell54" runat="Server" Width=80%>
                    <asp:TextBox ID="txtLastUpdate" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>    
    <br/><br/>
    <asp:Button ID="btnSave" runat="server" Text="Save" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />

</asp:Content>
