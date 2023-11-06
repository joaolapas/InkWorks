using InkWorks.Models;

namespace InkWorks.Repositorio
{
    public interface IMensagemRepositorio
    {
        List<Mensagem> ListarTodos();
        Mensagem ListarPorId(int id);

        Mensagem Enviar(Mensagem msg);
        Mensagem Editar(Mensagem msg);
        Mensagem Eliminar(Mensagem msg);
        

    }
}
