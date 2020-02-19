using Microsoft.EntityFrameworkCore;
using Roterizador.EntityPostgres;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.IntegrationTests
{
    public class StartUpTestConfig
    {
        public RoterizadorContext GetSarfContextToBDTest()
        {
            var connString = "Host=localhost;Port=5432;Pooling=true;Database=Roterizador;User Id=postgres;Password=LINKINPARK;";

            var options = new DbContextOptionsBuilder<RoterizadorContext>();
            options.UseNpgsql(connString);

            return new RoterizadorContext(options.Options);
        }
    }
}
