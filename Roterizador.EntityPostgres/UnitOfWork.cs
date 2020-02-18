using Roterizador.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Roterizador.EntityPostgres
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RoterizadorContext _context;

        public UnitOfWork(RoterizadorContext context)
        {
            _context = context;
            Routes = new RouteRepository(_context);
        }
        public IRouteRepository Routes { get; private set; }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
