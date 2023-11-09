using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Filters;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    [UtilizadorLogado]
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _repositorio;
        private readonly IMensagemRepositorio _mensagem;
        private readonly ITrabalhoRepositorio _trabalho;
        private readonly INotyfService _notification;
        public ClientesController(IClienteRepositorio repositorio, INotyfService notification, IMensagemRepositorio mensagem, ITrabalhoRepositorio trabalho)
        {
            _repositorio = repositorio;
            _notification = notification;
            _mensagem = mensagem;
            _trabalho = trabalho;
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
        public IActionResult AdicionarPorMsg(int id)
        {
            Mensagem mensagem = _mensagem.ListarPorId(id);

            if (mensagem == null)
            {
                _notification.Error("Não encontrado!");
                return RedirectToAction("Index");
            }

            Cliente novoCliente = new Cliente
            {
                Nome = mensagem.Nome,
                Email = mensagem.Email,
                Morada = mensagem.Morada,
                AnoNascimento = mensagem.AnoNascimento,
                Telefone = mensagem.Telefone,
                MsgId = mensagem.MensagemId
            };


            return View("AdicionarPorMsg", novoCliente);
        }
        public IActionResult Detalhes(int id)
        {

            var cliente = _repositorio.ListarDetalhesPorId(id);
            if (cliente == null)
            {
                _notification.Error("Cliente não encontrado!");
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Editar(int id)
        {

            Cliente cliente = _repositorio.ListarPorId(id);

            if (cliente == null)
            {
                _notification.Error("Cliente não encontrado!");
                return RedirectToAction("Index");
            }

            return View(cliente);
        }
        public IActionResult Eliminar(int id)
        {

            Cliente cliente = _repositorio.ListarPorId(id);

            if (cliente == null)
            {
                _notification.Error("Cliente não encontrado!");
                return RedirectToAction("Index");
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
                _notification.Error("Cliente não encontrado!");
                return RedirectToAction("Index");
            }
            _repositorio.Eliminar(cliente);
            _notification.Success("Cliente eliminado");


            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult AdicionarPorMsg(Cliente cliente)
        {
            int? msgIdNullable = cliente.MsgId;
            int msgId = msgIdNullable.HasValue ? msgIdNullable.Value : 0;


            var mensagem = _mensagem.ListarPorId(msgId);

            if (mensagem != null)
            {

                mensagem.Cliente = cliente;
                mensagem.ClienteId = cliente.ClienteId;

                mensagem.Nome = cliente.Nome;
                mensagem.Email = cliente.Email;
                mensagem.Morada = cliente.Morada;
                mensagem.AnoNascimento = cliente.AnoNascimento;
                mensagem.Telefone = cliente.Telefone;

                _repositorio.Adicionar(cliente);

                _notification.Success("Cliente adicionado com a mensagem associada");
                return RedirectToAction("Index");
            }

            //  situação em que não foi encontrada uma mensagem válida
            _notification.Error("A mensagem não pôde ser associada ao cliente.");
            return View("Adicionar", cliente);
        }






    }
}
