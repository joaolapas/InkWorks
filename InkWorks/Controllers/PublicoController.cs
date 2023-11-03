using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    public class PublicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
