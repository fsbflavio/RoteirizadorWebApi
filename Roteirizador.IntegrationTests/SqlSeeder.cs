using Roterizador.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roterizador.IntegrationTests
{
    public class SqlSeeder
    {
        private readonly ISqlExecutor sqlExecutor;

        public SqlSeeder(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public void SeedDependences(params string[] sqlsToSeed)
        {
            foreach (var sql in sqlsToSeed)
                sqlExecutor.ExecuteNonQuery(sql);
        }

        public bool HasRowInTable(string table, string column, int value)
        {
            var sql = "SELECT \"" + column + "\" FROM \"" + table + "\" WHERE \"" + column + "\" = " + value;
            var item = sqlExecutor.ExecuteEscalar<int>(sql);

            return (item > 0);
        }

        public string GetSqlRoute(int idRoute, int startId, int endId)
        {
            return "INSERT INTO ROT_ROUTES (ID_ROUTE,StartId,EndId) values ('" + idRoute + "', '" + startId + "','" + endId + "')";
        }

        public string GetSqlCoordinates(int idCoordinate, int Longitude, int Latitude)
        {
            return "INSERT INTO ROT_COORDINATES (ID_COORDINATE,Longitude,Latitude) values ('" + idCoordinate + "', '" + Longitude + "','" + Latitude + "')";
        }
    }
}
