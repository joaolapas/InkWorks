using InkWorks.Models;

namespace InkWorks.Repositorio
{
    public interface IClienteRepositorio
    {
        List<Cliente> ListarTodos();
        Cliente ListarPorId(int id);

        public Cliente ListarDetalhesPorId(int id);
        Cliente Adicionar(Cliente cliente);
        Cliente Editar(Cliente cliente);
        Cliente Eliminar(Cliente cliente);
        

    }
}
