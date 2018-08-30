Imports System.Data
Imports System.Web
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Imports ProductionApp17.clsMain

Public Class Login1
    Inherits System.Web.UI.Page

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

                    If GetUser(userId) Then
                        'not sure if I need to do anything here
                    End If
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet)
                    Exit Select
            End Select
        End Using
    End Sub

    Function GetUser(UserID As Integer) As Boolean
        Dim sqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("ProductionFormulaConnectionString1").ConnectionString.ToString)


        Dim strSQL = "SELECT TOP 1 * FROM Users WHERE UsersKeyNumber =" & UserID.ToString
        Dim sqlComm As New SqlCommand(strSQL, sqlConn)

        Dim sqlReader As SqlDataReader
        Try

            sqlConn.Open()
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.SingleResult)
            If sqlReader.Read Then
                Session("UserType") = sqlReader("UserType") & ""
                Return True
            End If

        Catch
            'Error has occured

            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If
            Return False
        Finally
            sqlComm.Dispose()
            sqlConn.Close()
        End Try
    End Function


End Class