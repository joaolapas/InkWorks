using InkWorks.Models;

namespace InkWorks.Repositorio
{
    public interface IImagemRepositorio
    {
        List<Imagem> ListarTodos();
        Imagem ListarPorId(int id);

        Imagem Adicionar(Imagem img);
        Imagem Editar(Imagem img);
        Imagem Eliminar(Imagem img);


    }
}
