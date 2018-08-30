Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports ProductionApp17.clsMain

Public Class MudProdEntry
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserID") > 0 Then
            'Valid User Has Logged In

        Else
            'Force a user login
            Session("UserName") = "No Current User"
            Response.Redirect("Login.aspx")
        End If

        Try
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
            End If

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try

    End Sub

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

            If clsMain.ConvertNullInteger(txtYield.Text) > 0 Then
                sSQL = "INSERT INTO MudProductionLog (KeyNumber, DeletedRec, RunDate, RunTime, PackageDate, PackageTime, OperatorKey, BagDumpOperatorKey, ShiftKey, ProductKey, BatchNumber, BatchPercent, WaterInitial, WaterFinal, ViscosityInitial, ViscosityInline, Amps, PSI, MixTime, ViscosityFinal, Yield, BoxWeightVolume, Notes, LastUserID, DateCreated, LastUpdate) "
                sSQL = sSQL & "VALUES (@KeyNumber, @DeletedRec, @RunDate, @RunTime, @PackageDate, @PackageTime, @OperatorKey, @BagDumpOperatorKey, @ShiftKey, @ProductKey, @BatchNumber, @BatchPercent, @WaterInitial, @WaterFinal, @ViscosityInitial, @ViscosityInline, @Amps, @PSI, @MixTime, @ViscosityFinal, @Yield, @BoxWeightVolume, @Notes, @LastUserID, @DateCreated, @LastUpdate)"
            Else
                sSQL = "INSERT INTO MudProductionLog (KeyNumber, DeletedRec, RunDate, RunTime, OperatorKey, BagDumpOperatorKey, ShiftKey, ProductKey, BatchNumber, BatchPercent, WaterInitial, WaterFinal, ViscosityInitial, ViscosityInline, Amps, PSI, MixTime, ViscosityFinal, Yield, BoxWeightVolume, Notes, LastUserID, DateCreated, LastUpdate) "
                sSQL = sSQL & "VALUES (@KeyNumber, @DeletedRec, @RunDate, @RunTime, @OperatorKey, @BagDumpOperatorKey, @ShiftKey, @ProductKey, @BatchNumber, @BatchPercent, @WaterInitial, @WaterFinal, @ViscosityInitial, @ViscosityInline, @Amps, @PSI, @MixTime, @ViscosityFinal, @Yield, @BoxWeightVolume, @Notes, @LastUserID, @DateCreated, @LastUpdate)"
            End If

            ' Create INSERT statement with named parameters
            nonqueryCommand.CommandText = sSQL

            ' Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@KeyNumber", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@DeletedRec", SqlDbType.NVarChar, 1)
            nonqueryCommand.Parameters.Add("@RunDate", SqlDbType.DateTime)
            nonqueryCommand.Parameters.Add("@RunTime", SqlDbType.DateTime)
            If clsMain.ConvertNullInteger(txtYield.Text) > 0 Then
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
            nonqueryCommand.Parameters.Add("@DateCreated", SqlDbType.DateTime)
            nonqueryCommand.Parameters.Add("@LastUpdate", SqlDbType.DateTime)

            nonqueryCommand.Parameters("@KeyNumber").Value = GetNextRecordKey()
            nonqueryCommand.Parameters("@DeletedRec").Value = "N"
            nonqueryCommand.Parameters("@RunDate").Value = Now
            nonqueryCommand.Parameters("@RunTime").Value = Now
            If clsMain.ConvertNullInteger(txtYield.Text) > 0 Then
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
            nonqueryCommand.Parameters("@DateCreated").Value = Now
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

    Function GetNextRecordKey() As Integer
        Dim sqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("ProductionFormulaConnectionString1").ConnectionString.ToString)
        Dim NextKeyNumber As Integer
        Dim clsMain As New clsMain

        Dim strSQL = "SELECT TOP 1 KeyNumber FROM MudProductionLog ORDER BY KeyNumber DESC"
        Dim sqlComm As New SqlCommand(strSQL, sqlConn)

        Dim sqlReader As SqlDataReader
        Try
            GetNextRecordKey = 0
            sqlConn.Open()
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.SingleResult)
            If sqlReader.Read Then
                NextKeyNumber = clsMain.ConvertNullInteger(sqlReader("KeyNumber"))
                If NextKeyNumber = 0 Then NextKeyNumber = 1
                GetNextRecordKey = (NextKeyNumber + 1)
            End If

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        Finally
            sqlComm.Dispose()
            sqlConn.Close()
        End Try
    End Function
End Class