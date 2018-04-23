Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraEditors
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters

Namespace Dashboard_ParametersAndCalculatedFileds
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()

			Dim dashboard As New Dashboard()

			' Creates a new dashboard parameter.
			Dim settings As New StaticListLookUpSettings()
			settings.Values = New String() { "0.1", "0.2", "0.3", "0.4" }
            Dim parameter1 As _
                New DashboardParameter("Parameter1", GetType(Decimal), 0.1D, "", True, settings)
			dashboard.Parameters.Add(parameter1)

			' Creates a connection to the Northwind database and adds data 
			' from the 'Products' table to the data source.
			Dim nwParams As New Access97ConnectionParameters("..\..\Data\nwind.mdb", "", "")
			Dim sqlProvider As New SqlDataProvider("NW", nwParams, "select * from Products")
			Dim dataSource As New DataSource("Data Source 1", sqlProvider)
			dashboard.DataSources.Add(dataSource)

			' Creates a new calculated field and passes the parameter to a calculated field expression.
            Dim priceWithDiscount As New CalculatedField("[UnitPrice] * (1 - [Parameters.Parameter1])", _
                                                         "Price with discount", _
                                                         CalculatedFieldType.Decimal)
			dataSource.CalculatedFields.Add(priceWithDiscount)

			' Creates a Grid dashboard item with two columns containing list of products 
			' and corresponing prices.
			Dim grid As New GridDashboardItem()
			grid.DataSource = dataSource
			grid.Columns.Add(New GridDimensionColumn(New Dimension("ProductName")))
			grid.Columns.Add(New GridMeasureColumn(New Measure("Price with discount")))

			dashboard.Items.Add(grid)
			dashboardViewer1.Dashboard = dashboard
		End Sub
	End Class
End Namespace
