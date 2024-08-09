using System.Collections.Generic;

namespace SGADemoApp.Domain
{
    /// <summary>
    /// Agrupación de ubicaciones de almacén
    /// Sirve para establecer un nombre lógico a un conjunto de ubicaciones físicas
    /// </summary>
    public class WarehouseLocationGroup
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del grupo (pasillo 1, estantería 1 etc..)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripción del grupo
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ubicaciones del grupo
        /// </summary>
        public List<WarehouseLocation> Locations { get; set; }
    }
}
