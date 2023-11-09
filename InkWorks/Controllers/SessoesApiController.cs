using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Filters;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;

[UtilizadorLogado]
public class SessoesApiController : Controller
{
    private readonly ISessaoRepositorio _repositorio;
    private readonly INotyfService _notification;

    public SessoesApiController(ISessaoRepositorio repositorio, INotyfService notification)
    {
        _repositorio = repositorio;
        _notification = notification;
    }

    [HttpGet]
    public IActionResult ObterEventosSessao()
    {
        var sessoes = _repositorio.ListarTodos();
        if (sessoes == null)
        {
            _notification.Error("Sessões não encontradas!");
            return RedirectToAction("Index");
        }
        var eventos = sessoes.Select(s => new
        {
            id = s.Id,
            title = s.Titulo,
            start = s.DataInicio,
            end = s.DataFinal
        });

        return Ok(eventos);
    }
}
