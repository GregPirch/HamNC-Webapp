<%@ Page Title="Raw Material" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="RawMaterial.aspx.vb" Inherits="ProductionApp17.RawMaterial"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Records Found: <asp:Label ID="lRecordCount" runat="server" Text="Label" BorderStyle="None"></asp:Label></h2>
    <asp:TextBox ID="txtDateToShow" runat="server" Text='text' />
    <br/>
    
    First Date: <asp:Label ID="lFirstDate" runat="server" Text="Label" BorderStyle="None"/>
    <br/>
    Last Date: <asp:Label ID="lLastDate" runat="server" Text="Label" BorderStyle="None"/>
    <br/>

    <asp:Button ID="BtnGetWeekBefore" runat="server" Text="Get Prev Week"  OnClick = "BtnGetWeekBefore_Click" />
    <asp:Button ID="BtnGetWeekAfter" runat="server" Text="Get Next Week"  OnClick = "BtnGetWeekAfter_Click" />
    <asp:Button ID="BtnViewWeeklyReport" runat="server" Text="Zoom Out (Weekly)"  OnClick = "BtnViewWeeklyReport_Click" />
    <asp:Button ID="BtnViewMonthlyReport" runat="server" Text="Zoom Out (Monthly)"  OnClick = "BtnViewMonthlyReport_Click" />

    <br/><br/>

    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Ingred" CssClass="Grid" AutoGenerateColumns="False" AllowSorting="True" Font-Size="Small" 
                                        HorizontalAlign="Center" Width="1018px" HeaderStyle-Wrap="True" ShowFooter="False" HeaderStyle-BackColor="#B1E8F1">    
        <Columns>
            <asp:BoundField DataField="Ingred" HeaderText="Raw Material" SortExpression="Ingred" ItemStyle-BackColor="#A7E4EF" />
            <asp:BoundField DataField="Usage7" HeaderText="Raw Wt 7" SortExpression="Usage7" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Usage6" HeaderText="Raw Wt 6" SortExpression="Usage6" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Usage5" HeaderText="Raw Wt 5" SortExpression="Usage5" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Usage4" HeaderText="Raw Wt 4" SortExpression="Usage4" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Usage3" HeaderText="Raw Wt 3" SortExpression="Usage3" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Usage2" HeaderText="Raw Wt 2" SortExpression="Usage2" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Usage1" HeaderText="Raw Wt 1" SortExpression="Usage1" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="UsageTot" HeaderText="Weeks Total" DataFormatString="{0:N1} lbs" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="#A7E4EF" />

        
        </Columns>
    </asp:GridView>
    <br/><br/>
    
    

</asp:Content>
