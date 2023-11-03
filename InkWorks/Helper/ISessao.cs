using InkWorks.Models;

namespace InkWorks.Helper
{
    public interface ISessao
    {
        void CriarSessaoUtilizador(Utilizador user);
        void RemoverSessaoUtilizador();
        Utilizador BuscarSessaoUtilizador();
    }
}
