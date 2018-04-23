using DevExpress.XtraEditors;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;

namespace Dashboard_ParametersAndCalculatedFileds {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();

            Dashboard dashboard = new Dashboard();

            // Creates a new dashboard parameter.
            StaticListLookUpSettings settings = new StaticListLookUpSettings();
            settings.Values = new string[] { "0.1", "0.2", "0.3", "0.4" };
            DashboardParameter parameter1 = 
                new DashboardParameter("Parameter1", typeof(decimal), 0.1m, "", true, settings);
            dashboard.Parameters.Add(parameter1);

            // Creates a connection to the Northwind database and selects data 
            // from the 'Products' table.
            Access97ConnectionParameters nwParams = 
                new Access97ConnectionParameters(@"..\..\Data\nwind.mdb", "", "");
            SqlDataProvider sqlProvider = new SqlDataProvider("NW", nwParams, "select * from Products");
            DataSource dataSource = new DataSource("Data Source 1", sqlProvider);
            dashboard.DataSources.Add(dataSource);

            // Creates a new calculated field and passes the created dashboard parameter 
            // to a calculated field expression.
            CalculatedField priceWithDiscount = 
                new CalculatedField("[UnitPrice] * (1 - [Parameters.Parameter1])", 
                                    "Price with discount", CalculatedFieldType.Decimal);
            dataSource.CalculatedFields.Add(priceWithDiscount);

            // Creates a Grid dashboard item with two columns containing a list of products 
            // and corresponding prices.
            GridDashboardItem grid = new GridDashboardItem();
            grid.DataSource = dataSource;
            grid.Columns.Add(new GridDimensionColumn(new Dimension("ProductName")));
            grid.Columns.Add(new GridMeasureColumn(new Measure("Price with discount")));

            dashboard.Items.Add(grid);
            dashboardViewer1.Dashboard = dashboard;
        }
    }
}
