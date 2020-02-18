using Microsoft.EntityFrameworkCore;
using Roterizador.Domain.Model;
using Roterizador.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.EntityPostgres
{
    public class RouteRepository : Repository<Route>, IRouteRepository
    {
        public RouteRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
