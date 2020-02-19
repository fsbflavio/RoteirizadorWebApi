using Roterizador.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Roterizador.EntityPostgres
{
    public class SqlExecutor : ISqlExecutor
    {
        private readonly RoterizadorContext context;

        public SqlExecutor(RoterizadorContext context)
        {
            this.context = context;
        }

        public T ExecuteEscalar<T>(string sql)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                context.Database.OpenConnection();
                return (T) command.ExecuteScalar();
            }
        }

        public void ExecuteNonQuery(string sql)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                context.Database.OpenConnection();

                command.ExecuteNonQuery();
            }
        }
    }
}
