Public Class MudProdLog
    Inherits System.Web.UI.Page
    Public LocalConnectionString As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim SqlDataSource1 As New SqlDataSource()
        SqlDataSource1.ID = "SqlDataSource1"
        Me.Page.Controls.Add(SqlDataSource1)
        SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("ProductionFormulaConnectionString1").ConnectionString
        SqlDataSource1.SelectCommand = "SELECT top 10 * from vu_nw_MudProductionLog ORDER BY DateCreated DESC"
        GridView1.DataSource = SqlDataSource1
        GridView1.DataBind()

    End Sub

End Class