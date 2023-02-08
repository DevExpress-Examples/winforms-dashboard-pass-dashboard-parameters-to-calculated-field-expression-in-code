Imports DevExpress.XtraEditors
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters

Namespace Dashboard_ParametersAndCalculatedFileds

    Public Partial Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            Dim dashboard As Dashboard = New Dashboard()
            ' Creates a new dashboard parameter.
            Dim settings As StaticListLookUpSettings = New StaticListLookUpSettings()
            settings.Values = New String() {"0.1", "0.2", "0.3", "0.4"}
            Dim parameter1 As DashboardParameter = New DashboardParameter("Parameter1", GetType(Decimal), 0.1D, "", True, settings)
            dashboard.Parameters.Add(parameter1)
            ' Creates a connection to the Northwind database and selects data 
            ' from the 'Products' table.
            Dim nwParams As Access97ConnectionParameters = New Access97ConnectionParameters("..\..\Data\nwind.mdb", "", "")
            Dim sqlProvider As SqlDataProvider = New SqlDataProvider("NW", nwParams, "select * from Products")
            Dim dataSource As DataSource = New DataSource("Data Source 1", sqlProvider)
            dashboard.DataSources.Add(dataSource)
            ' Creates a new calculated field and passes the created dashboard parameter 
            ' to a calculated field expression.
            Dim priceWithDiscount As CalculatedField = New CalculatedField("[UnitPrice] * (1 - [Parameters.Parameter1])", "Price with discount", CalculatedFieldType.Decimal)
            dataSource.CalculatedFields.Add(priceWithDiscount)
            ' Creates a Grid dashboard item with two columns containing a list of products 
            ' and corresponding prices.
            Dim grid As GridDashboardItem = New GridDashboardItem()
            grid.DataSource = dataSource
            grid.Columns.Add(New GridDimensionColumn(New Dimension("ProductName")))
            grid.Columns.Add(New GridMeasureColumn(New Measure("Price with discount")))
            dashboard.Items.Add(grid)
            dashboardViewer1.Dashboard = dashboard
        End Sub
    End Class
End Namespace
