Imports System.Data.SqlClient
Imports ProductionApp17.clsMain
Public Class UserEdit
    Inherits System.Web.UI.Page


    Public Structure UserData
        Public UsersKeyNumber As Integer
        Public FirstName As String
        Public LastName As String
        Public Address As String
        Public City As String
        Public State As String
        Public Zip As String
        Public Phone As String
        Public Email As String
        Public UserID As String
        Public Password As String
        Public UserType As String
        Public Notes As String
        Public LastLogin As String
        Public DateCreated As String
        Public LastUpdate As String
    End Structure

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim LocalUserData As UserData

        Try
            If Session("UserID") > 0 Then
                'Valid User Has Logged In

            Else
                'Force a user login
                Session("UserName") = "No Current User"
                Response.Redirect("Login.aspx")
            End If

            If IsPostBack = False Then

                'If administrator then they came here from the listing page otherwise just show their user
                If Session("UserType") = "A" Then
                    LocalUserData = GetUser(Session("KeyValue"))
                Else
                    LocalUserData = GetUser(Session("UserID"))
                    Me.ddlUserType.Visible = False ' If they are not an admin, they should not be able to change their status to admin.
                End If
                If LocalUserData.UsersKeyNumber <> 0 Then
                    'We have a valid item
                    Me.txtUsersKeyNumber.Text = LocalUserData.UsersKeyNumber.ToString
                    Me.txtFirstName.Text = LocalUserData.FirstName
                    Me.txtLastName.Text = LocalUserData.LastName
                    Me.txtAddress.Text = LocalUserData.Address
                    Me.txtCity.Text = LocalUserData.City
                    Me.txtState.Text = LocalUserData.State
                    Me.txtZip.Text = LocalUserData.Zip
                    Me.txtPhone.Text = LocalUserData.Phone
                    Me.txtEmail.Text = LocalUserData.Email
                    Me.txtUserID.Text = LocalUserData.UserID
                    Me.txtPassword.Text = LocalUserData.Password
                    Me.txtPassword2.Text = LocalUserData.Password
                    Me.ddlUserType.Text = LocalUserData.UserType
                    Me.txtNotes.Text = LocalUserData.Notes

                    Me.txtLastLogin.Text = LocalUserData.LastLogin
                    Me.txtDateCreated.Text = LocalUserData.DateCreated
                    Me.txtLastUpdate.Text = LocalUserData.LastUpdate
                Else
                    Me.txtUsersKeyNumber.Text = "NEW"
                    Me.btnChgPwd.Visible = False
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


    Function GetUser(KeyValue As Integer) As UserData
        Dim sqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("ProductionFormulaConnectionString1").ConnectionString.ToString)
        Dim LocalUserData As New UserData
        Dim clsMain As New clsMain

        Dim strSQL = "SELECT TOP 1 * FROM Users WHERE UsersKeyNumber=" & KeyValue.ToString
        Dim sqlComm As New SqlCommand(strSQL, sqlConn)

        Dim sqlReader As SqlDataReader
        Try

            sqlConn.Open()
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.SingleResult)
            If sqlReader.Read Then
                With LocalUserData
                    .UsersKeyNumber = clsMain.ConvertNullInteger(sqlReader("UsersKeyNumber"))
                    .FirstName = sqlReader("FirstName") & ""
                    .LastName = sqlReader("LastName") & ""
                    .Address = sqlReader("Address") & ""
                    .City = sqlReader("City") & ""
                    .State = sqlReader("State") & ""
                    .Zip = sqlReader("Zip") & ""
                    .Email = sqlReader("Email") & ""
                    .UserID = sqlReader("UserID") & ""
                    .Password = clsMain.DecryptStr(sqlReader("Password") & "")
                    .UserType = sqlReader("UserType") & ""
                    .Notes = sqlReader("Notes") & ""
                    .LastLogin = sqlReader("LastLogin") & ""
                    .DateCreated = sqlReader("DateCreated") & ""
                    .LastUpdate = sqlReader("LastUpdate") & ""

                End With
                Return LocalUserData
            End If

        Catch
            'Error has occured

            LocalUserData.UsersKeyNumber = 0

            Dim mpLabel As Label = DirectCast(Page.Master.FindControl("lblError"), Label)

            If mpLabel IsNot Nothing Then
                mpLabel.Text = Err.Description
            End If
            Return LocalUserData
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
        Dim bValidate As Boolean


        Try
            bValidate = True

            If txtUserID.Text = "" Then
                Call ShowPopUpMsg("User ID Required!")
                ' ScriptManager.GetCurrent(Me.Page).SetFocus(Me.txtUserID)
                bValidate = False
                Exit Sub
            End If

            If txtPassword.Text = "" And txtUsersKeyNumber.Text = "NEW" Then
                Call ShowPopUpMsg("Password Required!")
                'ScriptManager.GetCurrent(Me.Page).SetFocus(Me.txtPassword)
                bValidate = False
                Exit Sub
            End If

            If txtPassword.Text <> txtPassword2.Text And txtUsersKeyNumber.Text = "NEW" Then
                Call ShowPopUpMsg("Passwords must match!")
                'ScriptManager.GetCurrent(Me.Page).SetFocus(Me.txtPassword)
                bValidate = False
                Exit Sub
            End If

            If txtUsersKeyNumber.Text = "NEW" Then
                'This is a new user so add from scratch
                Call AddNewUser()
            Else
                'Existing user so update the one thats there

                ' Open Connection
                thisConnection.Open()

                sSQL = "UPDATE Users Set FirstName = @FirstName, LastName = @LastName, Address = @Address, City = @City, State = @State, Zip = @Zip, Phone =  @Phone, Email = @Email, UserID = @UserID, UserType = @UserType, Notes = @Notes, LastUpdate = @LastUpdate WHERE UsersKeyNumber = @UsersKeyNumber"

                ' Create INSERT statement with named parameters
                nonqueryCommand.CommandText = sSQL

                ' Add Parameters to Command Parameters collection
                nonqueryCommand.Parameters.Add("@UsersKeyNumber", SqlDbType.Int)
                nonqueryCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50)
                nonqueryCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50)
                nonqueryCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 75)
                nonqueryCommand.Parameters.Add("@City", SqlDbType.NVarChar, 50)
                nonqueryCommand.Parameters.Add("@State", SqlDbType.NVarChar, 2)
                nonqueryCommand.Parameters.Add("@Zip", SqlDbType.NVarChar, 10)
                nonqueryCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 50)
                nonqueryCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50)
                nonqueryCommand.Parameters.Add("@UserID", SqlDbType.NVarChar, 50)
                'nonqueryCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50)
                nonqueryCommand.Parameters.Add("@UserType", SqlDbType.NVarChar, 5)
                nonqueryCommand.Parameters.Add("@Notes", SqlDbType.NVarChar, 4000)
                nonqueryCommand.Parameters.Add("@LastUpdate", SqlDbType.DateTime)


                nonqueryCommand.Parameters("@UsersKeyNumber").Value = clsMain.ConvertNullInteger(txtUsersKeyNumber.Text)
                nonqueryCommand.Parameters("@FirstName").Value = txtFirstName.Text & ""
                nonqueryCommand.Parameters("@LastName").Value = txtLastName.Text & ""
                nonqueryCommand.Parameters("@Address").Value = txtAddress.Text & ""
                nonqueryCommand.Parameters("@City").Value = txtCity.Text & ""
                nonqueryCommand.Parameters("@State").Value = txtState.Text & ""
                nonqueryCommand.Parameters("@Zip").Value = txtZip.Text & ""
                nonqueryCommand.Parameters("@Phone").Value = txtPhone.Text & ""
                nonqueryCommand.Parameters("@Email").Value = txtEmail.Text & ""
                nonqueryCommand.Parameters("@UserID").Value = txtUserID.Text & ""
                'nonqueryCommand.Parameters("@Password").Value = EncryptStr(txtPassword.Text & "")
                nonqueryCommand.Parameters("@UserType").Value = ddlUserType.SelectedValue
                nonqueryCommand.Parameters("@Notes").Value = txtNotes.Text & ""
                nonqueryCommand.Parameters("@LastUpdate").Value = Now
                nonqueryCommand.ExecuteNonQuery()
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

            If bValidate Then Response.Redirect("Users.aspx")

        End Try
    End Sub

    Private Sub AddNewUser()
        Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString)
        Dim clsMain As New clsMain
        'Create Command object
        Dim nonqueryCommand As SqlCommand = thisConnection.CreateCommand()
        Dim sSQL As String
        Dim regDate As DateTime = DateTime.Now


        Try
            ' Open Connection
            thisConnection.Open()


            sSQL = "INSERT INTO Users (UsersKeyNumber, DeletedRec, UserLockedOut, FailedLoginAttempts, FirstName, LastName, Address, City, State, Zip, Phone, Email, UserID, Password, UserType, Notes, DateCreated, LastUpdate) "
            sSQL = sSQL & "VALUES (@UsersKeyNumber, @DeletedRec, @UserLockedOut, @FailedLoginAttempts, @FirstName, @LastName, @Address, @City, @State, @Zip, @Phone, @Email, @UserID, @Password, @UserType, @Notes, @DateCreated, @LastUpdate)"

            ' Create INSERT statement with named parameters
            nonqueryCommand.CommandText = sSQL


            ' Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@UsersKeyNumber", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@DeletedRec", SqlDbType.NVarChar, 1)
            nonqueryCommand.Parameters.Add("@UserLockedOut", SqlDbType.NVarChar, 1)
            nonqueryCommand.Parameters.Add("@FailedLoginAttempts", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 75)
            nonqueryCommand.Parameters.Add("@City", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@State", SqlDbType.NVarChar, 2)
            nonqueryCommand.Parameters.Add("@Zip", SqlDbType.NVarChar, 10)
            nonqueryCommand.Parameters.Add("@Phone", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@UserID", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@UserType", SqlDbType.NVarChar, 5)
            nonqueryCommand.Parameters.Add("@Notes", SqlDbType.NVarChar, 4000)
            nonqueryCommand.Parameters.Add("@DateCreated", SqlDbType.DateTime)
            nonqueryCommand.Parameters.Add("@LastUpdate", SqlDbType.DateTime)


            nonqueryCommand.Parameters("@UsersKeyNumber").Value = GetNextRecordKey()
            nonqueryCommand.Parameters("@DeletedRec").Value = "N"
            nonqueryCommand.Parameters("@UserLockedOut").Value = "N"
            nonqueryCommand.Parameters("@FailedLoginAttempts").Value = 0
            nonqueryCommand.Parameters("@FirstName").Value = txtFirstName.Text & ""
            nonqueryCommand.Parameters("@LastName").Value = txtLastName.Text & ""
            nonqueryCommand.Parameters("@Address").Value = txtAddress.Text & ""
            nonqueryCommand.Parameters("@City").Value = txtCity.Text & ""
            nonqueryCommand.Parameters("@State").Value = txtState.Text & ""
            nonqueryCommand.Parameters("@Zip").Value = txtZip.Text & ""
            nonqueryCommand.Parameters("@Phone").Value = txtPhone.Text & ""
            nonqueryCommand.Parameters("@Email").Value = txtEmail.Text & ""
            nonqueryCommand.Parameters("@UserID").Value = txtUserID.Text & ""
            nonqueryCommand.Parameters("@Password").Value = clsMain.EncryptStr(txtPassword.Text & "")
            nonqueryCommand.Parameters("@UserType").Value = ddlUserType.SelectedValue
            nonqueryCommand.Parameters("@Notes").Value = txtNotes.Text & ""
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



        End Try
    End Sub

    Function GetNextRecordKey() As Integer
        Dim sqlConn As New SqlConnection(ConfigurationManager.ConnectionStrings.Item("ProductionFormulaConnectionString1").ConnectionString.ToString)
        Dim NextKeyNumber As Integer
        Dim clsMain As New clsMain

        Dim strSQL = "SELECT TOP 1 UsersKeyNumber FROM Users ORDER BY UsersKeyNumber DESC"
        Dim sqlComm As New SqlCommand(strSQL, sqlConn)

        Dim sqlReader As SqlDataReader
        Try
            GetNextRecordKey = 0
            sqlConn.Open()
            sqlReader = sqlComm.ExecuteReader(CommandBehavior.SingleResult)
            If sqlReader.Read Then
                NextKeyNumber = clsMain.ConvertNullInteger(sqlReader("UsersKeyNumber"))
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


    Private Sub ShowPopUpMsg(msg As String)
        Dim sb As New StringBuilder()
        sb.Append("alert('")
        sb.Append(msg.Replace(vbLf, "\n").Replace(vbCr, "").Replace("'", "\'"))
        sb.Append("');")
        ScriptManager.RegisterStartupScript(Me.Page, Me.[GetType](), "showalert", sb.ToString(), True)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Response.Redirect("Users.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChgPwd_Click(sender As Object, e As EventArgs) Handles btnChgPwd.Click
        Dim thisConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString)
        Dim clsMain As New clsMain

        'Create Command object
        Dim nonqueryCommand As SqlCommand = thisConnection.CreateCommand()
        Dim sSQL As String
        Dim regDate As DateTime = DateTime.Now
        Dim bValidate As Boolean


        Try
            bValidate = True

            If txtPassword.Text = "" Then
                Call ShowPopUpMsg("Password Required!")
                'ScriptManager.GetCurrent(Me.Page).SetFocus(Me.txtPassword)
                bValidate = False
                Exit Sub
            End If

            If txtPassword.Text <> txtPassword2.Text Then
                Call ShowPopUpMsg("Passwords must match!")
                'ScriptManager.GetCurrent(Me.Page).SetFocus(Me.txtPassword)
                bValidate = False
                Exit Sub
            End If

            ' Open Connection
            thisConnection.Open()

            sSQL = "UPDATE Users Set Password = @Password, LastUpdate = @LastUpdate WHERE UsersKeyNumber = @UsersKeyNumber"

            ' Create INSERT statement with named parameters
            nonqueryCommand.CommandText = sSQL

            ' Add Parameters to Command Parameters collection
            nonqueryCommand.Parameters.Add("@UsersKeyNumber", SqlDbType.Int)
            nonqueryCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50)
            nonqueryCommand.Parameters.Add("@LastUpdate", SqlDbType.DateTime)

            nonqueryCommand.Parameters("@UsersKeyNumber").Value = clsMain.ConvertNullInteger(txtUsersKeyNumber.Text)
            nonqueryCommand.Parameters("@Password").Value = clsMain.EncryptStr(txtPassword.Text & "")
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

            If bValidate Then Response.Redirect("Users.aspx")

        End Try
    End Sub
End Class