using Microsoft.AspNetCore.Mvc;

namespace HR.PL.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dash()
        {
            return View();
        }
    }
}
