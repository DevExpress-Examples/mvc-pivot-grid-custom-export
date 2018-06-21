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

        public ActionResult ExportToXLS()
        {
            return PivotGridExtension.ExportToXls(PivotGridHelper.Settings, Models.NwindModel.GetData());
        }

        public ActionResult ExportToPDF()
        {
            return PivotGridExtension.ExportToPdf(PivotGridHelper.Settings, Models.NwindModel.GetData());
        }
    }
}