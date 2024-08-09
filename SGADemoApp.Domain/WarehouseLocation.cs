namespace SGADemoApp.Domain
{
    public class WarehouseLocation
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tipo de ubicación
        /// </summary>
        public WarehouseLocationType LocationType
        {
            get
            {
                return (WarehouseLocationType)TypeId;
            }
        }

        /// <summary>
        /// Identificador del tipo de ubicación
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Posición longitudinal
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// Posicion transversal
        /// </summary>
        public int PositionY { get; set; }

        /// <summary>
        /// Posición vertical
        /// </summary>
        public int PositionZ { get; set; }

        /// <summary>
        /// Posición de profundidad
        /// </summary>
        public int PositionW { get; set; }

        /// <summary>
        /// Límite de artículos que puede contener la ubicación
        /// </summary>
        public int ItemsLimit { get; set; } = 1;
    }
}
