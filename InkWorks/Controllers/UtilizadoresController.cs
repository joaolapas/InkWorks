using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Filters;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    [UtilizadorAdmin]
    public class UtilizadoresController : Controller
    {
        private readonly IUtilizadorRepositorio _repositorio;
        private readonly INotyfService _notification;
        public UtilizadoresController(IUtilizadorRepositorio repositorio, INotyfService notification)
        {
            _repositorio = repositorio;
            _notification = notification;
        }
        public IActionResult Index()
        {
            List<Utilizador> utilizadores = _repositorio.ListarTodos();
            if (utilizadores == null)
            {
                _notification.Error("Erro ao carregar utilizadores!");
                return RedirectToAction("Index");
            }
            return View("Index", utilizadores);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {

            Utilizador utilizador = _repositorio.ListarPorId(id);
            if (utilizador == null)
            {
                _notification.Error("Erro ao carregar utilizador!");
                return RedirectToAction("Index");
            }


            return View(utilizador);
        }
        public IActionResult Eliminar(int id)
        {

            Utilizador utilizador = _repositorio.ListarPorId(id);

            if (utilizador == null)
            {
                _notification.Error("Erro ao carregar utilizador!");
                return RedirectToAction("Index");
            }

            return View(utilizador);
        }

        [HttpPost]
        public IActionResult Adicionar(Utilizador utilizador)
        {
            if (utilizador == null)
            {
                _notification.Error("Erro ao carregar utilizador!");
                return RedirectToAction("Index");
            }
            _repositorio.Adicionar(utilizador);
            _notification.Success("Utilizador adicionado");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(Utilizador utilizador)
        {
            if (utilizador == null)
            {
                _notification.Error("Erro ao carregar utilizador!");
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                _repositorio.Editar(utilizador);
                _notification.Success("Utilizador Editado!");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(Utilizador utilizador)
        {
            if (utilizador == null)
            {
                _notification.Error("Erro ao carregar utilizador!");
                return RedirectToAction("Index");
            }
            _repositorio.Eliminar(utilizador);
            _notification.Success("Cliente eliminado");


            return RedirectToAction("Index");

        }
    }
}
