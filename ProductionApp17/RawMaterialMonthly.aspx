<%@ Page Title="Raw Material Monthly" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="RawMaterialMonthly.aspx.vb" Inherits="ProductionApp17.RawMaterialMonthly"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Records Found: <asp:Label ID="lRecordCount" runat="server" Text="Label" BorderStyle="None"></asp:Label></h2>
    <asp:TextBox ID="txtDateToShow" runat="server" Text='text' />
    <br/>
    
    First Date: <asp:Label ID="lFirstDate" runat="server" Text="Label" BorderStyle="None"/>
    <br/>
    Last Date: <asp:Label ID="lLastDate" runat="server" Text="Label" BorderStyle="None"/>
    <br/>

    <asp:Button ID="Button1" runat="server" Text="Get Prev Month"  OnClick = "BtnGetMonthBefore_Click" />
    <asp:Button ID="Button2" runat="server" Text="Get Next Month"  OnClick = "BtnGetMonthAfter_Click" />
    
    <br/><br/>
    
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Ingred" CssClass="Grid" AutoGenerateColumns="False" Font-Size="Small" HorizontalAlign="Left" Width="1018px">    
        <Columns>
            <asp:BoundField DataField="Ingred" HeaderText="Raw Ingredient" SortExpression="Ingred"  ItemStyle-BackColor="#A7E4EF" />
            <asp:BoundField DataField="Usage3" HeaderText="Raw Wt 3" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Usage2" HeaderText="Raw Wt 2" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Usage1" HeaderText="Raw Wt 1" DataFormatString="{0:N1}" />
            <asp:BoundField DataField="Total" HeaderText="3 Months Total" DataFormatString="{0:N1} lbs" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Center"  ItemStyle-BackColor="#A7E4EF" />
        </Columns>
    </asp:GridView>
    <br/><br/>
 
    
    

</asp:Content>
