namespace BackendForDiploma.Api.Domain.Entities
{
    /// <summary>
    /// Здание
    /// </summary>
    public class Building
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Ключ в MinIO
        /// </summary>
        public string ModelObjectKey { get; set; }

        /// <summary>
        /// Формат модели
        /// </summary>
        public string ModelFormat { get; set; }

        /// <summary>
        /// дата добавления
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Информационные точки
        /// </summary>
        public List<Point> Points { get; set; }
    }
}
