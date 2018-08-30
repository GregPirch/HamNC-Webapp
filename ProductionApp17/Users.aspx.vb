Public Class Users
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

            If Session("UserType") <> "A" Then
                Response.Redirect("UserEdit.aspx")
            End If

            If IsPostBack = False Then

                'Populate Data Grid View
                Dim SqlDataSource1 As New SqlDataSource()
                SqlDataSource1.ID = "SqlDataSource1"
                Me.Page.Controls.Add(SqlDataSource1)
                SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
                SqlDataSource1.SelectCommand = "SELECT * from Users ORDER BY LastName"
                GridView1.DataSource = SqlDataSource1
                GridView1.DataBind()


            End If

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
            Response.Redirect("UserEdit.aspx", False)

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub

    Protected Sub btnAddNewUser_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim CommandName As String = btn.CommandName
        Dim CommandArgument As String = btn.CommandArgument

        Try
            Session("KeyValue") = 0
            Response.Redirect("UserEdit.aspx", False)

        Catch
            'Error has occured
            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If

        End Try
    End Sub

End Class