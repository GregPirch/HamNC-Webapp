<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="MudProdEntry.aspx.vb" Inherits="ProductionApp17.MudProdEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Table ID="Table2" runat="Server" CellPadding="2" CellSpacing="1" Width="1000px"
        BorderColor="CadetBlue" Caption="Add New Production Entry" BorderWidth="1" BorderStyle="Dashed">
            <asp:TableRow ID="TableRow1" runat="Server" BorderWidth="1">
                <asp:TableCell ID="TableCell4" runat="Server" Width=20% BorderWidth="1">
                    Operator
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="Server">
                     <asp:DropDownList ID="ddlOperators" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="Server">
                <asp:TableCell ID="TableCell6" runat="Server" Width=20%>
                    Bag Dump
                </asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="Server" Width=80%>
                    <asp:DropDownList ID="ddlBagDump" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>            
            <asp:TableRow ID="TableRow3" runat="Server">
                <asp:TableCell ID="TableCell8" runat="Server" Width=20%>
                    Shift
                </asp:TableCell>
                <asp:TableCell ID="TableCell9" runat="Server" Width=80%>
                    <asp:DropDownList ID="ddlShift" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="Server">
                <asp:TableCell ID="TableCell10" runat="Server" Width=20%>
                    Product
                </asp:TableCell>
                <asp:TableCell ID="TableCell11" runat="Server" Width=80%>
                    <asp:DropDownList ID="ddlProduct" runat="server"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow5" runat="Server">
                <asp:TableCell ID="TableCell12" runat="Server" Width=20%>
                    Batch
                </asp:TableCell>
                <asp:TableCell ID="TableCell13" runat="Server" Width=80%>
                    <asp:TextBox ID="txtBatch" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow6" runat="Server">
                <asp:TableCell ID="TableCell14" runat="Server" Width=20%>
                    Batch %
                </asp:TableCell>
                <asp:TableCell ID="TableCell15" runat="Server" Width=80%>
                    <asp:TextBox ID="txtBatchPcnt" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow7" runat="Server">
                <asp:TableCell ID="TableCell16" runat="Server" Width=20%>
                    Water Initial
                </asp:TableCell>
                <asp:TableCell ID="TableCell18" runat="Server" Width=80%>
                    <asp:TextBox ID="txtWaterInitial" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow17" runat="Server">
                <asp:TableCell ID="TableCell37" runat="Server" Width=20%>
                    Water Final
                </asp:TableCell>
                <asp:TableCell ID="TableCell38" runat="Server" Width=80%>
                    <asp:TextBox ID="txtWaterFinal" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow8" runat="Server">
                <asp:TableCell ID="TableCell19" runat="Server" Width=20%>
                    Viscosity Initial
                </asp:TableCell>
                <asp:TableCell ID="TableCell20" runat="Server" Width=80%>
                    <asp:TextBox ID="txtViscosityInit" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow9" runat="Server">
                <asp:TableCell ID="TableCell21" runat="Server" Width=20%>
                    Viscosity InLine
                </asp:TableCell>
                <asp:TableCell ID="TableCell22" runat="Server" Width=80%>
                    <asp:TextBox ID="txtViscosityInline" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow10" runat="Server">
                <asp:TableCell ID="TableCell23" runat="Server" Width=20%>
                    Amps
                </asp:TableCell>
                <asp:TableCell ID="TableCell24" runat="Server" Width=80%>
                    <asp:TextBox ID="txtAmps" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow11" runat="Server">
                <asp:TableCell ID="TableCell25" runat="Server" Width=20%>
                    PSI
                </asp:TableCell>
                <asp:TableCell ID="TableCell26" runat="Server" Width=80%>
                    <asp:TextBox ID="txtPSI" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow12" runat="Server">
                <asp:TableCell ID="TableCell27" runat="Server" Width=20%>
                    Mix Time
                </asp:TableCell>
                <asp:TableCell ID="TableCell28" runat="Server" Width=80%>
                    <asp:TextBox ID="txtMixTime" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow13" runat="Server">
                <asp:TableCell ID="TableCell29" runat="Server" Width=20%>
                    Viscosity Final
                </asp:TableCell>
                <asp:TableCell ID="TableCell30" runat="Server" Width=80%>
                    <asp:TextBox ID="txtViscosityFinal" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow14" runat="Server">
                <asp:TableCell ID="TableCell31" runat="Server" Width=20%>
                    Yield
                </asp:TableCell>
                <asp:TableCell ID="TableCell32" runat="Server" Width=80%>
                    <asp:TextBox ID="txtYield" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow15" runat="Server">
                <asp:TableCell ID="TableCell33" runat="Server" Width=20%>
                    Box Wgt-Vol
                </asp:TableCell>
                <asp:TableCell ID="TableCell34" runat="Server" Width=80%>
                    <asp:TextBox ID="txtBoxWgtVol" runat="server"></asp:TextBox>
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
        </asp:Table>    
    <br/><br/>
    <asp:Button ID="btnSave" runat="server" Text="Save" />
</asp:Content>
