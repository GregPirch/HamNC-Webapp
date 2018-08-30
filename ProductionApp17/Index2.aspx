<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index2.aspx.vb" Inherits="ProductionApp17.Index" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<div>
    Current User: <% =Session("UserName") %> 

    <br />  
    <br />

    <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Vertical">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Index.aspx" Text="Home"/>
                    </Items>
                     <Items>
                         <asp:MenuItem NavigateUrl="#" Text="Production Menu">
                            <asp:MenuItem NavigateUrl="~/MudProd.aspx" Text = "Mud Production Entry"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/MudProd.aspx" Text="Mud Production Lookup"/></asp:MenuItem>
                    </Items>
                    <Items>
                         <asp:MenuItem NavigateUrl="#" Text="QC Menu">
                            <asp:MenuItem NavigateUrl="~/MudQC.aspx" Text = "Mud QC Entry"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/PaintQC.aspx" Text="Paint QC Entry"/></asp:MenuItem>
                    </Items>
                    <Items>
                        <asp:MenuItem NavigateUrl="~/DefaultUserLogin.aspx" Text="Account"/>
                    </Items>
     </asp:Menu>
 


    </div>
    </form>
</body>

</html>

