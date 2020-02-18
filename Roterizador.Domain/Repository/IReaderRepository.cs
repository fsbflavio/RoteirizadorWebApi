using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Domain.Repository
{
    public interface IReaderRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
    }
}
