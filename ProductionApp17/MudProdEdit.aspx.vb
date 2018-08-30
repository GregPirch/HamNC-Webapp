Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports ProductionApp17.clsMain

Public Class MudProdEdit
    Inherits System.Web.UI.Page

    Public Structure ProductionData
        Public KeyNumber As Integer
        Public DeletedRec As String
        Public RunDate As String
        Public RunTime As String
        Public PackageDate As String
        Public PackageTime As String
        Public OperatorKey As Integer
        Public BagDumpOperatorKey As Integer
        Public ShiftKey As Integer
        Public ProductKey As Integer
        Public BatchNumber As Integer
        Public BoxWeightVolume As Double
        Public ViscosityInLine As Double
        Public ViscosityInitial As Integer
        Public ViscosityFinal As Integer
        Public WaterInitial As Integer
        Public WaterFinal As Integer
        Public Amps As Double
        Public PSI As Double
        Public MixTime As Double
        Public Yield As Integer
        Public BatchPercent As Integer
        Public Notes As String
        Public LastUserID As String
        Public DateCreated As String
        Public LastUpdate As String
    End Structure

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim LocalProductionItem As ProductionData

        Try
            If Session("UserID") > 0 Then
                'Valid User Has Logged In

            Else
                'Force a user login
                Session("UserName") = "No Current User"
                Response.Redirect("Login.aspx")
            End If

            If IsPostBack = False Then

                'Populate Operator Drop Down
                ddlOperators.Items.Clear()
                Dim SqlDataSource1 As New SqlDataSource()
                SqlDataSource1.ID = "SqlDataSource1"
                Me.Page.Controls.Add(SqlDataSource1)
                SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
                SqlDataSource1.SelectCommand = "SELECT KeyNumber, FirstName from Operators ORDER BY FirstName"
                ddlOperators.DataSource = SqlDataSource1
                ddlOperators.DataTextField = "FirstName"
                ddlOperators.DataValueField = "KeyNumber"
                ddlOperators.DataBind()

                'Populate Bag Dump Operator as well 
                ddlBagDump.DataSource = SqlDataSource1
                ddlBagDump.DataTextField = "FirstName"
                ddlBagDump.DataValueField = "KeyNumber"
                ddlBagDump.DataBind()

                'Populate Shift Drop Down
                ddlShift.Items.Clear()
                Dim SqlDataSource2 As New SqlDataSource()
                SqlDataSource2.ID = "SqlDataSource1"
                Me.Page.Controls.Add(SqlDataSource2)
                SqlDataSource2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
                SqlDataSource2.SelectCommand = "SELECT KeyNumber, Shift, SortOrder from Shifts ORDER BY SortOrder"
                ddlShift.DataSource = SqlDataSource2
                ddlShift.DataTextField = "Shift"
                ddlShift.DataValueField = "KeyNumber"
                ddlShift.DataBind()

                'Populate Product Drop Down
                ddlProduct.Items.Clear()
                Dim SqlDataSource3 As New SqlDataSource()
                SqlDataSource3.ID = "SqlDataSource1"
                Me.Page.Controls.Add(SqlDataSource3)
                SqlDataSource3.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
                SqlDataSource3.SelectCommand = "SELECT KeyNumber, ProductName from Products ORDER BY ProductName"
                ddlProduct.DataSource = SqlDataSource3
                ddlProduct.DataTextField = "ProductName"
                ddlProduct.DataValueField = "KeyNumber"
                ddlProduct.DataBind()

                LocalProductionItem = GetProductionItem(Session("KeyValue"))
                If LocalProductionItem.KeyNumber <> 0 Then
                    'We have a valid item
                    Me.txtKeyNumber.Text = LocalProductionItem.KeyNumber
                    Me.txtRunDate.Text = LocalProductionItem.RunDate
                    'Me.txtRunTime.Text = LocalProductionItem.RunTime
                    Me.txtPackageDate.Text = LocalProductionItem.PackageDate.ToString
                    'Me.txtPackageTime.Text = LocalProductionItem.PackageTime.ToString
                    Me.ddlOperators.Text = LocalProductionItem.OperatorKey
                    Me.ddlBagDump.Text = LocalProductionItem.BagDumpOperatorKey
                    Me.ddlShift.Text = LocalProductionItem.ShiftKey
                    Me.ddlProduct.Text = LocalProductionItem.ProductKey
                    Me.txtBatch.Text = LocalProductionItem.BatchNumber
                    Me.txtBatchPcnt.Text = LocalProductionItem.BatchPercent
                    Me.txtWaterInitial.Text = LocalProductionItem.WaterInitial
                    Me.txtWaterFinal.Text = LocalProductionItem.WaterFinal
                    Me.txtViscosityInit.Text = LocalProductionItem.ViscosityInitial
                    Me.txtViscosityInline.Text = LocalProductionItem.ViscosityInLine
                    Me.txtAmps.Text = LocalProductionItem.Amps
                    Me.txtPSI.Text = LocalProductionItem.PSI
                    Me.txtMixTime.Text = LocalProductionItem.MixTime
                    Me.txtViscosityFinal.Text = LocalProductionItem.ViscosityFinal
                    Me.txtYield.Text = LocalProductionItem.Yield
                    Me.txtYield0.Value = LocalProductionItem.Yield 'Save the Yield to compare if it was changed from 0 to a value to mark run date.
                    Me.txtBoxWgtVol.Text = LocalProductionItem.BoxWeightVolume
                    Me.txtNotes.Text = LocalProductionItem.Notes
                    Me.txtLastUser.Text = LocalProductionItem.LastUserID
                    Me.txtDateCreated.Text = LocalProductionItem.DateCreated
                    Me.txtLastUpdated.Text = LocalProductionItem.LastUpdate

                End If
            End If

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub


    Function GetProductionItem(KeyValue As Integer) As ProductionData
        Dim sqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("ProductionFormulaConnectionString1").ConnectionString.ToString)
        Dim LocalProductionData As New ProductionData
        Dim clsMain As New clsMain

        Dim strSQL = "SELECT TOP 1 * FROM MudProductionLog WHERE KeyNumber=" & KeyValue.ToString
        Dim sqlComm As New SqlCommand(strSQL, sqlConn)

        Dim sqlReader As SqlDataReader
        Try

            sqlConn.Open()
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.SingleResult)
            If sqlReader.Read Then
                With LocalProductionData
                    .KeyNumber = clsMain.ConvertNullInteger(sqlReader("KeyNumber"))
                    .DeletedRec = sqlReader("DeletedRec") & ""
                    .RunDate = sqlReader("RunDate") & ""
                    .RunTime = sqlReader("RunTime") & ""
                    .PackageDate = sqlReader("PackageDate") & ""
                    .PackageTime = sqlReader("PackageTime") & ""
                    .OperatorKey = sqlReader("OperatorKey")
                    .BagDumpOperatorKey = sqlReader("BagDumpOperatorKey")
                    .ShiftKey = sqlReader("ShiftKey")
                    .ProductKey = sqlReader("ProductKey")
                    .BatchNumber = sqlReader("BatchNumber")
                    .BoxWeightVolume = sqlReader("BoxWeightVolume")
                    .ViscosityInLine = sqlReader("ViscosityInLine")
                    .ViscosityInitial = sqlReader("ViscosityInitial")
                    .ViscosityFinal = sqlReader("ViscosityFinal")
                    .WaterInitial = sqlReader("WaterInitial")
                    .WaterFinal = sqlReader("WaterFinal")
                    .Amps = sqlReader("AMPS")
                    .PSI = sqlReader("PSI")
                    .MixTime = sqlReader("MixTime")
                    .Yield = sqlReader("Yield")
                    .BatchPercent = sqlReader("BatchPercent")
                    .Notes = sqlReader("Notes") & ""
                    .LastUserID = sqlReader("LastUserID")
                    .DateCreated = sqlReader("DateCreated") & ""
                    .LastUpdate = sqlReader("LastUpdate") & ""
                End With
                Return LocalProductionData
            End If

        Catch
            'Error has occured

            LocalProductionData.KeyNumber = 0

            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If
            Return LocalProductionData
        Finally
            sqlComm.Dispose()
            sqlConn.Close()
        End Try
    End Function


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString)
        Dim clsMain As New clsMain

        'Create Command object
        Dim nonqueryCommand As SqlCommand = thisConnection.CreateCommand()
        Dim sSQL As String
        Dim regDate As DateTime = DateTime.Now
        'Dim strDate As String = regDate.ToString("yyyy-MM-dd HH:mm:ss")

        Try
            ' Open Connection
            thisConnection.Open()

            If clsMain.ConvertNullInteger(txtYield.Text) > 0 And clsMain.ConvertNullInteger(txtYield0.Value) = 0 Then
                sSQL = "UPDATE MudProductionLog Set DeletedRec = @DeletedRec, PackageDate = @PackageDate, PackageTime = @PackageTime, OperatorKey = @OperatorKey, BagDumpOperatorKey = @BagDumpOperatorKey, ShiftKey = @ShiftKey, ProductKey = @ProductKey, BatchNumber = @BatchNumber, BatchPercent =  @BatchPercent, WaterInitial = @WaterInitial, WaterFinal = @WaterFinal, ViscosityInitial = @ViscosityInitial, ViscosityInline = @ViscosityInline, Amps = @Amps, PSI = @PSI, MixTime = @MixTime, ViscosityFinal = @ViscosityFinal, Yield = @Yield, BoxWeightVolume = @BoxWeightVolume, Notes = @Notes, LastUserID = @LastUserID, LastUpdate = @LastUpdate WHERE KeyNumber = @KeyNumber"
            Else
                sSQL = "UPDATE MudProductionLog Set DeletedRec = @DeletedRec, OperatorKey = @OperatorKey, BagDumpOperatorKey = @BagDumpOperatorKey, ShiftKey = @ShiftKey, ProductKey = @ProductKey, BatchNumber = @BatchNumber, BatchPercent =  @BatchPercent, WaterInitial = @WaterInitial, WaterFinal = @WaterFinal, ViscosityInitial = @ViscosityInitial, ViscosityInline = @ViscosityInline, Amps = @Amps, PSI = @PSI, MixTime = @MixTime, ViscosityFinal = @ViscosityFinal, Yield = @Yield, BoxWeightVolume = @BoxWeightVolume, Notes = @Notes, LastUserID = @LastUserID, LastUpdate = @LastUpdate WHERE KeyNumber = @KeyNumber"
            End If

            ' Create INSERT statement with named parameters
            nonqueryCommand.CommandText = sSQL

            ' Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@KeyNumber", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@DeletedRec", SqlDbType.NVarChar, 1)
            If clsMain.ConvertNullInteger(txtYield.Text) > 0 And clsMain.ConvertNullInteger(txtYield0.Value) = 0 Then
                nonqueryCommand.Parameters.Add("@PackageDate", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@PackageTime", SqlDbType.DateTime)
            End If
            nonqueryCommand.Parameters.Add("@OperatorKey", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@BagDumpOperatorKey", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@ShiftKey", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@ProductKey", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@BatchNumber", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@BatchPercent", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@WaterInitial", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@WaterFinal", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@ViscosityInitial", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@ViscosityInLine", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@Amps", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@PSI", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@MixTime", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@ViscosityFinal", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@Yield", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@BoxWeightVolume", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@Notes", SqlDbType.NVarChar, 4000)
            nonqueryCommand.Parameters.Add("@LastUserID", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@LastUpdate", SqlDbType.DateTime)

            nonqueryCommand.Parameters("@KeyNumber").Value = clsMain.ConvertNullInteger(txtKeyNumber.Text)
            nonqueryCommand.Parameters("@DeletedRec").Value = "N"
            If clsMain.ConvertNullInteger(txtYield.Text) > 0 And clsMain.ConvertNullInteger(txtYield0.Value) = 0 Then
                nonqueryCommand.Parameters("@PackageDate").Value = Now
                nonqueryCommand.Parameters("@PackageTime").Value = Now
            End If
            nonqueryCommand.Parameters("@OperatorKey").Value = ddlOperators.SelectedValue
            nonqueryCommand.Parameters("@BagDumpOperatorKey").Value = ddlBagDump.SelectedValue
            nonqueryCommand.Parameters("@ShiftKey").Value = ddlShift.SelectedValue
            nonqueryCommand.Parameters("@ProductKey").Value = ddlProduct.SelectedValue
            nonqueryCommand.Parameters("@BatchNumber").Value = clsMain.ConvertNullInteger(txtBatch.Text)
            nonqueryCommand.Parameters("@BatchPercent").Value = clsMain.ConvertNullInteger(txtBatchPcnt.Text)
            nonqueryCommand.Parameters("@WaterInitial").Value = clsMain.ConvertNullInteger(txtWaterInitial.Text)
            nonqueryCommand.Parameters("@WaterFinal").Value = clsMain.ConvertNullInteger(txtWaterFinal.Text)
            nonqueryCommand.Parameters("@ViscosityInitial").Value = clsMain.ConvertNullInteger(txtViscosityInit.Text)
            nonqueryCommand.Parameters("@ViscosityInLine").Value = clsMain.ConvertNullDouble(txtViscosityInline.Text)
            nonqueryCommand.Parameters("@Amps").Value = clsMain.ConvertNullDouble(txtAmps.Text)
            nonqueryCommand.Parameters("@PSI").Value = clsMain.ConvertNullDouble(txtPSI.Text)
            nonqueryCommand.Parameters("@MixTime").Value = clsMain.ConvertNullDouble(txtMixTime.Text)
            nonqueryCommand.Parameters("@ViscosityFinal").Value = clsMain.ConvertNullInteger(txtViscosityFinal.Text)
            nonqueryCommand.Parameters("@Yield").Value = clsMain.ConvertNullInteger(txtYield.Text)
            nonqueryCommand.Parameters("@BoxWeightVolume").Value = clsMain.ConvertNullDouble(txtBoxWgtVol.Text)
            nonqueryCommand.Parameters("@Notes").Value = txtNotes.Text & ""
            nonqueryCommand.Parameters("@LastUserID").Value = Session("UserID")
            nonqueryCommand.Parameters("@LastUpdate").Value = Now
            nonqueryCommand.ExecuteNonQuery()


        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        Finally
            ' Close Connection
            thisConnection.Close()

            Response.Redirect("MudProd.aspx")

        End Try
    End Sub

End Class