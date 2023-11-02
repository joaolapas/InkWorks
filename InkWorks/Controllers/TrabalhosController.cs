using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Data;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InkWorks.Controllers
{
    public class TrabalhosController : Controller
    {
        private readonly ITrabalhoRepositorio _repositorio;
        private readonly IClienteRepositorio _repositorioCliente;
        private readonly INotyfService _notification;
        public TrabalhosController(ITrabalhoRepositorio repositorio,IClienteRepositorio repositorioClientes, INotyfService notification)
        {
            _repositorio = repositorio;
            _repositorioCliente = repositorioClientes;
            _notification = notification;
        }

        public IActionResult Index()
        {
            //Pedir dados
            List<Trabalho> trabalhos = _repositorio.ListarTodos();
            // Passa os dados para a view
            return View("Index", trabalhos);
        }
        public IActionResult Adicionar(int ClienteId)
        {
            var cliente = _repositorioCliente.ListarPorId(ClienteId);

            if (cliente == null)
            {
                // Cliente não encontrado, pode lidar com isso adequadamente, como redirecionar para uma página de erro
                return RedirectToAction("ClienteNaoEncontrado");
            }

            var trabalho = new Trabalho
            {
                ClienteId = ClienteId,
                Cliente = cliente // Atribua o objeto de cliente recuperado
            };
            return View(trabalho);
        }


        public IActionResult Editar(int id)
        {
           
            Trabalho trabalho = _repositorio.ListarPorId(id);

            if (trabalho == null)
            {
                return NotFound();
            }

            return View(trabalho);
        }
        public IActionResult Eliminar(int id)
        {

            Trabalho trabalho = _repositorio.ListarPorId(id);

            if (trabalho == null)
            {
                return NotFound();
            }
            

            return View(trabalho);
        }

        [HttpPost]
        public IActionResult Adicionar(Trabalho trabalho)
        {

            _repositorio.Adicionar(trabalho);
            _notification.Success("Trabalho adicionado!");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(Trabalho trabalho)
        {
            if (ModelState.IsValid)
            {
                _repositorio.Editar(trabalho);
            }
            _notification.Success("Trabalho editado!");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(Trabalho trabalho)
        {
            if (trabalho == null)
            {
                return NotFound();
            }
            _repositorio.Eliminar(trabalho);
            _notification.Success("Trabalho eliminado!");


            return RedirectToAction("Index");
            
        }
    }
}
