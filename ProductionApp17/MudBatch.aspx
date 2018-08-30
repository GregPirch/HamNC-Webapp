<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="MudBatch.aspx.vb" Inherits="ProductionApp17.MudBatch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Records Found: <asp:Label ID="lRecordCount" runat="server" Text="Label" BorderStyle="None"></asp:Label></h2>
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="Lot_Num" CssClass="Grid" AutoGenerateColumns="False" Font-Size="Small" HorizontalAlign="Left" Width="95%">    
        <Columns>
            <asp:BoundField DataField="Batch_DateTimeEnd" HeaderText="Batch Date" SortExpression="BatchEnd" />
            <asp:BoundField DataField="Lot_Num" HeaderText="Lot" SortExpression="Lot" />
            <asp:BoundField DataField="Recipe_Name" HeaderText="Product" SortExpression="Recipe" />
            <asp:BoundField DataField="Batch_Desc" HeaderText="Status" SortExpression="Batch_Desc" />
            <asp:BoundField DataField="Actual_BoxCount" HeaderText="Box Count" SortExpression="BoxCount" />
            <asp:BoundField DataField="SetPnt_BoxWt" HeaderText="Box Weight" SortExpression="BoxWeight" />
            <asp:BoundField DataField="Actual_MixTime" HeaderText="Mix Time (secs)" SortExpression="MixTime" />
            <asp:BoundField DataField="Actual_TimeInEvac" HeaderText="Time In Evac (secs)" SortExpression="TimeInEvac" />
            <asp:BoundField DataField="Actual_TotalWaterWt" HeaderText="Total Water Wt" SortExpression="TotalWaterWt" />
            <asp:BoundField DataField="ChemSclAdjustMultiplier" HeaderText="Chem Scl Adjust Mult" SortExpression="ChemSclAdjustMultiplier" DataFormatString="{0:0.000}" />
            <asp:BoundField DataField="SetPnt_EvacVacuum" HeaderText="SetPnt Evac Vacuum" SortExpression="EvacVacuum" />
            <asp:BoundField DataField="Actual_ViscosityI_BU" HeaderText="Actual Viscosity I (BU)" SortExpression="ViscosityIBU" />
            <asp:BoundField DataField="Actual_ViscosityF_BU" HeaderText="Actual Viscosity F (BU)" SortExpression="ViscosityFBU" />
            <asp:BoundField DataField="Actual_Water" HeaderText="Actual Water" SortExpression="Water" DataFormatString="{0:0}"/>
            <asp:BoundField DataField="Actual_DryMixTime" HeaderText="Actual Dry Mix Time (secs)" SortExpression="DryMixTime" />
            <asp:BoundField DataField="Actual_TimeInMudMixer" HeaderText="Actual Time In Mud Mixer (secs)" SortExpression="TimeInMudMixer" />
            <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="Button2" runat="server" Text="Batch Details" CommandArgument = '<%#Eval("Lot_Num")%>'  OnClick = "Button2_Click" />
                <asp:Button ID="Button1" runat="server" Text="Edit QC" CommandArgument = '<%#Eval("Lot_Num")%>'  OnClick = "Button1_Click" />
            </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>

    <asp:Panel runat="server" DefaultButton="btnSearchProduct">
    <h2>Search By Recipe</h2>
    Recipe: <asp:TextBox ID="tbRecipe" runat="server"></asp:TextBox>
    Number of Batches to Show: <asp:TextBox ID="tbBatchesPrior" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearchProduct" runat="server" Text="Search" />
    </asp:Panel>

    <br/><br/>
    -Or-
    <br/><br/>
    <asp:Panel runat="server" DefaultButton="btnSearchDate">
    <h2>Search By Date</h2>
    Start Date: <asp:TextBox ID="txtStartDate" runat="server" ReadOnly = "false"></asp:TextBox>
    <br/>
    End Date: <asp:TextBox ID="txtEndDate" runat="server" ReadOnly = "false"></asp:TextBox>

    <asp:Button ID="btnSearchDate" runat="server" Text="Search By Date" />
    </asp:Panel>
</asp:Content>
