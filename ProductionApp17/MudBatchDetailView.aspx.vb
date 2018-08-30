Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports ProductionApp17.clsMain

Public Class MudBatchDetailView
    Inherits System.Web.UI.Page

    Public Structure ProductionData
        Public LotNum As String
        Public Batch_DateTime As String
        Public Batch_DayofWeek As String
        Public Batch_Num As Integer
        Public Recipe_Num As Integer
        Public Mixer_Num As Integer
        Public Actual_BoxCount As Integer
        Public SetPnt_BoxWt As Integer
        Public Logged_On_Operator As String

        Public Actual_MixTime As Integer
        Public Actual_TimeInBoxOut As Integer
        Public BoxWeightVolume As Integer
        Public Actual_TotalBatchTime As Integer
        Public Actual_XferTime As Integer

        Public SetPnt_CaCO3 As Double
        Public SetPnt_Water As Double
        Public SetPnt_Tote1 As Double
        Public SetPnt_Tote2 As Double
        Public SetPnt_Tote3 As Double
        Public SetPnt_Tote4 As Double

        Public Actual_TotalWaterWt As Integer


    End Structure

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            If Session("UserID") > 0 Then
                'Valid User Has Logged In

            Else
                'Force a user login
                Session("UserName") = "No Current User"
                Response.Redirect("Login.aspx")
            End If

            If IsPostBack = False Then
                Dim SqlDataSource2 As New SqlDataSource()
                SqlDataSource2.ID = "SqlDataSource1"
                Me.Page.Controls.Add(SqlDataSource2)
                SqlDataSource2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString
                SqlDataSource2.SelectCommand = "SELECT * from vu_ProdApp_MudBatchDetail Where Lot_Num ='" & Session("KeyValue") & "'"

                Dim mycn As SqlConnection
                Dim myda As SqlDataAdapter
                Dim ds As DataSet
                mycn = New SqlConnection
                mycn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString
                myda = New SqlDataAdapter("SELECT * from vu_ProdApp_MudBatchDetail Where Lot_Num ='" & Session("KeyValue") & "'", mycn)
                ds = New DataSet()
                myda.Fill(ds, "Batch")



                Dim dc As DataColumn
                Dim dr As DataRow
                For Each dc In ds.Tables(0).Columns
                    Dim trow As New TableRow
                    Dim tcellcolname As New TableCell
                    'To Display the Column Names 
                    For Each dr In ds.Tables(0).Rows
                        tcellcolname.Text = dc.ColumnName
                        trow.BackColor = System.Drawing.Color.Beige
                        tcellcolname.BackColor = System.Drawing.Color.AliceBlue
                        'Populate the TableCell with the Column Name 
                        tcellcolname.Controls.Add(New LiteralControl(dc.ColumnName.ToString))
                    Next
                    trow.Cells.Add(tcellcolname)
                    'To Display the Column Data 
                    For Each dr In ds.Tables(0).Rows
                        Dim tcellcoldata As New TableCell
                        'Populate the TableCell with the Column Data 
                        tcellcoldata.Controls.Add(New LiteralControl(dr(dc.ColumnName).ToString))
                        trow.Cells.Add(tcellcoldata)
                    Next
                    Table1.Rows.Add(trow)
                Next


            End If

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub







End Class