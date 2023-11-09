using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Helper;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InkWorks.Controllers
{
    public class LoginController : Controller
    {
        private readonly INotyfService _notification;
        private readonly IUtilizadorRepositorio _user;
        private readonly ISessao _sessao;
        public LoginController(INotyfService notification, IUtilizadorRepositorio user, ISessao sessao)
        {
            _notification = notification;
            _user = user;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //se já estiver logado, redireciona para área restrita
            if (_sessao.BuscarSessaoUtilizador() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Utilizador user = _user.ListartPorLogin(login.Email);

                    if (user != null)
                    {
                        if (user.PasswordValida(login.Password))
                        {
                            _sessao.CriarSessaoUtilizador(user);
                            _notification.Success("Autenticado com sucesso!");
                            return RedirectToAction("Index", "Home");
                        }
                        _notification.Error("Email e/ou  passord incorretas");
                        return RedirectToAction("Index", "Login");
                    }

                    _notification.Error("Email e/ou  passord incorretas");
                    return RedirectToAction("Index", "Login");



                }
                _notification.Error("Introduza as credenciais corretas");
                return View("Index");
            }
            catch (Exception)
            {

                _notification.Error("Não conseguimos realizar o Login, tente novamente!");
                return RedirectToAction("Index");
            }

        }

        public IActionResult Logout()
        {
            _sessao.RemoverSessaoUtilizador();
            _notification.Success("Foi desligado com sucesso!");
            return RedirectToAction("Index", "Login");
        }
    }
}
