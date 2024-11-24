using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFuncionarios.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroFuncionarios.Context
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options) : base(options)
        {
            
        }

        public DbSet<Funcionario> Funcionarios {get; set;}
    }
}