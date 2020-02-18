using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Roterizador.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRouteRepository Routes { get; }
        Task<int> CompleteAsync();
    }
}
