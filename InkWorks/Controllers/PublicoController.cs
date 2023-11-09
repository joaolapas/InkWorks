using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    public class PublicoController : Controller
    {
        private readonly IImagemRepositorio _repositorio;
        private readonly INotyfService _notification;
        private readonly IMensagemRepositorio _mensagem;
        public PublicoController(IImagemRepositorio repositorio, INotyfService notification, IMensagemRepositorio mensagem)
        {
            _repositorio = repositorio;
            _notification = notification;
            _mensagem = mensagem;
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
        public IActionResult Enviar(PublicoViewModel publico)
        {
            Mensagem msg = publico.Mensagem;
            _mensagem.Enviar(msg);
            _notification.Success("Mensagem enviada!");
            return RedirectToAction("Index", "Publico");
        }

    }
}
