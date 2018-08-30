<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="MudQCEdit.aspx.vb" Inherits="ProductionApp17.MudQCEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       
    <asp:Table ID="Table2" runat="Server" CellPadding="2" CellSpacing="1" Width="1000px"
        BorderColor="CadetBlue" Caption="QC Edit" BorderWidth="1" BorderStyle="Dashed">
            <asp:TableRow ID="TableRow18" runat="Server">
                <asp:TableCell ID="TableCell1" runat="Server" Width=20%>
                    Record Item
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="Server" Width=80%>
                    <asp:TextBox ID="txtKeyNumber" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow5" runat="Server">
                    <asp:TableCell ID="TableCell39" runat="Server" Width=20%>
                   48 Hour Viscosity
                </asp:TableCell>
                <asp:TableCell ID="TableCell40" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQC48HourViscosity" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow19" runat="Server">
                <asp:TableCell ID="TableCell41" runat="Server" Width=20%>
                    Hold Value
                </asp:TableCell>
                <asp:TableCell ID="TableCell42" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQCHoldValue" runat="server"></asp:TextBox>
                    <asp:DropDownList ID="ddlQCHighLowFlag" runat="server">
                        <asp:ListItem Text="" Value="" />
                        <asp:ListItem Text="H" Value="H" />
                        <asp:ListItem Text="L" Value="L" />
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow21" runat="Server">
                <asp:TableCell ID="TableCell45" runat="Server" Width=20%>
                    Re-Test Visc.
                </asp:TableCell>
                <asp:TableCell ID="TableCell46" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQCReTestViscosity" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="Server">
                <asp:TableCell ID="TableCell4" runat="Server" Width=20% >
                    Tape Out/In
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="Server">
                    Out:
                     <asp:DropDownList ID="ddlQCTapeOut" runat="server">
                        <asp:ListItem Text="" Value="" />
                        <asp:ListItem Text="A" Value="A" />
                        <asp:ListItem Text="B" Value="B" />
                        <asp:ListItem Text="C" Value="C" />
                        <asp:ListItem Text="D" Value="D" />
                        <asp:ListItem Text="F" Value="F" />
                    </asp:DropDownList>
                      In:
                     <asp:DropDownList ID="ddlQCTapeIn" runat="server">
                        <asp:ListItem Text="" Value="" />
                        <asp:ListItem Text="A" Value="A" />
                        <asp:ListItem Text="B" Value="B" />
                        <asp:ListItem Text="C" Value="C" />
                        <asp:ListItem Text="D" Value="D" />
                        <asp:ListItem Text="F" Value="F" />
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="Server">
                <asp:TableCell ID="TableCell6" runat="Server" Width=20%>
                    Crack
                </asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQCCrack" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>            
            <asp:TableRow ID="TableRow3" runat="Server">
                <asp:TableCell ID="TableCell8" runat="Server" Width=20%>
                    Pocking Start
                </asp:TableCell>
                <asp:TableCell ID="TableCell9" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQCPockingStart" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                <asp:TableRow ID="TableRow4" runat="Server">
                <asp:TableCell ID="TableCell10" runat="Server" Width=20%>
                    Pocking End
                </asp:TableCell>
                <asp:TableCell ID="TableCell11" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQCPockingEnd" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
           <asp:TableRow ID="TableRow16" runat="Server">
                <asp:TableCell ID="TableCell35" runat="Server" Width=20%>
                    QC Notes
                </asp:TableCell>
                <asp:TableCell ID="TableCell36" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQCNotes" TextMode="MultiLine" Rows="15" runat="server" Width=500px></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>    
    <br/><br/>
    <asp:Button ID="btnSave" runat="server" Text="Save" />
    <asp:HiddenField ID="txtQC48HourViscosity0" runat="server" />
    <asp:HiddenField ID="txtQCHoldValue0" runat="server" />
    <asp:HiddenField ID="txtQCHighLowFlag0" runat="server" />
    <asp:HiddenField ID="txtQCRetestViscosity0" runat="server" />
    <asp:HiddenField ID="txtQCTapeOut0" runat="server" />
    <asp:HiddenField ID="txtQCTapeIn0" runat="server" />
    <asp:HiddenField ID="txtQCCrack0" runat="server" />
    <asp:HiddenField ID="txtQCPockingStart0" runat="server" />
    <asp:HiddenField ID="txtQCPockingEnd0" runat="server" />

</asp:Content>
