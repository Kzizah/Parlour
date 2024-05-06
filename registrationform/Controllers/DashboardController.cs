using Microsoft.AspNetCore.Mvc;
using registrationform.Models.Filters;

namespace registrationform.Controllers
{
    public class DashboardController : Controller
    {
        [ServiceFilter(typeof(AuditFilterAttribute))]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
