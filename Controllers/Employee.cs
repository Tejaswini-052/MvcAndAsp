using Microsoft.AspNetCore.Mvc;

namespace MvcDemoPractice.Controllers
{
    public class Employee : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
