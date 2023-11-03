using InkWorks.Data;
using InkWorks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace InkWorks.Repositorio
{
    public class UtilizadorRepositorio : IUtilizadorRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public UtilizadorRepositorio(AppDbContext context)
        {
            _appDbContext = context;
        }
        public List<Utilizador> ListarTodos()
        {
            return _appDbContext.Utilizadores.ToList();
        }
        public Utilizador ListarPorId(int id)
        {
            return _appDbContext.Utilizadores.FirstOrDefault(x => x.Id == id);
        }
        public Utilizador Adicionar(Utilizador utilizador)
        {
            
                //gravar no banco de dados
                _appDbContext.Utilizadores.Add(utilizador);
                _appDbContext.SaveChanges();
                return utilizador;
            
            
        }
        public Utilizador Editar(Utilizador utilizador)
        {
            _appDbContext.Utilizadores.Update(utilizador);
            _appDbContext.SaveChanges();

            return utilizador;
        }
        public Utilizador Eliminar(Utilizador utilizador)
        {
            _appDbContext.Utilizadores.Remove(utilizador);
            _appDbContext.SaveChanges();
            return utilizador;
        }

        public Utilizador ListartPorLogin(string login)
        {
            return _appDbContext.Utilizadores.FirstOrDefault(x => x.Email.ToUpper() == login.ToUpper());
        }
    }
}
