using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Filters;
using InkWorks.Migrations;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    [UtilizadorLogado]
    public class TrabalhosController : Controller
    {
        private readonly ITrabalhoRepositorio _repositorio;
        private readonly IClienteRepositorio _repositorioCliente;
        private readonly INotyfService _notification;
        public TrabalhosController(ITrabalhoRepositorio repositorio, IClienteRepositorio repositorioClientes, INotyfService notification)
        {
            _repositorio = repositorio;
            _repositorioCliente = repositorioClientes;
            _notification = notification;
        }

        public IActionResult Index()
        {
            List<Trabalho> trabalhos = _repositorio.ListarTodos();
            if (trabalhos == null)
            {
                _notification.Error("Erro ao carregar trabalhos!");
                return RedirectToAction("Index");
            }
            return View("Index", trabalhos);
        }
        public IActionResult Adicionar(int ClienteId)
        {
            var cliente = _repositorioCliente.ListarPorId(ClienteId);

            if (cliente == null)
            {
                _notification.Error("Erro ao carregar trabalhos!");
                return RedirectToAction("Index");
            }

            var trabalho = new Trabalho
            {
                ClienteId = ClienteId,
                Cliente = cliente 
            };
            return View(trabalho);
        }
        public IActionResult Detalhes(int id)
        {
            Trabalho trabalho = _repositorio.ListarPorId(id);
            if (trabalho == null)
            {
                _notification.Error("Erro ao carregar trabalho!");
                return RedirectToAction("Index");
            }
            return View(trabalho);

        }


        public IActionResult Editar(int id)
        {

            Trabalho trabalho = _repositorio.ListarPorId(id);

            if (trabalho == null)
            {
                _notification.Error("Erro ao carregar trabalho!");
                return RedirectToAction("Index");
            }

            return View(trabalho);
        }
        public IActionResult Eliminar(int id)
        {

            Trabalho trabalho = _repositorio.ListarPorId(id);

            if (trabalho == null)
            {
                _notification.Error("Erro ao carregar trabalho!");
                return RedirectToAction("Index");
            }


            return View(trabalho);
        }

        [HttpPost]
        public IActionResult Adicionar(Trabalho trabalho)
        {
            if (trabalho == null)
            {
                _notification.Error("Erro ao carregar trabalho!");
                return RedirectToAction("Index");
            }

            _repositorio.Adicionar(trabalho);
            _notification.Success("Trabalho adicionado!");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(Trabalho trabalho)
        {
            if (trabalho == null)
            {
                _notification.Error("Erro ao carregar trabalho!");
                return RedirectToAction("Index");
            }
            _repositorio.Editar(trabalho);
            _notification.Success("Trabalho editado!");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(Trabalho trabalho)
        {
            if (trabalho == null)
            {
                _notification.Error("Erro ao carregar trabalho!");
                return RedirectToAction("Index");
            }
            _repositorio.Eliminar(trabalho);
            _notification.Success("Trabalho eliminado!");


            return RedirectToAction("Index");

        }
    }
}
