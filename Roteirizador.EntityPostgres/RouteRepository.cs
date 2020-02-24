using Microsoft.EntityFrameworkCore;
using Roterizador.Domain.Model;
using Roterizador.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roterizador.EntityPostgres
{
    public class RouteRepository : RepositoryAsync<Route>, IRouteRepository
    {
        public RouteRepository(DbContext context) 
            : base(context)
        {
        }

        public Task<List<Route>> GetAllCompleteAsync(int pageIndex = 1, int pageSize = 10)
        {
            return roterizadorContext.Routes
                .Include(i => i.Coordinates)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        private RoterizadorContext roterizadorContext
        {
            get { return Context as RoterizadorContext; }
        }
    }
}
