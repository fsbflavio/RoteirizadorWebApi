using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.Domain.Repository
{
    public interface IRepositoryAsync<TEntity> : IReaderRepositoryAsync<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
