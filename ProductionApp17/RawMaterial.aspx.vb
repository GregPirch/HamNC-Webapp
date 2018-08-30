Imports System.Data.SqlClient

Public Class RawMaterial
    Inherits System.Web.UI.Page
    Public LocalConnectionString As String
    'Public Property GridView1 As Object 'added by greg


    'Public DateToShow As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim clsMain As New clsMain
        Dim DateToShow As Date

        DateToShow = CType(Session("glbDateToShow"), Date)
        If DateToShow < "01/01/2000" Then
            DateToShow = Date.Today
            Session("glbDateToShow") = CType(DateToShow, String)
        End If


        Try
            If Session("UserID") >= 0 Then
                'Valid User Has Logged In

            Else
                'Force a user login
                Session("UserName") = "No Current User"
                Response.Redirect("Login.aspx")
            End If


            If IsPostBack = False Then
                Dim constr As String = ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString
                Dim con As New SqlConnection(constr)
                Dim cmd As New SqlCommand()


                Me.txtDateToShow.Text = Session("glbDateToShow")

                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_Return7DaysOfRawMaterialUsage"
                cmd.Parameters.Add("@date_end_str", SqlDbType.Date).Value = CType(Session("glbDateToShow"), String)
                cmd.Connection = con

                Try
                    con.Open()
                    GridView1.EmptyDataText = "No Records Found"
                    GridView1.DataSource = cmd.ExecuteReader()

                    GridView1.DataBind()


                    'get/select the first row of data
                    Dim row As GridViewRow = GridView1.Rows(0)
                    Dim sDate As String
                    sDate = Replace(Replace(row.Cells(1).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)

                    Me.lFirstDate.Text = sDate
                    sDate = Replace(Replace(row.Cells(7).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                    Me.lLastDate.Text = sDate


                    'Change the Header Discriptions
                    GridView1.HeaderRow.Cells(1).Text = Me.lFirstDate.Text & " Sun"

                    sDate = Replace(Replace(row.Cells(2).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                    GridView1.HeaderRow.Cells(2).Text = sDate & " Mon"

                    sDate = Replace(Replace(row.Cells(3).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                    GridView1.HeaderRow.Cells(3).Text = sDate & " Tue"

                    sDate = Replace(Replace(row.Cells(4).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                    GridView1.HeaderRow.Cells(4).Text = sDate & " Wed"

                    sDate = Replace(Replace(row.Cells(5).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                    GridView1.HeaderRow.Cells(5).Text = sDate & " Thu"

                    sDate = Replace(Replace(row.Cells(6).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                    GridView1.HeaderRow.Cells(6).Text = sDate & " Fri"

                    GridView1.HeaderRow.Cells(7).Text = Me.lLastDate.Text & " Sat"

                    'Hide the first row (first row set above by  Dim row As GridViewRow = GridView1.Rows(0) )
                    row.Visible = False

                    Me.lRecordCount.Text = GridView1.Rows.Count - 1

                Catch ex As Exception
                    Throw ex
                Finally
                    con.Close()
                    con.Dispose()
                End Try

            End If

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try

    End Sub



    Protected Sub BtnGetWeekBefore_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim CommandName As String = btn.CommandName
        Dim CommandArgument As String = btn.CommandArgument

        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString
            Dim con As New SqlConnection(constr)
            'Dim reader As SqlDataReader
            Dim cmd As New SqlCommand()
            Dim DateToShow As Date

            DateToShow = CType(Session("glbDateToShow"), Date)
            DateToShow = DateToShow.AddDays(-7)
            Session("glbDateToShow") = CType(DateToShow, String)
            Me.txtDateToShow.Text = Session("glbDateToShow")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Return7DaysOfRawMaterialUsage"
            cmd.Parameters.Add("@date_end_str", SqlDbType.Date).Value = CType(DateToShow, String)
            cmd.Connection = con

            Try
                con.Open()
                GridView1.EmptyDataText = "No Records Found"
                GridView1.DataSource = cmd.ExecuteReader()
                GridView1.DataBind()

                'get/select the first row of data
                Dim row As GridViewRow = GridView1.Rows(0)
                Dim sDate As String
                sDate = Replace(Replace(row.Cells(1).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)

                Me.lFirstDate.Text = sDate
                sDate = Replace(Replace(row.Cells(7).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                Me.lLastDate.Text = sDate


                'Change the Header Discriptions
                GridView1.HeaderRow.Cells(1).Text = Me.lFirstDate.Text & " Sun"

                sDate = Replace(Replace(row.Cells(2).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(2).Text = sDate & " Mon"

                sDate = Replace(Replace(row.Cells(3).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(3).Text = sDate & " Tue"

                sDate = Replace(Replace(row.Cells(4).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(4).Text = sDate & " Wed"

                sDate = Replace(Replace(row.Cells(5).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(5).Text = sDate & " Thu"

                sDate = Replace(Replace(row.Cells(6).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(6).Text = sDate & " Fri"

                GridView1.HeaderRow.Cells(7).Text = Me.lLastDate.Text & " Sat"

                'Hide the first row (first row set above by  Dim row As GridViewRow = GridView1.Rows(0) )
                row.Visible = False

                Me.lRecordCount.Text = GridView1.Rows.Count - 1

            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con.Dispose()
            End Try

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub

    Protected Sub BtnGetWeekAfter_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim CommandName As String = btn.CommandName
        Dim CommandArgument As String = btn.CommandArgument

        Try
            Dim constr As String = ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString
            Dim con As New SqlConnection(constr)
            'Dim reader As SqlDataReader
            Dim cmd As New SqlCommand()
            Dim DateToShow As Date

            DateToShow = CType(Session("glbDateToShow"), Date)
            DateToShow = DateToShow.AddDays(7)
            Session("glbDateToShow") = CType(DateToShow, String)
            Me.txtDateToShow.Text = Session("glbDateToShow")

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Return7DaysOfRawMaterialUsage"
            cmd.Parameters.Add("@date_end_str", SqlDbType.Date).Value = CType(DateToShow, String)
            cmd.Connection = con

            Try
                con.Open()
                GridView1.EmptyDataText = "No Records Found"
                GridView1.DataSource = cmd.ExecuteReader()
                GridView1.DataBind()

                'get/select the first row of data
                Dim row As GridViewRow = GridView1.Rows(0)
                Dim sDate As String
                sDate = Replace(Replace(row.Cells(1).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)

                Me.lFirstDate.Text = sDate
                sDate = Replace(Replace(row.Cells(7).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                Me.lLastDate.Text = sDate


                'Change the Header Discriptions
                GridView1.HeaderRow.Cells(1).Text = Me.lFirstDate.Text & " Sun"

                sDate = Replace(Replace(row.Cells(2).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(2).Text = sDate & " Mon"

                sDate = Replace(Replace(row.Cells(3).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(3).Text = sDate & " Tue"

                sDate = Replace(Replace(row.Cells(4).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(4).Text = sDate & " Wed"

                sDate = Replace(Replace(row.Cells(5).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(5).Text = sDate & " Thu"

                sDate = Replace(Replace(row.Cells(6).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(6).Text = sDate & " Fri"

                GridView1.HeaderRow.Cells(7).Text = Me.lLastDate.Text & " Sat"

                'Hide the first row (first row set above by  Dim row As GridViewRow = GridView1.Rows(0) )
                row.Visible = False

                Me.lRecordCount.Text = GridView1.Rows.Count - 1

            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
                con.Dispose()
            End Try

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub

    Protected Sub BtnViewWeeklyReport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim CommandName As String = btn.CommandName
        Dim CommandArgument As String = btn.CommandArgument

        Try
            'Session("KeyValue") = CommandArgument
            Response.Redirect("RawMaterialWeekly.aspx")

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub

    Protected Sub BtnViewMonthlyReport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim CommandName As String = btn.CommandName
        Dim CommandArgument As String = btn.CommandArgument

        Try
            'Session("KeyValue") = CommandArgument
            Response.Redirect("RawMaterialMonthly.aspx")

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub

    'Protected Sub GridView1_ZoomIn(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

    '    Dim dateToZoom As String = e.SortExpression
    '    Dim test As String

    '    If dateToZoom = "Ingred" Then
    '        test = "Got Ingred"

    '    ElseIf dateToZoom = "Usage1" Then
    '        test = "Got Usage1"

    '    End If


    'End Sub

End Class