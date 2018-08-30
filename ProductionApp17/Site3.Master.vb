Public Class Site3
    Inherits System.Web.UI.MasterPage


    Public WriteOnly Property Heading() As String

        Set
            lblError.Text = Value
        End Set

    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class