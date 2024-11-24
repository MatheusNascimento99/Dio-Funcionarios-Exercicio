using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Data.Tables;
using CadastroFuncionarios.Enum;

namespace CadastroFuncionarios.Entities
{
    public class TableStorageLogger
    {
        private static string connectionString = "UseDevelopmentStorage=true";
        private static string tableName = "FuncionariosLog";

        public static async Task LogAsync(Funcionario funcionario, TipoAcao tipoAcao)
        {
            var tableClient = new TableClient(connectionString, tableName);

            var response = await tableClient.CreateIfNotExistsAsync();

            var log = new FuncionarioLog(funcionario, tipoAcao);

            await tableClient.AddEntityAsync(log);

        }

    }
}