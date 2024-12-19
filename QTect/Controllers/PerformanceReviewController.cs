using Microsoft.AspNetCore.Mvc;

namespace QTect.Controllers
{
    public class PerformanceReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
