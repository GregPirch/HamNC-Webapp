Public Class LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Blank out the user and send them to login page
        Session("UserID") = 0
        Session("UserName") = "No Current User"

        Response.Redirect("Login.aspx")

    End Sub

End Class