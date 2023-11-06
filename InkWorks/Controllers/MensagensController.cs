using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Filters;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InkWorks.Controllers
{
    [UtilizadorLogado]
    public class MensagensController : Controller
    {
        private readonly IMensagemRepositorio _repositorio;
        private readonly IClienteRepositorio _clientes;
        private readonly INotyfService _notification;
        public MensagensController(IMensagemRepositorio repositorio, INotyfService notification, IClienteRepositorio clientes)
        {
            _repositorio = repositorio;
            _notification = notification;
            _clientes = clientes;
        }
        public IActionResult Index()
        {
            //Pedir dados
            List<Mensagem> msgs = _repositorio.ListarTodos();
            // Passa os dados para a view
            return View("Index", msgs);
        }
        public IActionResult Enviar()
        {
            return View();
        }
        public IActionResult Atribuir(int id)
        {
            Mensagem mensagem = _repositorio.ListarPorId(id);
            var clientes = _clientes.ListarTodos();

            ViewBag.Clientes = new SelectList(clientes, "ClienteId", "Nome");

            return View(mensagem);

        }
        public IActionResult Detalhes(int id)
        {
            var msg = _repositorio.ListarPorId(id);
            return View(msg);
        }
        [HttpPost]
        public IActionResult Enviar(Mensagem msg)
        {

            _repositorio.Enviar(msg);
            _notification.Success("Mensagem enviada!");
            return RedirectToAction("Index", "Publico");
        }
        [HttpPost]
        public IActionResult Atribuir(Mensagem msg) 
        {
            Mensagem mensagem = _repositorio.ListarPorId(msg.MensagemId);
            mensagem.ClienteId = msg.ClienteId;
            
                _repositorio.Editar(mensagem);
                _notification.Success("Mensagem Atribuida!");
            
            return RedirectToAction("Index");
        }
    }
}
