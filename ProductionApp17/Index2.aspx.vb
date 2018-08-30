Imports System.Web.Security

Public Class Index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not Me.Page.User.Identity.IsAuthenticated Then
        'FormsAuthentication.RedirectToLoginPage()
        'End If
        If Session("UserID") > 0 Then
            'Valid User Has Logged In

        Else
            'Force a user login
            Response.Redirect("DefaultUserLogin.aspx")
        End If
    End Sub

End Class