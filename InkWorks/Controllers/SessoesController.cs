using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Filters;
using InkWorks.Migrations;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    [UtilizadorLogado]
    public class SessoesController : Controller
    {
        private readonly ISessaoRepositorio _repositorio;
        private readonly ITrabalhoRepositorio _repositorioTrabalhos;
        private readonly IClienteRepositorio _repositorioClientes;
        private readonly INotyfService _notification;
        public SessoesController(ISessaoRepositorio repositorio, ITrabalhoRepositorio repositorioTrabalhos, INotyfService notification, IClienteRepositorio repositorioClientes)
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
            if(sessoes == null)
            {
                _notification.Error("Erro ao carregar sessões!");
                return RedirectToAction("Index");
            }
            return View("Index", sessoes);
        }
        public IActionResult Adicionar(int TrabalhoId)
        {
            var trabalho = _repositorioTrabalhos.ListarPorId(TrabalhoId);

            if (trabalho == null)
            {
                _notification.Error("Trabalho não encontrado!");
                return RedirectToAction("Index");
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
            if (sessao == null)
            {
                _notification.Error("Erro ao carregar detalhes!");
                return RedirectToAction("Index");
            }
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
            if (sessao == null)
            {
                _notification.Error("Erro ao carregar sessão!");
                return RedirectToAction("Index");
            }

            sessao.Duracao = (int)(sessao.DataFinal - sessao.DataInicio).TotalHours;

            _repositorio.Adicionar(sessao);
            _repositorioTrabalhos.AtualizarTotalHorasParaTrabalho(sessao.TrabalhoId);
            _notification.Success("Sessão marcada!");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Sessao sessao)
        {
            if (sessao == null)
            {
                _notification.Error("Erro ao carregar sessão!");
                return RedirectToAction("Index");
            }
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
                _notification.Error("Erro ao carregar sessão!");
                return RedirectToAction("Index");
            }
            _repositorio.Eliminar(sessao);
            _repositorioTrabalhos.AtualizarTotalHorasParaTrabalho(sessao.TrabalhoId);
            _notification.Success("Sessão eliminada!");
            return RedirectToAction("Index");
        }

    }
}
