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
        public ClientesController(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
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
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = _repositorio.ListarPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }
        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Cliente cliente)
        {

                _repositorio.Adicionar(cliente);
                return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Editar(cliente);
            }
            return RedirectToAction("Index");
        }
    }
}
