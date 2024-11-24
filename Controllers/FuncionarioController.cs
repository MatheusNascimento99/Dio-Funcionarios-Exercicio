using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFuncionarios.Context;
using CadastroFuncionarios.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        #region FuncionarioCreate
        [HttpPost]
        public async Task<IActionResult> FuncionarioCreate(Funcionario funcionario)
        {
            _context.Add(funcionario);
            _context.SaveChangesAsync();
            await TableStorageLogger.LogAsync(funcionario, Enum.TipoAcao.Inclusao);
            return Ok(funcionario);
        }
        #endregion

        #region FuncionarioGetAll
        [HttpGet]
        public async Task<IActionResult> FuncionarioGetAll()
        {
            var funcionarios = await _context.Funcionarios.ToListAsync();

            foreach (var funcionario in funcionarios)
            {
                await TableStorageLogger.LogAsync(funcionario, Enum.TipoAcao.Busca);

            }

            return Ok(funcionarios);
        }
        #endregion

        #region  FuncionarioGetId
        [HttpGet("{id}")]
        public async Task<IActionResult> FuncionarioGetId(int id)
        {
            var DbFuncionario = _context.Funcionarios.Find(id);
            if (DbFuncionario == null)
            {
                return NotFound("Funcionário não encontrado!");
            }
            await TableStorageLogger.LogAsync(DbFuncionario, Enum.TipoAcao.Busca);

            return Ok(DbFuncionario);
        }
        #endregion

        #region FuncionarioUpdate
        [HttpPut("{id}")]
        public async Task<IActionResult> FuncionarioUpdate(int id, Funcionario funcionario)
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
            await TableStorageLogger.LogAsync(funcionario, Enum.TipoAcao.Atualizacao);
            return Ok(Dbfuncionario);
        }
        #endregion

        #region FuncionarioDeleteId
        [HttpDelete("{id}")]
        public async Task<IActionResult> FuncionarioDeleteId(int id)
        {
            var DbFuncionario = _context.Funcionarios.Find(id);
            if (DbFuncionario == null)
            {
                return NotFound("Funcionário não encontrado!");
            }
            _context.Funcionarios.Remove(DbFuncionario);
            _context.SaveChangesAsync();
            try
            {
                await TableStorageLogger.LogAsync(DbFuncionario, Enum.TipoAcao.Remocao);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar log no Azure: {ex.Message}");
            }
            return Ok("Funcionário apagado com sucesso");
        }
        #endregion
    }
}