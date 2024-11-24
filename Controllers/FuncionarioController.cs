using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFuncionarios.Context;
using CadastroFuncionarios.Entities;
using Microsoft.AspNetCore.Mvc;


namespace CadastroFuncionarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioContext _context;
        public FuncionarioController(FuncionarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult FuncionarioCreate(Funcionario funcionario)
        {
            _context.Add(funcionario);
            _context.SaveChanges();
            return Ok(funcionario);
        }

        [HttpGet]
        public IActionResult FuncionarioGetAll()
        {
            var funcionarios = _context.Funcionarios.ToList();
            return Ok(funcionarios);
        }


        [HttpGet("{id}")]
        public IActionResult FuncionarioGetId(int id)
        {
            var DbFuncionario = _context.Funcionarios.Find(id);
            if (DbFuncionario == null)
            {
                return NotFound("Funcionário não encontrado!");
            }
            return Ok(DbFuncionario);
        }

        [HttpPut("{id}")]
        public IActionResult FuncionarioUpdate(int id, Funcionario funcionario)
        {
            var Dbfuncionario = _context.Funcionarios.Find(id);

            if (Dbfuncionario == null)
                return NotFound("Funcionário não encontrado");
            Dbfuncionario.Nome = funcionario.Nome;
            Dbfuncionario.Endereco = funcionario.Endereco;
            Dbfuncionario.Ramal = funcionario.Ramal;
            Dbfuncionario.EmailProfissional = funcionario.EmailProfissional;
            Dbfuncionario.Departamento = funcionario.Departamento;
            Dbfuncionario.Salario = funcionario.Salario;
            Dbfuncionario.DataAdmissao = funcionario.DataAdmissao;
            
            _context.SaveChanges();
            return Ok(Dbfuncionario);
        }







        [HttpDelete("{id}")]
        public IActionResult FuncionarioDeleteId(int id)
        {
            var DbFuncionario = _context.Funcionarios.Find(id);
            if (DbFuncionario == null)
            {
                return NotFound("Funcionário não encontrado!");
            }
            _context.Funcionarios.Remove(DbFuncionario);
            _context.SaveChanges();
            return Ok("Funcionário apagado com sucesso");
        }


    }
}