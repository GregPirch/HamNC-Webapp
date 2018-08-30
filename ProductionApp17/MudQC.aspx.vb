Public Class MudQC
    Inherits System.Web.UI.Page
    Public LocalConnectionString As String
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

                'Populate Data Grid View
                Dim SqlDataSource1 As New SqlDataSource()
                SqlDataSource1.ID = "SqlDataSource1"
                Me.Page.Controls.Add(SqlDataSource1)
                SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
                SqlDataSource1.SelectCommand = "SELECT top 10 * from vu_nw_MudProductionLog WHERE DeletedRec = 'N' ORDER BY DateCreated DESC"
                GridView1.DataSource = SqlDataSource1
                GridView1.DataBind()

                'Populate Drop Down
                ddlProduct.Items.Clear()
                Dim SqlDataSource2 As New SqlDataSource()
                SqlDataSource2.ID = "SqlDataSource1"
                Me.Page.Controls.Add(SqlDataSource2)
                SqlDataSource2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
                SqlDataSource2.SelectCommand = "SELECT KeyNumber, ProductName from Products ORDER BY ProductName"
                ddlProduct.DataSource = SqlDataSource2
                ddlProduct.DataTextField = "ProductName"
                ddlProduct.DataValueField = "KeyNumber"
                ddlProduct.DataBind()

                'Default Values
                Me.tbBatchesPrior.Text = "10"
                Me.rbDateSearch.SelectedValue = "RunDate"
            End If

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
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
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString

            sSQLString = "SELECT top "
            If IsNumeric(Me.tbBatchesPrior.Text) Then
                sSQLString = sSQLString & Me.tbBatchesPrior.Text
            Else
                sSQLString = sSQLString & "10"
            End If
            sSQLString = sSQLString & " * from vu_nw_MudProductionLog "

            sSQLString = sSQLString & " WHERE ProductKey = " & Me.ddlProduct.SelectedValue

            If Not (Me.cbShowArchive.Checked) Then
                sSQLString = sSQLString & " AND DeletedRec = 'N' "
            End If

            sSQLString = sSQLString & "ORDER BY DateCreated DESC"

            SqlDataSource1.SelectCommand = sSQLString
            GridView1.DataSource = SqlDataSource1
            GridView1.DataBind()

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
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
            SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString

            sSQLString = "SELECT top "
            If IsNumeric(Me.tbBatchesPrior.Text) Then
                sSQLString = sSQLString & Me.tbBatchesPrior.Text
            Else
                sSQLString = sSQLString & "10"
            End If
            sSQLString = sSQLString & " * from vu_nw_MudProductionLog "

            sSQLString = sSQLString & " WHERE " & rbDateSearch.Text & " >= '" & Me.txtStartDate.Text & "'"
            sSQLString = sSQLString & " AND " & rbDateSearch.Text & " <= '" & Me.txtEndDate.Text & "'"

            If Not (Me.cbShowArchive.Checked) Then
                sSQLString = sSQLString & " And DeletedRec = 'N'"
            End If

            sSQLString = sSQLString & " ORDER BY DateCreated DESC"

            SqlDataSource1.SelectCommand = sSQLString
            GridView1.DataSource = SqlDataSource1
            GridView1.DataBind()

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim CommandName As String = btn.CommandName
        Dim CommandArgument As String = btn.CommandArgument

        Try
            Session("KeyValue") = CommandArgument
            Response.Redirect("MudQCEdit.aspx")

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub
End Class