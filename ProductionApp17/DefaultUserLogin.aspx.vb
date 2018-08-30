Imports System.Data
Imports System.Web
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Imports ProductionApp17.clsMain

Public Class DefaultUserLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ValidateUser(sender As Object, e As EventArgs)
        Dim clsMain As New clsMain
        Dim userId As Integer = 0
        Dim constr As String = ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("spValidate_User_NW")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Username", Login1.UserName)
                cmd.Parameters.AddWithValue("@Password", clsMain.EncryptStr(Login1.Password))
                cmd.Connection = con
                con.Open()
                userId = Convert.ToInt32(cmd.ExecuteScalar())
                con.Close()
            End Using
            Select Case userId
                Case -1
                    Login1.FailureText = "Username and/or password is incorrect."
                    Exit Select
                Case -2
                    Login1.FailureText = "Account has not been activated."
                    Exit Select
                Case Else
                    Session("UserID") = userId
                    'FormsAuthentication.SetAuthCookie(Login1.UserName, True)
                    'LoginStatus.Authenticated
                    'Response.Redirect("Index.aspx")
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet, "Index.aspx")
                    Exit Select
            End Select
        End Using
    End Sub



    Protected Sub ValidateUser(sender As Object, e As AuthenticateEventArgs) Handles Login1.Authenticate
        Dim clsMain As New clsMain
        Dim userId As Integer = 0
        Dim constr As String = ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("spValidate_User_NW")
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Username", Login1.UserName)
                cmd.Parameters.AddWithValue("@Password", clsMain.EncryptStr(Login1.Password))
                cmd.Connection = con
                con.Open()
                userId = Convert.ToInt32(cmd.ExecuteScalar())
                con.Close()
            End Using
            Select Case userId
                Case -1
                    Login1.FailureText = "Username and/or password is incorrect."
                    Exit Select
                Case -2
                    Login1.FailureText = "Account has not been activated."
                    Exit Select
                Case Else
                    Session("UserID") = userId
                    Session("UserName") = Login1.UserName
                    'FormsAuthentication.SetAuthCookie(Login1.UserName, True)
                    'LoginStatus.Authenticated
                    'Response.Redirect("Index.aspx")
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
                    Exit Select
            End Select
        End Using
    End Sub
End Class