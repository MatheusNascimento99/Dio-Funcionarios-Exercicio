using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroFuncionarios.Entities;
using CadastroFuncionarios.Enum;

namespace CadastroFuncionarios.Entities
{
    public class FuncionarioLog : Funcionario
    {
        public FuncionarioLog()
        {

        }

        public FuncionarioLog(Funcionario funcionario, TipoAcao tipoAcao, string partitionKey, string rowKey)
        {

        }

        public TipoAcao TipoAcao { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}

       // public Etag Etag { get; set; }