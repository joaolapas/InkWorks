using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    public class ImagensController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
