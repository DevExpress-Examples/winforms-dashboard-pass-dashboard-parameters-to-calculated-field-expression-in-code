Imports DevExpress.XtraEditors
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters

Namespace Dashboard_ParametersAndCalculatedFileds
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()

            Dim dashboard As New Dashboard()
            dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
            Dim dataSource As DashboardSqlDataSource =
                CType(dashboard.DataSources(0), DashboardSqlDataSource)
            Dim grid As GridDashboardItem = CType(dashboard.Items(0), GridDashboardItem)

            ' Creates a new dashboard parameter.
            Dim settings As New StaticListLookUpSettings()
            settings.Values = New String() { "0.01", "0.05", "0.1" }
            Dim discountValue As New DashboardParameter("discountValue", GetType(Double), 0.05, _
                                                        "Select discount:", True, settings)
            dashboard.Parameters.Add(discountValue)

            ' Creates a new calculated field and passes the created dashboard parameter 
            ' to a calculated field expression.
            Dim isGreater As _
                New CalculatedField("Iif(Avg([Discount]) >= [Parameters.discountValue], 'TRUE', 'FALSE')")
            isGreater.DataMember = "SalesPerson"
            isGreater.DataType = CalculatedFieldType.String
            isGreater.Name = "IsGreater"
            dataSource.CalculatedFields.Add(isGreater)

            grid.Columns.Add(New GridMeasureColumn(New Measure("IsGreater")))
            dashboardViewer1.Dashboard = dashboard
        End Sub
    End Class
End Namespace
