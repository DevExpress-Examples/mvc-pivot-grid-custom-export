using DevExpress.Web.Mvc;
using System.Web.Mvc;

namespace MVCxPivotGrid_CustomExport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "MVCxPivotGrid Custom Export Example";

            return View(Models.NwindModel.GetData());
        }

        [ValidateInput(false)]
        public ActionResult PivotGridPartial()
        {
            return PartialView("PivotGridPartial", Models.NwindModel.GetData());
        }

        public ActionResult ExportToXLSX_DataAware()
        {
            return PivotGridExtension.ExportToXlsx(PivotGridHelper.Settings, Models.NwindModel.GetData(), PivotGridHelper.XlsxOptions);
        }

        public ActionResult ExportToXLSX_WYSIWYG()
        {
            DevExpress.XtraPrinting.XlsxExportOptions options = new DevExpress.XtraPrinting.XlsxExportOptions();
            return PivotGridExtension.ExportToXlsx(PivotGridHelper.Settings, Models.NwindModel.GetData(), options);
        }

        public ActionResult ExportToPDF()
        {
            return PivotGridExtension.ExportToPdf(PivotGridHelper.Settings, Models.NwindModel.GetData());
        }
    }
}