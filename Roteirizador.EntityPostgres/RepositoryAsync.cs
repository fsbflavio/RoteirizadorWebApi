using Microsoft.EntityFrameworkCore;
using Roterizador.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roterizador.EntityPostgres
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _entities;

        public RepositoryAsync(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public ValueTask<TEntity> GetAsync(int id)
        {
            return _entities.FindAsync(id);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _entities.ToListAsync();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void Attach(TEntity entity)
        {
            _entities.Attach(entity);
        }

        public int Count()
        {
            return _entities.Count();
        }
    }
}
