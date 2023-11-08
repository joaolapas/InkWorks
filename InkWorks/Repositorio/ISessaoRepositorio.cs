using InkWorks.Models;

namespace InkWorks.Repositorio
{
    public interface ISessaoRepositorio
    {
        List<Sessao> ListarTodos();
        List<Sessao> ListarTodosPorId(int id);
        Sessao ListarPorId(int id);

        Sessao Adicionar(Sessao sessao);
        Sessao Editar(Sessao sessao);
        Sessao Eliminar(Sessao sessao);
        

    }
}
