using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFuncionarios.Entities;
using Azure;
using Azure.Data.Tables;
using CadastroFuncionarios.Enum;





namespace CadastroFuncionarios.Entities
{
    public class FuncionarioLog : ITableEntity
    {
        public TipoAcao TipoAcao { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Nome { get; set; }
        public string EmailProfissional { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public FuncionarioLog(Funcionario funcionario, TipoAcao tipoAcao)
        {
            PartitionKey = funcionario.Id.ToString();
            RowKey = Guid.NewGuid().ToString();
            TipoAcao = tipoAcao;
            Nome = funcionario.Nome;
            EmailProfissional = funcionario.EmailProfissional;
            Timestamp = DateTimeOffset.UtcNow;
        }

        public FuncionarioLog() { }


    }
}
