namespace BackendForDiploma.Api.Domain.Entities
{
    /// <summary>
    /// Информационная запись
    /// </summary>
    public class PointRecord
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Идентификатор точки
        /// </summary>
        public Guid PointId { get; set; }

        /// <summary>
        /// Ключ в MinIO
        /// </summary>
        public string? PhotoObjectKey { get; set; } 

        /// <summary>
        /// Дата обследования
        /// </summary>
        public string InspectionDate { get; set; } = string.Empty;

        /// <summary>
        /// Состояние в точке записи
        /// </summary>
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Информационная точка
        /// </summary>
        public Point? Point { get; set; }
    }
}