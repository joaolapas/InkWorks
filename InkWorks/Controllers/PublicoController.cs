using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Repositorio;
using InkWorks.Models;
using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    public class PublicoController : Controller
    {
        private readonly IImagemRepositorio _repositorio;
        public PublicoController(IImagemRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {



            var imagensPortfolio = _repositorio.ListarTodos();
            PublicoViewModel viewModel = new PublicoViewModel
            {
                ImagensPortfolio = imagensPortfolio
            };

            return View(viewModel);
        }

    }
}
