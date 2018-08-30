Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports ProductionApp17.clsMain
Public Class MudQCEdit
    Inherits System.Web.UI.Page

    Public Structure ProductionData
        Public KeyNumber As Integer
        Public QC48HourViscosity As Double
        Public QC48HourViscosityDateStamp As String
        Public QC48HourViscosityTimeStamp As String
        Public QC48HourViscosityUserStamp As String
        Public QCHoldValue As Double
        Public QCHighLowFlag As String
        Public QCHoldValueDateStamp As String
        Public QCHoldValueTimeStamp As String
        Public QCHoldValueUserStamp As String
        Public QCReTestViscosity As Double
        Public QCRetestViscosityDateStamp As String
        Public QCRetestViscosityTimeStamp As String
        Public QCRetestViscosityUserStamp As String
        Public QCTapeOut As String
        Public QCTapeOutDateStamp As String
        Public QCTapeOutTimeStamp As String
        Public QCTapeOutUserStamp As String
        Public QCTapeIn As String
        Public QCTapeInDateStamp As String
        Public QCTapeInTimeStamp As String
        Public QCTapeInUserStamp As String
        Public QCCrack As Double
        Public QCCrackDateStamp As String
        Public QCCrackTimeStamp As String
        Public QCCrackUserStamp As String
        Public QCPockingStart As Double
        Public QCPockingEnd As Double
        Public QCPockingStartEndDateStamp As String
        Public QCPockingStartEndTimeStamp As String
        Public QCPockingStartEndUserStamp As String
        Public QCNotes As String
        Public LastUserID As String
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


                LocalProductionItem = GetProductionItem(Session("KeyValue"))
                If LocalProductionItem.KeyNumber <> 0 Then
                    'We have a valid item
                    Me.txtKeyNumber.Text = LocalProductionItem.KeyNumber
                    Me.txtQC48HourViscosity.Text = LocalProductionItem.QC48HourViscosity
                    Me.txtQC48HourViscosity0.Value = LocalProductionItem.QC48HourViscosity
                    Me.txtQCHoldValue.Text = LocalProductionItem.QCHoldValue
                    Me.ddlQCHighLowFlag.Text = LocalProductionItem.QCHighLowFlag
                    Me.txtQCReTestViscosity.Text = LocalProductionItem.QCReTestViscosity
                    Me.ddlQCTapeOut.Text = LocalProductionItem.QCTapeOut
                    Me.txtQCTapeOut0.Value = LocalProductionItem.QCTapeOut
                    Me.ddlQCTapeIn.Text = LocalProductionItem.QCTapeIn
                    Me.txtQCTapeIn0.Value = LocalProductionItem.QCTapeIn
                    Me.txtQCCrack.Text = LocalProductionItem.QCCrack
                    Me.txtQCPockingStart.Text = LocalProductionItem.QCPockingStart
                    Me.txtQCPockingEnd.Text = LocalProductionItem.QCPockingEnd
                    Me.txtQCPockingStart0.Value = LocalProductionItem.QCPockingStart
                    Me.txtQCPockingEnd0.Value = LocalProductionItem.QCPockingEnd
                    Me.txtQCNotes.Text = LocalProductionItem.QCNotes

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
                    .QC48HourViscosity = clsMain.ConvertNullDouble(sqlReader("QC48HourViscosity"))
                    .QC48HourViscosityDateStamp = sqlReader("QC48HourViscosityDateStamp") & ""
                    .QC48HourViscosityTimeStamp = sqlReader("QC48HourViscosityTimeStamp") & ""
                    .QC48HourViscosityUserStamp = sqlReader("QC48HourViscosityUserStamp") & ""
                    .QCHoldValue = clsMain.ConvertNullDouble(sqlReader("QCHoldValue"))
                    .QCHighLowFlag = sqlReader("QCHighLowFlag") & ""
                    .QCHoldValueDateStamp = sqlReader("QCHoldValueDateStamp") & ""
                    .QCHoldValueTimeStamp = sqlReader("QCHoldValueTimeStamp") & ""
                    .QCHoldValueUserStamp = sqlReader("QCHoldValueUserStamp") & ""
                    .QCReTestViscosity = clsMain.ConvertNullDouble(sqlReader("QCReTestViscosity"))
                    .QCRetestViscosityDateStamp = sqlReader("QCRetestViscosityDateStamp") & ""
                    .QCRetestViscosityTimeStamp = sqlReader("QCRetestViscosityTimeStamp") & ""
                    .QCRetestViscosityUserStamp = sqlReader("QCRetestViscosityUserStamp") & ""
                    .QCTapeOut = sqlReader("QCTapeOut") & ""
                    .QCTapeOutDateStamp = sqlReader("QCTapeOutDateStamp") & ""
                    .QCTapeOutTimeStamp = sqlReader("QCTapeOutTimeStamp") & ""
                    .QCTapeOutUserStamp = sqlReader("QCTapeOutUserStamp") & ""
                    .QCTapeIn = sqlReader("QCTapeIn") & ""
                    .QCTapeInDateStamp = sqlReader("QCTapeInDateStamp") & ""
                    .QCTapeInTimeStamp = sqlReader("QCTapeInTimeStamp") & ""
                    .QCTapeInUserStamp = sqlReader("QCTapeInUserSTamp") & ""
                    .QCCrack = clsMain.ConvertNullDouble(sqlReader("QCCrack"))
                    .QCCrackDateStamp = sqlReader("QCCrackDateStamp") & ""
                    .QCCrackTimeStamp = sqlReader("QCCrackTimeStamp") & ""
                    .QCCrackUserStamp = sqlReader("QCCrackUserStamp") & ""
                    .QCPockingStart = clsMain.ConvertNullDouble(sqlReader("QCPockingStart"))
                    .QCPockingEnd = clsMain.ConvertNullDouble(sqlReader("QCPockingEnd"))
                    .QCPockingStartEndDateStamp = sqlReader("QCPockingStartEndDateStamp") & ""
                    .QCPockingStartEndTimeStamp = sqlReader("QCPockingStartEndTimeStamp") & ""
                    .QCPockingStartEndUserStamp = sqlReader("QCPockingStartEndUserStamp") & ""
                    .QCNotes = sqlReader("QCNotes") & ""
                    .LastUserID = sqlReader("LastUserID") & ""
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

            sSQL = "UPDATE MudProductionLog Set QC48HourViscosity = @QC48HourViscosity, "
            If clsMain.ConvertNullInteger(txtQC48HourViscosity.Text) > 0 And clsMain.ConvertNullInteger(txtQC48HourViscosity0.Value) = 0 Then
                sSQL = sSQL & "QC48HourViscosityDateStamp = @QC48HourViscosityDateStamp, QC48HourViscosityTimeStamp = @QC48HourViscosityTimeStamp, QC48HourViscosityUserStamp = @QC48HourViscosityUserStamp, "
            End If
            sSQL = sSQL & "QCHoldValue = @QCHoldValue, QCHighLowFlag = @QCHighLowFlag, "
            If clsMain.ConvertNullDouble(txtQCHoldValue.Text) > 0 And clsMain.ConvertNullDouble(txtQCHoldValue0.Value) = 0 Then
                sSQL = sSQL & "QCHoldValueDateStamp = @QCHoldValueDateStamp, QCHoldValueTimeStamp = @QCHoldValueTimeStamp, QCHoldValueUserStamp = @QCHoldValueUserStamp, "
            End If
            sSQL = sSQL & "QCReTestViscosity = @QCReTestViscosity, "
            If clsMain.ConvertNullDouble(txtQCReTestViscosity.Text) > 0 And clsMain.ConvertNullDouble(txtQCRetestViscosity0.Value) = 0 Then
                sSQL = sSQL & "QCRetestViscosityDateStamp = @QCRetestViscosityDateStamp, QCRetestViscosityTimeStamp = @QCRetestViscosityTimeStamp, QCRetestViscosityUserStamp = @QCRetestViscosityUserStamp, "
            End If
            sSQL = sSQL & "QCTapeOut = @QCTapeOut, "
            If ddlQCTapeOut.Text & "" <> txtQCTapeOut0.Value & "" Then
                sSQL = sSQL & "QCTapeOutDateStamp = @QCTapeOutDateStamp, QCTapeOutTimeStamp = @QCTapeOutTimeStamp, QCTapeOutUserStamp = @QCTapeOutUserStamp, "
            End If
            sSQL = sSQL & "QCTapeIn = @QCTapeIn, "
            If ddlQCTapeIn.Text & "" <> txtQCTapeIn0.Value & "" Then
                sSQL = sSQL & "QCTapeInDateStamp = @QCTapeInDateStamp, QCTapeInTimeStamp = @QCTapeInTimeStamp, QCTapeInUserStamp = @QCTapeInUserStamp, "
            End If
            sSQL = sSQL & "QCCrack = @QCCrack, "
            If clsMain.ConvertNullDouble(txtQCCrack.Text) > 0 And clsMain.ConvertNullDouble(txtQCCrack0.Value) = 0 Then
                sSQL = sSQL & "QCCrackDateStamp = @QCCrackDateStamp, QCCrackTimeStamp = @QCCrackTimeStamp, QCCrackUserStamp = @QCCrackUserStamp, "
            End If
            sSQL = sSQL & "QCPockingStart = @QCPockingStart, "
            sSQL = sSQL & "QCPockingEnd = @QCPockingEnd, "
            If (clsMain.ConvertNullDouble(txtQCPockingStart.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingStart0.Value) = 0) Or (clsMain.ConvertNullDouble(txtQCPockingEnd.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingEnd0.Value) = 0) Then
                sSQL = sSQL & "QCPockingStartEndDateStamp = @QCPockingStartEndDateStamp, QCPockingStartEndTimeStamp = @QCPockingStartEndTimeStamp, QCPockingStartEndUserStamp = @QCPockingStartEndUserStamp, "
            End If
            sSQL = sSQL & "QCNotes = @QCNotes, "
            sSQL = sSQL & "LastUserID = @LastUserID, "
            sSQL = sSQL & "LastUpdate = @LastUpdate "
            sSQL = sSQL & "WHERE KeyNumber = @KeyNumber"

            ' Create INSERT statement with named parameters
            nonqueryCommand.CommandText = sSQL

            ' Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@KeyNumber", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@QC48HourViscosity", SqlDbType.Float)
            If clsMain.ConvertNullInteger(txtQC48HourViscosity.Text) > 0 And clsMain.ConvertNullInteger(txtQC48HourViscosity0.Value) = 0 Then
                nonqueryCommand.Parameters.Add("@QC48HourViscosityDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QC48HourViscosityTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QC48HourViscosityUserStamp", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCHoldValue", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@QCHighLowFlag", SqlDbType.NVarChar, 1)
            If clsMain.ConvertNullDouble(txtQCHoldValue.Text) > 0 And clsMain.ConvertNullDouble(txtQCHoldValue0.Value) = 0 Then
                nonqueryCommand.Parameters.Add("@QCHoldValueDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCHoldValueTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCHoldValueUserStamp", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCReTestViscosity", SqlDbType.Float)
            If clsMain.ConvertNullDouble(txtQCReTestViscosity.Text) > 0 And clsMain.ConvertNullDouble(txtQCRetestViscosity0.Value) = 0 Then
                nonqueryCommand.Parameters.Add("@QCRetestViscosityDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCRetestViscosityTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCRetestViscosityUserStamp", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCTapeOut", SqlDbType.NVarChar, 2)
            If ddlQCTapeOut.Text & "" <> txtQCTapeOut0.Value & "" Then
                nonqueryCommand.Parameters.Add("@QCTapeOutDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCTapeOutTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCTapeOutUserStamp", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCTapeIn", SqlDbType.NVarChar, 2)
            If ddlQCTapeIn.Text & "" <> txtQCTapeIn0.Value & "" Then
                nonqueryCommand.Parameters.Add("@QCTapeInDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCTapeInTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCTapeInUserStamp", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCCrack", SqlDbType.Float)
            If clsMain.ConvertNullDouble(txtQCCrack.Text) > 0 And clsMain.ConvertNullDouble(txtQCCrack0.Value) = 0 Then
                nonqueryCommand.Parameters.Add("@QCCrackDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCCrackTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCCrackUserStamp", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCPockingStart", SqlDbType.Float)
            nonqueryCommand.Parameters.Add("@QCPockingEnd", SqlDbType.Float)
            If (clsMain.ConvertNullDouble(txtQCPockingStart.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingStart0.Value) = 0) Or (clsMain.ConvertNullDouble(txtQCPockingEnd.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingEnd0.Value) = 0) Then
                nonqueryCommand.Parameters.Add("@QCPockingStartEndDateStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCPockingStartEndTimeStamp", SqlDbType.DateTime)
                nonqueryCommand.Parameters.Add("@QCPockingStartEndUserStamp", SqlDbType.NVarChar, 50)
            End If
            nonqueryCommand.Parameters.Add("@QCNotes", SqlDbType.NVarChar, 500)
            nonqueryCommand.Parameters.Add("@LastUserID", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@LastUpdate", SqlDbType.DateTime)


            nonqueryCommand.Parameters("@KeyNumber").Value = clsMain.ConvertNullInteger(txtKeyNumber.Text)
            nonqueryCommand.Parameters("@QC48HourViscosity").Value = clsMain.ConvertNullDouble(txtQC48HourViscosity.Text)
            If clsMain.ConvertNullInteger(txtQC48HourViscosity.Text) > 0 And clsMain.ConvertNullInteger(txtQC48HourViscosity0.Value) = 0 Then
                nonqueryCommand.Parameters("@QC48HourViscosityDateStamp").Value = Now
                nonqueryCommand.Parameters("@QC48HourViscosityTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QC48HourViscosityUserStamp").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCHoldValue").Value = clsMain.ConvertNullDouble(txtQCHoldValue.Text)
            nonqueryCommand.Parameters("@QCHighLowFlag").Value = ddlQCHighLowFlag.SelectedValue
            If clsMain.ConvertNullDouble(txtQCHoldValue.Text) > 0 And clsMain.ConvertNullDouble(txtQCHoldValue0.Value) = 0 Then
                nonqueryCommand.Parameters("@QCHoldValueDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCHoldValueTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCHoldValueUserStamp").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCReTestViscosity").Value = clsMain.ConvertNullDouble(txtQCReTestViscosity.Text)
            If clsMain.ConvertNullDouble(txtQCReTestViscosity.Text) > 0 And clsMain.ConvertNullDouble(txtQCRetestViscosity0.Value) = 0 Then
                nonqueryCommand.Parameters("@QCRetestViscosityDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCRetestViscosityTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCRetestViscosityUserStamp").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCTapeOut").Value = ddlQCTapeOut.Text & ""
            If ddlQCTapeOut.Text & "" <> txtQCTapeOut0.Value & "" Then
                nonqueryCommand.Parameters("@QCTapeOutDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCTapeOutTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCTapeOutUserStamp").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCTapeIn").Value = ddlQCTapeIn.Text & ""
            If ddlQCTapeIn.Text & "" <> txtQCTapeIn0.Value & "" Then
                nonqueryCommand.Parameters("@QCTapeInDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCTapeInTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCTapeInUserStamp").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCCrack").Value = clsMain.ConvertNullDouble(txtQCCrack.Text)
            If clsMain.ConvertNullDouble(txtQCCrack.Text) > 0 And clsMain.ConvertNullDouble(txtQCCrack0.Value) = 0 Then
                nonqueryCommand.Parameters("@QCCrackDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCCrackTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCCrackUserStamp").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCPockingStart").Value = clsMain.ConvertNullDouble(txtQCPockingStart.Text)
            nonqueryCommand.Parameters("@QCPockingEnd").Value = clsMain.ConvertNullDouble(txtQCPockingEnd.Text)
            If (clsMain.ConvertNullDouble(txtQCPockingStart.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingStart0.Value) = 0) Or (clsMain.ConvertNullDouble(txtQCPockingEnd.Text) > 0 And clsMain.ConvertNullDouble(txtQCPockingEnd0.Value) = 0) Then
                nonqueryCommand.Parameters("@QCPockingStartEndDateStamp").Value = Now
                nonqueryCommand.Parameters("@QCPockingStartEndTimeStamp").Value = Now
                nonqueryCommand.Parameters("@QCPockingStartEndUserStamp").Value = Session("UserID")
            End If
            nonqueryCommand.Parameters("@QCNotes").Value = txtQCNotes.Text & ""
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

            Response.Redirect("MudQC.aspx")

        End Try
    End Sub

End Class