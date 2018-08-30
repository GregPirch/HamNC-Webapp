<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="MudBatchEdit.aspx.vb" Inherits="ProductionApp17.MudBatchEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       
    <asp:Table ID="Table2" runat="Server" CellPadding="2" CellSpacing="1" Width="1000px"
        BorderColor="CadetBlue" Caption="QC Edit" BorderWidth="1" BorderStyle="Dashed">
            <asp:TableRow ID="TableRow18" runat="Server">
                <asp:TableCell ID="TableCell1" runat="Server" Width=20%>
                    Lot
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="Server" Width=80%>
                    <asp:TextBox ID="txtLot_Num" runat="server" ReadOnly="true"></asp:TextBox>
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
                    Hold Value (If Not Between)
                </asp:TableCell>
                <asp:TableCell ID="TableCell42" runat="Server" >
                    <asp:TextBox ID="txtQCRecipeLabMinVisc" runat="server" BackColor="#CCCCCC" ReadOnly="True" BorderStyle="None" Width="50"></asp:TextBox>
                    -
                    <asp:TextBox ID="txtQCRecipeLabMaxVisc" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="50" BorderStyle="None"></asp:TextBox>
                    &nbsp &nbsp &nbsp &nbsp
                    <asp:TextBox ID="txtHoldStatus" runat="server" BackColor="transparent" ReadOnly="True" Width="75" BorderStyle="None" ForeColor="Red" Font-Bold="True"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
                    <asp:TableRow ID="TableRow9" runat="Server">
                <asp:TableCell ID="TableCell17" runat="Server" Width=20%>
                    
                </asp:TableCell>
                <asp:TableCell ID="TableCell18" runat="Server" >
                    <asp:Button ID="btnHold" runat="server" Text="Hold" /> &nbsp
                    <asp:Button ID="btnReRun" runat="server" Text="Re-Run" />&nbsp
                    <asp:Button ID="btnReject" runat="server" Text="Reject" />&nbsp
                    <asp:Button ID="btnRelease" runat="server" Text="Release" />&nbsp
                    <asp:TextBox ID="txtReason_Notes" TextMode="MultiLine" Rows="5" runat="server" Width=200px Visible="False"></asp:TextBox>
                     &nbsp
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="False" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow8" runat="Server">
                <asp:TableCell ID="TableCell15" runat="Server" Width=20%>
                    Status History
                </asp:TableCell>
                <asp:TableCell ID="TableCell16" runat="Server" Width=80%>
                    <asp:Button ID="btnShowHistory" runat="server" Text="Show History" />
                    &nbsp &nbsp
                    <asp:ListBox id="lbBatchHistory"  runat="server" Visible="False" Width="90%"></asp:ListBox>

                    <asp:GridView ID="gvHistory" runat="server" DataKeyNames="DateTimeStamp" CssClass="Grid" AutoGenerateColumns="False" Font-Size="Small" HorizontalAlign="Left" Width="95%" Visible="False">    
                        <Columns>
                            <asp:BoundField DataField="Batch_Desc" HeaderText="Status" SortExpression="BatchEnd" />
                            <asp:BoundField DataField="DateTimeStamp" HeaderText="Date" SortExpression="Date" />
                            <asp:BoundField DataField="UserName" HeaderText="User" SortExpression="User" />
                            <asp:BoundField DataField="Reason_Notes" HeaderText="Note" SortExpression="Note" />                                 
                        </Columns>
                    </asp:GridView>
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
            <asp:TableRow ID="TableRow6" runat="Server">
                <asp:TableCell ID="TableCell3" runat="Server" Width=20%>
                   Density
                </asp:TableCell>
                <asp:TableCell ID="TableCell12" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQCDensity" runat="server"></asp:TextBox>
                    g/cc = 
                    <asp:TextBox ID="txtDensitylbsgal" runat="server" BackColor="transparent" ReadOnly="True" Width="75" BorderStyle="None" Font-Bold="False" Font-Strikeout="False"></asp:TextBox> 
                    lbs/gal
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow7" runat="Server">
                <asp:TableCell ID="TableCell13" runat="Server" Width=20%>
                   Grit
                </asp:TableCell>
                <asp:TableCell ID="TableCell14" runat="Server" Width=80%>
                    <asp:TextBox ID="txtQCGrit" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow1" runat="Server">
                <asp:TableCell ID="TableCell4" runat="Server" Width=20% >
                    Tape Adhesion
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="Server">
                    Top:
                     <asp:TextBox ID="txtQCTapeTop" runat="server"></asp:TextBox>% 
                      Bottom:
                     <asp:TextBox ID="txtQCTapeBottom" runat="server"></asp:TextBox>%
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
                    &nbsp
                    &nbsp
                    <asp:Button ID="btnSave" runat="server" Text="Save" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>    
    <br/>

    <asp:HiddenField ID="txtNewRecord" runat="server" />
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
