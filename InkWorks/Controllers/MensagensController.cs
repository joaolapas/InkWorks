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
            
            List<Mensagem> msgs = _repositorio.ListarTodos();
           
            return View("Index", msgs);
        }
        public IActionResult Enviar()
        {
            return View();
        }
        public IActionResult Atribuir(int id)
        {
            Mensagem mensagem = _repositorio.ListarPorId(id);
            if (mensagem == null)
            {
                _notification.Error("Mensagem não encontrada!");
                return RedirectToAction("Index");
            }
            var clientes = _clientes.ListarTodos();
            if (clientes == null)
            {
                _notification.Error("Erro ao carregar clientes!");
                return RedirectToAction("Index");
            }

            ViewBag.Clientes = new SelectList(clientes, "ClienteId", "Nome");

            return View(mensagem);

        }
        public IActionResult Detalhes(int id)
        {
            var msg = _repositorio.ListarPorId(id);
            if (msg == null)
            {
                _notification.Error("Mensagem não encontrada!");
                return RedirectToAction("Index");
            }
            return View(msg);
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var mensagem = _repositorio.ListarPorId(id);

            if (mensagem == null)
            {
                _notification.Error("Mensagem não encontrada!");
                return RedirectToAction("Index");
            }

            return View(mensagem);
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
            if (mensagem == null)
            {
                _notification.Error("Mensagem não encontrada!");
                return RedirectToAction("Index");
            }
            mensagem.ClienteId = msg.ClienteId;

            _repositorio.Editar(mensagem);
            _notification.Success("Mensagem Atribuida!");

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Eliminar(Mensagem mensagem)
        {
            var mensagemParaEliminar = _repositorio.ListarPorId(mensagem.MensagemId);

            if (mensagemParaEliminar == null)
            {
                _notification.Error("Mensagem não encontrada!");
                return RedirectToAction("Index");
            }

            _repositorio.Eliminar(mensagemParaEliminar);
            _notification.Success("Mensagem eliminada com sucesso!");

            return RedirectToAction("Index");
        }


    }
}
