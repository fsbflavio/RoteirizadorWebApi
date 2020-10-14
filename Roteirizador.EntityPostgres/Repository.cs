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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
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

        public Task<List<TEntity>> GetAllAsync()
        {
            return _entities.ToListAsync();
        }
    }
}
