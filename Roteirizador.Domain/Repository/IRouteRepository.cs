using Roterizador.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Roterizador.Domain.Repository
{
    public interface IRouteRepository : IRepositoryAsync<Route>
    {
        Task<List<Route>> GetAllCompleteAsync(int pageIndex = 1, int pageSize = 10);
    }
}
