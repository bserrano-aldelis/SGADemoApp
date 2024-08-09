using Dapper;
using SGADemoApp.Domain;
using System.Collections.Generic;
using System.Data;

namespace SGADemoApp.DAL
{
    public class WarehouseLocationDAO
    {
        IDbConnection connection;

        private const string FIELDS = @"Id, 
                                       TypeId, 
                                       PositionX, 
                                       PositionY, 
                                       PositionZ, 
                                       PositionW";


        public WarehouseLocationDAO(IDbConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<WarehouseLocation> GetByLocationGroup(int locationGroupId)
        {
            return connection.Query<WarehouseLocation>($@"SELECT {FIELDS} FROM WarehouseLocation 
                                                        WHERE LocationGroupId = @LocationGroupId", new { LocationGroupId = locationGroupId });
        }

        public IEnumerable<WarehouseLocation> GetAll()
        {
            return connection.Query<WarehouseLocation>($"SELECT {FIELDS} FROM WarehouseLocation");
        }

        public WarehouseLocation GetById(int id)
        {
            return connection.QueryFirstOrDefault<WarehouseLocation>($"SELECT {FIELDS} FROM WarehouseLocation WHERE Id = @Id", new { Id = id });
        }


    }
}
