<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="Login.aspx.vb" Inherits="ProductionApp17.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID = "Login1" runat = "server" OnAuthenticate= "ValidateUser" Height="278px" Width="680px"></asp:Login>
</asp:Content>
