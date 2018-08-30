Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DateDisplay.Text = DateTime.Now.ToString("dddd, MMMM dd")
    End Sub

End Class