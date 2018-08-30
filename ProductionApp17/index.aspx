<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site3.Master" CodeBehind="index.aspx.vb" Inherits="ProductionApp17.WebForm1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

         <asp:Table ID="Table1" runat="Server" CellPadding="2" CellSpacing="1" Width="1300px"
        BorderColor="CadetBlue" Caption="Batch Daily Boxcount Totals" BorderWidth="1" BorderStyle="Dashed">
            <asp:TableRow ID="TableRow1" runat="Server">
                <asp:TableCell ID="TableCell39" runat="Server" Width=100%>
                          <asp:Chart ID="chtDailyTotals" runat="server" ImageAlign="Right" Height="400px" Palette="Bright" Width="1100px" BackImageWrapMode="Unscaled">
                            <Series>
                          <asp:Series Name="Series1"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>   
    
    <br/><br/>

        <asp:Table ID="Table2" runat="Server" CellPadding="2" CellSpacing="1" Width="1300px"
        BorderColor="CadetBlue" Caption="Batch Monthly Boxcount Totals" BorderWidth="1" BorderStyle="Dashed">
            <asp:TableRow ID="TableRow2" runat="Server">
                <asp:TableCell ID="TableCell1" runat="Server" Width=100%>
                          <asp:Chart ID="chtMonthlyTotals" runat="server" ImageAlign="Right" Height="400px" Palette="Bright" Width="1100px" BackImageWrapMode="Unscaled">
                            <Series>
                          <asp:Series Name="Series1"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea2"></asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>    
     
    <br/><br/>

        <br/><br/>

    <asp:Image ID="Image1" runat="server" ImageUrl="/images/HDPLogo.png" ImageAlign="Middle" />
</asp:Content>
