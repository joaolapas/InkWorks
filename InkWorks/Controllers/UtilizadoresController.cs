using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Data;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InkWorks.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _repositorio;
        private readonly INotyfService _notification;
        public ClientesController(IClienteRepositorio repositorio, INotyfService notification)
        {
            _repositorio = repositorio;
            _notification = notification;
        }
        public IActionResult Index()
        {
            //Pedir dados
            List<Cliente> clientes = _repositorio.ListarTodos();
            // Passa os dados para a view
            return View("Index", clientes);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
           
            Cliente cliente = _repositorio.ListarPorId(id);

            if (cliente == null)
            {
                
                return NotFound();
            }
            
            return View(cliente);
        }
        public IActionResult Eliminar(int id)
        {
           
            Cliente cliente = _repositorio.ListarPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Adicionar(Cliente cliente)
        {

                _repositorio.Adicionar(cliente);
                _notification.Success("Cliente adicionado");
                return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Editar(cliente);
                _notification.Success("Cliente Editado!");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(Cliente cliente)
        {
            if (cliente == null)
            {
                return NotFound();
            }
            _repositorio.Eliminar(cliente);
            _notification.Success("Cliente eliminado");


            return RedirectToAction("Index");
            
        }
    }
}
