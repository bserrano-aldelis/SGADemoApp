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
        /// ¿Realmente es necesaria?
        /// Quizás se pueda calcular a partir de la posición con la combinación de PositionZ y PositionY podría valer?
        /// </summary>
        public int PositionW { get; set; }
    }
}
