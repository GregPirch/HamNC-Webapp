Imports System.Data.SqlClient

Public Class RawMaterialMonthly
    Inherits System.Web.UI.Page
    Public LocalConnectionString As String
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
                'Dim reader As SqlDataReader
                Dim cmd As New SqlCommand()

                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "sp_Return3MonthsOfRawMaterialUsage"
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
                    sDate = Replace(Replace(row.Cells(3).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                    Me.lLastDate.Text = sDate


                    'Change the Header Discriptions
                    GridView1.HeaderRow.Cells(1).Text = Me.lFirstDate.Text

                    sDate = Replace(Replace(row.Cells(2).Text, ".0", ""), ",", "")
                    sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                    GridView1.HeaderRow.Cells(2).Text = sDate


                    GridView1.HeaderRow.Cells(3).Text = Me.lLastDate.Text

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



    Protected Sub BtnGetMonthBefore_Click(ByVal sender As Object, ByVal e As EventArgs)
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
            DateToShow = DateToShow.AddMonths(-1)
            Session("glbDateToShow") = CType(DateToShow, String)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Return3MonthsOfRawMaterialUsage"
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
                sDate = Replace(Replace(row.Cells(3).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                Me.lLastDate.Text = sDate


                'Change the Header Discriptions
                GridView1.HeaderRow.Cells(1).Text = Me.lFirstDate.Text

                sDate = Replace(Replace(row.Cells(2).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(2).Text = sDate


                GridView1.HeaderRow.Cells(3).Text = Me.lLastDate.Text

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

    Protected Sub BtnGetMonthAfter_Click(ByVal sender As Object, ByVal e As EventArgs)
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
            DateToShow = DateToShow.AddMonths(1)
            Session("glbDateToShow") = CType(DateToShow, String)

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_Return3MonthsOfRawMaterialUsage"
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
                sDate = Replace(Replace(row.Cells(3).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                Me.lLastDate.Text = sDate


                'Change the Header Discriptions
                GridView1.HeaderRow.Cells(1).Text = Me.lFirstDate.Text

                sDate = Replace(Replace(row.Cells(2).Text, ".0", ""), ",", "")
                sDate = Left(sDate, 4) + "-" + Mid(sDate, 5, 2) + "-" + Right(sDate, 2)
                GridView1.HeaderRow.Cells(2).Text = sDate


                GridView1.HeaderRow.Cells(3).Text = Me.lLastDate.Text

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

End Class