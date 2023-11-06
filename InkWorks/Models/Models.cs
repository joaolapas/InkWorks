using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InkWorks.Enums;
using Microsoft.EntityFrameworkCore;

namespace InkWorks.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Morada { get; set; }

        [Display(Name = "Ano de Nascimento")]
        public int? AnoNascimento { get; set; }

        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Observacoes { get; set; }

        public List<Trabalho>? Trabalhos { get; set; }

        public List<Mensagem>? Mensagens { get; set; }
        public virtual int? MsgId { get; set; }
    }

    public class Trabalho
    {
        public Trabalho()
        {
            Sessoes = new List<Sessao>();
        }

        public int TrabalhoId { get; set; }

        [Required]
        public string Titulo { get; set; }

        public List<Sessao>? Sessoes { get; set; }

        public int TotalHoras { get; set; }

        public string Estilo { get; set; }

        [Display(Name = "Observações sobre o Trabalho")]
        public string ObservacoesTrabalho { get; set; }

        public int Valor { get; set; }
        public bool Concluido { get; set; }

        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public List<Imagem>? Imagens { get; set; }
    }

    public class Mensagem
    {
        public int MensagemId { get; set; }

        [Required]
        public string MensagemTexto { get; set; }

        public string Nome { get; set; }

        public string Morada { get; set; }

        [Display(Name = "Ano de Nascimento")]
        public int? AnoNascimento { get; set; }

        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime DataEnvio { get; set; }
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

        public int TrabalhoId { get; set; }
        public Trabalho Trabalho { get; set; }
    }

    public class Utilizador
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        public PerfilEnum Perfil { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }
        public bool PasswordValida(string pass)
        {
            return Password == pass;
        }
    }


    public class Sessao
    {
        public int Id { get; set; }

        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de Conclusão")]
        public DateTime DataFinal { get; set; }

        public int TrabalhoId { get; set; }
        public Trabalho Trabalho { get; set; }

        public Cliente Cliente { get; set; }
    }


}
