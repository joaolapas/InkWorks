using InkWorks.Models;
using Newtonsoft.Json;

namespace InkWorks.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;

        }
        public Utilizador BuscarSessaoUtilizador()
        {
            string sessaoUtilizador = _contextAccessor.HttpContext.Session.GetString("sessaoUtilizador");
            if (string.IsNullOrEmpty(sessaoUtilizador)) return null;
            return JsonConvert.DeserializeObject<Utilizador>(sessaoUtilizador);
        }

        public void CriarSessaoUtilizador(Utilizador user)
        {
            string valor = JsonConvert.SerializeObject(user);
            _contextAccessor.HttpContext.Session.SetString("sessaoUtilizador", valor);
        }

        public void RemoverSessaoUtilizador()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUtilizador");
        }
    }
}
