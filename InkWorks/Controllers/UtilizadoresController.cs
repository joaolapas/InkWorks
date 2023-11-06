using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Data;
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
            //Pedir dados
            List<Utilizador> utilizadores = _repositorio.ListarTodos();
            // Passa os dados para a view
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
                
                return NotFound();
            }
            
            return View(utilizador);
        }
        public IActionResult Eliminar(int id)
        {
           
            Utilizador utilizador = _repositorio.ListarPorId(id);

            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        [HttpPost]
        public IActionResult Adicionar(Utilizador utilizador)
        {

                _repositorio.Adicionar(utilizador);
                _notification.Success("Utilizador adicionado");
                return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(Utilizador utilizador)
        {
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
                return NotFound();
            }
            _repositorio.Eliminar(utilizador);
            _notification.Success("Cliente eliminado");


            return RedirectToAction("Index");
            
        }
    }
}
