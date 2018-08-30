<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="MudProdEdit.aspx.vb" Inherits="ProductionApp17.MudProdEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:Table ID="Table2" runat="Server" CellPadding="2" CellSpacing="1" Width="1000px"
        BorderColor="CadetBlue" Caption="Production Edit" BorderWidth="1" BorderStyle="Dashed">
            <asp:TableRow ID="TableRow18" runat="Server">
                <asp:TableCell ID="TableCell39" runat="Server" Width=20%>
                    Record Item
                </asp:TableCell>
                <asp:TableCell ID="TableCell40" runat="Server" Width=80%>
                    <asp:TextBox ID="txtKeyNumber" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow19" runat="Server">
                <asp:TableCell ID="TableCell41" runat="Server" Width=20%>
                    Run Date / Time
                </asp:TableCell>
                <asp:TableCell ID="TableCell42" runat="Server" Width=80%>
                    <asp:TextBox ID="txtRunDate" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow21" runat="Server">
                <asp:TableCell ID="TableCell45" runat="Server" Width=20%>
                    Package Date / Time
                </asp:TableCell>
                <asp:TableCell ID="TableCell46" runat="Server" Width=80%>
                    <asp:TextBox ID="txtPackageDate" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="Server">
                <asp:TableCell ID="TableCell4" runat="Server" Width=20% >
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
            <asp:TableRow ID="TableRow23" runat="Server">
                <asp:TableCell ID="TableCell49" runat="Server" Width=20%>
                    Last User
                </asp:TableCell>
                <asp:TableCell ID="TableCell50" runat="Server" Width=80%>
                    <asp:TextBox ID="txtLastUser" runat="server" ReadOnly="true"></asp:TextBox>
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
                    <asp:TextBox ID="txtLastUpdated" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>    
    <br/><br/>
    <asp:Button ID="btnSave" runat="server" Text="Save" />
    <asp:HiddenField ID="txtYield0" runat="server" />

</asp:Content>
