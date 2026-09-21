using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.DTOs;



namespace BackendForDiploma.Api.Mappers
{
    public static class PointRecordMapper
    {
        public static PointRecordDto ToDto(PointRecord r) =>
            new(r.Id, r.PointId, r.PhotoObjectKey, r.InspectionDate, r.State);
    }
}
