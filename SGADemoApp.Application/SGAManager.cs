using SGADemoApp.DAL;
using SGADemoApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace SGADemoApp.Application
{
    /// <summary>
    /// Manager de SGA
    /// </summary>
    public class SGAManager
    {
        private readonly WarehouseLocationDAO warehouseLocationDAO;

        public SGAManager(WarehouseLocationDAO warehouseLocationDAO)
        {
            this.warehouseLocationDAO = warehouseLocationDAO;
        }

        /// <summary>
        /// Obtiene todas las ubicaciones del almacén
        /// </summary>
        /// <returns></returns>
        public List<WarehouseLocation> GetAll()
        {
            try
            {
                var locations = warehouseLocationDAO.GetAll().ToList();

                // Aplicar aquí otras lógicas de negocio necesarias (carga de elementos relacionados, cálculos, etc.)
                // aunque hay que tener en cuenta que Dapper ya puede cargar directamente los elementos relacionados
                // pero de necesitar acciones adicionales, añadirlas aquí.

                return locations;
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                // Aplicar aquí la gestión de errores necesaria

                throw;
            }
        }


        // Añadir otros métodos de carga de datos (por id, por grupo, etc.)


        /// <summary>
        /// Crea las dimensiones del almacén, insertando los registros correspondientes en la base de datos
        /// con el tipo de ubicación 0 (deshabilitado).
        /// </summary>
        /// <param name="xDimension">Número de posiciones longitudinales</param>
        /// <param name="yDimension">Número de posiciones transversales</param>
        /// <param name="zDimension">Número de alturas</param>
        /// <param name="wDimension">Número de posiciones de profundidad por cada altura</param>
        /// <returns></returns>
        public bool PopulateWarehouseDimensions(int xDimension, int yDimension, int zDimension, int wDimension)
        {
            try
            {
                // Levantamos una transacción de ambiente
                using (var trx = new TransactionScope())
                {
                    // Lógica de negocio para la creación de las ubicaciones del almacén
                    // Se podría hacer uso de un servicio de dominio para la creación de las ubicaciones
                    // o bien hacerlo directamente aquí.
                    for (int i = 0; i < xDimension; i++)
                    {
                        for (int j = 0; j < yDimension; j++)
                        {
                            for (int k = 0; k < zDimension; k++)
                            {
                                for (int l = 0; l < wDimension; l++)
                                {
                                    //logger.Info("Registrando ubicación en el almacén: " + i + " " + j + " " + k + " " + l);

                                    var location = new WarehouseLocation
                                    {
                                        TypeId = 0, // De momento tipo 0 (deshabilitado). En un proceso posterior se tendrá que establecer el tipo de ubicación correcto
                                        PositionX = i,
                                        PositionY = j,
                                        PositionZ = k,
                                        PositionW = l
                                    };

                                    warehouseLocationDAO.Insert(location);

                                    //logger.Info("Ubicación registrada en el almacén: " + i + " " + j + " " + k + " " + l);
                                }
                            }
                        }
                    }

                    trx.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                // Aplicar aquí la gestión de errores necesaria

                throw;
            }
        }

        /// <summary>
        /// Actualiza los datos de las ubicaciones del almacén
        /// </summary>
        /// <param name="warehouseLocations"></param>
        /// <returns></returns>
        public bool UpdateWarehouseLocationData(List<WarehouseLocation> warehouseLocations)
        {
            try
            {
                // Levantamos una transacción de ambiente
                using (var trx = new TransactionScope())
                {
                    // Actualizamos las ubicaciones del almacén que se hayan modificado
                    foreach (var location in warehouseLocations)
                    {
                        warehouseLocationDAO.Update(location);
                    }

                    trx.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                // Aplicar aquí la gestión de errores necesaria

                throw;
            }
        }
    }
}
