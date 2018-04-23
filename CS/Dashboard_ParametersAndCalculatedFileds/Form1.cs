using DevExpress.XtraEditors;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;

namespace Dashboard_ParametersAndCalculatedFileds {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();

            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            DashboardSqlDataSource dataSource = (DashboardSqlDataSource)dashboard.DataSources[0];
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items[0];

            // Creates a new dashboard parameter.
            StaticListLookUpSettings settings = new StaticListLookUpSettings();
            settings.Values = new string[] { "0.01", "0.05", "0.1" };
            DashboardParameter discountValue = new DashboardParameter("discountValue", 
                typeof(double), 0.05, "Select discount:", true, settings);
            dashboard.Parameters.Add(discountValue);

            // Creates a new calculated field and passes the created dashboard parameter 
            // to a calculated field expression.
            CalculatedField isGreater = new CalculatedField();
            isGreater.DataMember = "SalesPerson";
            isGreater.Name = "IsGreater";
            isGreater.Expression = "ToStr(Iif(Avg([Discount]) >= [Parameters.discountValue], 'TRUE', 'FALSE'))";
            dataSource.CalculatedFields.Add(isGreater);

            grid.Columns.Add(new GridMeasureColumn(new Measure("IsGreater")));
            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
