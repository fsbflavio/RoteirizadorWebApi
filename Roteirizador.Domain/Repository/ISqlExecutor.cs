using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Domain.Repository
{
    public interface ISqlExecutor
    {
        void ExecuteNonQuery(string sql);
        T ExecuteEscalar<T>(string sql);
    }
}
