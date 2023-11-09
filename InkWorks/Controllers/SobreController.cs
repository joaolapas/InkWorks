using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
