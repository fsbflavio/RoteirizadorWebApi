using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roterizador.Domain.Model;
using Roterizador.Domain.Repository;
using Roterizador.EntityPostgres;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roterizador.IntegrationTests
{
    [TestClass]
    public class UnitOfWork_RouteRepopsitory
    {
        private IUnitOfWork unitOfWork;
        private ISqlExecutor sqlExecutor;
        private SqlSeeder seeder;
        private const int insertId = 20000;

        [TestInitialize]
        public void Setup()
        {
            var config = new StartUpTestConfig();
            var context = config.GetSarfContextToBDTest();

            sqlExecutor = new SqlExecutor(context);
            seeder = new SqlSeeder(sqlExecutor);
            unitOfWork = new UnitOfWork(context);
            unitOfWork.BeginTransaction();
        }

        [TestMethod]
        public async Task Add_NewRoute_InsertEntity()
        {
            var itemModel = new Route()
            {
                Id = insertId,
                Descricao = "ROTA TESTE",
                Coordinates = new List<Coordinate>()
                {
                    new Coordinate()
                    {
                        Id = insertId,
                        Latitude = 28.45454f,
                        Longitude = 35.4545f
                    },
                    new Coordinate()
                    {
                        Id = insertId + 1,
                        Latitude = 30.45454f,
                        Longitude = 32.4545f
                    }
                }
            };

            unitOfWork.Routes.Add(itemModel);
            await unitOfWork.CompleteAsync();

            Assert.IsTrue(seeder.HasRowInTable("ROT_ROUTES", "ID_ROUTE", itemModel.Id));
        }

        [TestCleanup]
        public void Clean()
        {
            unitOfWork.Rollback();
        }
    }
}
