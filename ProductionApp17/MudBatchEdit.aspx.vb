Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports ProductionApp17.clsMain

Public Class MudBatchEdit
    Inherits System.Web.UI.Page

    Public Structure MudQC
        Public Lot_Num As String 'Key Value
        Public NewRecord As Boolean
        Public QC48HourViscosity As Double
        Public QC48HourViscosityDateStamp As String
        Public QC48HourViscosityTimeStamp As String
        Public QC48HourViscosityUser As String
        Public QCHoldValue As Double
        Public QCHighLowFlag As String
        Public QCHoldValueDateStamp As String
        Public QCHoldValueTimeStamp As String
        Public QCHoldValueUser As String
        Public QCReTestViscosity As Double
        Public QCReTestViscosityDateStamp As String
        Public QCReTestViscosityTimeStamp As String
        Public QCReTestViscosityUser As String
        Public QCTapeOut As String
        Public QCTapeOutDateStamp As String
        Public QCTapeOutTimeStamp As String
        Public QCTapeOutUser As String
        Public QCTapeIn As String
        Public QCTapeInDateStamp As String
        Public QCTapeInTimeStamp As String
        Public QCTapeInUser As String
        Public QCCrack As String
        Public QCCrackDateStamp As String
        Public QCCrackTimeStamp As String
        Public QCCrackUser As String
        Public QCPockingStart As String
        Public QCPockingEnd As String
        Public QCPockingStartEndDateStamp As String
        Public QCPockingStartEndTimeStamp As String
        Public QCPockingStartEndUser As String
        Public QCNotes As String
        Public RecipeLabMinVisc As String
        Public RecipeLabMaxVisc As String
        Public QCDensity As Double
        Public QCGrit As Double
        Public QCTapeTop As Integer
        Public QCTapeBottom As Integer
    End Structure

    Public Structure BatchStatus
        Public Lot_Num As String 'Key Value
        Public BatchStatus_ID As Integer
        Public BatchStatus As Integer
        Public DateTime As String
        Public ReasonNotes As String
        Public UserName As String
    End Structure

    Public Structure BatchRecipeVisc
        Public Lot_Num As String
        Public RecipeLabMinVisc As Integer
        Public RecipeLabMaxVisc As Integer
    End Structure

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim LocalMudQC As MudQC

        Try
            If Session("UserID") > 0 Then
                'Valid User Has Logged In

            Else
                'Force a user login
                Session("UserName") = "No Current User"
                Response.Redirect("Login.aspx")
            End If

            If Session("UserType") = "A" Then
                Me.btnReject.Visible = True
                Me.btnRelease.Visible = True
                Me.btnReRun.Visible = True
            Else
                Me.btnReject.Visible = False
                Me.btnRelease.Visible = False
                Me.btnReRun.Visible = False
            End If

            If IsPostBack = False Then


                LocalMudQC = GetProductionItem(Session("KeyValue"))
                If LocalMudQC.Lot_Num & "" <> "" Then
                    'We have a valid item
                    Me.txtLot_Num.Text = LocalMudQC.Lot_Num
                    Me.txtNewRecord.Value = LocalMudQC.NewRecord.ToString
                    Me.txtQC48HourViscosity.Text = LocalMudQC.QC48HourViscosity
                    Me.txtQC48HourViscosity0.Value = LocalMudQC.QC48HourViscosity
                    Me.txtQCRecipeLabMinVisc.Text = LocalMudQC.RecipeLabMinVisc
                    Me.txtQCRecipeLabMaxVisc.Text = LocalMudQC.RecipeLabMaxVisc
                    'Me.txtQCHoldValue.Text = LocalMudQC.QCHoldValue
                    'Me.ddlQCHighLowFlag.Text = LocalMudQC.QCHighLowFlag
                    Me.txtQCReTestViscosity.Text = LocalMudQC.QCReTestViscosity
                    Me.txtQCRetestViscosity0.Value = LocalMudQC.QCReTestViscosity
                    'Me.ddlQCTapeOut.Text = LocalMudQC.QCTapeOut
                    Me.txtQCTapeOut0.Value = LocalMudQC.QCTapeOut
                    'Me.ddlQCTapeIn.Text = LocalMudQC.QCTapeIn
                    Me.txtQCTapeIn0.Value = LocalMudQC.QCTapeIn
                    Me.txtQCCrack.Text = LocalMudQC.QCCrack
                    Me.txtQCPockingStart.Text = LocalMudQC.QCPockingStart
                    Me.txtQCPockingEnd.Text = LocalMudQC.QCPockingEnd
                    Me.txtQCPockingStart0.Value = LocalMudQC.QCPockingStart
                    Me.txtQCPockingEnd0.Value = LocalMudQC.QCPockingEnd
                    Me.txtQCNotes.Text = LocalMudQC.QCNotes
                    Me.txtQCRecipeLabMinVisc.Text = LocalMudQC.RecipeLabMinVisc
                    Me.txtQCRecipeLabMaxVisc.Text = LocalMudQC.RecipeLabMaxVisc
                    Me.txtQCTapeTop.Text = LocalMudQC.QCTapeTop
                    Me.txtQCTapeBottom.Text = LocalMudQC.QCTapeBottom
                    Me.txtQCDensity.Text = LocalMudQC.QCDensity
                    Me.txtDensitylbsgal.Text = LocalMudQC.QCDensity * 8.3454
                    Me.txtQCGrit.Text = LocalMudQC.QCGrit

                    Dim LocalBatchStatus As BatchStatus

                    LocalBatchStatus = GetBatchStatus(LocalMudQC.Lot_Num)

                    HoldValuesSetup(LocalBatchStatus.BatchStatus)


                    'Populate Shift Drop Down

                    Dim SqlDataSource2 As New SqlDataSource()
                    SqlDataSource2.ID = "SqlDataSource1"
                    Me.Page.Controls.Add(SqlDataSource2)
                    SqlDataSource2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString
                    SqlDataSource2.SelectCommand = "SELECT Batch_Desc, DateTimeStamp, UserName, Reason_Notes from vu_ProdApp_BatchStatus WHERE Lot_Num ='" & LocalMudQC.Lot_Num & "' ORDER BY BatchStatus_ID DESC"
                    gvHistory.DataSource = SqlDataSource2
                    gvHistory.DataBind()

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


    Function GetProductionItem(KeyValue As String) As MudQC
        Dim sqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("HamiltonNCProduction1").ConnectionString.ToString)
        Dim LocalMudQC As New MudQC
        Dim clsMain As New clsMain

        'Dim strSQL = "SELECT TOP 1 * FROM MudQCData WHERE Lot_Num='" & KeyValue.ToString & "'"
        Dim strSQL = "SELECT TOP 1 * FROM vu_ProdApp_MudQCData WHERE Lot_Num='" & KeyValue.ToString & "'"
        Dim sqlComm As New SqlCommand(strSQL, sqlConn)

        Dim sqlReader As SqlDataReader
        Try
            LocalMudQC.NewRecord = True
            LocalMudQC.Lot_Num = KeyValue
            sqlConn.Open()
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.SingleResult)
            If sqlReader.Read Then
                With LocalMudQC
                    .NewRecord = False
                    .Lot_Num = sqlReader("Lot_Num") & ""
                    .QC48HourViscosity = clsMain.ConvertNullDouble(sqlReader("QC48HourViscosity"))
                    .QC48HourViscosityDateStamp = sqlReader("QC48HourViscosityDateStamp") & ""
                    .QC48HourViscosityTimeStamp = sqlReader("QC48HourViscosityTimeStamp") & ""
                    .QC48HourViscosityUser = sqlReader("QC48HourViscosityUser") & ""
                    .QCHoldValue = clsMain.ConvertNullDouble(sqlReader("QCHoldValue"))
                    .QCHighLowFlag = sqlReader("QCHighLowFlag") & ""
                    .QCHoldValueDateStamp = sqlReader("QCHoldValueDateStamp") & ""
                    .QCHoldValueTimeStamp = sqlReader("QCHoldValueTimeStamp") & ""
                    .QCHoldValueUser = sqlReader("QCHoldValueUser") & ""
                    .QCReTestViscosity = clsMain.ConvertNullDouble(sqlReader("QCReTestViscosity"))
                    .QCReTestViscosityDateStamp = sqlReader("QCRetestViscosityDateStamp") & ""
                    .QCReTestViscosityTimeStamp = sqlReader("QCRetestViscosityTimeStamp") & ""
                    .QCReTestViscosityUser = sqlReader("QCRetestViscosityUser") & ""
                    '.QCTapeOut = sqlReader("QCTapeOut") & ""
                    '.QCTapeOutDateStamp = sqlReader("QCTapeOutDateStamp") & ""
                    '.QCTapeOutTimeStamp = sqlReader("QCTapeOutTimeStamp") & ""
                    '.QCTapeOutUser = sqlReader("QCTapeOutUser") & ""
                    '.QCTapeIn = sqlReader("QCTapeIn") & ""
                    '.QCTapeInDateStamp = sqlReader("QCTapeInDateStamp") & ""
                    '.QCTapeInTimeStamp = sqlReader("QCTapeInTimeStamp") & ""
                    '.QCTapeInUser = sqlReader("QCTapeInUser") & ""
                    .QCCrack = clsMain.ConvertNullDouble(sqlReader("QCCrack"))
                    .QCCrackDateStamp = sqlReader("QCCrackDateStamp") & ""
                    .QCCrackTimeStamp = sqlReader("QCCrackTimeStamp") & ""
                    .QCCrackUser = sqlReader("QCCrackUser") & ""
                    .QCPockingStart = clsMain.ConvertNullDouble(sqlReader("QCPockingStart"))
                    .QCPockingEnd = clsMain.ConvertNullDouble(sqlReader("QCPockingEnd"))
                    .QCPockingStartEndDateStamp = sqlReader("QCPockingStartEndDateStamp") & ""
                    .QCPockingStartEndTimeStamp = sqlReader("QCPockingStartEndTimeStamp") & ""
                    .QCPockingStartEndUser = sqlReader("QCPockingStartEndUser") & ""
                    .QCNotes = sqlReader("QCNotes") & ""
                    .QCCrack = clsMain.ConvertNullDouble(sqlReader("QCCrack"))
                    'Do These Seperate
                    '.RecipeLabMinVisc = clsMain.ConvertNullInteger(sqlReader("RecipeLabMinVisc"))
                    '.RecipeLabMaxVisc = clsMain.ConvertNullInteger(sqlReader("RecipeLabMaxVisc"))
                    .QCDensity = clsMain.ConvertNullDouble(sqlReader("QCDensity"))
                    .QCGrit = clsMain.ConvertNullDouble(sqlReader("QCGrit"))
                    .QCTapeTop = clsMain.ConvertNullInteger(sqlReader("QCTapeTop"))
                    .QCTapeBottom = clsMain.ConvertNullInteger(sqlReader("QCTapeBottom"))
                End With

            End If

            'Get these direct so if a record has not been saved yet we still have the min max
            Dim LocalBatchRecipeVisc As BatchRecipeVisc
            LocalBatchRecipeVisc = GetBatchRecipeVisc(KeyValue)
            LocalMudQC.RecipeLabMinVisc = LocalBatchRecipeVisc.RecipeLabMinVisc
            LocalMudQC.RecipeLabMaxVisc = LocalBatchRecipeVisc.RecipeLabMaxVisc

            Return LocalMudQC

        Catch
            'Error has occured

            LocalMudQC.Lot_Num = 0

            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If
            Return LocalMudQC
        Finally
            sqlComm.Dispose()
            sqlConn.Close()
        End Try
    End Function

    Function GetBatchStatus(KeyValue As String) As BatchStatus
        Dim sqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("HamiltonNCProduction1").ConnectionString.ToString)
        Dim LocalBatchStatus As New BatchStatus
        Dim clsMain As New clsMain

        Dim strSQL = "SELECT TOP 1 * FROM QCBatchStatus WHERE Lot_Num='" & KeyValue.ToString & "' ORDER BY BatchStatus_ID DESC"

        Dim sqlComm As New SqlCommand(strSQL, sqlConn)

        Dim sqlReader As SqlDataReader
        Try

            LocalBatchStatus.Lot_Num = KeyValue
            sqlConn.Open()
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.SingleResult)
            If sqlReader.Read Then
                With LocalBatchStatus
                    .Lot_Num = sqlReader("Lot_Num") & ""
                    .BatchStatus_ID = clsMain.ConvertNullInteger(sqlReader("BatchStatus_ID"))
                    .BatchStatus = clsMain.ConvertNullInteger(sqlReader("Batch_Status"))
                    .DateTime = sqlReader("DateTimeStamp") & ""
                    .ReasonNotes = sqlReader("Reason_Notes") & ""
                    .UserName = sqlReader("UserName") & ""
                End With
            Else
                With LocalBatchStatus
                    .Lot_Num = KeyValue
                    .BatchStatus_ID = 0
                    .BatchStatus = -1 ' Return a number out of range, no status
                    '.DateTime = vbNull
                    .ReasonNotes = ""
                    .UserName = ""
                End With
            End If

            Return LocalBatchStatus

        Catch
            'Error has occured

            LocalBatchStatus.Lot_Num = 0

            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If
            Return LocalBatchStatus
        Finally
            sqlComm.Dispose()
            sqlConn.Close()
        End Try
    End Function

    Function GetBatchRecipeVisc(KeyValue As String) As BatchRecipeVisc
        Dim sqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("HamiltonNCProduction1").ConnectionString.ToString)
        Dim LocalBatchRecipeVisc As New BatchRecipeVisc
        Dim clsMain As New clsMain

        Dim strSQL = "SELECT TOP 1 * FROM vu_ProdApp_BatchRecipeVisc WHERE Lot_Num='" & KeyValue.ToString & "'"

        Dim sqlComm As New SqlCommand(strSQL, sqlConn)

        Dim sqlReader As SqlDataReader
        Try

            LocalBatchRecipeVisc.Lot_Num = KeyValue
            sqlConn.Open()
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.SingleResult)
            If sqlReader.Read Then
                With LocalBatchRecipeVisc
                    .RecipeLabMaxVisc = clsMain.ConvertNullInteger(sqlReader("RecipeLabMaxVisc"))
                    .RecipeLabMinVisc = clsMain.ConvertNullInteger(sqlReader("RecipeLabMinVisc"))

                End With
            Else
                With LocalBatchRecipeVisc
                    .RecipeLabMaxVisc = 0
                    .RecipeLabMinVisc = 0
                End With
            End If

            Return LocalBatchRecipeVisc

        Catch
            'Error has occured

            LocalBatchRecipeVisc.Lot_Num = 0

            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If
            Return LocalBatchRecipeVisc
        Finally
            sqlComm.Dispose()
            sqlConn.Close()
        End Try
    End Function



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString)
        Dim clsMain As New clsMain

        Dim NewRecordSuccess As Boolean

        'Create Command object
        Dim nonqueryCommand As SqlCommand = thisConnection.CreateCommand()
        Dim sSQL As String
        Dim regDate As DateTime = DateTime.Now
        'Dim strDate As String = regDate.ToString("yyyy-MM-dd HH:mm:ss")

        Try
            NewRecordSuccess = False

            If Me.txtNewRecord.Value = True Then
                If AddNewQCRecord(Me.txtLot_Num.Text) Then
                    'Success, no issues
                    NewRecordSuccess = True
                    Me.txtNewRecord.Value = False
                End If
            Else
                NewRecordSuccess = True
            End If

            ' Open Connection
            thisConnection.Open()

            sSQL = "UPDATE MudQCData Set QC48HourViscosity = @QC48HourViscosity, "
            If clsMain.ConvertNullInteger(txtQC48HourViscosity.Text) > 0 And clsMain.ConvertNullInteger(txtQC48HourViscosity0.Value) = 0 Then
                sSQL = sSQL & "QC48HourViscosityDateStamp = @QC48HourViscosityDateStamp, QC48HourViscosityTimeStamp = @QC48HourViscosityTimeStamp, QC48HourViscosityUser = @QC48HourViscosityUser, "
            End If
            'sSQL = sSQL & "QCHoldValue = @QCHoldValue, QCHighLowFlag = @QCHighLowFlag, "
            'If clsMain.ConvertNullDouble(txtQCHoldValue.Text) > 0 And clsMain.ConvertNullDouble(txtQCHoldValue0.Value) = 0 Then
            ' sSQL = sSQL & "QCHoldValueDateStamp = @QCHoldValueDateStamp, QCHoldValueTimeStamp = @QCHoldValueTimeStamp, QCHoldValueUser = @QCHoldValueUser, "
            'End If
            sSQL = sSQL & "QCReTestViscosity = @QCReTestViscosity, "
            If clsMain.ConvertNullDouble(txtQCReTestViscosity.Text) > 0 And clsMain.ConvertNullDouble(txtQCRetestViscosity0.Value) = 0 Then
                sSQL = sSQL & "QCRetestViscosityDateStamp = @QCRetestViscosityDateStamp, QCRetestViscosityTimeStamp = @QCRetestViscosityTimeStamp, QCRetestViscosityUser = @QCRetestViscosityUser, "
            End If
            'sSQL = sSQL & "QCTapeOut = @QCTapeOut, "
            'If ddlQCTapeOut.Text & "" <> txtQCTapeOut0.Value & "" Then
            'sSQL = sSQL & "QCTapeOutDateStamp = @QCTapeOutDateStamp, QCTapeOutTimeStamp = @QCTapeOutTimeStamp, QCTapeOutUser = @QCTapeOutUser, "
            'End If
            'sSQL = sSQL & "QCTapeIn = @QCTapeIn, "
            'If ddlQCTapeIn.Text & "" <> txtQCTapeIn0.Value & "" Then
            'sSQL = sSQL & "QCTapeInDateStamp = @QCTapeInDateStamp, QCTapeInTimeStamp = @QCTapeInTimeStamp, QCTapeInUser = @QCTapeInUser, "
            'End If
            sSQL = sSQL & "QCCrack = @QCCrack, "
            If clsMain.ConvertNullDouble(txtQCCrack.Text) > 0 And clsMain.ConvertNullDouble(txtQCCrack0.Value) = 0 Then
                sSQL = sSQL & "QCCrackDateStamp = @QCCrackDateStamp, QCCrackTimeStamp = @QCCrackTimeStamp, QCCrackUser = @QCCrackUser, "
            End If
            sSQL = sSQL & "QCPockingStart = @QCPockingStart, "
            sSQL = sSQL & "QCPockingEnd = @QCPockingEnd, "
            If (clsMain.ConvertNullDouble(txtQCPockingStart.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingStart0.Value) = 0) Or (clsMain.ConvertNullDouble(txtQCPockingEnd.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingEnd0.Value) = 0) Then
                sSQL = sSQL & "QCPockingStartEndDateStamp = @QCPockingStartEndDateStamp, QCPockingStartEndTimeStamp = @QCPockingStartEndTimeStamp, QCPockingStartEndUser = @QCPockingStartEndUser, "
            End If
            sSQL = sSQL & "QCDensity = @QCDensity, "
            sSQL = sSQL & "QCGrit = @QCGrit, "
            sSQL = sSQL & "QCTapeTop = @QCTapeTop, "
            sSQL = sSQL & "QCTapeBottom = @QCTapeBottom, "
            sSQL = sSQL & "QCNotes = @QCNotes "
            sSQL = sSQL & "WHERE Lot_Num = @Lot_Num"

            ' Create INSERT statement with named parameters
            nonqueryCommand.CommandText = sSQL

            '************************************************************************************************************************


            ' Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@Lot_Num", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@QC48HourViscosity", SqlDbType.Float)
            If clsMain.ConvertNullInteger(txtQC48HourViscosity.Text) > 0 And clsMain.ConvertNullInteger(txtQC48HourViscosity0.Value) = 0 Then
                nonqueryCommand.Parameters.Add("@QC48HourViscosityDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QC48HourViscosityTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QC48HourViscosityUser", SqlDbType.NVarChar, 50)
            End If
            'nonqueryCommand.Parameters.Add("@QCHoldValue", SqlDbType.Float)
            'nonqueryCommand.Parameters.Add("@QCHighLowFlag", SqlDbType.NVarChar, 1)
            'If clsMain.ConvertNullDouble(txtQCHoldValue.Text) > 0 And clsMain.ConvertNullDouble(txtQCHoldValue0.Value) = 0 Then
            'nonqueryCommand.Parameters.Add("@QCHoldValueDateStamp", SqlDbType.DateTime)
            'nonqueryCommand.Parameters.Add("@QCHoldValueTimeStamp", SqlDbType.DateTime)
            'nonqueryCommand.Parameters.Add("@QCHoldValueUser", SqlDbType.NVarChar, 50)
            'End If
            nonqueryCommand.Parameters.Add("@QCReTestViscosity", SqlDbType.Float)
            If clsMain.ConvertNullDouble(txtQCReTestViscosity.Text) > 0 And clsMain.ConvertNullDouble(txtQCRetestViscosity0.Value) = 0 Then
                nonqueryCommand.Parameters.Add("@QCRetestViscosityDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCRetestViscosityTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCRetestViscosityUser", SqlDbType.NVarChar, 50)
            End If
            'nonqueryCommand.Parameters.Add("@QCTapeOut", SqlDbType.NVarChar, 2)
            'If ddlQCTapeOut.Text & "" <> txtQCTapeOut0.Value & "" Then
            'nonqueryCommand.Parameters.Add("@QCTapeOutDateStamp", SqlDbType.DateTime)
            'nonqueryCommand.Parameters.Add("@QCTapeOutTimeStamp", SqlDbType.DateTime)
            'nonqueryCommand.Parameters.Add("@QCTapeOutUser", SqlDbType.NVarChar, 50)
            'End If
            'nonqueryCommand.Parameters.Add("@QCTapeIn", SqlDbType.NVarChar, 2)
            'If ddlQCTapeIn.Text & "" <> txtQCTapeIn0.Value & "" Then
            'nonqueryCommand.Parameters.Add("@QCTapeInDateStamp", SqlDbType.DateTime)
            'nonqueryCommand.Parameters.Add("@QCTapeInTimeStamp", SqlDbType.DateTime)
            'nonqueryCommand.Parameters.Add("@QCTapeInUser", SqlDbType.NVarChar, 50)
            'End If
            nonqueryCommand.Parameters.Add("@QCCrack", SqlDbType.Float)
            If clsMain.ConvertNullDouble(txtQCCrack.Text) > 0 And clsMain.ConvertNullDouble(txtQCCrack0.Value) = 0 Then
                nonqueryCommand.Parameters.Add("@QCCrackDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCCrackTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCCrackUser", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCPockingStart", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@QCPockingEnd", SqlDbType.Float)
            If (clsMain.ConvertNullDouble(txtQCPockingStart.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingStart0.Value) = 0) Or (clsMain.ConvertNullDouble(txtQCPockingEnd.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingEnd0.Value) = 0) Then
                nonqueryCommand.Parameters.Add("@QCPockingStartEndDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCPockingStartEndTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCPockingStartEndUser", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCDensity", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@QCGrit", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@QCTapeTop", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@QCTapeBottom", SqlDbType.SmallInt)
            nonqueryCommand.Parameters.Add("@QCNotes", SqlDbType.NVarChar, 500)


            '**********************************************************************************************************************


            nonqueryCommand.Parameters("@Lot_Num").Value = txtLot_Num.Text & ""
            nonqueryCommand.Parameters("@QC48HourViscosity").Value = clsMain.ConvertNullDouble(txtQC48HourViscosity.Text)
            If clsMain.ConvertNullInteger(txtQC48HourViscosity.Text) > 0 And clsMain.ConvertNullInteger(txtQC48HourViscosity0.Value) = 0 Then
                nonqueryCommand.Parameters("@QC48HourViscosityDateStamp").Value = Now
                nonqueryCommand.Parameters("@QC48HourViscosityTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QC48HourViscosityUser").Value = Session("UserID")
            End If
            'nonqueryCommand.Parameters("@QCHoldValue").Value = clsMain.ConvertNullDouble(txtQCHoldValue.Text)
            'nonqueryCommand.Parameters("@QCHighLowFlag").Value = ddlQCHighLowFlag.SelectedValue
            'If clsMain.ConvertNullDouble(txtQCHoldValue.Text) > 0 And clsMain.ConvertNullDouble(txtQCHoldValue0.Value) = 0 Then
            'nonqueryCommand.Parameters("@QCHoldValueDateStamp").Value = Now
            'nonqueryCommand.Parameters("@QCHoldValueTimeStamp").Value = Now
            'nonqueryCommand.Parameters("@QCHoldValueUser").Value = Session("UserID")
            'End If
            nonqueryCommand.Parameters("@QCReTestViscosity").Value = clsMain.ConvertNullDouble(txtQCReTestViscosity.Text)
            If clsMain.ConvertNullDouble(txtQCReTestViscosity.Text) > 0 And clsMain.ConvertNullDouble(txtQCRetestViscosity0.Value) = 0 Then
                nonqueryCommand.Parameters("@QCRetestViscosityDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCRetestViscosityTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCRetestViscosityUser").Value = Session("UserID")
            End If
            'nonqueryCommand.Parameters("@QCTapeOut").Value = ddlQCTapeOut.Text & ""
            'If ddlQCTapeOut.Text & "" <> txtQCTapeOut0.Value & "" Then
            'nonqueryCommand.Parameters("@QCTapeOutDateStamp").Value = Now
            'nonqueryCommand.Parameters("@QCTapeOutTimeStamp").Value = Now
            'nonqueryCommand.Parameters("@QCTapeOutUser").Value = Session("UserID")
            'End If
            'nonqueryCommand.Parameters("@QCTapeIn").Value = ddlQCTapeIn.Text & ""
            'If ddlQCTapeIn.Text & "" <> txtQCTapeIn0.Value & "" Then
            'nonqueryCommand.Parameters("@QCTapeInDateStamp").Value = Now
            'nonqueryCommand.Parameters("@QCTapeInTimeStamp").Value = Now
            'nonqueryCommand.Parameters("@QCTapeInUser").Value = Session("UserID")
            'End If
            nonqueryCommand.Parameters("@QCCrack").Value = clsMain.ConvertNullDouble(txtQCCrack.Text)
            If clsMain.ConvertNullDouble(txtQCCrack.Text) > 0 And clsMain.ConvertNullDouble(txtQCCrack0.Value) = 0 Then
                nonqueryCommand.Parameters("@QCCrackDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCCrackTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCCrackUser").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCPockingStart").Value = clsMain.ConvertNullDouble(txtQCPockingStart.Text)
            nonqueryCommand.Parameters("@QCPockingEnd").Value = clsMain.ConvertNullDouble(txtQCPockingEnd.Text)
            If (clsMain.ConvertNullDouble(txtQCPockingStart.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingStart0.Value) = 0) Or (clsMain.ConvertNullDouble(txtQCPockingEnd.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingEnd0.Value) = 0) Then
                nonqueryCommand.Parameters("@QCPockingStartEndDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCPockingStartEndTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCPockingStartEndUser").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCDensity").Value = clsMain.ConvertNullDouble(txtQCDensity.Text)
            nonqueryCommand.Parameters("@QCGrit").Value = clsMain.ConvertNullDouble(txtQCGrit.Text)
            nonqueryCommand.Parameters("@QCTapeTop").Value = clsMain.ConvertNullInteger(txtQCTapeTop.Text)
            nonqueryCommand.Parameters("@QCTapeBottom").Value = clsMain.ConvertNullInteger(txtQCTapeBottom.Text)
            nonqueryCommand.Parameters("@QCNotes").Value = txtQCNotes.Text & ""


            If NewRecordSuccess = True Then
                nonqueryCommand.ExecuteNonQuery()

                Dim LocalBatchStatus As BatchStatus

                LocalBatchStatus = GetBatchStatus(txtLot_Num.Text & "")

                'If the record was saved then update Hold Status if needed, original entry of 48 hr only, and no prior Batch Status exists.
                If clsMain.ConvertNullInteger(txtQC48HourViscosity.Text) > 0 And LocalBatchStatus.BatchStatus = -1 Then 'clsMain.ConvertNullInteger(txtQC48HourViscosity0.Value) = 0 Then
                    ' If No retest then use the 48 hr value
                    If (clsMain.ConvertNullInteger(txtQC48HourViscosity.Text)) < clsMain.ConvertNullInteger(txtQCRecipeLabMinVisc.Text) Or (clsMain.ConvertNullInteger(txtQC48HourViscosity.Text) > clsMain.ConvertNullInteger(txtQCRecipeLabMaxVisc.Text)) Then
                        If AddNewBatchStatusRecord(Me.txtLot_Num.Text, 1, "Auto Hold Based On 48 Hr Viscosity of " & Me.txtQC48HourViscosity.Text) Then
                            'Success
                        End If
                    Else
                        If AddNewBatchStatusRecord(Me.txtLot_Num.Text, 0, "Batch Status Good Based On 48 Hr Viscosity of " & Me.txtQC48HourViscosity.Text) Then
                            'Success
                        End If
                    End If
                Else
                    'Retest Value exists so use it.
                    'If (clsMain.ConvertNullInteger(txtQCReTestViscosity.Text)) < clsMain.ConvertNullInteger(txtQCRecipeLabMinVisc.Text) Or (clsMain.ConvertNullInteger(txtQCReTestViscosity.Text) > clsMain.ConvertNullInteger(txtQCRecipeLabMaxVisc.Text)) Then
                    ' If AddNewBatchStatusRecord(Me.txtLot_Num.Text, 1, "Auto Hold Based On Re-Test Viscosity of " & Me.txtQCReTestViscosity.Text) Then
                    ' 'Success
                    'End If
                    'Else
                    'If AddNewBatchStatusRecord(Me.txtLot_Num.Text, 0, "Batch Status Good Based On Re-Test Viscosity of " & Me.txtQCReTestViscosity.Text) Then
                    ''Success
                    'End If
                    'End If


                End If
            Else
                    'Error has occured
                    Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)
                mpLabel.Text = "Error creating new QC Record"
            End If

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        Finally
            ' Close Connection
            thisConnection.Close()

            Response.Redirect("MudBatch.aspx")

        End Try
    End Sub

    Private Function AddNewQCRecord(Lot_Num As String) As Boolean
        Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString)
        Dim clsMain As New clsMain
        'Create Command object
        Dim nonqueryCommand As SqlCommand = thisConnection.CreateCommand()
        Dim sSQL As String
        Dim regDate As DateTime = DateTime.Now


        Try
            ' Open Connection
            thisConnection.Open()


            sSQL = "INSERT INTO MudQCData (Lot_Num) "
            sSQL = sSQL & "VALUES (@Lot_Num)"

            ' Create INSERT statement with named parameters
            nonqueryCommand.CommandText = sSQL


            ' Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@Lot_Num", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters("@Lot_Num").Value = Lot_Num

            nonqueryCommand.ExecuteNonQuery()

            Return True

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

            Return False

        Finally
            ' Close Connection
            thisConnection.Close()



        End Try
    End Function

    Private Function AddNewBatchStatusRecord(Lot_Num As String, Batch_Status As Integer, Reason_Notes As String) As Boolean
        Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString)
        Dim clsMain As New clsMain
        'Create Command object
        Dim nonqueryCommand As SqlCommand = thisConnection.CreateCommand()
        Dim sSQL As String
        Dim regDate As DateTime = DateTime.Now


        Try
            If Reason_Notes & "" = "" Then
                'Notes must be entered

                Me.btnSubmit.Text = "Note Required To Submit"
                Me.btnSubmit.ForeColor = Drawing.Color.Red
                Exit Function
            End If

            ' Open Connection
            thisConnection.Open()


            sSQL = "INSERT INTO QCBatchStatus (Lot_Num, Batch_Status, DateTimeStamp, Reason_Notes, UserName) "
            sSQL = sSQL & "VALUES (@Lot_Num, @Batch_Status, @DateTimeStamp, @Reason_Notes, @UserName )"

            ' Create INSERT statement with named parameters
            nonqueryCommand.CommandText = sSQL


            ' Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@Lot_Num", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@Batch_Status", SqlDbType.TinyInt)
            nonqueryCommand.Parameters.Add("@DateTimeStamp", SqlDbType.DateTime)
            nonqueryCommand.Parameters.Add("@Reason_Notes", SqlDbType.NVarChar, 200)
            nonqueryCommand.Parameters.Add("@UserName", SqlDbType.NVarChar, 50)

            nonqueryCommand.Parameters("@Lot_Num").Value = Lot_Num
            nonqueryCommand.Parameters("@Batch_Status").Value = Batch_Status
            nonqueryCommand.Parameters("@DateTimeStamp").Value = Now
            nonqueryCommand.Parameters("@Reason_Notes").Value = Reason_Notes
            nonqueryCommand.Parameters("@UserName").Value = Session("UserName")


            nonqueryCommand.ExecuteNonQuery()

            Return True

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

            Return False

        Finally
            ' Close Connection
            thisConnection.Close()



        End Try
    End Function

    Private Sub btnHold_Click(sender As Object, e As EventArgs) Handles btnHold.Click
        Try
            Me.txtReason_Notes.Visible = True
            Me.btnSubmit.Visible = True
            Session("HoldStatus") = 1


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If AddNewBatchStatusRecord(Me.txtLot_Num.Text, Session("HoldStatus"), Me.txtReason_Notes.Text) Then
                'Success

                HoldValuesSetup(Session("HoldStatus"))

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReRun_Click(sender As Object, e As EventArgs) Handles btnReRun.Click
        Try
            Me.txtReason_Notes.Visible = True
            Me.btnSubmit.Visible = True
            Session("HoldStatus") = 2


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        Try
            Me.txtReason_Notes.Visible = True
            Me.btnSubmit.Visible = True
            Session("HoldStatus") = 3


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRelease_Click(sender As Object, e As EventArgs) Handles btnRelease.Click
        Try
            Me.txtReason_Notes.Visible = True
            Me.btnSubmit.Visible = True
            Session("HoldStatus") = 4


        Catch ex As Exception

        End Try
    End Sub

    Private Sub HoldValuesSetup(HoldStatus As Integer)
        Try
            If Session("UserType") = "A" Then
                Select Case HoldStatus
                    Case 0
                        Me.txtHoldStatus.Text = "OK"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Green
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = True
                        Me.btnRelease.Visible = False
                        Me.btnReject.Visible = True
                    Case 1
                        Me.txtHoldStatus.Text = "HOLD"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Red
                        Me.btnHold.Visible = False
                        Me.btnReRun.Visible = True
                        Me.btnRelease.Visible = True
                        Me.btnReject.Visible = True
                    Case 2
                        Me.txtHoldStatus.Text = "RE-RUN"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Yellow
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = False
                        Me.btnRelease.Visible = True
                        Me.btnReject.Visible = True
                    Case 3
                        Me.txtHoldStatus.Text = "REJECT"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Red
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = True
                        Me.btnRelease.Visible = True
                        Me.btnReject.Visible = False
                    Case 4
                        Me.txtHoldStatus.Text = "RELEASE"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Green
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = True
                        Me.btnRelease.Visible = False
                        Me.btnReject.Visible = True
                    Case Else
                        Me.txtHoldStatus.Text = "Unknown"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Yellow
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = True
                        Me.btnRelease.Visible = True
                        Me.btnReject.Visible = True
                End Select
            Else
                Select Case HoldStatus
                    Case 0
                        Me.txtHoldStatus.Text = "OK"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Green
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = False
                        Me.btnRelease.Visible = False
                        Me.btnReject.Visible = False
                    Case 1
                        Me.txtHoldStatus.Text = "HOLD"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Red
                        Me.btnHold.Visible = False
                        Me.btnReRun.Visible = False
                        Me.btnRelease.Visible = False
                        Me.btnReject.Visible = False
                    Case 2
                        Me.txtHoldStatus.Text = "RE-RUN"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Yellow
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = False
                        Me.btnRelease.Visible = False
                        Me.btnReject.Visible = False
                    Case 3
                        Me.txtHoldStatus.Text = "REJECT"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Red
                        Me.btnHold.Visible = False
                        Me.btnReRun.Visible = False
                        Me.btnRelease.Visible = False
                        Me.btnReject.Visible = False
                    Case 4
                        Me.txtHoldStatus.Text = "RELEASE"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Green
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = False
                        Me.btnRelease.Visible = False
                        Me.btnReject.Visible = False
                    Case Else
                        Me.txtHoldStatus.Text = "Unknown"
                        Me.txtHoldStatus.ForeColor = Drawing.Color.Yellow
                        Me.btnHold.Visible = True
                        Me.btnReRun.Visible = False
                        Me.btnRelease.Visible = False
                        Me.btnReject.Visible = False
                End Select
            End If
            Me.txtReason_Notes.Visible = False
            Me.btnSubmit.Visible = False
            Me.txtReason_Notes.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnShowHistory_Click(sender As Object, e As EventArgs) Handles btnShowHistory.Click
        Try
            If Me.gvHistory.Visible Then
                Me.gvHistory.Visible = False
                Me.btnShowHistory.Text = "Show"
            Else
                Me.gvHistory.Visible = True
                Me.btnShowHistory.Text = "Hide"
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class