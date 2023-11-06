﻿// <auto-generated />
using System;
using InkWorks.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InkWorks.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231106092553_modMsg2")]
    partial class modMsg2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InkWorks.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<int?>("AnoNascimento")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("InkWorks.Models.Imagem", b =>
                {
                    b.Property<int>("ImagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImagemId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoLonga")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estilo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrabalhoId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImagemId");

                    b.HasIndex("TrabalhoId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("InkWorks.Models.Mensagem", b =>
                {
                    b.Property<int>("MensagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MensagemId"));

                    b.Property<int?>("AnoNascimento")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MensagemTexto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MensagemId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Mensagens");
                });

            modelBuilder.Entity("InkWorks.Models.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrabalhoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TrabalhoId");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("InkWorks.Models.Trabalho", b =>
                {
                    b.Property<int>("TrabalhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrabalhoId"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<bool>("Concluido")
                        .HasColumnType("bit");

                    b.Property<string>("Estilo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObservacoesTrabalho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalHoras")
                        .HasColumnType("int");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("TrabalhoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Trabalhos");
                });

            modelBuilder.Entity("InkWorks.Models.Utilizador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("InkWorks.Models.Imagem", b =>
                {
                    b.HasOne("InkWorks.Models.Trabalho", "Trabalho")
                        .WithMany("Imagens")
                        .HasForeignKey("TrabalhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trabalho");
                });

            modelBuilder.Entity("InkWorks.Models.Mensagem", b =>
                {
                    b.HasOne("InkWorks.Models.Cliente", "Cliente")
                        .WithMany("Mensagens")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("InkWorks.Models.Sessao", b =>
                {
                    b.HasOne("InkWorks.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InkWorks.Models.Trabalho", "Trabalho")
                        .WithMany("Sessoes")
                        .HasForeignKey("TrabalhoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Trabalho");
                });

            modelBuilder.Entity("InkWorks.Models.Trabalho", b =>
                {
                    b.HasOne("InkWorks.Models.Cliente", "Cliente")
                        .WithMany("Trabalhos")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("InkWorks.Models.Cliente", b =>
                {
                    b.Navigation("Mensagens");

                    b.Navigation("Trabalhos");
                });

            modelBuilder.Entity("InkWorks.Models.Trabalho", b =>
                {
                    b.Navigation("Imagens");

                    b.Navigation("Sessoes");
                });
#pragma warning restore 612, 618
        }
    }
}
