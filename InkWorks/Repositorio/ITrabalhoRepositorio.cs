using InkWorks.Models;

namespace InkWorks.Repositorio
{
    public interface ITrabalhoRepositorio
    {
        List<Trabalho> ListarTodos();
        List<Trabalho> ListarTodosPorId(int id);
        Trabalho ListarPorId(int id);

        Trabalho Adicionar(Trabalho trabalho);
        Trabalho Editar(Trabalho trabalho);
        Trabalho Eliminar(Trabalho trabalho);
        

    }
}
