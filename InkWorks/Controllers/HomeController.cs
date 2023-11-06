using InkWorks.Filters;
using InkWorks.Helper;
using InkWorks.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InkWorks.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessao _sessao;

        public HomeController(ILogger<HomeController> logger, ISessao sessao)
        {
            _logger = logger;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            string nomeUtilizador = _sessao.BuscarSessaoUtilizador().Nome;
            ViewBag.Nome = nomeUtilizador;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}