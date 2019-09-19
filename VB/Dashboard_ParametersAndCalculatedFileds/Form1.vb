Imports DevExpress.DashboardCommon
Imports DevExpress.XtraEditors

Namespace Dashboard_ParametersAndCalculatedFields
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()

			Dim dashboard As New Dashboard()
			dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
			Dim dataSource As DashboardSqlDataSource = DirectCast(dashboard.DataSources(0), DashboardSqlDataSource)
			Dim grid As GridDashboardItem = CType(dashboard.Items(0), GridDashboardItem)

			' Create a new dashboard parameter.
			Dim settings As New StaticListLookUpSettings()
			settings.Values = New String() { "0.01", "0.05", "0.1" }
			Dim discountValue As New DashboardParameter("discountValue", GetType(Double), 0.05, "Select discount:", True, settings)
			dashboard.Parameters.Add(discountValue)

			' Create a new calculated field and pass the created dashboard parameter 
			' to a calculated field expression.
			Dim isGreater As New CalculatedField()
			isGreater.DataMember = "SalesPerson"
			isGreater.Name = "IsGreater"
			isGreater.Expression = "ToStr(Iif(Avg([Discount]) >= [Parameters.discountValue], 'TRUE', 'FALSE'))"
			dataSource.CalculatedFields.Add(isGreater)

			grid.Columns.Add(New GridMeasureColumn(New Measure("IsGreater")))
			dashboardViewer1.Dashboard = dashboard
		End Sub
	End Class
End Namespace
