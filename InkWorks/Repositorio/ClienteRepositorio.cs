using InkWorks.Data;
using InkWorks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace InkWorks.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public ClienteRepositorio(AppDbContext context)
        {
            _appDbContext = context;
        }
        public List<Cliente> ListarTodos()
        {
            return _appDbContext.Clientes.ToList();
        }
        public Cliente ListarPorId(int id)
        {
            return _appDbContext.Clientes.FirstOrDefault(x => x.ClienteId == id);
        }
        public Cliente ListarDetalhesPorId(int id)
        {
            var cliente = _appDbContext.Clientes
                .Include(c => c.Trabalhos)
                .Include(c => c.Mensagens)
                .FirstOrDefault(c => c.ClienteId == id);

            return cliente;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            
                //gravar no banco de dados
                _appDbContext.Clientes.Add(cliente);
                _appDbContext.SaveChanges();
                return cliente;
            
            
        }
        public Cliente Editar(Cliente cliente)
        {
            _appDbContext.Clientes.Update(cliente);
            _appDbContext.SaveChanges();

            return cliente;
        }
        public Cliente Eliminar(Cliente cliente)
        {
            _appDbContext.Clientes.Remove(cliente);
            _appDbContext.SaveChanges();
            return cliente;
        }
       
    }
}
