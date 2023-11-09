using InkWorks.Data;
using InkWorks.Models;
using Microsoft.EntityFrameworkCore;
namespace InkWorks.Repositorio
{
    public class ImagemRepositorio : IImagemRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public ImagemRepositorio(AppDbContext context)
        {
            _appDbContext = context;
        }
        public List<Imagem> ListarTodos()
        {
            return _appDbContext.Imagens.Include(c => c.Trabalho).ToList();
        }
        public Imagem ListarPorId(int id)
        {
            return _appDbContext.Imagens.FirstOrDefault(x => x.ImagemId == id);
        }
        public Imagem Adicionar(Imagem img)
        {

            _appDbContext.Imagens.Add(img);
            _appDbContext.SaveChanges();
            return img;


        }
        public Imagem Editar(Imagem img)
        {
            _appDbContext.Imagens.Update(img);
            _appDbContext.SaveChanges();

            return img;
        }
        public Imagem Eliminar(Imagem img)
        {
            _appDbContext.Imagens.Remove(img);
            _appDbContext.SaveChanges();
            return img;
        }


    }
}
