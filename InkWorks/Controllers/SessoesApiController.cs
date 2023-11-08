using InkWorks.Filters;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;

[UtilizadorLogado]
public class SessoesApiController : Controller
{
    private readonly ISessaoRepositorio _repositorio;

    public SessoesApiController(ISessaoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpGet]
    public IActionResult ObterEventosSessao()
    {
        var sessoes = _repositorio.ListarTodos();
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
