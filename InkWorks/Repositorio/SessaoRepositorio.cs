using InkWorks.Data;
using InkWorks.Models;
using Microsoft.EntityFrameworkCore;
namespace InkWorks.Repositorio
{
    public class SessaoRepositorio : ISessaoRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public SessaoRepositorio(AppDbContext context)
        {
            _appDbContext = context;
        }
        public List<Sessao> ListarTodos()
        {
            return _appDbContext.Sessoes
                .Include(t => t.Trabalho)
                .ThenInclude(c => c.Cliente)
                .ToList();
        }

        public List<Sessao> ListarTodosPorId(int id)
        {
            return _appDbContext.Sessoes
                .Where(t => t.TrabalhoId == id)
                .ToList();
        }
        public Sessao ListarPorId(int id)
        {
            return _appDbContext.Sessoes
                .Include(t => t.Trabalho)
                .FirstOrDefault(t => t.Id == id);
        }
        public Sessao Adicionar(Sessao sessao)
        {


            //gravar no banco de dados
            _appDbContext.Sessoes.Add(sessao);
            _appDbContext.SaveChanges();
            return sessao;


        }
        public Sessao Editar(Sessao sessao)
        {
            _appDbContext.Sessoes.Update(sessao);
            _appDbContext.SaveChanges();

            return sessao;
        }
        public Sessao Eliminar(Sessao sessao)
        {
            _appDbContext.Sessoes.Remove(sessao);
            _appDbContext.SaveChanges();
            return sessao;
        }

    }
}
