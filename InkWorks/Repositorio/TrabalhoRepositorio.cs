using InkWorks.Data;
using InkWorks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace InkWorks.Repositorio
{
    public class TrabalhoRepositorio : ITrabalhoRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public TrabalhoRepositorio(AppDbContext context)
        {
            _appDbContext = context;
        }
        public List<Trabalho> ListarTodos()
        {
            return _appDbContext.Trabalhos
                .Include(t => t.Cliente)
                .ThenInclude(c => c.Mensagens) 
                .ToList();
        }

        public List<Trabalho> ListarTodosPorId(int clienteId)
        {
            return _appDbContext.Trabalhos
                .Where(t => t.ClienteId == clienteId)
                .ToList();
        }
        public Trabalho ListarPorId(int id)
        {
            return _appDbContext.Trabalhos.FirstOrDefault(x => x.TrabalhoId == id);
        }
        public Trabalho Adicionar(Trabalho trabalho)
        {
            
                //gravar no banco de dados
                _appDbContext.Trabalhos.Add(trabalho);
                _appDbContext.SaveChanges();
                return trabalho;
            
            
        }
        public Trabalho Editar(Trabalho trabalho)
        {
            _appDbContext.Trabalhos.Update(trabalho);
            _appDbContext.SaveChanges();

            return trabalho;
        }
        public Trabalho Eliminar(Trabalho trabalho)
        {
            _appDbContext.Trabalhos.Remove(trabalho);
            _appDbContext.SaveChanges();
            return trabalho;
        }
       
    }
}
