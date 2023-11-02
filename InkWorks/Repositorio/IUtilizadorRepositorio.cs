using InkWorks.Models;

namespace InkWorks.Repositorio
{
    public interface IUtilizadorRepositorio
    {
        List<Utilizador> ListarTodos();
        Utilizador ListarPorId(int id);

        Utilizador Adicionar(Utilizador utilizador);
        Utilizador Editar(Utilizador utilizador);
        Utilizador Eliminar(Utilizador utilizador);
        

    }
}
