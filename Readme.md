<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581193/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5135)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Dashboard_ParametersAndCalculatedFileds/Form1.cs) (VB: [Form1.vb](./VB/Dashboard_ParametersAndCalculatedFileds/Form1.vb))
<!-- default file list end -->
# How to pass a dashboard parameter to a calculated field's expression in code


<p>The following example demonstrates how to <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument16169">create a new dashboard parameter</a> and <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument16170">pass</a> it to a calculated field's expression.</p>
<br />
<p>In this example, the dashboard connects to the Northwind database and selects data from the 'SalesPerson' table. A new calculated field evaluated at <a href="http://documentation.devexpress.com/#Dashboard/CustomDocument114034">a summary level</a> returns 'TRUE' or 'FALSE' depending on whether on not the average discount exceeds the selected parameter value.</p>

<br/>


