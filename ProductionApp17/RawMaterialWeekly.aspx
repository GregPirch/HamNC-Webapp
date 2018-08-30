<%@ Page Title="Raw Material Weekly" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="RawMaterialWeekly.aspx.vb" Inherits="ProductionApp17.RawMaterialWeekly"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Records Found: <asp:Label ID="lRecordCount" runat="server" Text="Label" BorderStyle="None"></asp:Label></h2>
    <asp:TextBox ID="txtDateToShow" runat="server" Text='text' />
    <br/>
    
    First Date: <asp:Label ID="lFirstDate" runat="server" Text="Label" BorderStyle="None"/>
    <br/>
    Last Date: <asp:Label ID="lLastDate" runat="server" Text="Label" BorderStyle="None"/>
    <br/>

    <asp:Button ID="BtnGetMonthBefore" runat="server" Text="Get Prev Week"  OnClick = "BtnGetMonthBefore_Click" />
    <asp:Button ID="BtnGetMonthAfter" runat="server" Text="Get Next Week"  OnClick = "BtnGetMonthAfter_Click" />
    <asp:Button ID="BtnViewMonthlyReport" runat="server" Text="Zoom Out (Monthly)"  OnClick = "BtnViewMonthlyReport_Click" />

    <br/><br/>

    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Ingredient" CssClass="Grid" AutoGenerateColumns="False" Font-Size="Small" HorizontalAlign="Left" Width="1018px">    
        <Columns>
            <asp:BoundField DataField="Ingredient" HeaderText="Raw Ingredient" SortExpression="Ingredient" ItemStyle-BackColor="#A7E4EF" />
            <asp:BoundField DataField="Week5" HeaderText="Raw Wt 5" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Week4" HeaderText="Raw Wt 4" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Week3" HeaderText="Raw Wt 3" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Week2" HeaderText="Raw Wt 2" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Week1" HeaderText="Raw Wt 1" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Total" HeaderText="5 Weeks Total" DataFormatString="{0:N1} lbs" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Center" ItemStyle-BackColor="#A7E4EF" />
        </Columns>
    </asp:GridView>
    <br/><br/>
    
</asp:Content>
