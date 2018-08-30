<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DefaultUserLogin.aspx.vb" Inherits="ProductionApp17.DefaultUserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Form1 {
            width: 936px;
            height: 331px;
        }
    </style>
</head>
<body>
<form id="Form1" runat="server">
<asp:Login ID = "Login1" runat = "server" OnAuthenticate= "ValidateUser" Height="278px" Width="680px"></asp:Login>
</form>
</body>
</html>
