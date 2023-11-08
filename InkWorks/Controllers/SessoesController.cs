using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Data;
using InkWorks.Filters;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InkWorks.Controllers
{
    [UtilizadorLogado]
    public class SessoesController : Controller
    {
        private readonly ISessaoRepositorio _repositorio;
        private readonly ITrabalhoRepositorio _repositorioTrabalhos;
        private readonly IClienteRepositorio _repositorioClientes;
        private readonly INotyfService _notification;
        public SessoesController(ISessaoRepositorio repositorio,ITrabalhoRepositorio repositorioTrabalhos, INotyfService notification, IClienteRepositorio repositorioClientes)
        {
            _repositorio = repositorio;
            _repositorioTrabalhos = repositorioTrabalhos;
            _repositorioClientes = repositorioClientes;
            _notification = notification;
        }

        public IActionResult Index()
        {
            //Pedir dados
            List<Sessao> sessoes = _repositorio.ListarTodos();
            // Passa os dados para a view
            return View("Index", sessoes);
        }
        public IActionResult Adicionar(int TrabalhoId)
        {
            var trabalho = _repositorioTrabalhos.ListarPorId(TrabalhoId);

            if (trabalho == null)
            {
                
                return RedirectToAction("ClienteNaoEncontrado");
            }

            var sessao = new Sessao
            {
                TrabalhoId = TrabalhoId,
                Trabalho = trabalho
            };
            return View(sessao);
        }
        public IActionResult Detalhes(int id)
        {
            Sessao sessao = _repositorio.ListarPorId(id);
            return View(sessao);

        }


        public IActionResult Editar(int id)
        {
           
            Sessao sessao = _repositorio.ListarPorId(id);

            if (sessao == null)
            {
                _notification.Error("Não foi possível editar esta sessão!");
                return RedirectToAction("Index");
            }

            return View(sessao);
        }
        public IActionResult Eliminar(int id)
        {

            Sessao sessao = _repositorio.ListarPorId(id);

            if (sessao == null)
            {
                _notification.Error("Não foi possível apagar esta sessão!");
                return RedirectToAction("Index");
            }
            

            return View(sessao);
        }

        [HttpPost]
        public IActionResult Adicionar(Sessao sessao)
        {
           
            sessao.Duracao = (int)(sessao.DataFinal - sessao.DataInicio).TotalHours;

            _repositorio.Adicionar(sessao);
            _repositorioTrabalhos.AtualizarTotalHorasParaTrabalho(sessao.TrabalhoId); 
            _notification.Success("Sessão marcada!");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Sessao sessao)
        {
            
            sessao.Duracao = (int)(sessao.DataFinal - sessao.DataInicio).TotalHours;

            _repositorio.Editar(sessao);
            _repositorioTrabalhos.AtualizarTotalHorasParaTrabalho(sessao.TrabalhoId);
            _notification.Success("Sessão modificada!");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(Sessao sessao)
        {
            if (sessao == null)
            {
                return NotFound();
            }
            _repositorio.Eliminar(sessao);
            _repositorioTrabalhos.AtualizarTotalHorasParaTrabalho(sessao.TrabalhoId); 
            _notification.Success("Sessão eliminada!");
            return RedirectToAction("Index");
        }

    }
}
