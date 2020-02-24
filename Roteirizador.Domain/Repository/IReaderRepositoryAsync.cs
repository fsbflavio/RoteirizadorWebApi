using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Roterizador.Domain.Repository
{
    public interface IReaderRepositoryAsync<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetAsync(int Id);

        Task<List<TEntity>> GetAllAsync();
    }
}
