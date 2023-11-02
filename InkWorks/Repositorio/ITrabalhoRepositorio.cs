﻿using InkWorks.Models;

namespace InkWorks.Repositorio
{
    public interface ITrabalhoRepositorio
    {
        List<Trabalho> ListarTodos();
        Trabalho ListarPorId(int id);

        Trabalho Adicionar(Trabalho trabalho);
        Trabalho Editar(Trabalho trabalho);
        Trabalho Eliminar(Trabalho trabalho);
        

    }
}