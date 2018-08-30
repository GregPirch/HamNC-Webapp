<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MudProdLog.aspx.vb" Inherits="ProductionApp17.MudProdLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
<form id="form1" runat="server">
<div>
Mud Production 


</div>
    <asp:GridView ID="GridView1" runat="server" CssClass="Grid" AutoGenerateColumns="False">    
        <Columns>
            <asp:BoundField DataField="RunDate" HeaderText="Run Date" SortExpression="RunDate" />
            <asp:BoundField DataField="ProductKey" HeaderText="Prod" SortExpression="ProductKey" />
            <asp:BoundField DataField="BatchNumber" HeaderText="Batch" SortExpression="BatchNumber" />
            <asp:BoundField DataField="BoxWeightVolume" HeaderText="Box Wgt-Vol" SortExpression="BoxWeightVolume" />
            <asp:BoundField DataField="ViscosityInLine" HeaderText="Viscosity InLine" SortExpression="ViscosityInLine" />
            <asp:BoundField DataField="ViscosityInitial" HeaderText="Viscosity Initial" SortExpression="ViscosityInitial" />
            <asp:BoundField DataField="ViscosityFinal" HeaderText="Viscosity Final" SortExpression="ViscosityFinal" />
            <asp:BoundField DataField="WaterInitial" HeaderText="Water Initial" SortExpression="WaterInitial" />
            <asp:BoundField DataField="WaterFinal" HeaderText="Water Final" SortExpression="WaterFinal" />
            <asp:BoundField DataField="Amps" HeaderText="Amps" SortExpression="Amps" />
            <asp:BoundField DataField="PSI" HeaderText="PSI" SortExpression="PSI" />
            <asp:BoundField DataField="MixTime" HeaderText="Mix Time" SortExpression="MixTime" />
            <asp:BoundField DataField="Yield" HeaderText="Yield" SortExpression="Yield" />
            <asp:BoundField DataField="PackageDate" HeaderText="Package Date" SortExpression="PackageDate" />
            <asp:BoundField DataField="FirstName" HeaderText="Operator" SortExpression="FirstName" />
            <asp:BoundField DataField="Shift" HeaderText="Shift" SortExpression="Shift" />
            <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" /> 
        </Columns>
    </asp:GridView>
</form>
</body>
</html>
