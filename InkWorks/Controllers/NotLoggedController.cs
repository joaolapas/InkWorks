using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    public class NotLoggedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
