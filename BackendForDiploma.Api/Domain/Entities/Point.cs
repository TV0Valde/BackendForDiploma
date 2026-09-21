namespace BackendForDiploma.Api.Domain.Entities
{
    /// <summary>
    /// Информационная точка
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор здания
        /// </summary>
        public Guid BuildingId { get; set; }

        /// <summary>
        /// Идентификатор сферы в Unity
        /// </summary>
        public string? SphereObjectName { get; set; }

        /// <summary>
        /// Координата X
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Координата Y
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Координата Z
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// Текущеей состояние (Цвет)
        /// </summary>
        public string? CurrentColor { get; set; }

        /// <summary>
        /// Здание
        /// </summary>
        public Building Building { get; set; }

        /// <summary>
        /// Информационные записи
        /// </summary>
        public List<PointRecord> Records { get; set; }

    }
}
