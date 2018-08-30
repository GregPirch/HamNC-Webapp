Public Class MudBatch
    Inherits System.Web.UI.Page
    Public LocalConnectionString As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Session("UserID") >= 0 Then
                'Valid User Has Logged In

            Else
                'Force a user login
                Session("UserName") = "No Current User"
                Response.Redirect("Login.aspx")
            End If

            If IsPostBack = False Then

                'Populate Data Grid View
                Dim SqlDataSource1 As New SqlDataSource()
                SqlDataSource1.ID = "SqlDataSource1"
                Me.Page.Controls.Add(SqlDataSource1)
                SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString
                SqlDataSource1.SelectCommand = "SELECT top 10 * from vu_ProdApp_MudBatchGrid ORDER BY Batch_DateTimeEnd DESC"
                GridView1.DataSource = SqlDataSource1
                GridView1.DataBind()


                'Default Values
                Me.tbBatchesPrior.Text = "10"

                Me.lRecordCount.Text = GridView1.Rows.Count
            End If

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = "ERROR: " & Err.Description
            End If

        End Try

    End Sub



    Private Sub btnSearchProduct_Click(sender As Object, e As EventArgs) Handles btnSearchProduct.Click
        'Populate Data Grid View
        Dim sSQLString As String
        Dim SqlDataSource1 As New SqlDataSource()
        Try
            SqlDataSource1.ID = "SqlDataSource1"
            Me.Page.Controls.Add(SqlDataSource1)
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString

            sSQLString = "SELECT top "
            If IsNumeric(Me.tbBatchesPrior.Text) Then
                sSQLString = sSQLString & Me.tbBatchesPrior.Text
            Else
                sSQLString = sSQLString & "10"
            End If
            sSQLString = sSQLString & " * from vu_ProdApp_MudBatchGrid "

            sSQLString = sSQLString & " WHERE Recipe_Name LIKE '%" & Me.tbRecipe.Text & "%'"

            sSQLString = sSQLString & " ORDER BY Batch_DateTimeEnd DESC"

            SqlDataSource1.SelectCommand = sSQLString
            GridView1.DataSource = SqlDataSource1
            GridView1.DataBind()

            Me.lRecordCount.Text = GridView1.Rows.Count
        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = "ERROR: " & Err.Description
            End If

        End Try
    End Sub



    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs)
        'Dim dt As String = Request.Form(txtRunDate.UniqueID)
    End Sub

    Private Sub btnSearchDate_Click(sender As Object, e As EventArgs) Handles btnSearchDate.Click
        'Populate Data Grid View
        Dim sSQLString As String
        Dim SqlDataSource1 As New SqlDataSource()

        Try
            SqlDataSource1.ID = "SqlDataSource1"
            Me.Page.Controls.Add(SqlDataSource1)
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("HamiltonNCProduction1").ConnectionString

            sSQLString = "SELECT"
            'If IsNumeric(Me.tbBatchesPrior.Text) Then
            ' sSQLString = sSQLString & Me.tbBatchesPrior.Text
            ' Else
            ' sSQLString = sSQLString & "10"
            ' End If
            sSQLString = sSQLString & " * from vu_ProdApp_MudBatchGrid "

            sSQLString = sSQLString & " WHERE Batch_DateTimeEnd" & " >= '" & Me.txtStartDate.Text & "'"
            sSQLString = sSQLString & " AND Batch_DateTimeEnd" & " <= '" & Me.txtEndDate.Text & "'"

            sSQLString = sSQLString & " ORDER BY Batch_DateTimeEnd DESC"

            SqlDataSource1.SelectCommand = sSQLString
            GridView1.DataSource = SqlDataSource1
            GridView1.DataBind()

            Me.lRecordCount.Text = GridView1.Rows.Count
        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = "ERROR: " & Err.Description
            End If

        End Try
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim CommandName As String = btn.CommandName
        Dim CommandArgument As String = btn.CommandArgument

        Try
            Session("KeyValue") = CommandArgument
            Response.Redirect("MudBatchEdit.aspx")

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim CommandName As String = btn.CommandName
        Dim CommandArgument As String = btn.CommandArgument

        Try
            Session("KeyValue") = CommandArgument
            Response.Redirect("MudBatchDetailView.aspx")

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub

End Class