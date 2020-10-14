using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Domain.Repository
{
    public interface IRepository<TEntity> : IReaderRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
