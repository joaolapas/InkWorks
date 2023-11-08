using AspNetCoreHero.ToastNotification.Abstractions;
using InkWorks.Data;
using InkWorks.Filters;
using InkWorks.Models;
using InkWorks.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InkWorks.Controllers
{
    [UtilizadorLogado]
    public class ImagensController : Controller
    {
        private readonly IImagemRepositorio _repositorio;
        private readonly ITrabalhoRepositorio _trabalhos;
        private readonly INotyfService _notification;
        public ImagensController(IImagemRepositorio repositorio, INotyfService notification, ITrabalhoRepositorio trabalhos)
        {
            _repositorio = repositorio;
            _notification = notification;
            _trabalhos = trabalhos;
        }
        public IActionResult Index()
        {
            var imagens = _repositorio.ListarTodos(); 
            var trabalhos = _trabalhos.ListarTodos(); 

            var viewModel = new ImagemTrabalhoViewModel
            {
                Imagens = imagens,
                Trabalhos = trabalhos
            };

            return View(viewModel);
        }

        public IActionResult Editar(int id)
        {
            Imagem img = _repositorio.ListarPorId(id);
            var trabalhos = _trabalhos.ListarTodos();

            if (img == null)
            {
                return NotFound();
            }

            var viewModel = new ImagemTrabalhoViewModel
            {
                Imagens = new List<Imagem> { img },
                Trabalhos = trabalhos
            };

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Imagem img = _repositorio.ListarPorId(id);
            return View(img);
        }




        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile imagem, string titulo, string descricao, bool galeria, int TrabalhoId)
        {
            if (imagem != null && imagem.Length > 0)
            {
                try
                {
                    
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                    
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    
                    var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(imagem.FileName);

                    var caminhoCompleto = Path.Combine(uploadsFolder, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await imagem.CopyToAsync(stream);
                    }

                    
                    Imagem imagemModel;

                   
                        imagemModel = new Imagem
                        {
                            Url = "/uploads/" + nomeArquivo, 
                            Titulo = titulo,
                            Descricao = descricao,
                            Portfolio = galeria,
                            TrabalhoId = TrabalhoId != 0 ? TrabalhoId : (int?)null
                        };
                   

                    _repositorio.Adicionar(imagemModel);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _notification.Error("Não Conseguimos carregar a sua imagem :(");
                }
            }

            _notification.Error("Oops!! Algo deu errado! tente novamente!");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(ImagemTrabalhoViewModel viewModel)
        {

                Imagem imagemExistente = _repositorio.ListarPorId(viewModel.Imagens[0].ImagemId);
                if (imagemExistente != null)
                {
                    imagemExistente.Titulo = viewModel.Imagens[0].Titulo;
                    imagemExistente.Descricao = viewModel.Imagens[0].Descricao;
                    imagemExistente.Portfolio = viewModel.Imagens[0].Portfolio;
                    imagemExistente.TrabalhoId = viewModel.TrabalhoId != 0 ? viewModel.TrabalhoId : (int?)null;

                    _repositorio.Editar(imagemExistente);
                    _notification.Success("Dados da Imagem atualizados!");
                    return RedirectToAction("Index");
                }
                else
                {
                   
                    _notification.Error("Imagem não encontrada.");
                    return View(viewModel); 
                }
            
        }

        
        public IActionResult ConfirmaEliminar(int id)
        {
            Imagem imagem = _repositorio.ListarPorId(id);

            if (imagem == null)
            {
                return NotFound();
            }

            // Remova o registro do banco de dados
            _repositorio.Eliminar(imagem);

            // Exclua a imagem do sistema de arquivos
            if (!string.IsNullOrEmpty(imagem.Url))
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagem.Url.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _notification.Success("Imagem eliminada");
            return RedirectToAction("Index");
        }


    }
}