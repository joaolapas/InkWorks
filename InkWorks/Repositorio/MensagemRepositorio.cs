using InkWorks.Data;
using InkWorks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace InkWorks.Repositorio
{
    public class MensagemRepositorio : IMensagemRepositorio
    {
        private readonly AppDbContext _appDbContext;
        public MensagemRepositorio(AppDbContext context)
        {
            _appDbContext = context;
        }
        public List<Mensagem> ListarTodos()
        {
            return _appDbContext.Mensagens.ToList();
        }
        public Mensagem ListarPorId(int id)
        {
            return _appDbContext.Mensagens.FirstOrDefault(x => x.MensagemId == id);
        }
        public Mensagem Enviar(Mensagem msg)
        {
            msg.DataEnvio = DateTime.Now;
            
            //gravar no banco de dados
            _appDbContext.Mensagens.Add(msg);
            _appDbContext.SaveChanges();
            return msg;
            
            
        }
        public Mensagem Editar(Mensagem msg)
        {
            _appDbContext.Mensagens.Update(msg);
            _appDbContext.SaveChanges();

            return msg;
        }
        public Mensagem Eliminar(Mensagem msg)
        {
            _appDbContext.Mensagens.Remove(msg);
            _appDbContext.SaveChanges();
            return msg;
        }
       
    }
}
