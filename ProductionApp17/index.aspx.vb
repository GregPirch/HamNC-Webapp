
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports ProductionApp17.clsMain

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsMain As New clsMain
        If clsMain.ConvertNullInteger(Session("UserID")) > 0 Then
            'Valid User Has Logged In

            Using myConnection As New SqlConnection
                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString

                Dim myCommand As New SqlCommand
                myCommand.Connection = myConnection
                myCommand.CommandText = "SELECT TOP 31 * FROM vu_ProdApp_MudBatchDailySum" ' ORDER BY Batch_Date DESC"

                myConnection.Open()
                Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                Me.chtDailyTotals.DataBindTable(myReader, "Batch_Date")

                myReader.Close()
                myConnection.Close()
            End Using

            Using myConnection2 As New SqlConnection
                myConnection2.ConnectionString = ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString


                Dim myCommand2 As New SqlCommand
                myCommand2.Connection = myConnection2
                myCommand2.CommandText = "SELECT TOP 12 (CONVERT(varchar(2),BatchMonth,101) + '/' + CONVERT(varchar(4),BatchYear,101)) as BatchYearMonth, Total FROM vu_ProdApp_MudBatchMonthlySum ORDER BY CONVERT(int ,BatchYear,101), CONVERT(int ,BatchMonth,101)"
                'myCommand2.CommandText = "SELECT TOP 12 CONCAT(BatchYear, '/', BatchMonth) as BatchYearMonth, Total FROM vu_ProdApp_MudBatchMonthlySum ORDER BY BatchYearMonth DESC"

                myConnection2.Open()
                Dim myReader2 As SqlDataReader = myCommand2.ExecuteReader()

                Me.chtMonthlyTotals.DataBindTable(myReader2, "BatchYearMonth")

                myReader2.Close()
                myConnection2.Close()
            End Using
        Else
            'Force a user login
            Session("UserName") = "No Current User"
            Response.Redirect("Login.aspx")
        End If
    End Sub


End Class