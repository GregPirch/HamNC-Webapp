<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="MudProd.aspx.vb" Inherits="ProductionApp17.MudProd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="KeyNumber" CssClass="Grid" AutoGenerateColumns="False" Font-Size="Small" HorizontalAlign="Left" Width="1018px">    
        <Columns>
            <asp:BoundField DataField="RunDate" HeaderText="Run Date" SortExpression="RunDate" />
            <asp:BoundField DataField="ProductName" HeaderText="Prod" SortExpression="ProductName" />
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
            <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text="Edit" CommandArgument = '<%#Eval("KeyNumber")%>'  OnClick = "Button1_Click" />
            </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>

    <h2>Search By Product</h2>
    Product: <asp:DropDownList ID="ddlProduct" runat="server"></asp:DropDownList>
    Batches Prior: <asp:TextBox ID="tbBatchesPrior" runat="server"></asp:TextBox>
    Show Archive: <asp:CheckBox ID="cbShowArchive" runat="server" />
    <asp:Button ID="btnSearchProduct" runat="server" Text="Search" />
    
    <br/><br/>
    -Or-
    <br/><br/>
    <h2>Search By Date</h2>
    <asp:RadioButtonList ID="rbDateSearch" runat="server">
    <asp:ListItem Text="Run Date" Value="RunDate" />
    <asp:ListItem Text="Package Date" Value="PackageDate" />
    </asp:RadioButtonList>
    Start Date: <asp:TextBox ID="txtStartDate" runat="server" ReadOnly = "false"></asp:TextBox>
    <br/>
    End Date: <asp:TextBox ID="txtEndDate" runat="server" ReadOnly = "false"></asp:TextBox>

    <asp:Button ID="btnSearchDate" runat="server" Text="Search By Date" />
</asp:Content>
