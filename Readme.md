This example demonstrates how to export [ASP.NET MVC Pivot Grid](https://docs.devexpress.com/AspNet/10689/asp.net-mvc-extensions/pivot-grid) to PDF and XLSX formats, specify various export options and customize the exported cell's content and appearance.

The following image shows the [MVCXPivotGrid](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.MVCxPivotGrid) when the example is run.

![](~/images/mvcxpivotgrid-export-original.png)

Click the _Export to XLSX_ or _Export to PDF_ button to perform export.

![](~/images/mvcxpivotgrid-export-to-pdf-custom.png)


![](~/images/mvcxpivotgrid-export-to-xlsx-custom.png)

Export to XLSX format is performed using the [PivotGridExtension.ExportToXlsx](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.PivotGridExtension.ExportToXlsx(DevExpress.Web.Mvc.PivotGridSettings-System.Object-DevExpress.XtraPrinting.XlsxExportOptions)) method. To specify export options, this example creates the [PivotXlsxExportOptions](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.PivotXlsxExportOptions) class instance, modifies it as required and passes to the method as a parameter. The **PivotXlsxExportOptions** type is properly accepted because it inherits the [XlsxExportOptions](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.XlsxExportOptions) class.

To customize the cell content and appearance individually for each cell, this example handles the [PivotXlsxExportOptions.CustomizeCell](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPivotGrid.PivotXlsxExportOptions.CustomizeCell) event.


Export to PDF is performed using the [PivotGridExtension.ExportToPdf](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.PivotGridExtension.ExportToPdf(DevExpress.Web.Mvc.PivotGridSettings-System.Object)) method with the [PivotGridSettings](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.PivotGridSettings) instance passed as the method parameter. The [PivotGridSettings.SettingsExport.OptionsPrint](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.MVCxPivotGridExportSettings.OptionsPrint) property is used to specify page settings. 

To customize the cell content and appearance individually for each cell, this example handles the [PivotGridSettings.SettingsExport.CustomExportCell](https://docs.devexpress.com/AspNet/DevExpress.Web.Mvc.MVCxPivotGridExportSettings.CustomExportCell) event.
