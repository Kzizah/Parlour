using Microsoft.AspNetCore.Mvc;

namespace registrationform.Controllers
{
    public class CustomerReportController : Controller
    {
        public IActionResult CustomerReport()
        {
            return View();
        }
    }
}
