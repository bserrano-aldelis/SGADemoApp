using Dapper;
using SGADemoApp.Domain;
using System.Collections.Generic;

namespace SGADemoApp.DAL
{
    /// <summary>
    /// Acceso a datos de las localizaciones de almacén
    /// </summary>
    public class WarehouseLocationDAO
    {
        // Proveedor de conexión a base de datos
        private readonly DbProvider dbProvider;

        // Columnas para las consultas
        private const string FIELDS = @"wl.Id, 
                                       wl.TypeId, 
                                       wl.PositionX, 
                                       wl.PositionY, 
                                       wl.PositionZ, 
                                       wl.PositionW,
                                       wl.ItemsLimit";


        /// <summary>
        /// Constructor principal
        /// </summary>
        /// <param name="connection">Conexión a base de datos</param>
        public WarehouseLocationDAO(DbProvider dbProvider)
        {
            this.dbProvider = dbProvider;
        }

        /// <summary>
        /// Obtiene las localizaciones de un grupo de localizaciones
        /// </summary>
        /// <param name="locationGroupId"></param>
        /// <returns></returns>
        public IEnumerable<WarehouseLocation> GetByLocationGroup(int locationGroupId)
        {
            var conn = dbProvider.GetConnection();
            return conn.Query<WarehouseLocation>($@"SELECT {FIELDS} 
                                                        FROM WarehouseLocation wl
                                                        INNER JOIN WarehouseLocationGroupRelation wlgr ON wl.Id = wlgr.LocationId
                                                        WHERE wlgr.LocationGroupId = @LocationGroupId", new { LocationGroupId = locationGroupId });
        }

        /// <summary>
        /// Obtiene todas las localizaciones
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WarehouseLocation> GetAll()
        {
            var conn = dbProvider.GetConnection();
            return conn.Query<WarehouseLocation>($"SELECT {FIELDS} FROM WarehouseLocation wl");
        }

        /// <summary>
        /// Obtiene una localización por su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public WarehouseLocation GetById(int id)
        {
            var conn = dbProvider.GetConnection();
            return conn.QuerySingle<WarehouseLocation>($"SELECT {FIELDS} FROM WarehouseLocation wl WHERE wl.Id = @Id", new { Id = id });
        }

        /// <summary>
        /// Inserta una nueva localización
        /// </summary>
        /// <param name="location"></param>
        public void Insert(WarehouseLocation location)
        {
            var conn = dbProvider.GetConnection();
            conn.Execute($@"INSERT INTO WarehouseLocation (Id, TypeId, PositionX, PositionY, PositionZ, PositionW, ItemsLimit)
                                  VALUES (@Id, @TypeId, @PositionX, @PositionY, @PositionZ, @PositionW, @ItemsLimit)", location);
        }

        /// <summary>
        /// Actualiza una localización
        /// </summary>
        /// <param name="location"></param>
        public void Update(WarehouseLocation location)
        {
            var conn = dbProvider.GetConnection();
            conn.Execute($@"UPDATE WarehouseLocation 
                                  SET TypeId = @TypeId, 
                                      PositionX = @PositionX, 
                                      PositionY = @PositionY, 
                                      PositionZ = @PositionZ, 
                                      PositionW = @PositionW,
                                      ItemsLimit = @ItemsLimit
                                  WHERE Id = @Id", location);
        }

        /// <summary>
        /// Elimina una localización
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var conn = dbProvider.GetConnection();
            conn.Execute("DELETE FROM WarehouseLocation WHERE Id = @Id", new { Id = id });
        }
    }
}
