using InkWorks.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace InkWorks.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Morada { get; set; }

        [Display(Name = "Ano de Nascimento")]
        public int AnoNascimento { get; set; }

        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string? Observacoes { get; set; }

        // Relação um-para-muitos com Trabalhos
        public List<Trabalho>? Trabalhos { get; set; }

        // Relação um-para-muitos com Mensagens
        public List<Mensagem>? Mensagens { get; set; }
    }

    public class Trabalho
    {
        public int TrabalhoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de Conclusão")]
        public DateTime DataFinal { get; set; }

        public string Estilo { get; set; }

        [Display(Name = "Observações sobre o Trabalho")]
        public string ObservacoesTrabalho { get; set; }

        public bool Concluido { get; set; }

        // Relação muitos-para-um com Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Relação um-para-muitos com Imagens
        public List<Imagem> Imagens { get; set; }
    }

    public class Mensagem
    {
        public int MensagemId { get; set; }

        [Required]
        public string MensagemTexto { get; set; }

        public string Nome { get; set; }

        public string Morada { get; set; }

        [Display(Name = "Ano de Nascimento")]
        public int AnoNascimento { get; set; }

        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Relação muitos-para-um com Cliente
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }

    public class Imagem
    {
        public int ImagemId { get; set; }

        public string Url { get; set; }

        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Descrição Longa")]
        public string DescricaoLonga { get; set; }

        public string Estilo { get; set; }

        public string Observacoes { get; set; }

        // Relação muitos-para-um com Trabalho
        public int TrabalhoId { get; set; }
        public Trabalho Trabalho { get; set; }
    }
    public class Utilizador
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public  PerfilEnum Perfil { get; set; }
        public string Password { get; set; }
        public DateTime DataCriação { get; set; }
        public DateTime DataAlteração { get; set; }

    }
}

